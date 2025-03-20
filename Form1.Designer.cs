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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnOrdem = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCaixa = new System.Windows.Forms.Button();
            this.btnEndereco = new System.Windows.Forms.Button();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnHistoricos = new System.Windows.Forms.Button();
            this.btnItempedido = new System.Windows.Forms.Button();
            this.btnNivel = new System.Windows.Forms.Button();
            this.btnSolicitacao = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(0, 65);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(123, 23);
            this.btnCliente.TabIndex = 1;
            this.btnCliente.Text = "CLIENTE";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click_1);
            // 
            // btnProduto
            // 
            this.btnProduto.Location = new System.Drawing.Point(0, 387);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(123, 23);
            this.btnProduto.TabIndex = 2;
            this.btnProduto.Text = "PRODUTO";
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click_1);
            // 
            // btnOrdem
            // 
            this.btnOrdem.Location = new System.Drawing.Point(0, 332);
            this.btnOrdem.Name = "btnOrdem";
            this.btnOrdem.Size = new System.Drawing.Size(123, 23);
            this.btnOrdem.TabIndex = 3;
            this.btnOrdem.Text = "ORDEM";
            this.btnOrdem.UseVisualStyleBackColor = true;
            this.btnOrdem.Click += new System.EventHandler(this.btnOrdem_Click_1);
            // 
            // btnVenda
            // 
            this.btnVenda.Location = new System.Drawing.Point(0, 507);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(123, 23);
            this.btnVenda.TabIndex = 4;
            this.btnVenda.Text = "VENDA";
            this.btnVenda.UseVisualStyleBackColor = true;
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1749, 930);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(109, 23);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click_1);
            // 
            // btnCaixa
            // 
            this.btnCaixa.Location = new System.Drawing.Point(0, 22);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(123, 23);
            this.btnCaixa.TabIndex = 6;
            this.btnCaixa.Text = "CAIXA";
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // btnEndereco
            // 
            this.btnEndereco.Location = new System.Drawing.Point(0, 107);
            this.btnEndereco.Name = "btnEndereco";
            this.btnEndereco.Size = new System.Drawing.Size(123, 23);
            this.btnEndereco.TabIndex = 7;
            this.btnEndereco.Text = "ENDERECO";
            this.btnEndereco.UseVisualStyleBackColor = true;
            this.btnEndereco.Click += new System.EventHandler(this.btnEndereco_Click);
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Location = new System.Drawing.Point(0, 150);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(123, 23);
            this.btnFornecedor.TabIndex = 8;
            this.btnFornecedor.Text = "FORNECEDOR";
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // btnHistoricos
            // 
            this.btnHistoricos.Location = new System.Drawing.Point(0, 196);
            this.btnHistoricos.Name = "btnHistoricos";
            this.btnHistoricos.Size = new System.Drawing.Size(123, 23);
            this.btnHistoricos.TabIndex = 9;
            this.btnHistoricos.Text = "HISTORICOS";
            this.btnHistoricos.UseVisualStyleBackColor = true;
            this.btnHistoricos.Click += new System.EventHandler(this.btnHistoricos_Click);
            // 
            // btnItempedido
            // 
            this.btnItempedido.Location = new System.Drawing.Point(-10, 243);
            this.btnItempedido.Name = "btnItempedido";
            this.btnItempedido.Size = new System.Drawing.Size(133, 23);
            this.btnItempedido.TabIndex = 10;
            this.btnItempedido.Text = "ITEM PEDIDO";
            this.btnItempedido.UseVisualStyleBackColor = true;
            this.btnItempedido.Click += new System.EventHandler(this.btnItempedido_Click);
            // 
            // btnNivel
            // 
            this.btnNivel.Location = new System.Drawing.Point(0, 289);
            this.btnNivel.Name = "btnNivel";
            this.btnNivel.Size = new System.Drawing.Size(123, 23);
            this.btnNivel.TabIndex = 11;
            this.btnNivel.Text = "NIVEL";
            this.btnNivel.UseVisualStyleBackColor = true;
            this.btnNivel.Click += new System.EventHandler(this.btnNivel_Click);
            // 
            // btnSolicitacao
            // 
            this.btnSolicitacao.Location = new System.Drawing.Point(0, 428);
            this.btnSolicitacao.Name = "btnSolicitacao";
            this.btnSolicitacao.Size = new System.Drawing.Size(123, 23);
            this.btnSolicitacao.TabIndex = 12;
            this.btnSolicitacao.Text = "SOLICITACAO";
            this.btnSolicitacao.UseVisualStyleBackColor = true;
            this.btnSolicitacao.Click += new System.EventHandler(this.btnSolicitacao_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(0, 466);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(123, 23);
            this.btnUsuario.TabIndex = 13;
            this.btnUsuario.Text = "USUARIO";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(388, 310);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1328, 437);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1870, 965);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnSolicitacao);
            this.Controls.Add(this.btnNivel);
            this.Controls.Add(this.btnItempedido);
            this.Controls.Add(this.btnHistoricos);
            this.Controls.Add(this.btnFornecedor);
            this.Controls.Add(this.btnEndereco);
            this.Controls.Add(this.btnCaixa);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnVenda);
            this.Controls.Add(this.btnOrdem);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.btnCliente);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnOrdem;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCaixa;
        private System.Windows.Forms.Button btnEndereco;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Button btnHistoricos;
        private System.Windows.Forms.Button btnItempedido;
        private System.Windows.Forms.Button btnNivel;
        private System.Windows.Forms.Button btnSolicitacao;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
