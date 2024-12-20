namespace ComputerRepairRequests
{
    partial class EditClientRequestForm
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelTextStartDate = new System.Windows.Forms.Label();
            this.labelTextStatus = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxProblemDescription = new System.Windows.Forms.TextBox();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelTextProblem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(305, 312);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(110, 26);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(15, 312);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(110, 26);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
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
            this.labelTextStartDate.TabIndex = 13;
            this.labelTextStartDate.Text = "Дата создания:";
            // 
            // labelTextStatus
            // 
            this.labelTextStatus.AutoSize = true;
            this.labelTextStatus.Location = new System.Drawing.Point(66, 8);
            this.labelTextStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextStatus.Name = "labelTextStatus";
            this.labelTextStatus.Size = new System.Drawing.Size(56, 14);
            this.labelTextStatus.TabIndex = 12;
            this.labelTextStatus.Text = "Статус:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(133, 32);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(11, 14);
            this.labelStartDate.TabIndex = 11;
            this.labelStartDate.Text = ".";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(133, 8);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(11, 14);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = ".";
            // 
            // textBoxProblemDescription
            // 
            this.textBoxProblemDescription.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProblemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProblemDescription.Location = new System.Drawing.Point(15, 102);
            this.textBoxProblemDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProblemDescription.Multiline = true;
            this.textBoxProblemDescription.Name = "textBoxProblemDescription";
            this.textBoxProblemDescription.Size = new System.Drawing.Size(400, 196);
            this.textBoxProblemDescription.TabIndex = 9;
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(78, 56);
            this.comboBoxModel.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(337, 22);
            this.comboBoxModel.TabIndex = 8;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(11, 59);
            this.labelModel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(55, 14);
            this.labelModel.TabIndex = 16;
            this.labelModel.Text = "Модель";
            // 
            // labelTextProblem
            // 
            this.labelTextProblem.AutoSize = true;
            this.labelTextProblem.Location = new System.Drawing.Point(144, 82);
            this.labelTextProblem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextProblem.Name = "labelTextProblem";
            this.labelTextProblem.Size = new System.Drawing.Size(139, 14);
            this.labelTextProblem.TabIndex = 19;
            this.labelTextProblem.Text = "Описание проблемы";
            // 
            // EditClientRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(427, 349);
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
            this.Name = "EditClientRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование заявки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTextStartDate;
        private System.Windows.Forms.Label labelTextStatus;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxProblemDescription;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelTextProblem;
    }
}