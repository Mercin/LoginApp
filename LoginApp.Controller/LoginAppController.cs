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

    }
}
