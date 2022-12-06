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
using static Ex3.Program;

namespace Ex3
{
    public partial class Exx3 : Form
    {
        public Exx3()
        {
            InitializeComponent();

        }
        Connect connect = new Connect("server=chuc.caseum.ru;port=33333;username=st_2_20_20;password=92457063;database=is_2_20_st20_KURS");
        MySqlConnection conn;
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable DT = new DataTable();
        BindingSource BindingS = new BindingSource();
        public void Abonimets1()
        {
            DT.Clear();
            string table = "SELECT Abonimets.id_aboniments AS `id`, Abonimets.type_of_training AS `Вид тренировки`, Abonimets.type_of_service AS `Вид занятия`, Abonimets.price AS `Цена` FROM Abonimets";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(table, conn);
            MyDA.Fill(DT);
            BindingS.DataSource = DT;
            dataGridView1.DataSource = BindingS;
            conn.Close();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
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


            private void Exx3_Load(object sender, EventArgs e)
         {
             conn = connect.Conn();
             Abonimets1();
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            conn.Open();
            string info1 = "";  
            string info2 = "";
            string info3 = "";
            string info4 = "";
            string sql = $"SELECT Abonimets.id_aboniments AS `id`, Abonimets.type_of_training AS `Вид тренировки`, Abonimets.type_of_service AS `Вид занятия`, Abonimets.price AS `Цена` FROM Abonimets WHERE Abonimets.id_aboniments = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                info1 = reader[0].ToString();
                info2 = reader[1].ToString();
                info3 = reader[2].ToString();
                info4 = reader[3].ToString();
            }
            reader.Close();
            MessageBox.Show("id:" + info1 + "Вид тренировки:" + info2 + "Вид занятия:" + info3 + "Цена:" + info4);
            conn.Close();
        }


    }
}
