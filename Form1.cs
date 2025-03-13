using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using coldmakClass; // Para acessar a classe Banco
using coldmakApp; // Adicionado para acessar os forms no namespace coldmakApp

namespace coldmak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            TestarConexao();
        }

        private void TestarConexao()
        {
            try
            {
                using (MySqlCommand cmd = Banco.Abrir())
                {
                    // Verifica o banco atual
                    cmd.CommandText = "SELECT DATABASE()";
                    var bancoAtual = cmd.ExecuteScalar();
                    MessageBox.Show($"Conexão bem-sucedida! Banco atual: {bancoAtual ?? "Nenhum banco selecionado"}");

                    // Teste simples
                    cmd.CommandText = "SELECT 1";
                    var resultado = cmd.ExecuteScalar();
                    MessageBox.Show($"Teste simples: {resultado}");
                } // O 'using' automaticamente fecha e descarta a conexão
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

        // Evento do botão Produto
        private void btnProduto_Click(object sender, EventArgs e)
        {
            FrmProdutos frm = new FrmProdutos();
            frm.Show();
        }

        // Evento do botão Ordem de Serviço
        private void btnOrdem_Click(object sender, EventArgs e)
        {
            FrmOrdemDeServico frm = new FrmOrdemDeServico();
            frm.Show();
        }

        // Evento do botão Cliente
        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.Show();
        }

        // Evento do botão Venda
        private void btnVenda_Click(object sender, EventArgs e)
        {
            FrmVendas frm = new FrmVendas();
            frm.Show();
        }

        // Evento do botão Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProduto_Click_1(object sender, EventArgs e)
        {
            FrmProdutos frmProdutos = new FrmProdutos();
            frmProdutos.IsMdiContainer = true;
            frmProdutos.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.IsMdiContainer = true;
            frmUsuarios.Show();
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            FrmCaixa frmCaixa = new FrmCaixa();
            frmCaixa.IsMdiContainer = true;
            frmCaixa.Show();
        }

        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.IsMdiContainer = true;
            frmClientes.Show();
        }

        private void btnEndereco_Click(object sender, EventArgs e)
        {
            FrmEnderecos frmEnderecos = new FrmEnderecos();
            frmEnderecos.IsMdiContainer = true;
            frmEnderecos.Show();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedores frmFornecedores = new FrmFornecedores();
            frmFornecedores.IsMdiContainer = true;
            frmFornecedores.Show();
        }

        private void btnHistoricos_Click(object sender, EventArgs e)
        {
            FrmHistoricos frmHistoricos = new FrmHistoricos();
            frmHistoricos.IsMdiContainer = true;
            frmHistoricos.Show();
        }

        private void btnItempedido_Click(object sender, EventArgs e)
        {
            FrmItemPedido frmItempedido = new FrmItemPedido();
            frmItempedido.IsMdiContainer = true;
            frmItempedido.Show();
        }

        private void btnNivel_Click(object sender, EventArgs e)
        {
            FrmNiveis frmNiveis = new FrmNiveis();
            frmNiveis.IsMdiContainer = true;
            frmNiveis.Show();
        }

        private void btnOrdem_Click_1(object sender, EventArgs e)
        {
            FrmOrdemDeServico FrmOrdemDeServico = new FrmOrdemDeServico();
            FrmOrdemDeServico.IsMdiContainer = true;
            FrmOrdemDeServico.Show();
        }

        private void btnSolicitacao_Click(object sender, EventArgs e)
        {
            FrmSolicitacaoAtendimento FrmSolicitacaoAtendimento = new FrmSolicitacaoAtendimento();
            FrmSolicitacaoAtendimento.IsMdiContainer = true;
            FrmSolicitacaoAtendimento.Show();
        }

        private void btnVenda_Click_1(object sender, EventArgs e)
        {
            FrmVendas FrmVendas = new FrmVendas();
            FrmVendas.IsMdiContainer = true;
            FrmVendas.Show();
        }
    }
}
