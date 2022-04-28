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
    public partial class UC_cusInfo : UserControl
    {
        function fn = new function();
        String query;
        public UC_cusInfo()
        {
            InitializeComponent();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
            {
                query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.gender,cusReg.dob,cusReg.addres,cusReg.idNumber,cusReg.contact,cusReg.checkIn,cusReg.checkOut,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid";
                getRecord(query);

                panelCancel.Visible = false;
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.gender,cusReg.dob,cusReg.addres,cusReg.idNumber,cusReg.contact,cusReg.checkIn,cusReg.checkOut,cusReg.dayss,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid where checkOut is null";
                getRecord(query);

                panelCancel.Visible = true;

            }
            else if (cmbSearch.SelectedIndex == 2)
            {
                query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.gender,cusReg.dob,cusReg.addres,cusReg.idNumber,cusReg.contact,cusReg.checkIn,cusReg.checkOut,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid where checkOut is not null";
                getRecord(query);

                panelCancel.Visible = false;
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Int64 id = Int64.Parse(txtId.Text);
            query = "delete from cusReg where cid='"+id+"'";
            fn.setData(query, "check in cancelled.");
        }

        private void UC_cusInfo_Load(object sender, EventArgs e)
        {
            panelCancel.Visible = false;
            query = "select cusReg.cid,cusReg.firstName,cusReg.lastName,cusReg.gender,cusReg.dob,cusReg.addres,cusReg.idNumber,cusReg.contact,cusReg.checkIn,cusReg.checkOut,rooms.roomNo,rooms.roomType,rooms.bed from cusReg inner join rooms on cusReg.roomid = rooms.roomid";
            getRecord(query);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtId.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
            catch (Exception) { }
        }
    }
}
