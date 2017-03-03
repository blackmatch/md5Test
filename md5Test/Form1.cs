using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;

namespace md5Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cryptBtn_Click(object sender, EventArgs e)
        {
            string str = inputTextBox.Text;
            if (str.Length < 1)
            {
                MessageBox.Show("请先输入需要加密的字符串");
                return;
            }

            int bits = radioButton32.Checked ? 32 : 16;
            string type = radioButtonLow.Checked ? "low" : "up";
            resultLabel.Text = md5Crypt(str, bits, type);
        }

        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="bits"></param> 32或者16
        /// <param name="type"></param> low表示小写，up表示大写
        /// <returns></returns>
        public static string md5Crypt(string str, int bits, string type)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] buffer = Encoding.Default.GetBytes(str);
            byte[] encryptedBuffer = md5.ComputeHash(buffer);
            string temStr = "";
            string paramStr = "x2";
            if (type == "up")
            {
                paramStr = "X2";
            }
            for (int i = 0; i < encryptedBuffer.Length; i++)
            {
                temStr += encryptedBuffer[i].ToString(paramStr);
            }

            if (bits == 16)
            {
                temStr = temStr.Substring(8, 16);
            }
            return temStr;
        }
    }
}
