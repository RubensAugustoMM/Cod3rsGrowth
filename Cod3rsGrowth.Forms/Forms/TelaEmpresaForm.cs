using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using LinqToDB.Common;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaEmpresaForm : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private FiltroEmpresaUserControl _controladorFiltro;
        private PrivateFontCollection _pixeboy;

        public TelaEmpresaForm(ServicoEmpresa servicoEmpresa)
        {
            _servicoEmpresa = servicoEmpresa;
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
            dataGridView1.DataSource = _servicoEmpresa.ObterTodos(null);

            IniciaLizaControladorFiltro();
            InicializaFontePixeBoy();
            InicializaCabecalhoDaGrade();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
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

        private void botaoFiltros_Click(object sender, EventArgs e)
        {
            _controladorFiltro.Visible = true;
        }

        private void IniciaLizaControladorFiltro()
        {
            _controladorFiltro = new FiltroEmpresaUserControl();
            dataGridView1.Controls.Add(_controladorFiltro);
            _controladorFiltro.BringToFront();
            _controladorFiltro.Visible = false;
        }

        private void InicializaFontePixeBoy()
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void botaoPesquisar_Click(object sender, EventArgs e)
        {
            var ListaEmpresaRetornada = _servicoEmpresa.ObterTodos(_controladorFiltro.Filtro);
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

        private void InicializaCabecalhoDaGrade()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "Código Empresa";
            dataGridView1.Columns[1].HeaderCell.Value = "Razao Social";
            dataGridView1.Columns[2].HeaderCell.Value = "Nome Fantasia";
            dataGridView1.Columns[3].HeaderCell.Value = "CNPJ";
            dataGridView1.Columns[4].HeaderCell.Value = "Situação Cadastral"; 
            dataGridView1.Columns[5].HeaderCell.Value = "Data da Alteração Situação Cadastral"; 
            dataGridView1.Columns[6].HeaderCell.Value = "Idade";
            dataGridView1.Columns[7].HeaderCell.Value = "Data de Abertura";
            dataGridView1.Columns[8].HeaderCell.Value = "Natureza Juridica";
            dataGridView1.Columns[9].HeaderCell.Value = "Porte";
            dataGridView1.Columns[10].HeaderCell.Value = "Matriz ou Filial";
            dataGridView1.Columns[11].HeaderCell.Value = "Capital Social";
            dataGridView1.Columns[12].HeaderCell.Value = "Código Endereço";

            dataGridView1.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Cyan;
        }
    }
}
