namespace coldmakApp
{
    partial class FrmClientes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textIdCliente = new System.Windows.Forms.TextBox();
            this.textRg = new System.Windows.Forms.TextBox();
            this.textCpf = new System.Windows.Forms.TextBox();
            this.textCnpj = new System.Windows.Forms.TextBox();
            this.textNome = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textTelefone = new System.Windows.Forms.TextBox();
            this.textDataNasc = new System.Windows.Forms.TextBox();
            this.textIdadeCliente = new System.Windows.Forms.TextBox();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnRg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDataNasc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnIdade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(455, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cpf";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cnpj";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nome";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Telefone";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(253, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Data Nascimento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(532, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Idade";
            // 
            // textIdCliente
            // 
            this.textIdCliente.Location = new System.Drawing.Point(58, 53);
            this.textIdCliente.Name = "textIdCliente";
            this.textIdCliente.ReadOnly = true;
            this.textIdCliente.Size = new System.Drawing.Size(100, 22);
            this.textIdCliente.TabIndex = 10;
            // 
            // textRg
            // 
            this.textRg.Location = new System.Drawing.Point(58, 100);
            this.textRg.Name = "textRg";
            this.textRg.Size = new System.Drawing.Size(167, 22);
            this.textRg.TabIndex = 11;
            // 
            // textCpf
            // 
            this.textCpf.Location = new System.Drawing.Point(328, 100);
            this.textCpf.Name = "textCpf";
            this.textCpf.Size = new System.Drawing.Size(175, 22);
            this.textCpf.TabIndex = 12;
            // 
            // textCnpj
            // 
            this.textCnpj.Location = new System.Drawing.Point(617, 103);
            this.textCnpj.Name = "textCnpj";
            this.textCnpj.Size = new System.Drawing.Size(148, 22);
            this.textCnpj.TabIndex = 13;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(69, 170);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(299, 22);
            this.textNome.TabIndex = 14;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(459, 170);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(168, 22);
            this.textEmail.TabIndex = 15;
            // 
            // textTelefone
            // 
            this.textTelefone.Location = new System.Drawing.Point(86, 228);
            this.textTelefone.Name = "textTelefone";
            this.textTelefone.Size = new System.Drawing.Size(139, 22);
            this.textTelefone.TabIndex = 16;
            // 
            // textDataNasc
            // 
            this.textDataNasc.Location = new System.Drawing.Point(387, 231);
            this.textDataNasc.Name = "textDataNasc";
            this.textDataNasc.Size = new System.Drawing.Size(116, 22);
            this.textDataNasc.TabIndex = 17;
            // 
            // textIdadeCliente
            // 
            this.textIdadeCliente.Location = new System.Drawing.Point(606, 234);
            this.textIdadeCliente.Name = "textIdadeCliente";
            this.textIdadeCliente.Size = new System.Drawing.Size(100, 22);
            this.textIdadeCliente.TabIndex = 18;
            // 
            // dgvCliente
            // 
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnRg,
            this.ClnCpf,
            this.ClnCnpj,
            this.ClnNome,
            this.ClnEmail,
            this.ClnTelefone,
            this.ClnDataNasc,
            this.ClnIdade});
            this.dgvCliente.Location = new System.Drawing.Point(12, 332);
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.RowHeadersWidth = 51;
            this.dgvCliente.RowTemplate.Height = 24;
            this.dgvCliente.Size = new System.Drawing.Size(980, 150);
            this.dgvCliente.TabIndex = 19;
            // 
            // ClnId
            // 
            this.ClnId.HeaderText = "Id";
            this.ClnId.MinimumWidth = 6;
            this.ClnId.Name = "ClnId";
            this.ClnId.ReadOnly = true;
            this.ClnId.Visible = false;
            this.ClnId.Width = 125;
            // 
            // ClnRg
            // 
            this.ClnRg.HeaderText = "Rg";
            this.ClnRg.MinimumWidth = 6;
            this.ClnRg.Name = "ClnRg";
            this.ClnRg.Width = 125;
            // 
            // ClnCpf
            // 
            this.ClnCpf.HeaderText = "Cpf";
            this.ClnCpf.MinimumWidth = 6;
            this.ClnCpf.Name = "ClnCpf";
            this.ClnCpf.Width = 125;
            // 
            // ClnCnpj
            // 
            this.ClnCnpj.HeaderText = "Cnpj";
            this.ClnCnpj.MinimumWidth = 6;
            this.ClnCnpj.Name = "ClnCnpj";
            this.ClnCnpj.Width = 125;
            // 
            // ClnNome
            // 
            this.ClnNome.HeaderText = "Nome";
            this.ClnNome.MinimumWidth = 6;
            this.ClnNome.Name = "ClnNome";
            this.ClnNome.Width = 125;
            // 
            // ClnEmail
            // 
            this.ClnEmail.HeaderText = "Email";
            this.ClnEmail.MinimumWidth = 6;
            this.ClnEmail.Name = "ClnEmail";
            this.ClnEmail.Width = 125;
            // 
            // ClnTelefone
            // 
            this.ClnTelefone.HeaderText = "Telefone";
            this.ClnTelefone.MinimumWidth = 6;
            this.ClnTelefone.Name = "ClnTelefone";
            this.ClnTelefone.Width = 125;
            // 
            // ClnDataNasc
            // 
            this.ClnDataNasc.HeaderText = "Data Nascimento";
            this.ClnDataNasc.MinimumWidth = 6;
            this.ClnDataNasc.Name = "ClnDataNasc";
            this.ClnDataNasc.Width = 125;
            // 
            // ClnIdade
            // 
            this.ClnIdade.HeaderText = "Idade";
            this.ClnIdade.MinimumWidth = 6;
            this.ClnIdade.Name = "ClnIdade";
            this.ClnIdade.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(22, 504);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 20;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(328, 504);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 21;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(606, 504);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 22;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(923, 504);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 23;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 555);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvCliente);
            this.Controls.Add(this.textIdadeCliente);
            this.Controls.Add(this.textDataNasc);
            this.Controls.Add(this.textTelefone);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textCnpj);
            this.Controls.Add(this.textCpf);
            this.Controls.Add(this.textRg);
            this.Controls.Add(this.textIdCliente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCliente";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmClientes_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textIdCliente;
        private System.Windows.Forms.TextBox textRg;
        private System.Windows.Forms.TextBox textCpf;
        private System.Windows.Forms.TextBox textCnpj;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textTelefone;
        private System.Windows.Forms.TextBox textDataNasc;
        private System.Windows.Forms.TextBox textIdadeCliente;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnRg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDataNasc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdade;
        private System.Windows.Forms.Button btnListar;
    }
}