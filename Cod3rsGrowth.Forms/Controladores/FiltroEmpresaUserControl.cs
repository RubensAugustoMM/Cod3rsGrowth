﻿using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Filtros;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroEmpresaUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroEmpresaEnderecoOtd Filtro = null;
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
            Filtro = new FiltroEmpresaEnderecoOtd();

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
                Filtro.IdadeFiltro = int.Parse(textBoxIdade.Text);
            }

            if (!string.IsNullOrEmpty(textBoxCapitalSocial.Text))
            {
                Filtro.CapitalSocialFiltro = decimal.Parse(textBoxCapitalSocial.Text);
            }

            if (comboBoxNaturezaJuridica.SelectedItem != null)
            {
                Filtro.NaturezaJuridicaFiltro = (NaturezaJuridicaEnums)comboBoxNaturezaJuridica.SelectedItem;
            }

            if (comboBoxPorte.SelectedItem != null)
            {
                Filtro.PorteFiltro = (PorteEnums)comboBoxPorte.SelectedItem;
            }

            if (comboBoxMatrizFilial.SelectedItem != null)
            {
                Filtro.MatrizFilialFiltro = (MatrizFilialEnums)comboBoxMatrizFilial.SelectedItem;
            }

            if (comboBoxEstado.SelectedItem != null)
            {
                Filtro.EstadoFiltro = (EstadoEnums)comboBoxEstado.SelectedItem;
            }

            if (comboBoxHabilitadoSituacaoCadastral.SelectedItem != null)
            {
                if (HabilitadoEnums.Habilitado ==
                      (HabilitadoEnums)comboBoxHabilitadoSituacaoCadastral.SelectedItem)
                {
                    Filtro.SitucaoCadastralFiltro = true;
                }
                else
                {
                    Filtro.SitucaoCadastralFiltro = false;
                }
            }

            if (_filtroDataAbertura)
            {
                Filtro.DataAberturaFiltro = dateTimePickerDataAbertura.Value;
            }

            if (_filtroDataSituacaoCadastral)
            {
                Filtro.DataSituacaoCadastralFiltro = dateTimePickerDataSituacaoCadastral.Value;
            }

            Filtro.MaiorOuIgualIdade = ValidadorComboBoxMaiorMenorIgual(comboMaiorMenorIgualIdade);
            Filtro.MaiorOuIgualCapitalSocial = ValidadorComboBoxMaiorMenorIgual(comboBoxMaiorMenorIgualCapitalSocial);
            Filtro.MaiorOuIgualDataSituacaoCadastral = ValidadorComboBoxMaiorMenorIgual(comboBoxMaiorMenorIgualDataSituacaoCadastral);


            _botaoFiltrarPressionado = true;
            Visible = false;
        }

        private void AoPressionarTecla_TextBox_somenteValoresReais(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(",") != -1))
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
            LimpaFiltro();
        }

        public void LimpaFiltro()
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

            comboBoxNaturezaJuridica.SelectedItem = null;
            comboBoxMatrizFilial.SelectedItem = null;
            comboBoxPorte.SelectedItem = null;
            comboBoxHabilitadoSituacaoCadastral.SelectedItem = null;
            comboBoxEstado.SelectedItem = null;

            comboBoxMaiorMenorIgualDataSituacaoCadastral.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboBoxMaiorMenorIgualDataAbertura.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboBoxMaiorMenorIgualCapitalSocial.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
            comboMaiorMenorIgualIdade.SelectedItem = FiltrosMaiorMenorIgualEnums.Igual;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();

            int tamanhoFonte = Properties.Resources.Pixeboy_z8XGD.Length;

            byte[] dadosFonte = Properties.Resources.Pixeboy_z8XGD;

            System.IntPtr dado = Marshal.AllocCoTaskMem(tamanhoFonte);

            Marshal.Copy(dadosFonte, 0, dado, tamanhoFonte);

            _pixeboy.AddMemoryFont(dado, tamanhoFonte);
        }

        private void InicializaComboBox()
        {
            comboBoxNaturezaJuridica.DataSource = Enum.GetValues(typeof(NaturezaJuridicaEnums));
            comboBoxMatrizFilial.DataSource = Enum.GetValues(typeof(MatrizFilialEnums));
            comboBoxPorte.DataSource = Enum.GetValues(typeof(PorteEnums));
            comboBoxHabilitadoSituacaoCadastral.DataSource = Enum.GetValues(typeof(HabilitadoEnums));
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));

            comboBoxNaturezaJuridica.SelectedItem = null;
            comboBoxMatrizFilial.SelectedItem = null;
            comboBoxPorte.SelectedItem = null;
            comboBoxHabilitadoSituacaoCadastral.SelectedItem = null;
            comboBoxEstado.SelectedItem = null;

            comboBoxMaiorMenorIgualCapitalSocial.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboBoxMaiorMenorIgualDataAbertura.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboBoxMaiorMenorIgualDataSituacaoCadastral.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
            comboMaiorMenorIgualIdade.DataSource = Enum.GetValues(typeof(FiltrosMaiorMenorIgualEnums));
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
            if (textBoxCnpj.Text.Length == _tamanhoMaximoCnpj && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void AoFormatar_comboBoxEstado(object sender, ListControlConvertEventArgs e)
        {
            EstadoEnums valorEnum = (EstadoEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatar_comboBoxPorte(object sender, ListControlConvertEventArgs e)
        {
            PorteEnums valorEnum = (PorteEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatar_comboBoxNaturezaJuridica(object sender, ListControlConvertEventArgs e)
        {
            NaturezaJuridicaEnums valorEnum = (NaturezaJuridicaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
    }
}
