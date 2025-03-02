namespace coldmakApp
{
    partial class FrmItemPedido
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
            this.textIdItemp = new System.Windows.Forms.TextBox();
            this.textIdord = new System.Windows.Forms.TextBox();
            this.textIdprod = new System.Windows.Forms.TextBox();
            this.textValorunit = new System.Windows.Forms.TextBox();
            this.textQuant = new System.Windows.Forms.TextBox();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.dgvitped = new System.Windows.Forms.DataGridView();
            this.ClnItped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnValunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnQuant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnOrdserv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnIdprod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitped)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Iditempedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Idordemdeservico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Idproduto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valor unitário";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Quantidade ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(543, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Desconto";
            // 
            // textIdItemp
            // 
            this.textIdItemp.Location = new System.Drawing.Point(105, 85);
            this.textIdItemp.Name = "textIdItemp";
            this.textIdItemp.ReadOnly = true;
            this.textIdItemp.Size = new System.Drawing.Size(100, 22);
            this.textIdItemp.TabIndex = 7;
            // 
            // textIdord
            // 
            this.textIdord.Location = new System.Drawing.Point(404, 82);
            this.textIdord.Name = "textIdord";
            this.textIdord.ReadOnly = true;
            this.textIdord.Size = new System.Drawing.Size(100, 22);
            this.textIdord.TabIndex = 8;
            // 
            // textIdprod
            // 
            this.textIdprod.Location = new System.Drawing.Point(627, 85);
            this.textIdprod.Name = "textIdprod";
            this.textIdprod.ReadOnly = true;
            this.textIdprod.Size = new System.Drawing.Size(100, 22);
            this.textIdprod.TabIndex = 9;
            // 
            // textValorunit
            // 
            this.textValorunit.Location = new System.Drawing.Point(108, 162);
            this.textValorunit.Name = "textValorunit";
            this.textValorunit.Size = new System.Drawing.Size(100, 22);
            this.textValorunit.TabIndex = 10;
            // 
            // textQuant
            // 
            this.textQuant.Location = new System.Drawing.Point(371, 161);
            this.textQuant.Name = "textQuant";
            this.textQuant.Size = new System.Drawing.Size(133, 22);
            this.textQuant.TabIndex = 11;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(615, 162);
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(112, 22);
            this.textDesc.TabIndex = 12;
            // 
            // dgvitped
            // 
            this.dgvitped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnItped,
            this.ClnValunit,
            this.ClnQuant,
            this.ClnDesc,
            this.ClnOrdserv,
            this.ClnIdprod});
            this.dgvitped.Location = new System.Drawing.Point(19, 233);
            this.dgvitped.Name = "dgvitped";
            this.dgvitped.RowHeadersWidth = 51;
            this.dgvitped.RowTemplate.Height = 24;
            this.dgvitped.Size = new System.Drawing.Size(708, 150);
            this.dgvitped.TabIndex = 13;
            // 
            // ClnItped
            // 
            this.ClnItped.HeaderText = "Iditempedido";
            this.ClnItped.MinimumWidth = 6;
            this.ClnItped.Name = "ClnItped";
            this.ClnItped.Visible = false;
            this.ClnItped.Width = 125;
            // 
            // ClnValunit
            // 
            this.ClnValunit.HeaderText = "Valor Unitario";
            this.ClnValunit.MinimumWidth = 6;
            this.ClnValunit.Name = "ClnValunit";
            this.ClnValunit.Width = 125;
            // 
            // ClnQuant
            // 
            this.ClnQuant.HeaderText = "Quantidade";
            this.ClnQuant.MinimumWidth = 6;
            this.ClnQuant.Name = "ClnQuant";
            this.ClnQuant.Width = 125;
            // 
            // ClnDesc
            // 
            this.ClnDesc.HeaderText = "Desconto";
            this.ClnDesc.MinimumWidth = 6;
            this.ClnDesc.Name = "ClnDesc";
            this.ClnDesc.Width = 125;
            // 
            // ClnOrdserv
            // 
            this.ClnOrdserv.HeaderText = "IdOrdemservico";
            this.ClnOrdserv.MinimumWidth = 6;
            this.ClnOrdserv.Name = "ClnOrdserv";
            this.ClnOrdserv.Visible = false;
            this.ClnOrdserv.Width = 125;
            // 
            // ClnIdprod
            // 
            this.ClnIdprod.HeaderText = "IdProduto";
            this.ClnIdprod.MinimumWidth = 6;
            this.ClnIdprod.Name = "ClnIdprod";
            this.ClnIdprod.Visible = false;
            this.ClnIdprod.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(28, 399);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 14;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(325, 398);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 15;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(652, 399);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 16;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // FrmItemPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvitped);
            this.Controls.Add(this.textDesc);
            this.Controls.Add(this.textQuant);
            this.Controls.Add(this.textValorunit);
            this.Controls.Add(this.textIdprod);
            this.Controls.Add(this.textIdord);
            this.Controls.Add(this.textIdItemp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmItemPedido";
            this.Text = "FrmItempedido";
            ((System.ComponentModel.ISupportInitialize)(this.dgvitped)).EndInit();
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
        private System.Windows.Forms.TextBox textIdItemp;
        private System.Windows.Forms.TextBox textIdord;
        private System.Windows.Forms.TextBox textIdprod;
        private System.Windows.Forms.TextBox textValorunit;
        private System.Windows.Forms.TextBox textQuant;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.DataGridView dgvitped;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnItped;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnValunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnQuant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnOrdserv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdprod;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
    }
}