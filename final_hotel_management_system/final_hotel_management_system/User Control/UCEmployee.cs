using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using final_hotel_management_system;

namespace Hotel_Management_System.Admin_User_Controls
{
    public partial class UCEmployee : UserControl
    {
        function fn = new function();
        String query;

        public UCEmployee()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void UCEmployee_Load(object sender, EventArgs e)
        {
            getMaxId();  
        }

        public void getMaxId()
        {
            query = "select max(empid) from employe";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                label2.Text = (num + 1).ToString();
            }
        }

        public void clearAll()
        {
            nameTextBox.Clear();
            genderComboBox.SelectedIndex = -1;
            mNumberTextBox.Clear();
            emailTextBox.Clear();
            userNameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && genderComboBox.Text != "" && mNumberTextBox.Text != "" && emailTextBox.Text != "" && userNameTextBox.Text != "" && passwordTextBox.Text != "")
            {
                String employeeName = nameTextBox.Text;
                String gender = genderComboBox.Text;
                Int64 mobileNumber = Int64.Parse(mNumberTextBox.Text);
                String email = emailTextBox.Text;
                String username = userNameTextBox.Text;
                String password = passwordTextBox.Text;

                query = "insert into employe(employeeName, gender, mobileNumber, email, username, password) values ('"+employeeName+"', '"+gender+"', '"+mobileNumber+"', '"+email+"', '"+username+"', '"+password+"')";
                fn.setData(query, "New Receptionist Registerd.");

                clearAll();
                getMaxId();

            }
            else
            {
                MessageBox.Show("Fill all Fields", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 1)
            {
                setEmployee(employeeDataGridView);

            }
            else if (tabEmployee.SelectedIndex == 2)
            {
                setEmployee(deleteEmployeeDataGridView);
            }
            
            
        }

        public void setEmployee(DataGridView dgv)
        {
            query = "select * from employe";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Cnfirmation...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
                query = "delete from employe where empid = '" + searchTextBox.Text + "'";
                fn.setData(query, "Record Deleted.");
                tabEmployee_SelectedIndexChanged(this, null);
            }
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {

        }

        private void UCEmployee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkCreate_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
