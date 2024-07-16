using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Forms.Properties;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaEnderecoForm : Form
    {
        private readonly ServicoEndereco _servicoEndereco;
        private FiltroEnderecoUserControl _controladorFiltro;
        private PrivateFontCollection _pixeboy;

        public TelaEnderecoForm(ServicoEndereco servicoEndereco)
        {
            _servicoEndereco = servicoEndereco;
            InitializeComponent();
        }

        private void AoPintarTela(object sender, PaintEventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.None)
            {
                const int Tamanho = 2;
                const int xInicioRetanguloExterior = 4;
                const int yInicioRetanguloExterior = 6;
                const int xInicioRetanguloInterior = 8;
                const int yInicioRetanguloInterior = 10;

                using (Pen caneta = new Pen(Color.White, Tamanho))
                {
                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloExterior,
                                                                   yInicioRetanguloExterior,
                                                                   Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(null);

            IniciaLizaControladorFiltro();
            InicializaFontePixeBoy();
            InicializaCabecalhoDaGrade();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoPintarPainelLateral(object sender, PaintEventArgs e)
        {
            if (painelLateral.BorderStyle == BorderStyle.None)
            {
                const int Tamanho = 2;
                const int xInicioRetanguloExterior = 4;
                const int yInicioRetanguloExterior = 6;
                const int xInicioRetanguloInterior = 8;
                const int yInicioRetanguloInterior = 10;

                using (Pen caneta = new Pen(Color.White, Tamanho))
                {
                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloExterior,
                                                                   yInicioRetanguloExterior,
                                                                   painelLateral.Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   painelLateral.Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   painelLateral.Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   painelLateral.Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }
        }

        private void AoClicarEmFiltros(object sender, EventArgs e)
        {
            _controladorFiltro.Visible = true;
        }

        private void IniciaLizaControladorFiltro()
        {
            _controladorFiltro = new FiltroEnderecoUserControl();

            _controladorFiltro.Visible = false;
            _controladorFiltro.VisibleChanged += (object sender, EventArgs e) =>
            {
                if (_controladorFiltro._botaoFiltrarPressionado)
                {
                    dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(_controladorFiltro.Filtro);
                    _controladorFiltro.AlteraValorBotaoFiltrarPressionadoParaFalso();
                    _controladorFiltro.LimpaFiltro();
                }
            };

            _controladorFiltro.Location = new Point(painelLateral.Width, 0);
            Controls.Add(_controladorFiltro);
            _controladorFiltro.BringToFront();
        }

        private void InicializaFontePixeBoy()
        {    
            _pixeboy = new PrivateFontCollection();

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
        }

        private void AoClicarEmPesquisar(object sender, EventArgs e)
        {
            dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(_controladorFiltro.Filtro);
        }

        private void ConfiguraFonte(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);

                if (!c.Controls.IsNullOrEmpty())
                    ConfiguraFonte(c);
            }
        }

        private void InicializaCabecalhoDaGrade()
        {
            dataGridViewEnderecos.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEnderecos.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEnderecos.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEnderecos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEnderecos.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewEnderecos.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEnderecos.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewEnderecos.EnableHeadersVisualStyles = false;
            dataGridViewEnderecos.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEnderecos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewEnderecos.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEnderecos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Lime;
            dataGridViewEnderecos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
        }

        private void AoMudarVisibilidadeTela(object sender, EventArgs e)
        {
            if (Visible)
            {
                dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(null);
                _controladorFiltro.Visible = false;
                _controladorFiltro.AlteraValorBotaoFiltrarPressionadoParaFalso();
            }
        }

        private void AoPintarPainelBotoes(object sender, PaintEventArgs e)
        {
            const int PosicaoX = 11;
            const int PosicaoY = 13;
            int altura = botaoFiltros.Height;
            int largura = botaoFiltros.Width;

            using (Brush pincel = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(pincel, PosicaoX, PosicaoY, largura, altura);
            }
        }

        private void AoFormatarCelulasDataGridViewEnderecos(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewEnderecos.Columns[e.ColumnIndex].HeaderText == "Estado")
            {
                EstadoEnums valorEnum = (EstadoEnums)e.Value;
                e.Value = valorEnum.RetornaDescricao();
            }
        }

        private void AoClicarEmCriar(object sender, EventArgs e)
        {
            TelaCriarEnderecoForm telaCriarEndereco = new TelaCriarEnderecoForm(_servicoEndereco);

            telaCriarEndereco.StartPosition = FormStartPosition.CenterParent;
            telaCriarEndereco.TopLevel = true;

            telaCriarEndereco.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(null);
            };

            telaCriarEndereco.ShowDialog(this);
        }

        private void AoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEnderecos.SelectedRows.IsNullOrEmpty())
                {
                    throw new Exception("!!!!!!Selecione um Endereço para excluir!!!!!!");
                }

                int id = (int)dataGridViewEnderecos.SelectedRows[0].Cells[0].Value;

                var enderecoDeletar = _servicoEndereco.ObterPorId(id);
                
                var mensagemEnderecoExcluir = CriaMensagemEnderecoExcluir(enderecoDeletar);
                var descricaoEnderecoExcluir = CriaDescricaoEnderecoExcluir(enderecoDeletar);

                TelaCaixaDialogoConfirmacaoDelecaoForm telaExclusaoEndereco =
                    new TelaCaixaDialogoConfirmacaoDelecaoForm(mensagemEnderecoExcluir, descricaoEnderecoExcluir);

                telaExclusaoEndereco.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    if(telaExclusaoEndereco.BotaoDeletarClicado)
                    {
                        _servicoEndereco.Deletar(id);
                        dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(null);
                    }
                };

                telaExclusaoEndereco.StartPosition = FormStartPosition.CenterParent;
                telaExclusaoEndereco.TopLevel = true;

                telaExclusaoEndereco.ShowDialog(this);
            }
            catch(Exception excecao)
            {
                const string Separador = "\n";
                List<string> listaErros = new();

                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);
            }
        }

        private string CriaMensagemEnderecoExcluir(Endereco enderecoDeletar)
        {
            var mensagem = $"Tem certeza que deseja excluir o Endereço com CEP {enderecoDeletar.Cep}?\n";
            return mensagem;
        }

        private string CriaDescricaoEnderecoExcluir(Endereco enderecoDeletar)
        {
            var mensagem = $"Município:\n  {enderecoDeletar.Municipio}\nBairro:\n  {enderecoDeletar.Bairro}\n"
                           + $"Rua:\n {enderecoDeletar.Rua}\n" + $"Estado:\n {EnumExtencoes.RetornaDescricao(enderecoDeletar.Estado)}\n"
                           +$"Complemento:\n {enderecoDeletar.Complemento}";
            return mensagem;
        }
    }
}
