namespace ComputerRepairRequests
{
    partial class LoginHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewLoginHistory = new System.Windows.Forms.DataGridView();
            this.comboBoxLogin = new System.Windows.Forms.ComboBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelFiltration = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoginHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLoginHistory
            // 
            this.dataGridViewLoginHistory.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewLoginHistory.Location = new System.Drawing.Point(13, 40);
            this.dataGridViewLoginHistory.Name = "dataGridViewLoginHistory";
            this.dataGridViewLoginHistory.ReadOnly = true;
            this.dataGridViewLoginHistory.Size = new System.Drawing.Size(354, 179);
            this.dataGridViewLoginHistory.TabIndex = 0;
            // 
            // comboBoxLogin
            // 
            this.comboBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.comboBoxLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxLogin.FormattingEnabled = true;
            this.comboBoxLogin.Location = new System.Drawing.Point(210, 12);
            this.comboBoxLogin.Name = "comboBoxLogin";
            this.comboBoxLogin.Size = new System.Drawing.Size(157, 22);
            this.comboBoxLogin.TabIndex = 3;
            this.comboBoxLogin.SelectedIndexChanged += new System.EventHandler(this.comboBoxLogin_SelectedIndexChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(245, 225);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(122, 26);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelFiltration
            // 
            this.labelFiltration.AutoSize = true;
            this.labelFiltration.Location = new System.Drawing.Point(49, 15);
            this.labelFiltration.Name = "labelFiltration";
            this.labelFiltration.Size = new System.Drawing.Size(155, 14);
            this.labelFiltration.TabIndex = 5;
            this.labelFiltration.Text = "Фильтрация по логину";
            // 
            // LoginHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(379, 259);
            this.Controls.Add(this.labelFiltration);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.comboBoxLogin);
            this.Controls.Add(this.dataGridViewLoginHistory);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал событий входа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginHistoryForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoginHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLoginHistory;
        private System.Windows.Forms.ComboBox comboBoxLogin;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelFiltration;
    }
}