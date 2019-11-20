namespace AnaliseOperante.source.view {
	partial class GeradorRelatoriosView {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeradorRelatoriosView));
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnSelecionarExperimento = new System.Windows.Forms.Button();
			this.listViewExperimento = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label3 = new System.Windows.Forms.Label();
			this.btnDeletarExperimento = new System.Windows.Forms.Button();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.btnDeletarExperimento);
			this.panel3.Controls.Add(this.btnSelecionarExperimento);
			this.panel3.Controls.Add(this.listViewExperimento);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Location = new System.Drawing.Point(12, 13);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.panel3.Size = new System.Drawing.Size(315, 384);
			this.panel3.TabIndex = 7;
			// 
			// btnSelecionarExperimento
			// 
			this.btnSelecionarExperimento.Location = new System.Drawing.Point(190, 348);
			this.btnSelecionarExperimento.Margin = new System.Windows.Forms.Padding(2);
			this.btnSelecionarExperimento.Name = "btnSelecionarExperimento";
			this.btnSelecionarExperimento.Size = new System.Drawing.Size(118, 27);
			this.btnSelecionarExperimento.TabIndex = 4;
			this.btnSelecionarExperimento.Text = "Gerar Relatório";
			this.btnSelecionarExperimento.UseVisualStyleBackColor = true;
			this.btnSelecionarExperimento.Click += new System.EventHandler(this.btnSelecionarExperimento_Click);
			// 
			// listViewExperimento
			// 
			this.listViewExperimento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listViewExperimento.HideSelection = false;
			this.listViewExperimento.Location = new System.Drawing.Point(5, 26);
			this.listViewExperimento.Margin = new System.Windows.Forms.Padding(2);
			this.listViewExperimento.MultiSelect = false;
			this.listViewExperimento.Name = "listViewExperimento";
			this.listViewExperimento.Size = new System.Drawing.Size(305, 316);
			this.listViewExperimento.TabIndex = 1;
			this.listViewExperimento.UseCompatibleStateImageBehavior = false;
			this.listViewExperimento.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Nome";
			this.columnHeader1.Width = 300;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(-1, 4);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(154, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Experimentos Realizados";
			// 
			// btnDeletarExperimento
			// 
			this.btnDeletarExperimento.Location = new System.Drawing.Point(5, 348);
			this.btnDeletarExperimento.Margin = new System.Windows.Forms.Padding(2);
			this.btnDeletarExperimento.Name = "btnDeletarExperimento";
			this.btnDeletarExperimento.Size = new System.Drawing.Size(71, 27);
			this.btnDeletarExperimento.TabIndex = 5;
			this.btnDeletarExperimento.Text = "Deletar";
			this.btnDeletarExperimento.UseVisualStyleBackColor = true;
			this.btnDeletarExperimento.Click += new System.EventHandler(this.btnDeletarExperimento_Click);
			// 
			// GeradorRelatoriosView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 406);
			this.Controls.Add(this.panel3);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "GeradorRelatoriosView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gerar Relatórios";
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnSelecionarExperimento;
		private System.Windows.Forms.ListView listViewExperimento;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnDeletarExperimento;
	}
}