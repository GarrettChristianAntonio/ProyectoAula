using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Login : Form
    {
        ILogic _logic;
        public Login(ILogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nivelLogeo = _logic.Login(textBox1.Text, textBox2.Text);
            if(nivelLogeo > 0)
            {
                new Home(nivelLogeo,_logic).Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto.");
            }


        }
    }
}
