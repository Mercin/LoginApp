﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Controller
{
    public interface IController
    {
        void getJSONData();
        bool validatePassword(string _password);
    }
}