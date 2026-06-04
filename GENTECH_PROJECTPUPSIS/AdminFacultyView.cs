using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class AdminFacultyView : Form
    {
        public string facultyID;
        public string type1;
        public AdminFacultyView(string id, string type)
        {
            InitializeComponent();
            facultyID = id;
            type1 = type;
        }

        private void AdminFacultyView_Load(object sender, EventArgs e)
        {
            
            LoadFacultyData(facultyID);
        }
        private void LoadFacultyData(string facultyID)
        {
            if(type1 == "View")
            {
                txtFirstView.ReadOnly = true;
                txtMiddleView.ReadOnly = true;
                txtSuffix.ReadOnly = true;
                txtLastView.ReadOnly = true;
                txtContactNo.ReadOnly = true;
                txtEmailView.ReadOnly = true;
                txtDOB.ReadOnly = true;
                txtSexView.ReadOnly = true;
                txtAddress.ReadOnly = true;
            }
            else {
                txtFirstView.ReadOnly = false;
                txtMiddleView.ReadOnly = false;
                txtSuffix.ReadOnly = false;
                txtLastView.ReadOnly = false;
                txtContactNo.ReadOnly = false;
                txtEmailView.ReadOnly = false;
                txtDOB.ReadOnly = false;
                txtSexView.ReadOnly = false;
                txtAddress.ReadOnly = false;
            }
            // This is where you would normally load data from a database or other data source.
            // For demonstration purposes, we'll just use hardcoded data based on the faculty ID.
            if (facultyID == "FAC-001")
            {
                txtFirstView.Text = "Brylle";
                txtMiddleView.Text = "A.";
                txtLastView.Text = "Smith";
                txtSuffix.Text = "";
                txtAddress.Text = "123 Main St";
                txtContactNo.Text = "555-1234";
                txtEmailView.Text = "brylle.smith@example.com";
                txtDOB.Text = "01/01/1980";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "FAC-002")
            {
                txtFirstView.Text = "Angela";
                txtMiddleView.Text = "B.";
                txtLastView.Text = "Johnson";
                txtSuffix.Text = "";
                txtAddress.Text = "456 Oak Avenue";
                txtContactNo.Text = "555-2345";
                txtEmailView.Text = "angela.johnson@example.com";
                txtDOB.Text = "02/14/1985";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "FAC-003")
            {
                txtFirstView.Text = "Michael";
                txtMiddleView.Text = "C.";
                txtLastView.Text = "Williams";
                txtSuffix.Text = "";
                txtAddress.Text = "789 Pine Street";
                txtContactNo.Text = "555-3456";
                txtEmailView.Text = "michael.williams@example.com";
                txtDOB.Text = "03/20/1978";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "FAC-004")
            {
                txtFirstView.Text = "Sophia";
                txtMiddleView.Text = "D.";
                txtLastView.Text = "Brown";
                txtSuffix.Text = "";
                txtAddress.Text = "321 Maple Road";
                txtContactNo.Text = "555-4567";
                txtEmailView.Text = "sophia.brown@example.com";
                txtDOB.Text = "04/10/1990";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "FAC-005")
            {
                txtFirstView.Text = "Daniel";
                txtMiddleView.Text = "E.";
                txtLastView.Text = "Davis";
                txtSuffix.Text = "";
                txtAddress.Text = "654 Cedar Lane";
                txtContactNo.Text = "555-5678";
                txtEmailView.Text = "daniel.davis@example.com";
                txtDOB.Text = "05/05/1982";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "FAC-006")
            {
                txtFirstView.Text = "Isabella";
                txtMiddleView.Text = "F.";
                txtLastView.Text = "Garcia";
                txtSuffix.Text = "";
                txtAddress.Text = "987 Birch Blvd";
                txtContactNo.Text = "555-6789";
                txtEmailView.Text = "isabella.garcia@example.com";
                txtDOB.Text = "06/18/1988";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "FAC-007")
            {
                txtFirstView.Text = "Joshua";
                txtMiddleView.Text = "G.";
                txtLastView.Text = "Martinez";
                txtSuffix.Text = "";
                txtAddress.Text = "159 Walnut Drive";
                txtContactNo.Text = "555-7890";
                txtEmailView.Text = "joshua.martinez@example.com";
                txtDOB.Text = "07/25/1981";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "FAC-008")
            {
                txtFirstView.Text = "Camille";
                txtMiddleView.Text = "H.";
                txtLastView.Text = "Anderson";
                txtSuffix.Text = "";
                txtAddress.Text = "753 Cherry Street";
                txtContactNo.Text = "555-8901";
                txtEmailView.Text = "camille.anderson@example.com";
                txtDOB.Text = "08/12/1992";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "FAC-009")
            {
                txtFirstView.Text = "Ethan";
                txtMiddleView.Text = "I.";
                txtLastView.Text = "Thomas";
                txtSuffix.Text = "";
                txtAddress.Text = "852 Aspen Court";
                txtContactNo.Text = "555-9012";
                txtEmailView.Text = "ethan.thomas@example.com";
                txtDOB.Text = "09/30/1987";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "FAC-010")
            {
                txtFirstView.Text = "Nicole";
                txtMiddleView.Text = "J.";
                txtLastView.Text = "Taylor";
                txtSuffix.Text = "";
                txtAddress.Text = "951 Willow Way";
                txtContactNo.Text = "555-0123";
                txtEmailView.Text = "nicole.taylor@example.com";
                txtDOB.Text = "10/22/1991";
                txtSexView.Text = "Female";
            }
            else if (facultyID == "2024-00138-SM-0")
            {
                txtFirstView.Text = "Juan Miguel";
                txtMiddleView.Text = "D.";
                txtLastView.Text = "Dela Cruz";
                txtSuffix.Text = "";
                txtAddress.Text = "12 Mabini St";
                txtContactNo.Text = "555-1001";
                txtEmailView.Text = "juan.delacruz@example.com";
                txtDOB.Text = "01/15/1995";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "2024-00139-SM-0")
            {
                txtFirstView.Text = "Andrea Louise";
                txtMiddleView.Text = "M.";
                txtLastView.Text = "Ramirez";
                txtSuffix.Text = "";
                txtAddress.Text = "45 Quezon Ave";
                txtContactNo.Text = "555-1002";
                txtEmailView.Text = "andrea.ramirez@example.com";
                txtDOB.Text = "03/22/1994";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "2024-00140-SM-0")
            {
                txtFirstView.Text = "Christian Paul";
                txtMiddleView.Text = "S.";
                txtLastView.Text = "Navarro";
                txtSuffix.Text = "";
                txtAddress.Text = "88 Sampaguita Rd";
                txtContactNo.Text = "555-1003";
                txtEmailView.Text = "christian.navarro@example.com";
                txtDOB.Text = "07/10/1993";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "2024-00141-SM-0")
            {
                txtFirstView.Text = "Nicole Anne";
                txtMiddleView.Text = "R.";
                txtLastView.Text = "Garcia";
                txtSuffix.Text = "";
                txtAddress.Text = "23 Rizal St";
                txtContactNo.Text = "555-1004";
                txtEmailView.Text = "nicole.garcia@example.com";
                txtDOB.Text = "11/05/1992";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "2024-00142-SM-0")
            {
                txtFirstView.Text = "Mark Anthony";
                txtMiddleView.Text = "L.";
                txtLastView.Text = "Reyes";
                txtSuffix.Text = "";
                txtAddress.Text = "77 Aurora Blvd";
                txtContactNo.Text = "555-1005";
                txtEmailView.Text = "mark.reyes@example.com";
                txtDOB.Text = "02/14/1991";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "2024-00143-SM-0")
            {
                txtFirstView.Text = "Paula Sofia";
                txtMiddleView.Text = "T.";
                txtLastView.Text = "Lim";
                txtSuffix.Text = "";
                txtAddress.Text = "19 Bonifacio Ave";
                txtContactNo.Text = "555-1006";
                txtEmailView.Text = "paula.lim@example.com";
                txtDOB.Text = "06/30/1996";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "2024-00144-SM-0")
            {
                txtFirstView.Text = "Joshua Daniel";
                txtMiddleView.Text = "P.";
                txtLastView.Text = "Mendoza";
                txtSuffix.Text = "";
                txtAddress.Text = "101 Rizal Extension";
                txtContactNo.Text = "555-1007";
                txtEmailView.Text = "joshua.mendoza@example.com";
                txtDOB.Text = "09/18/1993";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "2024-00145-SM-0")
            {
                txtFirstView.Text = "Kimberly Rose";
                txtMiddleView.Text = "A.";
                txtLastView.Text = "Santos";
                txtSuffix.Text = "";
                txtAddress.Text = "56 Mabini Heights";
                txtContactNo.Text = "555-1008";
                txtEmailView.Text = "kimberly.santos@example.com";
                txtDOB.Text = "12/01/1995";
                txtSexView.Text = "Female";
            }

            else if (facultyID == "2024-00146-SM-0")
            {
                txtFirstView.Text = "Gabriel Enrique";
                txtMiddleView.Text = "V.";
                txtLastView.Text = "Bautista";
                txtSuffix.Text = "";
                txtAddress.Text = "33 Aurora Hills";
                txtContactNo.Text = "555-1009";
                txtEmailView.Text = "gabriel.bautista@example.com";
                txtDOB.Text = "04/27/1992";
                txtSexView.Text = "Male";
            }

            else if (facultyID == "2024-00147-SM-0")
            {
                txtFirstView.Text = "Angelica Mae";
                txtMiddleView.Text = "C.";
                txtLastView.Text = "Villanueva";
                txtSuffix.Text = "";
                txtAddress.Text = "78 Quezon Circle";
                txtContactNo.Text = "555-1010";
                txtEmailView.Text = "angelica.villanueva@example.com";
                txtDOB.Text = "08/09/1994";
                txtSexView.Text = "Female";
            }

        }

        private void Textbox_Enter(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt.ForeColor == Color.DarkGray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void Textbox_Leave(object sender, EventArgs e)
        {
            var txt = sender as ReaLTaiizor.Controls.SmallTextBox;
            if (txt.Text.Replace(" ", "") == "")
            {
                txt.Text = txt.Tag.ToString();
                txt.ForeColor = Color.DarkGray;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
