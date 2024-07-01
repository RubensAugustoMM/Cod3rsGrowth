using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEnderecoUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEndereco Filtro = null;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroEnderecoUserControl()
        {
            InitializeComponent();
        }

        private void FiltroConvenioUserControl_Paint(object sender, PaintEventArgs e)
        {
            if (BorderStyle == BorderStyle.None)
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

        private void FiltroConvenioUserControl_Load(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            }
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Visible = false;
            _botaoFiltrarPressionado = false;
        }

        private void botaoFiltrar_Click(object sender, EventArgs e)
        {
            if (Filtro == null)
            {
                Filtro = new FiltroEndereco();
            }

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

            if(checkBoxHabilitadoEstado.Checked)
            {
                Filtro.EstadoFiltro = (EstadoEnums)comboBoxEstado.SelectedItem;
            }

            _botaoFiltrarPressionado = true;
            Visible = false;
        }

        private void botaoLimpar_Click(object sender, EventArgs e)
        {
            const string TextoVazio = "";

            Filtro = null;

            textBoxMunicipio.Text = TextoVazio;
            textBoxBairro.Text = TextoVazio;
            textBoxCep.Text = TextoVazio;

            checkBoxHabilitadoEstado.Checked = false;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void InicializaComboBox()
        {
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));
        }

        public void AlteraValor_botaoFiltrarPressionadoParaFalso()
        {
            _botaoFiltrarPressionado = false;
        }
    }
}
