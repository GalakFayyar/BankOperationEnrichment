Bank Operation Enrichment
===================

> **Versions:**
> v0.1 : initial project

Project Objective
-------------
This short project aims to enrich excel document containing bank operation extractions with account details such as code operation and account code.

How does it works ?
-------------
The objective is to guess the code operation by analyzing the label of the operation. 
Then a comparison is performed to match the correct code and label for the operation.

The Programmation
-------------
This project is written in Visual Basic. The main purpose is a VBA excel macro.

Installation
-------------
Open Microsoft Excel, and then press <kbd>ALT + F11</kbd> to access Visual Basic Editor.
Go to File > Import file and select the macro released in this project (file.bas).

Execution
-------------
Simply run the macro by accessing the Display Tab and click on the Macros button. Then, simply select the Macro 'PerformOperation'.

Requirements
-------------
In order to run correctly, this macro needs the reference file containing the list of code and label for the common accounts.

Additional Informations
-------------
Open Excel File in Navigator : https://support.microsoft.com/en-us/kb/982995 (edit: change HKEY_LOCAL_MACHINE with HKEY_CURRENT_USER)

Integrate Excel File in C# Form Application : http://www.codeproject.com/Articles/15760/How-to-Integrate-Excel-in-a-Windows-Form-Applicati
