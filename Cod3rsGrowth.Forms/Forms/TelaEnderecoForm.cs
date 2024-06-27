using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using Cod3rsGrowth.Dominio.Filtros;
using System.ComponentModel;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaEnderecoForm : Form
    {
        private readonly ServicoEndereco _servicoEndereco;
        private FiltroEnderecoUserControl _controladorFiltro;
        BindingList<Endereco> ListaEnderecos;
        private PrivateFontCollection _pixeboy;

        public TelaEnderecoForm(ServicoEndereco servicoEndereco)
        {
            _servicoEndereco = servicoEndereco;
            InitializeComponent();
        }

        private void TelaConvenioForm_Paint(object sender, PaintEventArgs e)
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
                                                                   Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }
        }

        private void TelaConvenioForm_Load(object sender, EventArgs e)
        {
            InicializaBidingList();
            IniciaLizaControladorFiltro();
            InicializaFontePixeBoy();

            dataGridView1.DataSource = ListaEnderecos;

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            }
        }

        private void painelPrincipal_Paint(object sender, PaintEventArgs e)
        {
            if (painelPrincipal.BorderStyle == BorderStyle.None)
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
                                                                   painelPrincipal.Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   painelPrincipal.Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   painelPrincipal.Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   painelPrincipal.Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }
        }

        private void painelLateral_Paint(object sender, PaintEventArgs e)
        {
            if (painelLateral.BorderStyle == BorderStyle.None)
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
                                                                   painelLateral.Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   painelLateral.Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   painelLateral.Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   painelLateral.Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }

        }

        private void botaoFiltros_Paint(object sender, PaintEventArgs e)
        {
            botaoFiltros.Font = new Font(_pixeboy.Families[0], 10, FontStyle.Bold);
        }

        private void botaoPesquisar_Paint(object sender, PaintEventArgs e)
        {
            botaoPesquisar.Font = new Font(_pixeboy.Families[0], 10, FontStyle.Bold);
        }

        private void botaoFiltros_Click(object sender, EventArgs e)
        {
            _controladorFiltro.Visible = true;
        }

        private void IniciaLizaControladorFiltro()
        {
            _controladorFiltro = new FiltroEnderecoUserControl();
            dataGridView1.Controls.Add(_controladorFiltro);
            _controladorFiltro.BringToFront();
            _controladorFiltro.Visible = false;
        }

        private void InicializaBidingList()
        {
            ListaEnderecos = new BindingList<Endereco>();
            ListaEnderecos.AllowNew = false;
            ListaEnderecos.AllowRemove = false;
            ListaEnderecos.AllowEdit = false;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void botaoPesquisar_Click(object sender, EventArgs e)
        {
            var ListaEnderecoRetornada = _servicoEndereco.ObterTodos(_controladorFiltro.Filtro);

            ListaEnderecos.Clear();
            foreach(var endereco in ListaEnderecoRetornada)
            {
                ListaEnderecos.Add(endereco);
            }
        }
    }
}
