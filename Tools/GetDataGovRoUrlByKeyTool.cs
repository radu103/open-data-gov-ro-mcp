using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace OpenDataGovRo.Tools
{
    [McpServerToolType]
    public static class GetDataGovRoUrlByKeyTool
    {
        // Create a static logger for this class
        private static readonly ILogger logger = LoggerFactory.Create(builder =>
            builder.AddConsole().SetMinimumLevel(LogLevel.Debug))
            .CreateLogger(nameof(GetDataGovRoUrlByKeyTool));

        static GetDataGovRoUrlByKeyTool()
        {
            logger.LogInformation("GetDataGovRoUrlByKeyTool static constructor called");
        }

        [McpServerTool, Description("Get data.gov.ro URL by key from the predefined list")]
        public static string GetDataGovRoUrlByKey(
            [Description("Key of the dataset in the predefined list")] string key
        )
        {
            logger.LogInformation("GetDataGovRoUrlByKey called with key: {key}", key);

            if (string.IsNullOrEmpty(key))
            {
                logger.LogError("Dataset key cannot be empty");
                throw new McpException("Dataset key cannot be empty", 400);
            }

            try
            {
                var urlItem = DataGovRoUrls.Items.FirstOrDefault(item => item.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
                
                if (urlItem.Equals(default(KeyValuePair<string, string>)))
                {
                    var availableKeys = string.Join(", ", DataGovRoUrls.Items.Select(item => item.Key));
                    logger.LogError("Dataset key '{key}' not found. Available keys: {availableKeys}", key, availableKeys);
                    throw new McpException($"Dataset key '{key}' not found. Available keys: {availableKeys}", 404);
                }

                logger.LogInformation("URL for key '{key}' found: {url}", key, urlItem.Value);
                return urlItem.Value;
            }
            catch (Exception ex) when (!(ex is McpException))
            {
                logger.LogError(ex, "Error retrieving URL for key: {key}", key);
                throw new McpException($"Failed to retrieve URL: {ex.Message}", 500);
            }
        }

        [McpServerTool, Description("List all available data.gov.ro dataset keys")]
        public static List<string> ListDataGovRoDatasetKeys()
        {
            logger.LogInformation("ListDataGovRoDatasetKeys called");

            try
            {
                var keys = DataGovRoUrls.Items.Select(item => item.Key).ToList();
                logger.LogInformation("Available dataset keys: {keys}", string.Join(", ", keys));
                return keys;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error listing dataset keys");
                throw new McpException($"Failed to list dataset keys: {ex.Message}", 500);
            }
        }
    }
}