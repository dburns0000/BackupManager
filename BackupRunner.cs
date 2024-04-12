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
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

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

                    string driveName;
                    if (driveLetter.StartsWith("\\\\"))
                    {
                        driveName = $"NetworkDrive_{driveLetter.TrimStart('\\')}";
                    }
                    else
                    {
                        driveName = $"Drive_{driveLetter.TrimEnd('\\').TrimEnd(':')}\\";
                    }
                    
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

                    string driveName;
                    if (driveLetter.StartsWith("\\\\"))
                    {
                        driveName = $"NetworkDrive_{driveLetter.TrimStart('\\')}";
                    }
                    else
                    {
                        driveName = $"Drive_{driveLetter.TrimEnd('\\').TrimEnd(':')}\\";
                    }

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

        private void CopyFolder(string sourceFolder, string destinationFolder)
        {
            // Create the destination folder if it does not exist
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            // Copy all files in the source folder to the destination folder
            foreach (string file in Directory.GetFiles(sourceFolder))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationFolder, fileName);
                CopyFile(file, destFile);
            }

            // Copy all subfolders in the source folder to the destination folder
            foreach (string subfolder in Directory.GetDirectories(sourceFolder))
            {
                string folderName = Path.GetFileName(subfolder);
                string destFolder = Path.Combine(destinationFolder, folderName);
                CopyFolder(subfolder, destFolder);
            }
        }

    }
}
