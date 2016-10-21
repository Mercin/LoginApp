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
using System.Reflection;

namespace LoginApp.Model
{
    public class UserRepository : IUserRepository
    {
        List<User> userList = new List<User>();

        public UserRepository()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\Zadatak_1.json");
            UserList _users = JsonConvert.DeserializeObject<UserList>(File.ReadAllText(path));
            userList = _users.Users;
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
            dt.Columns.Add("Id");
            foreach (var item in userList)
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(item.avatarUrl);
                myRequest.Method = "GET";
                Bitmap bmp = null;
                Bitmap resized = null;
                try
                {
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    bmp = new Bitmap(myResponse.GetResponseStream());
                    resized = new Bitmap(bmp, new Size(200, 200));
                    myResponse.Close();
                }
                catch(Exception e)
                {
                    string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Anon.png";
                    bmp = new Bitmap(filePath);
                    resized = new Bitmap(bmp, new Size(200, 200));
                }

                
                dt.Rows.Add(resized, item.name, item.role, item.id);
            }

            return dt;
        }

        public string getHashByID(int id)
        {
            foreach(var item in userList)
            {
                if (id == Int16.Parse(item.id))
                {
                    return item.passHash;
                }
            }

            return "";
        }
    }
}
