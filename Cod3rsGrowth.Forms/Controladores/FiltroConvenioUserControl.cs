﻿using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroConvenioUserControl : UserControl
    {
        private const int _tamanhoFonte = 12;
        private const string _formatoDaData = "dd/MM/yyyy";
        private const string _textoVazio = "";
        private const string _dataVazia = " ";

        private PrivateFontCollection _pixeboy;
        public FiltroConvenioEscolaEmpresaOtd Filtro = null;
        private bool _filtroDataInicioHabilitado;
        private bool _filtroDataTerminoHabilitado;
        public bool _botaoFiltrarPressionado { get; private set; }


        public FiltroConvenioUserControl()
        {
            InitializeComponent();
        }

        private void AoCarregarControlador(object sender, EventArgs e)
        {

            InicializaFontePixeBoy();
            InicializaComboBox();
            botaoFiltrar.BringToFront();

            dateTimePickerDataInicio.CustomFormat = _dataVazia;
            dateTimePickerDataInicio.Format = DateTimePickerFormat.Custom;
            _filtroDataInicioHabilitado = false;

            dateTimePickerDataTermino.CustomFormat = _dataVazia;
            dateTimePickerDataTermino.Format = DateTimePickerFormat.Custom;
            _filtroDataTerminoHabilitado = false;

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoClicarEmFechar(object sender, EventArgs e)
        {
            Visible = false;
            _botaoFiltrarPressionado = false;
        }

        private void AoClicarEmFiltrar(object sender, EventArgs e)
        {
            Filtro = new FiltroConvenioEscolaEmpresaOtd();

            if (!string.IsNullOrEmpty(textBoxObjeto.Text))
            {
                Filtro.ObjetoFiltro = textBoxObjeto.Text;
            }

            if (!string.IsNullOrEmpty(textBoxValor.Text))
            {
                Filtro.ValorFiltro = decimal.Parse(textBoxValor.Text);
            }

            if (!string.IsNullOrEmpty(textBoxIdEscola.Text))
            {
                Filtro.IdEscolaFiltro = int.Parse(textBoxIdEscola.Text);
            }

            if (!string.IsNullOrEmpty(textBoxNomeEscola.Text))
            {
                Filtro.NomeEscolaFiltro = textBoxNomeEscola.Text;
            }

            if (!string.IsNullOrEmpty(textBoxIdEmpresa.Text))
            {
                Filtro.IdEmpresaFiltro = int.Parse(textBoxIdEmpresa.Text);
            }

            if (!string.IsNullOrEmpty(textBoxRazaoSocialEmpresa.Text))
            {
                Filtro.RazaoSocialEmpresaFiltro = textBoxRazaoSocialEmpresa.Text;
            }

            if (_filtroDataInicioHabilitado)
            {
                Filtro.DataInicioFiltro = dateTimePickerDataInicio.Value;
            }

            if (_filtroDataTerminoHabilitado)
            {
                Filtro.DataTerminoFiltro = dateTimePickerDataInicio.Value;
            }

            Filtro.MaiorOuIgualValor = ValidadorComboBoxMaiorMenorIgual(comboMaiorMenorIgualValor);
            Filtro.MaiorOuIgualDataInicio = ValidadorComboBoxMaiorMenorIgual(comboMaiorMenorIgualDataInicio);
            Filtro.MaiorOuIgualDataTermino = ValidadorComboBoxMaiorMenorIgual(comboMaiorMenorIgualDataTermino);

            _botaoFiltrarPressionado = true;
            Visible = false;
        }

        private void AoPressionarTeclaTextBoxSomenteValoresReais(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && !((sender as TextBox).Text.IndexOf(',') != -1))
            {
                e.Handled = true;
            }
        }

        private void AoPressionarTeclaTextBoxSomenteValoresNaturais(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoClicarEmLimpar(object sender, EventArgs e)
        {
            LimpaFiltro();
        }

        public void LimpaFiltro()
        {
            Filtro = null;
            textBoxObjeto.Text = _textoVazio;
            textBoxIdEscola.Text = _textoVazio;
            textBoxIdEmpresa.Text = _textoVazio;
            textBoxValor.Text = _textoVazio;
            textBoxNomeEscola.Text = _textoVazio;
            textBoxRazaoSocialEmpresa.Text = _textoVazio;

            dateTimePickerDataInicio.CustomFormat = _dataVazia;
            dateTimePickerDataInicio.Format = DateTimePickerFormat.Custom;
            _filtroDataInicioHabilitado = false;

            dateTimePickerDataTermino.CustomFormat = _dataVazia;
            dateTimePickerDataTermino.Format = DateTimePickerFormat.Custom;
            _filtroDataTerminoHabilitado = false;

            comboMaiorMenorIgualValor.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboMaiorMenorIgualDataInicio.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboMaiorMenorIgualDataTermino.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
        }

        private void InicializaFontePixeBoy()
        {    
            _pixeboy = new PrivateFontCollection();

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
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

        private void InicializaComboBox()
        {
            comboMaiorMenorIgualValor.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboMaiorMenorIgualDataInicio.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboMaiorMenorIgualDataTermino.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
        }

        private void AoAlterarValorDateTimePickerDataInicio(object sender, EventArgs e)
        {
            dateTimePickerDataInicio.CustomFormat = _formatoDaData;
            _filtroDataInicioHabilitado = true;
        }

        private void AoAlterarValorDateTimePickerDataTermino(object sender, EventArgs e)
        {
            dateTimePickerDataTermino.CustomFormat = _formatoDaData;
            _filtroDataTerminoHabilitado = true;
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

        private void ConfiguraFonte(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);

                if (!c.Controls.IsNullOrEmpty())
                    ConfiguraFonte(c);
            }
        }

        private bool? ValidadorComboBoxMaiorMenorIgual(ComboBox comboBox)
        {
            bool? ResultadoRetornado = null;

            if (FiltrosMaiorMenorIgualEnums.Maior ==
                    (FiltrosMaiorMenorIgualEnums)comboBox.SelectedItem)
            {
                ResultadoRetornado = true;
                return ResultadoRetornado;
            }

            if (FiltrosMaiorMenorIgualEnums.Menor ==
                    (FiltrosMaiorMenorIgualEnums)comboBox.SelectedItem)
            {
                ResultadoRetornado = false;
                return ResultadoRetornado;
            }

            return ResultadoRetornado; 
        }
    }
}
