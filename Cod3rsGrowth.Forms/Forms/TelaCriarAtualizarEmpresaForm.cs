using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarAtualizarEmpresaForm : Form
    {
        private const int _tamanhoFonte = 12;

        private readonly ServicoEndereco _servicoEndereco;
        private readonly ServicoEmpresa _servicoEmpresa;

        private PrivateFontCollection _pixeboy;
        private EmpresaEnderecoOtd _empresaEnderecoAtualizarOtd = null;
        private Endereco _enderecoAtualizar;

        public TelaCriarAtualizarEmpresaForm(ServicoEndereco servicoEndereco, ServicoEmpresa servicoEmpresa)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _servicoEmpresa = servicoEmpresa;
        }

        public TelaCriarAtualizarEmpresaForm(ServicoEndereco servicoEndereco, ServicoEmpresa servicoEmpresa, EmpresaEnderecoOtd empresaEnderecoOtd)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _servicoEmpresa = servicoEmpresa;
            _empresaEnderecoAtualizarOtd = empresaEnderecoOtd; 
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();
            
            if(_empresaEnderecoAtualizarOtd != null)
            {
                ConfiguraTelaParaAtualizar();
            }

            labelTitulo.Location = new Point(Width/2 - labelTitulo.Width / 2, labelTitulo.Location.Y);

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);
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
                c.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);

                if (!c.Controls.IsNullOrEmpty())
                    ConfiguraFonte(c);
            }
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            const char Separador = '\n';
            List<string> listaErros = new();
            Empresa empresaCriada = new();

            try
            {
                try
                {
                    if(_empresaEnderecoAtualizarOtd == null)
                    {
                        Endereco enderecoCriado = new();

                        RecebeDadosDaTelaEndereco(enderecoCriado);
                        _servicoEndereco.Criar(enderecoCriado);
                        empresaCriada.IdEndereco = enderecoCriado.Id;
                    }
                    else
                    {
                        RecebeDadosDaTelaEndereco(_enderecoAtualizar);
                        _servicoEndereco.Atualizar(_enderecoAtualizar);
                    }
                }
                catch (Exception excecao)
                {
                    listaErros.AddRange(excecao.Message.Split(Separador));
                    empresaCriada.IdEndereco = -1;
                }


                if(_empresaEnderecoAtualizarOtd == null)
                {
                    _servicoEmpresa.Criar(empresaCriada);
                }
                else
                {
                    Empresa empresaAtualizar = RetornaModeloEmpresa(_empresaEnderecoAtualizarOtd);

                    RecebeDadosDaTelaEmpresa(empresaAtualizar);
                    _servicoEmpresa.Atualizar(empresaAtualizar);
                }

                Close();
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);

                if (empresaCriada.IdEndereco != -1 && _empresaEnderecoAtualizarOtd == null)
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
                
                if(_empresaEnderecoAtualizarOtd == null)
                {
                    empresaCriada.DataSituacaoCadastral = DateTime.Now;
                }
                else if(_empresaEnderecoAtualizarOtd.SitucaoCadastral != empresaCriada.SitucaoCadastral)
                {
                    empresaCriada.DataSituacaoCadastral = DateTime.Now; 
                }

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

        private void ConfiguraTelaParaAtualizar()
        {
            if (_empresaEnderecoAtualizarOtd.SitucaoCadastral)
            {
                comboBoxSituacaoCadastral.SelectedItem = HabilitadoEnums.Habilitado;
            }
            else
            {
                comboBoxSituacaoCadastral.SelectedItem = HabilitadoEnums.Desabilitado;
            }

            textBoxCapitalSocial.Text = _empresaEnderecoAtualizarOtd.CapitalSocial.ToString();

            comboBoxNaturezaJuridica.SelectedItem = _empresaEnderecoAtualizarOtd.NaturezaJuridica;
            comboBoxPorte.SelectedItem = _empresaEnderecoAtualizarOtd.Porte;
            comboBoxMatrizFilial.SelectedItem = _empresaEnderecoAtualizarOtd.MatrizFilial;

            textBoxRazaoSocial.Text = _empresaEnderecoAtualizarOtd.RazaoSocial;
            textBoxNomeFantasia.Text = _empresaEnderecoAtualizarOtd.NomeFantasia;
            textBoxCnpj.Text = _empresaEnderecoAtualizarOtd.Cnpj;
            dateTimePickerDataAbertura.Value = _empresaEnderecoAtualizarOtd.DataAbertura;

            _enderecoAtualizar = _servicoEndereco.ObterPorId(_empresaEnderecoAtualizarOtd.IdEndereco);

            comboBoxEstado.SelectedItem = _enderecoAtualizar.Estado;
            textBoxCep.Text = _enderecoAtualizar.Cep;
            textBoxMunicipio.Text = _enderecoAtualizar.Municipio;
            textBoxBairro.Text = _enderecoAtualizar.Bairro;
            textBoxRua.Text = _enderecoAtualizar.Rua;
            textBoxNumero.Text = _enderecoAtualizar.Numero.ToString();
            textBoxComplemento.Text = _enderecoAtualizar.Complemento;
            
            labelTitulo.Text = "Atualizar Empresa";
        }

        private Empresa RetornaModeloEmpresa(EmpresaEnderecoOtd empresaOtd)
        {
            Empresa empresaRetorno = new Empresa();

            empresaRetorno.Id = empresaOtd.Id;
            empresaRetorno.RazaoSocial = empresaOtd.RazaoSocial;
            empresaRetorno.NomeFantasia = empresaOtd.NomeFantasia;
            empresaRetorno.Cnpj = empresaOtd.Cnpj;
            empresaRetorno.SitucaoCadastral = empresaOtd.SitucaoCadastral;
            empresaRetorno.DataSituacaoCadastral = empresaOtd.DataSituacaoCadastral;
            empresaRetorno.Idade = empresaOtd.Idade;
            empresaRetorno.DataAbertura = empresaOtd.DataAbertura;
            empresaRetorno.NaturezaJuridica = empresaOtd.NaturezaJuridica;
            empresaRetorno.Porte = empresaOtd.Porte;
            empresaRetorno.MatrizFilial = empresaOtd.MatrizFilial;
            empresaRetorno.CapitalSocial = empresaOtd.CapitalSocial;
            empresaRetorno.IdEndereco = empresaOtd.IdEndereco;

            return empresaRetorno;
        }
    }
}
