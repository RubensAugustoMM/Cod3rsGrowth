namespace Cod3rsGrowth.Forms.Controladores
{
    partial class FiltroEmpresaUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            labelRazaoSocial = new Label();
            labelNomeFantasia = new Label();
            labelCnpj = new Label();
            labelSituacaoCadastral = new Label();
            labelDataSituacaoCadastral = new Label();
            labelDataAbertura = new Label();
            labelCapitalSocial = new Label();
            labelPorte = new Label();
            labelNaturezaJuridica = new Label();
            labelMatrizFilial = new Label();
            textBoxRazaoSocial = new TextBox();
            textBoxNomeFantasia = new TextBox();
            textBoxCnpj = new TextBox();
            textBoxCapitalSocial = new TextBox();
            labelIdade = new Label();
            textBoxIdade = new TextBox();
            comboBoxNaturezaJuridica = new ComboBox();
            comboBoxPorte = new ComboBox();
            comboBoxMatrizFilial = new ComboBox();
            dateTimePickerDataSituacaoCadastral = new DateTimePicker();
            dateTimePickerDataAbertura = new DateTimePicker();
            panel2 = new Panel();
            botaoFechar = new Button();
            panel1 = new Panel();
            botaoLimpar = new Button();
            panelBotaoFiltrar = new Panel();
            botaoFiltrar = new Button();
            comboMaiorMenorIgualIdade = new ComboBox();
            comboBoxMaiorMenorIgualCapitalSocial = new ComboBox();
            comboBoxMaiorMenorIgualDataSituacaoCadastral = new ComboBox();
            comboBoxMaiorMenorIgualDataAbertura = new ComboBox();
            panelFiltro = new Panel();
            comboBoxEstado = new ComboBox();
            labelEstado = new Label();
            comboBoxHabilitadoSituacaoCadastral = new ComboBox();
            labelTitulo = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoFiltrar.SuspendLayout();
            panelFiltro.SuspendLayout();
            SuspendLayout();
            // 
            // labelRazaoSocial
            // 
            labelRazaoSocial.AutoSize = true;
            labelRazaoSocial.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelRazaoSocial.ForeColor = Color.White;
            labelRazaoSocial.Location = new Point(12, 17);
            labelRazaoSocial.Name = "labelRazaoSocial";
            labelRazaoSocial.Size = new Size(190, 19);
            labelRazaoSocial.TabIndex = 23;
            labelRazaoSocial.Text = "Razao Social . . . . . . . . . . .: ";
            // 
            // labelNomeFantasia
            // 
            labelNomeFantasia.AutoSize = true;
            labelNomeFantasia.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelNomeFantasia.ForeColor = Color.White;
            labelNomeFantasia.Location = new Point(12, 38);
            labelNomeFantasia.Name = "labelNomeFantasia";
            labelNomeFantasia.Size = new Size(196, 19);
            labelNomeFantasia.TabIndex = 24;
            labelNomeFantasia.Text = "Nome Fantasia . . . . . . . . . . :";
            // 
            // labelCnpj
            // 
            labelCnpj.AutoSize = true;
            labelCnpj.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelCnpj.ForeColor = Color.White;
            labelCnpj.Location = new Point(12, 59);
            labelCnpj.Name = "labelCnpj";
            labelCnpj.Size = new Size(203, 19);
            labelCnpj.TabIndex = 25;
            labelCnpj.Text = "CNPJ . . . . . . . . . . . . . . . . . . . :";
            // 
            // labelSituacaoCadastral
            // 
            labelSituacaoCadastral.AutoSize = true;
            labelSituacaoCadastral.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelSituacaoCadastral.ForeColor = Color.White;
            labelSituacaoCadastral.Location = new Point(12, 186);
            labelSituacaoCadastral.Name = "labelSituacaoCadastral";
            labelSituacaoCadastral.Size = new Size(177, 19);
            labelSituacaoCadastral.TabIndex = 26;
            labelSituacaoCadastral.Text = "Situação Cadastral . . . . .:";
            // 
            // labelDataSituacaoCadastral
            // 
            labelDataSituacaoCadastral.AutoSize = true;
            labelDataSituacaoCadastral.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelDataSituacaoCadastral.ForeColor = Color.White;
            labelDataSituacaoCadastral.Location = new Point(12, 226);
            labelDataSituacaoCadastral.Name = "labelDataSituacaoCadastral";
            labelDataSituacaoCadastral.Size = new Size(172, 19);
            labelDataSituacaoCadastral.TabIndex = 27;
            labelDataSituacaoCadastral.Text = "Data Situação Cadastral:";
            // 
            // labelDataAbertura
            // 
            labelDataAbertura.AutoSize = true;
            labelDataAbertura.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelDataAbertura.ForeColor = Color.White;
            labelDataAbertura.Location = new Point(12, 247);
            labelDataAbertura.Name = "labelDataAbertura";
            labelDataAbertura.Size = new Size(192, 19);
            labelDataAbertura.TabIndex = 28;
            labelDataAbertura.Text = "Data Abertura . . . . . . . . . . :";
            // 
            // labelCapitalSocial
            // 
            labelCapitalSocial.AutoSize = true;
            labelCapitalSocial.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelCapitalSocial.ForeColor = Color.White;
            labelCapitalSocial.Location = new Point(12, 101);
            labelCapitalSocial.Name = "labelCapitalSocial";
            labelCapitalSocial.Size = new Size(170, 19);
            labelCapitalSocial.TabIndex = 29;
            labelCapitalSocial.Text = "Capital social . . . . . . . . :";
            // 
            // labelPorte
            // 
            labelPorte.AutoSize = true;
            labelPorte.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelPorte.ForeColor = Color.White;
            labelPorte.Location = new Point(12, 143);
            labelPorte.Name = "labelPorte";
            labelPorte.Size = new Size(198, 19);
            labelPorte.TabIndex = 30;
            labelPorte.Text = "Porte . . . . . . . . . . . . . . . . . . :";
            // 
            // labelNaturezaJuridica
            // 
            labelNaturezaJuridica.AutoSize = true;
            labelNaturezaJuridica.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelNaturezaJuridica.ForeColor = Color.White;
            labelNaturezaJuridica.Location = new Point(12, 122);
            labelNaturezaJuridica.Name = "labelNaturezaJuridica";
            labelNaturezaJuridica.Size = new Size(174, 19);
            labelNaturezaJuridica.TabIndex = 31;
            labelNaturezaJuridica.Text = "Natureza Juridica . . . . . :";
            // 
            // labelMatrizFilial
            // 
            labelMatrizFilial.AutoSize = true;
            labelMatrizFilial.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelMatrizFilial.ForeColor = Color.White;
            labelMatrizFilial.Location = new Point(12, 164);
            labelMatrizFilial.Name = "labelMatrizFilial";
            labelMatrizFilial.Size = new Size(172, 19);
            labelMatrizFilial.TabIndex = 32;
            labelMatrizFilial.Text = "Matriz ou Filial . . . . . . . :";
            // 
            // textBoxRazaoSocial
            // 
            textBoxRazaoSocial.BackColor = Color.Black;
            textBoxRazaoSocial.BorderStyle = BorderStyle.None;
            textBoxRazaoSocial.ForeColor = Color.White;
            textBoxRazaoSocial.Location = new Point(217, 15);
            textBoxRazaoSocial.Name = "textBoxRazaoSocial";
            textBoxRazaoSocial.Size = new Size(149, 16);
            textBoxRazaoSocial.TabIndex = 33;
            // 
            // textBoxNomeFantasia
            // 
            textBoxNomeFantasia.BackColor = Color.Black;
            textBoxNomeFantasia.BorderStyle = BorderStyle.None;
            textBoxNomeFantasia.ForeColor = Color.White;
            textBoxNomeFantasia.Location = new Point(217, 36);
            textBoxNomeFantasia.Name = "textBoxNomeFantasia";
            textBoxNomeFantasia.Size = new Size(149, 16);
            textBoxNomeFantasia.TabIndex = 34;
            // 
            // textBoxCnpj
            // 
            textBoxCnpj.BackColor = Color.Black;
            textBoxCnpj.BorderStyle = BorderStyle.None;
            textBoxCnpj.ForeColor = Color.White;
            textBoxCnpj.Location = new Point(217, 58);
            textBoxCnpj.Name = "textBoxCnpj";
            textBoxCnpj.Size = new Size(149, 16);
            textBoxCnpj.TabIndex = 35;
            textBoxCnpj.KeyPress += AoPressionarTeclaTextBoxCnpj;
            // 
            // textBoxCapitalSocial
            // 
            textBoxCapitalSocial.BackColor = Color.Black;
            textBoxCapitalSocial.BorderStyle = BorderStyle.None;
            textBoxCapitalSocial.ForeColor = Color.White;
            textBoxCapitalSocial.Location = new Point(217, 100);
            textBoxCapitalSocial.Name = "textBoxCapitalSocial";
            textBoxCapitalSocial.Size = new Size(149, 16);
            textBoxCapitalSocial.TabIndex = 37;
            textBoxCapitalSocial.KeyPress += AoPressionarTeclaTextBoxSomenteValoresReais;
            // 
            // labelIdade
            // 
            labelIdade.AutoSize = true;
            labelIdade.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelIdade.ForeColor = Color.White;
            labelIdade.Location = new Point(10, 80);
            labelIdade.Name = "labelIdade";
            labelIdade.Size = new Size(199, 19);
            labelIdade.TabIndex = 38;
            labelIdade.Text = "Idade . . . . . . . . . . . . . . . . . . :\r\n";
            // 
            // textBoxIdade
            // 
            textBoxIdade.BackColor = Color.Black;
            textBoxIdade.BorderStyle = BorderStyle.None;
            textBoxIdade.ForeColor = Color.White;
            textBoxIdade.Location = new Point(217, 80);
            textBoxIdade.Name = "textBoxIdade";
            textBoxIdade.Size = new Size(149, 16);
            textBoxIdade.TabIndex = 39;
            textBoxIdade.KeyPress += AoPressionarTeclaTextBoxSomenteValoresNaturais;
            // 
            // comboBoxNaturezaJuridica
            // 
            comboBoxNaturezaJuridica.BackColor = Color.Black;
            comboBoxNaturezaJuridica.FlatStyle = FlatStyle.Flat;
            comboBoxNaturezaJuridica.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxNaturezaJuridica.ForeColor = Color.White;
            comboBoxNaturezaJuridica.FormattingEnabled = true;
            comboBoxNaturezaJuridica.Location = new Point(217, 118);
            comboBoxNaturezaJuridica.Name = "comboBoxNaturezaJuridica";
            comboBoxNaturezaJuridica.Size = new Size(149, 23);
            comboBoxNaturezaJuridica.TabIndex = 40;
            comboBoxNaturezaJuridica.Format += AoFormatarComboBoxNaturezaJuridica;
            // 
            // comboBoxPorte
            // 
            comboBoxPorte.BackColor = Color.Black;
            comboBoxPorte.FlatStyle = FlatStyle.Flat;
            comboBoxPorte.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxPorte.ForeColor = Color.White;
            comboBoxPorte.FormattingEnabled = true;
            comboBoxPorte.Location = new Point(217, 137);
            comboBoxPorte.Name = "comboBoxPorte";
            comboBoxPorte.Size = new Size(149, 23);
            comboBoxPorte.TabIndex = 41;
            comboBoxPorte.Format += AoFormatarComboBoxPorte;
            // 
            // comboBoxMatrizFilial
            // 
            comboBoxMatrizFilial.BackColor = Color.Black;
            comboBoxMatrizFilial.FlatStyle = FlatStyle.Flat;
            comboBoxMatrizFilial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMatrizFilial.ForeColor = Color.White;
            comboBoxMatrizFilial.FormattingEnabled = true;
            comboBoxMatrizFilial.Location = new Point(217, 160);
            comboBoxMatrizFilial.Name = "comboBoxMatrizFilial";
            comboBoxMatrizFilial.Size = new Size(149, 23);
            comboBoxMatrizFilial.TabIndex = 42;
            // 
            // dateTimePickerDataSituacaoCadastral
            // 
            dateTimePickerDataSituacaoCadastral.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataSituacaoCadastral.CalendarForeColor = Color.White;
            dateTimePickerDataSituacaoCadastral.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataSituacaoCadastral.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataSituacaoCadastral.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataSituacaoCadastral.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataSituacaoCadastral.Format = DateTimePickerFormat.Short;
            dateTimePickerDataSituacaoCadastral.Location = new Point(217, 220);
            dateTimePickerDataSituacaoCadastral.Name = "dateTimePickerDataSituacaoCadastral";
            dateTimePickerDataSituacaoCadastral.Size = new Size(149, 23);
            dateTimePickerDataSituacaoCadastral.TabIndex = 43;
            dateTimePickerDataSituacaoCadastral.ValueChanged += AoAlterarValorDateTimePickerDataSituacaoCadastral;
            // 
            // dateTimePickerDataAbertura
            // 
            dateTimePickerDataAbertura.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataAbertura.CalendarForeColor = Color.White;
            dateTimePickerDataAbertura.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataAbertura.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataAbertura.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataAbertura.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataAbertura.Format = DateTimePickerFormat.Short;
            dateTimePickerDataAbertura.Location = new Point(217, 243);
            dateTimePickerDataAbertura.Name = "dateTimePickerDataAbertura";
            dateTimePickerDataAbertura.Size = new Size(149, 23);
            dateTimePickerDataAbertura.TabIndex = 44;
            dateTimePickerDataAbertura.ValueChanged += AoAlterarValorDateTimePickerDataAbertura;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(botaoFechar);
            panel2.Location = new Point(167, 268);
            panel2.Name = "panel2";
            panel2.Size = new Size(106, 40);
            panel2.TabIndex = 60;
            panel2.Paint += AoPintarPainelBotoes;
            // 
            // botaoFechar
            // 
            botaoFechar.BackColor = Color.Green;
            botaoFechar.FlatAppearance.BorderSize = 0;
            botaoFechar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFechar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoFechar.FlatStyle = FlatStyle.Flat;
            botaoFechar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoFechar.ForeColor = Color.White;
            botaoFechar.Location = new Point(3, 3);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new Size(85, 27);
            botaoFechar.TabIndex = 14;
            botaoFechar.Text = "Fechar";
            botaoFechar.UseVisualStyleBackColor = false;
            botaoFechar.Click += AoClicarEmFechar;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(botaoLimpar);
            panel1.Location = new Point(279, 268);
            panel1.Name = "panel1";
            panel1.Size = new Size(106, 40);
            panel1.TabIndex = 59;
            panel1.Paint += AoPintarPainelBotoes;
            // 
            // botaoLimpar
            // 
            botaoLimpar.BackColor = Color.Green;
            botaoLimpar.FlatAppearance.BorderSize = 0;
            botaoLimpar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoLimpar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoLimpar.FlatStyle = FlatStyle.Flat;
            botaoLimpar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoLimpar.ForeColor = Color.White;
            botaoLimpar.Location = new Point(3, 3);
            botaoLimpar.Name = "botaoLimpar";
            botaoLimpar.Size = new Size(85, 27);
            botaoLimpar.TabIndex = 22;
            botaoLimpar.Text = "Limpar";
            botaoLimpar.UseVisualStyleBackColor = false;
            botaoLimpar.Click += AoClicarEmLimpar;
            // 
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.BackColor = Color.Transparent;
            panelBotaoFiltrar.Controls.Add(botaoFiltrar);
            panelBotaoFiltrar.Location = new Point(391, 268);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(106, 40);
            panelBotaoFiltrar.TabIndex = 58;
            panelBotaoFiltrar.Paint += AoPintarPainelBotoes;
            // 
            // botaoFiltrar
            // 
            botaoFiltrar.BackColor = Color.Green;
            botaoFiltrar.FlatAppearance.BorderSize = 0;
            botaoFiltrar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFiltrar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoFiltrar.FlatStyle = FlatStyle.Flat;
            botaoFiltrar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoFiltrar.ForeColor = Color.White;
            botaoFiltrar.Location = new Point(3, 3);
            botaoFiltrar.Name = "botaoFiltrar";
            botaoFiltrar.Size = new Size(85, 27);
            botaoFiltrar.TabIndex = 31;
            botaoFiltrar.Text = "Filtrar";
            botaoFiltrar.UseVisualStyleBackColor = false;
            botaoFiltrar.Click += AoClicarEmFiltrar;
            // 
            // comboMaiorMenorIgualIdade
            // 
            comboMaiorMenorIgualIdade.BackColor = Color.Black;
            comboMaiorMenorIgualIdade.FlatStyle = FlatStyle.Flat;
            comboMaiorMenorIgualIdade.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboMaiorMenorIgualIdade.ForeColor = Color.White;
            comboMaiorMenorIgualIdade.FormattingEnabled = true;
            comboMaiorMenorIgualIdade.Location = new Point(372, 78);
            comboMaiorMenorIgualIdade.Name = "comboMaiorMenorIgualIdade";
            comboMaiorMenorIgualIdade.Size = new Size(125, 23);
            comboMaiorMenorIgualIdade.TabIndex = 61;
            // 
            // comboBoxMaiorMenorIgualCapitalSocial
            // 
            comboBoxMaiorMenorIgualCapitalSocial.BackColor = Color.Black;
            comboBoxMaiorMenorIgualCapitalSocial.FlatStyle = FlatStyle.Flat;
            comboBoxMaiorMenorIgualCapitalSocial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMaiorMenorIgualCapitalSocial.ForeColor = Color.White;
            comboBoxMaiorMenorIgualCapitalSocial.FormattingEnabled = true;
            comboBoxMaiorMenorIgualCapitalSocial.Location = new Point(372, 100);
            comboBoxMaiorMenorIgualCapitalSocial.Name = "comboBoxMaiorMenorIgualCapitalSocial";
            comboBoxMaiorMenorIgualCapitalSocial.Size = new Size(125, 23);
            comboBoxMaiorMenorIgualCapitalSocial.TabIndex = 62;
            // 
            // comboBoxMaiorMenorIgualDataSituacaoCadastral
            // 
            comboBoxMaiorMenorIgualDataSituacaoCadastral.BackColor = Color.Black;
            comboBoxMaiorMenorIgualDataSituacaoCadastral.FlatStyle = FlatStyle.Flat;
            comboBoxMaiorMenorIgualDataSituacaoCadastral.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMaiorMenorIgualDataSituacaoCadastral.ForeColor = Color.White;
            comboBoxMaiorMenorIgualDataSituacaoCadastral.FormattingEnabled = true;
            comboBoxMaiorMenorIgualDataSituacaoCadastral.Location = new Point(372, 220);
            comboBoxMaiorMenorIgualDataSituacaoCadastral.Name = "comboBoxMaiorMenorIgualDataSituacaoCadastral";
            comboBoxMaiorMenorIgualDataSituacaoCadastral.Size = new Size(125, 23);
            comboBoxMaiorMenorIgualDataSituacaoCadastral.TabIndex = 63;
            // 
            // comboBoxMaiorMenorIgualDataAbertura
            // 
            comboBoxMaiorMenorIgualDataAbertura.BackColor = Color.Black;
            comboBoxMaiorMenorIgualDataAbertura.FlatStyle = FlatStyle.Flat;
            comboBoxMaiorMenorIgualDataAbertura.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMaiorMenorIgualDataAbertura.ForeColor = Color.White;
            comboBoxMaiorMenorIgualDataAbertura.FormattingEnabled = true;
            comboBoxMaiorMenorIgualDataAbertura.Location = new Point(372, 242);
            comboBoxMaiorMenorIgualDataAbertura.Name = "comboBoxMaiorMenorIgualDataAbertura";
            comboBoxMaiorMenorIgualDataAbertura.Size = new Size(125, 23);
            comboBoxMaiorMenorIgualDataAbertura.TabIndex = 64;
            // 
            // panelFiltro
            // 
            panelFiltro.BackColor = Color.DarkGray;
            panelFiltro.Controls.Add(comboBoxEstado);
            panelFiltro.Controls.Add(labelEstado);
            panelFiltro.Controls.Add(comboBoxHabilitadoSituacaoCadastral);
            panelFiltro.Controls.Add(labelTitulo);
            panelFiltro.Controls.Add(labelRazaoSocial);
            panelFiltro.Controls.Add(comboBoxMaiorMenorIgualDataAbertura);
            panelFiltro.Controls.Add(labelNomeFantasia);
            panelFiltro.Controls.Add(comboBoxMaiorMenorIgualDataSituacaoCadastral);
            panelFiltro.Controls.Add(labelCnpj);
            panelFiltro.Controls.Add(comboBoxMaiorMenorIgualCapitalSocial);
            panelFiltro.Controls.Add(labelSituacaoCadastral);
            panelFiltro.Controls.Add(comboMaiorMenorIgualIdade);
            panelFiltro.Controls.Add(labelDataSituacaoCadastral);
            panelFiltro.Controls.Add(panel2);
            panelFiltro.Controls.Add(labelDataAbertura);
            panelFiltro.Controls.Add(panel1);
            panelFiltro.Controls.Add(labelCapitalSocial);
            panelFiltro.Controls.Add(panelBotaoFiltrar);
            panelFiltro.Controls.Add(labelPorte);
            panelFiltro.Controls.Add(labelNaturezaJuridica);
            panelFiltro.Controls.Add(labelMatrizFilial);
            panelFiltro.Controls.Add(dateTimePickerDataAbertura);
            panelFiltro.Controls.Add(textBoxRazaoSocial);
            panelFiltro.Controls.Add(dateTimePickerDataSituacaoCadastral);
            panelFiltro.Controls.Add(textBoxNomeFantasia);
            panelFiltro.Controls.Add(comboBoxMatrizFilial);
            panelFiltro.Controls.Add(textBoxCnpj);
            panelFiltro.Controls.Add(comboBoxPorte);
            panelFiltro.Controls.Add(textBoxCapitalSocial);
            panelFiltro.Controls.Add(comboBoxNaturezaJuridica);
            panelFiltro.Controls.Add(labelIdade);
            panelFiltro.Controls.Add(textBoxIdade);
            panelFiltro.Location = new Point(0, 0);
            panelFiltro.Name = "panelFiltro";
            panelFiltro.Size = new Size(516, 307);
            panelFiltro.TabIndex = 65;
            panelFiltro.Paint += AoPintarControladorBordas;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.BackColor = Color.Black;
            comboBoxEstado.FlatStyle = FlatStyle.Flat;
            comboBoxEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstado.ForeColor = Color.White;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(217, 201);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(149, 23);
            comboBoxEstado.TabIndex = 74;
            comboBoxEstado.Format += AoFormatarComboBoxEstado;
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labelEstado.ForeColor = Color.White;
            labelEstado.Location = new Point(12, 205);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(197, 19);
            labelEstado.TabIndex = 73;
            labelEstado.Text = "Estado . . . . . . . . . . . . . . . . . :";
            // 
            // comboBoxHabilitadoSituacaoCadastral
            // 
            comboBoxHabilitadoSituacaoCadastral.BackColor = Color.Black;
            comboBoxHabilitadoSituacaoCadastral.FlatStyle = FlatStyle.Flat;
            comboBoxHabilitadoSituacaoCadastral.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxHabilitadoSituacaoCadastral.ForeColor = Color.White;
            comboBoxHabilitadoSituacaoCadastral.FormattingEnabled = true;
            comboBoxHabilitadoSituacaoCadastral.Location = new Point(217, 182);
            comboBoxHabilitadoSituacaoCadastral.Name = "comboBoxHabilitadoSituacaoCadastral";
            comboBoxHabilitadoSituacaoCadastral.Size = new Size(149, 23);
            comboBoxHabilitadoSituacaoCadastral.TabIndex = 72;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(192, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(96, 19);
            labelTitulo.TabIndex = 71;
            labelTitulo.Text = "Filtro Empresa";
            // 
            // FiltroEmpresaUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panelFiltro);
            Name = "FiltroEmpresaUserControl";
            Size = new Size(526, 326);
            Load += AoCarregarControlador;
            Paint += AoPintarControladorSombra;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoFiltrar.ResumeLayout(false);
            panelFiltro.ResumeLayout(false);
            panelFiltro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label labelRazaoSocial;
        private Label labelNomeFantasia;
        private Label labelCnpj;
        private Label labelSituacaoCadastral;
        private Label labelDataSituacaoCadastral;
        private Label labelDataAbertura;
        private Label labelCapitalSocial;
        private Label labelPorte;
        private Label labelNaturezaJuridica;
        private Label labelMatrizFilial;
        private TextBox textBoxRazaoSocial;
        private TextBox textBoxNomeFantasia;
        private TextBox textBoxCnpj;
        private TextBox textBoxCapitalSocial;
        private Label labelIdade;
        private TextBox textBoxIdade;
        private ComboBox comboBoxNaturezaJuridica;
        private ComboBox comboBoxPorte;
        private ComboBox comboBoxMatrizFilial;
        private DateTimePicker dateTimePickerDataSituacaoCadastral;
        private DateTimePicker dateTimePickerDataAbertura;
        private Panel panel2;
        private Button botaoFechar;
        private Panel panel1;
        private Button botaoLimpar;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltrar;
        private ComboBox comboMaiorMenorIgualIdade;
        private ComboBox comboBoxMaiorMenorIgualCapitalSocial;
        private ComboBox comboBoxMaiorMenorIgualDataSituacaoCadastral;
        private ComboBox comboBoxMaiorMenorIgualDataAbertura;
        private Panel panelFiltro;
        private Label labelTitulo;
        private ComboBox comboBoxHabilitadoSituacaoCadastral;
        private ComboBox comboBoxEstado;
        private Label labelEstado;
    }
}
