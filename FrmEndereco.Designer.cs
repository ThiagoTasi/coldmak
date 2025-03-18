namespace coldmakApp
{
    partial class FrmEnderecos
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
            this.textId = new System.Windows.Forms.TextBox();
            this.textCep = new System.Windows.Forms.TextBox();
            this.textLogra = new System.Windows.Forms.TextBox();
            this.textNumRes = new System.Windows.Forms.TextBox();
            this.textComple = new System.Windows.Forms.TextBox();
            this.textCidade = new System.Windows.Forms.TextBox();
            this.textBairro = new System.Windows.Forms.TextBox();
            this.textUf = new System.Windows.Forms.TextBox();
            this.dgvEndereco = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnLogra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnNumRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnComple = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnUf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndereco)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ENDERECO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cep";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Logradouro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Numero Residencial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(711, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Complemento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cidade";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Bairro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(533, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "UF";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(38, 73);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(100, 22);
            this.textId.TabIndex = 9;
            // 
            // textCep
            // 
            this.textCep.Location = new System.Drawing.Point(50, 115);
            this.textCep.Name = "textCep";
            this.textCep.Size = new System.Drawing.Size(123, 22);
            this.textCep.TabIndex = 10;
            // 
            // textLogra
            // 
            this.textLogra.Location = new System.Drawing.Point(262, 115);
            this.textLogra.Name = "textLogra";
            this.textLogra.Size = new System.Drawing.Size(245, 22);
            this.textLogra.TabIndex = 11;
            // 
            // textNumRes
            // 
            this.textNumRes.Location = new System.Drawing.Point(650, 115);
            this.textNumRes.Name = "textNumRes";
            this.textNumRes.Size = new System.Drawing.Size(55, 22);
            this.textNumRes.TabIndex = 12;
            // 
            // textComple
            // 
            this.textComple.Location = new System.Drawing.Point(799, 118);
            this.textComple.Name = "textComple";
            this.textComple.Size = new System.Drawing.Size(97, 22);
            this.textComple.TabIndex = 13;
            // 
            // textCidade
            // 
            this.textCidade.Location = new System.Drawing.Point(71, 189);
            this.textCidade.Name = "textCidade";
            this.textCidade.Size = new System.Drawing.Size(185, 22);
            this.textCidade.TabIndex = 14;
            // 
            // textBairro
            // 
            this.textBairro.Location = new System.Drawing.Point(323, 188);
            this.textBairro.Name = "textBairro";
            this.textBairro.Size = new System.Drawing.Size(184, 22);
            this.textBairro.TabIndex = 15;
            // 
            // textUf
            // 
            this.textUf.Location = new System.Drawing.Point(565, 189);
            this.textUf.Name = "textUf";
            this.textUf.Size = new System.Drawing.Size(100, 22);
            this.textUf.TabIndex = 16;
            // 
            // dgvEndereco
            // 
            this.dgvEndereco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEndereco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnCep,
            this.ClnLogra,
            this.ClnNumRes,
            this.ClnComple,
            this.ClnCidade,
            this.ClnBairro,
            this.ClnUf});
            this.dgvEndereco.Location = new System.Drawing.Point(12, 250);
            this.dgvEndereco.Name = "dgvEndereco";
            this.dgvEndereco.RowHeadersWidth = 51;
            this.dgvEndereco.RowTemplate.Height = 24;
            this.dgvEndereco.Size = new System.Drawing.Size(884, 150);
            this.dgvEndereco.TabIndex = 17;
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
            // ClnCep
            // 
            this.ClnCep.HeaderText = "Cep";
            this.ClnCep.MinimumWidth = 6;
            this.ClnCep.Name = "ClnCep";
            this.ClnCep.Width = 125;
            // 
            // ClnLogra
            // 
            this.ClnLogra.HeaderText = "Logradouro";
            this.ClnLogra.MinimumWidth = 6;
            this.ClnLogra.Name = "ClnLogra";
            this.ClnLogra.Width = 125;
            // 
            // ClnNumRes
            // 
            this.ClnNumRes.HeaderText = "Numero Residencial";
            this.ClnNumRes.MinimumWidth = 6;
            this.ClnNumRes.Name = "ClnNumRes";
            this.ClnNumRes.Width = 125;
            // 
            // ClnComple
            // 
            this.ClnComple.HeaderText = "Complemento";
            this.ClnComple.MinimumWidth = 6;
            this.ClnComple.Name = "ClnComple";
            this.ClnComple.Width = 125;
            // 
            // ClnCidade
            // 
            this.ClnCidade.HeaderText = "Cidade";
            this.ClnCidade.MinimumWidth = 6;
            this.ClnCidade.Name = "ClnCidade";
            this.ClnCidade.Width = 125;
            // 
            // ClnBairro
            // 
            this.ClnBairro.HeaderText = "Bairro";
            this.ClnBairro.MinimumWidth = 6;
            this.ClnBairro.Name = "ClnBairro";
            this.ClnBairro.Width = 125;
            // 
            // ClnUf
            // 
            this.ClnUf.HeaderText = "Uf";
            this.ClnUf.MinimumWidth = 6;
            this.ClnUf.Name = "ClnUf";
            this.ClnUf.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(13, 415);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 18;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(306, 415);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 19;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(536, 415);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 20;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(799, 415);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 21;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // FrmEnderecos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 450);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvEndereco);
            this.Controls.Add(this.textUf);
            this.Controls.Add(this.textBairro);
            this.Controls.Add(this.textCidade);
            this.Controls.Add(this.textComple);
            this.Controls.Add(this.textNumRes);
            this.Controls.Add(this.textLogra);
            this.Controls.Add(this.textCep);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmEnderecos";
            this.Text = "FrmEndereco";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndereco)).EndInit();
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
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textCep;
        private System.Windows.Forms.TextBox textLogra;
        private System.Windows.Forms.TextBox textNumRes;
        private System.Windows.Forms.TextBox textComple;
        private System.Windows.Forms.TextBox textCidade;
        private System.Windows.Forms.TextBox textBairro;
        private System.Windows.Forms.TextBox textUf;
        private System.Windows.Forms.DataGridView dgvEndereco;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnLogra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnNumRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnComple;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnBairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnUf;
    }
}