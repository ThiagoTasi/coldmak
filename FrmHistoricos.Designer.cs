namespace coldmakApp
{
    partial class FrmHistoricos
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
            this.textIdHist = new System.Windows.Forms.TextBox();
            this.textIdCli = new System.Windows.Forms.TextBox();
            this.textIdord = new System.Windows.Forms.TextBox();
            this.textIdForn = new System.Windows.Forms.TextBox();
            this.textIdProd = new System.Windows.Forms.TextBox();
            this.textDatven = new System.Windows.Forms.TextBox();
            this.dgvhist = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhist)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Históricos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "IdHistóricos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "IdCliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Idordemdeserviço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "IdFornecedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "IdProduto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Data Venda";
            // 
            // textIdHist
            // 
            this.textIdHist.Location = new System.Drawing.Point(96, 78);
            this.textIdHist.Name = "textIdHist";
            this.textIdHist.Size = new System.Drawing.Size(100, 22);
            this.textIdHist.TabIndex = 7;
            // 
            // textIdCli
            // 
            this.textIdCli.Location = new System.Drawing.Point(282, 81);
            this.textIdCli.Name = "textIdCli";
            this.textIdCli.Size = new System.Drawing.Size(100, 22);
            this.textIdCli.TabIndex = 8;
            // 
            // textIdord
            // 
            this.textIdord.Location = new System.Drawing.Point(528, 87);
            this.textIdord.Name = "textIdord";
            this.textIdord.Size = new System.Drawing.Size(100, 22);
            this.textIdord.TabIndex = 9;
            // 
            // textIdForn
            // 
            this.textIdForn.Location = new System.Drawing.Point(106, 149);
            this.textIdForn.Name = "textIdForn";
            this.textIdForn.Size = new System.Drawing.Size(100, 22);
            this.textIdForn.TabIndex = 10;
            // 
            // textIdProd
            // 
            this.textIdProd.Location = new System.Drawing.Point(288, 152);
            this.textIdProd.Name = "textIdProd";
            this.textIdProd.Size = new System.Drawing.Size(100, 22);
            this.textIdProd.TabIndex = 11;
            // 
            // textDatven
            // 
            this.textDatven.Location = new System.Drawing.Point(501, 155);
            this.textDatven.Name = "textDatven";
            this.textDatven.Size = new System.Drawing.Size(100, 22);
            this.textDatven.TabIndex = 12;
            // 
            // dgvhist
            // 
            this.dgvhist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7});
            this.dgvhist.Location = new System.Drawing.Point(15, 201);
            this.dgvhist.Name = "dgvhist";
            this.dgvhist.RowHeadersWidth = 51;
            this.dgvhist.RowTemplate.Height = 24;
            this.dgvhist.Size = new System.Drawing.Size(749, 150);
            this.dgvhist.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IdHistoricos";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IdCliente";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "IdOrdemdeservico";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "IdFornecedor";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "IdProduto";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "IdDataVenda";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(15, 384);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 14;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(310, 383);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 15;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(689, 384);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 16;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click_1);
            // 
            // FrmHistoricos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvhist);
            this.Controls.Add(this.textDatven);
            this.Controls.Add(this.textIdProd);
            this.Controls.Add(this.textIdForn);
            this.Controls.Add(this.textIdord);
            this.Controls.Add(this.textIdCli);
            this.Controls.Add(this.textIdHist);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmHistoricos";
            this.Text = "FrmHistoricos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvhist)).EndInit();
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
        private System.Windows.Forms.TextBox textIdHist;
        private System.Windows.Forms.TextBox textIdCli;
        private System.Windows.Forms.TextBox textIdord;
        private System.Windows.Forms.TextBox textIdForn;
        private System.Windows.Forms.TextBox textIdProd;
        private System.Windows.Forms.TextBox textDatven;
        private System.Windows.Forms.DataGridView dgvhist;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}