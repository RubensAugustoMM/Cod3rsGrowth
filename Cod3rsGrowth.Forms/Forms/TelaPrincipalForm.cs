using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servico;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaPrincipalForm : Form
    {
        private readonly ServicoEndereco _servicoEndereco; 
        public TelaPrincipalForm(ServicoEndereco servicoEndereco)
        {
            _servicoEndereco = servicoEndereco;

            InitializeComponent();
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void botaoPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = _servicoEndereco.ObterTodos(null);
        }
    }
}
