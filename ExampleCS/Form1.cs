using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleCS
{
    public partial class Form1 : Form
    {
        private string connectingString = "provider=Microsoft.Jet.OLEDB.4.0;data source=Database1.mdb";
        private OleDbConnection myConn;
        private int newRowInd = -1;

        public Form1()
        {
            InitializeComponent();
            myConn = new OleDbConnection(connectingString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadTable("Service");
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadTable("Products");
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            LoadTable("ServiseProducts");
        }

        private void LoadTable(string tableName)
        {
            try
            {

                myConn.Open();
                // Очищаем DataGridView перед загрузкой новых данных
                dataGridView1.Columns.Clear();

                // Создаем команду для получения метаданных о столбцах таблицы
                OleDbCommand schemaCommand = myConn.CreateCommand();
                schemaCommand.CommandText = $"SELECT TOP 1 * FROM {tableName}";

                // Используем OleDbDataReader для получения метаданных
                OleDbDataReader reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly);
                DataTable schemaTable = reader.GetSchemaTable();

                // Добавляем столбцы в DataGridView на основе информации о метаданных
                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = row["ColumnName"].ToString();
                    Type dataType = (Type)row["DataType"];
                    dataGridView1.Columns.Add(columnName, columnName);
                    dataGridView1.Columns[columnName].ValueType = dataType; // Устанавливаем тип данных столбца
                }

                // Загружаем данные из таблицы
                OleDbCommand dataCommand = myConn.CreateCommand();
                dataCommand.CommandText = $"SELECT * FROM {tableName}";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dataCommand);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Заполняем DataGridView данными из DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    object[] rowData = row.ItemArray;
                    dataGridView1.Rows.Add(rowData);
                }

                // Отключаем редактирование первого столбца (например, индекс 0)
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке таблицы: " + ex.Message, "Внимание !");
            }
            finally
            {
                myConn.Close();
            }
        }

        private void AddRow()
        {
            int index = GetSelectedRowIndex();
            if (index == -1) return;

            try
            {
                if (!CheckAllDataEntered(index)) return;

                myConn.Open();
                string insertQuery = GenerateInsertQuery(index);

                OleDbCommand myCommand = new OleDbCommand(insertQuery, myConn);

                if (myCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса", "Внимание !");
                }
                else
                {
                    MessageBox.Show("Данные добавлены успешно", "Внимание !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении строки: " + ex.Message, "Внимание !");
            }
            finally
            {
                myConn.Close();
            }
        }

        private void UpdateRow()
        {
            int index = GetSelectedRowIndex();
            if (index == -1) return;

            try
            {
                if (!CheckAllDataEntered(index)) return;

                myConn.Open();
                string updateQuery = GenerateUpdateQuery(index);

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
                MessageBox.Show("Ошибка при обновлении строки: " + ex.Message, "Внимание !");
            }
            finally
            {
                myConn.Close();
                //LoadTable(maskedTextBox1.Text);
            }
        }

        private void DeleteRow()
        {
            int index = GetSelectedRowIndex();
            if (index == -1) return;

            try
            {
                if (!CheckAllDataEntered(index)) return;

                myConn.Open();
                int count = CheckRelatedRecords(index);

                if (count > 0)
                {
                    DialogResult result = MessageBox.Show("Удаление этой записи приведет к удалению связанных записей. Продолжить?", "Предупреждение", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) return;
                }

                string deleteQuery = GenerateDeleteQuery(index);

                OleDbCommand myCommand = new OleDbCommand(deleteQuery, myConn);

                if (myCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса", "Внимание !");
                }
                else
                {
                    MessageBox.Show("Данные успешно удалены", "Внимание !");
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении строки: " + ex.Message, "Внимание !");
            }
            finally
            {
                myConn.Close();
            }
        }

        private int GetSelectedRowIndex()
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберете строку, которую хотите обработать", "Внимание !");
                return -1;
            }

            return dataGridView1.SelectedRows[0].Index;
        }

        private bool CheckAllDataEntered(int rowIndex)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Rows[rowIndex].Cells[i].Value == null)
                {
                    MessageBox.Show("Не все данные введены", "Внимание !");
                    return false;
                }
            }
            return true;
        }

        private int CheckRelatedRecords(int index)
        {
            int count = 0;
            string columnName = maskedTextBox1.Text == "Service" ? "ServiceId" : "ProductId";
            string checkQuery = "SELECT COUNT(*) FROM ServiseProducts WHERE " + columnName + " = " + dataGridView1.Rows[index].Cells[0].Value.ToString();

            OleDbCommand checkCommand = new OleDbCommand(checkQuery, myConn);
            count = (int)checkCommand.ExecuteScalar();

            return count;
        }

        private string GenerateInsertQuery(int index)
        {
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

            return insertQuery;
        }

        private string GenerateUpdateQuery(int index)
        {
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

            if (int.TryParse(dataGridView1.Rows[index].Cells[0].Value.ToString(), out int q))
            {
                updateQuery += " WHERE " + dataGridView1.Columns[0].Name + " = " + q;
            }

            return updateQuery;
        }

        private string GenerateDeleteQuery(int index)
        {
            return "DELETE FROM " + maskedTextBox1.Text + " WHERE " + dataGridView1.Columns[0].Name + "= " + dataGridView1.Rows[index].Cells[0].Value.ToString();
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            //SaveChanges();
        }
/*
        private void SaveChanges()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            if (rowIndex == -1)
            {
                return;
            }

            try
            {
                if (newRowInd != rowIndex)
                {
                    DialogResult result = MessageBox.Show("Сохранить внесённые изменения?", "Предупреждение", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) 
                    {
                        return; 
                    }
                    dataGridView1.Rows[rowIndex].Selected = true;
                    UpdateRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message, "Внимание !");
            }
        }*/

/*        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            newRowInd = dataGridView1.Rows[e.RowIndex].IsNewRow ? e.RowIndex : -1;
        }*/

     /*   private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (row.IsNewRow)
            {
                DialogResult result = MessageBox.Show("Сохранить новую строку?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
                //SaveNewRowData(row);
            }
        }*/

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Type dataType = dataGridView1.Columns[e.ColumnIndex].ValueType;

                string userInput = e.FormattedValue.ToString();

                if (dataType == typeof(int))
                {
                    int parsedValue;
                    if (!int.TryParse(userInput, out parsedValue))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Введите целочисленное значение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dataType == typeof(double))
                {
                    double parsedValue;
                    if (!double.TryParse(userInput, out parsedValue))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Введите число с плавающей точкой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dataType == typeof(DateTime))
                {
                    DateTime parsedDate;
                    if (!DateTime.TryParse(userInput, out parsedDate))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Введите корректную дату и время.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dataType == typeof(bool))
                {
                    bool parsedValue;
                    if (!bool.TryParse(userInput, out parsedValue))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Введите значение true или false.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dataType == typeof(TimeSpan))
                {
                    TimeSpan parsedValue;
                    if (!TimeSpan.TryParse(userInput, out parsedValue))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Введите корректное значение временного интервала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dataType == typeof(byte))
                {
                    byte parsedValue;
                    if (!byte.TryParse(userInput, out parsedValue))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Введите целое число от 0 до 255.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
