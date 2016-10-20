using LoginApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Model
{
    public class UserRepository : IUserRepository
    {
        UserList _users = new UserList();
        public void getJSONData()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Resources\Zadatak_1.json");
            var kajgod = File.ReadAllText(path);
            _users = JsonConvert.DeserializeObject<UserList>(kajgod);
        }
    }
}
