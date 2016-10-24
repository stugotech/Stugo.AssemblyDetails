# Stugo.AssemblyDetails

Provides information about an assembly.

## AssemblyDetailsInspector

Gets information about an assembly passed in the constructor:

```csharp
var inspector = new AssemblyDetailsInspector(assembly);
```

This class contains 3 properties:

| Name | Descriptions |
|----|----|
| ProgramDataDirectory | The sub directory of the `ProgramData` folder for the assembly (based on company name and product name) |
| ProgramFilesDirectory | The location of the given assembly |
| CurrentVersion | The version given by the `AssemblyInformationalVersion` attribute |