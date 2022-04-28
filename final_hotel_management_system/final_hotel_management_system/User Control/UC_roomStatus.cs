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
    public partial class UC_roomStatus : UserControl
    {
        function fn = new function();
        String query;
        public UC_roomStatus()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
            {
                query = "select * from rooms";
                getRecord(query);
            }
            else if (cmbSearch.SelectedIndex == 1)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='A/C' and bed='Single'";
                getRecord(query);
            }
            else if (cmbSearch.SelectedIndex == 2)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='A/C' and bed='Double'";
                getRecord(query);
            }
            else if (cmbSearch.SelectedIndex == 3)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='A/C' and bed='Triple'";
                getRecord(query);
            }
            else if (cmbSearch.SelectedIndex == 4)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='non A/C' and bed='Single'";
                getRecord(query);
            }
            else if (cmbSearch.SelectedIndex == 5)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked from rooms where roomType='non A/C' and bed='Double'";
                getRecord(query);
            }
            else if (cmbSearch.SelectedIndex == 6)
            {
                query = "select rooms.roomid,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price,rooms.booked, from rooms where roomType='non A/C' and bed='Triple'";
                getRecord(query);
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_roomStatus_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            getRecord(query);
            
        }
    }
}
