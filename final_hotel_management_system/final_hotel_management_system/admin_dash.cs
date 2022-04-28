using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace final_hotel_management_system
{
    public partial class admin_dash : Form
    {
        public admin_dash()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 204, b.Location.Y - 45);
            imgSlide.SendToBack();
        }

        private void btnCusInfo_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void btnRoomStatus_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void btnCusCheckOut_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void btnCusInfo_Click(object sender, EventArgs e)
        {
            uC_cusInfo1.Visible = true;
            uC_cusInfo1.BringToFront();
        }

        private void admin_dash_Load(object sender, EventArgs e)
        {
            uC_cusInfo1.Visible = false;
            uC_addRoom1.Visible = false;
            ucEmployee1.Visible = false;
            uC_paymentInfo1.Visible = false;
            btnCusInfo.PerformClick();

            lblDate.Text = DateTime.Now.ToShortDateString();
            timer1.Start();
        }

        private void btnRoomStatus_Click(object sender, EventArgs e)
        {
            uC_paymentInfo1.Visible = true;
            uC_paymentInfo1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_addRoom1.Visible = true;
            uC_addRoom1.BringToFront();
            
        }

        private void btnCusCheckOut_Click(object sender, EventArgs e)
        {
            ucEmployee1.Visible = true;
            ucEmployee1.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
        }

        private void guna2Button2_CheckedChanged_1(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }
    }
}
