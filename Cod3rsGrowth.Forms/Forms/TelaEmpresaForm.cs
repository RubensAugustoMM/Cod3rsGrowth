using Cod3rsGrowth.Forms.Controladores;
using Cod3rsGrowth.Servico;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Forms.Properties;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaEmpresaForm : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly ServicoEndereco _servicoEndereco;
        private FiltroEmpresaUserControl _controladorFiltro;
        private PrivateFontCollection _pixeboy;

        public TelaEmpresaForm(ServicoEmpresa servicoEmpresa, ServicoEndereco servicoEndereco)
        {
            _servicoEmpresa = servicoEmpresa;
            _servicoEndereco = servicoEndereco;
            InitializeComponent();
        }

        private void AoPintarTela(object sender, PaintEventArgs e)
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

        private void AoCarregarTela(object sender, EventArgs e)
        {
            dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(null);

            IniciaLizaControladorFiltro();
            InicializaFontePixeBoy();
            InicializaGrade();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoPintarPainelLateral(object sender, PaintEventArgs e)
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

        private void AoClicarEmFiltros(object sender, EventArgs e)
        {
            _controladorFiltro.Visible = true;
        }

        private void IniciaLizaControladorFiltro()
        {
            _controladorFiltro = new FiltroEmpresaUserControl();

            _controladorFiltro.Visible = false;
            _controladorFiltro.VisibleChanged += (object sender, EventArgs e) =>
            {
                if (_controladorFiltro._botaoFiltrarPressionado)
                {
                    dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(_controladorFiltro.Filtro);
                    _controladorFiltro.AlteraValorBotaoFiltrarPressionadoParaFalso();
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

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
        }

        private void AoClicarEmPesquisar(object sender, EventArgs e)
        {
            dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(_controladorFiltro.Filtro);
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

        private void InicializaGrade()
        {
            const string formatacaoDecimais = "0,0.00";

            dataGridViewEmpresas.Columns[11].DefaultCellStyle.Format = formatacaoDecimais;

            dataGridViewEmpresas.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEmpresas.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEmpresas.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEmpresas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEmpresas.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewEmpresas.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEmpresas.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewEmpresas.EnableHeadersVisualStyles = false;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Lime;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
        }

        private void AoMudarVisibilidadeDaTelaFiltros(object sender, EventArgs e)
        {
            if (Visible)
            {
                dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(null);
                _controladorFiltro.Visible = false;
                _controladorFiltro.AlteraValorBotaoFiltrarPressionadoParaFalso();
            }
        }

        private void AoPintarPainelBotoes(object sender, PaintEventArgs e)
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

        private void AoFormatarCelulasDataGridViewEmpresas(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Natureza Juridica")
            {
                NaturezaJuridicaEnums valorEnum = (NaturezaJuridicaEnums)e.Value;
                e.Value = valorEnum.RetornaDescricao();

            }

            if (dataGridViewEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Porte")
            {
                PorteEnums valorEnum = (PorteEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Matriz ou Filial")
            {
                MatrizFilialEnums valorEnum = (MatrizFilialEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEmpresas.Columns[e.ColumnIndex].HeaderText == "Estado")
            {
                EstadoEnums valorEnum = (EstadoEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }
        }

        private void AoClicarEmCriar(object sender, EventArgs e)
        {
            TelaCriarEmpresaForm telaCriarEmpresa = new TelaCriarEmpresaForm(_servicoEndereco, _servicoEmpresa);

            telaCriarEmpresa.StartPosition = FormStartPosition.CenterParent;
            telaCriarEmpresa.TopLevel = true;

            telaCriarEmpresa.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(null);
            };

            telaCriarEmpresa.ShowDialog(this);
        }

        private void AoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            { 
                if (dataGridViewEmpresas.SelectedRows.IsNullOrEmpty())
                {
                    throw new Exception("!!!!!!Selecione uma Empresa para excluir!!!!!!");
                }

                int id = (int)dataGridViewEmpresas.SelectedRows[0].Cells[0].Value;

                var empresaDeletar = _servicoEmpresa.ObterPorId(id);
                
                var mensagemEmpresaExcluir = CriaMensagemEmpresaExcluir(empresaDeletar);
                var descricaoEmpresaExcluir = CriaDescricaoEmpresaExcluir(empresaDeletar);

                TelaCaixaDialogoConfirmacaoDelecaoForm telaExclusaoConvenio =
                    new TelaCaixaDialogoConfirmacaoDelecaoForm(mensagemEmpresaExcluir, descricaoEmpresaExcluir);

                telaExclusaoConvenio.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    if(telaExclusaoConvenio.BotaoDeletarClicado)
                    {
                        _servicoEmpresa.Deletar(id);
                        dataGridViewEmpresas.DataSource = _servicoEmpresa.ObterTodos(null);
                    }
                };

                telaExclusaoConvenio.StartPosition = FormStartPosition.CenterParent;
                telaExclusaoConvenio.TopLevel = true;

                telaExclusaoConvenio.ShowDialog(this);
            }
            catch(Exception excecao)
            {
                const string Separador = "\n";
                List<string> listaErros = new();

                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);
            }
        }

        private string CriaMensagemEmpresaExcluir(EmpresaEnderecoOtd empresaDeletar)
        {
            var mensagem = $"Tem certeza que deseja excluir a Empresa {empresaDeletar.RazaoSocial}?\n";
            return mensagem;
        }

        private string CriaDescricaoEmpresaExcluir(EmpresaEnderecoOtd empresaDeletar)
        {
            var mensagem = $"Nome Fantasia:\n {empresaDeletar.NomeFantasia}\n\n CNPJ:\n {empresaDeletar.Cnpj}\n "
                        + $"Estado:\n {EnumExtencoes.RetornaDescricao(empresaDeletar.Estado)}\n\n"
                        + $"\n!!!O endereço de código:\n {empresaDeletar.IdEndereco} também será Excluído!!!";
            return mensagem;
        }
    }
}
