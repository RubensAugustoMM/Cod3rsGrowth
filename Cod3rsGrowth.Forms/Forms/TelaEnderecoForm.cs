using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;

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

        private void AoRequererPintura_TelaEnderecoForm(object sender, PaintEventArgs e)
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

        private void AoCarregar_TelaConvenioForm(object sender, EventArgs e)
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

        private void AoRequererPintura_painelLateral(object sender, PaintEventArgs e)
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

        private void AoClicar_botaoFiltros(object sender, EventArgs e)
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
                    _controladorFiltro.AlteraValor_botaoFiltrarPressionadoParaFalso();
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

            int tamanhoFonte = Properties.Resources.Pixeboy_z8XGD.Length;

            byte[] dadosFonte = Properties.Resources.Pixeboy_z8XGD;

            System.IntPtr dado = Marshal.AllocCoTaskMem(tamanhoFonte);

            Marshal.Copy(dadosFonte, 0, dado, tamanhoFonte);

            _pixeboy.AddMemoryFont(dado, tamanhoFonte);
        }

        private void AoClicar_botaoPesquisar(object sender, EventArgs e)
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

        private void AoMudarVisibilidade_TelaEnderecoForm(object sender, EventArgs e)
        {
            if (Visible)
            {
                dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(null);
                _controladorFiltro.Visible = false;
                _controladorFiltro.AlteraValor_botaoFiltrarPressionadoParaFalso();
            }
        }

        private void AoRequererPintura_panelSombraBotoes(object sender, PaintEventArgs e)
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

        private void AoFormatarCelulas_dataGridViewEnderecos(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewEnderecos.Columns[e.ColumnIndex].HeaderText == "Estado")
            {
                EstadoEnums valorEnum = (EstadoEnums)e.Value;
                e.Value = valorEnum.RetornaDescricao();
            }
        }

        private void AoClicar_botaoCriar(object sender, EventArgs e)
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

        private void botaoDeletar_Click(object sender, EventArgs e)
        {
            if (!dataGridViewEnderecos.SelectedRows.IsNullOrEmpty())
            {
                int id = (int)dataGridViewEnderecos.SelectedRows[0].Cells[0].Value;

                TelaCaixaDialogoConfirmacaoDelecaoForm telaExclusaoEndereco =
                    new TelaCaixaDialogoConfirmacaoDelecaoForm(_servicoEndereco.ObterPorId(id), _servicoEndereco);

                telaExclusaoEndereco.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    dataGridViewEnderecos.DataSource = _servicoEndereco.ObterTodos(null);
                };

                telaExclusaoEndereco.StartPosition = FormStartPosition.CenterParent;
                telaExclusaoEndereco.TopLevel = true;

                telaExclusaoEndereco.ShowDialog(this);
            }
            else
            {
                List<string> listaErros = new();

                listaErros.Add("!!!!!!Selecione um Convênio para excluir!!!!!!");
                TelaCaixaDialogoErroForm telaErro = new TelaCaixaDialogoErroForm(listaErros);
            }
        }
    }
}
