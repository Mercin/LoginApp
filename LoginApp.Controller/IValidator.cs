using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Controller
{
    public interface IValidator
    {
        string getHash(string _password);
        bool validatePassword(string _password, string _hash);

    }
}
