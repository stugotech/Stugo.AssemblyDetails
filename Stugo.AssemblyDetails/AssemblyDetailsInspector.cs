using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Stugo
{
    public class AssemblyDetailsInspector
    {
        public AssemblyDetailsInspector(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            // ReSharper disable once AssignNullToNotNullAttribute
            // null check above
            var assemblyVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            CompanyName = assemblyVersionInfo.CompanyName;
            ProductName = assemblyVersionInfo.ProductName;
            RegistryRoot = $"{CompanyName}\\{ProductName}";

            ProgramDataDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                CompanyName,
                ProductName
            );

            if (!Directory.Exists(ProgramDataDirectory))
                Directory.CreateDirectory(ProgramDataDirectory);

            ProgramFilesDirectory = Path.GetDirectoryName(assembly.Location);

            // set version
            var versionAttrib = (AssemblyInformationalVersionAttribute)assembly
                .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), true)
                .FirstOrDefault();

            if (versionAttrib != null)
                CurrentVersion = versionAttrib.InformationalVersion;
        }


        public string CompanyName { get; }
        public string ProductName { get; }
        public string RegistryRoot { get; }
        public string ProgramDataDirectory { get; }
        public string ProgramFilesDirectory { get; }
        public string CurrentVersion { get; }
    }
}
