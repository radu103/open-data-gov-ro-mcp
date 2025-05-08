using System;

namespace OpenDataGovRo.Tools
{
    public static class EnvironmentUtils
    {
        private const string LOCAL_VOLUME_PATH_KEY = "LOCAL_VOLUME_PATH";
        
        /// <summary>
        /// Gets the local volume path from environment variable
        /// </summary>
        /// <returns>The configured local volume path or default path if not set</returns>
        public static string GetLocalVolumePath()
        {
            return Environment.GetEnvironmentVariable(LOCAL_VOLUME_PATH_KEY);
        }
    }
}