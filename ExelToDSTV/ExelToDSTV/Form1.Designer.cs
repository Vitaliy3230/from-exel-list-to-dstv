namespace ExelToDSTV
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.wayFile = new System.Windows.Forms.TextBox();
            this.Open = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.pathDSTV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // wayFile
            // 
            this.wayFile.Location = new System.Drawing.Point(12, 12);
            this.wayFile.Name = "wayFile";
            this.wayFile.Size = new System.Drawing.Size(414, 20);
            this.wayFile.TabIndex = 0;
            this.wayFile.Text = "Путь к файлу xlsx";
            this.wayFile.TextChanged += new System.EventHandler(this.wayFile_TextChanged);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(432, 12);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 1;
            this.Open.Text = "Open excel";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(432, 41);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 34);
            this.Save.TabIndex = 2;
            this.Save.Text = "Generate nc1";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // pathDSTV
            // 
            this.pathDSTV.Location = new System.Drawing.Point(13, 49);
            this.pathDSTV.Name = "pathDSTV";
            this.pathDSTV.Size = new System.Drawing.Size(413, 20);
            this.pathDSTV.TabIndex = 4;
            this.pathDSTV.Text = "Путь хранения DSTV";
            this.pathDSTV.TextChanged += new System.EventHandler(this.pathDSTV_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "Структура Excel:\r\n1й столбец кол-во, 2й - размеры пластины \"6х78х200\", где х-кирр" +
    "илицой,\r\n3й-марка стали.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathDSTV);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.wayFile);
            this.Name = "Form1";
            this.Text = "Генератор DSTV (.nc1) с Екселя";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox wayFile;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox pathDSTV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

