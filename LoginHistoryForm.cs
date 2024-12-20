using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class LoginHistoryForm : Form
    {
        public LoginHistoryForm()
        {
            InitializeComponent();
            LoadLogins();
            LoadLoginHistory();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewLoginHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLoginHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewLoginHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in dataGridViewLoginHistory.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridViewLoginHistory.ReadOnly = true;
            dataGridViewLoginHistory.AllowUserToAddRows = false;
            dataGridViewLoginHistory.RowHeadersVisible = false;
            dataGridViewLoginHistory.AllowUserToResizeColumns = false;
        }

        private void LoadLogins()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    string query = "SELECT userLogin FROM users";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    var logins = new List<string>();

                    while (reader.Read())
                    {
                        logins.Add(reader["userLogin"].ToString());
                    }

                    var sortedLogins = logins.OrderBy(login =>
                    {
                        var match = System.Text.RegularExpressions.Regex.Match(login, @"\d+");
                        return match.Success ? int.Parse(match.Value) : 0;
                    }).ToList();

                    comboBoxLogin.Items.Clear();
                    comboBoxLogin.Items.Add("Нет фильтра");
                    comboBoxLogin.Items.AddRange(sortedLogins.ToArray());
                }

                comboBoxLogin.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке логинов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLoginHistory(string filterLogin = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    string query = "SELECT login, attemptDate, success FROM loginHistory";

                    if (!string.IsNullOrEmpty(filterLogin) && filterLogin != "Нет фильтра")
                    {
                        query += " WHERE login = @login";
                    }

                    query += " ORDER BY attemptDate DESC";

                    SqlCommand command = new SqlCommand(query, connection);

                    if (!string.IsNullOrEmpty(filterLogin) && filterLogin != "Нет фильтра")
                    {
                        command.Parameters.AddWithValue("@login", filterLogin);
                    }

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count == 0 && !string.IsNullOrEmpty(filterLogin) && filterLogin != "Нет фильтра")
                    {
                        MessageBox.Show("Для выбранного логина нет истории входа.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxLogin.SelectedIndex = 0;
                        LoadLoginHistory("Нет фильтра");
                    }
                    else
                    {
                        dataGridViewLoginHistory.DataSource = dataTable;
                        dataGridViewLoginHistory.Columns["attemptDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dataGridViewLoginHistory.Columns["login"].HeaderText = "Логин";
                        dataGridViewLoginHistory.Columns["attemptDate"].HeaderText = "Дата попытки";
                        dataGridViewLoginHistory.Columns["success"].HeaderText = "Успешность";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории входов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLogin = comboBoxLogin.SelectedItem.ToString();
            LoadLoginHistory(selectedLogin);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LoginHistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
