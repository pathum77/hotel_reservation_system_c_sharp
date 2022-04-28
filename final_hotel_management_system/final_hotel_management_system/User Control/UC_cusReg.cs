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
using System.Text.RegularExpressions;

namespace final_hotel_management_system.User_Control
{
    public partial class UC_cusReg : UserControl
    {
        function fn = new function();
        String query;

        public UC_cusReg()
        {
            InitializeComponent();
        }

        private void UC_cusReg_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtFirst;
            txtFirst.Focus();
           
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                    combo.Items.Add(sdr.GetString(1));
            }
            sdr.Close();
        }

        private void cmbBed_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbRoomNumber.Items.Clear();
            txtPrice.Clear();
            query = "select * from rooms where bed ='" + cmbBed.Text + "' and roomType ='" + cmbRoomType.Text + "'  and booked ='NO'";
            setComboBox(query, cmbRoomNumber);
        }

        private void cmbRoomType_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbRoomNumber.Items.Clear();
            txtPrice.Clear();
            query = "select * from rooms where bed ='" + cmbBed.Text + "' and roomType ='" + cmbRoomType.Text + "'  and booked ='NO'";
            setComboBox(query, cmbRoomNumber);
        }

        int rid;

        private void cmbRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                query = "select price,roomid from rooms where roomNo = '" + cmbRoomNumber.Text + "'";
                DataSet ds = fn.getData(query);
                
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
                Int64 price = Convert.ToInt64 (txtPrice.Text);
                Int64 days = Convert.ToInt64(txtDays.Text);
                Int64 final = price * days;
                txtLastPrice.Text = final.ToString();
                rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
            }
            catch (Exception) { }
        }

        private void btnAllocateRoom_Click(object sender, EventArgs e)
        {
            if(txtFirst.Text !="" && txtLast.Text !="" && cmbGender.Text !="" && txtDOB.Text !="" && txtAddress.Text !="" && txtIdCard.Text !="" && txtContact.Text !="" && txtCheckIn.Text !="" && cmbRoomType.Text !="" && cmbBed.Text !="" && cmbRoomNumber.Text !="" && txtPrice.Text != "")
            {
                String first = txtFirst.Text;
                String last = txtLast.Text;
                String gender = cmbGender.Text;
                String dob = txtDOB.Text;
                String address = txtAddress.Text;
                String idcard = txtIdCard.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String checkin = txtCheckIn.Text;
                String Days = txtDays.Text;

                String fullName = first +" "+ last;
                Int64 advance = Int64.Parse(txtAdvance.Text);
                Int64 roomTotal = Int64.Parse(txtLastPrice.Text);
                Int64 total = roomTotal;
                Int64 dueToPay = total - advance;
                Int64 days = Int64.Parse(Days);

                query = "insert into cusReg (firstName,lastName,gender,dob,addres,idNumber,contact,checkIn,dayss,roomid) values ('"+first+ "','"+last+ "','"+gender+ "','"+dob+ "','"+address+ "','"+idcard+ "','"+contact+"','"+checkin+"','"+days+"','"+rid+ "') insert into total (cusName,advance,servic,reduce,discount,room,total,dueToPay) values ('" + fullName + "','" + advance + "','0','0','0','"+total+"','" + total + "','" + dueToPay + "') update rooms set booked ='YES' where roomNo = '" + cmbRoomNumber.Text+"'";
                fn.setData(query, "Room No " + cmbRoomNumber.Text + " Allocation Succesfull");

                lblMValidate.Visible = false;

                //lblMValidate.Text = "";

                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Fields","Information!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            txtCheckIn.ResetText();
            cmbRoomType.SelectedIndex = -1;
            cmbBed.SelectedIndex = -1;
            cmbRoomNumber.SelectedIndex = -1;
            txtPrice.Clear();
            txtDays.Clear();
            txtLastPrice.Clear();
            txtAdvance.Text = "0";           
        }

        private void UC_cusReg_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "select price,roomid from rooms where roomNo = '" + cmbRoomNumber.Text + "'";
                DataSet ds = fn.getData(query);

                txtLastPrice.Clear();

                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
                Int64 price = Convert.ToInt64(txtPrice.Text);
                Int64 days = Convert.ToInt64(txtDays.Text);
                Int64 final = price * days;
                txtLastPrice.Text = final.ToString();
                rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
            }
            catch (Exception) { }
        }

        private void txtFirst_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtLast.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtIdCard.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtIdCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContact.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            contactValidation();
        }

        public void contactValidation()
        {
            string no = txtContact.Text;
            Regex regex = new Regex(@"^(^[0][1-9]\d{8}$)+$");
            Match match = regex.Match(no);
            
            if (match.Success)
            {
                lblMValidate.Text = "";
            }
            else
            {
                lblMValidate.Text = "The Contact Number is Incorrect";
            }
        }
    }
}
