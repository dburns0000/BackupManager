using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackupApp
{
    internal class BackupRunner(MainForm mainForm)
    {
        private readonly MainForm _mainForm = mainForm;

        async public Task RunBackup(List<string> foldersAndFiles, string backupPath)
        {
            await Task.Run(() => CopyFoldersAndFiles(foldersAndFiles, backupPath));
            _mainForm.UpdateCurrentItem("Backup completed!");
        }

        private void CopyFoldersAndFiles(List<string> foldersAndFiles, string backupPath)
        {
            foreach (string item in foldersAndFiles)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }

                // Check if the item is a file or a folder
                if (File.Exists(item))
                {
                    // Replace the drive letter with "Drive_N" in the backup path
                    string? driveLetter = Path.GetPathRoot(item);
                    if (driveLetter == null || driveLetter.Length < 3)
                    {
                        continue;
                    }

                    string driveName = driveLetter.StartsWith("\\\\")
                        ? $"NetworkDrive_{driveLetter.TrimStart('\\')}"
                        : $"Drive_{driveLetter.TrimEnd('\\').TrimEnd(':')}\\";

                    string backupPathWithDriveName = string.Concat(backupPath, "\\", driveName, item.AsSpan(driveLetter.Length));
                    string? backupFolder = Path.GetDirectoryName(backupPathWithDriveName);
                    if (backupFolder == null)
                    {
                        continue;
                    }
                    if (!Directory.Exists(backupFolder))
                    {
                        Directory.CreateDirectory(backupFolder);
                    }
                    CopyFile(item, backupPathWithDriveName);
                }
                else if (Directory.Exists(item))
                {
                    // Replace the drive letter with "Drive_N" in the backup path
                    string? driveLetter = Path.GetPathRoot(item);
                    if (driveLetter == null || driveLetter.Length < 3)
                    {
                        continue;
                    }

                    string driveName = driveLetter.StartsWith("\\\\")
                        ? $"NetworkDrive_{driveLetter.TrimStart('\\')}"
                        : $"Drive_{driveLetter.TrimEnd('\\').TrimEnd(':')}\\";

                    string backupPathWithDriveName = string.Concat(backupPath, "\\", driveName, item.AsSpan(driveLetter.Length));

                    _mainForm.UpdateCurrentItem(item);
                    CopyFolder(item, backupPathWithDriveName);
                }
            }
        }

        private void CopyFile(string filename, string backupFilename)
        {
            if (File.Exists(backupFilename))
            {
                // If the file's date modified is newer than the backup file's date modified or the file's size is different copy the file
                FileInfo file = new(filename);
                FileInfo backupFile = new(backupFilename);
                if (file.LastWriteTime > backupFile.LastWriteTime || file.Length != backupFile.Length)
                {
                    _mainForm.UpdateCurrentItem(filename);
                    try
                    {
                        File.Delete(backupFilename);
                    }
                    catch (Exception e)
                    {
                        _mainForm.AddError($"Error deleting backup file: {e.Message}");
                    }
                    try
                    {
                        File.Copy(filename, backupFilename, true);
                    }
                    catch (Exception e)
                    {
                        _mainForm.AddError($"Error copying file: {e.Message}");
                    }
                }
            }
            else
            {
                _mainForm.UpdateCurrentItem(filename);
                try
                {
                    File.Copy(filename, backupFilename, true);
                }
                catch (Exception e)
                {
                    _mainForm.AddError($"Error copying file: {e.Message}");
                }
            }
        }

        // Thanks to Gemini AI for the code to make it non-recursive
        private void CopyFolder(string sourceFolder, string destinationFolder)
        {
            void CopyFiles(string source, string dest)
            {
                foreach (string file in Directory.GetFiles(source))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(dest, fileName);
                    CopyFile(file, destFile); // Assuming CopyFile is defined elsewhere
                }
            }

            Stack<(string, string)> foldersToCopy = new();
            foldersToCopy.Push((sourceFolder, destinationFolder));

            while (foldersToCopy.Count > 0)
            {
                (string currentSource, string currentDest) = foldersToCopy.Pop();

                // Create the destination folder if it does not exist
                if (!Directory.Exists(currentDest))
                {
                    Directory.CreateDirectory(currentDest);
                }

                CopyFiles(currentSource, currentDest);

                foreach (string subfolder in Directory.GetDirectories(currentSource))
                {
                    string folderName = Path.GetFileName(subfolder);
                    string destFolder = Path.Combine(currentDest, folderName);
                    foldersToCopy.Push((subfolder, destFolder)); // Add subfolder to the stack
                }
            }
        }

    }
}
