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

            ProgramDataDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                assemblyVersionInfo.CompanyName,
                assemblyVersionInfo.ProductName
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


        public string ProgramDataDirectory { get; }
        public string ProgramFilesDirectory { get; private set; }
        public string CurrentVersion { get; private set; }
    }
}
