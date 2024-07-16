using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Forms.Properties;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarAtualizarEscolaForm : Form
    {
        private PrivateFontCollection _pixeboy;
        private readonly ServicoEndereco _servicoEndereco;
        private readonly ServicoEscola _servicoEscola;
        private EscolaEnderecoOtd _escolaEnderecoOtdAtualizar = null;
        private Endereco _enderecoAtualizar = null;

        public TelaCriarAtualizarEscolaForm(ServicoEndereco servicoEndereco, ServicoEscola servicoEscola)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _servicoEscola = servicoEscola;
        }

        public TelaCriarAtualizarEscolaForm(ServicoEndereco servicoEndereco, ServicoEscola servicoEscola, EscolaEnderecoOtd escolaEnderecoOtdAtualizar)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _servicoEscola = servicoEscola;
            _escolaEnderecoOtdAtualizar = escolaEnderecoOtdAtualizar;
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();

            if(_escolaEnderecoOtdAtualizar != null)
            {
                ConfiguraTelaParaAtualizar();
            }

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
            Escola escolaCriada = new();

            try
            {


                try
                {
                    if (_escolaEnderecoOtdAtualizar == null)
                    {
                        Endereco enderecoCriado = new();
                            
                        RecebeDadosDaTelaEndereco(enderecoCriado);
                        _servicoEndereco.Criar(enderecoCriado);
                        escolaCriada.IdEndereco = enderecoCriado.Id;
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
                    escolaCriada.IdEndereco = -1;
                }
                
                if(_escolaEnderecoOtdAtualizar == null)
                {
                     RecebeDadosDaTelaEscola(escolaCriada);
                    _servicoEscola.Criar(escolaCriada); 
                }
                else
                {
                    Escola escolaAtualizar = RetornaModeloEscola(_escolaEnderecoOtdAtualizar);
                    RecebeDadosDaTelaEscola(escolaAtualizar);
                    _servicoEscola.Atualizar(escolaAtualizar);
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

                if (escolaCriada.IdEndereco != -1 && _escolaEnderecoOtdAtualizar == null)
                {
                    _servicoEndereco.Deletar(escolaCriada.IdEndereco);
                }
            }
        }

        private void RecebeDadosDaTelaEscola(Escola escolaCriada)
        {
            if (HabilitadoEnums.Habilitado == (HabilitadoEnums)comboBoxSituacaoCadastral.SelectedItem)
            {
                escolaCriada.StatusAtividade = true;
            }
            else
            {
                escolaCriada.StatusAtividade = false;
            }

            escolaCriada.OrganizacaoAcademica = (OrganizacaoAcademicaEnums)comboBoxOrganizacaoAcademica.SelectedItem;
            escolaCriada.CategoriaAdministrativa = (CategoriaAdministrativaEnums)comboBoxCategoriaAdministrativa.SelectedItem;

            escolaCriada.Nome = textBoxNome.Text;
            escolaCriada.CodigoMec = textBoxCodigoMec.Text;
            escolaCriada.Telefone = textBoxTelefone.Text;
            escolaCriada.Email = textBoxEmail.Text;
            escolaCriada.InicioAtividade = dateTimePickerDataInicioAtividade.Value;
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
            comboBoxCategoriaAdministrativa.DataSource = Enum.GetValues(typeof(CategoriaAdministrativaEnums));
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));
            comboBoxOrganizacaoAcademica.DataSource = Enum.GetValues(typeof(OrganizacaoAcademicaEnums));
            comboBoxSituacaoCadastral.DataSource = Enum.GetValues(typeof(HabilitadoEnums));
        }

        private void AoFormatarComboBoxCategoriaAdministrativa(object sender, ListControlConvertEventArgs e)
        {
            var valorEnum = (CategoriaAdministrativaEnums)e.Value;
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
            if (dateTimePickerDataInicioAtividade.Value > DateTime.Now)
            {
                dateTimePickerDataInicioAtividade.Value = 
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

        private void AoPressionarTeclaTextBoxCodigoMec(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoCodigoMec = 8;

            if (textBoxCodigoMec.Text.Length == tamanhoMaximoCodigoMec && !char.IsControl(e.KeyChar))
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

        private void AoFormatarComboBoxOrganizacaoAcademica(object sender, ListControlConvertEventArgs e)
        {
            OrganizacaoAcademicaEnums valorEnum = (OrganizacaoAcademicaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoPressionarTeclaComboBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AoPressionarTeclaTextBoxTelefone(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoTelefone = 10;

            if (textBoxTelefone.Text.Length == tamanhoMaximoTelefone && !char.IsControl(e.KeyChar))
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

        private void ConfiguraTelaParaAtualizar()
        {
            if (_escolaEnderecoOtdAtualizar.StatusAtividade)
            {
                comboBoxSituacaoCadastral.SelectedItem = HabilitadoEnums.Habilitado;
            }
            else
            {
                comboBoxSituacaoCadastral.SelectedItem = HabilitadoEnums.Desabilitado;
            }

            comboBoxOrganizacaoAcademica.SelectedItem = _escolaEnderecoOtdAtualizar.OrganizacaoAcademica;
            comboBoxCategoriaAdministrativa.SelectedItem = _escolaEnderecoOtdAtualizar.CategoriaAdministrativa;

            textBoxNome.Text = _escolaEnderecoOtdAtualizar.Nome;
            textBoxCodigoMec.Text = _escolaEnderecoOtdAtualizar.CodigoMec;
            textBoxTelefone.Text = _escolaEnderecoOtdAtualizar.Telefone;
            textBoxEmail.Text = _escolaEnderecoOtdAtualizar.Email;
            dateTimePickerDataInicioAtividade.Value = _escolaEnderecoOtdAtualizar.InicioAtividade;

            _enderecoAtualizar = _servicoEndereco.ObterPorId(_escolaEnderecoOtdAtualizar.IdEndereco);

            comboBoxEstado.SelectedItem = _enderecoAtualizar.Estado;
            textBoxCep.Text = _enderecoAtualizar.Cep;
            textBoxMunicipio.Text = _enderecoAtualizar.Municipio;
            textBoxBairro.Text = _enderecoAtualizar.Bairro;
            textBoxRua.Text = _enderecoAtualizar.Rua;
            textBoxNumero.Text = _enderecoAtualizar.Numero.ToString();
            textBoxComplemento.Text = _enderecoAtualizar.Complemento;
            
            labelTitulo.Text = "Atualizar Escola";
        }

        private Escola RetornaModeloEscola(EscolaEnderecoOtd escolaOtd)
        {
            Escola escolaRetorno = new Escola();

            escolaRetorno.Id = escolaOtd.Id;
            escolaRetorno.Nome = escolaOtd.Nome;
            escolaRetorno.CodigoMec = escolaOtd.CodigoMec;
            escolaRetorno.Telefone = escolaOtd.Telefone;
            escolaRetorno.Email = escolaOtd.Email;
            escolaRetorno.InicioAtividade = escolaOtd.InicioAtividade;
            escolaRetorno.CategoriaAdministrativa = escolaOtd.CategoriaAdministrativa;
            escolaRetorno.OrganizacaoAcademica = escolaOtd.OrganizacaoAcademica;
            escolaRetorno.IdEndereco = escolaOtd.IdEndereco;

            return escolaRetorno;
        }
    }
}
