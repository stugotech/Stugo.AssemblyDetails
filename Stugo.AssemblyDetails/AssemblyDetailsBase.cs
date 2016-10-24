using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Stugo
{
    public class AssemblyDetailsBase
    {
        static AssemblyDetailsBase()
        {
            // entry assembly is null during testing
            var entryAssembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            var assemblyVersionInfo = FileVersionInfo.GetVersionInfo(entryAssembly.Location);

            ProgramDataDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                assemblyVersionInfo.CompanyName,
                assemblyVersionInfo.ProductName
            );

            if (!Directory.Exists(ProgramDataDirectory))
                Directory.CreateDirectory(ProgramDataDirectory);

            ProgramFilesDirectory = Path.GetDirectoryName(entryAssembly.Location);

            // set version
            var versionAttrib = (AssemblyInformationalVersionAttribute)entryAssembly
                .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), true)
                .FirstOrDefault();

            if (versionAttrib != null)
                CurrentVersion = versionAttrib.InformationalVersion;
        }


        public static string ProgramDataDirectory { get; private set; }
        public static string ProgramFilesDirectory { get; private set; }
        public static string CurrentVersion { get; private set; }
    }
}