# BackupManager
C# Forms application to create and update backups.

The target framework is .NET 8.0.

Designed to run on Windows only due to Windows file naming conventions.

## Features
The application allows the user to create and update backups of files and directories. The user can select the destination directory and multiple cource files and folders,
and the application will copy any new or changed files from the source to the destination.

The destination directories use a naming scheme that includes the name of the source drive or network path as follows:
Files or folders from drive C will be in a subfolder named "Drive_C", files or folders from a network path `\\server\share` will be in a subfolder named "NetworkDrive_server\share".

Examples given that the specified backup folder is "D:\Backups":
- Source: `C:\Users\JohnDoe\Documents\`
  Destination: `D:\Backups\Drive_C\Users\JohnDoe\Documents\`
- Source: `\\server\share\`
  Destination: `D:\Backups\NetworkDrive_server\share\`
