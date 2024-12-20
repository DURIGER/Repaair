using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class CreateCommentsForm : Form
    {
        int requestId;

        public CreateCommentsForm(int reqId)
        {
            InitializeComponent();
            this.requestId = reqId;
            LoadComments();
        }

        private void LoadComments()
        {
            listBoxComments.Items.Clear();

            string query = @"
                SELECT requestMessage
                FROM comments
                WHERE requestId = @requestId
                ORDER BY commentId";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@requestId", requestId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listBoxComments.Items.Add(reader["requestMessage"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке комментариев: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddComment(string comment)
        {
            string query = "INSERT INTO comments (requestMessage, requestId) VALUES (@requestMessage, @requestId)";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@requestMessage", comment);
                    command.Parameters.AddWithValue("@requestId", requestId);

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadComments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении комментария: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteComment(string commentText)
        {
            string query = "DELETE FROM comments WHERE requestId = @requestId AND requestMessage = @requestMessage";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@requestId", requestId);
                    command.Parameters.AddWithValue("@requestMessage", commentText);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        LoadComments();
                    }
                    else
                    {
                        MessageBox.Show("Комментарий не найден или произошла ошибка при удалении.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении комментария: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxComment.Text.Length < 255)
            {
                string comment = textBoxComment.Text.Trim();

                if (!string.IsNullOrEmpty(comment))
                {
                    AddComment(comment);
                    textBoxComment.Clear();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите комментарий.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Слишком длинный комментарий.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxComments.SelectedItem != null)
            {
                string selectedCommentText = listBoxComments.SelectedItem.ToString();

                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить комментарий: '{selectedCommentText}'?",
                    "Удалить комментарий",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteComment(selectedCommentText);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите комментарий для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
