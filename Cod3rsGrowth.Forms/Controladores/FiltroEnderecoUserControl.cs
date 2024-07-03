using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEnderecoUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEndereco Filtro = null;
        private const string _textoVazio = "";
        private const int _tamanhoMaximoCep = 8;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroEnderecoUserControl()
        {
            InitializeComponent();
        }

        private void AoCarregar_FiltroEnderecoUserControl(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            }
        }

        private void AoRequererPintura_panelBotaoFiltrar(object sender, PaintEventArgs e)
        {
            const int PosicaoX = 11;
            const int PosicaoY = 13;
            const int altura = 85;
            const int largura = 27;

            using (Brush pincel = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(pincel, PosicaoX, PosicaoY, altura, largura);
            }
        }

        private void AoClicar_botaoFechar(object sender, EventArgs e)
        {
            Visible = false;
            _botaoFiltrarPressionado = false;
        }

        private void AoClicar_botaoFiltrar(object sender, EventArgs e)
        {
                Filtro = new FiltroEndereco();

            if (!string.IsNullOrEmpty(textBoxMunicipio.Text))
            {
                Filtro.MunicipioFiltro = textBoxMunicipio.Text;
            }

            if (!string.IsNullOrEmpty(textBoxBairro.Text))
            {
                Filtro.BairroFiltro = textBoxBairro.Text;
            }

            if (!string.IsNullOrEmpty(textBoxCep.Text))
            {
                Filtro.CepFiltro = textBoxCep.Text;
            }

            if (comboBoxEstado.DataSource != null)
            {
                Filtro.EstadoFiltro = (EstadoEnums)comboBoxEstado.SelectedItem;
            }

            _botaoFiltrarPressionado = true;
            Visible = false;
        }

        private void AoClicar_botaoLimpar(object sender, EventArgs e)
        {
            LimpaFiltro();
        }

        public void LimpaFiltro()
        {
            Filtro = null;

            textBoxMunicipio.Text = _textoVazio;
            textBoxBairro.Text = _textoVazio;
            textBoxCep.Text = _textoVazio;

            comboBoxEstado.DataSource = null;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void InicializaComboBox()
        {
            comboBoxEstado.DataSource = null;
        }

        public void AlteraValor_botaoFiltrarPressionadoParaFalso()
        {
            _botaoFiltrarPressionado = false;
        }

        private void AoRequererPintura_FiltroEnderecoUserControl(object sender, PaintEventArgs e)
        {
            const int PosicaoX = 14;
            const int PosicaoY = 16;
            int Altura = panelFiltro.Height + 19;
            int Largura = panelFiltro.Width + 10;

            using (Brush pincel = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(pincel, PosicaoX, PosicaoY, Largura, Altura);
            }
        }

        private void AoRequererPintura_panelFiltro(object sender, PaintEventArgs e)
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
                                                               panelFiltro.Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                               panelFiltro.Height - (yInicioRetanguloExterior + Tamanho) * 2));

                e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                               yInicioRetanguloInterior,
                                                               panelFiltro.Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                               panelFiltro.Height - (yInicioRetanguloInterior + Tamanho) * 2));
            }

        }

        private void AoClicar_comboBoxEstado(object sender, EventArgs e)
        {
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));
        }

        private void AoPressionarTecla_textBoxCep(object sender, KeyPressEventArgs e)
        {
            if (textBoxCep.Text.Length > _tamanhoMaximoCep)
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
