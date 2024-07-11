namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaCriarEmpresaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelBotaoCancelar = new Panel();
            botaoCancelar = new Button();
            panelBotaoSalvar = new Panel();
            botaoSalvar = new Button();
            labelTitulo = new Label();
            textBoxRazaoSocial = new TextBox();
            textBoxCnpj = new TextBox();
            textBoxNomeFantasia = new TextBox();
            labelCnpj = new Label();
            labelCapitalSocial = new Label();
            textBoxCapitalSocial = new TextBox();
            panelCriacao = new Panel();
            labelPorte = new Label();
            comboBoxPorte = new ComboBox();
            labelMatrizFilial = new Label();
            comboBoxMatrizFilial = new ComboBox();
            textBoxNumero = new TextBox();
            labelCep = new Label();
            labelNumero = new Label();
            labelBairro = new Label();
            labelDataAbertura = new Label();
            label2 = new Label();
            labelRazaoSocial = new Label();
            labelMunicipio = new Label();
            labelNomeFantasia = new Label();
            labelRua = new Label();
            LabelEstado = new Label();
            labelNaturezaJuridica = new Label();
            labelSituacaoCadastral = new Label();
            dateTimePickerDataAbertura = new DateTimePicker();
            comboBoxSituacaoCadastral = new ComboBox();
            textBoxComplemento = new TextBox();
            textBoxRua = new TextBox();
            textBoxMunicipio = new TextBox();
            comboBoxEstado = new ComboBox();
            textBoxBairro = new TextBox();
            textBoxCep = new TextBox();
            comboBoxNaturezaJuridica = new ComboBox();
            panelBotaoCancelar.SuspendLayout();
            panelBotaoSalvar.SuspendLayout();
            panelCriacao.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotaoCancelar
            // 
            panelBotaoCancelar.BackColor = Color.Transparent;
            panelBotaoCancelar.Controls.Add(botaoCancelar);
            panelBotaoCancelar.Location = new Point(446, 262);
            panelBotaoCancelar.Name = "panelBotaoCancelar";
            panelBotaoCancelar.Size = new Size(106, 40);
            panelBotaoCancelar.TabIndex = 61;
            panelBotaoCancelar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoCancelar
            // 
            botaoCancelar.BackColor = Color.Orange;
            botaoCancelar.FlatAppearance.BorderSize = 0;
            botaoCancelar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoCancelar.FlatAppearance.MouseOverBackColor = Color.Cyan;
            botaoCancelar.FlatStyle = FlatStyle.Flat;
            botaoCancelar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoCancelar.ForeColor = Color.Black;
            botaoCancelar.Location = new Point(3, 3);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(85, 27);
            botaoCancelar.TabIndex = 22;
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.UseVisualStyleBackColor = false;
            botaoCancelar.Click += AoCLicar_botaoCancelar;
            // 
            // panelBotaoSalvar
            // 
            panelBotaoSalvar.BackColor = Color.Transparent;
            panelBotaoSalvar.Controls.Add(botaoSalvar);
            panelBotaoSalvar.Location = new Point(558, 262);
            panelBotaoSalvar.Name = "panelBotaoSalvar";
            panelBotaoSalvar.Size = new Size(106, 40);
            panelBotaoSalvar.TabIndex = 60;
            panelBotaoSalvar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoSalvar
            // 
            botaoSalvar.BackColor = Color.Orange;
            botaoSalvar.FlatAppearance.BorderSize = 0;
            botaoSalvar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoSalvar.FlatAppearance.MouseOverBackColor = Color.Cyan;
            botaoSalvar.FlatStyle = FlatStyle.Flat;
            botaoSalvar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoSalvar.ForeColor = Color.Black;
            botaoSalvar.Location = new Point(3, 3);
            botaoSalvar.Name = "botaoSalvar";
            botaoSalvar.Size = new Size(85, 27);
            botaoSalvar.TabIndex = 31;
            botaoSalvar.Text = "Salvar";
            botaoSalvar.UseVisualStyleBackColor = false;
            botaoSalvar.Click += AoClicar_botaoSalvar;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(276, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(110, 19);
            labelTitulo.TabIndex = 74;
            labelTitulo.Text = "Criação Empresa";
            // 
            // textBoxRazaoSocial
            // 
            textBoxRazaoSocial.BackColor = Color.Cyan;
            textBoxRazaoSocial.BorderStyle = BorderStyle.None;
            textBoxRazaoSocial.ForeColor = Color.Black;
            textBoxRazaoSocial.Location = new Point(241, 34);
            textBoxRazaoSocial.Name = "textBoxRazaoSocial";
            textBoxRazaoSocial.Size = new Size(149, 16);
            textBoxRazaoSocial.TabIndex = 73;
            // 
            // textBoxCnpj
            // 
            textBoxCnpj.BackColor = Color.Cyan;
            textBoxCnpj.BorderStyle = BorderStyle.None;
            textBoxCnpj.ForeColor = Color.Black;
            textBoxCnpj.Location = new Point(241, 78);
            textBoxCnpj.Name = "textBoxCnpj";
            textBoxCnpj.ShortcutsEnabled = false;
            textBoxCnpj.Size = new Size(149, 16);
            textBoxCnpj.TabIndex = 72;
            textBoxCnpj.KeyPress += AoPressionarTecla_textBoxCnpj;
            // 
            // textBoxNomeFantasia
            // 
            textBoxNomeFantasia.BackColor = Color.Cyan;
            textBoxNomeFantasia.BorderStyle = BorderStyle.None;
            textBoxNomeFantasia.ForeColor = Color.Black;
            textBoxNomeFantasia.Location = new Point(241, 56);
            textBoxNomeFantasia.Name = "textBoxNomeFantasia";
            textBoxNomeFantasia.Size = new Size(149, 16);
            textBoxNomeFantasia.TabIndex = 71;
            // 
            // labelCnpj
            // 
            labelCnpj.AutoSize = true;
            labelCnpj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCnpj.ForeColor = Color.White;
            labelCnpj.Location = new Point(13, 78);
            labelCnpj.Name = "labelCnpj";
            labelCnpj.Size = new Size(199, 21);
            labelCnpj.TabIndex = 68;
            labelCnpj.Text = "Cnpj . . . . . . . . . . . . . . . . . . . . . .:";
            // 
            // labelCapitalSocial
            // 
            labelCapitalSocial.AutoSize = true;
            labelCapitalSocial.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCapitalSocial.ForeColor = Color.White;
            labelCapitalSocial.Location = new Point(13, 99);
            labelCapitalSocial.Name = "labelCapitalSocial";
            labelCapitalSocial.Size = new Size(183, 21);
            labelCapitalSocial.TabIndex = 69;
            labelCapitalSocial.Text = "Capital Social . . . . . . . . . . .:";
            // 
            // textBoxCapitalSocial
            // 
            textBoxCapitalSocial.BackColor = Color.Cyan;
            textBoxCapitalSocial.BorderStyle = BorderStyle.None;
            textBoxCapitalSocial.ForeColor = Color.Black;
            textBoxCapitalSocial.Location = new Point(241, 100);
            textBoxCapitalSocial.Name = "textBoxCapitalSocial";
            textBoxCapitalSocial.ShortcutsEnabled = false;
            textBoxCapitalSocial.Size = new Size(149, 16);
            textBoxCapitalSocial.TabIndex = 76;
            textBoxCapitalSocial.KeyPress += AoPressionarTecla_textBoxCapitalSocial;
            // 
            // panelCriacao
            // 
            panelCriacao.BackColor = Color.BlueViolet;
            panelCriacao.Controls.Add(labelPorte);
            panelCriacao.Controls.Add(comboBoxPorte);
            panelCriacao.Controls.Add(labelMatrizFilial);
            panelCriacao.Controls.Add(comboBoxMatrizFilial);
            panelCriacao.Controls.Add(textBoxNumero);
            panelCriacao.Controls.Add(labelCep);
            panelCriacao.Controls.Add(labelNumero);
            panelCriacao.Controls.Add(labelBairro);
            panelCriacao.Controls.Add(labelDataAbertura);
            panelCriacao.Controls.Add(label2);
            panelCriacao.Controls.Add(labelRazaoSocial);
            panelCriacao.Controls.Add(labelMunicipio);
            panelCriacao.Controls.Add(labelNomeFantasia);
            panelCriacao.Controls.Add(labelRua);
            panelCriacao.Controls.Add(LabelEstado);
            panelCriacao.Controls.Add(labelNaturezaJuridica);
            panelCriacao.Controls.Add(labelSituacaoCadastral);
            panelCriacao.Controls.Add(dateTimePickerDataAbertura);
            panelCriacao.Controls.Add(comboBoxSituacaoCadastral);
            panelCriacao.Controls.Add(textBoxComplemento);
            panelCriacao.Controls.Add(textBoxRua);
            panelCriacao.Controls.Add(textBoxMunicipio);
            panelCriacao.Controls.Add(comboBoxEstado);
            panelCriacao.Controls.Add(textBoxBairro);
            panelCriacao.Controls.Add(textBoxCep);
            panelCriacao.Controls.Add(comboBoxNaturezaJuridica);
            panelCriacao.Controls.Add(panelBotaoCancelar);
            panelCriacao.Controls.Add(panelBotaoSalvar);
            panelCriacao.Controls.Add(labelCapitalSocial);
            panelCriacao.Controls.Add(labelCnpj);
            panelCriacao.Controls.Add(textBoxCapitalSocial);
            panelCriacao.Controls.Add(textBoxNomeFantasia);
            panelCriacao.Controls.Add(labelTitulo);
            panelCriacao.Controls.Add(textBoxCnpj);
            panelCriacao.Controls.Add(textBoxRazaoSocial);
            panelCriacao.Location = new Point(-1, 1);
            panelCriacao.Name = "panelCriacao";
            panelCriacao.Size = new Size(682, 303);
            panelCriacao.TabIndex = 79;
            panelCriacao.Paint += AoRequererPintura_PanelCriacao;
            // 
            // labelPorte
            // 
            labelPorte.AutoSize = true;
            labelPorte.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPorte.ForeColor = Color.White;
            labelPorte.Location = new Point(13, 150);
            labelPorte.Name = "labelPorte";
            labelPorte.Size = new Size(147, 20);
            labelPorte.TabIndex = 108;
            labelPorte.Text = "Porte . . . . . . . . . . . .:";
            // 
            // comboBoxPorte
            // 
            comboBoxPorte.BackColor = Color.Cyan;
            comboBoxPorte.FlatStyle = FlatStyle.Flat;
            comboBoxPorte.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxPorte.ForeColor = Color.Black;
            comboBoxPorte.FormattingEnabled = true;
            comboBoxPorte.Location = new Point(241, 150);
            comboBoxPorte.Name = "comboBoxPorte";
            comboBoxPorte.Size = new Size(149, 23);
            comboBoxPorte.TabIndex = 107;
            comboBoxPorte.Format += AoFormatar_comboBoxPorte;
            // 
            // labelMatrizFilial
            // 
            labelMatrizFilial.AutoSize = true;
            labelMatrizFilial.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMatrizFilial.ForeColor = Color.White;
            labelMatrizFilial.Location = new Point(13, 179);
            labelMatrizFilial.Name = "labelMatrizFilial";
            labelMatrizFilial.Size = new Size(187, 20);
            labelMatrizFilial.TabIndex = 106;
            labelMatrizFilial.Text = "Matriz Filial . . . . . . . . . . . .:";
            // 
            // comboBoxMatrizFilial
            // 
            comboBoxMatrizFilial.BackColor = Color.Cyan;
            comboBoxMatrizFilial.FlatStyle = FlatStyle.Flat;
            comboBoxMatrizFilial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMatrizFilial.ForeColor = Color.Black;
            comboBoxMatrizFilial.FormattingEnabled = true;
            comboBoxMatrizFilial.Location = new Point(241, 179);
            comboBoxMatrizFilial.Name = "comboBoxMatrizFilial";
            comboBoxMatrizFilial.Size = new Size(149, 23);
            comboBoxMatrizFilial.TabIndex = 105;
            comboBoxMatrizFilial.Format += AoFormatar_comboBoxMatrizFilial;
            comboBoxMatrizFilial.KeyPress += AoPressionarTecla_comboBox;
            // 
            // textBoxNumero
            // 
            textBoxNumero.BackColor = Color.Cyan;
            textBoxNumero.BorderStyle = BorderStyle.None;
            textBoxNumero.ForeColor = Color.Black;
            textBoxNumero.Location = new Point(515, 151);
            textBoxNumero.Name = "textBoxNumero";
            textBoxNumero.ShortcutsEnabled = false;
            textBoxNumero.Size = new Size(149, 16);
            textBoxNumero.TabIndex = 82;
            textBoxNumero.KeyPress += AoPressionarTecla_textBoxNumero;
            // 
            // labelCep
            // 
            labelCep.AutoSize = true;
            labelCep.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCep.ForeColor = Color.White;
            labelCep.Location = new Point(396, 34);
            labelCep.Name = "labelCep";
            labelCep.Size = new Size(103, 21);
            labelCep.TabIndex = 83;
            labelCep.Text = "CEP. . . . . . . . . :";
            // 
            // labelNumero
            // 
            labelNumero.AutoSize = true;
            labelNumero.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNumero.ForeColor = Color.White;
            labelNumero.Location = new Point(396, 152);
            labelNumero.Name = "labelNumero";
            labelNumero.Size = new Size(110, 21);
            labelNumero.TabIndex = 81;
            labelNumero.Text = "Numero . . . . . :";
            // 
            // labelBairro
            // 
            labelBairro.AutoSize = true;
            labelBairro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelBairro.ForeColor = Color.White;
            labelBairro.Location = new Point(396, 108);
            labelBairro.Name = "labelBairro";
            labelBairro.Size = new Size(90, 21);
            labelBairro.TabIndex = 82;
            labelBairro.Text = "Bairro. . . . . :";
            // 
            // labelDataAbertura
            // 
            labelDataAbertura.AutoSize = true;
            labelDataAbertura.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataAbertura.ForeColor = Color.White;
            labelDataAbertura.Location = new Point(13, 248);
            labelDataAbertura.Name = "labelDataAbertura";
            labelDataAbertura.Size = new Size(206, 20);
            labelDataAbertura.TabIndex = 104;
            labelDataAbertura.Text = "Data Abertura . . . . . . . . . . . :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(396, 174);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 85;
            label2.Text = "Complemento:";
            // 
            // labelRazaoSocial
            // 
            labelRazaoSocial.AutoSize = true;
            labelRazaoSocial.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRazaoSocial.ForeColor = Color.White;
            labelRazaoSocial.Location = new Point(13, 34);
            labelRazaoSocial.Name = "labelRazaoSocial";
            labelRazaoSocial.Size = new Size(215, 20);
            labelRazaoSocial.TabIndex = 99;
            labelRazaoSocial.Text = "Razão Social . . . . . . . . . . . . . :";
            // 
            // labelMunicipio
            // 
            labelMunicipio.AutoSize = true;
            labelMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMunicipio.ForeColor = Color.White;
            labelMunicipio.Location = new Point(396, 87);
            labelMunicipio.Name = "labelMunicipio";
            labelMunicipio.Size = new Size(103, 21);
            labelMunicipio.TabIndex = 81;
            labelMunicipio.Text = "Município . . .:";
            // 
            // labelNomeFantasia
            // 
            labelNomeFantasia.AutoSize = true;
            labelNomeFantasia.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNomeFantasia.ForeColor = Color.White;
            labelNomeFantasia.Location = new Point(13, 56);
            labelNomeFantasia.Name = "labelNomeFantasia";
            labelNomeFantasia.Size = new Size(221, 20);
            labelNomeFantasia.TabIndex = 100;
            labelNomeFantasia.Text = "Nome Fantasia . . . . . . . . . . . . :";
            // 
            // labelRua
            // 
            labelRua.AutoSize = true;
            labelRua.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRua.ForeColor = Color.White;
            labelRua.Location = new Point(396, 130);
            labelRua.Name = "labelRua";
            labelRua.Size = new Size(100, 21);
            labelRua.TabIndex = 84;
            labelRua.Text = "Rua . . . . . . . . :";
            // 
            // LabelEstado
            // 
            LabelEstado.AutoSize = true;
            LabelEstado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelEstado.ForeColor = Color.White;
            LabelEstado.Location = new Point(396, 64);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(97, 21);
            LabelEstado.TabIndex = 80;
            LabelEstado.Text = "Estado. . . . . .:";
            // 
            // labelNaturezaJuridica
            // 
            labelNaturezaJuridica.AutoSize = true;
            labelNaturezaJuridica.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNaturezaJuridica.ForeColor = Color.White;
            labelNaturezaJuridica.Location = new Point(13, 123);
            labelNaturezaJuridica.Name = "labelNaturezaJuridica";
            labelNaturezaJuridica.Size = new Size(196, 20);
            labelNaturezaJuridica.TabIndex = 102;
            labelNaturezaJuridica.Text = "Natureza Juridica . . . . . . . :";
            // 
            // labelSituacaoCadastral
            // 
            labelSituacaoCadastral.AutoSize = true;
            labelSituacaoCadastral.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelSituacaoCadastral.ForeColor = Color.White;
            labelSituacaoCadastral.Location = new Point(13, 208);
            labelSituacaoCadastral.Name = "labelSituacaoCadastral";
            labelSituacaoCadastral.Size = new Size(200, 20);
            labelSituacaoCadastral.TabIndex = 103;
            labelSituacaoCadastral.Text = "Situação Cadastral. . . . . . .:";
            // 
            // dateTimePickerDataAbertura
            // 
            dateTimePickerDataAbertura.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataAbertura.CalendarForeColor = Color.Cyan;
            dateTimePickerDataAbertura.CalendarMonthBackground = Color.Cyan;
            dateTimePickerDataAbertura.CalendarTitleBackColor = Color.Cyan;
            dateTimePickerDataAbertura.CalendarTitleForeColor = Color.Cyan;
            dateTimePickerDataAbertura.CalendarTrailingForeColor = Color.Cyan;
            dateTimePickerDataAbertura.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataAbertura.Format = DateTimePickerFormat.Short;
            dateTimePickerDataAbertura.Location = new Point(241, 237);
            dateTimePickerDataAbertura.Name = "dateTimePickerDataAbertura";
            dateTimePickerDataAbertura.Size = new Size(149, 22);
            dateTimePickerDataAbertura.TabIndex = 98;
            dateTimePickerDataAbertura.ValueChanged += AoAlterarValor_dateTimePickerDataInicioAtividade;
            // 
            // comboBoxSituacaoCadastral
            // 
            comboBoxSituacaoCadastral.BackColor = Color.Cyan;
            comboBoxSituacaoCadastral.FlatStyle = FlatStyle.Flat;
            comboBoxSituacaoCadastral.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxSituacaoCadastral.ForeColor = Color.Black;
            comboBoxSituacaoCadastral.FormattingEnabled = true;
            comboBoxSituacaoCadastral.Location = new Point(241, 208);
            comboBoxSituacaoCadastral.Name = "comboBoxSituacaoCadastral";
            comboBoxSituacaoCadastral.Size = new Size(149, 23);
            comboBoxSituacaoCadastral.TabIndex = 97;
            comboBoxSituacaoCadastral.KeyPress += AoPressionarTecla_comboBox;
            // 
            // textBoxComplemento
            // 
            textBoxComplemento.BackColor = Color.Cyan;
            textBoxComplemento.BorderStyle = BorderStyle.None;
            textBoxComplemento.ForeColor = Color.Black;
            textBoxComplemento.Location = new Point(515, 173);
            textBoxComplemento.Name = "textBoxComplemento";
            textBoxComplemento.Size = new Size(149, 16);
            textBoxComplemento.TabIndex = 95;
            // 
            // textBoxRua
            // 
            textBoxRua.BackColor = Color.Cyan;
            textBoxRua.BorderStyle = BorderStyle.None;
            textBoxRua.ForeColor = Color.Black;
            textBoxRua.Location = new Point(515, 129);
            textBoxRua.Name = "textBoxRua";
            textBoxRua.Size = new Size(149, 16);
            textBoxRua.TabIndex = 93;
            // 
            // textBoxMunicipio
            // 
            textBoxMunicipio.BackColor = Color.Cyan;
            textBoxMunicipio.BorderStyle = BorderStyle.None;
            textBoxMunicipio.ForeColor = Color.Black;
            textBoxMunicipio.Location = new Point(515, 85);
            textBoxMunicipio.Name = "textBoxMunicipio";
            textBoxMunicipio.Size = new Size(149, 16);
            textBoxMunicipio.TabIndex = 89;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.BackColor = Color.Cyan;
            comboBoxEstado.FlatStyle = FlatStyle.Flat;
            comboBoxEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstado.ForeColor = Color.Black;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(515, 56);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(149, 23);
            comboBoxEstado.TabIndex = 85;
            comboBoxEstado.Format += AoFormatar_comboBoxEstado;
            comboBoxEstado.KeyPress += AoPressionarTecla_comboBox;
            // 
            // textBoxBairro
            // 
            textBoxBairro.BackColor = Color.Cyan;
            textBoxBairro.BorderStyle = BorderStyle.None;
            textBoxBairro.ForeColor = Color.Black;
            textBoxBairro.Location = new Point(515, 107);
            textBoxBairro.Name = "textBoxBairro";
            textBoxBairro.Size = new Size(149, 16);
            textBoxBairro.TabIndex = 90;
            // 
            // textBoxCep
            // 
            textBoxCep.BackColor = Color.Cyan;
            textBoxCep.BorderStyle = BorderStyle.None;
            textBoxCep.ForeColor = Color.Black;
            textBoxCep.Location = new Point(515, 34);
            textBoxCep.Name = "textBoxCep";
            textBoxCep.ShortcutsEnabled = false;
            textBoxCep.Size = new Size(149, 16);
            textBoxCep.TabIndex = 91;
            textBoxCep.KeyPress += AoPressionarTecla_textBoxCep;
            // 
            // comboBoxNaturezaJuridica
            // 
            comboBoxNaturezaJuridica.BackColor = Color.Cyan;
            comboBoxNaturezaJuridica.FlatStyle = FlatStyle.Flat;
            comboBoxNaturezaJuridica.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxNaturezaJuridica.ForeColor = Color.Black;
            comboBoxNaturezaJuridica.FormattingEnabled = true;
            comboBoxNaturezaJuridica.Location = new Point(241, 122);
            comboBoxNaturezaJuridica.Name = "comboBoxNaturezaJuridica";
            comboBoxNaturezaJuridica.Size = new Size(149, 23);
            comboBoxNaturezaJuridica.TabIndex = 83;
            comboBoxNaturezaJuridica.Format += AoFormatar_comboBoxNaturezaJuridica;
            comboBoxNaturezaJuridica.KeyPress += AoPressionarTecla_comboBox;
            // 
            // TelaCriarEmpresaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(692, 322);
            Controls.Add(panelCriacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCriarEmpresaForm";
            Text = "TelaCriarEnderecoForm";
            Load += AoCarregar_TelaCriarEnderecoForm;
            panelBotaoCancelar.ResumeLayout(false);
            panelBotaoSalvar.ResumeLayout(false);
            panelCriacao.ResumeLayout(false);
            panelCriacao.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBotaoCancelar;
        private Button botaoCancelar;
        private Panel panelBotaoSalvar;
        private Button botaoSalvar;
        private Label labelTitulo;
        private TextBox textBoxRazaoSocial;
        private TextBox textBoxCnpj;
        private TextBox textBoxNomeFantasia;
        private Label labelCnpj;
        private Label labelCapitalSocial;
        private TextBox textBoxCapitalSocial;
        private Panel panelCriacao;
        private ComboBox comboBoxNaturezaJuridica;
        private ComboBox comboBoxSituacaoCadastral;
        private Label labelCep;
        private TextBox textBoxComplemento;
        private Label labelBairro;
        private Label labelComplemento;
        private Label labelMunicipio;
        private TextBox textBoxRua;
        private TextBox textBoxMunicipio;
        private Label labelRua;
        private ComboBox comboBoxEstado;
        private TextBox textBoxBairro;
        private Label LabelEstado;
        private TextBox textBoxCep;
        private DateTimePicker dateTimePickerDataAbertura;
        private Label labelRazaoSocial;
        private Label labelNomeFantasia;
        private Label labelNaturezaJuridica;
        private Label labelSituacaoCadastral;
        private Label labelDataAbertura;
        private Label label2;
        private TextBox textBoxNumero;
        private Label labelNumero;
        private Label labelMatrizFilial;
        private ComboBox comboBoxMatrizFilial;
        private Label labelPorte;
        private ComboBox comboBoxPorte;
    }
}