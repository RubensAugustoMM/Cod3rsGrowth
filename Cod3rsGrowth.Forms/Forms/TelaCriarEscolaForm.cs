using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarEscolaForm : Form
    {
        private Endereco _enderecoCriado;
        private Escola _EscolaCriada;
        private PrivateFontCollection _pixeboy;
        private readonly ServicoEndereco _servicoEndereco;
        private readonly ServicoEscola _servicoEscola;

        public TelaCriarEscolaForm(ServicoEndereco servicoEndereco, ServicoEscola servicoEscola)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _servicoEscola = servicoEscola;
        }

        private void AoCarregar_TelaCriarEnderecoForm(object sender, EventArgs e)
        {
            _EscolaCriada = new();
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
                _EscolaCriada.StatusAtividade = true;
            }
            else
            {
                _EscolaCriada.StatusAtividade = false;
            }

            _EscolaCriada.OrganizacaoAcademica = (OrganizacaoAcademicaEnums)comboBoxOrganizacaoAcademica.SelectedItem;
            _EscolaCriada.CategoriaAdministrativa = (CategoriaAdministrativaEnums)comboBoxCategoriaAdministrativa.SelectedItem;

            _EscolaCriada.Nome = textBoxNome.Text;
            _EscolaCriada.CodigoMec = textBoxCodigoMec.Text;
            _EscolaCriada.Telefone = textBoxTelefone.Text;
            _EscolaCriada.Email = textBoxEmail.Text;
            _EscolaCriada.InicioAtividade = dateTimePickerDataInicioAtividade.Value;

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
                _EscolaCriada.IdEndereco = _servicoEndereco.Criar(_enderecoCriado);
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                _EscolaCriada.IdEndereco = -1;
            }

            try
            {
                _servicoEscola.Criar(_EscolaCriada);
                Close();
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);
            }
        }

        private void AoCLicar_botaoCancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void InicializaComboBox()
        {
            comboBoxCategoriaAdministrativa.DataSource = Enum.GetValues(typeof(CategoriaAdministrativaEnums)); comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));
            comboBoxOrganizacaoAcademica.DataSource = Enum.GetValues(typeof(OrganizacaoAcademicaEnums));
            comboBoxSituacaoCadastral.DataSource = Enum.GetValues(typeof(HabilitadoEnums));
        }

        private void AoFormatar_comboBoxCategoriaAdministrativa(object sender, ListControlConvertEventArgs e)
        {
            var valorEnum = (CategoriaAdministrativaEnums)e.Value;
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
            if (dateTimePickerDataInicioAtividade.Value > DateTime.Now)
            {
                dateTimePickerDataInicioAtividade.Value = DateTime.Now;
            }
        }

        private void AoPressionarTecla_textBoxCodigoMec(object sender, KeyPressEventArgs e)
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

        private void AoFormatar_comboBoxEstado(object sender, ListControlConvertEventArgs e)
        {
            EstadoEnums valorEnum = (EstadoEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoFormatar_comboBoxOrganizacaoAcademica(object sender, ListControlConvertEventArgs e)
        {
            OrganizacaoAcademicaEnums valorEnum = (OrganizacaoAcademicaEnums)e.Value;
            e.Value = valorEnum.RetornaDescricao();
        }

        private void AoPressionarTecla_comboBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AoPressionarTecla_textBoxTelefone(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoTelefone = 10;

            if (textBoxCodigoMec.Text.Length > tamanhoMaximoTelefone && !char.IsControl(e.KeyChar))
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
            if(!string.IsNullOrEmpty(textBoxNumero.Text) &&
                Int64.Parse(textBoxNumero.Text) > Int32.MaxValue )
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
