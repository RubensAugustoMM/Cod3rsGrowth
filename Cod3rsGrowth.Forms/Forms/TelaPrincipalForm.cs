using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servico;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaPrincipalForm : Form
    {
        private readonly ServicoEndereco _servicoEndereco;
        bool BarraLateralExpandida = false;

        public TelaPrincipalForm(ServicoEndereco servicoEndereco)
        {
            _servicoEndereco = servicoEndereco;

            InitializeComponent();
        }

        private async void barraLateralTimer_Tick(object sender, EventArgs e)
        {
            const int TempoDelay = 1000;
            const int TamanhoVariado = 10; 

            if (BarraLateralExpandida)
            {
                barraLateral.Width -= TamanhoVariado;
                if (barraLateral.Width == barraLateral.MinimumSize.Width)
                {
                    BarraLateralExpandida = false;
                    barraLateralTimer.Stop();
                }
            }
            else
            {
                await Task.Delay(TempoDelay);
                barraLateral.Width += TamanhoVariado;
                if (barraLateral.Width == barraLateral.MaximumSize.Width)
                {
                    BarraLateralExpandida = true;
                    barraLateralTimer.Stop();
                }
            }
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void botaoPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = _servicoEndereco.ObterTodos(null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void botaoConvenios_MouseEnter(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }

        }

        private void barraLateral_MouseEnter_1(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void barraLateral_MouseLeave(object sender, EventArgs e)
        {
            barraLateralTimer.Start();
        }

        private void barraLateral_MouseHover_1(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateral.Width = barraLateral.MaximumSize.Width;
            }
        }

        private void botaoEmpresas_Click(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void botaoEnderecos_Click(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void botaoEnderecos_MouseEnter(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void botaoEscolas_MouseEnter(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void botaoEmpresas_MouseEnter(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            if (!BarraLateralExpandida)
            {
                barraLateralTimer.Start();
            }
        }

        private void barraLateral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
