using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using OpenDataGovRo.Factory;
using System.Text;
using ClosedXML.Excel;

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
            // No license setup needed for ClosedXML as it uses MIT license
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
                    if(File.Exists(outputFilePath))
                    {
                        var existingFileInfo = new FileInfo(outputFilePath);
                        logger.LogInformation("File already exists {outputFilePath}", existingFileInfo.FullName);

                        var existingLocalVolumePath = ReplaceFilePathToLocal(existingFileInfo.FullName);
                        return existingLocalVolumePath;
                    }

                    logger.LogInformation("File does not exist, downloading: {outputFilePath}", outputFilePath);
                    
                    // Create a new HttpClient instance
                    var httpClient = HttpClientFactory.Client;

                    logger.LogInformation("Downloading CSV data from {datasetUrl}", datasetUrl);
                    var response = await httpClient.GetAsync(datasetUrl);
                    response.EnsureSuccessStatusCode();

                    var csvContent = await response.Content.ReadAsStringAsync();
                    logger.LogInformation("Successfully downloaded {bytes} bytes of CSV data", csvContent.Length);
                    
                    // Check if the file is an XLSX file based on the URL or file extension
                    bool isXlsxFile = datasetUrl.Contains(".xlsx", StringComparison.OrdinalIgnoreCase) || 
                                     fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase);
                    
                    if (isXlsxFile)
                    {
                        // Create a temporary path for the XLSX file
                        var xlsxFilePath = outputFilePath;
                        
                        // If the output path doesn't end with .xlsx, add it
                        if (!xlsxFilePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                        {
                            xlsxFilePath += ".xlsx";
                        }
                        
                        // Create a path for the CSV file (replace .xlsx with .csv)
                        outputFilePath = outputFilePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) 
                            ? outputFilePath.Replace(".xlsx", ".csv", StringComparison.OrdinalIgnoreCase) 
                            : outputFilePath + ".csv";
                        
                        logger.LogInformation("File is XLSX, will convert to CSV. XLSX path: {xlsxPath}, CSV path: {csvPath}", xlsxFilePath, outputFilePath);
                        
                        // Save the xlsx content to a temporary file
                        await File.WriteAllBytesAsync(xlsxFilePath, await response.Content.ReadAsByteArrayAsync());
                        
                        // Convert the XLSX file to CSV
                        ConvertXlsxToCsv(xlsxFilePath, outputFilePath);
                        
                        // Delete the original XLSX file after conversion
                        if (File.Exists(xlsxFilePath))
                        {
                            File.Delete(xlsxFilePath);
                            logger.LogInformation("Original XLSX file deleted: {xlsxPath}", xlsxFilePath);
                        }
                    }
                    else
                    {
                        // For CSV files, just save as usual
                        await File.WriteAllTextAsync(outputFilePath, csvContent);
                    }
                    
                    logger.LogInformation("Data saved successfully to {path}", outputFilePath);
                }

                // get ful path of the file
                var fileInfo = new FileInfo(outputFilePath);
                if (!fileInfo.Exists)
                {
                    logger.LogError("File does not exist after download: {outputFilePath}", outputFilePath);
                    throw new McpException($"File does not exist after download: {outputFilePath}", 500);
                }

                logger.LogInformation("File downloaded successfully: {outputFilePath}", fileInfo.FullName);

                var localVolumePath = ReplaceFilePathToLocal(fileInfo.FullName);
                return localVolumePath;
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

        // This method is used to replace the path in the CSV file with the local volume path
        private static string ReplaceFilePathToLocal(string fullFileName)
        {
            var localVolumePath = EnvironmentUtils.GetLocalVolumePath();
            logger.LogInformation("Local volume path: {localVolumePath}", localVolumePath);

            string localFilePath = fullFileName.Replace("/app/build/Resources", localVolumePath, StringComparison.OrdinalIgnoreCase);
            logger.LogInformation("Local file path: {localFilePath}", localFilePath);

            return localFilePath; // Return the full path of the downloaded file
        }

        private static void ConvertXlsxToCsv(string xlsxFilePath, string csvFilePath)
        {
            logger.LogInformation("Converting XLSX to CSV: {xlsxFilePath} -> {csvFilePath}", xlsxFilePath, csvFilePath);
            
            try
            {
                // Load the Excel workbook using ClosedXML
                using (var workbook = new XLWorkbook(xlsxFilePath))
                {
                    // Get the first worksheet
                    var worksheet = workbook.Worksheet(1);
                    if (worksheet == null)
                    {
                        logger.LogWarning("No worksheets found in the Excel file");
                        return;
                    }
                    
                    // Get the used range of cells to determine dimensions
                    var usedRange = worksheet.RangeUsed();
                    if (usedRange == null)
                    {
                        logger.LogWarning("Worksheet is empty");
                        return;
                    }
                    
                    int rowCount = usedRange.RowCount();
                    int colCount = usedRange.ColumnCount();
                    
                    logger.LogInformation("Converting Excel file with {rows} rows and {columns} columns", rowCount, colCount);
                    
                    // Create a StringBuilder to hold the CSV data
                    var csv = new StringBuilder();
                    
                    // Process each row in the used range
                    for (int row = 1; row <= rowCount; row++)
                    {
                        var rowValues = new List<string>();
                        
                        // Process each column in the row
                        for (int col = 1; col <= colCount; col++)
                        {
                            // Get the cell
                            var cell = worksheet.Cell(row, col);
                            string cellValue = string.Empty;
                            
                            // Extract the cell value based on its type
                            if (!cell.IsEmpty())
                            {
                                // Handle different cell types
                                if (cell.DataType == XLDataType.DateTime)
                                {
                                    // Format dates consistently
                                    cellValue = cell.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else
                                {
                                    // For other types, get the text value
                                    cellValue = cell.GetString();
                                }
                                
                                // If the cell value contains a semicolon, quote it
                                if (cellValue.Contains(";") || cellValue.Contains("\"") || cellValue.Contains("\n"))
                                {
                                    cellValue = $"\"{cellValue.Replace("\"", "\"\"")}\"";
                                }
                            }
                            
                            rowValues.Add(cellValue);
                        }
                        
                        // Add the row to the CSV using semicolons as separators
                        csv.AppendLine(string.Join(";", rowValues));
                    }
                    
                    // Write the CSV to file
                    File.WriteAllText(csvFilePath, csv.ToString());
                    logger.LogInformation("Successfully converted Excel file to CSV with semicolon delimiter");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error converting Excel file to CSV");
                throw new McpException($"Failed to convert Excel file to CSV: {ex.Message}", 500);
            }
        }
    }
}