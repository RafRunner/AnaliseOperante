namespace AnaliseOperante.source.view {
	partial class CopiadorDeCoresView {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopiadorDeCoresView));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSelecionarLinhaDeBase = new System.Windows.Forms.Button();
			this.listViewLinhaDeBase = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSelecionarCondicao = new System.Windows.Forms.Button();
			this.listViewCondicao = new System.Windows.Forms.ListView();
			this.ColunaNomeExperimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnSelecionarLinhaDeBase);
			this.panel1.Controls.Add(this.listViewLinhaDeBase);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(12, 14);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.panel1.Size = new System.Drawing.Size(315, 408);
			this.panel1.TabIndex = 9;
			// 
			// btnSelecionarLinhaDeBase
			// 
			this.btnSelecionarLinhaDeBase.Location = new System.Drawing.Point(226, 370);
			this.btnSelecionarLinhaDeBase.Margin = new System.Windows.Forms.Padding(2);
			this.btnSelecionarLinhaDeBase.Name = "btnSelecionarLinhaDeBase";
			this.btnSelecionarLinhaDeBase.Size = new System.Drawing.Size(83, 29);
			this.btnSelecionarLinhaDeBase.TabIndex = 3;
			this.btnSelecionarLinhaDeBase.Text = "Selecionar";
			this.btnSelecionarLinhaDeBase.UseVisualStyleBackColor = true;
			this.btnSelecionarLinhaDeBase.Click += new System.EventHandler(this.btnSelecionarLinhaDeBase_Click);
			// 
			// listViewLinhaDeBase
			// 
			this.listViewLinhaDeBase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
			this.listViewLinhaDeBase.HideSelection = false;
			this.listViewLinhaDeBase.Location = new System.Drawing.Point(5, 28);
			this.listViewLinhaDeBase.Margin = new System.Windows.Forms.Padding(2);
			this.listViewLinhaDeBase.MultiSelect = false;
			this.listViewLinhaDeBase.Name = "listViewLinhaDeBase";
			this.listViewLinhaDeBase.Size = new System.Drawing.Size(305, 336);
			this.listViewLinhaDeBase.TabIndex = 1;
			this.listViewLinhaDeBase.UseCompatibleStateImageBehavior = false;
			this.listViewLinhaDeBase.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Nome";
			this.columnHeader2.Width = 300;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(-1, 4);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Linhas de Base Cadastradas";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.btnSelecionarCondicao);
			this.panel2.Controls.Add(this.listViewCondicao);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new System.Drawing.Point(333, 14);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.panel2.Size = new System.Drawing.Size(315, 408);
			this.panel2.TabIndex = 8;
			// 
			// btnSelecionarCondicao
			// 
			this.btnSelecionarCondicao.Location = new System.Drawing.Point(226, 370);
			this.btnSelecionarCondicao.Margin = new System.Windows.Forms.Padding(2);
			this.btnSelecionarCondicao.Name = "btnSelecionarCondicao";
			this.btnSelecionarCondicao.Size = new System.Drawing.Size(83, 29);
			this.btnSelecionarCondicao.TabIndex = 4;
			this.btnSelecionarCondicao.Text = "Selecionar";
			this.btnSelecionarCondicao.UseVisualStyleBackColor = true;
			this.btnSelecionarCondicao.Click += new System.EventHandler(this.btnSelecionarCondicao_Click);
			// 
			// listViewCondicao
			// 
			this.listViewCondicao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColunaNomeExperimento});
			this.listViewCondicao.HideSelection = false;
			this.listViewCondicao.Location = new System.Drawing.Point(5, 28);
			this.listViewCondicao.Margin = new System.Windows.Forms.Padding(2);
			this.listViewCondicao.MultiSelect = false;
			this.listViewCondicao.Name = "listViewCondicao";
			this.listViewCondicao.Size = new System.Drawing.Size(305, 336);
			this.listViewCondicao.TabIndex = 1;
			this.listViewCondicao.UseCompatibleStateImageBehavior = false;
			this.listViewCondicao.View = System.Windows.Forms.View.Details;
			// 
			// ColunaNomeExperimento
			// 
			this.ColunaNomeExperimento.Text = "Nome";
			this.ColunaNomeExperimento.Width = 300;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(-1, 4);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(146, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Condições Cadastradas";
			// 
			// CopiadorDeCoresView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(655, 426);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CopiadorDeCoresView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Copiar Cores";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSelecionarLinhaDeBase;
		private System.Windows.Forms.ListView listViewLinhaDeBase;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView listViewCondicao;
		private System.Windows.Forms.ColumnHeader ColunaNomeExperimento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSelecionarCondicao;
	}
}