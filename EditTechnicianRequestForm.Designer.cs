namespace ComputerRepairRequests
{
    partial class EditTechnicianRequestForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddPart = new System.Windows.Forms.Button();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxPartName = new System.Windows.Forms.TextBox();
            this.repairPartsDataGridView = new Zuby.ADGV.AdvancedDataGridView();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonComplete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.repairPartsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "Количество";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "Название детали";
            // 
            // buttonAddPart
            // 
            this.buttonAddPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonAddPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPart.Location = new System.Drawing.Point(279, 148);
            this.buttonAddPart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddPart.Name = "buttonAddPart";
            this.buttonAddPart.Size = new System.Drawing.Size(123, 63);
            this.buttonAddPart.TabIndex = 27;
            this.buttonAddPart.Text = "Добавить деталь";
            this.buttonAddPart.UseVisualStyleBackColor = false;
            this.buttonAddPart.Click += new System.EventHandler(this.buttonAddPart_Click);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(142, 189);
            this.textBoxQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(119, 22);
            this.textBoxQuantity.TabIndex = 26;
            this.textBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantity_KeyPress);
            // 
            // textBoxPartName
            // 
            this.textBoxPartName.Location = new System.Drawing.Point(142, 148);
            this.textBoxPartName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPartName.Name = "textBoxPartName";
            this.textBoxPartName.Size = new System.Drawing.Size(119, 22);
            this.textBoxPartName.TabIndex = 25;
            // 
            // repairPartsDataGridView
            // 
            this.repairPartsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.repairPartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.repairPartsDataGridView.FilterAndSortEnabled = true;
            this.repairPartsDataGridView.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.repairPartsDataGridView.Location = new System.Drawing.Point(13, 10);
            this.repairPartsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.repairPartsDataGridView.MaxFilterButtonImageHeight = 23;
            this.repairPartsDataGridView.Name = "repairPartsDataGridView";
            this.repairPartsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.repairPartsDataGridView.RowHeadersWidth = 62;
            this.repairPartsDataGridView.RowTemplate.Height = 28;
            this.repairPartsDataGridView.Size = new System.Drawing.Size(390, 126);
            this.repairPartsDataGridView.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.repairPartsDataGridView.TabIndex = 24;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(279, 228);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(123, 26);
            this.buttonBack.TabIndex = 23;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonComplete
            // 
            this.buttonComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(208)))), ((int)(((byte)(211)))));
            this.buttonComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonComplete.Location = new System.Drawing.Point(16, 228);
            this.buttonComplete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.Size = new System.Drawing.Size(153, 26);
            this.buttonComplete.TabIndex = 22;
            this.buttonComplete.Text = "Завершить заявку";
            this.buttonComplete.UseVisualStyleBackColor = false;
            this.buttonComplete.Click += new System.EventHandler(this.buttonComplete_Click);
            // 
            // EditTechnicianRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(415, 265);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddPart);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxPartName);
            this.Controls.Add(this.repairPartsDataGridView);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonComplete);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTechnicianRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Исполнение заявки";
            ((System.ComponentModel.ISupportInitialize)(this.repairPartsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddPart;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxPartName;
        private Zuby.ADGV.AdvancedDataGridView repairPartsDataGridView;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonComplete;
    }
}