
CSVReaderWriter - Written by Junior Developer

Sample file (ContactAddress.csv) has been provided and is attached to the solution.

Click Choose File and select .csv file.

Press Submit to upload the file and display its contents on screen.

At the bottom on the page there is a link to allow appending of data to the file.

Once data has been appended the file will reload and display its updated contents.

There is also a link that allows emails to be sent to all the contacts.

Tasks
Refactor the code using SOLID Principles and Design Patterns

Note: Sample File is random data
---------------------------------------------

I have made the following changes to the code:

1. The functionality in the controller class is shifted to a new service classes  called 'FileSystemService',
'FileUploader' and 'FileProcessor'  in 'Services' Folder.

2. Abstractions of the services classes are available in the 'Interfaces' folder.  
'IFileSystemService', 'IFileUploader' and 'IFileProcessor'.

3. The file System service also implements IDisposable interface to correctly dispose off 
all managed and unmanaged resources.

4. The code in the 'FileSystemService' is re-factored to follow SOLID principles and DRY.

5. Dependency Injection is introduced using Unity Container. (new class 'DependencyConfig' class 
added in 'App_Start' folder and new class 'NyUnityDependencyResolver' in Infrastructure folder and 
'Global.asax' file modified.)

6. Unnecessary view model classes like 'FileReader' and 'FileWriter' are removed from Models folder.

7. There is no big difference between 'NewContactViewModel' and 'ContactViewModel'. The additional functionality in 
'NewContactViewModel' class is added to 'ContactViewModel' itself and also the file is renamed to 
the same name. There is no need for 'NewContactViewModel' and hence removed.

8. References to all unused name-spaces removed from all files.

9. Comments have been added just where necessary.

Enhancements for the future:

1. Validations can be added for all the fields.

2. Unit tests can be added.
