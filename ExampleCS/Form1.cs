using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ExampleCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберете строку,которую хотите добвить", "Внимание !");
            }
            else
            {
                int index = dataGridView1.SelectedRows[0].Index;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Rows[index].Cells[i].Value == null)
                    {

                        MessageBox.Show("Не все данные введены", "Внимание !");
                        return;
                    }
                }



                string connectingString = "provider=Microsoft.Jet.OLEDB.4.0;data source=Database1.mdb";
                OleDbConnection myConn = new OleDbConnection(connectingString);
                //Сформировать строку запросов


                try { 
                    myConn.Open();


                    string insertQuery = "INSERT INTO " + maskedTextBox1.Text + " VALUES (";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {

                        if (int.TryParse(dataGridView1.Rows[index].Cells[i].Value.ToString(), out int o))
                        {
                            insertQuery += o;

                        }
                        else
                        {
                            insertQuery += "'" + dataGridView1.Rows[index].Cells[i].Value.ToString() + "'";

                        }

                        if (i < dataGridView1.Columns.Count - 1)
                            insertQuery += ", ";
                    }
                    insertQuery += ")";


                    OleDbCommand myCommand = new OleDbCommand(insertQuery, myConn);

                    if (myCommand.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("Ошибка выполнения запроса", "Внимание !");
                    }
                    else
                    {
                        MessageBox.Show("Данные Добавлены Успешно", "Внимание !");
                    }
            
                }catch (Exception ex) {   
                     MessageBox.Show("Ошибка при вставке в базу данных: " + ex.Message, "Внимание !");
                }
                finally
                {
                    myConn.Close();
                }

            }
        }

        private int selectedRowIndex; // Поле для сохранения индекса выбранной строки
        private int selectedColumnIndex; // Поле для сохранения индекса выбранного столбца

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Сохраняем индексы выбранной ячейки при каждом клике на ячейку
            selectedRowIndex = e.RowIndex;
            selectedColumnIndex = e.ColumnIndex;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите строку которую хотите обновить", "Внимание !");
            }
            else
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                if (columnIndex == 0)
                {
                    MessageBox.Show("Нельзя изменить первое поле", "Внимание !");
                    return;
                }

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Rows[index].Cells[i].Value == null)
                    {
                        MessageBox.Show("Не все данные введены", "Внимание !");
                        return;
                    }
                }

                string connectingString = "provider=Microsoft.Jet.OLEDB.4.0;data source=Database1.mdb";
                OleDbConnection myConn = new OleDbConnection(connectingString);

                try
                {
                    myConn.Open();

                    string updateQuery = "UPDATE " + maskedTextBox1.Text + " SET ";

                    for (int i = 1; i < dataGridView1.Columns.Count; i++)
                    {
                        string columnName = dataGridView1.Columns[i].Name;

                        if (int.TryParse(dataGridView1.Rows[index].Cells[i].Value.ToString(), out int o))
                        {
                            updateQuery += columnName + " = " + o;
                        }
                        else
                        {
                            updateQuery += columnName + " = '" + dataGridView1.Rows[index].Cells[i].Value.ToString() + "'";
                        }

                        if (i < dataGridView1.Columns.Count - 1)
                            updateQuery += ", ";
                    }

                    updateQuery += " WHERE " + dataGridView1.Columns[0].Name +" = " + (index+1);

                    OleDbCommand myCommand = new OleDbCommand(updateQuery, myConn);

                    if (myCommand.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("Ошибка выполнения запроса", "Внимание !");
                    }
                    else
                    {
                        MessageBox.Show("Данные обновлены успешно", "Внимание !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении базы данных: " + ex.Message, "Внимание !");
                }
                finally
                {
                    myConn.Close();
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберете строку которую хотите удалить", "Внимание !");
            }
            else
            {
                int index = dataGridView1.SelectedRows[0].Index;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Rows[index].Cells[i].Value == null)
                    {

                        MessageBox.Show("Не все данные введены", "Внимание !");
                        return;
                    }
                }



                string connectingString = "provider=Microsoft.Jet.OLEDB.4.0;data source=Database1.mdb";
                OleDbConnection myConn = new OleDbConnection(connectingString);
                //Сформировать строку запросов


                try
                {
                    myConn.Open();
                    int count = 0;
                    if (maskedTextBox1.Text == "Service") {
                        string checkQuery = "SELECT COUNT(*) FROM ServiseProducts WHERE ServiceId = " + dataGridView1.Rows[index].Cells[0].Value.ToString();
                        OleDbCommand checkCommand = new OleDbCommand(checkQuery, myConn);
                        count = (int)checkCommand.ExecuteScalar();
                    }
                    else if(maskedTextBox1.Text == "Products") {
                        string checkQuery = "SELECT COUNT(*) FROM ServiseProducts WHERE  ProductId = " + dataGridView1.Rows[index].Cells[0].Value.ToString();
                        OleDbCommand checkCommand = new OleDbCommand(checkQuery, myConn);
                        count = (int)checkCommand.ExecuteScalar();
                    }
                    // Проверить наличие связанных записей
                    

                    if (count > 0)
                    {
                        // Предупредить пользователя о наличии связанных записей
                        DialogResult result = MessageBox.Show("Удаление этой записи приведет к удалению связанных записей. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            // Пользователь отказался от каскадного удаления
                            return;
                        }else if(result == DialogResult.Yes)
                        {
                            string Query = "DELETE FROM " + maskedTextBox1.Text + " WHERE " + dataGridView1.Columns[0].Name + "= " + dataGridView1.Rows[index].Cells[0].Value.ToString();
                            OleDbCommand myCommand = new OleDbCommand(Query, myConn);
                            if (myCommand.ExecuteNonQuery() != 1)
                            {
                                MessageBox.Show("Ошибка выполнения запроса", "Внимание !");
                            }
                            else
                            {
                                MessageBox.Show("Данные Успешно Удалены", "Внимание !");
                                dataGridView1.Rows.RemoveAt(index);
                            }

                        }
                    }
                    else
                    {
                        string Query = "DELETE FROM " + maskedTextBox1.Text + " WHERE " + dataGridView1.Columns[0].Name + "= " + dataGridView1.Rows[index].Cells[0].Value.ToString();
                        OleDbCommand myCommand = new OleDbCommand(Query, myConn);
                        if (myCommand.ExecuteNonQuery() != 1)
                        {
                            MessageBox.Show("Ошибка выполнения запроса", "Внимание !");
                        }
                        else
                        {
                            MessageBox.Show("Данные Успешно Удалены", "Внимание !");
                            dataGridView1.Rows.RemoveAt(index);
                        }
                    }




                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при вставке в базу данных: " + ex.Message, "Внимание !");
                }
                finally
                {
                    myConn.Close();
                }

            }


        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выбратьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void перваяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectingString = "provider=Microsoft.Jet.OLEDB.4.0;data source=Database1.mdb";
            OleDbConnection myConn = new OleDbConnection(connectingString);
            try
            {
               
                //Сформировать строку запросов
                string selectString = "Select * from Service";
                OleDbCommand myCommand = myConn.CreateCommand();
                myCommand.CommandText = selectString;
                OleDbDataAdapter oda = new OleDbDataAdapter();
                oda.SelectCommand = myCommand;
                DataSet myDataset = new DataSet();
                myConn.Open();
                string dataTableName = "CompanyA";
                oda.Fill(myDataset, dataTableName);
                DataTable myDataTable = myDataset.Tables[dataTableName];
                if (dataGridView1.Columns.Count > 0 && maskedTextBox1.Text != null)
                {
                    // Если есть, удаляем все столбцы
                    dataGridView1.Columns.Clear();
                    maskedTextBox1.Clear();
                    foreach (DataColumn cl in myDataTable.Columns)
                    {
                        string columnName = cl.ColumnName;
                        dataGridView1.Columns.Add(columnName, columnName);
                        maskedTextBox1.Text = "Service";
                    }
                }
                else
                {
                    foreach (DataColumn cl in myDataTable.Columns)
                    {
                        string columnName = cl.ColumnName;
                        dataGridView1.Columns.Add(columnName, columnName);
                        maskedTextBox1.Text = "Service";
                    }
                }

                foreach (DataRow row in myDataTable.Rows)
                {
                    // Создаем массив объектов для хранения значений ячеек строки
                    object[] rowData = new object[myDataTable.Columns.Count];

                    // Заполняем массив значениями ячеек строки
                    for (int i = 0; i < myDataTable.Columns.Count; i++)
                    {
                        rowData[i] = row[i];
                    }

                    // Добавляем новую строку в DataGridView и заполняем ее данными
                    dataGridView1.Rows.Add(rowData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вставке в базу данных: " + ex.Message, "Внимание !");
            }
            finally
            {
                myConn.Close();
            }

        }

        


        private void втораяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectingString = "provider=Microsoft.Jet.OLEDB.4.0;data source=Database1.mdb";
            OleDbConnection myConn = new OleDbConnection(connectingString);
            try
            {

                //Сформировать строку запросов
                string selectString = "Select * from Products";
                OleDbCommand myCommand = myConn.CreateCommand();
                myCommand.CommandText = selectString;
                OleDbDataAdapter oda = new OleDbDataAdapter();
                oda.SelectCommand = myCommand;
                DataSet myDataset = new DataSet();
                myConn.Open();
                string dataTableName = "CompanyA";
                oda.Fill(myDataset, dataTableName);
                DataTable myDataTable = myDataset.Tables[dataTableName];
                if (dataGridView1.Columns.Count > 0 && maskedTextBox1.Text != null)
                {
                    // Если есть, удаляем все столбцы
                    dataGridView1.Columns.Clear();
                    maskedTextBox1.Clear();
                    foreach (DataColumn cl in myDataTable.Columns)
                    {
                        string columnName = cl.ColumnName;
                        dataGridView1.Columns.Add(columnName, columnName);
                        maskedTextBox1.Text = "Products";
                    }
                }
                else
                {
                    foreach (DataColumn cl in myDataTable.Columns)
                    {
                        string columnName = cl.ColumnName;
                        dataGridView1.Columns.Add(columnName, columnName);
                        maskedTextBox1.Text = "Products";
                    }
                }

                foreach (DataRow row in myDataTable.Rows)
                {
                    // Создаем массив объектов для хранения значений ячеек строки
                    object[] rowData = new object[myDataTable.Columns.Count];

                    // Заполняем массив значениями ячеек строки
                    for (int i = 0; i < myDataTable.Columns.Count; i++)
                    {
                        rowData[i] = row[i];
                    }

                    // Добавляем новую строку в DataGridView и заполняем ее данными
                    dataGridView1.Rows.Add(rowData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вставке в базу данных: " + ex.Message, "Внимание !");
            }
            finally
            {
                myConn.Close();
            }
        }

        

        private void третьяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectingString = "provider=Microsoft.Jet.OLEDB.4.0;data source=Database1.mdb";
            OleDbConnection myConn = new OleDbConnection(connectingString);
            try
            {

                //Сформировать строку запросов
                string selectString = "Select * from ServiseProducts";
                OleDbCommand myCommand = myConn.CreateCommand();
                myCommand.CommandText = selectString;
                OleDbDataAdapter oda = new OleDbDataAdapter();
                oda.SelectCommand = myCommand;
                DataSet myDataset = new DataSet();
                myConn.Open();
                string dataTableName = "CompanyA";
                oda.Fill(myDataset, dataTableName);
                DataTable myDataTable = myDataset.Tables[dataTableName];
                if (dataGridView1.Columns.Count > 0 && maskedTextBox1.Text != null)
                {
                    // Если есть, удаляем все столбцы
                    dataGridView1.Columns.Clear();
                    maskedTextBox1.Clear();
                    foreach (DataColumn cl in myDataTable.Columns)
                    {
                        string columnName = cl.ColumnName;
                        dataGridView1.Columns.Add(columnName, columnName);
                        maskedTextBox1.Text = "ServiseProducts";
                    }
                }
                else
                {
                    foreach (DataColumn cl in myDataTable.Columns)
                    {
                        string columnName = cl.ColumnName;
                        dataGridView1.Columns.Add(columnName, columnName);
                        maskedTextBox1.Text = "ServiseProducts";
                    }
                }

                foreach (DataRow row in myDataTable.Rows)
                {
                    // Создаем массив объектов для хранения значений ячеек строки
                    object[] rowData = new object[myDataTable.Columns.Count];

                    // Заполняем массив значениями ячеек строки
                    for (int i = 0; i < myDataTable.Columns.Count; i++)
                    {
                        rowData[i] = row[i];
                    }

                    // Добавляем новую строку в DataGridView и заполняем ее данными
                    dataGridView1.Rows.Add(rowData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вставке в базу данных: " + ex.Message, "Внимание !");
            }
            finally
            {
                myConn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
