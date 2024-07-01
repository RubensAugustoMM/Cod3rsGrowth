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
            botaoFechar = new Button();
            botaoFiltrar = new Button();
            botaoLimpar = new Button();
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
            labelMenor = new Label();
            labelMaior = new Label();
            checkBoxMenorDataSituacaoCadastral = new CheckBox();
            checkBoxMaiorDataSituacaoCadastral = new CheckBox();
            checkBoxMenorCapitalSocial = new CheckBox();
            checkBoxMaiorCapitalSocial = new CheckBox();
            checkBoxMenorIdade = new CheckBox();
            checkBoxMaiorIdade = new CheckBox();
            checkBoxMenorDataAbertura = new CheckBox();
            checkBoxMaiorDataAbertura = new CheckBox();
            checkBoxSituacaoCadastral = new CheckBox();
            checkBoxHabilitadoSituacaoCadastral = new CheckBox();
            checkBoxHabilitadoDataAbertura = new CheckBox();
            checkBoxHabilitadoDataSituacaoCadastral = new CheckBox();
            checkBoxHabilitadoMatrizFilial = new CheckBox();
            checkBoxHabilitadoPorte = new CheckBox();
            checkBoxHabilitadoNaturezaJuridica = new CheckBox();
            SuspendLayout();
            // 
            // botaoFechar
            // 
            botaoFechar.BackColor = Color.Green;
            botaoFechar.FlatAppearance.BorderSize = 0;
            botaoFechar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFechar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFechar.FlatStyle = FlatStyle.Flat;
            botaoFechar.ForeColor = Color.White;
            botaoFechar.Location = new Point(326, 304);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new Size(67, 40);
            botaoFechar.TabIndex = 14;
            botaoFechar.Text = "Fechar";
            botaoFechar.UseVisualStyleBackColor = false;
            botaoFechar.Click += botaoFechar_Click;
            // 
            // botaoFiltrar
            // 
            botaoFiltrar.BackColor = Color.Green;
            botaoFiltrar.FlatAppearance.BorderSize = 0;
            botaoFiltrar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFiltrar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFiltrar.FlatStyle = FlatStyle.Flat;
            botaoFiltrar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            botaoFiltrar.ForeColor = Color.White;
            botaoFiltrar.Location = new Point(471, 304);
            botaoFiltrar.Name = "botaoFiltrar";
            botaoFiltrar.Size = new Size(67, 40);
            botaoFiltrar.TabIndex = 15;
            botaoFiltrar.Text = "Filtrar";
            botaoFiltrar.UseVisualStyleBackColor = false;
            botaoFiltrar.Click += botaoFiltrar_Click;
            // 
            // botaoLimpar
            // 
            botaoLimpar.BackColor = Color.ForestGreen;
            botaoLimpar.FlatAppearance.BorderSize = 0;
            botaoLimpar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoLimpar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoLimpar.FlatStyle = FlatStyle.Flat;
            botaoLimpar.ForeColor = Color.White;
            botaoLimpar.Location = new Point(399, 304);
            botaoLimpar.Name = "botaoLimpar";
            botaoLimpar.Size = new Size(67, 40);
            botaoLimpar.TabIndex = 22;
            botaoLimpar.Text = "Limpar";
            botaoLimpar.UseVisualStyleBackColor = false;
            botaoLimpar.Click += botaoLimpar_Click;
            // 
            // labelRazaoSocial
            // 
            labelRazaoSocial.AutoSize = true;
            labelRazaoSocial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRazaoSocial.ForeColor = Color.Black;
            labelRazaoSocial.Location = new Point(37, 25);
            labelRazaoSocial.Name = "labelRazaoSocial";
            labelRazaoSocial.Size = new Size(181, 21);
            labelRazaoSocial.TabIndex = 23;
            labelRazaoSocial.Text = "Razao Social . . . . . . . . . . .: ";
            // 
            // labelNomeFantasia
            // 
            labelNomeFantasia.AutoSize = true;
            labelNomeFantasia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNomeFantasia.ForeColor = Color.Black;
            labelNomeFantasia.Location = new Point(37, 46);
            labelNomeFantasia.Name = "labelNomeFantasia";
            labelNomeFantasia.Size = new Size(190, 21);
            labelNomeFantasia.TabIndex = 24;
            labelNomeFantasia.Text = "Nome Fantasia . . . . . . . . . . :";
            // 
            // labelCnpj
            // 
            labelCnpj.AutoSize = true;
            labelCnpj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCnpj.ForeColor = Color.Black;
            labelCnpj.Location = new Point(37, 67);
            labelCnpj.Name = "labelCnpj";
            labelCnpj.Size = new Size(186, 21);
            labelCnpj.TabIndex = 25;
            labelCnpj.Text = "CNPJ . . . . . . . . . . . . . . . . . . . :";
            // 
            // labelSituacaoCadastral
            // 
            labelSituacaoCadastral.AutoSize = true;
            labelSituacaoCadastral.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelSituacaoCadastral.ForeColor = Color.Black;
            labelSituacaoCadastral.Location = new Point(37, 195);
            labelSituacaoCadastral.Name = "labelSituacaoCadastral";
            labelSituacaoCadastral.Size = new Size(176, 21);
            labelSituacaoCadastral.TabIndex = 26;
            labelSituacaoCadastral.Text = "Situação Cadastral . . . . .:";
            // 
            // labelDataSituacaoCadastral
            // 
            labelDataSituacaoCadastral.AutoSize = true;
            labelDataSituacaoCadastral.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataSituacaoCadastral.ForeColor = Color.Black;
            labelDataSituacaoCadastral.Location = new Point(37, 231);
            labelDataSituacaoCadastral.Name = "labelDataSituacaoCadastral";
            labelDataSituacaoCadastral.Size = new Size(177, 21);
            labelDataSituacaoCadastral.TabIndex = 27;
            labelDataSituacaoCadastral.Text = "Data Situação Cadastral:";
            // 
            // labelDataAbertura
            // 
            labelDataAbertura.AutoSize = true;
            labelDataAbertura.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataAbertura.ForeColor = Color.Black;
            labelDataAbertura.Location = new Point(37, 252);
            labelDataAbertura.Name = "labelDataAbertura";
            labelDataAbertura.Size = new Size(184, 21);
            labelDataAbertura.TabIndex = 28;
            labelDataAbertura.Text = "Data Abertura . . . . . . . . . . :";
            // 
            // labelCapitalSocial
            // 
            labelCapitalSocial.AutoSize = true;
            labelCapitalSocial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCapitalSocial.ForeColor = Color.Black;
            labelCapitalSocial.Location = new Point(37, 109);
            labelCapitalSocial.Name = "labelCapitalSocial";
            labelCapitalSocial.Size = new Size(164, 21);
            labelCapitalSocial.TabIndex = 29;
            labelCapitalSocial.Text = "Capital social . . . . . . . . :";
            // 
            // labelPorte
            // 
            labelPorte.AutoSize = true;
            labelPorte.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPorte.ForeColor = Color.Black;
            labelPorte.Location = new Point(37, 151);
            labelPorte.Name = "labelPorte";
            labelPorte.Size = new Size(179, 21);
            labelPorte.TabIndex = 30;
            labelPorte.Text = "Porte . . . . . . . . . . . . . . . . . . :";
            // 
            // labelNaturezaJuridica
            // 
            labelNaturezaJuridica.AutoSize = true;
            labelNaturezaJuridica.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNaturezaJuridica.ForeColor = Color.Black;
            labelNaturezaJuridica.Location = new Point(37, 130);
            labelNaturezaJuridica.Name = "labelNaturezaJuridica";
            labelNaturezaJuridica.Size = new Size(172, 21);
            labelNaturezaJuridica.TabIndex = 31;
            labelNaturezaJuridica.Text = "Natureza Juridica . . . . . :";
            // 
            // labelMatrizFilial
            // 
            labelMatrizFilial.AutoSize = true;
            labelMatrizFilial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMatrizFilial.ForeColor = Color.Black;
            labelMatrizFilial.Location = new Point(37, 172);
            labelMatrizFilial.Name = "labelMatrizFilial";
            labelMatrizFilial.Size = new Size(168, 21);
            labelMatrizFilial.TabIndex = 32;
            labelMatrizFilial.Text = "Matriz ou Filial . . . . . . . :";
            // 
            // textBoxRazaoSocial
            // 
            textBoxRazaoSocial.BackColor = Color.Black;
            textBoxRazaoSocial.BorderStyle = BorderStyle.None;
            textBoxRazaoSocial.ForeColor = Color.Yellow;
            textBoxRazaoSocial.Location = new Point(204, 30);
            textBoxRazaoSocial.Name = "textBoxRazaoSocial";
            textBoxRazaoSocial.Size = new Size(149, 16);
            textBoxRazaoSocial.TabIndex = 33;
            // 
            // textBoxNomeFantasia
            // 
            textBoxNomeFantasia.BackColor = Color.Black;
            textBoxNomeFantasia.BorderStyle = BorderStyle.None;
            textBoxNomeFantasia.ForeColor = Color.Yellow;
            textBoxNomeFantasia.Location = new Point(204, 51);
            textBoxNomeFantasia.Name = "textBoxNomeFantasia";
            textBoxNomeFantasia.Size = new Size(149, 16);
            textBoxNomeFantasia.TabIndex = 34;
            // 
            // textBoxCnpj
            // 
            textBoxCnpj.BackColor = Color.Black;
            textBoxCnpj.BorderStyle = BorderStyle.None;
            textBoxCnpj.ForeColor = Color.Yellow;
            textBoxCnpj.Location = new Point(204, 73);
            textBoxCnpj.Name = "textBoxCnpj";
            textBoxCnpj.Size = new Size(149, 16);
            textBoxCnpj.TabIndex = 35;
            // 
            // textBoxCapitalSocial
            // 
            textBoxCapitalSocial.BackColor = Color.Black;
            textBoxCapitalSocial.BorderStyle = BorderStyle.None;
            textBoxCapitalSocial.ForeColor = Color.Yellow;
            textBoxCapitalSocial.Location = new Point(204, 115);
            textBoxCapitalSocial.Name = "textBoxCapitalSocial";
            textBoxCapitalSocial.Size = new Size(149, 16);
            textBoxCapitalSocial.TabIndex = 37;
            textBoxCapitalSocial.KeyPress += somenteValoresReais_KeyPress;
            // 
            // labelIdade
            // 
            labelIdade.AutoSize = true;
            labelIdade.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIdade.ForeColor = Color.Black;
            labelIdade.Location = new Point(35, 88);
            labelIdade.Name = "labelIdade";
            labelIdade.Size = new Size(181, 21);
            labelIdade.TabIndex = 38;
            labelIdade.Text = "Idade . . . . . . . . . . . . . . . . . . :\r\n";
            // 
            // textBoxIdade
            // 
            textBoxIdade.BackColor = Color.Black;
            textBoxIdade.BorderStyle = BorderStyle.None;
            textBoxIdade.ForeColor = Color.Yellow;
            textBoxIdade.Location = new Point(204, 95);
            textBoxIdade.Name = "textBoxIdade";
            textBoxIdade.Size = new Size(149, 16);
            textBoxIdade.TabIndex = 39;
            textBoxIdade.KeyPress += somenteValoresNaturais_KeyPress;
            // 
            // comboBoxNaturezaJuridica
            // 
            comboBoxNaturezaJuridica.BackColor = Color.Yellow;
            comboBoxNaturezaJuridica.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxNaturezaJuridica.FormattingEnabled = true;
            comboBoxNaturezaJuridica.Location = new Point(204, 133);
            comboBoxNaturezaJuridica.Name = "comboBoxNaturezaJuridica";
            comboBoxNaturezaJuridica.Size = new Size(149, 23);
            comboBoxNaturezaJuridica.TabIndex = 40;
            // 
            // comboBoxPorte
            // 
            comboBoxPorte.BackColor = Color.Yellow;
            comboBoxPorte.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxPorte.FormattingEnabled = true;
            comboBoxPorte.Location = new Point(204, 152);
            comboBoxPorte.Name = "comboBoxPorte";
            comboBoxPorte.Size = new Size(149, 23);
            comboBoxPorte.TabIndex = 41;
            // 
            // comboBoxMatrizFilial
            // 
            comboBoxMatrizFilial.BackColor = Color.Yellow;
            comboBoxMatrizFilial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMatrizFilial.FormattingEnabled = true;
            comboBoxMatrizFilial.Location = new Point(204, 175);
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
            dateTimePickerDataSituacaoCadastral.Location = new Point(204, 230);
            dateTimePickerDataSituacaoCadastral.Name = "dateTimePickerDataSituacaoCadastral";
            dateTimePickerDataSituacaoCadastral.Size = new Size(149, 23);
            dateTimePickerDataSituacaoCadastral.TabIndex = 43;
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
            dateTimePickerDataAbertura.Location = new Point(204, 253);
            dateTimePickerDataAbertura.Name = "dateTimePickerDataAbertura";
            dateTimePickerDataAbertura.Size = new Size(149, 23);
            dateTimePickerDataAbertura.TabIndex = 44;
            // 
            // labelMenor
            // 
            labelMenor.AutoSize = true;
            labelMenor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMenor.ForeColor = Color.White;
            labelMenor.Location = new Point(407, 15);
            labelMenor.Name = "labelMenor";
            labelMenor.Size = new Size(56, 21);
            labelMenor.TabIndex = 53;
            labelMenor.Text = "Menor";
            // 
            // labelMaior
            // 
            labelMaior.AutoSize = true;
            labelMaior.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMaior.ForeColor = Color.White;
            labelMaior.Location = new Point(359, 15);
            labelMaior.Name = "labelMaior";
            labelMaior.Size = new Size(51, 21);
            labelMaior.TabIndex = 52;
            labelMaior.Text = "Maior";
            // 
            // checkBoxMenorDataSituacaoCadastral
            // 
            checkBoxMenorDataSituacaoCadastral.AutoSize = true;
            checkBoxMenorDataSituacaoCadastral.FlatAppearance.BorderSize = 0;
            checkBoxMenorDataSituacaoCadastral.ForeColor = Color.White;
            checkBoxMenorDataSituacaoCadastral.Location = new Point(419, 232);
            checkBoxMenorDataSituacaoCadastral.Name = "checkBoxMenorDataSituacaoCadastral";
            checkBoxMenorDataSituacaoCadastral.Size = new Size(15, 14);
            checkBoxMenorDataSituacaoCadastral.TabIndex = 51;
            checkBoxMenorDataSituacaoCadastral.UseVisualStyleBackColor = true;
            checkBoxMenorDataSituacaoCadastral.CheckedChanged += checkBoxMenorDataSituacaoCadastral_CheckedChanged;
            // 
            // checkBoxMaiorDataSituacaoCadastral
            // 
            checkBoxMaiorDataSituacaoCadastral.AutoSize = true;
            checkBoxMaiorDataSituacaoCadastral.FlatAppearance.BorderSize = 0;
            checkBoxMaiorDataSituacaoCadastral.ForeColor = Color.White;
            checkBoxMaiorDataSituacaoCadastral.Location = new Point(359, 232);
            checkBoxMaiorDataSituacaoCadastral.Name = "checkBoxMaiorDataSituacaoCadastral";
            checkBoxMaiorDataSituacaoCadastral.Size = new Size(15, 14);
            checkBoxMaiorDataSituacaoCadastral.TabIndex = 50;
            checkBoxMaiorDataSituacaoCadastral.UseVisualStyleBackColor = true;
            checkBoxMaiorDataSituacaoCadastral.CheckedChanged += checkBoxMaiorDataSituacaoCadastral_CheckedChanged;
            // 
            // checkBoxMenorCapitalSocial
            // 
            checkBoxMenorCapitalSocial.AutoSize = true;
            checkBoxMenorCapitalSocial.FlatAppearance.BorderSize = 0;
            checkBoxMenorCapitalSocial.ForeColor = Color.White;
            checkBoxMenorCapitalSocial.Location = new Point(419, 117);
            checkBoxMenorCapitalSocial.Name = "checkBoxMenorCapitalSocial";
            checkBoxMenorCapitalSocial.Size = new Size(15, 14);
            checkBoxMenorCapitalSocial.TabIndex = 49;
            checkBoxMenorCapitalSocial.UseVisualStyleBackColor = true;
            checkBoxMenorCapitalSocial.CheckedChanged += checkBoxMenorCapitalSocial_CheckedChanged;
            // 
            // checkBoxMaiorCapitalSocial
            // 
            checkBoxMaiorCapitalSocial.AutoSize = true;
            checkBoxMaiorCapitalSocial.FlatAppearance.BorderSize = 0;
            checkBoxMaiorCapitalSocial.ForeColor = Color.White;
            checkBoxMaiorCapitalSocial.Location = new Point(359, 117);
            checkBoxMaiorCapitalSocial.Name = "checkBoxMaiorCapitalSocial";
            checkBoxMaiorCapitalSocial.Size = new Size(15, 14);
            checkBoxMaiorCapitalSocial.TabIndex = 48;
            checkBoxMaiorCapitalSocial.UseVisualStyleBackColor = true;
            checkBoxMaiorCapitalSocial.CheckedChanged += checkBoxMaiorCapitalSocial_CheckedChanged;
            // 
            // checkBoxMenorIdade
            // 
            checkBoxMenorIdade.AutoSize = true;
            checkBoxMenorIdade.FlatAppearance.BorderSize = 0;
            checkBoxMenorIdade.ForeColor = SystemColors.Window;
            checkBoxMenorIdade.Location = new Point(419, 96);
            checkBoxMenorIdade.Name = "checkBoxMenorIdade";
            checkBoxMenorIdade.Size = new Size(15, 14);
            checkBoxMenorIdade.TabIndex = 47;
            checkBoxMenorIdade.UseVisualStyleBackColor = true;
            checkBoxMenorIdade.CheckedChanged += checkBoxMenorIdade_CheckedChanged;
            // 
            // checkBoxMaiorIdade
            // 
            checkBoxMaiorIdade.AutoSize = true;
            checkBoxMaiorIdade.FlatAppearance.BorderSize = 0;
            checkBoxMaiorIdade.ForeColor = Color.White;
            checkBoxMaiorIdade.Location = new Point(359, 96);
            checkBoxMaiorIdade.Name = "checkBoxMaiorIdade";
            checkBoxMaiorIdade.Size = new Size(15, 14);
            checkBoxMaiorIdade.TabIndex = 46;
            checkBoxMaiorIdade.UseVisualStyleBackColor = true;
            checkBoxMaiorIdade.CheckedChanged += checkBoxMaiorIdade_CheckedChanged;
            // 
            // checkBoxMenorDataAbertura
            // 
            checkBoxMenorDataAbertura.AutoSize = true;
            checkBoxMenorDataAbertura.FlatAppearance.BorderSize = 0;
            checkBoxMenorDataAbertura.ForeColor = Color.White;
            checkBoxMenorDataAbertura.Location = new Point(419, 259);
            checkBoxMenorDataAbertura.Name = "checkBoxMenorDataAbertura";
            checkBoxMenorDataAbertura.Size = new Size(15, 14);
            checkBoxMenorDataAbertura.TabIndex = 55;
            checkBoxMenorDataAbertura.UseVisualStyleBackColor = true;
            checkBoxMenorDataAbertura.CheckedChanged += checkBoxMenorDataAbertura_CheckedChanged;
            // 
            // checkBoxMaiorDataAbertura
            // 
            checkBoxMaiorDataAbertura.AutoSize = true;
            checkBoxMaiorDataAbertura.FlatAppearance.BorderSize = 0;
            checkBoxMaiorDataAbertura.ForeColor = Color.White;
            checkBoxMaiorDataAbertura.Location = new Point(359, 259);
            checkBoxMaiorDataAbertura.Name = "checkBoxMaiorDataAbertura";
            checkBoxMaiorDataAbertura.Size = new Size(15, 14);
            checkBoxMaiorDataAbertura.TabIndex = 54;
            checkBoxMaiorDataAbertura.UseVisualStyleBackColor = true;
            checkBoxMaiorDataAbertura.CheckedChanged += checkBoxMaiorDataAbertura_CheckedChanged;
            // 
            // checkBoxSituacaoCadastral
            // 
            checkBoxSituacaoCadastral.AutoSize = true;
            checkBoxSituacaoCadastral.FlatAppearance.BorderSize = 0;
            checkBoxSituacaoCadastral.ForeColor = Color.White;
            checkBoxSituacaoCadastral.Location = new Point(204, 204);
            checkBoxSituacaoCadastral.Name = "checkBoxSituacaoCadastral";
            checkBoxSituacaoCadastral.Size = new Size(15, 14);
            checkBoxSituacaoCadastral.TabIndex = 56;
            checkBoxSituacaoCadastral.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitadoSituacaoCadastral
            // 
            checkBoxHabilitadoSituacaoCadastral.AutoSize = true;
            checkBoxHabilitadoSituacaoCadastral.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoSituacaoCadastral.ForeColor = Color.White;
            checkBoxHabilitadoSituacaoCadastral.Location = new Point(225, 202);
            checkBoxHabilitadoSituacaoCadastral.Name = "checkBoxHabilitadoSituacaoCadastral";
            checkBoxHabilitadoSituacaoCadastral.Size = new Size(86, 19);
            checkBoxHabilitadoSituacaoCadastral.TabIndex = 57;
            checkBoxHabilitadoSituacaoCadastral.Text = "Habilitado?";
            checkBoxHabilitadoSituacaoCadastral.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitadoDataAbertura
            // 
            checkBoxHabilitadoDataAbertura.AutoSize = true;
            checkBoxHabilitadoDataAbertura.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoDataAbertura.ForeColor = Color.White;
            checkBoxHabilitadoDataAbertura.Location = new Point(16, 253);
            checkBoxHabilitadoDataAbertura.Name = "checkBoxHabilitadoDataAbertura";
            checkBoxHabilitadoDataAbertura.Size = new Size(15, 14);
            checkBoxHabilitadoDataAbertura.TabIndex = 59;
            checkBoxHabilitadoDataAbertura.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitadoDataSituacaoCadastral
            // 
            checkBoxHabilitadoDataSituacaoCadastral.AutoSize = true;
            checkBoxHabilitadoDataSituacaoCadastral.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoDataSituacaoCadastral.ForeColor = Color.White;
            checkBoxHabilitadoDataSituacaoCadastral.Location = new Point(16, 232);
            checkBoxHabilitadoDataSituacaoCadastral.Name = "checkBoxHabilitadoDataSituacaoCadastral";
            checkBoxHabilitadoDataSituacaoCadastral.Size = new Size(15, 14);
            checkBoxHabilitadoDataSituacaoCadastral.TabIndex = 58;
            checkBoxHabilitadoDataSituacaoCadastral.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitadoMatrizFilial
            // 
            checkBoxHabilitadoMatrizFilial.AutoSize = true;
            checkBoxHabilitadoMatrizFilial.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoMatrizFilial.ForeColor = Color.White;
            checkBoxHabilitadoMatrizFilial.Location = new Point(16, 172);
            checkBoxHabilitadoMatrizFilial.Name = "checkBoxHabilitadoMatrizFilial";
            checkBoxHabilitadoMatrizFilial.Size = new Size(15, 14);
            checkBoxHabilitadoMatrizFilial.TabIndex = 60;
            checkBoxHabilitadoMatrizFilial.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitadoPorte
            // 
            checkBoxHabilitadoPorte.AutoSize = true;
            checkBoxHabilitadoPorte.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoPorte.ForeColor = Color.White;
            checkBoxHabilitadoPorte.Location = new Point(16, 153);
            checkBoxHabilitadoPorte.Name = "checkBoxHabilitadoPorte";
            checkBoxHabilitadoPorte.Size = new Size(15, 14);
            checkBoxHabilitadoPorte.TabIndex = 61;
            checkBoxHabilitadoPorte.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitadoNaturezaJuridica
            // 
            checkBoxHabilitadoNaturezaJuridica.AutoSize = true;
            checkBoxHabilitadoNaturezaJuridica.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoNaturezaJuridica.ForeColor = Color.White;
            checkBoxHabilitadoNaturezaJuridica.Location = new Point(16, 133);
            checkBoxHabilitadoNaturezaJuridica.Name = "checkBoxHabilitadoNaturezaJuridica";
            checkBoxHabilitadoNaturezaJuridica.Size = new Size(15, 14);
            checkBoxHabilitadoNaturezaJuridica.TabIndex = 62;
            checkBoxHabilitadoNaturezaJuridica.UseVisualStyleBackColor = true;
            // 
            // FiltroEmpresaUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            Controls.Add(checkBoxHabilitadoNaturezaJuridica);
            Controls.Add(checkBoxHabilitadoPorte);
            Controls.Add(checkBoxHabilitadoMatrizFilial);
            Controls.Add(checkBoxHabilitadoDataAbertura);
            Controls.Add(checkBoxHabilitadoDataSituacaoCadastral);
            Controls.Add(checkBoxHabilitadoSituacaoCadastral);
            Controls.Add(checkBoxSituacaoCadastral);
            Controls.Add(checkBoxMenorDataAbertura);
            Controls.Add(checkBoxMaiorDataAbertura);
            Controls.Add(labelMenor);
            Controls.Add(labelMaior);
            Controls.Add(checkBoxMenorDataSituacaoCadastral);
            Controls.Add(checkBoxMaiorDataSituacaoCadastral);
            Controls.Add(checkBoxMenorCapitalSocial);
            Controls.Add(checkBoxMaiorCapitalSocial);
            Controls.Add(checkBoxMenorIdade);
            Controls.Add(checkBoxMaiorIdade);
            Controls.Add(dateTimePickerDataAbertura);
            Controls.Add(dateTimePickerDataSituacaoCadastral);
            Controls.Add(comboBoxMatrizFilial);
            Controls.Add(comboBoxPorte);
            Controls.Add(comboBoxNaturezaJuridica);
            Controls.Add(textBoxIdade);
            Controls.Add(labelIdade);
            Controls.Add(textBoxCapitalSocial);
            Controls.Add(textBoxCnpj);
            Controls.Add(textBoxNomeFantasia);
            Controls.Add(textBoxRazaoSocial);
            Controls.Add(labelMatrizFilial);
            Controls.Add(labelNaturezaJuridica);
            Controls.Add(labelPorte);
            Controls.Add(labelCapitalSocial);
            Controls.Add(labelDataAbertura);
            Controls.Add(labelDataSituacaoCadastral);
            Controls.Add(labelSituacaoCadastral);
            Controls.Add(labelCnpj);
            Controls.Add(labelNomeFantasia);
            Controls.Add(labelRazaoSocial);
            Controls.Add(botaoLimpar);
            Controls.Add(botaoFiltrar);
            Controls.Add(botaoFechar);
            Name = "FiltroEmpresaUserControl";
            Size = new Size(541, 347);
            Load += FiltroConvenioUserControl_Load;
            Paint += FiltroConvenioUserControl_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button botaoFechar;
        private Button botaoFiltrar;
        private Button botaoLimpar;
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
        private Label labelMenor;
        private Label labelMaior;
        private CheckBox checkBoxMenorDataSituacaoCadastral;
        private CheckBox checkBoxMaiorDataSituacaoCadastral;
        private CheckBox checkBoxMenorCapitalSocial;
        private CheckBox checkBoxMaiorCapitalSocial;
        private CheckBox checkBoxMenorIdade;
        private CheckBox checkBoxMaiorIdade;
        private CheckBox checkBoxMenorDataAbertura;
        private CheckBox checkBoxMaiorDataAbertura;
        private CheckBox checkBoxSituacaoCadastral;
        private CheckBox checkBoxHabilitadoSituacaoCadastral;
        private CheckBox checkBoxHabilitadoDataAbertura;
        private CheckBox checkBoxHabilitadoDataSituacaoCadastral;
        private CheckBox checkBoxHabilitadoMatrizFilial;
        private CheckBox checkBoxHabilitadoPorte;
        private CheckBox checkBoxHabilitadoNaturezaJuridica;
    }
}
