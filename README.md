# Motormount
This project was developed for the subject LI4 from University of Minho - Software Engineering degree.

#### Requirements:
To run this project you might need to install some of its dependencies:
- [.NET 8.0 (or latest)](https://dotnet.microsoft.com/en-us/)
- [Microsoft Blazor Fluent UI](https://www.fluentui-blazor.net/CodeSetup)

###### Note: If you experience troubles with the Blazor Fluent UI NuGet package run these commands:
```shell
cd ./MotorMount/
$ dotnet add package Microsoft.FluentUI.AspNetCore.Components
$ dotnet add package Microsoft.FluentUI.AspNetCore.Components.Icons
$ dotnet add package Microsoft.FluentUI.AspNetCore.Components.Emoji
```

## How to build
```shell
$ make build
```

## How to run
```shell
$ make
```
or:
```shell
$ make dev
```

## Report
The pre-compiled version of the report can be found in the Relatório folder. If you want to compile it yourself, you can do so by running:
```shell
$ make relatorio
```
(Attention: You need to have [Typst](https://typst.app/) installed to compile)

### Developement Team
AXXXXXX - Name
