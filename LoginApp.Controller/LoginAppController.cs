using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Model;
using System.Data;

namespace LoginApp.Controller
{
    public class LoginAppController : IController
    {
        private IUserRepository repo;
        public LoginAppController()
        {
            repo = new UserRepository();
        }

        public DataTable getDataTable()
        {
            return repo.getDataTableFromJSON();
        }

        public bool validatePassword(int id, string pass)
        {
            string hash =  repo.getHashByID(id);

            IValidator pv = new PasswordValidator();
            string inputPassHash = pv.getHash(pass);
            return pv.validatePassword(hash, inputPassHash);

        }


    }
}
