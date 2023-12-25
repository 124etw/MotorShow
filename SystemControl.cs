using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motorshow2
{
    public partial class SystemControl : Form
    {
        EditForms editForms = new EditForms();
        public SystemControl()
        {
            InitializeComponent();
            editForms.ApplyCommonFormProperties(this);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Peremen peremen = new Peremen();
            string login = textBox1.Text;
            string password = textBox2.Text;
            peremen.Proverka(login, password);
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
