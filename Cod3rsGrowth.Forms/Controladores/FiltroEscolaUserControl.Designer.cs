﻿namespace Cod3rsGrowth.Forms.Controladores
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
            comboBoxCategoriaAdministrativa = new ComboBox();
            textBoxNome = new TextBox();
            labelCodigoMec = new Label();
            labelCategoriaAdministrativa = new Label();
            labelOrganizacaoAcademica = new Label();
            labelStatusAtividade = new Label();
            labelInicioAtividade = new Label();
            textBoxCodigoMec = new TextBox();
            comboBoxOrganizacaoAcademica = new ComboBox();
            dateTimePickerDataInicioAtividade = new DateTimePicker();
            comboBoxMaiorMenorIgualInicioAtividade = new ComboBox();
            panelBotaoFiltrar = new Panel();
            botaoFiltrar = new Button();
            panel1 = new Panel();
            botaoLimpar = new Button();
            panel2 = new Panel();
            botaoFechar = new Button();
            panelFiltro = new Panel();
            comboBoxEstado = new ComboBox();
            labelEstado = new Label();
            comboBoxHabilitadoStatusAtividade = new ComboBox();
            labelTitulo = new Label();
            panelBotaoFiltrar.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelFiltro.SuspendLayout();
            SuspendLayout();
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            idEmpresaLabel.ForeColor = Color.White;
            idEmpresaLabel.Location = new Point(15, 19);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new Size(176, 16);
            idEmpresaLabel.TabIndex = 5;
            idEmpresaLabel.Text = "Nome . . . . . . . . . . . . . . . . . . . . . :";
            // 
            // comboBoxCategoriaAdministrativa
            // 
            comboBoxCategoriaAdministrativa.BackColor = Color.Black;
            comboBoxCategoriaAdministrativa.FlatStyle = FlatStyle.Flat;
            comboBoxCategoriaAdministrativa.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCategoriaAdministrativa.ForeColor = Color.White;
            comboBoxCategoriaAdministrativa.FormattingEnabled = true;
            comboBoxCategoriaAdministrativa.Location = new Point(241, 85);
            comboBoxCategoriaAdministrativa.Name = "comboBoxCategoriaAdministrativa";
            comboBoxCategoriaAdministrativa.Size = new Size(149, 24);
            comboBoxCategoriaAdministrativa.TabIndex = 41;
            comboBoxCategoriaAdministrativa.Format += AoFormatarComboBoxCategoriaAdministrativa;
            comboBoxCategoriaAdministrativa.Click += AoClicarEmComboBoxCategoriaAdministrativa;
            // 
            // textBoxNome
            // 
            textBoxNome.BackColor = Color.Black;
            textBoxNome.BorderStyle = BorderStyle.None;
            textBoxNome.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNome.ForeColor = Color.Yellow;
            textBoxNome.Location = new Point(241, 19);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(149, 15);
            textBoxNome.TabIndex = 45;
            // 
            // labelCodigoMec
            // 
            labelCodigoMec.AutoSize = true;
            labelCodigoMec.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelCodigoMec.ForeColor = Color.White;
            labelCodigoMec.Location = new Point(15, 40);
            labelCodigoMec.Name = "labelCodigoMec";
            labelCodigoMec.Size = new Size(176, 16);
            labelCodigoMec.TabIndex = 46;
            labelCodigoMec.Text = "Codigo Mec . . . . . . . . . . . . . . . :";
            // 
            // labelCategoriaAdministrativa
            // 
            labelCategoriaAdministrativa.AutoSize = true;
            labelCategoriaAdministrativa.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelCategoriaAdministrativa.ForeColor = Color.White;
            labelCategoriaAdministrativa.Location = new Point(15, 87);
            labelCategoriaAdministrativa.Name = "labelCategoriaAdministrativa";
            labelCategoriaAdministrativa.Size = new Size(156, 16);
            labelCategoriaAdministrativa.TabIndex = 47;
            labelCategoriaAdministrativa.Text = "Categoria Administrativa:";
            // 
            // labelOrganizacaoAcademica
            // 
            labelOrganizacaoAcademica.AutoSize = true;
            labelOrganizacaoAcademica.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelOrganizacaoAcademica.ForeColor = Color.White;
            labelOrganizacaoAcademica.Location = new Point(15, 108);
            labelOrganizacaoAcademica.Name = "labelOrganizacaoAcademica";
            labelOrganizacaoAcademica.Size = new Size(177, 16);
            labelOrganizacaoAcademica.TabIndex = 48;
            labelOrganizacaoAcademica.Text = "Organizacao Academica . . .:";
            // 
            // labelStatusAtividade
            // 
            labelStatusAtividade.AutoSize = true;
            labelStatusAtividade.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatusAtividade.ForeColor = Color.White;
            labelStatusAtividade.Location = new Point(15, 128);
            labelStatusAtividade.Name = "labelStatusAtividade";
            labelStatusAtividade.Size = new Size(158, 16);
            labelStatusAtividade.TabIndex = 50;
            labelStatusAtividade.Text = "Status Atividade. . . . . . . . .:";
            // 
            // labelInicioAtividade
            // 
            labelInicioAtividade.AutoSize = true;
            labelInicioAtividade.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelInicioAtividade.ForeColor = Color.White;
            labelInicioAtividade.Location = new Point(16, 157);
            labelInicioAtividade.Name = "labelInicioAtividade";
            labelInicioAtividade.Size = new Size(152, 16);
            labelInicioAtividade.TabIndex = 51;
            labelInicioAtividade.Text = "Inicio Atividade. . . . . . . . .:";
            // 
            // textBoxCodigoMec
            // 
            textBoxCodigoMec.BackColor = Color.Black;
            textBoxCodigoMec.BorderStyle = BorderStyle.None;
            textBoxCodigoMec.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCodigoMec.ForeColor = Color.Yellow;
            textBoxCodigoMec.Location = new Point(241, 40);
            textBoxCodigoMec.Name = "textBoxCodigoMec";
            textBoxCodigoMec.Size = new Size(149, 15);
            textBoxCodigoMec.TabIndex = 52;
            textBoxCodigoMec.KeyPress += AoPressionarTeclaTextBoxCodigoMec;
            // 
            // comboBoxOrganizacaoAcademica
            // 
            comboBoxOrganizacaoAcademica.BackColor = Color.Black;
            comboBoxOrganizacaoAcademica.FlatStyle = FlatStyle.Flat;
            comboBoxOrganizacaoAcademica.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxOrganizacaoAcademica.ForeColor = Color.White;
            comboBoxOrganizacaoAcademica.FormattingEnabled = true;
            comboBoxOrganizacaoAcademica.Location = new Point(241, 106);
            comboBoxOrganizacaoAcademica.Name = "comboBoxOrganizacaoAcademica";
            comboBoxOrganizacaoAcademica.Size = new Size(149, 24);
            comboBoxOrganizacaoAcademica.TabIndex = 53;
            comboBoxOrganizacaoAcademica.Format += AoFormatarComboBoxOrganizacaoAcademica;
            comboBoxOrganizacaoAcademica.Click += AoClicarEmComboBoxOrganizacaoAcademica;
            // 
            // dateTimePickerDataInicioAtividade
            // 
            dateTimePickerDataInicioAtividade.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicioAtividade.CalendarForeColor = Color.White;
            dateTimePickerDataInicioAtividade.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataInicioAtividade.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataInicioAtividade.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataInicioAtividade.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataInicioAtividade.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicioAtividade.Format = DateTimePickerFormat.Short;
            dateTimePickerDataInicioAtividade.Location = new Point(240, 155);
            dateTimePickerDataInicioAtividade.Name = "dateTimePickerDataInicioAtividade";
            dateTimePickerDataInicioAtividade.Size = new Size(149, 22);
            dateTimePickerDataInicioAtividade.TabIndex = 60;
            dateTimePickerDataInicioAtividade.ValueChanged += AoAlterarValorDateTimePickerDataInicioAtividade;
            // 
            // comboBoxMaiorMenorIgualInicioAtividade
            // 
            comboBoxMaiorMenorIgualInicioAtividade.BackColor = Color.Black;
            comboBoxMaiorMenorIgualInicioAtividade.FlatStyle = FlatStyle.Flat;
            comboBoxMaiorMenorIgualInicioAtividade.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxMaiorMenorIgualInicioAtividade.ForeColor = Color.White;
            comboBoxMaiorMenorIgualInicioAtividade.FormattingEnabled = true;
            comboBoxMaiorMenorIgualInicioAtividade.Location = new Point(395, 155);
            comboBoxMaiorMenorIgualInicioAtividade.Name = "comboBoxMaiorMenorIgualInicioAtividade";
            comboBoxMaiorMenorIgualInicioAtividade.Size = new Size(125, 24);
            comboBoxMaiorMenorIgualInicioAtividade.TabIndex = 68;
            // 
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.BackColor = Color.Transparent;
            panelBotaoFiltrar.Controls.Add(botaoFiltrar);
            panelBotaoFiltrar.Location = new Point(413, 185);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(106, 40);
            panelBotaoFiltrar.TabIndex = 69;
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
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(botaoLimpar);
            panel1.Location = new Point(301, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(106, 40);
            panel1.TabIndex = 33;
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
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(botaoFechar);
            panel2.Location = new Point(189, 185);
            panel2.Name = "panel2";
            panel2.Size = new Size(106, 40);
            panel2.TabIndex = 34;
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
            // panelFiltro
            // 
            panelFiltro.BackColor = Color.DarkGray;
            panelFiltro.Controls.Add(comboBoxEstado);
            panelFiltro.Controls.Add(labelEstado);
            panelFiltro.Controls.Add(comboBoxHabilitadoStatusAtividade);
            panelFiltro.Controls.Add(labelTitulo);
            panelFiltro.Controls.Add(idEmpresaLabel);
            panelFiltro.Controls.Add(panel2);
            panelFiltro.Controls.Add(comboBoxCategoriaAdministrativa);
            panelFiltro.Controls.Add(panel1);
            panelFiltro.Controls.Add(textBoxNome);
            panelFiltro.Controls.Add(panelBotaoFiltrar);
            panelFiltro.Controls.Add(labelCodigoMec);
            panelFiltro.Controls.Add(comboBoxMaiorMenorIgualInicioAtividade);
            panelFiltro.Controls.Add(labelCategoriaAdministrativa);
            panelFiltro.Controls.Add(dateTimePickerDataInicioAtividade);
            panelFiltro.Controls.Add(labelOrganizacaoAcademica);
            panelFiltro.Controls.Add(labelStatusAtividade);
            panelFiltro.Controls.Add(labelInicioAtividade);
            panelFiltro.Controls.Add(comboBoxOrganizacaoAcademica);
            panelFiltro.Controls.Add(textBoxCodigoMec);
            panelFiltro.Location = new Point(0, 0);
            panelFiltro.Name = "panelFiltro";
            panelFiltro.Size = new Size(539, 226);
            panelFiltro.TabIndex = 70;
            panelFiltro.Paint += AoPintarControladorBordas;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.BackColor = Color.Black;
            comboBoxEstado.FlatStyle = FlatStyle.Flat;
            comboBoxEstado.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstado.ForeColor = Color.White;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(241, 61);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(149, 24);
            comboBoxEstado.TabIndex = 74;
            comboBoxEstado.Format += AoFormatarComboBoxEstado;
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelEstado.ForeColor = Color.White;
            labelEstado.Location = new Point(15, 63);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(170, 16);
            labelEstado.TabIndex = 75;
            labelEstado.Text = "Estado . . . . . . . . . . . . . . . . . . . :";
            // 
            // comboBoxHabilitadoStatusAtividade
            // 
            comboBoxHabilitadoStatusAtividade.BackColor = Color.Black;
            comboBoxHabilitadoStatusAtividade.FlatStyle = FlatStyle.Flat;
            comboBoxHabilitadoStatusAtividade.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxHabilitadoStatusAtividade.ForeColor = Color.White;
            comboBoxHabilitadoStatusAtividade.FormattingEnabled = true;
            comboBoxHabilitadoStatusAtividade.Location = new Point(241, 126);
            comboBoxHabilitadoStatusAtividade.Name = "comboBoxHabilitadoStatusAtividade";
            comboBoxHabilitadoStatusAtividade.Size = new Size(149, 23);
            comboBoxHabilitadoStatusAtividade.TabIndex = 73;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(220, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(81, 19);
            labelTitulo.TabIndex = 70;
            labelTitulo.Text = "Filtro Escola";
            // 
            // FiltroEscolaUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panelFiltro);
            Name = "FiltroEscolaUserControl";
            Size = new Size(549, 258);
            Load += AoCarregarControlador;
            Paint += AoPintarControladorSombra;
            panelBotaoFiltrar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelFiltro.ResumeLayout(false);
            panelFiltro.PerformLayout();
            ResumeLayout(false);
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
        private CheckBox checkBoxMaiorValor;
        private CheckBox checkBoxMenorValor;
        private CheckBox checkBoxMaiorDataInicio;
        private CheckBox checkBoxMenorDataInicio;
        private CheckBox checkBoxMaiorDataTermino;
        private CheckBox checkBoxMenorDataTermino;
        private ComboBox comboBoxCategoriaAdministrativa;
        private TextBox textBoxNome;
        private Label labelCodigoMec;
        private Label labelCategoriaAdministrativa;
        private Label labelOrganizacaoAcademica;
        private Label labelStatusAtividade;
        private Label labelInicioAtividade;
        private TextBox textBoxCodigoMec;
        private ComboBox comboBoxOrganizacaoAcademica;
        private DateTimePicker dateTimePickerDataInicioAtividade;
        private ComboBox comboBoxMaiorMenorIgualInicioAtividade;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltrar;
        private Panel panel1;
        private Button botaoLimpar;
        private Panel panel2;
        private Button botaoFechar;
        private Panel panelFiltro;
        private Label labelTitulo;
        private ComboBox comboBoxHabilitadoStatusAtividade;
        private ComboBox comboBoxEstado;
        private Label labelEstado;
    }
}
