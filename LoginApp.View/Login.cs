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
using LoginApp.View;

namespace LoginApp
{
    public partial class Login : Form, IView
    {
        IController controller = null;

        public Login(IController _controller)
        {
            InitializeComponent();
            setController(_controller);
            dataGridView.DataSource = controller.getDataTable();
            dataGridView.Columns[0].Width = 200;
            dataGridView.Columns[3].Visible = false;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            


        }

        public void setController(IController _controller)
        {
            controller = _controller;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Form passwordForm = new PasswordInput(controller, dataGridView.SelectedRows[0].Cells[3].Value.ToString().Trim());
            passwordForm.ShowDialog();
        }
    }
}
