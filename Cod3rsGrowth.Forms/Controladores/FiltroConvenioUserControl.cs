using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroConvenioUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroConvenio Filtro = null;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroConvenioUserControl()
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
                Filtro = new FiltroConvenio();
            }

            if (!string.IsNullOrEmpty(textBoxObjeto.Text))
            {
                Filtro.ObjetoFiltro = textBoxObjeto.Text;
            }

            if (!string.IsNullOrEmpty(textBoxValor.Text))
            {
                Filtro.ValorFiltro = decimal.Parse(textBoxValor.Text);
            }

            if (!string.IsNullOrEmpty(textBoxValor.Text))
            {
                Filtro.IdEscolaFiltro = int.Parse(textBoxValor.Text);
            }

            if (!string.IsNullOrEmpty(textBoxValor.Text))
            {
                Filtro.IdEmpresaFiltro = int.Parse(textBoxValor.Text);
            }

            if (checkBoxHabilitadoDataInicio.Checked)
            {
                Filtro.DataInicioFiltro = dateTimePickerDataInicio.Value;
            }

            if (checkBoxHabilitadoDataTermino.Checked)
            {
                Filtro.DataTerminoFiltro = dateTimePickerDataInicio.Value;
            }

            if (checkBoxMenorValor.Checked)
            {
                Filtro.MaiorOuIgualValor = new();
                Filtro.MaiorOuIgualValor = false;
            }
            else if (checkBoxMaiorValor.Checked)
            {
                Filtro.MaiorOuIgualValor = new();
                Filtro.MaiorOuIgualValor = true;
            }
            else
            {
                Filtro.MaiorOuIgualValor = null;
            }

            if (checkBoxMenorDataInicio.Checked)
            {
                Filtro.MaiorOuIgualDataInicio = new();
                Filtro.MaiorOuIgualDataInicio = false;
            }
            else if (checkBoxMaiorDataInicio.Checked)
            {
                Filtro.MaiorOuIgualDataInicio = new();
                Filtro.MaiorOuIgualDataInicio = true;
            }
            else
            {
                Filtro.MaiorOuIgualDataInicio = null;
            }

            if (checkBoxMenorDataTermino.Checked)
            {
                Filtro.MaiorOuIgualDataTermino = new();
                Filtro.MaiorOuIgualDataTermino = false;
            }
            else if (checkBoxMaiorDataTermino.Checked)
            {
                Filtro.MaiorOuIgualDataTermino = new();
                Filtro.MaiorOuIgualDataTermino = true;
            }
            else
            {
                Filtro.MaiorOuIgualDataTermino = null;
            }

            _botaoFiltrarPressionado = true;
            Visible = false;
        }

        private void checkBoxMaiorValor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorValor.Checked == true)
                checkBoxMenorValor.Checked = !checkBoxMenorValor.Checked;
        }

        private void checkBoxMenorValor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorValor.Checked == true)
                checkBoxMaiorValor.Checked = !checkBoxMaiorValor.Checked;
        }

        private void checkBoxMaiorDataInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorDataInicio.Checked == true)
                checkBoxMenorDataInicio.Checked = !checkBoxMenorDataInicio.Checked;
        }

        private void checkBoxMenorDataInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorDataInicio.Checked == true)
                checkBoxMaiorDataInicio.Checked = !checkBoxMaiorDataInicio.Checked;
        }

        private void checkBoxMaiorDataTermino_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorDataTermino.Checked == true)
                checkBoxMenorDataTermino.Checked = !checkBoxMenorDataTermino.Checked;
        }

        private void checkBoxMenorDataTermino_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorDataTermino.Checked == true)
                checkBoxMaiorDataTermino.Checked = !checkBoxMaiorDataTermino.Checked;
        }

        private void somenteValoresReais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(".") == -1))
            {
                e.Handled = true;
            }
        }

        private void somenteValoresNaturais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void botaoLimpar_Click(object sender, EventArgs e)
        {
            const string TextoVazio = "";

            Filtro = null;
            textBoxObjeto.Text = TextoVazio;
            textBoxIdEscola.Text = TextoVazio;
            textBoxIdEmpresa.Text = TextoVazio;
            textBoxValor.Text = TextoVazio;

            checkBoxMaiorValor.Checked = false;
            checkBoxMenorValor.Checked = false;

            dateTimePickerDataInicio.Value = DateTime.Now;
            dateTimePickerDataTermino.Value = DateTime.Now;

            checkBoxHabilitadoDataInicio.Checked = false;
            checkBoxMaiorDataInicio.Checked = false;
            checkBoxMenorDataInicio.Checked = false;
            checkBoxHabilitadoDataTermino.Checked = false;
            checkBoxMaiorDataTermino.Checked = false;
            checkBoxMenorDataTermino.Checked = false;
        }


        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        public void AlteraValor_botaoFiltrarPressionadoParaFalso()
        {
            _botaoFiltrarPressionado = false;
        }
    }
}
