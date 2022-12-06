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
using System.Net;

namespace Ex4
{
    public partial class Exx4 : Form
    {
        Connect connect = new Connect("server=chuc.caseum.ru;port=33333;username=st_2_20_20;password=92457063;database=is_2_20_st20_KURS");
        MySqlConnection conn;
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable DT = new DataTable();
        BindingSource BindingS = new BindingSource();
        public void Abonimets1()
        {
            DT.Clear();
            string table = "SELECT t_datatime.id AS `Код`, t_datatime.fio AS `ФИО`, t_datatime.data_of_Birth `Дата рождения`, t_datatime.photoUrl AS `Ссылка на фото` FROM `t_datatime`";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(table, conn);
            MyDA.Fill(DT);
            BindingS.DataSource = DT;
            dataGridView1.DataSource = BindingS;
            conn.Close();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;




            dataGridView1.Columns[0].FillWeight = 15;
            dataGridView1.Columns[1].FillWeight = 15;
            dataGridView1.Columns[2].FillWeight = 15;
            dataGridView1.Columns[3].FillWeight = 15;



            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;



            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
        }
        void Image(string a)
        {
            var rec = WebRequest.Create(a);
            using (var res = rec.GetResponse())
            using (var stream = res.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
        }

        public Exx4()
        {
            InitializeComponent();
        }

        private void Exx4_Load(object sender, EventArgs e)
        {
            conn = connect.Conn();
            Abonimets1();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                conn.Open();
                //Запрос на выборку ссылки изображения из бд
                string sql = "SELECT t_datatime.photoUrl AS 'Фото' FROM t_datatime WHERE t_datatime.id =" + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                string pic = cmd.ExecuteScalar().ToString();
                //Отправляем ссылку фото на обработку в метод
                Image(pic);
                MySqlDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
