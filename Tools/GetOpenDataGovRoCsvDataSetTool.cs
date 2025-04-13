using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using OpenDataGovRo.Factory;

namespace OpenDataGovRo.Tools
{
    [McpServerToolType]
    public static class GetOpenDataGovRoCsvDataSetTool
    {
        // Create a static logger for this class
        private static readonly ILogger logger = LoggerFactory.Create(builder =>
            builder.AddConsole().SetMinimumLevel(LogLevel.Debug))
            .CreateLogger(nameof(GetOpenDataGovRoCsvDataSetTool));

        static GetOpenDataGovRoCsvDataSetTool()
        {
            logger.LogInformation("GetOpenDataGovRoCsvDataSetTool static constructor called");
        }

        [McpServerTool, Description("Download CSV dataset from data.gov.ro using a predefined key")]
        public static async Task<string> DownloadOpenDataGovRoCsvDataSetByKey(
            [Description("Key of the dataset in the predefined list")] string datasetKey
        )
        {
            logger.LogInformation("DownloadOpenDataGovRoCsvDataSetByKey called with key: {datasetKey}", datasetKey);

            if (string.IsNullOrEmpty(datasetKey))
            {
                logger.LogError("Dataset key cannot be empty");
                throw new McpException("Dataset key cannot be empty", 400);
            }

            try
            {
                // Get the URL using the GetDataGovRoUrlByKey method
                string datasetUrl = GetDataGovRoUrlByKeyTool.GetDataGovRoUrlByKey(datasetKey);
                
                // Use the existing method to download the dataset
                return await DownloadOpenDataGovRoCsvDataSetByUrl(datasetUrl);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error downloading CSV data for key: {datasetKey}", datasetKey);
                throw new McpException($"Failed to download CSV data: {ex.Message}", 500);
            }
        }

        [McpServerTool, Description("Download CSV dataset from data.gov.ro")]
        public static async Task<string> DownloadOpenDataGovRoCsvDataSetByUrl(
            [Description("URL of the CSV dataset on data.gov.ro")] string datasetUrl
        )
        {
            logger.LogInformation("DownloadOpenDataGovRoCsvDataSet called with URL: {datasetUrl}", datasetUrl);

            if (string.IsNullOrEmpty(datasetUrl))
            {
                logger.LogError("Dataset URL cannot be empty");
                throw new McpException("Dataset URL cannot be empty", 400);
            }

            var outputFilePath = string.Empty;
            try
            {
                var dllLocation = System.Reflection.Assembly.GetExecutingAssembly().Location; // Get the location of the executing assembly           
                var assemblyLocation = Path.GetDirectoryName(dllLocation);
                outputFilePath = Path.Combine(!string.IsNullOrEmpty(assemblyLocation) ? assemblyLocation : "./", "Resources"); 

                // Ensure directory exists
                Directory.CreateDirectory(outputFilePath);
                
                // extract file name from URL
                var uri = new Uri(datasetUrl);
                var fileName = uri.Segments.LastOrDefault() ?? $"dataset_{DateTime.Now:yyyyMMdd_HHmmss}.csv"; // Use a default name if the last segment is null or empty
                outputFilePath = Path.Combine(outputFilePath, fileName); // Combine the directory and file name to create the full path

                if (!string.IsNullOrEmpty(outputFilePath))
                {
                    var httpClient = HttpClientFactory.Client;

                    logger.LogInformation("Downloading CSV data from {datasetUrl}", datasetUrl);
                    var response = await httpClient.GetAsync(datasetUrl);
                    response.EnsureSuccessStatusCode();

                    var csvContent = await response.Content.ReadAsStringAsync();
                    logger.LogInformation("Successfully downloaded {bytes} bytes of CSV data", csvContent.Length);
                                        
                    logger.LogInformation("Saving CSV data to {outputFilePath}", outputFilePath);
                    await File.WriteAllTextAsync(outputFilePath, csvContent);
                    logger.LogInformation("CSV data saved successfully");
                }

                return outputFilePath;
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, "Error downloading CSV data from {datasetUrl}", datasetUrl);
                throw new McpException($"Failed to download CSV data: {ex.Message}", 500);
            }
            catch (IOException ex)
            {
                logger.LogError(ex, "Error saving CSV data to {outputFilePath}", outputFilePath);
                throw new McpException($"Failed to save CSV data: {ex.Message}", 500);
            }
        }
    }
}