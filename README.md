# Motormount
This project was developed for the subject LI4 from University of Minho - Software Engineering degree.

#### Requirements:
To run this project you might need to install some of its dependencies:
- [.NET 8.0 (or latest)](https://dotnet.microsoft.com/en-us/)
- [Microsoft Blazor Fluent UI](https://www.fluentui-blazor.net/CodeSetup)
- [Microsoft SQL Server 2022 (or latest)](https://www.microsoft.com/en-us/sql-server/sql-server-2022) (Note: if you don't have a SQL Server license you can use the [Developer Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))
- [Microsoft SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
- [Typst](https://typst.app/) (Optional: used to compile the report)

## How to install
```shell
$ git clone
$ cd ./UM-motormount/
# After downloading the SQL Server Setup run the following command (example for SQL Server 2022 Developer Edition):
$ sudo ./path/SQL2022-SSEI-Dev.exe /ConfigurationFile="ConfigurationFile.ini"
```

###### Note: If you experience troubles with the NuGet packages run these commands:
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
###### Attention: You need to have [Typst](https://typst.app/) installed to compile

### Developement Team
AXXXXXX - Name
