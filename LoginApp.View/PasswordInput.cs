using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp.Controller;

namespace LoginApp.View
{
    public partial class PasswordInput : Form, IView
    {
        IController controller = null;
        int id;
        string hash;

        public PasswordInput(IController cont, string _id)
        {
            setController(cont);
            id = Int32.Parse(_id);
            InitializeComponent();
        }

        public void setController(IController _controller)
        {
            controller = _controller;
        }

        private void button_Click(object sender, EventArgs e)
        {
            bool valid = controller.validatePassword(id, textBox.Text.ToString());

            if (valid)
            {
                MessageBox.Show("Valid", "The password is correct", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Invalid", "The password is incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
