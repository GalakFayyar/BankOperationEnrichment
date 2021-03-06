Bank Operation Enrichment
===================

> **Versions:**
> - v0.1 : initial project
> - v1.0 : First Release
> - v1.1 : Buildin dll
> - v1.2 : x86 compatibility with Interop
> - v1.3 : New Settings UI
> - v1.4 & v1.5 : Bug fixes
> - v1.6 : New label match (CP25 & CP251 CP252)

![](capture.PNG?raw=true)

Project Objective
-------------
This short project aims to enrich excel document containing bank operation extractions with account details such as code operation and account code.

How does it works ?
-------------
Based on a reference matrix file, the objective is to guess the code operation by analyzing the label of the operation. 
Then a comparison is performed to match the correct code and label for the operation.

The Programmation
-------------
This project is written in C# with .NET 4 Framework. It also use ACE OLEDB database driver to communicate with Microsoft Excel files as databases. It also includes the [bsargos project EmbeddedExcel](http://www.codeproject.com/Articles/15760/How-to-Integrate-Excel-in-a-Windows-Form-Applicati) to preview Microsoft Excel files and set up fields to operate. 

Installation
-------------
Thanks to [Fody Costura nuget Package] (https://github.com/Fody/Costura) all dependencies (DLL files) are included in executable generated. No installation required. Of course, Microsoft Excel (Excel.Interop) is required to be able to preview file...

Execution
-------------
Simply execute file executable. For best use, it is recommanded to launch as Administrator.

Requirements
-------------
- Package Tool : Microsoft Office Database Connectivity Component (https://www.microsoft.com/fr-fr/download/confirmation.aspx?id=23734)
- .NET Framework 4.0
- Microsoft Excel (for preview only, not required for enrichment operation)
- Windows Environment (of course...)

Additional Informations
-------------
Open Excel File in Navigator : https://support.microsoft.com/en-us/kb/982995 (edit: change HKEY_LOCAL_MACHINE with HKEY_CURRENT_USER)

Integrate Excel File in C# Form Application : http://www.codeproject.com/Articles/15760/How-to-Integrate-Excel-in-a-Windows-Form-Applicati

Integrate dll interop Excel dll in exe :
http://www.claudiobernasconi.ch/2014/02/13/painless-office-interop-using-visual-c-sharp/
