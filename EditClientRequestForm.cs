using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class EditClientRequestForm : Form
    {
        public int requestId;
        string problemDescription;
        int SelectedIndex;
        string currentStatus;

        public EditClientRequestForm(int reqId)
        {
            InitializeComponent();
            requestId = reqId;
            LoadRequestData();
            LoadModelComboBox();
        }

        private void LoadRequestData()
        {
            string query = @"
                SELECT 
                    r.startDate, 
                    r.problemDescription, 
                    rs.statusDescription AS StatusDescription,
                    r.modelId
                FROM 
                    requests r
                INNER JOIN requestStatus rs ON r.requestStatusId = rs.requestStatusId
                WHERE 
                    r.requestId = @requestId";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@requestId", requestId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        labelStartDate.Text = reader["startDate"].ToString().Remove(10);
                        textBoxProblemDescription.Text = reader["problemDescription"].ToString();
                        labelStatus.Text = reader["StatusDescription"].ToString();

                        problemDescription = textBoxProblemDescription.Text;
                        SelectedIndex = Convert.ToInt32(reader["modelId"]) - 1;

                        currentStatus = reader["StatusDescription"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных заявки: " + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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
                comboBoxModel.SelectedIndex = SelectedIndex;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string newProblemDescription = textBoxProblemDescription.Text;

            if (newProblemDescription.Length > 512)
            {
                MessageBox.Show("Описание проблемы не может содержать более 512 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedModelId = (int)comboBoxModel.SelectedValue;
            problemDescription = newProblemDescription;

            string updateQuery = @"
                UPDATE requests
                SET 
                    problemDescription = @problemDescription,
                    modelId = @modelId
                WHERE requestId = @requestId";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@problemDescription", problemDescription);
                    command.Parameters.AddWithValue("@modelId", selectedModelId);
                    command.Parameters.AddWithValue("@requestId", requestId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заявка успешно обновлена.",
                            "Информация",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить заявку.",
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
