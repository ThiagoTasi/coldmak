namespace coldmakApp
{
    partial class FrmSolicitacaodeAtendimento
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
            this.textIdSolicitacaodeAtendimento = new System.Windows.Forms.TextBox();
            this.textDatag = new System.Windows.Forms.TextBox();
            this.textTipserv = new System.Windows.Forms.TextBox();
            this.dgvsolaten = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDatag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnHoag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnTipserv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.maskedtextHorarioAgendamento = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsolaten)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitação de atendimento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data agendamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Horário  agendamento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(549, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo serviço";
            // 
            // textIdSolicitacaodeAtendimento
            // 
            this.textIdSolicitacaodeAtendimento.Location = new System.Drawing.Point(52, 87);
            this.textIdSolicitacaodeAtendimento.Name = "textIdSolicitacaodeAtendimento";
            this.textIdSolicitacaodeAtendimento.ReadOnly = true;
            this.textIdSolicitacaodeAtendimento.Size = new System.Drawing.Size(100, 22);
            this.textIdSolicitacaodeAtendimento.TabIndex = 5;
            // 
            // textDatag
            // 
            this.textDatag.Location = new System.Drawing.Point(146, 126);
            this.textDatag.Name = "textDatag";
            this.textDatag.Size = new System.Drawing.Size(100, 22);
            this.textDatag.TabIndex = 6;
            // 
            // textTipserv
            // 
            this.textTipserv.Location = new System.Drawing.Point(646, 130);
            this.textTipserv.Name = "textTipserv";
            this.textTipserv.Size = new System.Drawing.Size(100, 22);
            this.textTipserv.TabIndex = 8;
            // 
            // dgvsolaten
            // 
            this.dgvsolaten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsolaten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnDatag,
            this.ClnHoag,
            this.ClnTipserv});
            this.dgvsolaten.Location = new System.Drawing.Point(19, 206);
            this.dgvsolaten.Name = "dgvsolaten";
            this.dgvsolaten.RowHeadersWidth = 51;
            this.dgvsolaten.RowTemplate.Height = 24;
            this.dgvsolaten.Size = new System.Drawing.Size(727, 150);
            this.dgvsolaten.TabIndex = 9;
            // 
            // ClnId
            // 
            this.ClnId.HeaderText = "Id";
            this.ClnId.MinimumWidth = 6;
            this.ClnId.Name = "ClnId";
            this.ClnId.Visible = false;
            this.ClnId.Width = 125;
            // 
            // ClnDatag
            // 
            this.ClnDatag.HeaderText = "Data agendamento";
            this.ClnDatag.MinimumWidth = 6;
            this.ClnDatag.Name = "ClnDatag";
            this.ClnDatag.Width = 125;
            // 
            // ClnHoag
            // 
            this.ClnHoag.HeaderText = "Horario agendamento";
            this.ClnHoag.MinimumWidth = 6;
            this.ClnHoag.Name = "ClnHoag";
            this.ClnHoag.Width = 125;
            // 
            // ClnTipserv
            // 
            this.ClnTipserv.HeaderText = "Tipo servico";
            this.ClnTipserv.MinimumWidth = 6;
            this.ClnTipserv.Name = "ClnTipserv";
            this.ClnTipserv.Width = 125;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(19, 375);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 10;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click_1);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(329, 375);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 11;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(671, 375);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 12;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // maskedtextHorarioAgendamento
            // 
            this.maskedtextHorarioAgendamento.Location = new System.Drawing.Point(410, 130);
            this.maskedtextHorarioAgendamento.Name = "maskedtextHorarioAgendamento";
            this.maskedtextHorarioAgendamento.Size = new System.Drawing.Size(100, 22);
            this.maskedtextHorarioAgendamento.TabIndex = 13;
            // 
            // FrmSolicitacaodeAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 450);
            this.Controls.Add(this.maskedtextHorarioAgendamento);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dgvsolaten);
            this.Controls.Add(this.textTipserv);
            this.Controls.Add(this.textDatag);
            this.Controls.Add(this.textIdSolicitacaodeAtendimento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmSolicitacaodeAtendimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSolicitacadeatendimento";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvsolaten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textIdSolicitacaodeAtendimento;
        private System.Windows.Forms.TextBox textDatag;
        private System.Windows.Forms.TextBox textTipserv;
        private System.Windows.Forms.DataGridView dgvsolaten;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDatag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnHoag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnTipserv;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.MaskedTextBox maskedtextHorarioAgendamento;
    }
}