using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Filtros;
using System.ComponentModel;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaConvenioForm : Form
    {
        private readonly ServicoConvenio _servicoConvenio;
        private readonly ServicoEscola _servicoEscola;
        private readonly ServicoEmpresa _servicoEmpresa;
        private FiltroConvenioUserControl _controladorFiltro;
        private PrivateFontCollection _pixeboy;

        public TelaConvenioForm(ServicoConvenio servicoConvenio,
            ServicoEscola servicoEscola, ServicoEmpresa servicoEmpresa)
        {
            _servicoConvenio = servicoConvenio;
            _servicoEscola = servicoEscola;
            _servicoEmpresa = servicoEmpresa;
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
            dataGridViewConvenios.DataSource = new BindingList<FiltroConvenioEscolaEmpresaOtd>();
            dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(null);

            InicializaControladorFiltro();
            InicializaFontePixeBoy();
            InicializaCabecalhoDaGrade();

            foreach (Control c in Controls)
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

        private void InicializaControladorFiltro()
        {
            _controladorFiltro = new FiltroConvenioUserControl();

            _controladorFiltro.Visible = false;
            _controladorFiltro.VisibleChanged += (object sender, EventArgs e) =>
            {
                if (_controladorFiltro._botaoFiltrarPressionado)
                {
                    dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(_controladorFiltro.Filtro);
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
            dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(null);
        }

        private void InicializaCabecalhoDaGrade()
        {
            const string formatacaoDecimais = "0,0.00";

            dataGridViewConvenios.Columns[3].DefaultCellStyle.Format = formatacaoDecimais;

            dataGridViewConvenios.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewConvenios.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewConvenios.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewConvenios.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewConvenios.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewConvenios.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewConvenios.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewConvenios.EnableHeadersVisualStyles = false;
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Lime;
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
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

        private void AoAlterarVisibilidadeDaGrade(object sender, EventArgs e)
        {
            if (Visible)
            {
                dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(null);
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

        private void AoClicarEmCriar(object sender, EventArgs e)
        {

            TelaCriarConvenioForm telaCriarConvenio =
                new TelaCriarConvenioForm(_servicoConvenio, _servicoEmpresa, _servicoEscola);

            telaCriarConvenio.StartPosition = FormStartPosition.CenterParent;
            telaCriarConvenio.TopLevel = true;

            telaCriarConvenio.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(null);
            };

            telaCriarConvenio.ShowDialog(this);
        }

        private void AoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewConvenios.SelectedRows.IsNullOrEmpty())
                {
                    throw new Exception("!!!!!!Selecione um Convênio para excluir!!!!!!");
                }
                
                int id = (int)dataGridViewConvenios.SelectedRows[0].Cells[0].Value;

                var convenioDeletar = _servicoConvenio.ObterPorId(id);

                var mensagemConvenioExcluir = CriaMensagemConvenioExcluir(convenioDeletar);
                var descricaoConvenioExcluir = CriaDescricaoConvenioExcluir(convenioDeletar);

                TelaCaixaDialogoConfirmacaoDelecaoForm telaExclusaoConvenio =
                    new TelaCaixaDialogoConfirmacaoDelecaoForm(mensagemConvenioExcluir, descricaoConvenioExcluir);

                telaExclusaoConvenio.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    if(telaExclusaoConvenio.BotaoDeletarClicado)
                    {
                        _servicoConvenio.Deletar(convenioDeletar.Id);
                        dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(null);
                    }
                };

                telaExclusaoConvenio.StartPosition = FormStartPosition.CenterParent;
                telaExclusaoConvenio.TopLevel = true;

                telaExclusaoConvenio.ShowDialog(this);
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

        private string CriaMensagemConvenioExcluir(ConvenioEscolaEmpresaOtd convenioDeletar)
        {
            var mensagem = $"Tem certeza que deseja excluir o Convênio {convenioDeletar.NumeroProcesso}?\n";
            return mensagem;
        }

        private string CriaDescricaoConvenioExcluir(ConvenioEscolaEmpresaOtd convenioDeletar)
        {
            var mensagem = $"Escola:\n  {convenioDeletar.NomeEscola}\n"
                     + $"Empresa:\n  {convenioDeletar.RazaoSocialEmpresa}\n\n"
                     + $"Objeto:\n {convenioDeletar.Objeto}";
            return mensagem;
        }
    }
}
