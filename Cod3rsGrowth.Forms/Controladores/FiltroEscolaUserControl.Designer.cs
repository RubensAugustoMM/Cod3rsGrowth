namespace Cod3rsGrowth.Forms.Controladores
{
    partial class FiltroEscolaUserControl
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
            idEmpresaLabel = new Label();
            botaoFechar = new Button();
            botaoFiltrar = new Button();
            botaoLimpar = new Button();
            comboBoxCategoriaAdministrativa = new ComboBox();
            textBoxNome = new TextBox();
            labelCodigoMec = new Label();
            labelCategoriaAdministrativa = new Label();
            labelOrganizacaoAcademica = new Label();
            labelIdEndereco = new Label();
            labelStatusAtividade = new Label();
            labelInicioAtividade = new Label();
            textBoxCodigoMec = new TextBox();
            comboBoxOrganizacaoAcademica = new ComboBox();
            textBoxIdEndereco = new TextBox();
            checkBoxHabilitadoStatusAtividade = new CheckBox();
            checkBoxStatusAtividade = new CheckBox();
            dateTimePickerDataInicioAtividade = new DateTimePicker();
            labelMenor = new Label();
            labelMaior = new Label();
            checkBoxMenorInicioAtividade = new CheckBox();
            checkBoxMaiorInicioAtividade = new CheckBox();
            SuspendLayout();
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            idEmpresaLabel.ForeColor = Color.White;
            idEmpresaLabel.Location = new Point(15, 30);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new Size(207, 21);
            idEmpresaLabel.TabIndex = 5;
            idEmpresaLabel.Text = "Nome . . . . . . . . . . . . . . . . . . . . . :";
            // 
            // botaoFechar
            // 
            botaoFechar.FlatAppearance.BorderSize = 0;
            botaoFechar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFechar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFechar.FlatStyle = FlatStyle.Flat;
            botaoFechar.ForeColor = Color.White;
            botaoFechar.Location = new Point(243, 250);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new Size(67, 40);
            botaoFechar.TabIndex = 14;
            botaoFechar.Text = "Fechar";
            botaoFechar.UseVisualStyleBackColor = true;
            botaoFechar.Click += botaoFechar_Click;
            // 
            // botaoFiltrar
            // 
            botaoFiltrar.FlatAppearance.BorderSize = 0;
            botaoFiltrar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFiltrar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFiltrar.FlatStyle = FlatStyle.Flat;
            botaoFiltrar.ForeColor = Color.White;
            botaoFiltrar.Location = new Point(388, 250);
            botaoFiltrar.Name = "botaoFiltrar";
            botaoFiltrar.Size = new Size(67, 40);
            botaoFiltrar.TabIndex = 15;
            botaoFiltrar.Text = "Filtrar";
            botaoFiltrar.UseVisualStyleBackColor = true;
            botaoFiltrar.Click += botaoFiltrar_Click;
            // 
            // botaoLimpar
            // 
            botaoLimpar.FlatAppearance.BorderSize = 0;
            botaoLimpar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoLimpar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoLimpar.FlatStyle = FlatStyle.Flat;
            botaoLimpar.ForeColor = Color.White;
            botaoLimpar.Location = new Point(316, 250);
            botaoLimpar.Name = "botaoLimpar";
            botaoLimpar.Size = new Size(67, 40);
            botaoLimpar.TabIndex = 22;
            botaoLimpar.Text = "Limpar";
            botaoLimpar.UseVisualStyleBackColor = true;
            botaoLimpar.Click += botaoLimpar_Click;
            // 
            // comboBoxCategoriaAdministrativa
            // 
            comboBoxCategoriaAdministrativa.BackColor = Color.Yellow;
            comboBoxCategoriaAdministrativa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCategoriaAdministrativa.FormattingEnabled = true;
            comboBoxCategoriaAdministrativa.Location = new Point(192, 92);
            comboBoxCategoriaAdministrativa.Name = "comboBoxCategoriaAdministrativa";
            comboBoxCategoriaAdministrativa.Size = new Size(149, 23);
            comboBoxCategoriaAdministrativa.TabIndex = 41;
            // 
            // textBoxNome
            // 
            textBoxNome.BackColor = Color.Black;
            textBoxNome.BorderStyle = BorderStyle.None;
            textBoxNome.ForeColor = Color.Yellow;
            textBoxNome.Location = new Point(192, 30);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(149, 16);
            textBoxNome.TabIndex = 45;
            // 
            // labelCodigoMec
            // 
            labelCodigoMec.AutoSize = true;
            labelCodigoMec.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCodigoMec.ForeColor = Color.White;
            labelCodigoMec.Location = new Point(15, 51);
            labelCodigoMec.Name = "labelCodigoMec";
            labelCodigoMec.Size = new Size(201, 21);
            labelCodigoMec.TabIndex = 46;
            labelCodigoMec.Text = "Codigo Mec. . . . . . . . . . . . . . . :";
            // 
            // labelCategoriaAdministrativa
            // 
            labelCategoriaAdministrativa.AutoSize = true;
            labelCategoriaAdministrativa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCategoriaAdministrativa.ForeColor = Color.White;
            labelCategoriaAdministrativa.Location = new Point(15, 94);
            labelCategoriaAdministrativa.Name = "labelCategoriaAdministrativa";
            labelCategoriaAdministrativa.Size = new Size(185, 21);
            labelCategoriaAdministrativa.TabIndex = 47;
            labelCategoriaAdministrativa.Text = "Categoria Administrativa:";
            // 
            // labelOrganizacaoAcademica
            // 
            labelOrganizacaoAcademica.AutoSize = true;
            labelOrganizacaoAcademica.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelOrganizacaoAcademica.ForeColor = Color.White;
            labelOrganizacaoAcademica.Location = new Point(15, 135);
            labelOrganizacaoAcademica.Name = "labelOrganizacaoAcademica";
            labelOrganizacaoAcademica.Size = new Size(200, 21);
            labelOrganizacaoAcademica.TabIndex = 48;
            labelOrganizacaoAcademica.Text = "Organizacao Academica . . .:";
            // 
            // labelIdEndereco
            // 
            labelIdEndereco.AutoSize = true;
            labelIdEndereco.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIdEndereco.ForeColor = Color.White;
            labelIdEndereco.Location = new Point(17, 71);
            labelIdEndereco.Name = "labelIdEndereco";
            labelIdEndereco.Size = new Size(192, 21);
            labelIdEndereco.TabIndex = 49;
            labelIdEndereco.Text = "Id Endereco. . . . . . . . . . . . . . :";
            // 
            // labelStatusAtividade
            // 
            labelStatusAtividade.AutoSize = true;
            labelStatusAtividade.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatusAtividade.ForeColor = Color.White;
            labelStatusAtividade.Location = new Point(15, 169);
            labelStatusAtividade.Name = "labelStatusAtividade";
            labelStatusAtividade.Size = new Size(183, 21);
            labelStatusAtividade.TabIndex = 50;
            labelStatusAtividade.Text = "Status Atividade. . . . . . . . .:";
            // 
            // labelInicioAtividade
            // 
            labelInicioAtividade.AutoSize = true;
            labelInicioAtividade.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelInicioAtividade.ForeColor = Color.White;
            labelInicioAtividade.Location = new Point(15, 210);
            labelInicioAtividade.Name = "labelInicioAtividade";
            labelInicioAtividade.Size = new Size(178, 21);
            labelInicioAtividade.TabIndex = 51;
            labelInicioAtividade.Text = "Inicio Atividade. . . . . . . . .:";
            // 
            // textBoxCodigoMec
            // 
            textBoxCodigoMec.BackColor = Color.Black;
            textBoxCodigoMec.BorderStyle = BorderStyle.None;
            textBoxCodigoMec.ForeColor = Color.Yellow;
            textBoxCodigoMec.Location = new Point(192, 51);
            textBoxCodigoMec.Name = "textBoxCodigoMec";
            textBoxCodigoMec.Size = new Size(149, 16);
            textBoxCodigoMec.TabIndex = 52;
            // 
            // comboBoxOrganizacaoAcademica
            // 
            comboBoxOrganizacaoAcademica.BackColor = Color.Yellow;
            comboBoxOrganizacaoAcademica.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxOrganizacaoAcademica.FormattingEnabled = true;
            comboBoxOrganizacaoAcademica.Location = new Point(192, 133);
            comboBoxOrganizacaoAcademica.Name = "comboBoxOrganizacaoAcademica";
            comboBoxOrganizacaoAcademica.Size = new Size(149, 23);
            comboBoxOrganizacaoAcademica.TabIndex = 53;
            // 
            // textBoxIdEndereco
            // 
            textBoxIdEndereco.BackColor = Color.Black;
            textBoxIdEndereco.BorderStyle = BorderStyle.None;
            textBoxIdEndereco.ForeColor = Color.Yellow;
            textBoxIdEndereco.Location = new Point(192, 71);
            textBoxIdEndereco.Name = "textBoxIdEndereco";
            textBoxIdEndereco.Size = new Size(149, 16);
            textBoxIdEndereco.TabIndex = 54;
            textBoxIdEndereco.KeyPress += somenteValoresNaturais_KeyPress;
            // 
            // checkBoxHabilitadoStatusAtividade
            // 
            checkBoxHabilitadoStatusAtividade.AutoSize = true;
            checkBoxHabilitadoStatusAtividade.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoStatusAtividade.ForeColor = Color.White;
            checkBoxHabilitadoStatusAtividade.Location = new Point(211, 173);
            checkBoxHabilitadoStatusAtividade.Name = "checkBoxHabilitadoStatusAtividade";
            checkBoxHabilitadoStatusAtividade.Size = new Size(86, 19);
            checkBoxHabilitadoStatusAtividade.TabIndex = 59;
            checkBoxHabilitadoStatusAtividade.Text = "Habilitado?";
            checkBoxHabilitadoStatusAtividade.UseVisualStyleBackColor = true;
            // 
            // checkBoxStatusAtividade
            // 
            checkBoxStatusAtividade.AutoSize = true;
            checkBoxStatusAtividade.FlatAppearance.BorderSize = 0;
            checkBoxStatusAtividade.ForeColor = Color.White;
            checkBoxStatusAtividade.Location = new Point(190, 175);
            checkBoxStatusAtividade.Name = "checkBoxStatusAtividade";
            checkBoxStatusAtividade.Size = new Size(15, 14);
            checkBoxStatusAtividade.TabIndex = 58;
            checkBoxStatusAtividade.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDataInicioAtividade
            // 
            dateTimePickerDataInicioAtividade.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicioAtividade.CalendarForeColor = Color.White;
            dateTimePickerDataInicioAtividade.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataInicioAtividade.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataInicioAtividade.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataInicioAtividade.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataInicioAtividade.Format = DateTimePickerFormat.Short;
            dateTimePickerDataInicioAtividade.Location = new Point(190, 208);
            dateTimePickerDataInicioAtividade.Name = "dateTimePickerDataInicioAtividade";
            dateTimePickerDataInicioAtividade.Size = new Size(149, 23);
            dateTimePickerDataInicioAtividade.TabIndex = 60;
            // 
            // labelMenor
            // 
            labelMenor.AutoSize = true;
            labelMenor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMenor.ForeColor = Color.White;
            labelMenor.Location = new Point(391, 16);
            labelMenor.Name = "labelMenor";
            labelMenor.Size = new Size(56, 21);
            labelMenor.TabIndex = 64;
            labelMenor.Text = "Menor";
            // 
            // labelMaior
            // 
            labelMaior.AutoSize = true;
            labelMaior.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMaior.ForeColor = Color.White;
            labelMaior.Location = new Point(343, 16);
            labelMaior.Name = "labelMaior";
            labelMaior.Size = new Size(51, 21);
            labelMaior.TabIndex = 63;
            labelMaior.Text = "Maior";
            // 
            // checkBoxMenorInicioAtividade
            // 
            checkBoxMenorInicioAtividade.AutoSize = true;
            checkBoxMenorInicioAtividade.FlatAppearance.BorderSize = 0;
            checkBoxMenorInicioAtividade.ForeColor = SystemColors.Window;
            checkBoxMenorInicioAtividade.Location = new Point(405, 215);
            checkBoxMenorInicioAtividade.Name = "checkBoxMenorInicioAtividade";
            checkBoxMenorInicioAtividade.Size = new Size(15, 14);
            checkBoxMenorInicioAtividade.TabIndex = 62;
            checkBoxMenorInicioAtividade.UseVisualStyleBackColor = true;
            checkBoxMenorInicioAtividade.CheckedChanged += checkBoxMenorInicioAtividade_CheckedChanged;
            // 
            // checkBoxMaiorInicioAtividade
            // 
            checkBoxMaiorInicioAtividade.AutoSize = true;
            checkBoxMaiorInicioAtividade.FlatAppearance.BorderSize = 0;
            checkBoxMaiorInicioAtividade.ForeColor = Color.White;
            checkBoxMaiorInicioAtividade.Location = new Point(345, 215);
            checkBoxMaiorInicioAtividade.Name = "checkBoxMaiorInicioAtividade";
            checkBoxMaiorInicioAtividade.Size = new Size(15, 14);
            checkBoxMaiorInicioAtividade.TabIndex = 61;
            checkBoxMaiorInicioAtividade.UseVisualStyleBackColor = true;
            checkBoxMaiorInicioAtividade.CheckedChanged += checkBoxMaiorInicioAtividade_CheckedChanged;
            // 
            // FiltroEscolaUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            Controls.Add(labelMenor);
            Controls.Add(labelMaior);
            Controls.Add(checkBoxMenorInicioAtividade);
            Controls.Add(checkBoxMaiorInicioAtividade);
            Controls.Add(dateTimePickerDataInicioAtividade);
            Controls.Add(checkBoxHabilitadoStatusAtividade);
            Controls.Add(checkBoxStatusAtividade);
            Controls.Add(textBoxIdEndereco);
            Controls.Add(comboBoxOrganizacaoAcademica);
            Controls.Add(textBoxCodigoMec);
            Controls.Add(labelInicioAtividade);
            Controls.Add(labelStatusAtividade);
            Controls.Add(labelIdEndereco);
            Controls.Add(labelOrganizacaoAcademica);
            Controls.Add(labelCategoriaAdministrativa);
            Controls.Add(labelCodigoMec);
            Controls.Add(textBoxNome);
            Controls.Add(comboBoxCategoriaAdministrativa);
            Controls.Add(botaoLimpar);
            Controls.Add(botaoFiltrar);
            Controls.Add(botaoFechar);
            Controls.Add(idEmpresaLabel);
            Name = "FiltroEscolaUserControl";
            Size = new Size(456, 293);
            Load += FiltroConvenioUserControl_Load;
            Paint += FiltroConvenioUserControl_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label dataInicioLabel;
        private Label dataTerminoLabel;
        private Label idEmpresaLabel;
        private TextBox textBoxValor;
        private DateTimePicker dateTimePickerDataInicio;
        private TextBox textBoxIdEmpresa;
        private TextBox textBoxIdEscola;
        private DateTimePicker dateTimePickerDataTermino;
        private Button botaoFechar;
        private Button botaoFiltrar;
        private CheckBox checkBoxMaiorValor;
        private CheckBox checkBoxMenorValor;
        private CheckBox checkBoxMaiorDataInicio;
        private CheckBox checkBoxMenorDataInicio;
        private CheckBox checkBoxMaiorDataTermino;
        private CheckBox checkBoxMenorDataTermino;
        private Button botaoLimpar;
        private ComboBox comboBoxCategoriaAdministrativa;
        private TextBox textBoxNome;
        private Label labelMaior;
        private Label labelMenor;
        private Label labelCodigoMec;
        private Label labelCategoriaAdministrativa;
        private Label labelOrganizacaoAcademica;
        private Label labelIdEndereco;
        private Label labelStatusAtividade;
        private Label labelInicioAtividade;
        private TextBox textBoxCodigoMec;
        private ComboBox comboBoxOrganizacaoAcademica;
        private TextBox textBoxIdEndereco;
        private CheckBox checkBoxHabilitadoStatusAtividade;
        private CheckBox checkBoxStatusAtividade;
        private DateTimePicker dateTimePickerDataInicioAtividade;
        private CheckBox checkBoxMenorInicioAtividade;
        private CheckBox checkBoxMaiorInicioAtividade;
    }
}
