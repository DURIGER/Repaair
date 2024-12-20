using Zuby.ADGV;

namespace ComputerRepairRequests
{
    partial class ClientForm
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
            this.buttonEditRequest = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonQrCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // lableTableName
            // 
            this.lableTableName.AutoSize = true;
            this.lableTableName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lableTableName.Location = new System.Drawing.Point(337, 31);
            this.lableTableName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lableTableName.Name = "lableTableName";
            this.lableTableName.Size = new System.Drawing.Size(112, 19);
            this.lableTableName.TabIndex = 18;
            this.lableTableName.Text = "Ваши заявки";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(584, 54);
            this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(136, 14);
            this.labelCount.TabIndex = 16;
            this.labelCount.Text = "Отображено строк:";
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(78, 54);
            this.labelUserType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(42, 14);
            this.labelUserType.TabIndex = 15;
            this.labelUserType.Text = "РОЛЬ";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(78, 8);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(27, 14);
            this.labelFullName.TabIndex = 14;
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
            this.requestsDataGridView.Size = new System.Drawing.Size(745, 244);
            this.requestsDataGridView.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.requestsDataGridView.TabIndex = 13;
            this.requestsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.requestsDataGridView_CellContentClick);
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
            this.buttonLogout.TabIndex = 12;
            this.buttonLogout.Text = "Выйти из системы";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonEditRequest
            // 
            this.buttonEditRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonEditRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditRequest.Location = new System.Drawing.Point(177, 339);
            this.buttonEditRequest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditRequest.Name = "buttonEditRequest";
            this.buttonEditRequest.Size = new System.Drawing.Size(190, 26);
            this.buttonEditRequest.TabIndex = 11;
            this.buttonEditRequest.Text = "Редактирование заявки";
            this.buttonEditRequest.UseVisualStyleBackColor = false;
            this.buttonEditRequest.Click += new System.EventHandler(this.buttonEditRequest_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::ComputerRepairRequests.Properties.Resources.user;
            this.pictureBoxProfile.Location = new System.Drawing.Point(11, 8);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxProfile.TabIndex = 19;
            this.pictureBoxProfile.TabStop = false;
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Location = new System.Drawing.Point(11, 339);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(145, 26);
            this.buttonCreate.TabIndex = 21;
            this.buttonCreate.Text = "Создание заявки";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonQrCode
            // 
            this.buttonQrCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonQrCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQrCode.Location = new System.Drawing.Point(386, 339);
            this.buttonQrCode.Name = "buttonQrCode";
            this.buttonQrCode.Size = new System.Drawing.Size(182, 26);
            this.buttonQrCode.TabIndex = 22;
            this.buttonQrCode.Text = "Оценить работу";
            this.buttonQrCode.UseVisualStyleBackColor = false;
            this.buttonQrCode.Click += new System.EventHandler(this.buttonQrCode_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(769, 375);
            this.Controls.Add(this.buttonQrCode);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.lableTableName);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelUserType);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.requestsDataGridView);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonEditRequest);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableTableName;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.Label labelFullName;
        private AdvancedDataGridView requestsDataGridView;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonEditRequest;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonQrCode;
    }
}