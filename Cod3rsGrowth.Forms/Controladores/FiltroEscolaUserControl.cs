using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEscolaUserControl : UserControl
    {
        private const string _formatoDaData = "dd/MM/yyyy";
        private const string _textoVazio = "";
        private const string _dataVazia = " ";

        private PrivateFontCollection _pixeboy;
        public FiltroEscolaEnderecoOtd Filtro = null;
        private bool _filtroDataInicioAtividade;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroEscolaUserControl()
        {
            InitializeComponent();
        }

        private void AoCarregarControlador(object sender, EventArgs e)
        {
            const int tamanhoFonte = 12;

            InicializaFontePixeBoy();
            InicializaComboBox();

            dateTimePickerDataInicioAtividade.CustomFormat = _dataVazia;
            dateTimePickerDataInicioAtividade.Format = DateTimePickerFormat.Custom;
            _filtroDataInicioAtividade = false;

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], tamanhoFonte, FontStyle.Bold);
            }
        }

        private void AoClicarEmFechar(object sender, EventArgs e)
        {
            Visible = false;
            _botaoFiltrarPressionado = false;
        }

        private void AoClicarEmFiltrar(object sender, EventArgs e)
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

        private void AoClicarEmLimpar(object sender, EventArgs e)
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

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
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


        private void AoPressionarTeclaTextBoxSomenteValoresNaturais(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void AlteraValorBotaoFiltrarPressionadoParaFalso()
        {
            _botaoFiltrarPressionado = false;
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

        private void AoAlterarValorDateTimePickerDataInicioAtividade(object sender, EventArgs e)
        {
            dateTimePickerDataInicioAtividade.CustomFormat = _formatoDaData;
            _filtroDataInicioAtividade = true;
        }

        private void AoClicarEmComboBoxCategoriaAdministrativa(object sender, EventArgs e)
        {
            if (comboBoxCategoriaAdministrativa.DataSource == null)
            {
                comboBoxCategoriaAdministrativa.DataSource = Enum.GetValues(typeof(CategoriaAdministrativaEnums));
            }
        }

        private void AoClicarEmComboBoxOrganizacaoAcademica(object sender, EventArgs e)
        {
            if (comboBoxOrganizacaoAcademica.DataSource == null)
            {
                comboBoxOrganizacaoAcademica.DataSource = Enum.GetValues(typeof(OrganizacaoAcademicaEnums));
            }
        }

        private void AoPressionarTeclaTextBoxCodigoMec(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoCodigoMec = 8;

            if (textBoxCodigoMec.Text.Length > tamanhoMaximoCodigoMec && !char.IsControl(e.KeyChar))
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

        private void AoFormatarComboBoxCategoriaAdministrativa(object sender, ListControlConvertEventArgs e)
        {
            CategoriaAdministrativaEnums valorEnum = (CategoriaAdministrativaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatarComboBoxOrganizacaoAcademica(object sender, ListControlConvertEventArgs e)
        {
            OrganizacaoAcademicaEnums valorEnum = (OrganizacaoAcademicaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
    }
}
