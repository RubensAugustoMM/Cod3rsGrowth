using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;
using System.Runtime.InteropServices;

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

        private void AoCarregar_TelaCriarEnderecoForm(object sender, EventArgs e)
        {
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

            int tamanhoFonte = Properties.Resources.Pixeboy_z8XGD.Length;

            byte[] dadosFonte = Properties.Resources.Pixeboy_z8XGD;

            System.IntPtr dado = Marshal.AllocCoTaskMem(tamanhoFonte);

            Marshal.Copy(dadosFonte, 0, dado, tamanhoFonte);

            _pixeboy.AddMemoryFont(dado, tamanhoFonte);
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
            Endereco enderecoCriado = new();
            Empresa empresaCriada = new();

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

            try
            {
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

                if(empresaCriada.IdEndereco != -1)
                {
                    _servicoEndereco.Deletar(empresaCriada.IdEndereco);
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

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(",") != -1))
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
