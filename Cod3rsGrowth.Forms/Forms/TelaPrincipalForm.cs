using LinqToDB.Common;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaPrincipalForm : Form
    {
        private PrivateFontCollection _pixeboy;
        private readonly TelaConvenioForm _telaConvenioForm;
        private readonly TelaEmpresaForm _telaEmpresaForm;
        private readonly TelaEnderecoForm _telaEnderecoForm;
        private readonly TelaEscolaForm _telaEscolaForm;

        private bool _telaConvenioAtiva;
        private bool _telaEmpresaAtiva;
        private bool _telaEnderecoAtiva;
        private bool _telaEscolaAtiva;

        public TelaPrincipalForm(TelaConvenioForm telaConvenioForm, TelaEmpresaForm telaEmpresaForm
                , TelaEnderecoForm telaEnderecoForm, TelaEscolaForm telaEscolaForm)
        {
            InitializeComponent();
            _telaConvenioForm = telaConvenioForm;
            _telaEmpresaForm = telaEmpresaForm;
            _telaEnderecoForm = telaEnderecoForm;
            _telaEscolaForm = telaEscolaForm;
        }

        private void AoRequererPintura_panelTopo(object sender, PaintEventArgs e)
        {
            if (panelTopo.BorderStyle == BorderStyle.None)
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
                                                                   panelTopo.ClientSize.Width - (xInicioRetanguloExterior * 2 + Tamanho),
                                                                   panelTopo.ClientSize.Height - (yInicioRetanguloExterior * 2 + Tamanho)));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   panelTopo.ClientSize.Width - (xInicioRetanguloInterior * 2 + Tamanho),
                                                                   panelTopo.ClientSize.Height - (yInicioRetanguloInterior * 2 + Tamanho)));
                }
            }
        }

        private void AoCarregar_TelaPrincipalForm(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaPainelExibicao();
            timer1.Start();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoPassarTempo_temporizador(object sender, EventArgs e)
        {
            data.Text = DateTime.Now.ToLongDateString();
            tempo.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_telaConvenioAtiva)
            {
                _telaConvenioAtiva = !_telaConvenioAtiva;
                _telaConvenioForm.Hide();

                return;
            }

            _telaEmpresaForm.Hide();
            _telaEnderecoForm.Hide();
            _telaEscolaForm.Hide();

            _telaEmpresaAtiva = false;
            _telaEnderecoAtiva = false;
            _telaEscolaAtiva = false;

            _telaConvenioForm.TopMost = true;

            _telaConvenioAtiva = true;
            _telaConvenioForm.Show();
        }

        private void AoClicar_botaoEmpresa(object sender, EventArgs e)
        {
            if(_telaEmpresaAtiva)
            {
                _telaEmpresaAtiva = !_telaEmpresaAtiva;
                _telaEmpresaForm.Hide();

                return;
            }

            _telaConvenioForm.Hide();
            _telaEnderecoForm.Hide();
            _telaEscolaForm.Hide();

            _telaConvenioAtiva = false;
            _telaEnderecoAtiva = false;
            _telaEscolaAtiva = false;

            _telaEmpresaForm.TopMost = true;

            _telaEmpresaAtiva = true;
            _telaEmpresaForm.Show();
        }

        private void AoClicar_botaoEnderecos(object sender, EventArgs e)
        {
            if(_telaEnderecoAtiva)
            {
                _telaEnderecoAtiva = !_telaEnderecoAtiva;
                _telaEnderecoForm.Hide();

                return;
            }

            _telaConvenioForm.Hide();
            _telaEmpresaForm.Hide();
            _telaEscolaForm.Hide();            
            _telaEscolaAtiva = false;
            _telaConvenioAtiva = false;
            _telaEmpresaAtiva = false;

            _telaEnderecoForm.TopMost = true;

            _telaEnderecoAtiva = true;
            _telaEnderecoForm.Show();
        }
        private void AoClicar_botaoEscolas(object sender, EventArgs e)
        {
            if(_telaEscolaAtiva)
            {
                _telaEscolaAtiva = !_telaEscolaAtiva;
                _telaEscolaForm.Hide();

                return;
            }

            _telaConvenioForm.Hide();
            _telaEmpresaForm.Hide();
            _telaEnderecoForm.Hide();

            _telaConvenioAtiva = false;
            _telaEmpresaAtiva = false;
            _telaEnderecoAtiva = false;
            
            _telaEscolaForm.TopMost = true;

            _telaEscolaAtiva = true;
            _telaEscolaForm.Show();
        }

        private void AoClicar_botaoFechar(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void ConfiguraFonte(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);

                if (!c.Controls.IsNullOrEmpty())
                    ConfiguraFonte(c);
            }
        }

        private void InicializaPainelExibicao()
        {
            _telaEscolaForm.TopLevel = false;
            _telaConvenioForm.TopLevel = false;
            _telaEmpresaForm.TopLevel = false;
            _telaEnderecoForm.TopLevel = false;

            _telaEscolaAtiva = false;
            _telaConvenioAtiva = false;
            _telaEmpresaAtiva = false;
            _telaEnderecoAtiva = false;

            painelExibicao.Controls.Add(_telaEscolaForm);
            painelExibicao.Controls.Add(_telaConvenioForm);
            painelExibicao.Controls.Add(_telaEmpresaForm);
            painelExibicao.Controls.Add(_telaEnderecoForm);
        }

        private void AoRequererPintura_panelSombraBotoes(object sender, PaintEventArgs e)
        {
            const int PosicaoX = 11;
            const int PosicaoY = 13;
            const int Altura = 44;
            const int Largura = 113;

            using (Brush pincel = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(pincel, PosicaoX, PosicaoY, Largura, Altura);
            }
        }
    }
}
