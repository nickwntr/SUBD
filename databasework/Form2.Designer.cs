
namespace databasework
{
    partial class FormEditor
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
            this.dataGridViewEdit = new System.Windows.Forms.DataGridView();
            this.textBoxEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEdit
            // 
            this.dataGridViewEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEdit.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewEdit.Name = "dataGridViewEdit";
            this.dataGridViewEdit.RowHeadersWidth = 51;
            this.dataGridViewEdit.RowTemplate.Height = 24;
            this.dataGridViewEdit.Size = new System.Drawing.Size(776, 339);
            this.dataGridViewEdit.TabIndex = 0;
            this.dataGridViewEdit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEdit_CellContentClick);
            this.dataGridViewEdit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEdit_CellValueChanged);
            this.dataGridViewEdit.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewEdit_UserAddedRow);
            // 
            // textBoxEdit
            // 
            this.textBoxEdit.Location = new System.Drawing.Point(211, 366);
            this.textBoxEdit.Name = "textBoxEdit";
            this.textBoxEdit.ReadOnly = true;
            this.textBoxEdit.Size = new System.Drawing.Size(204, 22);
            this.textBoxEdit.TabIndex = 1;
            this.textBoxEdit.Text = "Редактировать";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название таблицы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(660, 357);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(94, 34);
            this.Update.TabIndex = 3;
            this.Update.Text = "Обновить";
            this.Update.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEdit);
            this.Controls.Add(this.dataGridViewEdit);
            this.Name = "FormEditor";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditor_FormClosing);
            this.Load += new System.EventHandler(this.FormEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEdit;
        private System.Windows.Forms.TextBox textBoxEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Update;
    }
}