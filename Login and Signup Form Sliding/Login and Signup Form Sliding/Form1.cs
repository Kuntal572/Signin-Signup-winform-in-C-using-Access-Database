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
using System.Data.OleDb;

namespace Login_and_Signup_Form_Sliding
{
    public partial class Form1 : Form
    {
        OleDbConnection con=new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Login.mdb");
        public Form1()
        {
            InitializeComponent();
        }
        private void showPass(Guna2TextBox txtBox)
        {
            if(txtBox.UseSystemPasswordChar==true)
            {
                txtBox.UseSystemPasswordChar = false;
            }
            else
            {
                txtBox.UseSystemPasswordChar = true;
            }
        }
        private void Guna2PictureBox7_Click(object sender, EventArgs e)
        {
            showPass(signinPass);
        }

        private void Guna2PictureBox8_Click(object sender, EventArgs e)
        {
            showPass(signupPass);
        }

        private void Guna2PictureBox9_Click(object sender, EventArgs e)
        {
            showPass(SignupRePass);
        }

        private void Slidebtn_Click(object sender, EventArgs e)
        {
            if(panel.Dock==DockStyle.Right)
            {
                panel.Dock = DockStyle.Left;
                slidebtn.Text = "SIGN IN";
                lblHeading.Text = "Welcome Back";
                lblDetail.Text = "To keep connect with us please login " +
                    "with your personal info";
            }
            else
            {
                panel.Dock = DockStyle.Right;
                slidebtn.Text = "SIGN UP";
                lblHeading.Text = "Hello, Friends!";
                lblDetail.Text = "Enter your personal details and start journey with us.";
            }
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "" && signupPass.Text != "" && SignupRePass.Text != "")
            {
                if (signupPass.Text == SignupRePass.Text)
                {
                    string query = "insert into login values('" + txtuser.Text + "','" + signupPass.Text + "')";
                    OleDbCommand cmd = new OleDbCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblsuccessmsg.Text = "Signup success got to signin";
                    lblsuccessmsg.Visible = true;
                    picSuccess.Visible = true;
                }
                else
                {
                    lblsuccessmsg.Text = "Password not match";
                    lblsuccessmsg.Visible = true;
                }
            }
            else
            {
                lblsuccessmsg.Text = "Please Fill All";
                lblsuccessmsg.Visible = true;
            }
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            if(signinUser.Text!="" && signinPass.Text!="")
            {
                string query = "select * from login where username='" + signinUser.Text + "' and '" + signinPass.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query,con);
                con.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                if(count==1)
                {
                    signinMsg.Text = "Signin Success";
                    signinMsg.Visible = true;
                    picBox.Visible = true;
                }
                else
                {
                    signinMsg.Text = "Signin Failed";
                    signinMsg.Visible = true;
                }
            }
            else
            {
                signinMsg.Text = "Please Fill All";
                signinMsg.Visible = true;
            }
        }
    }
}
