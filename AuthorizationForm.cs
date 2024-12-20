using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class AuthorizationForm : Form
    {
        private int attempts = 0;
        private int maxAttempts = 3;
        private string captchaText = string.Empty;
        private DateTime lockTime = DateTime.MinValue;
        private bool isBlockedForever = false;

        public AuthorizationForm()
        {
            InitializeComponent();
            pictureBoxCaptcha.Image = CreateCaptcha(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
            textBoxPassword.UseSystemPasswordChar = true;
            HideCaptchaElements();
        }

        private void buttonShowHidePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
        }

        private Bitmap CreateCaptcha(int width, int height)
        {
            Random rnd = new Random();
            Bitmap result = new Bitmap(width, height);
            int Xpos = rnd.Next(0, width - 50);
            int Ypos = rnd.Next(15, height - 15);

            Brush[] colors = { Brushes.Black, Brushes.Red, Brushes.RoyalBlue, Brushes.Green };
            Graphics g = Graphics.FromImage(result);
            g.Clear(Color.White);

            captchaText = string.Empty;
            string characters = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                captchaText += characters[rnd.Next(characters.Length)];

            g.DrawString(captchaText, new Font("Arial", 15), colors[rnd.Next(colors.Length)], new PointF(Xpos, Ypos));
            g.DrawLine(Pens.Black, new Point(0, 0), new Point(width - 1, height - 1));
            g.DrawLine(Pens.Black, new Point(0, height - 1), new Point(width - 1, 0));

            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

        private void buttonRefreshCaptcha_Click(object sender, EventArgs e)
        {
            pictureBoxCaptcha.Image = CreateCaptcha(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
        }

        private (bool, int) ValidateUser(string login, string password)
        {
            bool isValid = false;
            int userTypeId = -1;
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    string query = "SELECT userTypeId FROM users WHERE userLogin COLLATE SQL_Latin1_General_CP1_CS_AS = @login AND userPassword COLLATE SQL_Latin1_General_CP1_CS_AS = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        isValid = true;
                        userTypeId = (int)result;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return (isValid, userTypeId);
        }

        private void LogLoginAttempt(string login, bool success)
        {
            if (!DoesUserExist(login))
            {
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
                {
                    string query = "INSERT INTO loginHistory (login, attemptDate, success) VALUES (@login, @attemptDate, @success)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@attemptDate", DateTime.Now);
                    command.Parameters.AddWithValue("@success", success);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в базу данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DoesUserExist(string login)
        {
            using (SqlConnection connection = new SqlConnection(Program.ConnectionString))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM users WHERE userLogin COLLATE SQL_Latin1_General_CP1_CS_AS = @login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", login);

                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при проверке пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string enteredLogin = textBoxLogin.Text;
            string enteredPassword = textBoxPassword.Text;
            string enteredCaptcha = textBoxCaptcha.Text;
            bool loginSuccess = false;
            int userTypeId = -1;

            if (attempts >= maxAttempts && DateTime.Now < lockTime)
            {
                if (attempts == 3)
                {
                    MessageBox.Show($"Попробуйте снова через {lockTime.Subtract(DateTime.Now).Minutes} минут(ы).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Вы превысили количество попыток. Для разблокировки перезагрузите приложение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            if (string.IsNullOrEmpty(enteredLogin) || string.IsNullOrEmpty(enteredPassword) || (attempts >= 1 && string.IsNullOrEmpty(enteredCaptcha)))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (attempts == 0)
            {
                (loginSuccess, userTypeId) = ValidateUser(enteredLogin, enteredPassword);

                if (loginSuccess)
                {
                    MessageBox.Show("Добро пожаловать!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    loginSuccess = false;
                    attempts++;
                    MessageBox.Show("Неправильный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxLogin.Clear();
                    textBoxPassword.Clear();
                    ShowCaptchaElements();
                }
            }
            else
            {
                bool captchaValid = enteredCaptcha == captchaText;
                if (!captchaValid)
                {
                    MessageBox.Show("Неверно введена капча. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCaptcha.Clear();
                    pictureBoxCaptcha.Image = CreateCaptcha(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
                    return;
                }

                (loginSuccess, userTypeId) = ValidateUser(enteredLogin, enteredPassword);

                if (loginSuccess)
                {
                    MessageBox.Show("Добро пожаловать!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    loginSuccess = false;
                    attempts++;
                    MessageBox.Show("Неправильный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxLogin.Clear();
                    textBoxPassword.Clear();
                    textBoxCaptcha.Clear();
                    pictureBoxCaptcha.Image = CreateCaptcha(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
                }
            }

            LogLoginAttempt(enteredLogin, loginSuccess);

            if (loginSuccess)
            {
                this.Hide();
                attempts = 0;

                switch (userTypeId)
                {
                    case 1:
                        ManagerForm managerForm = new ManagerForm(enteredLogin);
                        managerForm.Show();
                        break;
                    case 2:
                        TechnicianForm technicianForm = new TechnicianForm(enteredLogin);
                        technicianForm.Show();
                        break;
                    case 3:
                        OperatorForm operatorForm = new OperatorForm(enteredLogin);
                        operatorForm.Show();
                        break;
                    case 4:
                        ClientForm clientForm = new ClientForm(enteredLogin);
                        clientForm.Show();
                        break;
                }

                textBoxLogin.Clear();
                textBoxPassword.Clear();
                textBoxCaptcha.Clear();
            }

            if (attempts == 3)
            {
                lockTime = DateTime.Now.AddMinutes(3);
                buttonLogin.Enabled = false;
                ShowLockTimer();
                MessageBox.Show("Вы превысили количество попыток. Попробуйте снова через 3 минуты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (attempts >= maxAttempts)
            {
                buttonLogin.Enabled = false;
                MessageBox.Show("Вы превысили количество попыток входа. Для разблокировки перезагрузите приложение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowCaptchaElements()
        {
            labelCaptcha.Visible = true;
            buttonRefreshCaptcha.Visible = true;
            textBoxCaptcha.Visible = true;
            pictureBoxCaptcha.Visible = true;
            pictureBoxCaptcha.Image = CreateCaptcha(pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
        }

        private void HideCaptchaElements()
        {
            labelCaptcha.Visible = false;
            buttonRefreshCaptcha.Visible = false;
            textBoxCaptcha.Visible = false;
            pictureBoxCaptcha.Visible = false;
        }

        private void ShowLockTimer()
        {
            Timer lockTimer = new Timer();
            lockTimer.Interval = 1000;
            lockTimer.Tick += (s, e) =>
            {
                var remainingTime = lockTime.Subtract(DateTime.Now);

                if (remainingTime <= TimeSpan.Zero)
                {
                    buttonLogin.Enabled = true;
                    lockTimer.Stop();
                    labelMessage.Text = "";
                }
                else
                {
                    labelMessage.Text = $"Блок: {remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
                }
            };
            lockTimer.Start();
        }

        private void AuthorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}