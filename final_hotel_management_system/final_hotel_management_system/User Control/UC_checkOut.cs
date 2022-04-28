using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace final_hotel_management_system.User_Control
{
    public partial class UC_checkOut : UserControl
    {
         String[] a; //bill
        String service, reduce, advance, tel, address, DueToPay;
        int discount,dueToPay;

        function fn = new function();
        String query;

        public UC_checkOut()
        {
            InitializeComponent();
        }

        private void UC_checkOut_Load(object sender, EventArgs e)
        {
            query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.addres,cusReg.contact,cusReg.checkIn,cusReg.dayss,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid where chekOut = 'NO'";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.addres,cusReg.contact,cusReg.checkIn,cusReg.dayss,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid where firstName like '"+txtName.Text+"%' and chekOut = 'NO'";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];            
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                rchBill.Clear();
                Bill();
                discount = int.Parse(txtDiscount.Text);
                dueToPay = int.Parse(DueToPay);
                txtDueToPay.Text = (dueToPay - discount).ToString();
                lblDate.Text = DateTime.Now.ToShortDateString();
                timer1.Start();
                e.SuppressKeyPress = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawString(rchBill.Text, new Font("New Times Romance", 30, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        //}

        int id;

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    id = int.Parse(DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtCName.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtRoomNumber.Text = DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    tel = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtCheckedIn.Text = DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    address = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }

                query = "select total,dueToPay,servic,reduce,advance from total where cusName='" + txtCName.Text + "'";
                SqlDataReader sdr = fn.getDataa(query);
                while (sdr.Read())
                {
                    txtTotal.Text = sdr.GetValue(0).ToString();
                    DueToPay = sdr.GetValue(1).ToString();
                    service = sdr.GetValue(2).ToString();
                    reduce = sdr.GetValue(3).ToString();
                    advance = sdr.GetValue(4).ToString();
                }
            }catch(Exception) { }
        }

        public void Bill()
        {            
            rchBill.AppendText(" " + lblDate.Text + Environment.NewLine);
            rchBill.AppendText(" " + lblTimer.Text + Environment.NewLine);
            rchBill.AppendText("----------------------------------------------------------------------------" + Environment.NewLine);
            rchBill.AppendText("From" + Environment.NewLine);
            rchBill.AppendText("\tHotel Name" + Environment.NewLine);
            rchBill.AppendText("\tNo: 20/1," + Environment.NewLine);
            rchBill.AppendText("\tKandy." + Environment.NewLine);
            rchBill.AppendText("\tTel: 771234567" + Environment.NewLine);
            rchBill.AppendText("\tEmail: HotelName@gmail.com" + Environment.NewLine);
            rchBill.AppendText("----------------------------------------------------------------------------" + Environment.NewLine);
            rchBill.AppendText("To" + Environment.NewLine);
            rchBill.AppendText("\t" + txtCName.Text + Environment.NewLine);
            rchBill.AppendText("\t" + address + Environment.NewLine);
            rchBill.AppendText("\tTel: " + tel + Environment.NewLine);
            rchBill.AppendText("\tCheck In: " + txtCheckedIn.Text + Environment.NewLine);
            rchBill.AppendText("\tCheck Out: " + txtCheckOutDate.Text + Environment.NewLine);
            rchBill.AppendText("----------------------------------------------------------------------------" + Environment.NewLine);
            rchBill.AppendText(Environment.NewLine);
            rchBill.AppendText("----------------------------------------------------------------------------" + Environment.NewLine);
            rchBill.AppendText("Services" + Environment.NewLine);

            string path1 = Application.StartupPath + "\\Payments\\service\\" + txtCName.Text + ".txt";

            if (File.Exists(path1))
            {
                using (StreamReader sr = File.OpenText(path1))
                {
                    string service = sr.ReadToEnd();
                    sr.Close();
                    rchBill.AppendText(service + Environment.NewLine);
                }
            }

            rchBill.AppendText("Reduce" + Environment.NewLine);
            string path = Application.StartupPath + "\\Payments\\reduce\\" + txtCName.Text + ".txt";

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string reduce = sr.ReadToEnd();
                    sr.Close();
                    rchBill.AppendText(reduce + Environment.NewLine);
                }
            }

            rchBill.AppendText("----------------------------------------------------------------------------" + Environment.NewLine);
            rchBill.AppendText(" total\t\t\t\t" + txtTotal.Text + Environment.NewLine);
            rchBill.AppendText("----------------------------------------------------------------------------" + Environment.NewLine);
            rchBill.AppendText(" discount\t\t\t\t" + txtDiscount.Text + Environment.NewLine);
            rchBill.AppendText(" advance\t\t\t\t" + advance + Environment.NewLine);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if (MessageBox.Show("Are you sure?","Conformation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    String checkOutDate = txtCheckOutDate.Text;
                    query = "update cusReg set chekOut = 'YES',checkOut='"+checkOutDate+"' where cid="+id+" update rooms set booked = 'NO' where roomNo = '"+txtRoomNumber.Text+"' update total set discount = '"+txtDiscount.Text+"', dueToPay = '0',chekOut = 'YES' where cusName = '"+txtCName.Text+"'";
                    fn.setData(query, "Check Out Successfully.");
                    //if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    //{
                    //    printDocument1.Print();
                    //}
                    UC_checkOut_Load(this, null);
                    ClearAll();                   
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ClearAll()
        {
            txtName.Clear();
            txtCName.Clear();
            txtRoomNumber.Clear();
            txtCheckOutDate.ResetText();
            txtCheckedIn.Clear();
            rchBill.Clear();
            txtDiscount.Clear();
            txtDueToPay.Clear();
            txtTotal.Clear();
        }

        private void UC_checkOut_Leave(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
