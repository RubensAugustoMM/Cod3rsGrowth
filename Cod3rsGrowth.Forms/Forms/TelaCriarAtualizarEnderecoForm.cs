﻿using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarAtualizarEnderecoForm : Form
    {
        private const int _tamanhoFonte = 12;

        private readonly ServicoEndereco _servicoEndereco;

        private PrivateFontCollection _pixeboy;
        private Endereco _enderecoAtualizar = null;

        public TelaCriarAtualizarEnderecoForm(ServicoEndereco servicoEndereco)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
        }

        public TelaCriarAtualizarEnderecoForm(ServicoEndereco servicoEndereco, Endereco enderecoAtualizado)
        {
            InitializeComponent();
            _servicoEndereco = servicoEndereco;
            _enderecoAtualizar = enderecoAtualizado;
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaComboBox();
            
            if(_enderecoAtualizar != null)
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
            try
            {
                if (_enderecoAtualizar == null)
                {
                    Endereco enderecoCriado = new();

                    _servicoEndereco.Criar(enderecoCriado);
                }
                else
                {
                    RecebeDadosDaTelaEndereco(_enderecoAtualizar);
                    _servicoEndereco.Atualizar(_enderecoAtualizar);
                }

                Close();
            }
            catch (Exception excecao)
            {
                const char Separador = '\n';
                var listaErros = new List<string>();
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);
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
            comboBoxEstado.DataSource = Enum.GetValues(typeof(EstadoEnums));
        }

        private void AoFormatarComboBoxEstado(object sender, ListControlConvertEventArgs e)
        {
            var valorEnum = (EstadoEnums)e.Value;
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

        private void AoPressionarTeclaComboBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
            comboBoxEstado.SelectedItem = _enderecoAtualizar.Estado;
            textBoxCep.Text = _enderecoAtualizar.Cep;
            textBoxMunicipio.Text = _enderecoAtualizar.Municipio;
            textBoxBairro.Text = _enderecoAtualizar.Bairro;
            textBoxRua.Text = _enderecoAtualizar.Rua;
            textBoxNumero.Text = _enderecoAtualizar.Numero.ToString();
            textBoxComplemento.Text = _enderecoAtualizar.Complemento;

            labelTitulo.Text = "Atualizar Endereço";
        }
    }
}
