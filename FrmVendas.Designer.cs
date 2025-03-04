namespace coldmakApp
{
    partial class FrmVendas
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
            this.textIdvendas = new System.Windows.Forms.TextBox();
            this.textData = new System.Windows.Forms.TextBox();
            this.textPreco = new System.Windows.Forms.TextBox();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.textVendtot = new System.Windows.Forms.TextBox();
            this.dgvendas = new System.Windows.Forms.DataGridView();
            this.ClnIdvendas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnValTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvendas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "VENDAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "IdVendas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Preço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Desconto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Venda Total";
            // 
            // textIdvendas
            // 
            this.textIdvendas.Location = new System.Drawing.Point(85, 85);
            this.textIdvendas.Name = "textIdvendas";
            this.textIdvendas.ReadOnly = true;
            this.textIdvendas.Size = new System.Drawing.Size(100, 22);
            this.textIdvendas.TabIndex = 6;
            // 
            // textData
            // 
            this.textData.Location = new System.Drawing.Point(618, 202);
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(100, 22);
            this.textData.TabIndex = 7;
            // 
            // textPreco
            // 
            this.textPreco.Location = new System.Drawing.Point(67, 195);
            this.textPreco.Name = "textPreco";
            this.textPreco.Size = new System.Drawing.Size(100, 22);
            this.textPreco.TabIndex = 8;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(258, 196);
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(100, 22);
            this.textDesc.TabIndex = 9;
            // 
            // textVendtot
            // 
            this.textVendtot.Location = new System.Drawing.Point(457, 198);
            this.textVendtot.Name = "textVendtot";
            this.textVendtot.Size = new System.Drawing.Size(100, 22);
            this.textVendtot.TabIndex = 10;
            // 
            // dgvendas
            // 
            this.dgvendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnIdvendas,
            this.ClnData,
            this.ClnPreco,
            this.ClnDesc,
            this.ClnValTot});
            this.dgvendas.Location = new System.Drawing.Point(19, 243);
            this.dgvendas.Name = "dgvendas";
            this.dgvendas.RowHeadersWidth = 51;
            this.dgvendas.RowTemplate.Height = 24;
            this.dgvendas.Size = new System.Drawing.Size(747, 150);
            this.dgvendas.TabIndex = 11;
            // 
            // ClnIdvendas
            // 
            this.ClnIdvendas.HeaderText = "IdVendas";
            this.ClnIdvendas.MinimumWidth = 6;
            this.ClnIdvendas.Name = "ClnIdvendas";
            this.ClnIdvendas.Visible = false;
            this.ClnIdvendas.Width = 125;
            // 
            // ClnData
            // 
            this.ClnData.HeaderText = "Data";
            this.ClnData.MinimumWidth = 6;
            this.ClnData.Name = "ClnData";
            this.ClnData.Width = 125;
            // 
            // ClnPreco
            // 
            this.ClnPreco.HeaderText = "Preco";
            this.ClnPreco.MinimumWidth = 6;
            this.ClnPreco.Name = "ClnPreco";
            this.ClnPreco.Width = 125;
            // 
            // ClnDesc
            // 
            this.ClnDesc.HeaderText = "Desconto";
            this.ClnDesc.MinimumWidth = 6;
            this.ClnDesc.Name = "ClnDesc";
            this.ClnDesc.Width = 125;
            // 
            // ClnValTot
            // 
            this.ClnValTot.HeaderText = "Valor Total";
            this.ClnValTot.MinimumWidth = 6;
            this.ClnValTot.Name = "ClnValTot";
            this.ClnValTot.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(19, 415);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 12;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(299, 414);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 13;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(691, 415);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 14;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click_1);
            // 
            // FrmVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvendas);
            this.Controls.Add(this.textVendtot);
            this.Controls.Add(this.textDesc);
            this.Controls.Add(this.textPreco);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.textIdvendas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmVendas";
            this.Text = "FrmVendas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvendas)).EndInit();
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
        private System.Windows.Forms.TextBox textIdvendas;
        private System.Windows.Forms.TextBox textData;
        private System.Windows.Forms.TextBox textPreco;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.TextBox textVendtot;
        private System.Windows.Forms.DataGridView dgvendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnIdvendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnValTot;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
    }
}