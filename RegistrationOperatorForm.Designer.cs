namespace ComputerRepairRequests
{
    partial class RegistrationOperatorForm
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
            this.labelTextProblem = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelTextStartDate = new System.Windows.Forms.Label();
            this.labelTextStatus = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxProblemDescription = new System.Windows.Forms.TextBox();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.comboBoxMaster = new System.Windows.Forms.ComboBox();
            this.dateTimePickerCompletionDate = new System.Windows.Forms.DateTimePicker();
            this.labelTechnic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTextProblem
            // 
            this.labelTextProblem.AutoSize = true;
            this.labelTextProblem.Location = new System.Drawing.Point(144, 166);
            this.labelTextProblem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextProblem.Name = "labelTextProblem";
            this.labelTextProblem.Size = new System.Drawing.Size(139, 14);
            this.labelTextProblem.TabIndex = 29;
            this.labelTextProblem.Text = "Описание проблемы";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(11, 91);
            this.labelModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(55, 14);
            this.labelModel.TabIndex = 28;
            this.labelModel.Text = "Модель";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(305, 396);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(110, 26);
            this.buttonBack.TabIndex = 27;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(15, 396);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(110, 26);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "Применить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelTextStartDate
            // 
            this.labelTextStartDate.AutoSize = true;
            this.labelTextStartDate.Location = new System.Drawing.Point(15, 32);
            this.labelTextStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextStartDate.Name = "labelTextStartDate";
            this.labelTextStartDate.Size = new System.Drawing.Size(107, 14);
            this.labelTextStartDate.TabIndex = 25;
            this.labelTextStartDate.Text = "Дата создания:";
            // 
            // labelTextStatus
            // 
            this.labelTextStatus.AutoSize = true;
            this.labelTextStatus.Location = new System.Drawing.Point(66, 8);
            this.labelTextStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextStatus.Name = "labelTextStatus";
            this.labelTextStatus.Size = new System.Drawing.Size(56, 14);
            this.labelTextStatus.TabIndex = 24;
            this.labelTextStatus.Text = "Статус:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(133, 32);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(11, 14);
            this.labelStartDate.TabIndex = 23;
            this.labelStartDate.Text = ".";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(133, 8);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(11, 14);
            this.labelStatus.TabIndex = 22;
            this.labelStatus.Text = ".";
            // 
            // textBoxProblemDescription
            // 
            this.textBoxProblemDescription.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProblemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProblemDescription.Location = new System.Drawing.Point(15, 186);
            this.textBoxProblemDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProblemDescription.Multiline = true;
            this.textBoxProblemDescription.Name = "textBoxProblemDescription";
            this.textBoxProblemDescription.Size = new System.Drawing.Size(400, 196);
            this.textBoxProblemDescription.TabIndex = 21;
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(78, 88);
            this.comboBoxModel.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(337, 22);
            this.comboBoxModel.TabIndex = 20;
            // 
            // comboBoxMaster
            // 
            this.comboBoxMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.comboBoxMaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaster.FormattingEnabled = true;
            this.comboBoxMaster.Location = new System.Drawing.Point(78, 122);
            this.comboBoxMaster.Name = "comboBoxMaster";
            this.comboBoxMaster.Size = new System.Drawing.Size(335, 22);
            this.comboBoxMaster.TabIndex = 30;
            // 
            // dateTimePickerCompletionDate
            // 
            this.dateTimePickerCompletionDate.Location = new System.Drawing.Point(78, 56);
            this.dateTimePickerCompletionDate.Name = "dateTimePickerCompletionDate";
            this.dateTimePickerCompletionDate.Size = new System.Drawing.Size(161, 22);
            this.dateTimePickerCompletionDate.TabIndex = 31;
            // 
            // labelTechnic
            // 
            this.labelTechnic.AutoSize = true;
            this.labelTechnic.Location = new System.Drawing.Point(14, 125);
            this.labelTechnic.Name = "labelTechnic";
            this.labelTechnic.Size = new System.Drawing.Size(52, 14);
            this.labelTechnic.TabIndex = 32;
            this.labelTechnic.Text = "Техник";
            // 
            // RegistrationOperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(427, 429);
            this.Controls.Add(this.labelTechnic);
            this.Controls.Add(this.dateTimePickerCompletionDate);
            this.Controls.Add(this.comboBoxMaster);
            this.Controls.Add(this.labelTextProblem);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelTextStartDate);
            this.Controls.Add(this.labelTextStatus);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxProblemDescription);
            this.Controls.Add(this.comboBoxModel);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationOperatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация и изменение заявки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTextProblem;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTextStartDate;
        private System.Windows.Forms.Label labelTextStatus;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxProblemDescription;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.ComboBox comboBoxMaster;
        private System.Windows.Forms.DateTimePicker dateTimePickerCompletionDate;
        private System.Windows.Forms.Label labelTechnic;
    }
}