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

namespace final_hotel_management_system.User_Control
{
    public partial class UC_onlineReg : UserControl
    {
        function fn = new function();
        String query;
        String roomid;
        Int64 price;

        //String date;
        public UC_onlineReg()
        {
            InitializeComponent();
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

        public void appoinmentsLoad()
        {
            query = "select cid,firstName,lastName,checkIn,roomType,bed from onlineReg where verification = 'pending'";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        public void roomStatusLoad()
        {
            query = "select roomid,roomNo,roomType,bed,booked from rooms";
            DataSet ds = fn.getData(query);
            DataGridView2.DataSource = ds.Tables[0];
        }

        public void acceptedCusLoad()
        {
            query = "select cid,firstName,lastName,gender,dob,addres,idNumber,contact,checkIn,roomType,bed from onlineReg where verification = 'accept'";
            DataSet ds = fn.getData(query);
            DataGridView3.DataSource = ds.Tables[0];
        }

        
        private void txtAccept_Click(object sender, EventArgs e)
        {
            query = "update onlineReg set verification = 'accept' where cid = '"+txtCusId.Text+ "'";// update rooms set onlinereg = '"+txtCheckInDate.Text+"' where roomNo = '"+cmbRoomNumber.Text+"'";
            fn.setData(query, "Customer iid " + txtCusId.Text + "Accepted.");            
            appoinmentsLoad();
            txtCusId.Clear();
            txtCusName.Clear();
            txtRType.Clear();
            txtRType.Clear();
            txtBType.Clear();
            acceptedCusLoad();
        }

        private void UC_onlineReg_Load(object sender, EventArgs e)
        {
            appoinmentsLoad();
            roomStatusLoad();
            acceptedCusLoad();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtCusId.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtCusName.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtCheckInDate.Text = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtRType.Text = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtBType.Text = DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
            }catch(Exception) { }
        }


        private void txtDenied_Click(object sender, EventArgs e)
        {
            query = "update onlineReg set verification = 'denied' where cid = '"+txtCusId.Text+"'";
            fn.setData(query, "Customer id " + txtCusId.Text + "Denied.");
            appoinmentsLoad();
            txtRType.Clear();
            txtCusName.Clear();
            txtRType.Clear();
            txtBType.Clear();
            txtRType.Clear();
        }

        private void txtRefresh_Click(object sender, EventArgs e)
        {
            acceptedCusLoad();
            appoinmentsLoad();
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtCId.Text = DataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();                    
                    txtRoomType.Text = DataGridView3.Rows[e.RowIndex].Cells[9].Value.ToString();
                    txtBedType.Text = DataGridView3.Rows[e.RowIndex].Cells[10].Value.ToString();
                }
            }
            catch (Exception) { }
        }

       
        private void txtRoomType_TextChanged(object sender, EventArgs e)
        {
            cmbRoomNumber.Items.Clear();
            query = "select * from rooms where bed ='" + txtBedType.Text + "' and roomType ='" + txtRoomType.Text + "'  and booked ='NO'";
            setComboBox(query, cmbRoomNumber);
        }

        private void txtBedType_TextChanged(object sender, EventArgs e)
        {
            cmbRoomNumber.Items.Clear();
            query = "select * from rooms where bed ='" + txtBedType.Text + "' and roomType ='" + txtRoomType.Text + "'  and booked ='NO'";
            setComboBox(query, cmbRoomNumber);
        }
        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            try {
                query = "select price,roomid from rooms where roomNo = '" + cmbRoomNumber.Text + "'";
                DataSet ds = fn.getData(query);

                String Price = ds.Tables[0].Rows[0][0].ToString();
                roomid = ds.Tables[0].Rows[0][1].ToString();
                int days = int.Parse(txtDays.Text);
                int price = int.Parse(Price);               
                    txtPrice.Text = (days * price).ToString();              
            }
            catch (Exception) { }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String first;
            String last;
            String gender;
            String dob;
            String address;
            String idCard;
            String Contact;
            String checkIn;
            String fullName;
            String Advance;
            String Days = txtDays.Text;

