using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarEmpresaForm : Form
    {
        private Endereco _enderecoCriado;
        private Empresa _empresaCriada;
        private PrivateFontCollection _pixeboy;
        private readonly ServicoEndereco _servicoEndereco;
        private readonly ServicoEmpresa _servicoEmpresa;

        public TelaCriarEmpresaForm(ServicoEndereco servicoEndereco, ServicoEmpresa servicoEmpresa)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _servicoEmpresa = servicoEmpresa;
        }

        private void AoCarregar_TelaCriarEnderecoForm(object sender, EventArgs e)
        {
            _empresaCriada = new();
            _enderecoCriado = new();
            InicializaFontePixeBoy();
            InicializaComboBox();

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoRequererPintura_PanelCriacao(object sender, PaintEventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.None)
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
                                                                   panelCriacao.Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   panelCriacao.Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   panelCriacao.Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   panelCriacao.Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
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

        private void ConfiguraFonte(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);

                if (!c.Controls.IsNullOrEmpty())
                    ConfiguraFonte(c);
            }
        }

        private void AoClicar_botaoSalvar(object sender, EventArgs e)
        {
            const char Separador = '\n';
            List<string> listaErros = new();

            if (HabilitadoEnums.Habilitado == (HabilitadoEnums)comboBoxSituacaoCadastral.SelectedItem)
            {
                _empresaCriada.SitucaoCadastral = true;
            }
            else
            {
                _empresaCriada.SitucaoCadastral = false;
            }

            _empresaCriada.DataSituacaoCadastral = DateTime.Now;

            if (!string.IsNullOrEmpty(textBoxCapitalSocial.Text))
            {
                _empresaCriada.CapitalSocial = decimal.Parse(textBoxCapitalSocial.Text);
            }
            else
            {
                _empresaCriada.CapitalSocial = -1;
            }

            _empresaCriada.NaturezaJuridica = (NaturezaJuridicaEnums)comboBoxNaturezaJuridica.SelectedItem;
            _empresaCriada.Porte = (PorteEnums)comboBoxPorte.SelectedItem;
            _empresaCriada.MatrizFilial = (MatrizFilialEnums)comboBoxMatrizFilial.SelectedItem;

            _empresaCriada.RazaoSocial = textBoxRazaoSocial.Text;
            _empresaCriada.NomeFantasia = textBoxNomeFantasia.Text;
            _empresaCriada.Cnpj = textBoxCnpj.Text;
            _empresaCriada.DataAbertura = dateTimePickerDataAbertura.Value;

            _empresaCriada.Idade = DateTime.Now.Year - _empresaCriada.DataAbertura.Year;

            _enderecoCriado.Estado = (EstadoEnums)comboBoxEstado.SelectedItem;

            _enderecoCriado.Cep = textBoxCep.Text;
            _enderecoCriado.Municipio = textBoxMunicipio.Text;
            _enderecoCriado.Bairro = textBoxBairro.Text;
            _enderecoCriado.Rua = textBoxRua.Text;

            if (!string.IsNullOrEmpty(textBoxNumero.Text))
            {
                _enderecoCriado.Numero = int.Parse(textBoxNumero.Text);
            }
            else
            {
                _enderecoCriado.Numero = -1;
            }

            _enderecoCriado.Complemento = textBoxComplemento.Text;

            try
            {
                _empresaCriada.IdEndereco = _servicoEndereco.Criar(_enderecoCriado);
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                _empresaCriada.IdEndereco = -1;
            }

            try
            {
                _servicoEmpresa.Criar(_empresaCriada);
                Close();
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;
                 
                caixaDialogoErro.ShowDialog(this);

                if(_empresaCriada.IdEndereco != -1)
                {
                    _servicoEndereco.Deletar(_empresaCriada.IdEndereco);
                }
            }
        }


        private void AoCLicar_botaoCancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void InicializaComboBox()
        {
            comboBoxPorte.DataSource = Enum.GetValues(typeof(PorteEnums));
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));
            comboBoxNaturezaJuridica.DataSource = Enum.GetValues(typeof(NaturezaJuridicaEnums));
            comboBoxMatrizFilial.DataSource = Enum.GetValues(typeof(MatrizFilialEnums));
            comboBoxSituacaoCadastral.DataSource = Enum.GetValues(typeof(HabilitadoEnums));
        }

        private void AoFormatar_comboBoxPorte(object sender, ListControlConvertEventArgs e)
        {
            var valorEnum = (PorteEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
        private void AoPressionarTecla_textBoxCep(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoCep = 8;

            if (textBoxCep.Text.Length == tamanhoMaximoCep && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoAlterarValor_dateTimePickerDataInicioAtividade(object sender, EventArgs e)
        {
            if (dateTimePickerDataAbertura.Value > DateTime.Now)
            {
                dateTimePickerDataAbertura.Value = 
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

        private void AoPressionarTecla_textBoxCapitalSocial(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void AoFormatar_comboBoxEstado(object sender, ListControlConvertEventArgs e)
        {
            EstadoEnums valorEnum = (EstadoEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatar_comboBoxNaturezaJuridica(object sender, ListControlConvertEventArgs e)
        {
            NaturezaJuridicaEnums valorEnum = (NaturezaJuridicaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoPressionarTecla_comboBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AoPressionarTecla_textBoxCnpj(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoCnpj = 14;

            if (textBoxCnpj.Text.Length == tamanhoMaximoCnpj && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoPressionarTecla_textBoxNumero(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoNumero = 8;
            if(textBoxNumero.Text.Length == tamanhoMaximoNumero)
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoFormatar_comboBoxMatrizFilial(object sender, ListControlConvertEventArgs e)
        {
            var valorEnum = (MatrizFilialEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
    }
}
