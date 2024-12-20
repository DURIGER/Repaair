using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zuby.ADGV;

namespace ComputerRepairRequests
{
    public partial class TechnicianForm : Form
    {
        private string userLogin;
        private DataTable dataTable = new DataTable();
        private BindingSource bindingSource = new BindingSource();
        bool firstLoad = true;
        int rowIndex = -1;

        public TechnicianForm(string login)
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
                    ShowMessage("Ошибка при загрузке данных пользователя: " + ex.Message);
                }
            }
        }

        private void LoadRequestsData()
        {
            dataTable.Clear();
            string query = @"
                SELECT 
                    r.requestId AS [Номер заявки],
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
                    r.masterId = (SELECT userId FROM users WHERE userLogin = @userLogin)";

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

                    UpdateRowCount();
                }
                catch (Exception ex)
                {
                    ShowMessage("Ошибка при загрузке данных: " + ex.Message);
                }
            }

            if (firstLoad == true)
            {
                ButtonColumn();
            }
            firstLoad = false;
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.Show();
        }

        private void requestsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == requestsDataGridView.Columns["Comments"].Index)
            {
                int index = (int)requestsDataGridView.Rows[e.RowIndex].Index;
                int requestId = Convert.ToInt32(dataTable.Rows[index][0]);

                CreateCommentsForm view = new CreateCommentsForm(requestId);
                view.Show();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (rowIndex > -1)
            {
                int requestId = Convert.ToInt32(dataTable.Rows[rowIndex][0]);

                EditTechnicianRequestForm edit = new EditTechnicianRequestForm(requestId);
                edit.ShowDialog();

                LoadRequestsData();
            }
            else
            {
                ShowMessage("Пожалуйста, выберите заявку для редактирования.");
            }
        }

        private void requestsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void TechnicianForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
