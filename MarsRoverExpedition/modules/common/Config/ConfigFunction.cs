using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MarsRoverExpedition.modules.common.Config
{

    /// <summary>
    /// 取参数功能类
    /// </summary>
    public static class ConfigFunction
    {
        private static readonly string configFileName = "appsettings.json";
        
        public static void Init(string[] configFiles)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            foreach (var cf in configFiles)
            {
                builder.AddJsonFile(cf, true, true);
            }
            Configuration = builder.Build();
        }
        
        public static void InitByConfiguration(IConfiguration configuration = null)
        {
            if (configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(configFileName);
                configuration = builder.Build();
            }
            Configuration = configuration;
        }
        
        public static void InitByFilePath(string cofFileName = "")
        {
            var cofName = configFileName;
            if (!string.IsNullOrEmpty(cofFileName))
            {
                cofName = cofFileName;
            }
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(cofName);
            Configuration = builder.Build();
        }
        /// <summary>
        /// 参数接口
        /// </summary>
        public static IConfiguration Configuration { get; set; }
        /// <summary>
        /// 取参数
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConfig(string configName)
        {
            // var builder = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json");
            // Configuration = builder.Build();
            return Configuration[configName];

        }

        public static bool SetConfig(string configName, string configValue)
        {
            // var builder = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json");
            // Configuration = builder.Build();
            try
            {
                Configuration[configName] = configValue;
                return true;
            }
            catch(Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

    }
}