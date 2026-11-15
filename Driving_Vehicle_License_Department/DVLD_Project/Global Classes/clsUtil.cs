using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Global_Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid newGUID = Guid.NewGuid();

            return newGUID.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                { 
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Creation Folder: " + ex.Message);
                    return false;
                }
            }
            return true;
        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fileInfo = new FileInfo(fileName);
            string extension = fileInfo.Extension;
            return GenerateGUID() + extension;
        }

        public static bool CopyImageToProjectImageFolder(ref string sourceFile)
        {
            string DestinationFolder = @"D:\Desktop Applications\Driving_And_Vehicle_License_Department_System\People Images\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder)) return false;

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourceFile = destinationFile;
            return true;
        }
    }
}
