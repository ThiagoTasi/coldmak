namespace coldmakApp
{
    partial class FrmFornecedores
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
            this.textId = new System.Windows.Forms.TextBox();
            this.textRazaosoc = new System.Windows.Forms.TextBox();
            this.textFanta = new System.Windows.Forms.TextBox();
            this.textCnpj = new System.Windows.Forms.TextBox();
            this.textTelefone = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.dgvFornecedor = new System.Windows.Forms.DataGridView();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnRazao_soc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnFanta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFornecedor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fornecedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Razao Social";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fantasia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(629, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cnpj";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Telefone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(48, 72);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(100, 22);
            this.textId.TabIndex = 7;
            // 
            // textRazaosoc
            // 
            this.textRazaosoc.Location = new System.Drawing.Point(123, 111);
            this.textRazaosoc.Name = "textRazaosoc";
            this.textRazaosoc.Size = new System.Drawing.Size(216, 22);
            this.textRazaosoc.TabIndex = 8;
            // 
            // textFanta
            // 
            this.textFanta.Location = new System.Drawing.Point(441, 111);
            this.textFanta.Name = "textFanta";
            this.textFanta.Size = new System.Drawing.Size(170, 22);
            this.textFanta.TabIndex = 9;
            // 
            // textCnpj
            // 
            this.textCnpj.Location = new System.Drawing.Point(669, 117);
            this.textCnpj.Name = "textCnpj";
            this.textCnpj.Size = new System.Drawing.Size(142, 22);
            this.textCnpj.TabIndex = 10;
            // 
            // textTelefone
            // 
            this.textTelefone.Location = new System.Drawing.Point(90, 163);
            this.textTelefone.Name = "textTelefone";
            this.textTelefone.Size = new System.Drawing.Size(100, 22);
            this.textTelefone.TabIndex = 11;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(266, 166);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(191, 22);
            this.textEmail.TabIndex = 12;
            // 
            // dgvFornecedor
            // 
            this.dgvFornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFornecedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnRazao_soc,
            this.ClnFanta,
            this.ClnCnpj,
            this.ClnTelefone,
            this.ClnEmail});
            this.dgvFornecedor.Location = new System.Drawing.Point(12, 216);
            this.dgvFornecedor.Name = "dgvFornecedor";
            this.dgvFornecedor.RowHeadersWidth = 51;
            this.dgvFornecedor.RowTemplate.Height = 24;
            this.dgvFornecedor.Size = new System.Drawing.Size(799, 150);
            this.dgvFornecedor.TabIndex = 13;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(12, 398);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 14;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(264, 398);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 15;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(513, 398);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 16;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click_1);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(736, 398);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 17;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // ClnId
            // 
            this.ClnId.HeaderText = "Id";
            this.ClnId.MinimumWidth = 6;
            this.ClnId.Name = "ClnId";
            this.ClnId.Width = 125;
            // 
            // ClnRazao_soc
            // 
            this.ClnRazao_soc.HeaderText = "Razao Social";
            this.ClnRazao_soc.MinimumWidth = 6;
            this.ClnRazao_soc.Name = "ClnRazao_soc";
            this.ClnRazao_soc.Width = 125;
            // 
            // ClnFanta
            // 
            this.ClnFanta.HeaderText = "Fantasia";
            this.ClnFanta.MinimumWidth = 6;
            this.ClnFanta.Name = "ClnFanta";
            this.ClnFanta.Width = 125;
            // 
            // ClnCnpj
            // 
            this.ClnCnpj.HeaderText = "Cnpj";
            this.ClnCnpj.MinimumWidth = 6;
            this.ClnCnpj.Name = "ClnCnpj";
            this.ClnCnpj.Width = 125;
            // 
            // ClnTelefone
            // 
            this.ClnTelefone.HeaderText = "Telefone";
            this.ClnTelefone.MinimumWidth = 6;
            this.ClnTelefone.Name = "ClnTelefone";
            this.ClnTelefone.Width = 125;
            // 
            // ClnEmail
            // 
            this.ClnEmail.HeaderText = "Email";
            this.ClnEmail.MinimumWidth = 6;
            this.ClnEmail.Name = "ClnEmail";
            this.ClnEmail.Width = 125;
            // 
            // FrmFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvFornecedor);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textTelefone);
            this.Controls.Add(this.textCnpj);
            this.Controls.Add(this.textFanta);
            this.Controls.Add(this.textRazaosoc);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmFornecedores";
            this.Text = "FrmFornecedor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFornecedor)).EndInit();
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
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textRazaosoc;
        private System.Windows.Forms.TextBox textFanta;
        private System.Windows.Forms.TextBox textCnpj;
        private System.Windows.Forms.TextBox textTelefone;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.DataGridView dgvFornecedor;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnRazao_soc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnFanta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCnpj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnEmail;
    }
}