namespace ComputerRepairRequests
{
    partial class OperatorForm
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
            this.lableTableName = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelUserType = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.requestsDataGridView = new Zuby.ADGV.AdvancedDataGridView();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonOpenAudit = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.labelAverageTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // lableTableName
            // 
            this.lableTableName.AutoSize = true;
            this.lableTableName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lableTableName.Location = new System.Drawing.Point(337, 15);
            this.lableTableName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lableTableName.Name = "lableTableName";
            this.lableTableName.Size = new System.Drawing.Size(144, 29);
            this.lableTableName.TabIndex = 28;
            this.lableTableName.Text = "Все заявки";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(584, 54);
            this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(190, 22);
            this.labelCount.TabIndex = 27;
            this.labelCount.Text = "Отображено строк:";
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(78, 54);
            this.labelUserType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(60, 22);
            this.labelUserType.TabIndex = 26;
            this.labelUserType.Text = "РОЛЬ";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(78, 8);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(38, 22);
            this.labelFullName.TabIndex = 25;
            this.labelFullName.Text = "ФИ";
            // 
            // requestsDataGridView
            // 
            this.requestsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.requestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsDataGridView.FilterAndSortEnabled = true;
            this.requestsDataGridView.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.requestsDataGridView.Location = new System.Drawing.Point(11, 80);
            this.requestsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.requestsDataGridView.MaxFilterButtonImageHeight = 23;
            this.requestsDataGridView.Name = "requestsDataGridView";
            this.requestsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.requestsDataGridView.RowHeadersWidth = 62;
            this.requestsDataGridView.RowTemplate.Height = 28;
            this.requestsDataGridView.Size = new System.Drawing.Size(745, 245);
            this.requestsDataGridView.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.requestsDataGridView.TabIndex = 24;
            this.requestsDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.requestsDataGridView_CellMouseClick);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(587, 339);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(169, 26);
            this.buttonLogout.TabIndex = 23;
            this.buttonLogout.Text = "Выйти из системы";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistration.Location = new System.Drawing.Point(11, 339);
            this.buttonRegistration.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(164, 26);
            this.buttonRegistration.TabIndex = 22;
            this.buttonRegistration.Text = "Регистрация заявки";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(193, 339);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(137, 26);
            this.buttonDelete.TabIndex = 30;
            this.buttonDelete.Text = "Удаление заявки";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonOpenAudit
            // 
            this.buttonOpenAudit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonOpenAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenAudit.Location = new System.Drawing.Point(350, 339);
            this.buttonOpenAudit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenAudit.Name = "buttonOpenAudit";
            this.buttonOpenAudit.Size = new System.Drawing.Size(175, 26);
            this.buttonOpenAudit.TabIndex = 31;
            this.buttonOpenAudit.Text = "Журнал авторизаций";
            this.buttonOpenAudit.UseVisualStyleBackColor = false;
            this.buttonOpenAudit.Click += new System.EventHandler(this.buttonOpenAudit_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::ComputerRepairRequests.Properties.Resources.user;
            this.pictureBoxProfile.Location = new System.Drawing.Point(11, 8);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxProfile.TabIndex = 29;
            this.pictureBoxProfile.TabStop = false;
            // 
            // labelAverageTime
            // 
            this.labelAverageTime.AutoSize = true;
            this.labelAverageTime.Location = new System.Drawing.Point(310, 54);
            this.labelAverageTime.Name = "labelAverageTime";
            this.labelAverageTime.Size = new System.Drawing.Size(68, 22);
            this.labelAverageTime.TabIndex = 32;
            this.labelAverageTime.Text = "Время";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 22);
            this.label1.TabIndex = 33;
            this.label1.Text = "Среднее время:";
            // 
            // OperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(769, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAverageTime);
            this.Controls.Add(this.buttonOpenAudit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.lableTableName);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelUserType);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.requestsDataGridView);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonRegistration);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperatorForm_FormClosing_1);
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label lableTableName;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.Label labelFullName;
        private Zuby.ADGV.AdvancedDataGridView requestsDataGridView;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonRegistration;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonOpenAudit;
        private System.Windows.Forms.Label labelAverageTime;
        private System.Windows.Forms.Label label1;
    }
}