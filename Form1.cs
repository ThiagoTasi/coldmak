using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using coldmakClass; // Para acessar a classe Banco
using coldmakApp; // Para acessar os forms no namespace coldmakApp

namespace coldmak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Define Form1 como contêiner MDI
        }

        private void Form1_Load(object sender, EventArgs e) // Corrigido para Form1_Load
        {
            TestarConexao();
        }

        private void TestarConexao()
        {
            try
            {
                using (MySqlCommand cmd = Banco.Abrir())
                {
                    cmd.CommandText = "SELECT DATABASE()";
                    var bancoAtual = cmd.ExecuteScalar();
                    MessageBox.Show($"Conexão bem-sucedida! Banco atual: {bancoAtual ?? "Nenhum banco selecionado"}");

                    cmd.CommandText = "SELECT 1";
                    var resultado = cmd.ExecuteScalar();
                    MessageBox.Show($"Teste simples: {resultado}");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco: {ex.Message} (Código: {ex.Number})");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            FrmCaixa frm = new FrmCaixa();
            frm.MdiParent = this; // Define Form1 como pai
            frm.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnEndereco_Click(object sender, EventArgs e)
        {
            FrmEnderecos frm = new FrmEnderecos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedores frm = new FrmFornecedores();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnHistoricos_Click(object sender, EventArgs e)
        {
            FrmHistoricos frm = new FrmHistoricos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnItempedido_Click(object sender, EventArgs e)
        {
            FrmItemPedido frm = new FrmItemPedido();
            frm.MdiParent = this;
            frm.Show();
        }
        
            

        private void btnNivel_Click(object sender, EventArgs e)
        {
            FrmNiveis frm = new FrmNiveis();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnOrdem_Click(object sender, EventArgs e)
        {
            FrmOrdemDeServico frm = new FrmOrdemDeServico();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            FrmProdutos frm = new FrmProdutos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnSolicitacao_Click(object sender, EventArgs e)
        {
            FrmSolicitacaodeAtendimento frm = new FrmSolicitacaodeAtendimento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            FrmVendas frm = new FrmVendas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnItemfor_Click_1(object sender, EventArgs e)
        {
            FrmItemFornecido frm = new FrmItemFornecido();
            frm.MdiParent = this;
            frm.Show();
        }

      }

    }
