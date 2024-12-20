namespace ComputerRepairRequests
{
    partial class TechnicianForm
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
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelUserType = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.requestsDataGridView = new Zuby.ADGV.AdvancedDataGridView();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::ComputerRepairRequests.Properties.Resources.user;
            this.pictureBoxProfile.Location = new System.Drawing.Point(11, 8);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxProfile.TabIndex = 36;
            this.pictureBoxProfile.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(303, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 29);
            this.label2.TabIndex = 35;
            this.label2.Text = "Назначенные заявки";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(584, 54);
            this.labelCount.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(190, 22);
            this.labelCount.TabIndex = 34;
            this.labelCount.Text = "Отображено строк:";
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(78, 54);
            this.labelUserType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(60, 22);
            this.labelUserType.TabIndex = 33;
            this.labelUserType.Text = "РОЛЬ";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(78, 8);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(38, 22);
            this.labelFullName.TabIndex = 32;
            this.labelFullName.Text = "ФИ";
            // 
            // requestsDataGridView
            // 
            this.requestsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.requestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsDataGridView.FilterAndSortEnabled = true;
            this.requestsDataGridView.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.requestsDataGridView.Location = new System.Drawing.Point(11, 80);
            this.requestsDataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.requestsDataGridView.MaxFilterButtonImageHeight = 23;
            this.requestsDataGridView.Name = "requestsDataGridView";
            this.requestsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.requestsDataGridView.RowHeadersWidth = 62;
            this.requestsDataGridView.RowTemplate.Height = 28;
            this.requestsDataGridView.Size = new System.Drawing.Size(745, 246);
            this.requestsDataGridView.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.requestsDataGridView.TabIndex = 31;
            this.requestsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.requestsDataGridView_CellContentClick);
            this.requestsDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.requestsDataGridView_CellMouseClick);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(587, 339);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(169, 26);
            this.buttonLogout.TabIndex = 30;
            this.buttonLogout.Text = "Выйти из системы";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Location = new System.Drawing.Point(11, 339);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(191, 26);
            this.buttonEdit.TabIndex = 29;
            this.buttonEdit.Text = "Редактирование заявки";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // TechnicianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(769, 375);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelUserType);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.requestsDataGridView);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonEdit);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TechnicianForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TechnicianForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.Label labelFullName;
        private Zuby.ADGV.AdvancedDataGridView requestsDataGridView;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonEdit;
    }
}