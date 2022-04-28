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
using System.IO;

namespace final_hotel_management_system.User_Control
{
    public partial class UC_billing : UserControl
    {
        function fn = new function();
        String query;
        Int64 rooms;

        public UC_billing()
        {
            InitializeComponent();
        }

        private void txtService_Click(object sender, EventArgs e)
        {
            txtService.SelectAll();
        }

        private void txtReduce_Click(object sender, EventArgs e)
        {
            txtReduce.SelectAll();
        }

        private void txtAdvance_Click(object sender, EventArgs e)
        {
            txtAdvance.SelectAll();
        }
        private void UC_billing_Load(object sender, EventArgs e)
        {
            query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.addres,cusReg.contact,cusReg.checkIn,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid where chekOut = 'NO'";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.addres,cusReg.contact,cusReg.checkIn,cusReg.dayss,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid where firstName like '" + txtName.Text + "%' and chekOut = 'NO'";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

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
                    txtCheckedIn.Text = DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                    query = "select total,dueToPay,servic,reduce,discount,advance,room from total where cusName='" + txtCName.Text + "'";
                    SqlDataReader sdr = fn.getDataa(query);
                    while (sdr.Read())
                    {
                        txtTotalAdvance.Text = sdr.GetValue(5).ToString();
                        txtTotalService.Text = sdr.GetValue(2).ToString();
                        txtTotalReduce.Text = sdr.GetValue(3).ToString();
                        txtTotal.Text = sdr.GetValue(0).ToString();
                        txtDueToPay.Text = sdr.GetValue(1).ToString();
                        String Rooms = sdr.GetValue(6).ToString();
                        rooms = Int64.Parse(Rooms);
                        txtRooms.Text = rooms.ToString();
                    }
                }
            }
            catch (Exception) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Int64 service = Int64.Parse(txtService.Text);
            Int64 reduce = Int64.Parse(txtReduce.Text);
            Int64 advance = Int64.Parse(txtAdvance.Text);
            Int64 tService = Int64.Parse(txtTotalService.Text);
            Int64 tReduce = Int64.Parse(txtTotalReduce.Text);
            Int64 tAdvance = Int64.Parse(txtTotalAdvance.Text);
            Int64 total = Int64.Parse(txtTotal.Text);
            Int64 dueToPay = Int64.Parse(txtDueToPay.Text);
           // int roomCharge;

                                
            

            if (rdoService.Checked == true)
            {
                tService += service - reduce;
            }
            else if (rdoRCharge.Checked == true)
            {
                rooms -= reduce;
            }

            tReduce += reduce;
            tAdvance += advance;
            total += service - reduce;
            dueToPay = total - tAdvance;
            

            txtTotalService.Text = tService.ToString();
            txtTotalReduce.Text = tReduce.ToString();
            txtTotalAdvance.Text = tAdvance.ToString();
            txtTotal.Text = total.ToString();
            txtDueToPay.Text = dueToPay.ToString();
            txtRooms.Text = rooms.ToString();


            query = "update total set advance='"+txtTotalAdvance.Text+"',servic='"+txtTotalService.Text+"',reduce='"+txtTotalReduce.Text+"',total='"+txtTotal.Text+"',dueToPay='"+txtDueToPay.Text+"',room='"+txtRooms.Text+"' where cusName='"+txtCName.Text+"'";
            fn.setData(query, "Bill information of " + txtCName.Text + " was updated successfully!");

            if (txtServiceInfo.Text != null && txtService.Text!="0")
            {
                string path = Application.StartupPath + "\\Payments\\service\\" + txtCName.Text + ".txt";

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(" " + txtServiceInfo.Text + "\t\t\t\t" + txtService.Text);
                        sw.Close();
                    }
                    txtServiceInfo.Clear();
                    txtService.Text = "0";
                }
                else if (File.Exists(path))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(" " + txtServiceInfo.Text + "\t\t\t\t" + txtService.Text);
                        sw.Close();
                    }
                    txtServiceInfo.Clear();
                    txtService.Text = "0";
                }
            }

            if(txtReduceInfo.Text !=null && txtReduce.Text != "0") {
                if (txtReduceInfo.Text != null)
                {
                    string path = Application.StartupPath + "\\Payments\\reduce\\" + txtCName.Text + ".txt";

                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(" " + txtReduceInfo.Text + "\t\t\t\t" + txtReduce.Text);
                            sw.Close();
                        }
                    }
                    else if (File.Exists(path))
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(" " + txtReduceInfo.Text + "\t\t\t\t" + txtReduce.Text);
                            sw.Close();
                        }
                    }
                    txtReduceInfo.Clear();
                    txtReduce.Text = "0";
                }
            }
            txtAdvance.Text = "0";
        }

        private void txtServiceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtService.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtReduceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReduce.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}
