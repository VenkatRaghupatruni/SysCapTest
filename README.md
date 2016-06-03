# SysCapTest
Sys Cap Test - Version 1

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

1. The functionality in the controller class is shifted to a new service class 'FileSystemService'  
in 'Services' Folder.

2. Abstraction of the 'FileSystemService' class is available in the  'IFileSystemService' in the same folder.

3. The file System service also implements IDisposable interface to correctly dispose off 
all managed and unmanaged resources.

4. The code in the 'FileSystemService' is re-factored to follow SOLID principles and DRY.

5. Dependency Injection is introduced using Unity Container. (new class 'DependencyConfig' class 
added in 'App_Start' folder and new class 'NyUnityDependencyResolver' in Infrastructure folder and 
'Global.asax' file modified.)

6. Unnecessary classes like 'FileReader' and 'FileWriter' are removed from Models folder.

7. There is no need for 'NewContactViewModel' and hence removed. The additional functionality in 
'NewContactViewModel' class is added to 'ContactViewModel' itself and also the file is renamed to 
the same name.

8. References to all unused name-spaces removed from all files.

9. Comments have been added just where necessary.

Enhancements for the future:

1. The 'FileSystemReader' still seems to be doing too many things. This class can be further split into 
'FileUploader' class, 'FileHandler' class ( for Read and Write operations), 'EMailSender' class
for maintaining single responsibility principle. 

2. Validations can be added for all the fields.

3. Unit tests can be added.
