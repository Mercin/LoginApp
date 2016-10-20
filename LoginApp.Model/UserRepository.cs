using LoginApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LoginApp.Model
{
    public class UserRepository : IUserRepository
    {
        List<User> userList = new List<User>();

        public UserRepository()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Resources\Zadatak_1.json");
            UserList _users = JsonConvert.DeserializeObject<UserList>(File.ReadAllText(path));
            userList = _users.Users;
        }
        public void getJSONData()
        {

        }

        public List<User> getUserList()
        {
            return userList;
        }

        public DataTable getDataTableFromJSON()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Avatar", typeof(System.Drawing.Bitmap)));
            dt.Columns.Add("Name");
            dt.Columns.Add("Role");
            foreach (var item in userList)
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(item.avatarUrl);
                myRequest.Method = "GET";
                Bitmap bmp = null;
                try
                {
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    bmp = new Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();
                }
                catch(Exception e)
                {

                }

                
                dt.Rows.Add(bmp, item.name, item.role);
            }

            return dt;
        }
    }
}
