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
        private PrivateFontCollection _pixeboy;
        private readonly ServicoEndereco _servicoEndereco;
        private readonly ServicoEmpresa _servicoEmpresa;

        public TelaCriarEmpresaForm(ServicoEndereco servicoEndereco, ServicoEmpresa servicoEmpresa)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _servicoEmpresa = servicoEmpresa;
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoPintarTela(object sender, PaintEventArgs e)
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

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
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

        private void ConfiguraFonte(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);

                if (!c.Controls.IsNullOrEmpty())
                    ConfiguraFonte(c);
            }
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            const char Separador = '\n';
            List<string> listaErros = new();
            Endereco enderecoCriado = new();
            Empresa empresaCriada = new();

            try
            {
                RecebeDadosDaTelaEmpresa(empresaCriada);

                RecebeDadosDaTelaEndereco(enderecoCriado);

                try
                {
                    _servicoEndereco.Criar(enderecoCriado);
                    empresaCriada.IdEndereco = enderecoCriado.Id;
                }
                catch (Exception excecao)
                {
                    listaErros.AddRange(excecao.Message.Split(Separador));
                    empresaCriada.IdEndereco = -1;
                }

                _servicoEmpresa.Criar(empresaCriada);
                Close();
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);

                if (empresaCriada.IdEndereco != -1)
                {
                    _servicoEndereco.Deletar(empresaCriada.IdEndereco);
                }
            }
        }

        private void RecebeDadosDaTelaEmpresa(Empresa empresaCriada)
        {
            try
            {
                if (HabilitadoEnums.Habilitado == (HabilitadoEnums)comboBoxSituacaoCadastral.SelectedItem)
                {
                    empresaCriada.SitucaoCadastral = true;
                }
                else
                {
                    empresaCriada.SitucaoCadastral = false;
                }

                empresaCriada.DataSituacaoCadastral = DateTime.Now;

                if (!string.IsNullOrEmpty(textBoxCapitalSocial.Text))
                {
                    empresaCriada.CapitalSocial = decimal.Parse(textBoxCapitalSocial.Text);
                }
                else
                {
                    empresaCriada.CapitalSocial = -1;
                }

                empresaCriada.NaturezaJuridica = (NaturezaJuridicaEnums)comboBoxNaturezaJuridica.SelectedItem;
                empresaCriada.Porte = (PorteEnums)comboBoxPorte.SelectedItem;
                empresaCriada.MatrizFilial = (MatrizFilialEnums)comboBoxMatrizFilial.SelectedItem;

                empresaCriada.RazaoSocial = textBoxRazaoSocial.Text;
                empresaCriada.NomeFantasia = textBoxNomeFantasia.Text;
                empresaCriada.Cnpj = textBoxCnpj.Text;
                empresaCriada.DataAbertura = dateTimePickerDataAbertura.Value;

                empresaCriada.Idade = DateTime.Now.Year - empresaCriada.DataAbertura.Year;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void RecebeDadosDaTelaEndereco(Endereco enderecoCriado)
        {
            try
            {
                enderecoCriado.Estado = (EstadoEnums)comboBoxEstado.SelectedItem;

                enderecoCriado.Cep = textBoxCep.Text;
                enderecoCriado.Municipio = textBoxMunicipio.Text;
                enderecoCriado.Bairro = textBoxBairro.Text;
                enderecoCriado.Rua = textBoxRua.Text;

                if (!string.IsNullOrEmpty(textBoxNumero.Text))
                {
                    enderecoCriado.Numero = int.Parse(textBoxNumero.Text);
                }
                else
                {
                    enderecoCriado.Numero = -1;
                }

                enderecoCriado.Complemento = textBoxComplemento.Text;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AoCLicarEmCancelar(object sender, EventArgs e)
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

        private void AoFormatarComboBoxPorte(object sender, ListControlConvertEventArgs e)
        {
            var valorEnum = (PorteEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
        private void AoPressionarTeclaTextBoxCep(object sender, KeyPressEventArgs e)
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

        private void AoAlterarValorDateTimePickerDataInicioAtividade(object sender, EventArgs e)
        {
            if (dateTimePickerDataAbertura.Value > DateTime.Now)
            {
                dateTimePickerDataAbertura.Value = 
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

        private void AoPressionarTeclaTextBoxCapitalSocial(object sender, KeyPressEventArgs e)
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

        private void AoFormatarComboBoxEstado(object sender, ListControlConvertEventArgs e)
        {
            EstadoEnums valorEnum = (EstadoEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatarComboBoxNaturezaJuridica(object sender, ListControlConvertEventArgs e)
        {
            NaturezaJuridicaEnums valorEnum = (NaturezaJuridicaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoPressionarTeclaComboBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AoPressionarTeclaTextBoxCnpj(object sender, KeyPressEventArgs e)
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

        private void AoPressionarTeclaTextBoxNumero(object sender, KeyPressEventArgs e)
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

        private void AoFormatarComboBoxMatrizFilial(object sender, ListControlConvertEventArgs e)
        {
            var valorEnum = (MatrizFilialEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }
    }
}
