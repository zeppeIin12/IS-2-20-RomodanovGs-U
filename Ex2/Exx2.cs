using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ex2
{
    public class Connect
    {
        public static MySqlConnection GetConnection(MySqlConnection mySql)
        {
            try
            {
                MessageBox.Show("Подключение");
                return mySql;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
                return null;
            }
        }
    }
    public partial class Exx2 : Form
    {
        public Exx2()
        {
            InitializeComponent();
        }
        private void Second_Load(object sender, EventArgs e)
        {
            string connStr = "server=chuc.caseum.ru;port=33333;username=uchebka;password=uchebka;database=uchebka";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Connect.GetConnection(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
    }
}
