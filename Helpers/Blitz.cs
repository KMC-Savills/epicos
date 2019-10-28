using EpicOS.Managers;
using EpicOS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EpicOS.Helpers
{
    public class Blitz
    {

        //public static string Salt = ConfigurationManager.AppSettings["salt"];
        public static string Salt = "kmc";

        public static string CalculateMD5Hash(string secret)
        {
            string input = Salt + secret;
            MD5 encrypter = MD5.Create();
            byte[] data = encrypter.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public string GenerateToken(string keyword)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Salt));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(keyword);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public string DecodeToken(string token)
        {
            string keyword = "";
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    using (var md5 = new MD5CryptoServiceProvider())
                    {
                        using (var tdes = new TripleDESCryptoServiceProvider())
                        {
                            tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Salt));
                            tdes.Mode = CipherMode.ECB;
                            tdes.Padding = PaddingMode.PKCS7;

                            using (var transform = tdes.CreateDecryptor())
                            {
                                byte[] cipherBytes = Convert.FromBase64String(token);
                                byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                                keyword = UTF8Encoding.UTF8.GetString(bytes);
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {

            }
            return keyword;
        }

        public Result VerifyToken(string token)
        {
            Result result = new Result();
            result.ExceptionMessage = "The token is invalid or expired.";
            result.IsSuccess = false;
            try
            {
                string key = DecodeToken(token);
                string[] keys = key.Split('*');
                string email = keys[0];
                DateTime dateStamp = Convert.ToDateTime(keys[1]);
                int day = Convert.ToInt32(DateTime.UtcNow.Subtract(dateStamp).ToString("dd"));
                int hours = Convert.ToInt32(DateTime.UtcNow.Subtract(dateStamp).ToString("hh"));
                if (day == 0)
                {
                    if (hours <= 1)
                    {
                        UserManager manager = new UserManager();
                        User user = manager.GetByEmail(email);
                        result.ID = user.ID;
                        result.IsSuccess = true;
                        result.ExceptionMessage = "The token is valid.";
                    }
                }
            }
            catch (Exception error)
            {
                result.Exception = error;
            }
            return result;
        }

    }
}
