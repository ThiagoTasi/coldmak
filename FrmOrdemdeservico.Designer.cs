namespace coldmakApp
{
    partial class FrmOrdemDeServico
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
            this.textId = new System.Windows.Forms.TextBox();
            this.textData = new System.Windows.Forms.TextBox();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.textVato = new System.Windows.Forms.TextBox();
            this.dgvords = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnVato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textIdusu = new System.Windows.Forms.TextBox();
            this.textIdcli = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvords)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ordem de servico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Desconto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor total";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(47, 78);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(100, 22);
            this.textId.TabIndex = 6;
            // 
            // textData
            // 
            this.textData.Location = new System.Drawing.Point(71, 133);
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(100, 22);
            this.textData.TabIndex = 7;
            // 
            // textStatus
            // 
            this.textStatus.Location = new System.Drawing.Point(238, 130);
            this.textStatus.Name = "textStatus";
            this.textStatus.Size = new System.Drawing.Size(132, 22);
            this.textStatus.TabIndex = 8;
            // 
            // textDesc
            // 
            this.textDesc.Location = new System.Drawing.Point(460, 130);
            this.textDesc.Name = "textDesc";
            this.textDesc.Size = new System.Drawing.Size(121, 22);
            this.textDesc.TabIndex = 9;
            // 
            // textVato
            // 
            this.textVato.Location = new System.Drawing.Point(673, 133);
            this.textVato.Name = "textVato";
            this.textVato.Size = new System.Drawing.Size(168, 22);
            this.textVato.TabIndex = 10;
            // 
            // dgvords
            // 
            this.dgvords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnData,
            this.ClnStatus,
            this.ClnDesc,
            this.ClnVato});
            this.dgvords.Location = new System.Drawing.Point(16, 252);
            this.dgvords.Name = "dgvords";
            this.dgvords.RowHeadersWidth = 51;
            this.dgvords.RowTemplate.Height = 24;
            this.dgvords.Size = new System.Drawing.Size(825, 150);
            this.dgvords.TabIndex = 11;
            // 
            // ClnId
            // 
            this.ClnId.HeaderText = "Id";
            this.ClnId.MinimumWidth = 6;
            this.ClnId.Name = "ClnId";
            this.ClnId.Visible = false;
            this.ClnId.Width = 125;
            // 
            // ClnData
            // 
            this.ClnData.HeaderText = "Data";
            this.ClnData.MinimumWidth = 6;
            this.ClnData.Name = "ClnData";
            this.ClnData.Width = 125;
            // 
            // ClnStatus
            // 
            this.ClnStatus.HeaderText = "Status";
            this.ClnStatus.MinimumWidth = 6;
            this.ClnStatus.Name = "ClnStatus";
            this.ClnStatus.Width = 125;
            // 
            // ClnDesc
            // 
            this.ClnDesc.HeaderText = "Desconto";
            this.ClnDesc.MinimumWidth = 6;
            this.ClnDesc.Name = "ClnDesc";
            this.ClnDesc.Width = 125;
            // 
            // ClnVato
            // 
            this.ClnVato.HeaderText = "Valor total";
            this.ClnVato.MinimumWidth = 6;
            this.ClnVato.Name = "ClnVato";
            this.ClnVato.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(16, 415);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 12;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click_1);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(366, 415);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 13;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(766, 415);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 14;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Idusuario";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(651, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Idcliente";
            // 
            // textIdusu
            // 
            this.textIdusu.Location = new System.Drawing.Point(379, 78);
            this.textIdusu.Name = "textIdusu";
            this.textIdusu.ReadOnly = true;
            this.textIdusu.Size = new System.Drawing.Size(100, 22);
            this.textIdusu.TabIndex = 17;
            // 
            // textIdcli
            // 
            this.textIdcli.Location = new System.Drawing.Point(714, 83);
            this.textIdcli.Name = "textIdcli";
            this.textIdcli.ReadOnly = true;
            this.textIdcli.Size = new System.Drawing.Size(100, 22);
            this.textIdcli.TabIndex = 18;
            // 
            // FrmOrdemDeServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 450);
            this.Controls.Add(this.textIdcli);
            this.Controls.Add(this.textIdusu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvords);
            this.Controls.Add(this.textVato);
            this.Controls.Add(this.textDesc);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmOrdemDeServico";
            this.Text = "FrmOrdemdeservico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvords)).EndInit();
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
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textData;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.TextBox textVato;
        private System.Windows.Forms.DataGridView dgvords;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnVato;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textIdusu;
        private System.Windows.Forms.TextBox textIdcli;
    }
}