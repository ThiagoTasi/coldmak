namespace coldmakApp
{
    partial class FrmCaixa
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
            this.textIdCaixa = new System.Windows.Forms.TextBox();
            this.textIdUsuario = new System.Windows.Forms.TextBox();
            this.textDatab = new System.Windows.Forms.TextBox();
            this.textSalini = new System.Windows.Forms.TextBox();
            this.textStt = new System.Windows.Forms.TextBox();
            this.dgvcaixa = new System.Windows.Forms.DataGridView();
            this.ClnIdcaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnIdUsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDatab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnSalini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcaixa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caixa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "IdCaixa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "IdUsuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data Abertura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Saldo Inicial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(531, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status";
            // 
            // textIdCaixa
            // 
            this.textIdCaixa.Location = new System.Drawing.Point(82, 74);
            this.textIdCaixa.Name = "textIdCaixa";
            this.textIdCaixa.ReadOnly = true;
            this.textIdCaixa.Size = new System.Drawing.Size(100, 22);
            this.textIdCaixa.TabIndex = 6;
            // 
            // textIdUsuario
            // 
            this.textIdUsuario.Location = new System.Drawing.Point(591, 88);
            this.textIdUsuario.Name = "textIdUsuario";
            this.textIdUsuario.ReadOnly = true;
            this.textIdUsuario.Size = new System.Drawing.Size(100, 22);
            this.textIdUsuario.TabIndex = 7;
            // 
            // textDatab
            // 
            this.textDatab.Location = new System.Drawing.Point(112, 151);
            this.textDatab.Name = "textDatab";
            this.textDatab.Size = new System.Drawing.Size(100, 22);
            this.textDatab.TabIndex = 8;
            // 
            // textSalini
            // 
            this.textSalini.Location = new System.Drawing.Point(351, 151);
            this.textSalini.Name = "textSalini";
            this.textSalini.Size = new System.Drawing.Size(100, 22);
            this.textSalini.TabIndex = 9;
            // 
            // textStt
            // 
            this.textStt.Location = new System.Drawing.Point(591, 154);
            this.textStt.Name = "textStt";
            this.textStt.Size = new System.Drawing.Size(100, 22);
            this.textStt.TabIndex = 10;
            // 
            // dgvcaixa
            // 
            this.dgvcaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnIdcaixa,
            this.ClnIdUsu,
            this.ColDatab,
            this.ClnSalini,
            this.ClnStt});
            this.dgvcaixa.Location = new System.Drawing.Point(15, 215);
            this.dgvcaixa.Name = "dgvcaixa";
            this.dgvcaixa.RowHeadersWidth = 51;
            this.dgvcaixa.RowTemplate.Height = 24;
            this.dgvcaixa.Size = new System.Drawing.Size(676, 150);
            this.dgvcaixa.TabIndex = 11;
            // 
            // ClnIdcaixa
            // 
            this.ClnIdcaixa.HeaderText = "IdCaixa";
            this.ClnIdcaixa.MinimumWidth = 6;
            this.ClnIdcaixa.Name = "ClnIdcaixa";
            this.ClnIdcaixa.Visible = false;
            this.ClnIdcaixa.Width = 125;
            // 
            // ClnIdUsu
            // 
            this.ClnIdUsu.HeaderText = "IdUsuario";
            this.ClnIdUsu.MinimumWidth = 6;
            this.ClnIdUsu.Name = "ClnIdUsu";
            this.ClnIdUsu.Visible = false;
            this.ClnIdUsu.Width = 125;
            // 
            // ColDatab
            // 
            this.ColDatab.HeaderText = "Data Abertura";
            this.ColDatab.MinimumWidth = 6;
            this.ColDatab.Name = "ColDatab";
            this.ColDatab.Width = 125;
            // 
            // ClnSalini
            // 
            this.ClnSalini.HeaderText = "Saldo Inicial";
            this.ClnSalini.MinimumWidth = 6;
            this.ClnSalini.Name = "ClnSalini";
            this.ClnSalini.Width = 125;
            // 
            // ClnStt
            // 
            this.ClnStt.HeaderText = "Status";
            this.ClnStt.MinimumWidth = 6;
            this.ClnStt.Name = "ClnStt";
            this.ClnStt.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(16, 386);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 12;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(298, 386);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 13;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(616, 386);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 14;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
          
            // 
            // FrmCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvcaixa);
            this.Controls.Add(this.textStt);
            this.Controls.Add(this.textSalini);
            this.Controls.Add(this.textDatab);
            this.Controls.Add(this.textIdUsuario);
            this.Controls.Add(this.textIdCaixa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCaixa";
            this.Text = "FrmCaixa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvcaixa)).EndInit();
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
        private System.Windows.Forms.TextBox textIdCaixa;
        private System.Windows.Forms.TextBox textIdUsuario;
        private System.Windows.Forms.TextBox textDatab;
        private System.Windows.Forms.TextBox textSalini;
        private System.Windows.Forms.TextBox textStt;
        private System.Windows.Forms.DataGridView dgvcaixa;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdcaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdUsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDatab;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnSalini;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnStt;
    }
}