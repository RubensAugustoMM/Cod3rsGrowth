using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaEscolaForm : Form
    {
        private readonly ServicoEscola _servicoEscola;
        private readonly ServicoEndereco _servicoEndereco;
        private FiltroEscolaUserControl _controladorFiltro;
        
        private PrivateFontCollection _pixeboy;

        public TelaEscolaForm(ServicoEscola servicoEscola, ServicoEndereco servicoEndereco)
        {
            _servicoEscola = servicoEscola;
            _servicoEndereco = servicoEndereco;
            InitializeComponent();
        }

        private void AoRequererPintura_TelaConvenioForm(object sender, PaintEventArgs e)
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

        private void AoCarregar_TelaConvenioForm(object sender, EventArgs e)
        {
            dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);

            IniciaLizaControladorFiltro();
            InicializaFontePixeBoy();
            InicializaCabecalhoDaGrade();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoRequererPintura_painelLateral(object sender, PaintEventArgs e)
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

        private void AoClicar_botaoFiltros(object sender, EventArgs e)
        {
            _controladorFiltro.Visible = true;
        }

        private void IniciaLizaControladorFiltro()
        {
            _controladorFiltro = new FiltroEscolaUserControl();

            _controladorFiltro.Visible = false;
            _controladorFiltro.VisibleChanged += (object sender, EventArgs e) =>
            {
                if (_controladorFiltro._botaoFiltrarPressionado)
                {
                    dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(_controladorFiltro.Filtro);
                    _controladorFiltro.AlteraValor_botaoFiltrarPressionadoParaFalso();
                    _controladorFiltro.LimpaFiltro();
                }
            };

            _controladorFiltro.Location = new Point(painelLateral.Width, 0);
            Controls.Add(_controladorFiltro);
            _controladorFiltro.BringToFront();
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

        private void botaoPesquisar_Click(object sender, EventArgs e)
        {
            dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(_controladorFiltro.Filtro);
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
            dataGridViewEscolas.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolas.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEscolas.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEscolas.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewEscolas.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolas.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewEscolas.EnableHeadersVisualStyles = false;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Lime;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
        }

        private void AoMudarVisibilidade_TelaEscolaForm(object sender, EventArgs e)
        {
            if (Visible)
            {
                dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);
                _controladorFiltro.Visible = false;
                _controladorFiltro.AlteraValor_botaoFiltrarPressionadoParaFalso();
            }
        }

        private void AoRequererPintura_panelSombraBotoes(object sender, PaintEventArgs e)
        {
            const int PosicaoX = 11;
            const int PosicaoY = 13;
            int altura = botaoFiltros.Height;
            int largura = botaoFiltros.Width;

            using (Brush pincel = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(pincel, PosicaoX, PosicaoY, largura, altura);
            }
        }

        private void AoFormatarCelulas_dataGridViewEscolas(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewEscolas.Columns[e.ColumnIndex].HeaderCell.Value == "Categoria Administrativa")
            {
                CategoriaAdministrativaEnums valorEnum = (CategoriaAdministrativaEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolas.Columns[e.ColumnIndex].HeaderCell.Value == "Organização Acadêmica")
            {
                OrganizacaoAcademicaEnums valorEnum = (OrganizacaoAcademicaEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolas.Columns[e.ColumnIndex].HeaderCell.Value == "Estado")
            {
                EstadoEnums valorEnum = (EstadoEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }
        }

        private void AoClicar_botaoCriar(object sender, EventArgs e)
        {
            TelaCriarEscolaForm telaCriarEscola = new TelaCriarEscolaForm(_servicoEndereco,_servicoEscola);

            telaCriarEscola.StartPosition = FormStartPosition.CenterParent;
            telaCriarEscola.TopLevel = true;

            telaCriarEscola.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                dataGridViewEscolas.DataSource = _servicoEscola.ObterTodos(null);
            };

            telaCriarEscola.ShowDialog(this); 
        }
    }
}
