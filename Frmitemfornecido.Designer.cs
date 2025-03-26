namespace coldmakApp
{
    partial class FrmItemFornecido
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
            this.textIditemfor = new System.Windows.Forms.TextBox();
            this.textquant = new System.Windows.Forms.TextBox();
            this.textmod = new System.Windows.Forms.TextBox();
            this.textnome = new System.Windows.Forms.TextBox();
            this.dgvitfor = new System.Windows.Forms.DataGridView();
            this.Clniditemfornecido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnIdFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textIdFornecedor = new System.Windows.Forms.TextBox();
            this.textIdProduto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitfor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ITEM FORNECIDO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Iditemfornecido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "quantidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "modelo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "nome";
            // 
            // textIditemfor
            // 
            this.textIditemfor.Location = new System.Drawing.Point(118, 42);
            this.textIditemfor.Name = "textIditemfor";
            this.textIditemfor.ReadOnly = true;
            this.textIditemfor.Size = new System.Drawing.Size(100, 22);
            this.textIditemfor.TabIndex = 5;
            // 
            // textquant
            // 
            this.textquant.Location = new System.Drawing.Point(305, 42);
            this.textquant.Name = "textquant";
            this.textquant.Size = new System.Drawing.Size(100, 22);
            this.textquant.TabIndex = 6;
            // 
            // textmod
            // 
            this.textmod.Location = new System.Drawing.Point(485, 42);
            this.textmod.Name = "textmod";
            this.textmod.Size = new System.Drawing.Size(100, 22);
            this.textmod.TabIndex = 7;
            // 
            // textnome
            // 
            this.textnome.Location = new System.Drawing.Point(661, 42);
            this.textnome.Name = "textnome";
            this.textnome.Size = new System.Drawing.Size(100, 22);
            this.textnome.TabIndex = 8;
            // 
            // dgvitfor
            // 
            this.dgvitfor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitfor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clniditemfornecido,
            this.ClnIdFornecedor,
            this.ClnIdProduto,
            this.ClnQuantidade,
            this.ClnModelo,
            this.ClnNome});
            this.dgvitfor.Location = new System.Drawing.Point(16, 135);
            this.dgvitfor.Name = "dgvitfor";
            this.dgvitfor.RowHeadersWidth = 51;
            this.dgvitfor.RowTemplate.Height = 24;
            this.dgvitfor.Size = new System.Drawing.Size(768, 250);
            this.dgvitfor.TabIndex = 9;
            // 
            // Clniditemfornecido
            // 
            this.Clniditemfornecido.HeaderText = "Iditemfornecido";
            this.Clniditemfornecido.MinimumWidth = 6;
            this.Clniditemfornecido.Name = "Clniditemfornecido";
            this.Clniditemfornecido.Visible = false;
            this.Clniditemfornecido.Width = 125;
            // 
            // ClnIdFornecedor
            // 
            this.ClnIdFornecedor.HeaderText = "IdFornecedor";
            this.ClnIdFornecedor.MinimumWidth = 6;
            this.ClnIdFornecedor.Name = "ClnIdFornecedor";
            this.ClnIdFornecedor.Visible = false;
            this.ClnIdFornecedor.Width = 125;
            // 
            // ClnIdProduto
            // 
            this.ClnIdProduto.HeaderText = "IdProduto";
            this.ClnIdProduto.MinimumWidth = 6;
            this.ClnIdProduto.Name = "ClnIdProduto";
            this.ClnIdProduto.Visible = false;
            this.ClnIdProduto.Width = 125;
            // 
            // ClnQuantidade
            // 
            this.ClnQuantidade.HeaderText = "quantidade";
            this.ClnQuantidade.MinimumWidth = 6;
            this.ClnQuantidade.Name = "ClnQuantidade";
            this.ClnQuantidade.Width = 125;
            // 
            // ClnModelo
            // 
            this.ClnModelo.HeaderText = "modelo";
            this.ClnModelo.MinimumWidth = 6;
            this.ClnModelo.Name = "ClnModelo";
            this.ClnModelo.Width = 125;
            // 
            // ClnNome
            // 
            this.ClnNome.HeaderText = "nome";
            this.ClnNome.MinimumWidth = 6;
            this.ClnNome.Name = "ClnNome";
            this.ClnNome.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(16, 401);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(120, 35);
            this.btnInserir.TabIndex = 10;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(212, 401);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(120, 35);
            this.btnAtualizar.TabIndex = 11;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(416, 401);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(120, 35);
            this.btnDeletar.TabIndex = 12;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(664, 401);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(120, 35);
            this.btnListar.TabIndex = 13;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "IdFornecedor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "IdProduto";
            // 
            // textIdFornecedor
            // 
            this.textIdFornecedor.Location = new System.Drawing.Point(118, 74);
            this.textIdFornecedor.Name = "textIdFornecedor";
            this.textIdFornecedor.ReadOnly = true;
            this.textIdFornecedor.Size = new System.Drawing.Size(100, 22);
            this.textIdFornecedor.TabIndex = 16;
            // 
            // textIdProduto
            // 
            this.textIdProduto.Location = new System.Drawing.Point(305, 74);
            this.textIdProduto.Name = "textIdProduto";
            this.textIdProduto.ReadOnly = true;
            this.textIdProduto.Size = new System.Drawing.Size(100, 22);
            this.textIdProduto.TabIndex = 17;
            // 
            // FrmItemFornecido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textIdProduto);
            this.Controls.Add(this.textIdFornecedor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvitfor);
            this.Controls.Add(this.textnome);
            this.Controls.Add(this.textmod);
            this.Controls.Add(this.textquant);
            this.Controls.Add(this.textIditemfor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmItemFornecido";
            this.Text = "Frmitemfornecido";
            this.Load += new System.EventHandler(this.FrmItemFornecido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitfor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textIditemfor;
        private System.Windows.Forms.TextBox textquant;
        private System.Windows.Forms.TextBox textmod;
        private System.Windows.Forms.TextBox textnome;
        private System.Windows.Forms.DataGridView dgvitfor;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clniditemfornecido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textIdFornecedor;
        private System.Windows.Forms.TextBox textIdProduto;
    }
}