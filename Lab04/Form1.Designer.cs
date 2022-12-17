
namespace Lab04
{
	partial class Form1
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
			this.lenOut = new System.Windows.Forms.TextBox();
			this.EventButton = new System.Windows.Forms.Button();
			this.DTButton = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.pInp = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.sigInp = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.muInp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.bInp = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.aInp = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lenOut
			// 
			this.lenOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lenOut.Location = new System.Drawing.Point(184, 187);
			this.lenOut.Margin = new System.Windows.Forms.Padding(5);
			this.lenOut.Name = "lenOut";
			this.lenOut.ReadOnly = true;
			this.lenOut.Size = new System.Drawing.Size(152, 29);
			this.lenOut.TabIndex = 33;
			this.lenOut.Text = "0";
			// 
			// EventButton
			// 
			this.EventButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EventButton.Location = new System.Drawing.Point(310, 230);
			this.EventButton.Name = "EventButton";
			this.EventButton.Size = new System.Drawing.Size(290, 80);
			this.EventButton.TabIndex = 32;
			this.EventButton.Text = "Событийный метод";
			this.EventButton.UseVisualStyleBackColor = true;
			this.EventButton.Click += new System.EventHandler(this.EventButton_Click);
			// 
			// DTButton
			// 
			this.DTButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DTButton.Location = new System.Drawing.Point(10, 230);
			this.DTButton.Name = "DTButton";
			this.DTButton.Size = new System.Drawing.Size(290, 80);
			this.DTButton.TabIndex = 31;
			this.DTButton.Text = "Метод Δt";
			this.DTButton.UseVisualStyleBackColor = true;
			this.DTButton.Click += new System.EventHandler(this.DTButton_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(180, 150);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(27, 24);
			this.label9.TabIndex = 30;
			this.label9.Text = "P:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(10, 150);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(155, 24);
			this.label10.TabIndex = 29;
			this.label10.Text = "Обратная связь";
			// 
			// pInp
			// 
			this.pInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.pInp.Location = new System.Drawing.Point(220, 148);
			this.pInp.Margin = new System.Windows.Forms.Padding(5);
			this.pInp.Name = "pInp";
			this.pInp.Size = new System.Drawing.Size(116, 29);
			this.pInp.TabIndex = 28;
			this.pInp.Text = "0.0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(180, 115);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(25, 24);
			this.label5.TabIndex = 27;
			this.label5.Text = "λ:";
			// 
			// sigInp
			// 
			this.sigInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.sigInp.Location = new System.Drawing.Point(220, 113);
			this.sigInp.Margin = new System.Windows.Forms.Padding(5);
			this.sigInp.Name = "sigInp";
			this.sigInp.Size = new System.Drawing.Size(116, 29);
			this.sigInp.TabIndex = 26;
			this.sigInp.Text = "0.2";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(10, 115);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(26, 24);
			this.label6.TabIndex = 25;
			this.label6.Text = "α:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(10, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(597, 24);
			this.label7.TabIndex = 24;
			this.label7.Text = "Параметры обслуживающего аппарата (распределение Эрланга)";
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// muInp
			// 
			this.muInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.muInp.Location = new System.Drawing.Point(50, 113);
			this.muInp.Margin = new System.Windows.Forms.Padding(5);
			this.muInp.Name = "muInp";
			this.muInp.Size = new System.Drawing.Size(116, 29);
			this.muInp.TabIndex = 23;
			this.muInp.Text = "3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(10, 190);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(164, 24);
			this.label4.TabIndex = 22;
			this.label4.Text = "Размер очереди:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(180, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 24);
			this.label3.TabIndex = 21;
			this.label3.Text = "b:";
			// 
			// bInp
			// 
			this.bInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bInp.Location = new System.Drawing.Point(220, 43);
			this.bInp.Margin = new System.Windows.Forms.Padding(5);
			this.bInp.Name = "bInp";
			this.bInp.Size = new System.Drawing.Size(116, 29);
			this.bInp.TabIndex = 20;
			this.bInp.Text = "1.0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(10, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 24);
			this.label2.TabIndex = 19;
			this.label2.Text = "a:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(507, 24);
			this.label1.TabIndex = 18;
			this.label1.Text = "Параметры генератора (равномерное распределение)";
			// 
			// aInp
			// 
			this.aInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.aInp.Location = new System.Drawing.Point(50, 43);
			this.aInp.Margin = new System.Windows.Forms.Padding(5);
			this.aInp.Name = "aInp";
			this.aInp.Size = new System.Drawing.Size(116, 29);
			this.aInp.TabIndex = 17;
			this.aInp.Text = "0.25";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 321);
			this.Controls.Add(this.lenOut);
			this.Controls.Add(this.EventButton);
			this.Controls.Add(this.DTButton);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.pInp);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.sigInp);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.muInp);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.bInp);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.aInp);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox lenOut;
		private System.Windows.Forms.Button EventButton;
		private System.Windows.Forms.Button DTButton;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox pInp;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox sigInp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox muInp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox bInp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox aInp;
	}
}

