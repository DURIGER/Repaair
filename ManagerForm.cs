using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Zuby.ADGV;
using static ComputerRepairRequests.TimeCalculation;

namespace ComputerRepairRequests
{
    public partial class ManagerForm : Form
    {
        private string userLogin;
        private DataTable dataTable = new DataTable();
        private BindingSource bindingSource = new BindingSource();
        int rowIndex = -1;

        public ManagerForm(string login)
        {
            InitializeComponent();
            userLogin = login;
            InitializeDataGridView();
            LoadUserData();
            LoadRequestsData();
            AverageTime();
        }

        public void AverageTime()
        {
            TimeCalculation rep = new TimeCalculation();
            labelAverageTime.Text = rep.CalculateAverageCompletionTime().ToString() + " дней";
        }
        public void SetFilteredData(DataTable filteredRows)
        {
            bindingSource.DataSource = filteredRows;
            bindingSource.ResetBindings(false);
            UpdateRowCount();
        }

        private void InitializeDataGridView()
        {
            requestsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            requestsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            requestsDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in requestsDataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            requestsDataGridView.ReadOnly = true;
            requestsDataGridView.AllowUserToAddRows = false;
            requestsDataGridView.RowHeadersVisible = false;
            requestsDataGridView.AllowUserToResizeColumns = false;

            requestsDataGridView.DataSource = bindingSource;

            ((AdvancedDataGridView)requestsDataGridView).FilterStringChanged += AdvancedDataGridView_FilterStringChanged;
        }

        private void LoadUserData()
        {
            string query = @"
                SELECT 
                    u.firstName + ' ' + u.lastName AS FullName, 
                    ut.userTypeName 
                FROM 
                    users u
                    INNER JOIN userTypes ut ON u.userTypeId = ut.userTypeId
                WHERE 
                    u.userLogin = @userLogin";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userLogin", userLogin);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        labelFullName.Text = reader["FullName"].ToString();
                        labelUserType.Text = reader["userTypeName"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных пользователя: " + ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRequestsData()
        {
            dataTable.Clear();
            string query = @"
                SELECT
                    r.clientId AS ClID,
                    r.requestId AS ID,
                    ctm.modelName AS Модель,
                    r.problemDescription AS [Описание проблемы],
                    rs.statusDescription AS Статус,
                    r.startDate AS [Дата начала],
                    r.completionDate AS [Дата окончания],
                    t.firstName + ' ' + t.lastName + ' ' + t.patronymic AS Техник
                FROM 
                    requests r
                    INNER JOIN computerTechModel ctm ON r.modelId = ctm.modelId
                    INNER JOIN requestStatus rs ON r.requestStatusId = rs.requestStatusId
                    LEFT JOIN users t ON r.masterId = t.userId
                WHERE 
                    r.clientId IS NOT NULL";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    bindingSource.DataSource = dataTable;
                    requestsDataGridView.Columns[0].Visible = false;
                    requestsDataGridView.Columns[1].Visible = false;

                    UpdateRowCount();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateRowCount()
        {
            int filteredRowCount = bindingSource.Count;
            int totalRowCount = dataTable.Rows.Count;
            labelCount.Text = $"Отображено строк: {filteredRowCount}/{totalRowCount}";
        }

        private void AdvancedDataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            string filterString = ((AdvancedDataGridView)requestsDataGridView).FilterString;
            bindingSource.Filter = filterString;
            UpdateRowCount();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.Show();
        }

        private void OperatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void requestsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
            }
            else
            {
                rowIndex = -1;
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (rowIndex > -1)
            {
                int requestId = Convert.ToInt32(dataTable.Rows[rowIndex][1]);

                RegistrationOperatorForm registrationForm = new RegistrationOperatorForm(requestId);
                registrationForm.ShowDialog();

                LoadRequestsData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для регистрации и изменения.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OperatorForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
