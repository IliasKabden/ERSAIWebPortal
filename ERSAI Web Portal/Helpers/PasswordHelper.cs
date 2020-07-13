using DataModels.ERSAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace ERSAI_Web_Portal.Helpers
{
    public static class PasswordHelper
    {
        public static bool CheckPassword(this PersonalAccountUser user, string password)
        {
            return CreateMD5(user.Hint1 + password + user.Hint2) == user.PasswordHash;
        }
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// Set new password for user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newPassword">If null, random password will be generated and returned</param>
        /// <returns></returns>
        public static string SetNewPassword(this PersonalAccountUser user, string newPassword = null)
        {
            user.Hint1 = Membership.GeneratePassword(8, 3);
            user.Hint2 = Membership.GeneratePassword(8, 3);
            if (newPassword == null)
            {
                newPassword = Membership.GeneratePassword(6, 0);
                var rand = new Random();
                newPassword = Regex.Replace(newPassword, @"[^a-zA-Z0-9]", m =>
                {
                    return rand.Next(10).ToString();
                });
            }
            user.PasswordHash = CreateMD5(user.Hint1 + newPassword + user.Hint2);
            return newPassword;
        }
    }
}