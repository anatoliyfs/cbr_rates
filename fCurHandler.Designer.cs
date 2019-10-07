namespace cbrHanler
{
    partial class fCurHandler
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
            this.btnUpdCur = new System.Windows.Forms.Button();
            this.btnGetCur = new System.Windows.Forms.Button();
            this.curGet = new System.Windows.Forms.ComboBox();
            this.dtGet = new System.Windows.Forms.DateTimePicker();
            this.lblUpdateCur = new System.Windows.Forms.Label();
            this.lblGetCur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdCur
            // 
            this.btnUpdCur.Location = new System.Drawing.Point(158, 21);
            this.btnUpdCur.Name = "btnUpdCur";
            this.btnUpdCur.Size = new System.Drawing.Size(168, 23);
            this.btnUpdCur.TabIndex = 0;
            this.btnUpdCur.Text = "Обновить курс с сайта ЦБ";
            this.btnUpdCur.UseVisualStyleBackColor = true;
            this.btnUpdCur.Click += new System.EventHandler(this.btnUpdCur_Click);
            // 
            // btnGetCur
            // 
            this.btnGetCur.Location = new System.Drawing.Point(158, 67);
            this.btnGetCur.Name = "btnGetCur";
            this.btnGetCur.Size = new System.Drawing.Size(168, 23);
            this.btnGetCur.TabIndex = 1;
            this.btnGetCur.Text = "Получить из БД";
            this.btnGetCur.UseVisualStyleBackColor = true;
            this.btnGetCur.Click += new System.EventHandler(this.btnGetCur_Click);
            // 
            // curGet
            // 
            this.curGet.FormattingEnabled = true;
            this.curGet.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.curGet.Location = new System.Drawing.Point(34, 69);
            this.curGet.Name = "curGet";
            this.curGet.Size = new System.Drawing.Size(104, 21);
            this.curGet.TabIndex = 2;
            this.curGet.Text = "USD";
            // 
            // dtGet
            // 
            this.dtGet.CustomFormat = "";
            this.dtGet.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtGet.Location = new System.Drawing.Point(34, 24);
            this.dtGet.Name = "dtGet";
            this.dtGet.Size = new System.Drawing.Size(104, 20);
            this.dtGet.TabIndex = 3;
            // 
            // lblUpdateCur
            // 
            this.lblUpdateCur.AutoSize = true;
            this.lblUpdateCur.Location = new System.Drawing.Point(344, 30);
            this.lblUpdateCur.Name = "lblUpdateCur";
            this.lblUpdateCur.Size = new System.Drawing.Size(0, 13);
            this.lblUpdateCur.TabIndex = 4;
            // 
            // lblGetCur
            // 
            this.lblGetCur.AutoSize = true;
            this.lblGetCur.Location = new System.Drawing.Point(344, 72);
            this.lblGetCur.Name = "lblGetCur";
            this.lblGetCur.Size = new System.Drawing.Size(0, 13);
            this.lblGetCur.TabIndex = 5;
            // 
            // fCurHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 119);
            this.Controls.Add(this.lblGetCur);
            this.Controls.Add(this.lblUpdateCur);
            this.Controls.Add(this.dtGet);
            this.Controls.Add(this.curGet);
            this.Controls.Add(this.btnGetCur);
            this.Controls.Add(this.btnUpdCur);
            this.Name = "fCurHandler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdCur;
        private System.Windows.Forms.Button btnGetCur;
        private System.Windows.Forms.ComboBox curGet;
        private System.Windows.Forms.DateTimePicker dtGet;
        private System.Windows.Forms.Label lblUpdateCur;
        private System.Windows.Forms.Label lblGetCur;
    }
}

