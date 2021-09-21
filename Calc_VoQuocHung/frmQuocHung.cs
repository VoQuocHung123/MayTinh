using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_VoQuocHung
{
    public partial class frmQuocHung : Form
    {

        String toantu = "";
        double KetQua = 0;
        public frmQuocHung()
        {
            InitializeComponent();
        }


        public void Nhapso(string so)
        {
            if (lbl_input.Text == "0")
            {
                lbl_input.Text = so;
            }
            else
            {
                lbl_input.Text += so;
            }

        }
        public void Toantu(string dau)
        {
            if (lbl_input.Text.EndsWith("+") || lbl_input.Text.EndsWith("-") || lbl_input.Text.EndsWith("*") || lbl_input.Text.EndsWith("/"))
            {
                String temp = lbl_input.Text;
                temp = temp.Remove(temp.Length - 1, 1);
                lbl_input.Text = temp;
            }
            lbl_input.Text += dau;
        }
        private void btn_0_Click(object sender, EventArgs e)
        {
            lbl_input.Text += "0";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            Nhapso("1");
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            Nhapso("2");

        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            Nhapso("3");
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            Nhapso("4");
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            Nhapso("5");

        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            Nhapso("6");
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            Nhapso("7");

        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            Nhapso("8");
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            Nhapso("9");

        }



        private void btn_xoa_Click(object sender, EventArgs e)

        {
           
            if (lbl_input.Text.Length >= 1)
            {
                lbl_input.Text = lbl_input.Text.Remove(lbl_input.Text.Length - 1, 1);
            }
        }

        private void btn_xoaALL_Click(object sender, EventArgs e)
        {
            lbl_input.Text = "";
            lbl_kq.Text = "";
       

        }

        private void btn_dauphay_Click(object sender, EventArgs e)
        {
            lbl_input.Text = lbl_input.Text + ".";
            
        }

        
        
        private void btn_cong_Click(object sender, EventArgs e)
        {
            Toantu("+");

        }

        private void btn_tru_Click(object sender, EventArgs e)
        {
            Toantu("-");
        }


        private void btn_nhan_Click(object sender, EventArgs e)
        {

            Toantu("*");
        }

        private void btn_chia_Click(object sender, EventArgs e)
        {

            Toantu("/");
        }
       
       
        private void btn_res_Click(object sender, EventArgs e)
        {
           
            if (lbl_input.Text.EndsWith("+") || lbl_input.Text.EndsWith("-") || lbl_input.Text.EndsWith("*")
               || lbl_input.Text.EndsWith("/") || lbl_input.Text.EndsWith("."))
            {
                lbl_kq.Text = "ERROR";
            }
            else if (lbl_input.Text == "")
            {
                lbl_input.Text = "";
            }
            else { 

                
            KetQua = Convert.ToDouble(new DataTable().Compute(lbl_input.Text, null));
            lbl_kq.Text = Convert.ToString(KetQua);

           

            }
            

        }

        private void btn_amduong_Click(object sender, EventArgs e)
        {
            
            lbl_input.Text = kt_amduong();



        }
        // kiểm tra +/-
        private string kt_amduong()
        {
            string s = lbl_input.Text; // gán chuoi 
            // nếu chuoi rỗng và chuoi ==0
            if (s.Length == 0 || s == "0")
            {

                return lbl_input.Text; // không thêm dấu vd  0 thì 0
            }

            // kiểm tra ký tự cuối cùng có phải là 1 trong 4 dấu ko 
            if (s[s.Length - 1] == '-' || s[s.Length - 1] == '+' || s[s.Length - 1] == '*' || s[s.Length - 1] == '/')
            {
                return s; // nếu phải thì ko thay đổi vd : 3+ thì trả về 3+ chứ ko phải là 3+-
            }
            string so = ""; // bến so =""
            int i = 0; // biến i để cắt chuỗi
            for (i = s.Length - 1; i >= 0; i--)
            {
                // nếu kí tự là 1 trong 3 dấu +/* thì trả về - vd 3+5 thì sẽ trả về 3 + -5 
                if (s[i].Equals('+') || s[i].Equals('/') || s[i].Equals('*'))
                {

                    return s.Substring(0, i + 1) + "-" + so; // cái ni trả về nè cắt tự vị trí i vd :  3+5 thì nó cắt từ vị trí 0 là 3 đến + là 2 

                }
                else if (s[i].Equals('-')) // nếu là dấu - thì
                {

                    if (i == 0) // nếu i ==0 là nó là số đầu tiên nên break 
                    {
                        break;
                    }
                    if (i - 1 >= 0) // nếu i -1 >=0 thì chứng tỏ nó ko phải số dầu nên thực hiện

                    {
                        // nếu nó nằm trong 4 dấu thì trả về so vd : 3 + - 5 thì i bây giờ là dấu - i -1 là dấu + nên nó sẽ bỏ dấu - đi
                        if (s[i - 1].Equals('+') || s[i - 1].Equals('/') || s[i - 1].Equals('*') || s[i - 1].Equals('-'))
                        {
                            return s.Substring(0, i) + so;
                        }
                        else
                        {
                            // ngược lại nếu chỉ có 1 dấu - chứng tỏ nó là số dướng nên thêm - vào vd 3 -5 thì nó sẽ là 3--5
                            return s.Substring(0, i + 1) + "-" + so;
                        }
                    }
                }
                so = s[i] + so; // đây là chỗ nó lấy số nè vd 3+ 53 thì nó lấy số 3 sau đó so = 5 +3 ok
            }
            // do i = 0 là t break nên nó sẽ thực hiện dưới ni nếu chuoi[0] == - thì chứ tỏ nó là số âm nên lấy sô thoy
            if (s[0].Equals('-'))
            {
                return so;
            }
            else
            {
                return "-" + so; // ngược lại thì thêm -
            }
        }

        private void btn_chiadu_Click(object sender, EventArgs e)
        {
            if (lbl_input.Text.EndsWith("+") || lbl_input.Text.EndsWith("-") || lbl_input.Text.EndsWith("*")
              || lbl_input.Text.EndsWith("/") || lbl_input.Text.EndsWith("."))
            {
                lbl_kq.Text = "ERROR";
            }
            else
            {
                double t = double.Parse(lbl_kq.Text) / 100;
                lbl_kq.Text = t.ToString();
            }
            
           
        }
        

        
        

    }
}
    