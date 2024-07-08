using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Filtros;
using System.ComponentModel;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaConvenioForm : Form
    {
        private readonly ServicoConvenio _servicoConvenio;
        private readonly ServicoEscola _servicoEscola;
        private readonly ServicoEmpresa _servicoEmpresa;
        private FiltroConvenioUserControl _controladorFiltro;
        private PrivateFontCollection _pixeboy;

        public TelaConvenioForm(ServicoConvenio servicoConvenio, ServicoEmpresa servicoEmpresa,
                ServicoEscola servicoEscola)
        {
            _servicoEmpresa = servicoEmpresa;
            _servicoEscola = servicoEscola;
            _servicoConvenio = servicoConvenio;
            InitializeComponent();
        }

        private void AoRequererPintura_TelaConvenioForm(object sender, PaintEventArgs e)
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

        private void AoCarregarForm_TelaConvenioForm(object sender, EventArgs e)
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

        private void InicializaControladorFiltro()
        {
            _controladorFiltro = new FiltroConvenioUserControl();

            _controladorFiltro.Visible = false;
            _controladorFiltro.VisibleChanged += (object sender, EventArgs e) =>
            {
                if (_controladorFiltro._botaoFiltrarPressionado)
                {
                    dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(_controladorFiltro.Filtro);
                    _controladorFiltro.AlteraValor_botaoFiltrarPressionadoParaFalso();
                    _controladorFiltro.LimpaFiltro();
                }
            };

            _controladorFiltro.Location = new Point(painelLateral.Width,0);
            Controls.Add(_controladorFiltro);
            _controladorFiltro.BringToFront();
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void AoClicar_botaoPesquisar(object sender, EventArgs e)
        {
            dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(null);
        }

        private void InicializaCabecalhoDaGrade()
        {
            dataGridViewConvenios.Columns[0].HeaderCell.Value = "Código Convênio";
            dataGridViewConvenios.Columns[1].HeaderCell.Value = "Número do Processo";
            dataGridViewConvenios.Columns[2].HeaderCell.Value = "Objeto";
            dataGridViewConvenios.Columns[3].HeaderCell.Value = "Valor";
            dataGridViewConvenios.Columns[4].HeaderCell.Value = "Início";
            dataGridViewConvenios.Columns[5].HeaderCell.Value = "Término";
            dataGridViewConvenios.Columns[6].HeaderCell.Value = "Código Escola";
            dataGridViewConvenios.Columns[7].HeaderCell.Value = "Nome Escola";
            dataGridViewConvenios.Columns[8].HeaderCell.Value = "Código Empresa";
            dataGridViewConvenios.Columns[9].HeaderCell.Value = "Razão Social Empresa";

            foreach(DataGridViewColumn coluna in dataGridViewConvenios.Columns)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

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
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Cyan;
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

        private void AoMudarVisibilidade_dataGridView1(object sender, EventArgs e)
        {
            if(Visible)
            {
                dataGridViewConvenios.DataSource = _servicoConvenio.ObterTodos(null);
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
    }
}
