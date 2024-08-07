﻿using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaPrincipalForm : Form
    {
        private const int _tamanhoFonte = 12;

        private readonly TelaConvenioForm _telaConvenioForm;
        private readonly TelaEmpresaForm _telaEmpresaForm;
        private readonly TelaEnderecoForm _telaEnderecoForm;
        private readonly TelaEscolaForm _telaEscolaForm;

        private PrivateFontCollection _pixeboy;
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

        private void AoPintarPainelSuperior(object sender, PaintEventArgs e)
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

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();
            InicializaPainelExibicao();
            timer1.Start();

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoPassarTempoTemporizador(object sender, EventArgs e)
        {
            data.Text = DateTime.Now.ToLongDateString();
            tempo.Text = DateTime.Now.ToLongTimeString();
        }

        private void AoClicarEmConvenios(object sender, EventArgs e)
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

        private void AoClicarEmEmpresas(object sender, EventArgs e)
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

        private void AoClicarEmEnderecos(object sender, EventArgs e)
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
        private void AoClicarEmEscolas(object sender, EventArgs e)
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

        private void AoClicarEmFechar(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InicializaFontePixeBoy()
        {    
            _pixeboy = new PrivateFontCollection();

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
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

        private void AoPintarPainelBotoes(object sender, PaintEventArgs e)
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
