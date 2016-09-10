using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransitSMS
{
    public partial class ConectionForm : Form
    {
        public ConectionForm()
        {
            InitializeComponent();
        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {
            Int16 Comm_Port = Convert.ToInt16(COMPortBox.Text);
            Int32 Comm_BaudRate = Convert.ToInt32(BaudRateBox.Text);
            Int32 Comm_TimeOut = Convert.ToInt32(TimeoutBox.Text);

            MainForm mf = new MainForm(Comm_Port, Comm_BaudRate, Comm_TimeOut);
            this.Hide();
            mf.Show();

        }
    }
}
