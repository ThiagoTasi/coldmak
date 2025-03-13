namespace coldmak
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnOrdem = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(338, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(71, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "COLDMAK";
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(462, 66);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(87, 23);
            this.btnCliente.TabIndex = 1;
            this.btnCliente.Text = "CLIENTE";
            this.btnCliente.UseVisualStyleBackColor = true;
          
            // 
            // btnProduto
            // 
            this.btnProduto.Location = new System.Drawing.Point(12, 66);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(87, 23);
            this.btnProduto.TabIndex = 2;
            this.btnProduto.Text = "PRODUTO";
            this.btnProduto.UseVisualStyleBackColor = true;
            
            // 
            // btnOrdem
            // 
            this.btnOrdem.Location = new System.Drawing.Point(219, 66);
            this.btnOrdem.Name = "btnOrdem";
            this.btnOrdem.Size = new System.Drawing.Size(87, 23);
            this.btnOrdem.TabIndex = 3;
            this.btnOrdem.Text = "ORDEM";
            this.btnOrdem.UseVisualStyleBackColor = true;
          
            // 
            // btnVenda
            // 
            this.btnVenda.Location = new System.Drawing.Point(701, 66);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(87, 23);
            this.btnVenda.TabIndex = 4;
            this.btnVenda.Text = "VENDA";
            this.btnVenda.UseVisualStyleBackColor = true;
          
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(701, 415);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(87, 23);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnVenda);
            this.Controls.Add(this.btnOrdem);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnOrdem;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnSair;
    }
}
