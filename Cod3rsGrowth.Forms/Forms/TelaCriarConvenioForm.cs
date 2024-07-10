using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarConvenioForm : Form
    {
        private Convenio _convenioCriado;
        private PrivateFontCollection _pixeboy;
        private readonly ServicoConvenio _servicoConvenio;
        private readonly ServicoEscola _servicoEscola;
        private readonly ServicoEmpresa _servicoEmpresa;
        private bool botaoEscolaAtivo;

        public TelaCriarConvenioForm(ServicoConvenio servicoConvenio, ServicoEmpresa servicoEmpresa, ServicoEscola servicoEscola)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _servicoEscola = servicoEscola;
            _servicoConvenio = servicoConvenio;
        }

        private void AoCarregar_TelaCriarConvenioForm(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();

            dataGridViewEscolasEmpresas.DataSource = _servicoEscola.ObterTodos(null);
            botaoEscolaAtivo = true;

            ConfiguraGradeEscola();

            _convenioCriado = new();

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
                ConfiguraFonte(c);
            }
        }

        private void AoRequererPintura_PanelCriacao(object sender, PaintEventArgs e)
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
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
        }

        private void AoRequererPintura_panelSombraBotoes(object sender, PaintEventArgs e)
        {
            const int PosicaoX = 11;
            const int PosicaoY = 13;
            const int altura = 105;
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

        private void AoClicar_botaoSalvar(object sender, EventArgs e)
        {
            const char Separador = '\n';

            if (!string.IsNullOrEmpty(textBoxNumeroProcesso.Text))
            {
                _convenioCriado.NumeroProcesso = int.Parse(textBoxNumeroProcesso.Text);
            }
            else
            {
                _convenioCriado.NumeroProcesso = -1;
            }

            if (!string.IsNullOrEmpty(textBoxValor.Text))
            {
                _convenioCriado.Valor = int.Parse(textBoxValor.Text);
            }
            else
            {
                _convenioCriado.Valor = -1;
            }

            _convenioCriado.Objeto = richTextBoxObjeto.Text;
            _convenioCriado.DataInicio = DateTime.Now;
            _convenioCriado.DataTermino = dateTimePickerDataTermino.Value;
            /*
            try
            {
                _servicoEndereco.Criar(_enderecoCriado);
                Close();
            }
            catch (Exception excecao)
            {
                var listaErros = new List<string>();
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);
            }
            */
        }

        private void AoCLicar_botaoCancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void AoPressionarTecla_textBoxValor(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoPressionarTecla_textBoxNumeroProcesso(object sender, KeyPressEventArgs e)
        {
            const int tamanhoMaximoCep = 8;

            if (textBoxNumeroProcesso.Text.Length == tamanhoMaximoCep && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoRequererPintura_panelEmpresas(object sender, PaintEventArgs e)
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

        private void AoRequererPintura_panelEscolas(object sender, PaintEventArgs e)
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
                                                                   panelDataGrid.Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   panelDataGrid.Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   panelDataGrid.Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   panelDataGrid.Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }
        }

        private void AoAlterarValor_dateTimePickerDataInicioAtividade(object sender, EventArgs e)
        {
            if (dateTimePickerDataTermino.Value > DateTime.Now)
            {
                dateTimePickerDataTermino.Value = DateTime.Now;
            }
        }

        private void AoClicar_botaoEscola(object sender, EventArgs e)
        {
            dataGridViewEscolasEmpresas.DataSource = _servicoEscola.ObterTodos(null);

            botaoEscolaAtivo = true;

            ConfiguraGradeEscola();
        }

        private void AoClicar_botaoEmpresa(object sender, EventArgs e)
        {
            dataGridViewEscolasEmpresas.DataSource = _servicoEmpresa.ObterTodos(null);

            botaoEscolaAtivo = false;

            ConfiguraGradeEmpresa();
        }

        private void ConfiguraGradeEmpresa()
        {
            dataGridViewEscolasEmpresas.Columns[0].HeaderCell.Value = "Código Empresa";
            dataGridViewEscolasEmpresas.Columns[1].HeaderCell.Value = "Razão Social";
            dataGridViewEscolasEmpresas.Columns[2].HeaderCell.Value = "Nome Fantasia";
            dataGridViewEscolasEmpresas.Columns[3].HeaderCell.Value = "CNPJ";
            dataGridViewEscolasEmpresas.Columns[4].HeaderCell.Value = "Situação Cadastral";
            dataGridViewEscolasEmpresas.Columns[5].HeaderCell.Value = "Data da Alteração Situação Cadastral";
            dataGridViewEscolasEmpresas.Columns[6].HeaderCell.Value = "Idade";
            dataGridViewEscolasEmpresas.Columns[7].HeaderCell.Value = "Data de Abertura";
            dataGridViewEscolasEmpresas.Columns[8].HeaderCell.Value = "Natureza Juridica";
            dataGridViewEscolasEmpresas.Columns[9].HeaderCell.Value = "Porte";
            dataGridViewEscolasEmpresas.Columns[10].HeaderCell.Value = "Matriz ou Filial";
            dataGridViewEscolasEmpresas.Columns[11].HeaderCell.Value = "Capital Social";
            dataGridViewEscolasEmpresas.Columns[12].HeaderCell.Value = "Código Endereço";
            dataGridViewEscolasEmpresas.Columns[13].HeaderCell.Value = "Estado";

            foreach (DataGridViewColumn coluna in dataGridViewEscolasEmpresas.Columns)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            dataGridViewEscolasEmpresas.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolasEmpresas.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEscolasEmpresas.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolasEmpresas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEscolasEmpresas.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewEscolasEmpresas.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolasEmpresas.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewEscolasEmpresas.EnableHeadersVisualStyles = false;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Cyan;
        }

        private void ConfiguraGradeEscola()
        {
            dataGridViewEscolasEmpresas.Columns[0].HeaderCell.Value = "Código Escola";
            dataGridViewEscolasEmpresas.Columns[1].HeaderCell.Value = "Status Atividade";
            dataGridViewEscolasEmpresas.Columns[2].HeaderCell.Value = "Nome";
            dataGridViewEscolasEmpresas.Columns[3].HeaderCell.Value = "Código Mec";
            dataGridViewEscolasEmpresas.Columns[4].HeaderCell.Value = "Telefone";
            dataGridViewEscolasEmpresas.Columns[5].HeaderCell.Value = "E-Mail";
            dataGridViewEscolasEmpresas.Columns[6].HeaderCell.Value = "Data Início da Atividade";
            dataGridViewEscolasEmpresas.Columns[7].HeaderCell.Value = "Categoria Administrativa";
            dataGridViewEscolasEmpresas.Columns[8].HeaderCell.Value = "Organização Acadêmica";
            dataGridViewEscolasEmpresas.Columns[9].HeaderCell.Value = "Código Endereço";
            dataGridViewEscolasEmpresas.Columns[10].HeaderCell.Value = "Estado";

            foreach (DataGridViewColumn coluna in dataGridViewEscolasEmpresas.Columns)
            {
                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            dataGridViewEscolasEmpresas.DefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolasEmpresas.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEscolasEmpresas.DefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolasEmpresas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEscolasEmpresas.DefaultCellStyle.SelectionBackColor = Color.Cyan;

            dataGridViewEscolasEmpresas.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolasEmpresas.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridViewEscolasEmpresas.EnableHeadersVisualStyles = false;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Lime;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Cyan;
        }

        private void AoFormatarCelula_dataGridViewEscolasEmpresas(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridViewEscolasEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Natureza Juridica")
            {
                NaturezaJuridicaEnums valorEnum = (NaturezaJuridicaEnums)e.Value;
                e.Value = valorEnum.RetornaDescricao();

            }

            if (dataGridViewEscolasEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Porte")
            {
                PorteEnums valorEnum = (PorteEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolasEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Matriz ou Filial")
            {
                MatrizFilialEnums valorEnum = (MatrizFilialEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolasEmpresas.Columns[e.ColumnIndex].Name == "Estado")
            {
                EstadoEnums valorEnum = (EstadoEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolasEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Categoria Administrativa")
            {
                CategoriaAdministrativaEnums valorEnum = (CategoriaAdministrativaEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }

            if (dataGridViewEscolasEmpresas.Columns[e.ColumnIndex].HeaderCell.Value == "Organização Acadêmica")
            {
                OrganizacaoAcademicaEnums valorEnum = (OrganizacaoAcademicaEnums)e.Value;
                string descricaoEnum = valorEnum.RetornaDescricao();
                e.Value = descricaoEnum;
            }
        }

        private void AoClicar_botaoSelecionar(object sender, EventArgs e)
        {
            if(botaoEscolaAtivo)
            {
               // if (dataGridViewEscolasEmpresas.SelectedCells[0] )
            }
            else
            {

            }
        }
    }
}
