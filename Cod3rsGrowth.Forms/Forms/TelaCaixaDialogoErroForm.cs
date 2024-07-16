using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCaixaDialogoErroForm : Form
    {
        private PrivateFontCollection _pixeboy;
        private List<string> _listaErrosEntrada;
        private List<string> _listaErrosExibida;

        public TelaCaixaDialogoErroForm(List<string> listaErros)
        {
            InitializeComponent();
            _listaErrosEntrada = listaErros;
            _listaErrosExibida = new List<string>();
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();

            FormataListBoxErros();
            listBoxErros.DataSource = _listaErrosExibida;

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoPintarPainel(object sender, PaintEventArgs e)
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


        private void AoClicarEmOk(object sender, EventArgs e)
        {
            Close();
        }

        private void FormataListBoxErros()
        {
            foreach (var mensagemErro in _listaErrosEntrada)
            {
                _listaErrosExibida.AddRange(TruncarTexto(mensagemErro));
                _listaErrosExibida.Add(" ");
            }
        }

        private List<string> TruncarTexto(string texto)
        {
            string subTexto = texto;
            var textoTruncado = texto;
            List<string> listaRetorno = new List<string>();

            int index = textoTruncado.Length - 1;
            while (true)
            {
                if (textoTruncado[index] == ' ')
                {
                    textoTruncado = textoTruncado.Remove(index);
                    index = textoTruncado.Length;

                    if (TextRenderer.MeasureText(textoTruncado,
                        new Font(_pixeboy.Families[0], 15, FontStyle.Bold)).Width-2< listBoxErros.Width)
                    {
                        listaRetorno.Add(textoTruncado);
                        subTexto = subTexto.Substring(index);
                        if (TextRenderer.MeasureText(subTexto
                            , new Font(_pixeboy.Families[0], 15, FontStyle.Bold)).Width-2 > listBoxErros.Width)
                        {
                            textoTruncado = subTexto;
                            index = textoTruncado.Length;
                        }
                        else
                        {
                            listaRetorno.Add(subTexto);
                            break;
                        }
                    }
                }

                index--;
            }

            return listaRetorno;
        }
    }
}
