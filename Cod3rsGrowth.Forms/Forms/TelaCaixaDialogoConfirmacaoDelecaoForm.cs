using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCaixaDialogoConfirmacaoDelecaoForm : Form
    {
        private PrivateFontCollection _pixeboy;
        private object _objetoExcluir;
        private object _servico;

        public TelaCaixaDialogoConfirmacaoDelecaoForm(object objetoExcluir, object servico)
        {
            InitializeComponent();
            _objetoExcluir = objetoExcluir;
            _servico = servico;
        }

        private void AoCarregar_TelaCaixaDialogoErroForm(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            labelLinha.Text = EscreveLinhaIgualdades(labelLinha);

            switch(_objetoExcluir)
            {
                case ConvenioEscolaEmpresaOtd convenio:
                    labelEntidadeExcluir.Text = $"Tem certeza que deseja excluir o convênio {convenio.NumeroProcesso}?\n";
                    labelDetalhes.Text = $"Escola:\n  {convenio.NomeEscola}\n\nEmpresa:\n  {convenio.RazaoSocialEmpresa}\n\n"
                     + $"Objeto:\n {convenio.Objeto}";
                    break;
                case EmpresaEnderecoOtd empresa:
                    labelEntidadeExcluir.Text = $"Tem certeza que deseja excluir a Empresa {empresa.RazaoSocial}?\n";
                    labelDetalhes.Text = $"Nome Fantasia:\n {empresa.NomeFantasia}\n\n CNPJ:\n {empresa.Cnpj}\n "
                        + $"Estado:\n {EnumExtencoes.RetornaDescricao((EstadoEnums)empresa.IdEndereco)}\n"
                        + EscreveLinhaIgualdades(labelDetalhes)
                        + $"\n!!!O endereço de código:\n {empresa.IdEndereco} também será Excluído!!!";
                    break;
                case EscolaEnderecoOtd escola:
                    break;
                case Endereco endereco:
                    break;
            }

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoRequererPintura_PanelErros(object sender, PaintEventArgs e)
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


        private void AoClicar_botaoExcluir(object sender, EventArgs e)
        {
            const string Separador = "\n";

            try
            {
                switch(_objetoExcluir)
                {
                    case ConvenioEscolaEmpresaOtd convenio:
                        ServicoConvenio servicoConvenio = (ServicoConvenio)_servico;
                        servicoConvenio.Deletar(convenio.Id);
                        break;
                    case EmpresaEnderecoOtd empresa:
                        ServicoEmpresa servicoEmpresa = (ServicoEmpresa)_servico;
                        servicoEmpresa.Deletar(empresa.Id);
                        break;
                    case EscolaEnderecoOtd escola:
                        break;
                    case Endereco endereco:
                        break;
                }
            }
            catch(Exception excecao)
            {
                var listaErros = new List<string>();
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);
            }

            Close();
        }

        private void AoClicar_botaoCancelar(object sender, EventArgs e)
        {
            Close();
        }        

        private string EscreveLinhaIgualdades(Label label)
        {
            string stringRetorno = "=";
            
            while(TextRenderer.MeasureText(stringRetorno,
                        new Font(_pixeboy.Families[0], 15, FontStyle.Bold)).Width < label.MaximumSize.Width)
            {
                stringRetorno += "==";
            }

            return stringRetorno;
        }
    }
}
