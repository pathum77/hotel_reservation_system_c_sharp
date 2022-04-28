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
    public partial class UC_addRoom : UserControl
    {

        function fn = new function();
        String query;
        int id;

        public UC_addRoom()
        {
            InitializeComponent();
        }



        private void UC_addRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (txtRoomNumber.Text != "" && cmbRoomType.Text != "" && cmbBed.Text != "" && txtPrice.Text != "")
            {

                String roomno = txtRoomNumber.Text;
                String type = cmbRoomType.Text;
                String bed = cmbBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                query = "insert into rooms (roomNo,roomType,bed,price) values ('" + roomno + "','" + type + "','" + bed + "'," + price + ")";
                fn.setData(query, "Room Added.");

                UC_addRoom_Load(this, null);

            }
            else
            {
                MessageBox.Show("Fill all fields.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //        {
        //            id = int.Parse(DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        //        }
        //    }
        //    catch (Exception) { }
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if
        //    query = "delete from cusReg where roomid='" + id + "'";
        //    fn.setData(query, "Room was Removed!.");
        //}
    }
}
