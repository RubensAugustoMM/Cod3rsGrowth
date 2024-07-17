using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEnderecoUserControl : UserControl
    {
        private const string _textoVazio = "";

        private PrivateFontCollection _pixeboy;
        public FiltroEndereco Filtro = null;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroEnderecoUserControl()
        {
            InitializeComponent();
        }

        private void AoCarregarControlador(object sender, EventArgs e)
        {
            const int tamanhoFonte = 12;

            InicializaFontePixeBoy();
            InicializaComboBox();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], tamanhoFonte, FontStyle.Bold);
            }
        }

        private void AoPintarPainelBotoes(object sender, PaintEventArgs e)
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

        private void AoClicarEmFechar(object sender, EventArgs e)
        {
            Visible = false;
            _botaoFiltrarPressionado = false;
        }

        private void AoClicarEmFiltrar(object sender, EventArgs e)
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

        private void AoClicarEmLimpar(object sender, EventArgs e)
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

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
        }

        private void InicializaComboBox()
        {
            comboBoxEstado.DataSource = null;
        }

        public void AlteraValorBotaoFiltrarPressionadoParaFalso()
        {
            _botaoFiltrarPressionado = false;
        }

        private void AoPintarControladorSombra(object sender, PaintEventArgs e)
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

        private void AoPintarControladorBordas(object sender, PaintEventArgs e)
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

        private void AoClicarComboBoxEstado(object sender, EventArgs e)
        {
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));
        }

        private void AoPressionarTeclaTextBoxCep(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoCep = 8;

            if (textBoxCep.Text.Length == tamanhoMaximoCep && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoFormatarComboBoxEstado(object sender, ListControlConvertEventArgs e)
        {
            EstadoEnums valorEnum = (EstadoEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
    }
}
