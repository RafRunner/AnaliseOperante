namespace AnaliseOperante.source.view {
	partial class ExperimentoCrud {
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
			this.btnSelecionarLinhaDeBase = new System.Windows.Forms.Button();
			this.listViewLinhaDeBase = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnAdicionarCondicao = new System.Windows.Forms.Button();
			this.listViewCondicao = new System.Windows.Forms.ListView();
			this.ColunaNomeExperimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnSalvarExperimento = new System.Windows.Forms.Button();
			this.listViewCondicoesSelecionadas = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textNome = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textLinhaDeBase = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnRemoverCondicao = new System.Windows.Forms.Button();
			this.btnRemoverLinhaDeBase = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnSelecionarLinhaDeBase);
			this.panel1.Controls.Add(this.listViewLinhaDeBase);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(12, 13);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.panel1.Size = new System.Drawing.Size(315, 384);
			this.panel1.TabIndex = 10;
			// 
			// btnSelecionarLinhaDeBase
			// 
			this.btnSelecionarLinhaDeBase.Location = new System.Drawing.Point(123, 348);
			this.btnSelecionarLinhaDeBase.Margin = new System.Windows.Forms.Padding(2);
			this.btnSelecionarLinhaDeBase.Name = "btnSelecionarLinhaDeBase";
			this.btnSelecionarLinhaDeBase.Size = new System.Drawing.Size(77, 27);
			this.btnSelecionarLinhaDeBase.TabIndex = 4;
			this.btnSelecionarLinhaDeBase.Text = "Selecionar";
			this.btnSelecionarLinhaDeBase.UseVisualStyleBackColor = true;
			this.btnSelecionarLinhaDeBase.Click += new System.EventHandler(this.btnSelecionarLinhaDeBase_Click);
			// 
			// listViewLinhaDeBase
			// 
			this.listViewLinhaDeBase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
			this.listViewLinhaDeBase.HideSelection = false;
			this.listViewLinhaDeBase.Location = new System.Drawing.Point(5, 26);
			this.listViewLinhaDeBase.Margin = new System.Windows.Forms.Padding(2);
			this.listViewLinhaDeBase.MultiSelect = false;
			this.listViewLinhaDeBase.Name = "listViewLinhaDeBase";
			this.listViewLinhaDeBase.Size = new System.Drawing.Size(305, 316);
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
			this.panel2.Controls.Add(this.btnAdicionarCondicao);
			this.panel2.Controls.Add(this.listViewCondicao);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Location = new System.Drawing.Point(333, 13);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.panel2.Size = new System.Drawing.Size(315, 384);
			this.panel2.TabIndex = 8;
			// 
			// btnAdicionarCondicao
			// 
			this.btnAdicionarCondicao.Location = new System.Drawing.Point(117, 348);
			this.btnAdicionarCondicao.Margin = new System.Windows.Forms.Padding(2);
			this.btnAdicionarCondicao.Name = "btnAdicionarCondicao";
			this.btnAdicionarCondicao.Size = new System.Drawing.Size(87, 27);
			this.btnAdicionarCondicao.TabIndex = 4;
			this.btnAdicionarCondicao.Text = "Adicionar";
			this.btnAdicionarCondicao.UseVisualStyleBackColor = true;
			this.btnAdicionarCondicao.Click += new System.EventHandler(this.btnAdicionarCondicao_Click);
			// 
			// listViewCondicao
			// 
			this.listViewCondicao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColunaNomeExperimento});
			this.listViewCondicao.HideSelection = false;
			this.listViewCondicao.Location = new System.Drawing.Point(5, 26);
			this.listViewCondicao.Margin = new System.Windows.Forms.Padding(2);
			this.listViewCondicao.MultiSelect = false;
			this.listViewCondicao.Name = "listViewCondicao";
			this.listViewCondicao.Size = new System.Drawing.Size(305, 316);
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
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.btnRemoverLinhaDeBase);
			this.panel3.Controls.Add(this.btnRemoverCondicao);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.textLinhaDeBase);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.textNome);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.btnSalvarExperimento);
			this.panel3.Controls.Add(this.listViewCondicoesSelecionadas);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Location = new System.Drawing.Point(654, 13);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.panel3.Size = new System.Drawing.Size(315, 384);
			this.panel3.TabIndex = 9;
			// 
			// btnSalvarExperimento
			// 
			this.btnSalvarExperimento.Location = new System.Drawing.Point(248, 346);
			this.btnSalvarExperimento.Margin = new System.Windows.Forms.Padding(2);
			this.btnSalvarExperimento.Name = "btnSalvarExperimento";
			this.btnSalvarExperimento.Size = new System.Drawing.Size(59, 27);
			this.btnSalvarExperimento.TabIndex = 3;
			this.btnSalvarExperimento.Text = "Salvar";
			this.btnSalvarExperimento.UseVisualStyleBackColor = true;
			this.btnSalvarExperimento.Click += new System.EventHandler(this.btnSalvarExperimento_Click);
			// 
			// listViewCondicoesSelecionadas
			// 
			this.listViewCondicoesSelecionadas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listViewCondicoesSelecionadas.HideSelection = false;
			this.listViewCondicoesSelecionadas.Location = new System.Drawing.Point(5, 181);
			this.listViewCondicoesSelecionadas.Margin = new System.Windows.Forms.Padding(2);
			this.listViewCondicoesSelecionadas.MultiSelect = false;
			this.listViewCondicoesSelecionadas.Name = "listViewCondicoesSelecionadas";
			this.listViewCondicoesSelecionadas.Size = new System.Drawing.Size(305, 161);
			this.listViewCondicoesSelecionadas.TabIndex = 1;
			this.listViewCondicoesSelecionadas.UseCompatibleStateImageBehavior = false;
			this.listViewCondicoesSelecionadas.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Nome";
			this.columnHeader1.Width = 300;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(-1, 4);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 21);
			this.label3.TabIndex = 0;
			this.label3.Text = "Experimento";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(2, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "Nome";
			// 
			// textNome
			// 
			this.textNome.Location = new System.Drawing.Point(6, 47);
			this.textNome.Name = "textNome";
			this.textNome.Size = new System.Drawing.Size(304, 23);
			this.textNome.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 17);
			this.label5.TabIndex = 6;
			this.label5.Text = "Linha de Base";
			// 
			// textLinhaDeBase
			// 
			this.textLinhaDeBase.Enabled = false;
			this.textLinhaDeBase.Location = new System.Drawing.Point(8, 93);
			this.textLinhaDeBase.Name = "textLinhaDeBase";
			this.textLinhaDeBase.Size = new System.Drawing.Size(304, 23);
			this.textLinhaDeBase.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 162);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 17);
			this.label6.TabIndex = 8;
			this.label6.Text = "Condições";
			// 
			// btnRemoverCondicao
			// 
			this.btnRemoverCondicao.Location = new System.Drawing.Point(5, 346);
			this.btnRemoverCondicao.Margin = new System.Windows.Forms.Padding(2);
			this.btnRemoverCondicao.Name = "btnRemoverCondicao";
			this.btnRemoverCondicao.Size = new System.Drawing.Size(142, 27);
			this.btnRemoverCondicao.TabIndex = 9;
			this.btnRemoverCondicao.Text = "Remover Condição";
			this.btnRemoverCondicao.UseVisualStyleBackColor = true;
			this.btnRemoverCondicao.Click += new System.EventHandler(this.btnRemoverCondicao_Click);
			// 
			// btnRemoverLinhaDeBase
			// 
			this.btnRemoverLinhaDeBase.Location = new System.Drawing.Point(8, 121);
			this.btnRemoverLinhaDeBase.Margin = new System.Windows.Forms.Padding(2);
			this.btnRemoverLinhaDeBase.Name = "btnRemoverLinhaDeBase";
			this.btnRemoverLinhaDeBase.Size = new System.Drawing.Size(142, 27);
			this.btnRemoverLinhaDeBase.TabIndex = 10;
			this.btnRemoverLinhaDeBase.Text = "Remover LdB";
			this.btnRemoverLinhaDeBase.UseVisualStyleBackColor = true;
			this.btnRemoverLinhaDeBase.Click += new System.EventHandler(this.btnRemoverLinhaDeBase_Click);
			// 
			// ExperimentoCrud
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(978, 408);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ExperimentoCrud";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ExperimentoCrud";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSelecionarLinhaDeBase;
		private System.Windows.Forms.ListView listViewLinhaDeBase;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnAdicionarCondicao;
		private System.Windows.Forms.ListView listViewCondicao;
		private System.Windows.Forms.ColumnHeader ColunaNomeExperimento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnRemoverLinhaDeBase;
		private System.Windows.Forms.Button btnRemoverCondicao;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textLinhaDeBase;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textNome;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSalvarExperimento;
		private System.Windows.Forms.ListView listViewCondicoesSelecionadas;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label3;
	}
}