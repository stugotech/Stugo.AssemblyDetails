using System.Reflection;

[assembly: AssemblyDescription("Provides information about an assembly")]
[assembly: AssemblyCompany("Stugo Ltd")]
[assembly: AssemblyProduct("Stugo.AssemblyDetails")]
[assembly: AssemblyCopyright("Copyright © Stugo Ltd 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
