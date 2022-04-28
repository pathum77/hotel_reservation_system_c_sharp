using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_hotel_management_system.User_Control
{
    public partial class UC_hallBooking : UserControl
    {
        function fn = new function();
        String query;
        public UC_hallBooking()
        {
            InitializeComponent();
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*  if (cmbFood.SelectedIndex == 0)
              {
                  normal.Visible = true;
                  normal.BringToFront();
                  mid.SendToBack();
                  advance.SendToBack();
              }
              else if (cmbFood.SelectedIndex == 1)
              {
                  mid.Visible = true;
                  mid.BringToFront();
                  normal.SendToBack();
                  advance.SendToBack();
              }
              else if (cmbFood.SelectedIndex == 2)
              {
                  advance.Visible = true;
                  advance.BringToFront();
                  normal.SendToBack();
                  mid.SendToBack();

              }

              Int64 memberss = Int64.Parse(txtMembers.Text);
              if (cmbFood.SelectedIndex == 0)
              {
                  int total = (int)((500 * memberss) + 30000);
                  txtPrice.Text = total.ToString();
              }
              else if (cmbFood.SelectedIndex == 1)
              {
                  int total = (int)((700 * memberss) + 30000);
                  txtPrice.Text = total.ToString();
              }
              else if (cmbFood.SelectedIndex == 2)
              {
                  int total = (int)((1000 * memberss) + 30000);
                  txtPrice.Text = total.ToString();
              } */


        }


        private void btnAllocateRoom_Click(object sender, EventArgs e)
        {
           /* if (txtFirst.Text != "" && txtLast.Text != "" && cmbGender.Text != "" && txtDOB.Text != "" && txtAddress.Text != "" && txtIdCard.Text != "" && txtContact.Text != "" && txtBookingDate.Text != "" && cmbTime.Text != "" && txtMembers.Text != "" && cmbFood.Text != "" && txtPrice.Text != "")
            {
                String first = txtFirst.Text;
                String last = txtLast.Text;
                String gender = cmbGender.Text;
                String dob = txtDOB.Text;
                String address = txtAddress.Text;
                String idcard = txtIdCard.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String bookingDate = txtBookingDate.Text;
                String time = cmbTime.Text;
                Int64 members = Int64.Parse(txtMembers.Text);
                String food = cmbFood.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                //int totalPrice = 

                query = "insert into hallBooking (firstName,lastName,gender,dob,idNumber,addres,contact,bookingDate,timee,food,members,price) values ('" + first+ "','"+last+ "','"+gender+ "','"+dob+ "','"+idcard+ "','" + address + "','" + contact+ "','"+bookingDate+ "','"+time+ "','"+food+ "','" + members + "','" + price+"')";
                fn.setData(query, " Allocation Succesfull");

            }
            else
            {
                MessageBox.Show("Fill All Fields", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } */
        }

        private void cmbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 memberss = Int64.Parse(txtMembers.Text);
            if (cmbFood.SelectedIndex == 0)
            {
                int total = (int)((500 * memberss) + 30000);
                txtPrice.Text = total.ToString();
            }
            else if (cmbFood.SelectedIndex == 1)
            {
                int total = (int)((700 * memberss) + 30000);
                txtPrice.Text = total.ToString();
            }
            else if (cmbFood.SelectedIndex == 2)
            {
                int total = (int)((1000 * memberss) + 30000);
                txtPrice.Text = total.ToString();
            }
        }

        private void btnAllocateRoom_Click_1(object sender, EventArgs e)
        {
            if (txtFirst.Text != "" && txtLast.Text != "" && cmbGender.Text != "" && txtDOB.Text != "" && txtAddress.Text != "" && txtIdCard.Text != "" && txtContact.Text != "" && txtBookingDate.Text != "" && cmbTime.Text != "" && txtMembers.Text != "" && cmbFood.Text != "" && txtPrice.Text != "")
            {
                String first = txtFirst.Text;
                String last = txtLast.Text;
                String gender = cmbGender.Text;
                String dob = txtDOB.Text;
                String address = txtAddress.Text;
                String idcard = txtIdCard.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String bookingDate = txtBookingDate.Text;
                String time = cmbTime.Text;
                Int64 members = Int64.Parse(txtMembers.Text);
                String food = cmbFood.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                //int totalPrice = 

                query = "insert into hallBooking (firstName,lastName,gender,dob,idNumber,addres,contact,bookingDate,timee,food,members,price) values ('" + first + "','" + last + "','" + gender + "','" + dob + "','" + idcard + "','" + address + "','" + contact + "','" + bookingDate + "','" + time + "','" + food + "','" + members + "','" + price + "')";
                fn.setData(query, " Allocation Succesfull");
                clearAll();

            }
            else
            {
                MessageBox.Show("Fill All Fields", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtFirst.Clear();
            txtLast.Clear();
            cmbGender.SelectedIndex = -1;
            txtDOB.ResetText();
            txtAddress.Clear();
            txtIdCard.Clear();
            txtContact.Clear();
            txtBookingDate.ResetText();
            cmbFood.SelectedIndex = -1;
            cmbTime.SelectedIndex = -1;
            txtMembers.Clear();
            txtPrice.Clear();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSearch.SelectedIndex == 0)
            {
                query = "select * from hallBooking";
                getRecord(query);
            }
        }

        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void cmbTime_SelectedValueChanged(object sender, EventArgs e)
        {
            query = "select * from hallBooking where timee='"+cmbTime.Text+"' and bookingDate='"+txtBookingDate.Text+"'";
            DataSet ds = fn.getData(query);
            int i = ds.Tables[0].Rows.Count;
            if (i>0)
            {
                MessageBox.Show("Alredy exist");
            }
        }

        private void txtBookingDate_ValueChanged(object sender, EventArgs e)
        {
            query = "select * from hallBooking where timee='" + cmbTime.Text + "' and bookingDate='" + txtBookingDate.Text + "'";
            DataSet ds = fn.getData(query);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                MessageBox.Show("Alredy exist");
                cmbTime.SelectedIndex = -1;
            }
        }

        /* private void cmbFood_SelectedIndexChanged(object sender, EventArgs e)
         {

         }*/
    }
}
