namespace coldmakApp
{
    partial class FrmProdutos
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textIdProd = new System.Windows.Forms.TextBox();
            this.textIdForn = new System.Windows.Forms.TextBox();
            this.textCodBar = new System.Windows.Forms.TextBox();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.textValun = new System.Windows.Forms.TextBox();
            this.textUnidvend = new System.Windows.Forms.TextBox();
            this.textCladesc = new System.Windows.Forms.TextBox();
            this.textDatcad = new System.Windows.Forms.TextBox();
            this.textEstmin = new System.Windows.Forms.TextBox();
            this.dgvprod = new System.Windows.Forms.DataGridView();
            this.ClnIdprod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnIdforn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCodbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clndesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clnvalun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clnunidvend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clncladesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clndatcad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clnestmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clnimg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textCat = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IdProduto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Codigo Barras";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "IdFornecedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Decrição";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 195);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Valor Unitário";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 197);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Unidade Venda";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(343, 247);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Estoque MInimo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(476, 193);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Classe desconto";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 242);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Data Cadastro";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(588, 242);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Imagem";
            // 
            // textIdProd
            // 
            this.textIdProd.Location = new System.Drawing.Point(60, 60);
            this.textIdProd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textIdProd.Name = "textIdProd";
            this.textIdProd.ReadOnly = true;
            this.textIdProd.Size = new System.Drawing.Size(98, 20);
            this.textIdProd.TabIndex = 12;
            // 
            // textIdForn
            // 
            this.textIdForn.Location = new System.Drawing.Point(665, 60);
            this.textIdForn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textIdForn.Name = "textIdForn";
            this.textIdForn.ReadOnly = true;
            this.textIdForn.Size = new System.Drawing.Size(95, 20);
            this.textIdForn.TabIndex = 14;
            // 
            // textCodBar
            // 
            this.textCodBar.Location = new System.Drawing.Point(343, 128);
            this.textCodBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textCodBar.Name = "textCodBar";
            this.textCodBar.Size = new System.Drawing.Size(76, 20);
            this.textCodBar.TabIndex = 15;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(502, 120);
            this.textDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(258, 20);
            this.textDesc.TabIndex = 16;
            // 
            // textValun
            // 
            this.textValun.Location = new System.Drawing.Point(92, 195);
            this.textValun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textValun.Name = "textValun";
            this.textValun.Size = new System.Drawing.Size(76, 20);
            this.textValun.TabIndex = 17;
            // 
            // textUnidvend
            // 
            this.textUnidvend.Location = new System.Drawing.Point(274, 193);
            this.textUnidvend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textUnidvend.Name = "textUnidvend";
            this.textUnidvend.Size = new System.Drawing.Size(183, 20);
            this.textUnidvend.TabIndex = 18;
            // 
            // textCladesc
            // 
            this.textCladesc.Location = new System.Drawing.Point(582, 188);
            this.textCladesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textCladesc.Name = "textCladesc";
            this.textCladesc.Size = new System.Drawing.Size(224, 20);
            this.textCladesc.TabIndex = 19;
            // 
            // textDatcad
            // 
            this.textDatcad.Location = new System.Drawing.Point(91, 242);
            this.textDatcad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textDatcad.Name = "textDatcad";
            this.textDatcad.Size = new System.Drawing.Size(76, 20);
            this.textDatcad.TabIndex = 20;
            // 
            // textEstmin
            // 
            this.textEstmin.Location = new System.Drawing.Point(435, 242);
            this.textEstmin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textEstmin.Name = "textEstmin";
            this.textEstmin.Size = new System.Drawing.Size(150, 20);
            this.textEstmin.TabIndex = 21;
            // 
            // dgvprod
            // 
            this.dgvprod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvprod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnIdprod,
            this.ClnCat,
            this.ClnIdforn,
            this.ClnCodbar,
            this.Clndesc,
            this.Clnvalun,
            this.Clnunidvend,
            this.Clncladesc,
            this.Clndatcad,
            this.Clnestmin,
            this.Clnimg});
            this.dgvprod.Location = new System.Drawing.Point(9, 269);
            this.dgvprod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvprod.Name = "dgvprod";
            this.dgvprod.RowHeadersWidth = 51;
            this.dgvprod.RowTemplate.Height = 24;
            this.dgvprod.Size = new System.Drawing.Size(796, 122);
            this.dgvprod.TabIndex = 23;
            // 
            // ClnIdprod
            // 
            this.ClnIdprod.HeaderText = "IdProduto";
            this.ClnIdprod.MinimumWidth = 6;
            this.ClnIdprod.Name = "ClnIdprod";
            this.ClnIdprod.ReadOnly = true;
            this.ClnIdprod.Visible = false;
            this.ClnIdprod.Width = 125;
            // 
            // ClnCat
            // 
            this.ClnCat.HeaderText = "Categorias";
            this.ClnCat.MinimumWidth = 6;
            this.ClnCat.Name = "ClnCat";
            this.ClnCat.Width = 125;
            // 
            // ClnIdforn
            // 
            this.ClnIdforn.HeaderText = "IdFornecedor";
            this.ClnIdforn.MinimumWidth = 6;
            this.ClnIdforn.Name = "ClnIdforn";
            this.ClnIdforn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClnIdforn.Visible = false;
            this.ClnIdforn.Width = 125;
            // 
            // ClnCodbar
            // 
            this.ClnCodbar.HeaderText = "Codigo Barras";
            this.ClnCodbar.MinimumWidth = 6;
            this.ClnCodbar.Name = "ClnCodbar";
            this.ClnCodbar.Width = 125;
            // 
            // Clndesc
            // 
            this.Clndesc.HeaderText = "Descrição";
            this.Clndesc.MinimumWidth = 6;
            this.Clndesc.Name = "Clndesc";
            this.Clndesc.Width = 125;
            // 
            // Clnvalun
            // 
            this.Clnvalun.HeaderText = "Valor Unitário";
            this.Clnvalun.MinimumWidth = 6;
            this.Clnvalun.Name = "Clnvalun";
            this.Clnvalun.Width = 125;
            // 
            // Clnunidvend
            // 
            this.Clnunidvend.HeaderText = "Unidade Venda";
            this.Clnunidvend.MinimumWidth = 6;
            this.Clnunidvend.Name = "Clnunidvend";
            this.Clnunidvend.Width = 125;
            // 
            // Clncladesc
            // 
            this.Clncladesc.HeaderText = "Classe Desconto";
            this.Clncladesc.MinimumWidth = 6;
            this.Clncladesc.Name = "Clncladesc";
            this.Clncladesc.Width = 125;
            // 
            // Clndatcad
            // 
            this.Clndatcad.HeaderText = "Data Cadastro";
            this.Clndatcad.MinimumWidth = 6;
            this.Clndatcad.Name = "Clndatcad";
            this.Clndatcad.Width = 125;
            // 
            // Clnestmin
            // 
            this.Clnestmin.HeaderText = "Estoque Minimo";
            this.Clnestmin.MinimumWidth = 6;
            this.Clnestmin.Name = "Clnestmin";
            this.Clnestmin.Width = 125;
            // 
            // Clnimg
            // 
            this.Clnimg.HeaderText = "Imagem";
            this.Clnimg.MinimumWidth = 6;
            this.Clnimg.Name = "Clnimg";
            this.Clnimg.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(9, 405);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(56, 19);
            this.btnInserir.TabIndex = 24;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(380, 405);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(56, 19);
            this.btnAtualizar.TabIndex = 25;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(748, 405);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(56, 19);
            this.btnDeletar.TabIndex = 26;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Categoria";
            // 
            // textCat
            // 
            this.textCat.Location = new System.Drawing.Point(82, 135);
            this.textCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textCat.Name = "textCat";
            this.textCat.Size = new System.Drawing.Size(153, 20);
            this.textCat.TabIndex = 28;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(637, 214);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 50);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 444);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textCat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvprod);
            this.Controls.Add(this.textEstmin);
            this.Controls.Add(this.textDatcad);
            this.Controls.Add(this.textCladesc);
            this.Controls.Add(this.textUnidvend);
            this.Controls.Add(this.textValun);
            this.Controls.Add(this.textDesc);
            this.Controls.Add(this.textCodBar);
            this.Controls.Add(this.textIdForn);
            this.Controls.Add(this.textIdProd);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmProdutos";
            this.Text = "FrmProduto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvprod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textIdProd;
        private System.Windows.Forms.TextBox textIdForn;
        private System.Windows.Forms.TextBox textCodBar;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.TextBox textValun;
        private System.Windows.Forms.TextBox textUnidvend;
        private System.Windows.Forms.TextBox textCladesc;
        private System.Windows.Forms.TextBox textDatcad;
        private System.Windows.Forms.TextBox textEstmin;
        private System.Windows.Forms.DataGridView dgvprod;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdprod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdforn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCodbar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clndesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clnvalun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clnunidvend;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clncladesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clndatcad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clnestmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clnimg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}