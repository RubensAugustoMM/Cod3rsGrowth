using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using System.ComponentModel;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB.Common;

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
            dataGridViewEnderecos.Columns[0].HeaderCell.Value = "Código Endereço";
            dataGridViewEnderecos.Columns[1].HeaderCell.Value = "Numero";
            dataGridViewEnderecos.Columns[2].HeaderCell.Value = "CEP";
            dataGridViewEnderecos.Columns[3].HeaderCell.Value = "Município";
            dataGridViewEnderecos.Columns[4].HeaderCell.Value = "Bairro";
            dataGridViewEnderecos.Columns[5].HeaderCell.Value = "Rua";
            dataGridViewEnderecos.Columns[6].HeaderCell.Value = "Complemento";
            dataGridViewEnderecos.Columns[7].HeaderCell.Value = "Estado";

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
            dataGridViewEnderecos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEnderecos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Cyan;
        }

        private void AoMudarVisibilidade_TelaEnderecoForm(object sender, EventArgs e)
        {
            if(Visible)
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
            const int altura = 86;
            const int largura = 54;

            using (Brush pincel = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(pincel, PosicaoX, PosicaoY, altura, largura);
            }
        }
    }
}
