using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.common
{
    static class Common
    {
        public static string encryptPassword(string password)
        {
            byte[] encData_byte = new byte[password.Length];
            encData_byte = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(encData_byte);
            /*return password;*/
        }
    }
}
