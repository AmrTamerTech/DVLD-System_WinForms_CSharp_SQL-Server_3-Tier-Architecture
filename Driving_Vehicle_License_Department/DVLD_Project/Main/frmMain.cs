using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project.People;

namespace DVLD_Project.Main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmListPeople frmListPeople = new frmListPeople();
            frmListPeople.ShowDialog();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy | hh:mm:ss tt");
        }
    }
}
