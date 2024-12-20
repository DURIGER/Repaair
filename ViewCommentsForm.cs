using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ComputerRepairRequests
{
    public partial class ViewCommentsForm : Form
    {
        int requestId;
        public ViewCommentsForm(int reqId)
        {
            requestId = reqId;
            InitializeComponent();
            LoadComments();
        }
        private void LoadComments()
        {
            string query = @"
            SELECT c.commentId, c.requestMessage
            FROM comments c
            WHERE c.requestId = @requestId
            ORDER BY c.commentId";

            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@requestId", requestId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string commentMessage = reader["requestMessage"].ToString();
                        listBoxComments.Items.Add(commentMessage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке комментариев: " + ex.Message);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
