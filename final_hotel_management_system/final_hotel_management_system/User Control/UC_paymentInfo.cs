using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final_hotel_management_system.User_Control
{
    public partial class UC_paymentInfo : UserControl
    {
        function fn = new function();
        String query,Service,Reduce;
        public UC_paymentInfo()
        {
            InitializeComponent();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSearch.SelectedIndex == 0)
            {
                query = "select billID,cusName,advance,servic,reduce,discount,room,total,dueToPay from total where chekOut='NO'";
                getRecord(query);
            }
            else if(cmbSearch.SelectedIndex == 1)
            {
                query = "select billID,cusName,advance,servic,reduce,discount,room,total from total where chekOut='YES'";
                getRecord(query);
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_paymentInfo_Load(object sender, EventArgs e)
        {
            query = "select * from total where chekOut='NO'";
            getRecord(query);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                    try
                    {
                    txtBillID.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtName.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Service = DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Reduce = DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                    string path1 = Application.StartupPath + "\\Payments\\service\\" + txtName.Text + ".txt";

                    if (File.Exists(path1))
                    {
                        using (StreamReader sr = File.OpenText(path1))
                        {
                            string service = sr.ReadToEnd();
                            sr.Close();
                            richTextBox1.AppendText("\tServices : " + Environment.NewLine);
                            richTextBox1.AppendText(Environment.NewLine);
                            richTextBox1.AppendText(service + Environment.NewLine);
                            richTextBox1.AppendText("\t\t\t\t\t-------------" + Environment.NewLine);
                            richTextBox1.AppendText(" Total Service\t\t\t" + Service + Environment.NewLine);
                            richTextBox1.AppendText("\t\t\t\t\t-------------" + Environment.NewLine);
                            richTextBox1.AppendText(Environment.NewLine);
                            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);
                            richTextBox1.AppendText(Environment.NewLine);
                        }
                    }
                    else
                    {
                        richTextBox1.AppendText("\tServices : " + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        richTextBox1.AppendText("No Records" + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        richTextBox1.AppendText("--------------------------------------------------------------------" + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                    }

                    string path = Application.StartupPath + "\\Payments\\reduce\\" + txtName.Text + ".txt";

                    if (File.Exists(path))
                    {
                        using (StreamReader sr = File.OpenText(path))
                        {
                            string reduce = sr.ReadToEnd();
                            sr.Close();
                            richTextBox1.AppendText("\tReduces : " + Environment.NewLine);
                            richTextBox1.AppendText(Environment.NewLine);
                            richTextBox1.AppendText(reduce + Environment.NewLine);
                            richTextBox1.AppendText("\t\t\t\t\t-------------" + Environment.NewLine);
                            richTextBox1.AppendText(" Total Reduce\t\t\t" + Reduce + Environment.NewLine);
                            richTextBox1.AppendText("\t\t\t\t\t-------------" + Environment.NewLine);
                            richTextBox1.AppendText(Environment.NewLine);
                            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);
                        }
                    }
                    else
                    {
                        richTextBox1.AppendText("\tReduces : " + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        richTextBox1.AppendText(" No Records" + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        richTextBox1.AppendText("--------------------------------------------------------------------" + Environment.NewLine);
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
