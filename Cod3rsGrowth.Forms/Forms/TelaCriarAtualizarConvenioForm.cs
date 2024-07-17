using Cod3rsGrowth.Dominio.Enums.Extencoes;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.ObjetosTranferenciaDados;
using Cod3rsGrowth.Servico;
using LinqToDB.Common;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class TelaCriarAtualizarConvenioForm : Form
    {
        private const int _tamanhoFonte = 12;

        private readonly ServicoConvenio _servicoConvenio;
        private readonly ServicoEscola _servicoEscola;
        private readonly ServicoEmpresa _servicoEmpresa;

        private PrivateFontCollection _pixeboy;
        private ConvenioEscolaEmpresaOtd _convenioEscolaEmpresaOtdAtualizar = null;
        private bool _botaoEscolaAtivo;
        private bool _botaoEmpresaAtivo;
        private int _idEscolaSelecionada = -1;
        private int _idEmpresaSelecionada = -1;

        public TelaCriarAtualizarConvenioForm(ServicoConvenio servicoConvenio, ServicoEmpresa servicoEmpresa, ServicoEscola servicoEscola)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _servicoEscola = servicoEscola;
            _servicoConvenio = servicoConvenio;
        }

        public TelaCriarAtualizarConvenioForm(ServicoConvenio servicoConvenio, ServicoEmpresa servicoEmpresa, ServicoEscola servicoEscola, ConvenioEscolaEmpresaOtd convenioEscolaEmpresaOtdAtualizar)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _servicoEscola = servicoEscola;
            _servicoConvenio = servicoConvenio;
            _convenioEscolaEmpresaOtdAtualizar = convenioEscolaEmpresaOtdAtualizar;
        }

        private void AoCarregarTela(object sender, EventArgs e)
        {
            InicializaFontePixeBoy();

            _botaoEmpresaAtivo = false;
            _botaoEscolaAtivo = true;
            listBoxEscolaEmpresa.DataSource = _servicoEscola.ObterTodos(null);

            if(_convenioEscolaEmpresaOtdAtualizar != null) 
            {
                ConfiguraTelaParaAtualizar();
            }

            labelTitulo.Location = new Point((Width - panelDataGrid.Width)/2 - labelTitulo.Width / 2, labelTitulo.Location.Y);

            richTextBoxObjeto.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);

            foreach (Control c in Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);
                ConfiguraFonte(c);
            }
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

            string caminhoDados = Environment.CurrentDirectory;
            caminhoDados = caminhoDados.Replace("bin\\Debug\\net7.0-windows", "");
            string caminhaDados = Path.Combine(caminhoDados, "Resources\\Pixeboy-z8XGD.ttf");

            _pixeboy.AddFontFile(caminhaDados);
        }

        private void AoPintarPainelBotoes(object sender, PaintEventArgs e)
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
                c.Font = new Font(_pixeboy.Families[0], _tamanhoFonte, FontStyle.Bold);

                if (!c.Controls.IsNullOrEmpty())
                    ConfiguraFonte(c);
            }
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {

                if (_convenioEscolaEmpresaOtdAtualizar == null)
                {
                    Convenio convenioCriado = new();
                    RecebeDadosDaTelaConvenio(convenioCriado);
                    _servicoConvenio.Criar(convenioCriado);
                }
                else
                {
                    Convenio convenioAtualizar = RetornaModeloConvenio(_convenioEscolaEmpresaOtdAtualizar);

                    RecebeDadosDaTelaConvenio(convenioAtualizar);
                    _servicoConvenio.Atualizar(convenioAtualizar);
                }
                Close();
            }
            catch (Exception excecao)
            {
                const char Separador = '\n';

                var listaErros = new List<string>();
                listaErros.AddRange(excecao.Message.Split(Separador));
                var caixaDialogoErro = new TelaCaixaDialogoErroForm(listaErros);

                caixaDialogoErro.StartPosition = FormStartPosition.CenterParent;
                caixaDialogoErro.TopLevel = true;

                caixaDialogoErro.ShowDialog(this);
            }
        }

        private void RecebeDadosDaTelaConvenio(Convenio convenioCriado)
        {
            convenioCriado.NumeroProcesso = CriaValorNumeroProcesso();

            if (!string.IsNullOrEmpty(textBoxValor.Text))
            {
                convenioCriado.Valor = decimal.Parse(textBoxValor.Text);
            }
            else
            {
                const int valorInvalido = -1;
                convenioCriado.Valor = valorInvalido;
            }

            convenioCriado.Objeto = richTextBoxObjeto.Text;

            if (_convenioEscolaEmpresaOtdAtualizar == null)
            {
                convenioCriado.DataInicio =
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
            else
            {
                convenioCriado.DataInicio = _convenioEscolaEmpresaOtdAtualizar.DataInicio;
            }

            convenioCriado.DataTermino =
                new DateTime(dateTimePickerDataTermino.Value.Year,
                    dateTimePickerDataTermino.Value.Month, dateTimePickerDataTermino.Value.Day);
            convenioCriado.IdEmpresa = _idEmpresaSelecionada;
            convenioCriado.IdEscola = _idEscolaSelecionada;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            Close();
        }

        private void AoPressionarTeclaEmCaixaTextoValor(object sender, KeyPressEventArgs e)
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

        private void AoPintarpainelEscolas(object sender, PaintEventArgs e)
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

        private void AoPintarPainelEscolas(object sender, PaintEventArgs e)
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

        private void AoAlterarValorDateTimePickerDataTermino(object sender, EventArgs e)
        {
            if (dateTimePickerDataTermino.Value < DateTime.Now)
            {
                dateTimePickerDataTermino.Value = 
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); 
            }
        }

        private void AoClicarEmEscola(object sender, EventArgs e)
        {
            _botaoEmpresaAtivo = false;
            _botaoEscolaAtivo = true;

            listBoxEscolaEmpresa.DataSource = _servicoEscola.ObterTodos(null);
        }

        private void AoClicarEmEmpresa(object sender, EventArgs e)
        {
            _botaoEscolaAtivo = false;
            _botaoEmpresaAtivo = true;

            listBoxEscolaEmpresa.DataSource = _servicoEmpresa.ObterTodos(null);
        }

        private void AoFormatarListBoxEscolaEmpresa(object sender, ListControlConvertEventArgs e)
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

        private void AoMudarIndexSelecionadoListBoxEscolaEmpresa(object sender, EventArgs e)
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
            int maiorNumeroProcesso = 0;
            if (!listaConvenios.IsNullOrEmpty())
            {
                maiorNumeroProcesso = listaConvenios[0].NumeroProcesso;

                foreach (var convenio in listaConvenios)
                {
                    if (convenio.NumeroProcesso > maiorNumeroProcesso)
                    {
                        maiorNumeroProcesso = convenio.NumeroProcesso;
                    }
                }
            }

            return maiorNumeroProcesso +1;
        }

        private void ConfiguraTelaParaAtualizar()
        {
            textBoxValor.Text = _convenioEscolaEmpresaOtdAtualizar.Valor.ToString();
            richTextBoxObjeto.Text = _convenioEscolaEmpresaOtdAtualizar.Objeto;
            dateTimePickerDataTermino.Value = _convenioEscolaEmpresaOtdAtualizar.DataTermino.Value;

            _idEmpresaSelecionada = _convenioEscolaEmpresaOtdAtualizar.IdEmpresa;
            var empresa = _servicoEmpresa.ObterPorId(_idEmpresaSelecionada);
            textBoxEmpresaSelecionada.Text = empresa.RazaoSocial;
            textBoxEmpresaSelecionada.ForeColor = Color.LimeGreen;

            _idEscolaSelecionada = _convenioEscolaEmpresaOtdAtualizar.IdEscola;
            var escola = _servicoEscola.ObterPorId(_idEscolaSelecionada);
            textBoxEscolaSelecionada.Text = escola.Nome;
            textBoxEscolaSelecionada.ForeColor = Color.LimeGreen;

            labelTitulo.Text = "Atualizar Convênio";
        }

        private Convenio RetornaModeloConvenio(ConvenioEscolaEmpresaOtd convenioOtd)
        {
            Convenio ConvenioRetorno = new Convenio();

            ConvenioRetorno.Id = convenioOtd.Id;
            ConvenioRetorno.NumeroProcesso = convenioOtd.NumeroProcesso;
            ConvenioRetorno.Objeto = convenioOtd.Objeto;
            ConvenioRetorno.Valor = convenioOtd.Valor;
            ConvenioRetorno.DataInicio = convenioOtd.DataInicio;
            ConvenioRetorno.DataTermino = convenioOtd.DataTermino;
            ConvenioRetorno.IdEscola = convenioOtd.IdEscola;
            ConvenioRetorno.IdEmpresa = convenioOtd.IdEmpresa;

            return ConvenioRetorno;
        }
    }
}
