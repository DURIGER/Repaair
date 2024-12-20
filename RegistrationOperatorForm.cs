using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class RegistrationOperatorForm : Form
    {
        public int requestId;
        string problemDescription;
        int SelectedIndex;
        string currentStatus;

        public RegistrationOperatorForm(int reqId)
        {
            InitializeComponent();
            requestId = reqId;
            LoadMasterComboBox();
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
            r.modelId,
            r.completionDate,
            r.masterId
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

                        if (reader["completionDate"] != DBNull.Value)
                        {
                            dateTimePickerCompletionDate.Value = Convert.ToDateTime(reader["completionDate"]);
                        }

                        if (reader["masterId"] != DBNull.Value)
                        {
                            int masterId = Convert.ToInt32(reader["masterId"]);
                            comboBoxMaster.SelectedValue = masterId;
                        }
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

        private void LoadMasterComboBox()
        {
            string query = @"
        SELECT 
            u.userId, 
            u.firstName + ' ' + u.lastName + ' ' + u.patronymic AS FullName
        FROM 
            users u
        INNER JOIN userTypes ut ON u.userTypeId = ut.userTypeId
        WHERE 
            ut.userTypeName = N'Техник'";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable masterTable = new DataTable();
                dataAdapter.Fill(masterTable);

                DataRow defaultRow = masterTable.NewRow();
                defaultRow["userId"] = DBNull.Value;
                defaultRow["FullName"] = "Отсутствует";
                masterTable.Rows.InsertAt(defaultRow, 0);

                comboBoxMaster.DataSource = masterTable;
                comboBoxMaster.DisplayMember = "FullName";
                comboBoxMaster.ValueMember = "userId";

                
                comboBoxMaster.SelectedIndex = 0;
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

            int? selectedMasterId = null;
            if (comboBoxMaster.SelectedValue != DBNull.Value)
            {
                selectedMasterId = (int)comboBoxMaster.SelectedValue;
            }

            int selectedStatusId = selectedMasterId.HasValue ? 2 : 1;

            if (dateTimePickerCompletionDate.Value < DateTime.Parse(labelStartDate.Text))
            {
                MessageBox.Show("Дата завершения не может быть раньше даты начала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updateQuery = @"
    UPDATE requests
    SET 
        problemDescription = @problemDescription,
        modelId = @modelId,
        masterId = @masterId,
        requestStatusId = @statusId,
        completionDate = @completionDate
    WHERE requestId = @requestId";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@problemDescription", problemDescription);
                    command.Parameters.AddWithValue("@modelId", selectedModelId);
                    command.Parameters.AddWithValue("@masterId", (object)selectedMasterId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@statusId", selectedStatusId);
                    command.Parameters.AddWithValue("@completionDate", dateTimePickerCompletionDate.Value);
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
