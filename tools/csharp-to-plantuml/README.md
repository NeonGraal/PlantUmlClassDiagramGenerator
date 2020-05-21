# csharp-to-plantuml README

Create class diagrams of PlantUML from C# source code.

## Requirements

- .Net Core SDK 2.1 or newer.

## Extension Settings

- __csharp2plantuml.inputPath__  
  Specify a input folder (relative to workspace folder)
- __csharp2plantuml.outputPath__  
  Specify a output folder (relative to workspace folder
- __csharp2plantuml.public__  
  Only public accessibility members are output.
- __csharp2plantuml.ignoreAccessibility__  
  Specify accessibiliies of members to ignore, with a comma separated list. (ex. 'private,protected,protected internal')
- __csharp2plantuml.excludePath__  
  Specify exclude file or directory paths (relative to the \"InputPath\"), with a comma separated list. (ex. 'obj,Properties\\AssemblyInfo.cs')
- __csharp2plantuml.fields__
  Create object associations from references of fields and properties.
- __csharp2plantuml.constructor__
  Create object associations from references of constructor parameters.


## Known Issues


## Release Notes
### 1.1.0
Add Feature that create object associations from references of constructor parameters. 

### 1.0.0
Add Feature that create object associations from references of fields and properties. 

### 0.0.1 preview
Beta release.
