﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Controller
{
    public interface IController
    {

        DataTable getDataTable();
        bool validatePassword(int id, string pass);

    }
}
