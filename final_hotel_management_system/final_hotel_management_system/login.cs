using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_hotel_management_system
{
    public partial class login : Form
    {
        function fn = new function();
        String query;

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public login()
        {
            InitializeComponent();
            con = new SqlConnection("data source = DESKTOP-R4S2TE2;database=hotelManagement;integrated security =True");
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            if(rdoAdmin.Checked == true)
            {
                if(txtUser.Text == "admin" && txtPass.Text == "1234")
                {

                    admin_dash ad = new admin_dash();
                    ad.Show();
                    this.Hide();
                    
                }
                else if (txtUser.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("username or password cannot be empty", "Warning !!!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    lblError.Visible = true;
                    txtPass.Clear();
                }
            }
            else
            {
                string user = txtUser.Text;
                string pass = txtPass.Text;
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM employe where username='" + txtUser.Text + "' AND password='" + txtPass.Text + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    rec_dash rd = new rec_dash();
                    rd.Show();
                    this.Hide();
                }
              
                else if (txtUser.Text == "" || txtPass.Text == "")
                {
                    MessageBox.Show("username or password cannot be empty", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblError.Visible = true;
                    txtPass.Clear();
                    txtPass.Focus();
                }
                con.Close();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}
