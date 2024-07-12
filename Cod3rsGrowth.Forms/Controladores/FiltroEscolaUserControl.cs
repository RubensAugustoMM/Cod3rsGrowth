using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEscolaUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEscolaEnderecoOtd Filtro = null;
        private const string _formatoDaData = "dd/MM/yyyy";
        private const string _textoVazio = "";
        private const string _dataVazia = " ";
        private const int _tamanhoMaximoCodigoMec = 8;
        private bool _filtroDataInicioAtividade;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroEscolaUserControl()
        {
            InitializeComponent();
        }

        private void AoCarregar_FiltroEscolaUserControl(object sender, EventArgs e)
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

        private void AoClicar_botaoFechar(object sender, EventArgs e)
        {
            Visible = false;
            _botaoFiltrarPressionado = false;
        }

        private void AoClicar_botaoFiltrar(object sender, EventArgs e)
        {
            Filtro = new FiltroEscolaEnderecoOtd();

            if (!string.IsNullOrEmpty(textBoxNome.Text))
            {
                Filtro.NomeFiltro = textBoxNome.Text;
            }

            if (comboBoxEstado.SelectedItem != null)
            {
                Filtro.EstadoFiltro = (EstadoEnums)comboBoxEstado.SelectedItem;
            }

            if (!string.IsNullOrEmpty(textBoxCodigoMec.Text))
            {
                Filtro.CodigoMecFiltro = textBoxCodigoMec.Text;
            }

            if (comboBoxCategoriaAdministrativa.SelectedItem != null)
            {
                Filtro.CategoriaAdministrativaFiltro = (CategoriaAdministrativaEnums)comboBoxCategoriaAdministrativa.SelectedItem;
            }

            if (comboBoxOrganizacaoAcademica.SelectedItem != null)
            {
                Filtro.OrganizacaoAcademicaFiltro = (OrganizacaoAcademicaEnums)comboBoxOrganizacaoAcademica.SelectedItem;
            }

            if (comboBoxHabilitadoStatusAtividade.SelectedItem != null)
            {
                if (HabilitadoEnums.Habilitado ==
                    (HabilitadoEnums)comboBoxHabilitadoStatusAtividade.SelectedItem)
                {
                    Filtro.StatusAtividadeFiltro = true;
                }
                else
                {
                    Filtro.StatusAtividadeFiltro = false;
                }
            }

            if (_filtroDataInicioAtividade)
            {
                Filtro.InicioAtividadeFiltro = dateTimePickerDataInicioAtividade.Value;
            }

            if (FiltrosMaiorMenorIgualEnums.Maior ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualInicioAtividade.SelectedItem)
            {
                Filtro.MaiorOuIgualInicioAtividade = true;
            }
            else if (FiltrosMaiorMenorIgualEnums.Menor ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualInicioAtividade.SelectedItem)
            {
                Filtro.MaiorOuIgualInicioAtividade = false;
            }
            else
            {
                Filtro.MaiorOuIgualInicioAtividade = null;
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

            textBoxNome.Text = _textoVazio;
            textBoxCodigoMec.Text = _textoVazio;

            dateTimePickerDataInicioAtividade.CustomFormat = _dataVazia;
            dateTimePickerDataInicioAtividade.Format = DateTimePickerFormat.Custom;
            _filtroDataInicioAtividade = false;

            comboBoxCategoriaAdministrativa.SelectedItem = null;
            comboBoxOrganizacaoAcademica.SelectedItem = null;
            comboBoxHabilitadoStatusAtividade.SelectedItem = null;
            comboBoxEstado.SelectedItem = null;

            comboBoxMaiorMenorIgualInicioAtividade.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
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
            comboBoxHabilitadoStatusAtividade.DataSource = Enum.GetValues(typeof(HabilitadoEnums));
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));

            comboBoxCategoriaAdministrativa.SelectedItem = null;
            comboBoxOrganizacaoAcademica.SelectedItem = null;
            comboBoxHabilitadoStatusAtividade.SelectedItem = null;
            comboBoxEstado.SelectedItem = null;

            comboBoxMaiorMenorIgualInicioAtividade.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
        }


        private void AoPressionarTecla_TextBox_somenteValoresNaturais(object sender, KeyPressEventArgs e)
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

        private void AoRequererPintura_panelSombraBotoes(object sender, PaintEventArgs e)
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

        private void AoRequererPintura_FiltroEmpresaUserControl(object sender, PaintEventArgs e)
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

        private void AoAlterarValor_dateTimePickerDataInicioAtividade(object sender, EventArgs e)
        {
            dateTimePickerDataInicioAtividade.CustomFormat = _formatoDaData;
            _filtroDataInicioAtividade = true;
        }

        private void AoClicar_comboBoxCategoriaAdministrativa(object sender, EventArgs e)
        {
            if (comboBoxCategoriaAdministrativa.DataSource == null)
            {
                comboBoxCategoriaAdministrativa.DataSource = Enum.GetValues(typeof(CategoriaAdministrativaEnums));
            }
        }

        private void AoClicar_comboBoxOrganizacaoAcademica(object sender, EventArgs e)
        {
            if (comboBoxOrganizacaoAcademica.DataSource == null)
            {
                comboBoxOrganizacaoAcademica.DataSource = Enum.GetValues(typeof(OrganizacaoAcademicaEnums));
            }
        }

        private void AoPressionarTecla_textBoxCodigoMec(object sender, KeyPressEventArgs e)
        {
            if (textBoxCodigoMec.Text.Length > _tamanhoMaximoCodigoMec && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoFormatar_comboBoxEstado(object sender, ListControlConvertEventArgs e)
        {
            EstadoEnums valorEnum = (EstadoEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatar_comboBoxCategoriaAdministrativa(object sender, ListControlConvertEventArgs e)
        {
            CategoriaAdministrativaEnums valorEnum = (CategoriaAdministrativaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatar_comboBoxOrganizacaoAcademica(object sender, ListControlConvertEventArgs e)
        {
            OrganizacaoAcademicaEnums valorEnum = (OrganizacaoAcademicaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
    }
}
