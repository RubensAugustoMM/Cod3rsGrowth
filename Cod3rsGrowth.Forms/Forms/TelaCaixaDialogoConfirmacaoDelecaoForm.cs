using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCaixaDialogoConfirmacaoDelecaoForm : Form
    {
        private PrivateFontCollection _pixeboy;
        private string _textoEntidadeExcluir;
        private string _descricaoEntidadeExcluir;
        public bool BotaoDeletarClicado = false;

        public TelaCaixaDialogoConfirmacaoDelecaoForm(string textoEntidadeExcluir, string descricaoEntidadeExcluir)
        {
            InitializeComponent();
            _textoEntidadeExcluir = textoEntidadeExcluir;
            _descricaoEntidadeExcluir = descricaoEntidadeExcluir;
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            labelLinha.Text = EscreveLinhaIgualdades(labelLinha);

            labelEntidadeExcluir.Text = _textoEntidadeExcluir;
            labelDetalhes.Text = _descricaoEntidadeExcluir;

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

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
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
            BotaoDeletarClicado = true;
            Close();
        }

        private void AoClicar_botaoCancelar(object sender, EventArgs e)
        {
            Close();
        }        

        private string EscreveLinhaIgualdades(Label label)
        {
            string stringRetorno = "==";
            
            while(TextRenderer.MeasureText(stringRetorno,
                        new Font(_pixeboy.Families[0], 15, FontStyle.Bold)).Width < label.MaximumSize.Width)
            {
                stringRetorno += "==";
            }

            return stringRetorno;
        }
    }
}
