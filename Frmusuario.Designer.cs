namespace coldmakApp
{
    partial class FrmUsuarios
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
            this.textId = new System.Windows.Forms.TextBox();
            this.textNome = new System.Windows.Forms.TextBox();
            this.textCpf = new System.Windows.Forms.TextBox();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clnendereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clncep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clnemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clntelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clnsenha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clndatanascimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnRg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.textRg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textEndereco = new System.Windows.Forms.TextBox();
            this.textCep = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textTelefone = new System.Windows.Forms.TextBox();
            this.textSenha = new System.Windows.Forms.TextBox();
            this.textDataNascimento = new System.Windows.Forms.TextBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "USUÁRIO";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cpf";
            this.label4.UseWaitCursor = true;
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(38, 45);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(67, 22);
            this.textId.TabIndex = 4;
            this.textId.UseWaitCursor = true;
            // 
            // textNome
            // 
            this.textNome.Location = new System.Drawing.Point(63, 84);
            this.textNome.Name = "textNome";
            this.textNome.Size = new System.Drawing.Size(340, 22);
            this.textNome.TabIndex = 5;
            this.textNome.UseWaitCursor = true;
            // 
            // textCpf
            // 
            this.textCpf.Location = new System.Drawing.Point(63, 163);
            this.textCpf.Name = "textCpf";
            this.textCpf.Size = new System.Drawing.Size(150, 22);
            this.textCpf.TabIndex = 6;
            this.textCpf.UseWaitCursor = true;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(107, 613);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 7;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.UseWaitCursor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(515, 613);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 8;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.UseWaitCursor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(950, 613);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 9;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.UseWaitCursor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.Clnendereco,
            this.Clncep,
            this.Clnemail,
            this.Clntelefone,
            this.Clnsenha,
            this.Clndatanascimento,
            this.ClnNome,
            this.ClnRg,
            this.Cpf});
            this.dgvUsuarios.Location = new System.Drawing.Point(107, 430);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.Size = new System.Drawing.Size(918, 150);
            this.dgvUsuarios.TabIndex = 10;
            this.dgvUsuarios.UseWaitCursor = true;
            // 
            // ClnId
            // 
            this.ClnId.HeaderText = "ID";
            this.ClnId.MinimumWidth = 6;
            this.ClnId.Name = "ClnId";
            this.ClnId.ReadOnly = true;
            this.ClnId.Visible = false;
            this.ClnId.Width = 50;
            // 
            // Clnendereco
            // 
            this.Clnendereco.HeaderText = "Endereco";
            this.Clnendereco.MinimumWidth = 6;
            this.Clnendereco.Name = "Clnendereco";
            this.Clnendereco.ReadOnly = true;
            this.Clnendereco.Width = 125;
            // 
            // Clncep
            // 
            this.Clncep.HeaderText = "Cep";
            this.Clncep.MinimumWidth = 6;
            this.Clncep.Name = "Clncep";
            this.Clncep.ReadOnly = true;
            this.Clncep.Width = 125;
            // 
            // Clnemail
            // 
            this.Clnemail.HeaderText = "Email";
            this.Clnemail.MinimumWidth = 6;
            this.Clnemail.Name = "Clnemail";
            this.Clnemail.ReadOnly = true;
            this.Clnemail.Width = 80;
            // 
            // Clntelefone
            // 
            this.Clntelefone.HeaderText = "Telefone";
            this.Clntelefone.MinimumWidth = 6;
            this.Clntelefone.Name = "Clntelefone";
            this.Clntelefone.ReadOnly = true;
            this.Clntelefone.Width = 80;
            // 
            // Clnsenha
            // 
            this.Clnsenha.HeaderText = "Senha";
            this.Clnsenha.MinimumWidth = 6;
            this.Clnsenha.Name = "Clnsenha";
            this.Clnsenha.ReadOnly = true;
            this.Clnsenha.Width = 60;
            // 
            // Clndatanascimento
            // 
            this.Clndatanascimento.HeaderText = "Data nascimento";
            this.Clndatanascimento.MinimumWidth = 6;
            this.Clndatanascimento.Name = "Clndatanascimento";
            this.Clndatanascimento.ReadOnly = true;
            this.Clndatanascimento.Width = 80;
            // 
            // ClnNome
            // 
            this.ClnNome.HeaderText = "Nome";
            this.ClnNome.MinimumWidth = 6;
            this.ClnNome.Name = "ClnNome";
            this.ClnNome.ReadOnly = true;
            this.ClnNome.Width = 120;
            // 
            // ClnRg
            // 
            this.ClnRg.HeaderText = "Rg";
            this.ClnRg.MinimumWidth = 6;
            this.ClnRg.Name = "ClnRg";
            this.ClnRg.ReadOnly = true;
            this.ClnRg.Width = 80;
            // 
            // Cpf
            // 
            this.Cpf.HeaderText = "Cpf";
            this.Cpf.MinimumWidth = 6;
            this.Cpf.Name = "Cpf";
            this.Cpf.ReadOnly = true;
            this.Cpf.Width = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rg";
            this.label5.UseWaitCursor = true;
            // 
            // textRg
            // 
            this.textRg.Location = new System.Drawing.Point(63, 114);
            this.textRg.Name = "textRg";
            this.textRg.Size = new System.Drawing.Size(100, 22);
            this.textRg.TabIndex = 12;
            this.textRg.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Endereco";
            this.label6.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cep";
            this.label7.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Email";
            this.label8.UseWaitCursor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Telefone";
            this.label9.UseWaitCursor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Senha";
            this.label10.UseWaitCursor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Data nascimento";
            this.label11.UseWaitCursor = true;
            // 
            // textEndereco
            // 
            this.textEndereco.Location = new System.Drawing.Point(86, 193);
            this.textEndereco.Name = "textEndereco";
            this.textEndereco.Size = new System.Drawing.Size(317, 22);
            this.textEndereco.TabIndex = 19;
            this.textEndereco.UseWaitCursor = true;
            // 
            // textCep
            // 
            this.textCep.Location = new System.Drawing.Point(86, 235);
            this.textCep.Name = "textCep";
            this.textCep.Size = new System.Drawing.Size(144, 22);
            this.textCep.TabIndex = 20;
            this.textCep.UseWaitCursor = true;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(86, 268);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(238, 22);
            this.textEmail.TabIndex = 21;
            this.textEmail.UseWaitCursor = true;
            // 
            // textTelefone
            // 
            this.textTelefone.Location = new System.Drawing.Point(81, 312);
            this.textTelefone.Name = "textTelefone";
            this.textTelefone.Size = new System.Drawing.Size(149, 22);
            this.textTelefone.TabIndex = 22;
            this.textTelefone.UseWaitCursor = true;
            // 
            // textSenha
            // 
            this.textSenha.Location = new System.Drawing.Point(81, 348);
            this.textSenha.Name = "textSenha";
            this.textSenha.Size = new System.Drawing.Size(88, 22);
            this.textSenha.TabIndex = 23;
            this.textSenha.UseSystemPasswordChar = true;
            this.textSenha.UseWaitCursor = true;
            // 
            // textDataNascimento
            // 
            this.textDataNascimento.Location = new System.Drawing.Point(133, 386);
            this.textDataNascimento.Name = "textDataNascimento";
            this.textDataNascimento.Size = new System.Drawing.Size(128, 22);
            this.textDataNascimento.TabIndex = 24;
            this.textDataNascimento.UseWaitCursor = true;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Location = new System.Drawing.Point(218, 350);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(59, 20);
            this.chkAtivo.TabIndex = 25;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            this.chkAtivo.UseWaitCursor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(371, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Nivel";
            this.label12.UseWaitCursor = true;
            // 
            // cmbNivel
            // 
            this.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Location = new System.Drawing.Point(416, 273);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(121, 24);
            this.cmbNivel.TabIndex = 27;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 701);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.textDataNascimento);
            this.Controls.Add(this.textSenha);
            this.Controls.Add(this.textTelefone);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textCep);
            this.Controls.Add(this.textEndereco);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textRg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.textCpf);
            this.Controls.Add(this.textNome);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmUsuarios";
            this.Text = "Frmusuario";
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textNome;
        private System.Windows.Forms.TextBox textCpf;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textRg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textEndereco;
        private System.Windows.Forms.TextBox textCep;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textTelefone;
        private System.Windows.Forms.TextBox textSenha;
        private System.Windows.Forms.TextBox textDataNascimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clnendereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clncep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clnemail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clntelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clnsenha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clndatanascimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnRg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbNivel;
    }
}