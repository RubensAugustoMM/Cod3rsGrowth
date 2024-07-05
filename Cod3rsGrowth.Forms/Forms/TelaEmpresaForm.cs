using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaEmpresaForm : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private FiltroEmpresaUserControl _controladorFiltro;
        private PrivateFontCollection _pixeboy;

        public TelaEmpresaForm(ServicoEmpresa servicoEmpresa)
        {
            _servicoEmpresa = servicoEmpresa;
            InitializeComponent();
        }

        private void AoRequererPintura_TelaEmpresaForm(object sender, PaintEventArgs e)
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

        private void AoCarregar_TelaEmpresaForm(object sender, EventArgs e)
        {
            dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(null);

            IniciaLizaControladorFiltro();
            InicializaFontePixeBoy();
            InicializaGrade();

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
            _controladorFiltro = new FiltroEmpresaUserControl();

            _controladorFiltro.Visible = false;
            _controladorFiltro.VisibleChanged += (object sender, EventArgs e) =>
            {
                if (_controladorFiltro._botaoFiltrarPressionado)
                {
                    dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(_controladorFiltro.Filtro);
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
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void AoClicar_botaoPesquisar(object sender, EventArgs e)
        {
            dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(_controladorFiltro.Filtro);
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

        private void InicializaGrade()
        {
            dataGridViewEmpresas.Columns[0].HeaderCell.Value = "Código Empresa";
            dataGridViewEmpresas.Columns[1].HeaderCell.Value = "Razao Social";
            dataGridViewEmpresas.Columns[2].HeaderCell.Value = "Nome Fantasia";
            dataGridViewEmpresas.Columns[3].HeaderCell.Value = "CNPJ";
            dataGridViewEmpresas.Columns[4].HeaderCell.Value = "Situação Cadastral";
            dataGridViewEmpresas.Columns[5].HeaderCell.Value = "Data da Alteração Situação Cadastral";
            dataGridViewEmpresas.Columns[6].HeaderCell.Value = "Idade";
            dataGridViewEmpresas.Columns[7].HeaderCell.Value = "Data de Abertura";
            dataGridViewEmpresas.Columns[8].HeaderCell.Value = "Natureza Juridica";
            dataGridViewEmpresas.Columns[9].HeaderCell.Value = "Porte";
            dataGridViewEmpresas.Columns[10].HeaderCell.Value = "Matriz ou Filial";
            dataGridViewEmpresas.Columns[11].HeaderCell.Value = "Capital Social";
            dataGridViewEmpresas.Columns[12].HeaderCell.Value = "Código Endereço";
            dataGridViewEmpresas.Columns[13].HeaderCell.Value = "Estado";

            dataGridViewEmpresas.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEmpresas.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEmpresas.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEmpresas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEmpresas.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewEmpresas.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEmpresas.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewEmpresas.EnableHeadersVisualStyles = false;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Cyan;
        }

        private void AoMudarVisibilidade_TelaEmpresaForm(object sender, EventArgs e)
        {
            if (Visible)
            {
                dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(null);
                _controladorFiltro.Visible = false;
                _controladorFiltro.AlteraValor_botaoFiltrarPressionadoParaFalso();
            }
        }

        private void AoRequererPintura_panelSombraBotoes(object sender, PaintEventArgs e)
        {
            const int PosicaoX = 11;
            const int PosicaoY = 13;
            const int altura = 86;
            const int largura = 54;

            using (Brush pincel = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(pincel, PosicaoX, PosicaoY, altura, largura);
            }
        }

        private void AoFormatarCelula_dataGridViewEmpresas(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Estado")
            {
                dataGridViewEmpresas.Rows[e.RowIndex]
                    .Cells[e.ColumnIndex]
                    .ParseFormattedValue(EnumExtencoes.RetornaDescricao((EstadoEnums)e.Value),e.CellStyle,null,null);
            }
        }
    }
}
