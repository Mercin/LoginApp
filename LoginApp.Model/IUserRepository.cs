using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Model
{
    public interface IUserRepository
    {
        void getJSONData();
        List<User> getUserList();
        DataTable getDataTableFromJSON();

    }
}
