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
using ConnectDB;
using static ConnectDB.Class1;

namespace Ex5
{
    public partial class Form1 : Form
    {
        Connect connect = new Connect("server=chuc.caseum.ru;port=33333;username=st_2_20_20;password=92457063;database=is_2_20_st20_KURS");
        MySqlConnection conn;
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable DT = new DataTable();
        BindingSource BindingS = new BindingSource();
        public void Abonimets1()
        {
            DT.Clear();
            string table = "SELECT t_Uchebka_Romodanov.idStud AS `Код`, t_Uchebka_Romodanov.fioStud AS `ФИО`, t_Uchebka_Romodanov.datetimeStud `Дата рождения` FROM `t_Uchebka_Romodanov`";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(table, conn);
            MyDA.Fill(DT);
            BindingS.DataSource = DT;
            dataGridView1.DataSource = BindingS;
            conn.Close();

            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;





            dataGridView1.Columns[0].FillWeight = 15;
            dataGridView1.Columns[1].FillWeight = 15;
            dataGridView1.Columns[2].FillWeight = 15;





            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;




            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = connect.Conn();
            Abonimets1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string fio = textBox1.Text;
                string datetime = textBox2.Text;
                string sql = "INSERT INTO `t_Uchebka_Romodanov`(fioStud, datetimeStud) VALUES (@a, @b)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@a", MySqlDbType.VarChar).Value = fio;
                cmd.Parameters.Add("@b", MySqlDbType.VarChar).Value = datetime;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Пользователь записан");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                Abonimets1();
            }
        }
    }
}
