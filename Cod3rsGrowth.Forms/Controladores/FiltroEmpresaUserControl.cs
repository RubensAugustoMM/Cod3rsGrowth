using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEmpresaUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEmpresa Filtro = null;

        public FiltroEmpresaUserControl()
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
                Filtro = new FiltroEmpresa();
            }

            if (!string.IsNullOrEmpty(textBoxRazaoSocial.Text))
            {
                Filtro.RazaoSocialFiltro = textBoxRazaoSocial.Text;
            }

            if (!string.IsNullOrEmpty(textBoxNomeFantasia.Text))
            {
                Filtro.NomeFantasiaFiltro = textBoxNomeFantasia.Text;
            }

            if (!string.IsNullOrEmpty(textBoxCnpj.Text))
            {
                Filtro.CnpjFiltro = textBoxCnpj.Text;
            }

            if (!string.IsNullOrEmpty(textBoxIdade.Text))
            {
                Filtro.CapitalSocialFiltro = int.Parse(textBoxIdade.Text);
            }

            if (!string.IsNullOrEmpty(textBoxCapitalSocial.Text))
            {
                Filtro.CapitalSocialFiltro = decimal.Parse(textBoxCapitalSocial.Text);
            }

            if (checkBoxHabilitadoSituacaoCadastral.Checked)
            {
                Filtro.SitucaoCadastralFiltro = checkBoxSituacaoCadastral.Checked;
            }

            if(checkBoxHabilitadoNaturezaJuridica.Checked)
            {
            Filtro.NaturezaJuridicaFiltro = (NaturezaJuridicaEnums)comboBoxNaturezaJuridica.SelectedItem;
            }

            if(checkBoxHabilitadoPorte.Checked)
            {
            Filtro.PorteFiltro = (PorteEnums)comboBoxPorte.SelectedItem;
            }

            if(checkBoxHabilitadoMatrizFilial.Checked)
            {
            Filtro.MatrizFilialFiltro = (MatrizFilialEnums)comboBoxMatrizFilial.SelectedItem;
            }

            if(checkBoxHabilitadoDataAbertura.Checked)
            {
                Filtro.DataAberturaFiltro = dateTimePickerDataAbertura.Value;
            }

            if(checkBoxHabilitadoDataSituacaoCadastral.Checked)
            {
                Filtro.DataSituacaoCadastralFiltro = dateTimePickerDataSituacaoCadastral.Value;
            }

            if (checkBoxMenorIdade.Checked)
            {
                Filtro.MaiorOuIgualIdade = new();
                Filtro.MaiorOuIgualIdade = false;
            }
            else if (checkBoxMaiorIdade.Checked)
            {
                Filtro.MaiorOuIgualIdade = new();
                Filtro.MaiorOuIgualIdade = true;
            }
            else
            {
                Filtro.MaiorOuIgualIdade = null;
            }

            if (checkBoxMenorCapitalSocial.Checked)
            {
                Filtro.MaiorOuIgualCapitalSocial = new();
                Filtro.MaiorOuIgualCapitalSocial = false;
            }
            else if (checkBoxMaiorCapitalSocial.Checked)
            {
                Filtro.MaiorOuIgualCapitalSocial = new();
                Filtro.MaiorOuIgualCapitalSocial = true;
            }
            else
            {
                Filtro.MaiorOuIgualCapitalSocial = null;
            }

            if (checkBoxMenorDataSituacaoCadastral.Checked)
            {
                Filtro.MaiorOuIgualDataSituacaoCadastral = new();
                Filtro.MaiorOuIgualDataSituacaoCadastral = false;
            }
            else if (checkBoxMaiorDataSituacaoCadastral.Checked)
            {
                Filtro.MaiorOuIgualDataSituacaoCadastral = new();
                Filtro.MaiorOuIgualDataSituacaoCadastral = true;
            }
            else
            {
                Filtro.MaiorOuIgualDataSituacaoCadastral = null;
            }
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

            textBoxRazaoSocial.Text = TextoVazio;
            textBoxNomeFantasia.Text = TextoVazio;
            textBoxCnpj.Text = TextoVazio;
            textBoxIdade.Text = TextoVazio;
            textBoxCapitalSocial.Text = TextoVazio;

            dateTimePickerDataAbertura.Value = DateTime.Now;
            dateTimePickerDataSituacaoCadastral.Value = DateTime.Now;
            

            checkBoxMenorIdade.Checked = false;
            checkBoxMaiorIdade.Checked = false;
            checkBoxMenorCapitalSocial.Checked = false;
            checkBoxMaiorCapitalSocial.Checked = false;
            checkBoxMenorDataSituacaoCadastral.Checked = false;
            checkBoxMaiorDataSituacaoCadastral.Checked = false;
            checkBoxMenorDataAbertura.Checked = false;
            checkBoxMaiorDataAbertura.Checked = false;
            checkBoxHabilitadoNaturezaJuridica.Checked = false;
            checkBoxHabilitadoPorte.Checked = false;
            checkBoxHabilitadoMatrizFilial.Checked = false;
            checkBoxHabilitadoDataAbertura.Checked = false;
            checkBoxHabilitadoDataSituacaoCadastral.Checked = false;
            checkBoxSituacaoCadastral.Checked = false;
            checkBoxHabilitadoSituacaoCadastral.Checked = false;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void InicializaComboBox()
        {
            comboBoxPorte.DataSource = Enum.GetValues(typeof(PorteEnums));
            comboBoxNaturezaJuridica.DataSource = Enum.GetValues(typeof(NaturezaJuridicaEnums));
            comboBoxMatrizFilial.DataSource = Enum.GetValues(typeof(MatrizFilialEnums));
        }

        private void checkBoxMaiorIdade_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxMenorIdade.Checked == true)
                checkBoxMenorIdade.Checked = !checkBoxMenorIdade.Checked;
        }

        private void checkBoxMenorIdade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorIdade.Checked == true)
                checkBoxMaiorIdade.Checked = !checkBoxMaiorIdade.Checked;
        }

        private void checkBoxMaiorCapitalSocial_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorCapitalSocial.Checked == true)
                checkBoxMenorCapitalSocial.Checked = !checkBoxMenorCapitalSocial.Checked;
        }

        private void checkBoxMenorCapitalSocial_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorCapitalSocial.Checked == true)
                checkBoxMaiorCapitalSocial.Checked = !checkBoxMaiorCapitalSocial.Checked;
        }

        private void checkBoxMaiorDataSituacaoCadastral_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorDataSituacaoCadastral.Checked == true)
                checkBoxMenorDataSituacaoCadastral.Checked = !checkBoxMenorDataSituacaoCadastral.Checked;
        }

        private void checkBoxMenorDataSituacaoCadastral_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorDataSituacaoCadastral.Checked == true)
                checkBoxMaiorDataSituacaoCadastral.Checked = !checkBoxMaiorDataSituacaoCadastral.Checked;
        }

        private void checkBoxMaiorDataAbertura_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorDataAbertura.Checked == true)
                checkBoxMenorDataAbertura.Checked = !checkBoxMenorDataAbertura.Checked;
        }

        private void checkBoxMenorDataAbertura_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorDataAbertura.Checked == true)
                checkBoxMaiorDataAbertura.Checked = !checkBoxMaiorDataAbertura.Checked;
        }
    }
}
