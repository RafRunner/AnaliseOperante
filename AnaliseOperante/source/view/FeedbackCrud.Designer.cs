namespace AnaliseOperante.source.view {
	partial class FeedbackCrud {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackCrud));
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.numericPontos = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.btnSalvar = new System.Windows.Forms.Button();
			this.btnCorBlink = new System.Windows.Forms.Button();
			this.panelCorBlink = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.textNomeAudio = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericPontos)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.numericPontos);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.btnSalvar);
			this.panel1.Controls.Add(this.btnCorBlink);
			this.panel1.Controls.Add(this.panelCorBlink);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.textNomeAudio);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(12, 13);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(496, 278);
			this.panel1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(387, 66);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 29);
			this.button1.TabIndex = 33;
			this.button1.Text = "Selecionar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// numericPontos
			// 
			this.numericPontos.Location = new System.Drawing.Point(12, 127);
			this.numericPontos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.numericPontos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericPontos.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numericPontos.Name = "numericPontos";
			this.numericPontos.Size = new System.Drawing.Size(155, 23);
			this.numericPontos.TabIndex = 32;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(9, 101);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(297, 17);
			this.label10.TabIndex = 31;
			this.label10.Text = "Pontos Ganhos (coloque negativo para perdidos)";
			// 
			// btnSalvar
			// 
			this.btnSalvar.Location = new System.Drawing.Point(180, 229);
			this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Size = new System.Drawing.Size(126, 33);
			this.btnSalvar.TabIndex = 20;
			this.btnSalvar.Text = "Salvar";
			this.btnSalvar.UseVisualStyleBackColor = true;
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			// 
			// btnCorBlink
			// 
			this.btnCorBlink.Location = new System.Drawing.Point(47, 188);
			this.btnCorBlink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCorBlink.Name = "btnCorBlink";
			this.btnCorBlink.Size = new System.Drawing.Size(120, 29);
			this.btnCorBlink.TabIndex = 7;
			this.btnCorBlink.Text = "Selecionar";
			this.btnCorBlink.UseVisualStyleBackColor = true;
			this.btnCorBlink.Click += new System.EventHandler(this.btnCorBlink_Click);
			// 
			// panelCorBlink
			// 
			this.panelCorBlink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelCorBlink.Location = new System.Drawing.Point(11, 188);
			this.panelCorBlink.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panelCorBlink.Name = "panelCorBlink";
			this.panelCorBlink.Size = new System.Drawing.Size(28, 29);
			this.panelCorBlink.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(8, 163);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "Cor Blink (piscada)";
			// 
			// textNomeAudio
			// 
			this.textNomeAudio.Enabled = false;
			this.textNomeAudio.Location = new System.Drawing.Point(11, 69);
			this.textNomeAudio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textNomeAudio.Name = "textNomeAudio";
			this.textNomeAudio.Size = new System.Drawing.Size(370, 23);
			this.textNomeAudio.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nome Audio";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Feedback";
			// 
			// FeedbackCrud
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(521, 298);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FeedbackCrud";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FeedbackCrud";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericPontos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericPontos;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnCorBlink;
		private System.Windows.Forms.Panel panelCorBlink;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textNomeAudio;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColorDialog colorDialog;
	}
}