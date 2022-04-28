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
    public partial class rec_dash : Form
    {
        function fn = new function();
        String query;

        public rec_dash()
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

        private void guna2Button4_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_cusReg1.Visible = true;
            uC_cusReg1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uC_roomStatus1.Visible = true;
            uC_roomStatus1.BringToFront();
            
        }

        private void dashContainer_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           lblTimer.Text = DateTime.Now.ToLongTimeString();
        }

        private void rec_dash_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            timer1.Start();
            



            uC_cusReg1.Visible = false;
            uC_roomStatus1.Visible = false;
            uC_cusInfo1.Visible = false;
            uC_checkOut1.Visible = false;
            uC_billing1.Visible = false;
            uC_onlineReg1.Visible = false;
            btnCusReg.PerformClick();
        }

        private void btnCusInfo_Click(object sender, EventArgs e)
        {
            uC_cusInfo1.Visible = true;
            uC_cusInfo1.BringToFront();
        }

        private void btnCusCheckOut_Click(object sender, EventArgs e)
        {
            uC_checkOut1.Visible = true;
            uC_checkOut1.BringToFront();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            uC_billing1.Visible = true;
            uC_billing1.BringToFront();
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            uC_onlineReg1.Visible = true;
            uC_onlineReg1.BringToFront();
        }

        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }
    }
}