                query = "select firstName, lastName, gender,dob, addres,idNumber, contact, checkIn from onlineReg where cid = '" + txtCId.Text + "'";
                DataSet ds = fn.getData(query);

            first = ds.Tables[0].Rows[0][0].ToString();
            last = ds.Tables[0].Rows[0][1].ToString();
            gender = ds.Tables[0].Rows[0][2].ToString();
            dob = ds.Tables[0].Rows[0][3].ToString();
            address = ds.Tables[0].Rows[0][4].ToString();
            idCard = ds.Tables[0].Rows[0][5].ToString();
            Contact = ds.Tables[0].Rows[0][6].ToString();
            Int64 contact = Int64.Parse(Contact);
            checkIn = ds.Tables[0].Rows[0][7].ToString();
          //  int rid = int.Parse(txtRId.Text);
            fullName = first + " " + last;
            int advance = int.Parse(txtAdvance.Text);
            int total = int.Parse(txtPrice.Text);
            int dueToPay = total - advance;
            int days = int.Parse(Days);

            query = "insert into cusReg (firstName,lastName,gender,dob,addres,idNumber,contact,checkIn,dayss,roomid) values ('" + first + "','" + last + "','" + gender + "','" + dob + "','" + address + "','" + idCard + "','" + contact + "','" + checkIn + "','"+days+"','" + roomid + "') insert into total (cusName,advance,servic,reduce,discount,room,total,dueToPay) values ('" + fullName + "','" + advance + "','0','0','0','" + total + "','" + total + "','" + dueToPay + "') delete from onlineReg where cid='" + txtCId.Text + "' update rooms set booked ='YES' where roomNo = '" + cmbRoomNumber.Text + "'";
            fn.setData(query, "Room No " + cmbRoomNumber.Text + " Allocation Succesfull");

            txtPrice.Clear();
            txtRoomType.Clear();
            txtDays.Clear();
            txtCId.Clear();
            txtAdvance.Clear();
            txtBedType.Clear();
            cmbRoomNumber.SelectedIndex = -1;

            acceptedCusLoad();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            query = "delete from onlineReg where cid = '" + txtPrice.Text + "'";
            fn.setData(query, "Customer id " + txtPrice.Text + " Removed!");
            acceptedCusLoad();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select cid,firstName,lastName,gender,dob,addres,idNumber,contact,checkIn,roomType,bed from onlineReg where firstName like '"+txtSearch.Text+"%' and verification = 'accept'";
            DataSet ds = fn.getData(query);
            DataGridView3.DataSource = ds.Tables[0];
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
            {
                query = "select * from rooms";
                DataSet ds = fn.getData(query);
                DataGridView2.DataSource = ds.Tables[0];
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='A/C' and bed='Single'";
                DataSet ds = fn.getData(query);
                DataGridView2.DataSource = ds.Tables[0];
            }
            else if (cmbSearch.SelectedIndex == 2)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='A/C' and bed='Double'";
                DataSet ds = fn.getData(query);
                DataGridView2.DataSource = ds.Tables[0];
            }
            else if (cmbSearch.SelectedIndex == 3)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='A/C' and bed='Triple'";
                DataSet ds = fn.getData(query);
                DataGridView2.DataSource = ds.Tables[0];
            }
            else if (cmbSearch.SelectedIndex == 4)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='non A/C' and bed='Single'";
                DataSet ds = fn.getData(query);
                DataGridView2.DataSource = ds.Tables[0];
            }
            else if (cmbSearch.SelectedIndex == 5)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='non A/C' and bed='Double'";
                DataSet ds = fn.getData(query);
                DataGridView2.DataSource = ds.Tables[0];
            }
            else if (cmbSearch.SelectedIndex == 6)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='non A/C' and bed='Triple'";
                DataSet ds = fn.getData(query);
                DataGridView2.DataSource = ds.Tables[0];
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
