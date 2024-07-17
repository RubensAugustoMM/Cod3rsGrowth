using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaEscolaForm : Form
    {
        private readonly ServicoEscola _servicoEscola;
        private readonly ServicoEndereco _servicoEndereco;
        private FiltroEscolaUserControl _controladorFiltro;

        private PrivateFontCollection _pixeboy;

        public TelaEscolaForm(ServicoEscola servicoEscola, ServicoEndereco servicoEndereco)
        {
            _servicoEscola = servicoEscola;
            _servicoEndereco = servicoEndereco;
            InitializeComponent();
        }

        private void AoPintarTela(object sender, PaintEventArgs e)
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
            dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);

            IniciaLizaControladorFiltro();
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

        private void IniciaLizaControladorFiltro()
        {
            _controladorFiltro = new FiltroEscolaUserControl();

            _controladorFiltro.Visible = false;
            _controladorFiltro.VisibleChanged += (object sender, EventArgs e) =>
            {
                if (_controladorFiltro._botaoFiltrarPressionado)
                {
                    dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(_controladorFiltro.Filtro);
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

        private void AoCLicarEmPesquisar(object sender, EventArgs e)
        {
            dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(_controladorFiltro.Filtro);
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
            dataGridViewEscolas.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolas.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEscolas.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEscolas.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewEscolas.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolas.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewEscolas.EnableHeadersVisualStyles = false;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Lime;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
        }

        private void AoMudarVisibilidadeTela(object sender, EventArgs e)
        {
            if (Visible)
            {
                dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);
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

        private void AoFormatarCelulasDataGridViewEscolas(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewEscolas.Columns[e.ColumnIndex].HeaderCell.Value == "Categoria Administrativa")
            {
                CategoriaAdministrativaEnums valorEnum = (CategoriaAdministrativaEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolas.Columns[e.ColumnIndex].HeaderCell.Value == "Organização Acadêmica")
            {
                OrganizacaoAcademicaEnums valorEnum = (OrganizacaoAcademicaEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolas.Columns[e.ColumnIndex].HeaderCell.Value == "Estado")
            {
                EstadoEnums valorEnum = (EstadoEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }
        }

        private void AoClicarEmCriar(object sender, EventArgs e)
        {
            TelaCriarAtualizarEscolaForm telaCriarEscola = new TelaCriarAtualizarEscolaForm(_servicoEndereco, _servicoEscola);

            telaCriarEscola.StartPosition = FormStartPosition.CenterParent;
            telaCriarEscola.TopLevel = true;

            telaCriarEscola.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);
            };

            telaCriarEscola.ShowDialog(this);
        }

        private void AoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEscolas.SelectedRows.IsNullOrEmpty())
                {
                    throw new Exception("!!!!!!Selecione uma Escola para excluir!!!!!!");
                }

                int id = (int)dataGridViewEscolas.SelectedRows[0].Cells[0].Value;

                var escolaDeletar = _servicoEscola.ObterPorId(id);

                var mensagemEscolaExcluir = CriaMensagemEscolaExcluir(escolaDeletar);
                var descricaoEscolaExcluir = CriaDescricaoEscolaExcluir(escolaDeletar);


                TelaCaixaDialogoConfirmacaoDelecaoForm telaExclusaoEscola =
                    new TelaCaixaDialogoConfirmacaoDelecaoForm(mensagemEscolaExcluir, descricaoEscolaExcluir);

                telaExclusaoEscola.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    if (telaExclusaoEscola.BotaoDeletarClicado)
                    {
                        _servicoEscola.Deletar(id);
                        dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);
                    }
                };

                telaExclusaoEscola.StartPosition = FormStartPosition.CenterParent;
                telaExclusaoEscola.TopLevel = true;

                telaExclusaoEscola.ShowDialog(this);
            }
            catch (Exception excecao)
            {
                ExibeCaixaDeDialogoErro(excecao);
            }
        }

        private string CriaMensagemEscolaExcluir(EscolaEnderecoOtd escolaDeletar)
        {
            var mensagem = $"Tem certeza que deseja excluir a Escola {escolaDeletar.Nome}?\n"; ;
            return mensagem;
        }

        private string CriaDescricaoEscolaExcluir(EscolaEnderecoOtd escolaDeletar)
        {
            var mensagem = $"Código Mec:\n {escolaDeletar.CodigoMec}\n"
                           + $"Estado:\n {EnumExtencoes.RetornaDescricao(escolaDeletar.Estado)}\n\n"
                           + $"\n!!!O endereço de código:\n {escolaDeletar.IdEndereco} também será Excluído!!!";
            return mensagem;
        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEscolas.SelectedRows.IsNullOrEmpty())
                {
                    throw new Exception("!!!!!!Selecione uma Escola para atualizar!!!!!!");
                }

                int id = (int)dataGridViewEscolas.SelectedRows[0].Cells[0].Value;

                var EscolaEditar = _servicoEscola.ObterPorId(id);

                TelaCriarAtualizarEscolaForm telaAtualizarEscola =
                    new TelaCriarAtualizarEscolaForm(_servicoEndereco, _servicoEscola, EscolaEditar);

                telaAtualizarEscola.StartPosition = FormStartPosition.CenterParent;
                telaAtualizarEscola.TopLevel = true;

                telaAtualizarEscola.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);
                };

                telaAtualizarEscola.StartPosition = FormStartPosition.CenterParent;
                telaAtualizarEscola.TopLevel = true;

                telaAtualizarEscola.ShowDialog(this);
            }
            catch (Exception excecao)
            {
                ExibeCaixaDeDialogoErro(excecao);
            }
        }

        private void ExibeCaixaDeDialogoErro(Exception excecao)
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
}
