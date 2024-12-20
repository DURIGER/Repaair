using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Zuby.ADGV;

namespace ComputerRepairRequests
{
    public partial class ClientForm : Form
    {
        private string userLogin;
        int clientId;
        private DataTable dataTable = new DataTable();
        private BindingSource bindingSource = new BindingSource();
        int rowIndex = -1;
        bool firstload = true;

        public ClientForm(string login)
        {
            InitializeComponent();
            userLogin = login;
            InitializeDataGridView();
            LoadUserData();
            LoadRequestsData();
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
                    u.userId AS ID,
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
                        clientId = Convert.ToInt32(reader["ID"]);
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
                    r.requestid AS ID,
                    ctm.modelName AS Модель,
                    r.problemDescription AS [Описание проблемы],
                    rs.statusDescription AS Статус,
                    r.startDate AS [Дата начала],
                    r.completionDate AS [Дата окончания]
                FROM 
                    requests r
                    INNER JOIN computerTechModel ctm ON r.modelId = ctm.modelId
                    INNER JOIN requestStatus rs ON r.requestStatusId = rs.requestStatusId
                WHERE 
                    r.clientId = (SELECT userId FROM users WHERE userLogin = @userLogin)";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userLogin", userLogin);

                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    bindingSource.DataSource = dataTable;
                    requestsDataGridView.Columns[0].Visible = false;

                    UpdateRowCount();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (firstload == true)
            {
                ButtonColumn();
            }
            firstload = false;
        }

        private void ButtonColumn()
        {
            DataGridViewButtonColumn commentsColumn = new DataGridViewButtonColumn();
            commentsColumn.Name = "Comments";
            commentsColumn.HeaderText = "Комментарии";
            commentsColumn.Text = "Открыть";
            commentsColumn.UseColumnTextForButtonValue = true;

            requestsDataGridView.Columns.Add(commentsColumn);
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

        private void buttonEditRequest_Click(object sender, EventArgs e)
        {
            if (rowIndex > -1)
            {
                int requestId = Convert.ToInt32(dataTable.Rows[rowIndex][0]);

                string statusDescription = string.Empty;
                string query = @"
            SELECT rs.statusDescription 
            FROM requests r
            INNER JOIN requestStatus rs ON r.requestStatusId = rs.requestStatusId
            WHERE r.requestId = @requestId";

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
                            statusDescription = reader["statusDescription"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при получении статуса заявки: " + ex.Message,
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (statusDescription != "Новая заявка")
                {
                    MessageBox.Show("Редактирование заявки возможно только при статусе 'Новая заявка'.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EditClientRequestForm edit = new EditClientRequestForm(requestId);
                edit.ShowDialog();

                LoadRequestsData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для редактирования.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.Show();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void requestsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            СreateClientRequestForm create = new СreateClientRequestForm(clientId);
            create.ShowDialog();

            LoadRequestsData();
        }

        private void requestsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == requestsDataGridView.Columns["Comments"].Index)
            {
                int index = (int)requestsDataGridView.Rows[e.RowIndex].Index;
                int requestId = Convert.ToInt32(dataTable.Rows[index][0]);

                ViewCommentsForm view = new ViewCommentsForm(requestId);
                view.ShowDialog();
            }
        }

        private void buttonQrCode_Click(object sender, EventArgs e)
        {
            QrCodeForm qrCodeForm = new QrCodeForm();
            qrCodeForm.ShowDialog();
        }
    }
}
