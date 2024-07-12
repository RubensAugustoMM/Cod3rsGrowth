using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarConvenioForm : Form
    {
        private PrivateFontCollection _pixeboy;
        private readonly ServicoConvenio _servicoConvenio;
        private readonly ServicoEscola _servicoEscola;
        private readonly ServicoEmpresa _servicoEmpresa;
        private bool _botaoEscolaAtivo;
        private bool _botaoEmpresaAtivo;
        private int _idEscolaSelecionada = -1;
        private int _idEmpresaSelecionada = -1;

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

            _botaoEmpresaAtivo = false;
            _botaoEscolaAtivo = true;
            listBoxEscolaEmpresa.DataSource = _servicoEscola.ObterTodos(null);

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
            const int altura = 85;
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
            Convenio convenioCriado = new();

            convenioCriado.NumeroProcesso = CriaValorNumeroProcesso(); 

            if (!string.IsNullOrEmpty(textBoxValor.Text))
            {
                convenioCriado.Valor = decimal.Parse(textBoxValor.Text);
            }
            else
            {
                convenioCriado.Valor = -1;
            }
            
            convenioCriado.Objeto = richTextBoxObjeto.Text;
            convenioCriado.DataInicio =
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); 
            convenioCriado.DataTermino =
                new DateTime(dateTimePickerDataTermino.Value.Year, 
                    dateTimePickerDataTermino.Value.Month, dateTimePickerDataTermino.Value.Day);
            convenioCriado.IdEmpresa = _idEmpresaSelecionada;
            convenioCriado.IdEscola = _idEscolaSelecionada;
            
            try
            {
                _servicoConvenio.Criar(convenioCriado);
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
            
        }

        private void AoCLicar_botaoCancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void AoPressionarTecla_textBoxValor(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(",") != -1))
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
            if (dateTimePickerDataTermino.Value < DateTime.Now)
            {
                dateTimePickerDataTermino.Value = 
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); 
            }
        }

        private void AoClicar_botaoEscola(object sender, EventArgs e)
        {
            _botaoEmpresaAtivo = false;
            _botaoEscolaAtivo = true;

            listBoxEscolaEmpresa.DataSource = _servicoEscola.ObterTodos(null);
        }

        private void AoClicar_botaoEmpresa(object sender, EventArgs e)
        {
            _botaoEscolaAtivo = false;
            _botaoEmpresaAtivo = true;

            listBoxEscolaEmpresa.DataSource = _servicoEmpresa.ObterTodos(null);
        }

        private void AoFormatar_listBoxEscolaEmpresa(object sender, ListControlConvertEventArgs e)
        {
            if (_botaoEscolaAtivo)
            {
                EscolaEnderecoOtd escola = (EscolaEnderecoOtd)e.Value;

                e.Value = escola.Id.ToString() + " || " +
                    escola.Nome + " || " + escola.CodigoMec + " || " + escola.Estado.RetornaDescricao();
            }

            if (_botaoEmpresaAtivo)
            {
                EmpresaEnderecoOtd empresa = (EmpresaEnderecoOtd)e.Value;

                e.Value = empresa.Id.ToString() + " || "
                    + empresa.RazaoSocial + " || " + empresa.Cnpj + " || " + empresa.Estado.RetornaDescricao();
            }
        }

        private void AoMudarIndexSelecionado_listBoxEscolaEmpresa(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;

            if(_botaoEmpresaAtivo && !_botaoEscolaAtivo)
            {
                EmpresaEnderecoOtd empresaSelecionada = (EmpresaEnderecoOtd)listBox.SelectedItem;
                textBoxEmpresaSelecionada.Text = empresaSelecionada.RazaoSocial;
                textBoxEmpresaSelecionada.ForeColor = Color.LimeGreen;

                _idEmpresaSelecionada = empresaSelecionada.Id;
            }

            if(_botaoEscolaAtivo && !_botaoEmpresaAtivo)
            {
                EscolaEnderecoOtd EscolaSelecionada = (EscolaEnderecoOtd)listBoxEscolaEmpresa.SelectedItem;
                textBoxEscolaSelecionada.Text = EscolaSelecionada.Nome;
                textBoxEscolaSelecionada.ForeColor = Color.LimeGreen;

                _idEscolaSelecionada = EscolaSelecionada.Id;
            }
        }

        private int CriaValorNumeroProcesso()
        {
            var listaConvenios = _servicoConvenio.ObterTodos(null);
            var maiorNumeroProcesso = listaConvenios[0].NumeroProcesso;

            foreach(var convenio in listaConvenios)
            {
                if(convenio.NumeroProcesso > maiorNumeroProcesso)
                {
                    maiorNumeroProcesso = convenio.NumeroProcesso;
                }
            }

            return maiorNumeroProcesso +1;
        }
    }
}
