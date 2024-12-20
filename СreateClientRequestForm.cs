using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class СreateClientRequestForm : Form
    {
        public int clientId;

        public СreateClientRequestForm(int ClId)
        {
            InitializeComponent();
            clientId = ClId;
            LoadModelComboBox();
        }

        private void LoadModelComboBox()
        {
            string query = @"SELECT modelId, modelName FROM computerTechModel";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable modelTable = new DataTable();
                dataAdapter.Fill(modelTable);

                comboBoxModel.DataSource = modelTable;
                comboBoxModel.DisplayMember = "modelName";
                comboBoxModel.ValueMember = "modelId";
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string problemDescription = textBoxProblemDescription.Text;

            if (problemDescription.Length > 512)
            {
                MessageBox.Show("Описание проблемы не может содержать более 512 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedModelId = (int)comboBoxModel.SelectedValue;
            DateTime startDate = DateTime.Now.Date;
            int requestStatusId = 1;
            int? masterId = null;
            DateTime? completionDate = null;

            string insertQuery = @"
            INSERT INTO requests 
            (startDate, modelId, problemDescription, requestStatusId, clientId, masterId, completionDate)
            VALUES 
            (@startDate, @modelId, @problemDescription, @requestStatusId, @clientId, @masterId, @completionDate)";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@modelId", selectedModelId);
                    command.Parameters.AddWithValue("@problemDescription", problemDescription);
                    command.Parameters.AddWithValue("@requestStatusId", requestStatusId);
                    command.Parameters.AddWithValue("@clientId", clientId);
                    command.Parameters.AddWithValue("@masterId", (object)masterId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@completionDate", (object)completionDate ?? DBNull.Value);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заявка успешно создана.",
                            "Информация",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось создать заявку.",
                            "Предупреждение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении данных: " + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
