using System;
using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Logger
{
    /// <summary>
    /// Provides basic setup and experience of using log4net
    /// with class libraries.
    /// </summary>
    public class LogManager
    {
        private readonly string _className;
        private string _pattern = "%d %-5p %C %method %m%n";

        public ILog Logger => log4net.LogManager.GetLogger(_className);

        /// <summary>
        /// Initializes a new instance of the <see cref="LogManager"/> class.
        /// </summary>
        /// <param name="logFilePath">The log file path.</param>
        /// <param name="className">Name of the class for logging.</param>
        public LogManager(string logFilePath, string className)
        {
            SetupLogManager(logFilePath, _pattern);
            _className = className;
        }

        /// <summary>
        /// Setups the log manager.
        /// </summary>
        /// <param name="logFilePath">The log file path.</param>
        /// <param name="pattern">The pattern of log entries.</param>
        private void SetupLogManager(string logFilePath, string pattern)
        {
            Hierarchy hierarchy = (Hierarchy)log4net.LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout
            {
                ConversionPattern = pattern
            };
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender
            {
                AppendToFile = true,
                File = logFilePath,
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "1GB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true
            };
            roller.ActivateOptions();

            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = log4net.Core.Level.Info;
            hierarchy.Configured = true;
        }
    }
}
