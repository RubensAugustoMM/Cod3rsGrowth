using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarEscolaForm : Form
    {
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
            Escola escolaCriada = new();

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
                escolaCriada.IdEndereco = enderecoCriado.Id;
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                escolaCriada.IdEndereco = -1;
            }

            try
            {
                _servicoEscola.Criar(escolaCriada);
                Close();
            }
            catch (Exception excecao)
            {
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);

                if(escolaCriada.IdEndereco != -1)
                {
                    _servicoEndereco.Deletar(escolaCriada.IdEndereco);
                }
            }
        }

        private void AoCLicar_botaoCancelar(object sender, EventArgs e)
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
                dateTimePickerDataInicioAtividade.Value = 
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
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

            if (textBoxTelefone.Text.Length == tamanhoMaximoTelefone && !char.IsControl(e.KeyChar))
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
    }
}
