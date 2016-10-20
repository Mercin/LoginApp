using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Model;

namespace LoginApp.Controller
{
    public class LoginAppController : IController
    {
        private IUserRepository repo;
        public LoginAppController()
        {
            repo = new UserRepository();
        }
        public void getJSONData()
        {
            
            repo.getJSONData();
        }

        public bool validatePassword(string _password)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(_password);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            sb.Append(BitConverter.ToString(hash).Replace("-", string.Empty));

            Console.Out.WriteLine(sb.ToString());
            return false;
        }
    }
}
