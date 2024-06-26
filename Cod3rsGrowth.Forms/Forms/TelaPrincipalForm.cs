using Cod3rsGrowth.Forms.Properties;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaPrincipalForm : Form
    {
        private PrivateFontCollection _pixeboy;

        public TelaPrincipalForm()
        {
            InitializeComponent();
        }

        private void panelTopo1_Paint(object sender, PaintEventArgs e)
        {
            if (panelTopo1.BorderStyle == BorderStyle.None)
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
                                                                   panelTopo1.ClientSize.Width - (xInicioRetanguloExterior * 2 + Tamanho),
                                                                   panelTopo1.ClientSize.Height - (yInicioRetanguloExterior * 2 + Tamanho)));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   panelTopo1.ClientSize.Width - (xInicioRetanguloInterior * 2 + Tamanho),
                                                                   panelTopo1.ClientSize.Height - (yInicioRetanguloInterior * 2 + Tamanho)));
                }
            }
        }

        private void TelaPrincipalForm_Load(object sender, EventArgs e)
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            }

            timer1.Start();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            button1.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
        }

        private void Tempo_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            data.Text = DateTime.Now.ToLongDateString();
            tempo.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaConvenioForm TelaConvenio = new TelaConvenioForm()
            {
                TopLevel = false,
                TopMost = true
            };

            TelaConvenio.FormBorderStyle = FormBorderStyle.None;
            painelExibicao.Controls.Add(TelaConvenio);
            TelaConvenio.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            button2.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
        }

        private void botaoEscolas_Paint(object sender, PaintEventArgs e)
        {
            botaoEscolas.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
        }

        private void botaoEnderecos_Paint(object sender, PaintEventArgs e)
        {
            botaoEnderecos.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
        }

        private void botaoFechar_Paint(object sender, PaintEventArgs e)
        {
            botaoEscolas.Font = new Font(_pixeboy.Families[0], 10, FontStyle.Bold);
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
