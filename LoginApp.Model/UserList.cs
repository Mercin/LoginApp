using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Model
{
    public class UserList
    {
        [JsonProperty("loginModel")]
        public List<User> _users { get; set; }

    }
}
