namespace AnaliseOperante.source.view {
	partial class ExperimentoView {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.Borda3 = new System.Windows.Forms.Panel();
			this.Quadrado3 = new System.Windows.Forms.Panel();
			this.Borda2 = new System.Windows.Forms.Panel();
			this.Quadrado2 = new System.Windows.Forms.Panel();
			this.Borda1 = new System.Windows.Forms.Panel();
			this.Quadrado1 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelPontosPerdidos = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.labelPontosTotais = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.labelPontosGanhos = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Borda3.SuspendLayout();
			this.Quadrado3.SuspendLayout();
			this.Borda2.SuspendLayout();
			this.Quadrado2.SuspendLayout();
			this.Borda1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Borda3
			// 
			this.Borda3.Controls.Add(this.Quadrado3);
			this.Borda3.Location = new System.Drawing.Point(610, 190);
			this.Borda3.Name = "Borda3";
			this.Borda3.Size = new System.Drawing.Size(700, 700);
			this.Borda3.TabIndex = 0;
			this.Borda3.Click += new System.EventHandler(this.Borda3_Click);
			// 
			// Quadrado3
			// 
			this.Quadrado3.Controls.Add(this.Borda2);
			this.Quadrado3.Location = new System.Drawing.Point(15, 15);
			this.Quadrado3.Name = "Quadrado3";
			this.Quadrado3.Size = new System.Drawing.Size(670, 670);
			this.Quadrado3.TabIndex = 0;
			this.Quadrado3.Click += new System.EventHandler(this.Quadrado3_Click);
			// 
			// Borda2
			// 
			this.Borda2.Controls.Add(this.Quadrado2);
			this.Borda2.Location = new System.Drawing.Point(145, 137);
			this.Borda2.Name = "Borda2";
			this.Borda2.Size = new System.Drawing.Size(375, 375);
			this.Borda2.TabIndex = 0;
			this.Borda2.Click += new System.EventHandler(this.Borda2_Click);
			// 
			// Quadrado2
			// 
			this.Quadrado2.Controls.Add(this.Borda1);
			this.Quadrado2.Location = new System.Drawing.Point(15, 15);
			this.Quadrado2.Name = "Quadrado2";
			this.Quadrado2.Size = new System.Drawing.Size(345, 345);
			this.Quadrado2.TabIndex = 0;
			this.Quadrado2.Click += new System.EventHandler(this.Quadrado2_Click);
			// 
			// Borda1
			// 
			this.Borda1.Controls.Add(this.Quadrado1);
			this.Borda1.Location = new System.Drawing.Point(89, 82);
			this.Borda1.Name = "Borda1";
			this.Borda1.Size = new System.Drawing.Size(175, 175);
			this.Borda1.TabIndex = 0;
			this.Borda1.Click += new System.EventHandler(this.Borda1_Click);
			// 
			// Quadrado1
			// 
			this.Quadrado1.Location = new System.Drawing.Point(13, 13);
			this.Quadrado1.Name = "Quadrado1";
			this.Quadrado1.Size = new System.Drawing.Size(151, 151);
			this.Quadrado1.TabIndex = 0;
			this.Quadrado1.Click += new System.EventHandler(this.Quadrado1_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.labelPontosPerdidos);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(292, 155);
			this.panel1.TabIndex = 1;
			this.panel1.Click += new System.EventHandler(this.panel1_Click);
			// 
			// labelPontosPerdidos
			// 
			this.labelPontosPerdidos.AutoSize = true;
			this.labelPontosPerdidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPontosPerdidos.Location = new System.Drawing.Point(106, 62);
			this.labelPontosPerdidos.Name = "labelPontosPerdidos";
			this.labelPontosPerdidos.Size = new System.Drawing.Size(68, 73);
			this.labelPontosPerdidos.TabIndex = 1;
			this.labelPontosPerdidos.Text = "0";
			this.labelPontosPerdidos.Click += new System.EventHandler(this.panel1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(49, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(190, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "PONTOS PERDIDOS";
			this.label1.Click += new System.EventHandler(this.panel1_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.labelPontosTotais);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new System.Drawing.Point(812, 13);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(292, 155);
			this.panel2.TabIndex = 2;
			this.panel2.Click += new System.EventHandler(this.panel2_Click);
			// 
			// labelPontosTotais
			// 
			this.labelPontosTotais.AutoSize = true;
			this.labelPontosTotais.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPontosTotais.Location = new System.Drawing.Point(110, 62);
			this.labelPontosTotais.Name = "labelPontosTotais";
			this.labelPontosTotais.Size = new System.Drawing.Size(68, 73);
			this.labelPontosTotais.TabIndex = 2;
			this.labelPontosTotais.Text = "0";
			this.labelPontosTotais.Click += new System.EventHandler(this.panel2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(64, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "PONTOS TOTAIS";
			this.label2.Click += new System.EventHandler(this.panel2_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.labelPontosGanhos);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Location = new System.Drawing.Point(1616, 12);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(292, 155);
			this.panel3.TabIndex = 2;
			this.panel3.Click += new System.EventHandler(this.panel3_Click);
			// 
			// labelPontosGanhos
			// 
			this.labelPontosGanhos.AutoSize = true;
			this.labelPontosGanhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPontosGanhos.Location = new System.Drawing.Point(115, 63);
			this.labelPontosGanhos.Name = "labelPontosGanhos";
			this.labelPontosGanhos.Size = new System.Drawing.Size(68, 73);
			this.labelPontosGanhos.TabIndex = 3;
			this.labelPontosGanhos.Text = "0";
			this.labelPontosGanhos.Click += new System.EventHandler(this.panel3_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(61, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "PONTOS GANHOS";
			this.label3.Click += new System.EventHandler(this.panel3_Click);
			// 
			// ExperimentoView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Borda3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ExperimentoView";
			this.Load += new System.EventHandler(this.ExperimentoView_Load);
			this.Click += new System.EventHandler(this.ExperimentoView_Click);
			this.Borda3.ResumeLayout(false);
			this.Quadrado3.ResumeLayout(false);
			this.Borda2.ResumeLayout(false);
			this.Quadrado2.ResumeLayout(false);
			this.Borda1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel Borda3;
		private System.Windows.Forms.Panel Quadrado3;
		private System.Windows.Forms.Panel Borda2;
		private System.Windows.Forms.Panel Quadrado2;
		private System.Windows.Forms.Panel Borda1;
		private System.Windows.Forms.Panel Quadrado1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelPontosPerdidos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labelPontosTotais;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label labelPontosGanhos;
		private System.Windows.Forms.Label label3;
	}
}