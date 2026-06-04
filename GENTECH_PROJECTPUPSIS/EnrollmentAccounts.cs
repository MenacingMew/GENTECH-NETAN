using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentAccounts : UserControl
    {
        public static bool IsFreeEducation = true; // Temporary mock data
        public EnrollmentAccounts()
        {
            InitializeComponent();
        }

        private void EnrollmentAccounts_Load(object sender, EventArgs e)
        {
            if (IsFreeEducation == true) 
            {
                lbl_misc.Text= "Must been the wind...";
                lbl_totalAmount.Text = "Covered by Free Higher Education Act";
                button11.Visible = false;

                kryptonPanel2.Visible = false;
               
            }
            else
            {
                lbl_misc.Text = "Lab fees: 12.67$\nRoom fees: 67.50$\nRegistration fee: 90$";
                lbl_totalAmount.Text = "500$";


                kryptonPanel2.Visible= true;
            }
        }

        private void lbl_misc_Click(object sender, EventArgs e)
        {

        }

        private void lbl_totalAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
