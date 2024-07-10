namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaCriarEscolaForm
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
            textBoxNome = new TextBox();
            textBoxTelefone = new TextBox();
            comboBoxCategoriaAdministrativa = new ComboBox();
            textBoxCodigoMec = new TextBox();
            labelTelefone = new Label();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            panelCriacao = new Panel();
            textBoxNumero = new TextBox();
            labelCep = new Label();
            labelNumero = new Label();
            labelBairro = new Label();
            labelInicioAtividade = new Label();
            label2 = new Label();
            labelNome = new Label();
            labelMunicipio = new Label();
            labelCodigoMec = new Label();
            labelRua = new Label();
            labelCategoriaAdministrativa = new Label();
            LabelEstado = new Label();
            labelOrganizacaoAcademica = new Label();
            labelStatusAtividade = new Label();
            dateTimePickerDataInicioAtividade = new DateTimePicker();
            comboBoxSituacaoCadastral = new ComboBox();
            textBoxComplemento = new TextBox();
            textBoxRua = new TextBox();
            textBoxMunicipio = new TextBox();
            comboBoxEstado = new ComboBox();
            textBoxBairro = new TextBox();
            textBoxCep = new TextBox();
            comboBoxOrganizacaoAcademica = new ComboBox();
            panelBotaoCancelar.SuspendLayout();
            panelBotaoSalvar.SuspendLayout();
            panelCriacao.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotaoCancelar
            // 
            panelBotaoCancelar.BackColor = Color.Transparent;
            panelBotaoCancelar.Controls.Add(botaoCancelar);
            panelBotaoCancelar.Location = new Point(446, 249);
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
            panelBotaoSalvar.Location = new Point(558, 249);
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
            labelTitulo.Size = new Size(95, 19);
            labelTitulo.TabIndex = 74;
            labelTitulo.Text = "Criação Escola";
            // 
            // textBoxNome
            // 
            textBoxNome.BackColor = Color.Cyan;
            textBoxNome.BorderStyle = BorderStyle.None;
            textBoxNome.ForeColor = Color.Black;
            textBoxNome.Location = new Point(241, 34);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(149, 16);
            textBoxNome.TabIndex = 73;
            // 
            // textBoxTelefone
            // 
            textBoxTelefone.BackColor = Color.Cyan;
            textBoxTelefone.BorderStyle = BorderStyle.None;
            textBoxTelefone.ForeColor = Color.Black;
            textBoxTelefone.Location = new Point(241, 78);
            textBoxTelefone.Name = "textBoxTelefone";
            textBoxTelefone.Size = new Size(149, 16);
            textBoxTelefone.TabIndex = 72;
            textBoxTelefone.KeyPress += AoPressionarTecla_textBoxTelefone;
            // 
            // comboBoxCategoriaAdministrativa
            // 
            comboBoxCategoriaAdministrativa.BackColor = Color.Cyan;
            comboBoxCategoriaAdministrativa.FlatStyle = FlatStyle.Flat;
            comboBoxCategoriaAdministrativa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCategoriaAdministrativa.ForeColor = Color.Black;
            comboBoxCategoriaAdministrativa.FormattingEnabled = true;
            comboBoxCategoriaAdministrativa.Location = new Point(241, 121);
            comboBoxCategoriaAdministrativa.Name = "comboBoxCategoriaAdministrativa";
            comboBoxCategoriaAdministrativa.Size = new Size(149, 23);
            comboBoxCategoriaAdministrativa.TabIndex = 67;
            comboBoxCategoriaAdministrativa.Format += AoFormatar_comboBoxCategoriaAdministrativa;
            comboBoxCategoriaAdministrativa.KeyPress += AoPressionarTecla_comboBox;
            // 
            // textBoxCodigoMec
            // 
            textBoxCodigoMec.BackColor = Color.Cyan;
            textBoxCodigoMec.BorderStyle = BorderStyle.None;
            textBoxCodigoMec.ForeColor = Color.Black;
            textBoxCodigoMec.Location = new Point(241, 56);
            textBoxCodigoMec.Name = "textBoxCodigoMec";
            textBoxCodigoMec.Size = new Size(149, 16);
            textBoxCodigoMec.TabIndex = 71;
            textBoxCodigoMec.KeyPress += AoPressionarTecla_textBoxCodigoMec;
            // 
            // labelTelefone
            // 
            labelTelefone.AutoSize = true;
            labelTelefone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTelefone.ForeColor = Color.White;
            labelTelefone.Location = new Point(13, 78);
            labelTelefone.Name = "labelTelefone";
            labelTelefone.Size = new Size(193, 21);
            labelTelefone.TabIndex = 68;
            labelTelefone.Text = "Telefone . . . . . . . . . . . . . . . . . :";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.ForeColor = Color.White;
            labelEmail.Location = new Point(13, 99);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(194, 21);
            labelEmail.TabIndex = 69;
            labelEmail.Text = "E-Mail . . . . . . . . . . . . . . . . . . . :";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = Color.Cyan;
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.ForeColor = Color.Black;
            textBoxEmail.Location = new Point(241, 100);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(149, 16);
            textBoxEmail.TabIndex = 76;
            // 
            // panelCriacao
            // 
            panelCriacao.BackColor = Color.BlueViolet;
            panelCriacao.Controls.Add(textBoxNumero);
            panelCriacao.Controls.Add(labelCep);
            panelCriacao.Controls.Add(labelNumero);
            panelCriacao.Controls.Add(labelBairro);
            panelCriacao.Controls.Add(labelInicioAtividade);
            panelCriacao.Controls.Add(label2);
            panelCriacao.Controls.Add(labelNome);
            panelCriacao.Controls.Add(labelMunicipio);
            panelCriacao.Controls.Add(labelCodigoMec);
            panelCriacao.Controls.Add(labelRua);
            panelCriacao.Controls.Add(labelCategoriaAdministrativa);
            panelCriacao.Controls.Add(LabelEstado);
            panelCriacao.Controls.Add(labelOrganizacaoAcademica);
            panelCriacao.Controls.Add(labelStatusAtividade);
            panelCriacao.Controls.Add(dateTimePickerDataInicioAtividade);
            panelCriacao.Controls.Add(comboBoxSituacaoCadastral);
            panelCriacao.Controls.Add(textBoxComplemento);
            panelCriacao.Controls.Add(textBoxRua);
            panelCriacao.Controls.Add(textBoxMunicipio);
            panelCriacao.Controls.Add(comboBoxEstado);
            panelCriacao.Controls.Add(textBoxBairro);
            panelCriacao.Controls.Add(textBoxCep);
            panelCriacao.Controls.Add(comboBoxOrganizacaoAcademica);
            panelCriacao.Controls.Add(panelBotaoCancelar);
            panelCriacao.Controls.Add(panelBotaoSalvar);
            panelCriacao.Controls.Add(labelEmail);
            panelCriacao.Controls.Add(labelTelefone);
            panelCriacao.Controls.Add(textBoxEmail);
            panelCriacao.Controls.Add(textBoxCodigoMec);
            panelCriacao.Controls.Add(comboBoxCategoriaAdministrativa);
            panelCriacao.Controls.Add(labelTitulo);
            panelCriacao.Controls.Add(textBoxTelefone);
            panelCriacao.Controls.Add(textBoxNome);
            panelCriacao.Location = new Point(-1, 1);
            panelCriacao.Name = "panelCriacao";
            panelCriacao.Size = new Size(682, 289);
            panelCriacao.TabIndex = 79;
            panelCriacao.Paint += AoRequererPintura_PanelCriacao;
            // 
            // textBoxNumero
            // 
            textBoxNumero.BackColor = Color.Cyan;
            textBoxNumero.BorderStyle = BorderStyle.None;
            textBoxNumero.ForeColor = Color.Black;
            textBoxNumero.Location = new Point(515, 151);
            textBoxNumero.Name = "textBoxNumero";
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
            // labelInicioAtividade
            // 
            labelInicioAtividade.AutoSize = true;
            labelInicioAtividade.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelInicioAtividade.ForeColor = Color.White;
            labelInicioAtividade.Location = new Point(13, 229);
            labelInicioAtividade.Name = "labelInicioAtividade";
            labelInicioAtividade.Size = new Size(187, 20);
            labelInicioAtividade.TabIndex = 104;
            labelInicioAtividade.Text = "Inicio Atividade. . . . . . . . .:";
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
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNome.ForeColor = Color.White;
            labelNome.Location = new Point(13, 34);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(227, 20);
            labelNome.TabIndex = 99;
            labelNome.Text = "Nome . . . . . . . . . . . . . . . . . . . . . :";
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
            // labelCodigoMec
            // 
            labelCodigoMec.AutoSize = true;
            labelCodigoMec.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCodigoMec.ForeColor = Color.White;
            labelCodigoMec.Location = new Point(13, 56);
            labelCodigoMec.Name = "labelCodigoMec";
            labelCodigoMec.Size = new Size(221, 20);
            labelCodigoMec.TabIndex = 100;
            labelCodigoMec.Text = "Codigo Mec . . . . . . . . . . . . . . . :";
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
            // labelCategoriaAdministrativa
            // 
            labelCategoriaAdministrativa.AutoSize = true;
            labelCategoriaAdministrativa.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCategoriaAdministrativa.ForeColor = Color.White;
            labelCategoriaAdministrativa.Location = new Point(13, 121);
            labelCategoriaAdministrativa.Name = "labelCategoriaAdministrativa";
            labelCategoriaAdministrativa.Size = new Size(185, 20);
            labelCategoriaAdministrativa.TabIndex = 101;
            labelCategoriaAdministrativa.Text = "Categoria Administrativa:";
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
            // labelOrganizacaoAcademica
            // 
            labelOrganizacaoAcademica.AutoSize = true;
            labelOrganizacaoAcademica.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelOrganizacaoAcademica.ForeColor = Color.White;
            labelOrganizacaoAcademica.Location = new Point(13, 151);
            labelOrganizacaoAcademica.Name = "labelOrganizacaoAcademica";
            labelOrganizacaoAcademica.Size = new Size(210, 20);
            labelOrganizacaoAcademica.TabIndex = 102;
            labelOrganizacaoAcademica.Text = "Organizacao Academica . . .:";
            // 
            // labelStatusAtividade
            // 
            labelStatusAtividade.AutoSize = true;
            labelStatusAtividade.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatusAtividade.ForeColor = Color.White;
            labelStatusAtividade.Location = new Point(13, 179);
            labelStatusAtividade.Name = "labelStatusAtividade";
            labelStatusAtividade.Size = new Size(197, 20);
            labelStatusAtividade.TabIndex = 103;
            labelStatusAtividade.Text = "Status Atividade. . . . . . . . .:";
            // 
            // dateTimePickerDataInicioAtividade
            // 
            dateTimePickerDataInicioAtividade.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicioAtividade.CalendarForeColor = Color.Cyan;
            dateTimePickerDataInicioAtividade.CalendarMonthBackground = Color.Cyan;
            dateTimePickerDataInicioAtividade.CalendarTitleBackColor = Color.Cyan;
            dateTimePickerDataInicioAtividade.CalendarTitleForeColor = Color.Cyan;
            dateTimePickerDataInicioAtividade.CalendarTrailingForeColor = Color.Cyan;
            dateTimePickerDataInicioAtividade.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicioAtividade.Format = DateTimePickerFormat.Short;
            dateTimePickerDataInicioAtividade.Location = new Point(241, 218);
            dateTimePickerDataInicioAtividade.Name = "dateTimePickerDataInicioAtividade";
            dateTimePickerDataInicioAtividade.Size = new Size(149, 22);
            dateTimePickerDataInicioAtividade.TabIndex = 98;
            dateTimePickerDataInicioAtividade.ValueChanged += AoAlterarValor_dateTimePickerDataInicioAtividade;
            // 
            // comboBoxSituacaoCadastral
            // 
            comboBoxSituacaoCadastral.BackColor = Color.Cyan;
            comboBoxSituacaoCadastral.FlatStyle = FlatStyle.Flat;
            comboBoxSituacaoCadastral.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxSituacaoCadastral.ForeColor = Color.Black;
            comboBoxSituacaoCadastral.FormattingEnabled = true;
            comboBoxSituacaoCadastral.Location = new Point(241, 179);
            comboBoxSituacaoCadastral.Name = "comboBoxSituacaoCadastral";
            comboBoxSituacaoCadastral.Size = new Size(149, 23);
            comboBoxSituacaoCadastral.TabIndex = 97;
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
            textBoxCep.Size = new Size(149, 16);
            textBoxCep.TabIndex = 91;
            textBoxCep.KeyPress += AoPressionarTecla_textBoxCep;
            // 
            // comboBoxOrganizacaoAcademica
            // 
            comboBoxOrganizacaoAcademica.BackColor = Color.Cyan;
            comboBoxOrganizacaoAcademica.FlatStyle = FlatStyle.Flat;
            comboBoxOrganizacaoAcademica.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxOrganizacaoAcademica.ForeColor = Color.Black;
            comboBoxOrganizacaoAcademica.FormattingEnabled = true;
            comboBoxOrganizacaoAcademica.Location = new Point(241, 150);
            comboBoxOrganizacaoAcademica.Name = "comboBoxOrganizacaoAcademica";
            comboBoxOrganizacaoAcademica.Size = new Size(149, 23);
            comboBoxOrganizacaoAcademica.TabIndex = 83;
            comboBoxOrganizacaoAcademica.Format += AoFormatar_comboBoxOrganizacaoAcademica;
            // 
            // TelaCriarEscolaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(693, 302);
            Controls.Add(panelCriacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCriarEscolaForm";
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
        private TextBox textBoxNome;
        private TextBox textBoxTelefone;
        private ComboBox comboBoxCategoriaAdministrativa;
        private TextBox textBoxCodigoMec;
        private Label labelTelefone;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Panel panelCriacao;
        private ComboBox comboBoxOrganizacaoAcademica;
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
        private DateTimePicker dateTimePickerDataInicioAtividade;
        private Label labelNome;
        private Label labelCodigoMec;
        private Label labelCategoriaAdministrativa;
        private Label labelOrganizacaoAcademica;
        private Label labelStatusAtividade;
        private Label labelInicioAtividade;
        private Label label2;
        private TextBox textBoxNumero;
        private Label labelNumero;
    }
}