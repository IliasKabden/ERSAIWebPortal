using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IMS
{
    public class EmployeePhotosRepository
    {
        public string EmployeePhotosMainDirectoryPath;
        public string TryGetEmployeePhotoBase64(string Badge)
        {
            var photoPath = GetEmployeePhotoPath(Badge);
            if (File.Exists(photoPath))
                return Convert.ToBase64String(File.ReadAllBytes(photoPath));
            else
                return null;
        }
        public void SaveEmployeePhotoFromBase64(string Badge, string Base64Photo)
        {
            File.WriteAllBytes(GetEmployeePhotoPath(Badge), Convert.FromBase64String(Base64Photo));
        }
        public void DeleteEmployeePhotoIfExists(string Badge)
        {
            var photoPath = Path.Combine(EmployeePhotosMainDirectoryPath, Badge);
            if (File.Exists(photoPath))
                File.Delete(photoPath);
        }
        public string GetEmployeePhotoPath(string Badge)
        {
            return Path.Combine(EmployeePhotosMainDirectoryPath, Badge + ".jpg");
        }
        public void TryChangeBadgeNumber(string OldBadgeNumber, string NewBadgeNumber)
        {
            string oldFilePath = GetEmployeePhotoPath(OldBadgeNumber),
                newFilePath = GetEmployeePhotoPath(NewBadgeNumber);
            if (File.Exists(newFilePath))
                File.Delete(newFilePath);
            if (File.Exists(oldFilePath))
                File.Move(oldFilePath, newFilePath);
        }
    }
}