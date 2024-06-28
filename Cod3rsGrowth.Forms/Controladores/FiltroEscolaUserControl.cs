using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEscolaUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEscola Filtro = null;

        public FiltroEscolaUserControl()
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
        }

        private void botaoFiltrar_Click(object sender, EventArgs e)
        {
            if (Filtro == null)
            {
                Filtro = new FiltroEscola();
            }

            if (!string.IsNullOrEmpty(textBoxNome.Text))
            {
                Filtro.NomeFiltro = textBoxNome.Text;
            }

            if (!string.IsNullOrEmpty(textBoxCodigoMec.Text))
            {
                Filtro.CodigoMecFiltro = textBoxCodigoMec.Text;
            }

            if (!string.IsNullOrEmpty(textBoxIdEndereco.Text))
            {
                Filtro.IdEnderecoFiltro = int.Parse(textBoxIdEndereco.Text);
            }

            if (checkBoxHabilitadoStatusAtividade.Checked)
            {
                Filtro.StatusAtividadeFiltro = checkBoxStatusAtividade.Checked;
            }

            if(checkBoxHabilitadoCategoriaAdministrativa.Checked)
            {
                Filtro.CategoriaAdministrativaFiltro = (CategoriaAdministrativaEnums)comboBoxCategoriaAdministrativa.SelectedItem;
            }

            if(checkBoxHabilitadoOrganizacaoAcademica.Checked)
            {
                Filtro.OrganizacaoAcademicaFiltro = (OrganizacaoAcademicaEnums)comboBoxOrganizacaoAcademica.SelectedItem;
            }

            if(checkBoxHabilitadoInicioAtividade.Checked)
            {
                Filtro.InicioAtividadeFiltro = dateTimePickerDataInicio.Value;
            }

            if (checkBoxMenorInicioAtividade.Checked)
            {
                Filtro.MaiorOuIgualInicioAtividade = new();
                Filtro.MaiorOuIgualInicioAtividade = false;
            }
            else if (checkBoxMaiorInicioAtividade.Checked)
            {
                Filtro.MaiorOuIgualInicioAtividade = new();
                Filtro.MaiorOuIgualInicioAtividade = true;
            }
            else
            {
                Filtro.MaiorOuIgualInicioAtividade = null;
            }
        }

        private void botaoLimpar_Click(object sender, EventArgs e)
        {
            Filtro = null;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void InicializaComboBox()
        {
            comboBoxCategoriaAdministrativa.DataSource = Enum.GetValues(typeof(CategoriaAdministrativaEnums));
            comboBoxOrganizacaoAcademica.DataSource = Enum.GetValues(typeof(OrganizacaoAcademicaEnums));
        }

        private void checkBoxMaiorInicioAtividade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorInicioAtividade.Checked)
                checkBoxMenorInicioAtividade.Checked = !checkBoxMenorInicioAtividade.Checked;
        }

        private void checkBoxMenorInicioAtividade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorInicioAtividade.Checked)
                checkBoxMaiorInicioAtividade.Checked = !checkBoxMaiorInicioAtividade.Checked;
        }

        private void somenteValoresNaturais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
