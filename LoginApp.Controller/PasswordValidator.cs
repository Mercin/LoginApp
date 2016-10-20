using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Controller
{
    public class PasswordValidator
    {
        public string getHash(string _password)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(_password);
            byte[] hash = md5.ComputeHash(inputBytes);

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
        public bool validatePassword(string _password, string _hash)
        {
            if (_password.Equals(_hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
