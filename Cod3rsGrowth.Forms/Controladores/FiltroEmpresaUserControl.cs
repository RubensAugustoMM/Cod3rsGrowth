﻿using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEmpresaUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEmpresa Filtro = null;
        private const string _formatoDaData = "dd/MM/yyyy";
        private const string _textoVazio = "";
        private const string _dataVazia = " ";
        private const int _tamanhoMaximoCnpj = 14;
        private bool _filtroDataAbertura;
        private bool _filtroDataSituacaoCadastral;
        public bool _botaoFiltrarPressionado { get; private set; }

        public FiltroEmpresaUserControl()
        {
            InitializeComponent();
        }

        private void AoCarregar_FiltroEmpresaUserControl(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();

            dateTimePickerDataAbertura.CustomFormat = _dataVazia;
            dateTimePickerDataAbertura.Format = DateTimePickerFormat.Custom;
            _filtroDataAbertura = false;

            dateTimePickerDataSituacaoCadastral.CustomFormat = _dataVazia;
            dateTimePickerDataSituacaoCadastral.Format = DateTimePickerFormat.Custom;
            _filtroDataAbertura = false;

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 10, FontStyle.Bold);
            }
        }

        private void AoClicar_botaoFechar(object sender, EventArgs e)
        {
            Visible = false;
            _botaoFiltrarPressionado = false;
        }

        private void AoClicar_botaoFiltrar(object sender, EventArgs e)
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

            if (comboBoxNaturezaJuridica.DataSource != null)
            {
                Filtro.NaturezaJuridicaFiltro = (NaturezaJuridicaEnums)comboBoxNaturezaJuridica.SelectedItem;
            }

            if (comboBoxPorte.DataSource != null)
            {
                Filtro.PorteFiltro = (PorteEnums)comboBoxPorte.SelectedItem;
            }

            if (comboBoxMatrizFilial.DataSource != null)
            {
                Filtro.MatrizFilialFiltro = (MatrizFilialEnums)comboBoxMatrizFilial.SelectedItem;
            }

            if (_filtroDataAbertura)
            {
                Filtro.DataAberturaFiltro = dateTimePickerDataAbertura.Value;
            }

            if (_filtroDataSituacaoCadastral)
            {
                Filtro.DataSituacaoCadastralFiltro = dateTimePickerDataSituacaoCadastral.Value;
            }

            if (FiltrosMaiorMenorIgualEnums.Menor ==
                    (FiltrosMaiorMenorIgualEnums)comboMaiorMenorIgualIdade.SelectedItem)
            {
                Filtro.MaiorOuIgualIdade = new();
                Filtro.MaiorOuIgualIdade = false;
            }
            else if (FiltrosMaiorMenorIgualEnums.Maior ==
                    (FiltrosMaiorMenorIgualEnums)comboMaiorMenorIgualIdade.SelectedItem)
            {
                Filtro.MaiorOuIgualIdade = new();
                Filtro.MaiorOuIgualIdade = true;
            }
            else
            {
                Filtro.MaiorOuIgualIdade = null;
            }

            if (FiltrosMaiorMenorIgualEnums.Maior ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualCapitalSocial.SelectedItem)
            {
                Filtro.MaiorOuIgualCapitalSocial = new();
                Filtro.MaiorOuIgualCapitalSocial = false;
            }
            else if (FiltrosMaiorMenorIgualEnums.Menor ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualCapitalSocial.SelectedItem)
            {
                Filtro.MaiorOuIgualCapitalSocial = new();
                Filtro.MaiorOuIgualCapitalSocial = true;
            }
            else
            {
                Filtro.MaiorOuIgualCapitalSocial = null;
            }

            if (FiltrosMaiorMenorIgualEnums.Menor ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualDataSituacaoCadastral.SelectedItem)
            {
                Filtro.MaiorOuIgualDataSituacaoCadastral = new();
                Filtro.MaiorOuIgualDataSituacaoCadastral = false;
            }
            else if (FiltrosMaiorMenorIgualEnums.Maior ==
                    (FiltrosMaiorMenorIgualEnums)comboBoxMaiorMenorIgualDataSituacaoCadastral.SelectedItem)
            {
                Filtro.MaiorOuIgualDataSituacaoCadastral = new();
                Filtro.MaiorOuIgualDataSituacaoCadastral = true;
            }
            else
            {
                Filtro.MaiorOuIgualDataSituacaoCadastral = null;
            }


            _botaoFiltrarPressionado = true;
            Visible = false;
        }

        private void AoPressionarTecla_TextBox_somenteValoresReais(object sender, KeyPressEventArgs e)
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

        private void AoPressionarTecla_TextBox_somenteValoresNaturais(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoClicar_botaoLimpar(object sender, EventArgs e)
        {
            Filtro = null;

            textBoxRazaoSocial.Text = _textoVazio;
            textBoxNomeFantasia.Text = _textoVazio;
            textBoxCnpj.Text = _textoVazio;
            textBoxIdade.Text = _textoVazio;
            textBoxCapitalSocial.Text = _textoVazio;

            dateTimePickerDataAbertura.CustomFormat = _dataVazia;
            dateTimePickerDataAbertura.Format = DateTimePickerFormat.Custom;
            _filtroDataAbertura = false;

            dateTimePickerDataSituacaoCadastral.CustomFormat = _dataVazia;
            dateTimePickerDataSituacaoCadastral.Format = DateTimePickerFormat.Custom;
            _filtroDataAbertura = false;

            comboBoxMatrizFilial.DataSource = null;
            comboBoxNaturezaJuridica.DataSource = null;
            comboBoxPorte.DataSource = null;

            checkBoxSituacaoCadastral.Checked = false;
            checkBoxHabilitadoSituacaoCadastral.Checked = false;

            comboBoxMaiorMenorIgualDataSituacaoCadastral.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboBoxMaiorMenorIgualDataAbertura.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboBoxMaiorMenorIgualCapitalSocial.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboMaiorMenorIgualIdade.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void InicializaComboBox()
        {
            comboBoxNaturezaJuridica.DataSource = null;
            comboBoxMatrizFilial.DataSource = null;
            comboBoxPorte.DataSource = null;

            comboBoxMaiorMenorIgualCapitalSocial.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboBoxMaiorMenorIgualDataAbertura.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboBoxMaiorMenorIgualDataSituacaoCadastral.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboMaiorMenorIgualIdade.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
        }

        public void AlteraValor_botaoFiltrarPressionadoParaFalso()
        {
            _botaoFiltrarPressionado = false;
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


        private void AoClicar_comboBoxNaturezaJuridica(object sender, EventArgs e)
        {
            if (comboBoxNaturezaJuridica.DataSource == null)
            {
                comboBoxNaturezaJuridica.DataSource = Enum.GetValues(typeof(NaturezaJuridicaEnums));
            }
        }

        private void AoClicar_comboBoxPorte(object sender, EventArgs e)
        {
            if (comboBoxPorte.DataSource == null)
            {
                comboBoxPorte.DataSource = Enum.GetValues(typeof(PorteEnums));
            }
        }

        private void AoClicar_comboBoxMatrizFilial(object sender, EventArgs e)
        {
            if (comboBoxMatrizFilial.DataSource == null)
            {
                comboBoxMatrizFilial.DataSource = Enum.GetValues(typeof(MatrizFilialEnums));
            }
        }

        private void AoAlterarValor_dateTimePickerDataSituacaoCadastral(object sender, EventArgs e)
        {
            dateTimePickerDataSituacaoCadastral.CustomFormat = _formatoDaData;
            _filtroDataSituacaoCadastral = true;
        }

        private void AoAlterarValor_dateTimePickerDataAbertura(object sender, EventArgs e)
        {
            dateTimePickerDataAbertura.CustomFormat = _formatoDaData;
            _filtroDataAbertura = true;
        }

        private void AoPressionarTecla_textBoxCnpj(object sender, KeyPressEventArgs e)
        {
            if (textBoxCnpj.Text.Length > _tamanhoMaximoCnpj)
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
