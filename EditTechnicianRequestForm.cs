using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class EditTechnicianRequestForm : Form
    {
        public int requestId;

        public EditTechnicianRequestForm(int reqId)
        {
            InitializeComponent();
            InitializeDataGridView();
            requestId = reqId;
            LoadRepairParts();
        }

        private void LoadRepairParts()
        {
            string query = @"
                SELECT partId AS [Номер детали], partName AS [Название], quantity AS [Количество]
                FROM repairParts
                WHERE requestId = @requestId
                ORDER BY partId";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@requestId", requestId);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    repairPartsDataGridView.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке деталей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeDataGridView()
        {
            repairPartsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            repairPartsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            repairPartsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in repairPartsDataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            repairPartsDataGridView.ReadOnly = true;
            repairPartsDataGridView.AllowUserToAddRows = false;
            repairPartsDataGridView.RowHeadersVisible = false;
            repairPartsDataGridView.AllowUserToResizeColumns = false;
        }

        private void AddRepairPart(string partName, int quantity)
        {
            string query = @"
                INSERT INTO repairParts (partName, quantity, requestId)
                VALUES (@partName, @quantity, @requestId)";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@partName", partName);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@requestId", requestId);

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadRepairParts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении детали: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddPart_Click(object sender, EventArgs e)
        {
            string partName = textBoxPartName.Text.Trim();
            int quantity;

            if (string.IsNullOrEmpty(partName))
            {
                MessageBox.Show("Пожалуйста, введите название детали.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное количество.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddRepairPart(partName, quantity);

            textBoxPartName.Clear();
            textBoxQuantity.Clear();
        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            string updateRequestQuery = @"
        UPDATE requests
        SET requestStatusId = 3, 
            completionDate = @completionDate
        WHERE requestId = @requestId";

            DateTime currentDate = DateTime.Now.Date;

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand(updateRequestQuery, connection);
                    updateCommand.Parameters.AddWithValue("@requestId", requestId);
                    updateCommand.Parameters.AddWithValue("@completionDate", currentDate);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Ошибка при обновлении статуса заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string startDateQuery = @"
                SELECT startDate
                FROM requests
                WHERE requestId = @requestId";

                    DateTime startDate = DateTime.MinValue;

                    SqlCommand startDateCommand = new SqlCommand(startDateQuery, connection);
                    startDateCommand.Parameters.AddWithValue("@requestId", requestId);

                    using (SqlDataReader reader = startDateCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            startDate = reader.GetDateTime(0);
                        }
                    }

                    int daysTaken = (currentDate - startDate).Days;

                    string partsQuery = @"
                SELECT partName, quantity
                FROM repairParts
                WHERE requestId = @requestId";

                    SqlCommand partsCommand = new SqlCommand(partsQuery, connection);
                    partsCommand.Parameters.AddWithValue("@requestId", requestId);

                    string partsInfo = "";
                    using (SqlDataReader partsReader = partsCommand.ExecuteReader())
                    {
                        while (partsReader.Read())
                        {
                            string partName = partsReader.GetString(0);
                            int quantity = partsReader.GetInt32(1);
                            partsInfo += $"{partName} - {quantity}\n";
                        }
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        using (StreamWriter file = new StreamWriter(filePath))
                        {
                            file.WriteLine($"Заявка завершена: {currentDate.ToShortDateString()}");
                            file.WriteLine($"Количество дней выполнения: {daysTaken} дней");
                            file.WriteLine("Использованные детали:");
                            file.WriteLine(partsInfo);
                        }

                        MessageBox.Show($"Заявка завершена. Информация записана в файл {filePath}.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не выбран путь для сохранения файла.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при завершении заявки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
