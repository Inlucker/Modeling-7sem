
namespace lab3
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
      this.alg1 = new System.Windows.Forms.Panel();
      this.alg2 = new System.Windows.Forms.Panel();
      this.alg3 = new System.Windows.Forms.Panel();
      this.tab3 = new System.Windows.Forms.Panel();
      this.tab2 = new System.Windows.Forms.Panel();
      this.tab1 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.inp_panel = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.button2 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // alg1
      // 
      this.alg1.Location = new System.Drawing.Point(181, 53);
      this.alg1.Margin = new System.Windows.Forms.Padding(2);
      this.alg1.Name = "alg1";
      this.alg1.Size = new System.Drawing.Size(67, 266);
      this.alg1.TabIndex = 0;
      this.alg1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // alg2
      // 
      this.alg2.Location = new System.Drawing.Point(247, 53);
      this.alg2.Margin = new System.Windows.Forms.Padding(2);
      this.alg2.Name = "alg2";
      this.alg2.Size = new System.Drawing.Size(67, 266);
      this.alg2.TabIndex = 2;
      this.alg2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // alg3
      // 
      this.alg3.Location = new System.Drawing.Point(314, 53);
      this.alg3.Margin = new System.Windows.Forms.Padding(2);
      this.alg3.Name = "alg3";
      this.alg3.Size = new System.Drawing.Size(67, 266);
      this.alg3.TabIndex = 3;
      this.alg3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // tab3
      // 
      this.tab3.Location = new System.Drawing.Point(529, 53);
      this.tab3.Margin = new System.Windows.Forms.Padding(2);
      this.tab3.Name = "tab3";
      this.tab3.Size = new System.Drawing.Size(67, 266);
      this.tab3.TabIndex = 6;
      this.tab3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // tab2
      // 
      this.tab2.Location = new System.Drawing.Point(462, 53);
      this.tab2.Margin = new System.Windows.Forms.Padding(2);
      this.tab2.Name = "tab2";
      this.tab2.Size = new System.Drawing.Size(67, 266);
      this.tab2.TabIndex = 5;
      this.tab2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // tab1
      // 
      this.tab1.Location = new System.Drawing.Point(396, 53);
      this.tab1.Margin = new System.Windows.Forms.Padding(2);
      this.tab1.Name = "tab1";
      this.tab1.Size = new System.Drawing.Size(67, 266);
      this.tab1.TabIndex = 4;
      this.tab1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(396, 22);
      this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(200, 21);
      this.label2.TabIndex = 7;
      this.label2.Text = "Табличный метод";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(181, 22);
      this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(200, 21);
      this.label3.TabIndex = 8;
      this.label3.Text = "Алгоритмический метод";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // inp_panel
      // 
      this.inp_panel.Location = new System.Drawing.Point(11, 53);
      this.inp_panel.Margin = new System.Windows.Forms.Padding(2);
      this.inp_panel.Name = "inp_panel";
      this.inp_panel.Size = new System.Drawing.Size(157, 266);
      this.inp_panel.TabIndex = 9;
      this.inp_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
      // 
      // button1
      // 
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      this.button1.Location = new System.Drawing.Point(10, 323);
      this.button1.Margin = new System.Windows.Forms.Padding(2);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(158, 36);
      this.button1.TabIndex = 11;
      this.button1.Text = "Рассчитать критерий";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(12, 22);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(156, 21);
      this.label1.TabIndex = 12;
      this.label1.Text = "Собственный ввод";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
      this.button2.Location = new System.Drawing.Point(181, 323);
      this.button2.Margin = new System.Windows.Forms.Padding(2);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(415, 36);
      this.button2.TabIndex = 13;
      this.button2.Text = "Сгенерировать последовательности";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(607, 366);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.inp_panel);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tab3);
      this.Controls.Add(this.tab2);
      this.Controls.Add(this.tab1);
      this.Controls.Add(this.alg3);
      this.Controls.Add(this.alg2);
      this.Controls.Add(this.alg1);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "Form1";
      this.Text = "Генерация псевдослучайных последовательностей";
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel alg1;
        private System.Windows.Forms.Panel alg2;
        private System.Windows.Forms.Panel alg3;
        private System.Windows.Forms.Panel tab3;
        private System.Windows.Forms.Panel tab2;
        private System.Windows.Forms.Panel tab1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel inp_panel;
        private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2;
  }
}

