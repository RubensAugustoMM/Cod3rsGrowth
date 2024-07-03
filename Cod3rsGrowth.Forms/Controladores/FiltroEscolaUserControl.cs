using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEscolaUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEscola Filtro = null;
        private const string _formatoDaData = "yyyy/MM/dd hh:mm:ss";
        private const string _textoVazio = "";
        private const string _dataVazia = " ";
        private const int _tamanhoMaximoCodigoMec = 8;
        private bool _filtroDataInicioAtividade;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroEscolaUserControl()
        {
            InitializeComponent();
        }

        private void FiltroConvenioUserControl_Load(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();

            dateTimePickerDataInicioAtividade.CustomFormat = _dataVazia;
            dateTimePickerDataInicioAtividade.Format = DateTimePickerFormat.Custom;
            _filtroDataInicioAtividade = false;

            foreach (Control c in Controls)
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

            if (comboBoxCategoriaAdministrativa.DataSource != null)
            {
                Filtro.CategoriaAdministrativaFiltro = (CategoriaAdministrativaEnums)comboBoxCategoriaAdministrativa.SelectedItem;
            }

            if (comboBoxOrganizacaoAcademica.DataSource != null)
            {
                Filtro.OrganizacaoAcademicaFiltro = (OrganizacaoAcademicaEnums)comboBoxOrganizacaoAcademica.SelectedItem;
            }

            if (_filtroDataInicioAtividade)
            {
                Filtro.InicioAtividadeFiltro = dateTimePickerDataInicioAtividade.Value;
            }

            if (FiltrosMaiorMenorIgualEnums.Menor ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualInicioAtividade.SelectedItem)
            {
                Filtro.MaiorOuIgualInicioAtividade = new();
                Filtro.MaiorOuIgualInicioAtividade = false;
            }
            else if (FiltrosMaiorMenorIgualEnums.Maior ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualInicioAtividade.SelectedItem)
            {
                Filtro.MaiorOuIgualInicioAtividade = new();
                Filtro.MaiorOuIgualInicioAtividade = true;
            }
            else
            {
                Filtro.MaiorOuIgualInicioAtividade = null;
            }


            _botaoFiltrarPressionado = true;
            Visible = false;
        }

        private void botaoLimpar_Click(object sender, EventArgs e)
        {
            Filtro = null;

            textBoxNome.Text = _textoVazio;
            textBoxCodigoMec.Text = _textoVazio;
            textBoxIdEndereco.Text = _textoVazio;

            dateTimePickerDataInicioAtividade.CustomFormat = _dataVazia;
            dateTimePickerDataInicioAtividade.Format = DateTimePickerFormat.Custom;
            _filtroDataInicioAtividade = false;

            comboBoxCategoriaAdministrativa.DataSource = null;
            comboBoxOrganizacaoAcademica.DataSource = null;

            checkBoxHabilitadoStatusAtividade.Checked = false;
            checkBoxStatusAtividade.Checked = false;

            comboBoxMaiorMenorIgualInicioAtividade.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void InicializaComboBox()
        {
            comboBoxCategoriaAdministrativa.DataSource = null;
            comboBoxOrganizacaoAcademica.DataSource = null;
            comboBoxMaiorMenorIgualInicioAtividade.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
        }


        private void somenteValoresNaturais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void AlteraValor_botaoFiltrarPressionadoParaFalso()
        {
            _botaoFiltrarPressionado = false;
        }

        private void panelBotaoFiltrar_Paint(object sender, PaintEventArgs e)
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

        private void FiltroEmpresaUserControl_Paint_1(object sender, PaintEventArgs e)
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

        private void panelFiltro_Paint(object sender, PaintEventArgs e)
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

        private void dateTimePickerDataInicioAtividade_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDataInicioAtividade.CustomFormat = _formatoDaData;
            _filtroDataInicioAtividade = true;
        }

        private void comboBoxCategoriaAdministrativa_Click(object sender, EventArgs e)
        {
            if (comboBoxCategoriaAdministrativa.DataSource == null)
            {
                comboBoxCategoriaAdministrativa.DataSource = Enum.GetValues(typeof(CategoriaAdministrativaEnums));
            }
        }

        private void comboBoxOrganizacaoAcademica_Click(object sender, EventArgs e)
        {
            if (comboBoxOrganizacaoAcademica.DataSource == null)
            {
                comboBoxOrganizacaoAcademica.DataSource = Enum.GetValues(typeof(OrganizacaoAcademicaEnums));
            }
        }

        private void textBoxCodigoMec_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (textBoxCodigoMec.Text.Length > _tamanhoMaximoCodigoMec)
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
