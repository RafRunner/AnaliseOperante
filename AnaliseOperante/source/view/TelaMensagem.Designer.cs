namespace AnaliseOperante.source.view {
	partial class TelaMensagem {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelMensagem = new System.Windows.Forms.Label();
			this.btnContinuar = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelMensagem);
			this.panel1.Location = new System.Drawing.Point(99, 167);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1720, 546);
			this.panel1.TabIndex = 0;
			// 
			// labelMensagem
			// 
			this.labelMensagem.AutoSize = true;
			this.labelMensagem.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelMensagem.Location = new System.Drawing.Point(4, 4);
			this.labelMensagem.Name = "labelMensagem";
			this.labelMensagem.Size = new System.Drawing.Size(0, 41);
			this.labelMensagem.TabIndex = 0;
			this.labelMensagem.Click += new System.EventHandler(this.labelMensagem_Click);
			// 
			// btnContinuar
			// 
			this.btnContinuar.BackColor = System.Drawing.SystemColors.Highlight;
			this.btnContinuar.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnContinuar.Location = new System.Drawing.Point(1611, 719);
			this.btnContinuar.Name = "btnContinuar";
			this.btnContinuar.Size = new System.Drawing.Size(208, 110);
			this.btnContinuar.TabIndex = 1;
			this.btnContinuar.Text = "Continuar";
			this.btnContinuar.UseVisualStyleBackColor = false;
			this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
			// 
			// TelaMensagem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.ClientSize = new System.Drawing.Size(1920, 1061);
			this.Controls.Add(this.btnContinuar);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "TelaMensagem";
			this.Load += new System.EventHandler(this.TelaMensagem_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelMensagem;
		private System.Windows.Forms.Button btnContinuar;
	}
}