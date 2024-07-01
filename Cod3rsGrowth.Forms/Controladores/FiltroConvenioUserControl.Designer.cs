namespace Cod3rsGrowth.Forms.Controladores
{
    partial class FiltroConvenioUserControl
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
            objetoLabel = new Label();
            valorLabel = new Label();
            dataInicioLabel = new Label();
            dataTerminoLabel = new Label();
            idEscolaLabel = new Label();
            idEmpresaLabel = new Label();
            textBoxObjeto = new TextBox();
            textBoxValor = new TextBox();
            dateTimePickerDataInicio = new DateTimePicker();
            textBoxIdEmpresa = new TextBox();
            textBoxIdEscola = new TextBox();
            dateTimePickerDataTermino = new DateTimePicker();
            botaoFechar = new Button();
            botaoFiltrar = new Button();
            checkBoxMaiorValor = new CheckBox();
            checkBoxMenorValor = new CheckBox();
            checkBoxMaiorDataInicio = new CheckBox();
            checkBoxMenorDataInicio = new CheckBox();
            checkBoxMaiorDataTermino = new CheckBox();
            checkBoxMenorDataTermino = new CheckBox();
            botaoLimpar = new Button();
            labelMaior = new Label();
            labelMenor = new Label();
            checkBoxHabilitadoDataTermino = new CheckBox();
            checkBoxHabilitadoDataInicio = new CheckBox();
            SuspendLayout();
            // 
            // objetoLabel
            // 
            objetoLabel.AutoSize = true;
            objetoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            objetoLabel.ForeColor = Color.White;
            objetoLabel.Location = new Point(40, 31);
            objetoLabel.Name = "objetoLabel";
            objetoLabel.Size = new Size(113, 21);
            objetoLabel.TabIndex = 0;
            objetoLabel.Text = "Objeto . . . . . . . :";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            valorLabel.ForeColor = Color.White;
            valorLabel.Location = new Point(40, 52);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new Size(109, 21);
            valorLabel.TabIndex = 1;
            valorLabel.Text = "Valor . . . . . . . . :";
            // 
            // dataInicioLabel
            // 
            dataInicioLabel.AutoSize = true;
            dataInicioLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataInicioLabel.ForeColor = Color.White;
            dataInicioLabel.Location = new Point(40, 138);
            dataInicioLabel.Name = "dataInicioLabel";
            dataInicioLabel.Size = new Size(104, 21);
            dataInicioLabel.TabIndex = 2;
            dataInicioLabel.Text = "Data Inicio . . :";
            // 
            // dataTerminoLabel
            // 
            dataTerminoLabel.AutoSize = true;
            dataTerminoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataTerminoLabel.ForeColor = Color.White;
            dataTerminoLabel.Location = new Point(40, 180);
            dataTerminoLabel.Name = "dataTerminoLabel";
            dataTerminoLabel.Size = new Size(116, 21);
            dataTerminoLabel.TabIndex = 3;
            dataTerminoLabel.Text = "Data Termino . :";
            // 
            // idEscolaLabel
            // 
            idEscolaLabel.AutoSize = true;
            idEscolaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            idEscolaLabel.ForeColor = Color.White;
            idEscolaLabel.Location = new Point(40, 71);
            idEscolaLabel.Name = "idEscolaLabel";
            idEscolaLabel.Size = new Size(105, 21);
            idEscolaLabel.TabIndex = 4;
            idEscolaLabel.Text = "Id  Escola . . . .:";
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            idEmpresaLabel.ForeColor = Color.White;
            idEmpresaLabel.Location = new Point(40, 95);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new Size(115, 21);
            idEmpresaLabel.TabIndex = 5;
            idEmpresaLabel.Text = "Id Empresa . . . :";
            // 
            // textBoxObjeto
            // 
            textBoxObjeto.BackColor = Color.Black;
            textBoxObjeto.BorderStyle = BorderStyle.None;
            textBoxObjeto.ForeColor = Color.Yellow;
            textBoxObjeto.Location = new Point(144, 29);
            textBoxObjeto.Name = "textBoxObjeto";
            textBoxObjeto.Size = new Size(149, 16);
            textBoxObjeto.TabIndex = 6;
            // 
            // textBoxValor
            // 
            textBoxValor.BackColor = Color.Black;
            textBoxValor.BorderStyle = BorderStyle.None;
            textBoxValor.ForeColor = Color.Yellow;
            textBoxValor.Location = new Point(144, 51);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(149, 16);
            textBoxValor.TabIndex = 7;
            textBoxValor.KeyPress += somenteValoresReais_KeyPress;
            // 
            // dateTimePickerDataInicio
            // 
            dateTimePickerDataInicio.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicio.CalendarForeColor = Color.White;
            dateTimePickerDataInicio.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataInicio.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataInicio.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataInicio.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataInicio.Enabled = false;
            dateTimePickerDataInicio.Format = DateTimePickerFormat.Short;
            dateTimePickerDataInicio.Location = new Point(144, 138);
            dateTimePickerDataInicio.Name = "dateTimePickerDataInicio";
            dateTimePickerDataInicio.Size = new Size(149, 23);
            dateTimePickerDataInicio.TabIndex = 8;
            // 
            // textBoxIdEmpresa
            // 
            textBoxIdEmpresa.BackColor = Color.Black;
            textBoxIdEmpresa.BorderStyle = BorderStyle.None;
            textBoxIdEmpresa.ForeColor = Color.Yellow;
            textBoxIdEmpresa.Location = new Point(144, 98);
            textBoxIdEmpresa.Name = "textBoxIdEmpresa";
            textBoxIdEmpresa.Size = new Size(149, 16);
            textBoxIdEmpresa.TabIndex = 10;
            textBoxIdEmpresa.KeyPress += somenteValoresNaturais_KeyPress;
            // 
            // textBoxIdEscola
            // 
            textBoxIdEscola.BackColor = Color.Black;
            textBoxIdEscola.BorderStyle = BorderStyle.None;
            textBoxIdEscola.ForeColor = Color.Yellow;
            textBoxIdEscola.Location = new Point(144, 76);
            textBoxIdEscola.Name = "textBoxIdEscola";
            textBoxIdEscola.Size = new Size(149, 16);
            textBoxIdEscola.TabIndex = 9;
            textBoxIdEscola.KeyPress += somenteValoresNaturais_KeyPress;
            // 
            // dateTimePickerDataTermino
            // 
            dateTimePickerDataTermino.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataTermino.CalendarForeColor = Color.White;
            dateTimePickerDataTermino.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataTermino.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataTermino.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataTermino.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataTermino.Format = DateTimePickerFormat.Short;
            dateTimePickerDataTermino.Location = new Point(144, 178);
            dateTimePickerDataTermino.Name = "dateTimePickerDataTermino";
            dateTimePickerDataTermino.Size = new Size(149, 23);
            dateTimePickerDataTermino.TabIndex = 11;
            // 
            // botaoFechar
            // 
            botaoFechar.FlatAppearance.BorderSize = 0;
            botaoFechar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFechar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFechar.FlatStyle = FlatStyle.Flat;
            botaoFechar.ForeColor = Color.White;
            botaoFechar.Location = new Point(206, 221);
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
            botaoFiltrar.Location = new Point(351, 221);
            botaoFiltrar.Name = "botaoFiltrar";
            botaoFiltrar.Size = new Size(67, 40);
            botaoFiltrar.TabIndex = 15;
            botaoFiltrar.Text = "Filtrar";
            botaoFiltrar.UseVisualStyleBackColor = true;
            botaoFiltrar.Click += botaoFiltrar_Click;
            // 
            // checkBoxMaiorValor
            // 
            checkBoxMaiorValor.AutoSize = true;
            checkBoxMaiorValor.FlatAppearance.BorderSize = 0;
            checkBoxMaiorValor.ForeColor = Color.White;
            checkBoxMaiorValor.Location = new Point(299, 49);
            checkBoxMaiorValor.Name = "checkBoxMaiorValor";
            checkBoxMaiorValor.Size = new Size(15, 14);
            checkBoxMaiorValor.TabIndex = 16;
            checkBoxMaiorValor.UseVisualStyleBackColor = true;
            checkBoxMaiorValor.CheckedChanged += checkBoxMaiorValor_CheckedChanged;
            // 
            // checkBoxMenorValor
            // 
            checkBoxMenorValor.AutoSize = true;
            checkBoxMenorValor.FlatAppearance.BorderSize = 0;
            checkBoxMenorValor.ForeColor = SystemColors.Window;
            checkBoxMenorValor.Location = new Point(359, 49);
            checkBoxMenorValor.Name = "checkBoxMenorValor";
            checkBoxMenorValor.Size = new Size(15, 14);
            checkBoxMenorValor.TabIndex = 17;
            checkBoxMenorValor.UseVisualStyleBackColor = true;
            checkBoxMenorValor.CheckedChanged += checkBoxMenorValor_CheckedChanged;
            // 
            // checkBoxMaiorDataInicio
            // 
            checkBoxMaiorDataInicio.AutoSize = true;
            checkBoxMaiorDataInicio.FlatAppearance.BorderSize = 0;
            checkBoxMaiorDataInicio.ForeColor = Color.White;
            checkBoxMaiorDataInicio.Location = new Point(299, 142);
            checkBoxMaiorDataInicio.Name = "checkBoxMaiorDataInicio";
            checkBoxMaiorDataInicio.Size = new Size(15, 14);
            checkBoxMaiorDataInicio.TabIndex = 18;
            checkBoxMaiorDataInicio.UseVisualStyleBackColor = true;
            checkBoxMaiorDataInicio.CheckedChanged += checkBoxMaiorDataInicio_CheckedChanged;
            // 
            // checkBoxMenorDataInicio
            // 
            checkBoxMenorDataInicio.AutoSize = true;
            checkBoxMenorDataInicio.FlatAppearance.BorderSize = 0;
            checkBoxMenorDataInicio.ForeColor = Color.White;
            checkBoxMenorDataInicio.Location = new Point(359, 142);
            checkBoxMenorDataInicio.Name = "checkBoxMenorDataInicio";
            checkBoxMenorDataInicio.Size = new Size(15, 14);
            checkBoxMenorDataInicio.TabIndex = 19;
            checkBoxMenorDataInicio.UseVisualStyleBackColor = true;
            checkBoxMenorDataInicio.CheckedChanged += checkBoxMenorDataInicio_CheckedChanged;
            // 
            // checkBoxMaiorDataTermino
            // 
            checkBoxMaiorDataTermino.AutoSize = true;
            checkBoxMaiorDataTermino.FlatAppearance.BorderSize = 0;
            checkBoxMaiorDataTermino.ForeColor = Color.White;
            checkBoxMaiorDataTermino.Location = new Point(299, 185);
            checkBoxMaiorDataTermino.Name = "checkBoxMaiorDataTermino";
            checkBoxMaiorDataTermino.Size = new Size(15, 14);
            checkBoxMaiorDataTermino.TabIndex = 20;
            checkBoxMaiorDataTermino.UseVisualStyleBackColor = true;
            checkBoxMaiorDataTermino.CheckedChanged += checkBoxMaiorDataTermino_CheckedChanged;
            // 
            // checkBoxMenorDataTermino
            // 
            checkBoxMenorDataTermino.AutoSize = true;
            checkBoxMenorDataTermino.FlatAppearance.BorderSize = 0;
            checkBoxMenorDataTermino.ForeColor = Color.White;
            checkBoxMenorDataTermino.Location = new Point(359, 185);
            checkBoxMenorDataTermino.Name = "checkBoxMenorDataTermino";
            checkBoxMenorDataTermino.Size = new Size(15, 14);
            checkBoxMenorDataTermino.TabIndex = 21;
            checkBoxMenorDataTermino.UseVisualStyleBackColor = true;
            checkBoxMenorDataTermino.CheckedChanged += checkBoxMenorDataTermino_CheckedChanged;
            // 
            // botaoLimpar
            // 
            botaoLimpar.FlatAppearance.BorderSize = 0;
            botaoLimpar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoLimpar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoLimpar.FlatStyle = FlatStyle.Flat;
            botaoLimpar.ForeColor = Color.White;
            botaoLimpar.Location = new Point(279, 221);
            botaoLimpar.Name = "botaoLimpar";
            botaoLimpar.Size = new Size(67, 40);
            botaoLimpar.TabIndex = 22;
            botaoLimpar.Text = "Limpar";
            botaoLimpar.UseVisualStyleBackColor = true;
            botaoLimpar.Click += botaoLimpar_Click;
            // 
            // labelMaior
            // 
            labelMaior.AutoSize = true;
            labelMaior.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMaior.ForeColor = Color.White;
            labelMaior.Location = new Point(294, 5);
            labelMaior.Name = "labelMaior";
            labelMaior.Size = new Size(51, 21);
            labelMaior.TabIndex = 23;
            labelMaior.Text = "Maior";
            // 
            // labelMenor
            // 
            labelMenor.AutoSize = true;
            labelMenor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMenor.ForeColor = Color.White;
            labelMenor.Location = new Point(351, 5);
            labelMenor.Name = "labelMenor";
            labelMenor.Size = new Size(56, 21);
            labelMenor.TabIndex = 24;
            labelMenor.Text = "Menor";
            // 
            // checkBoxHabilitadoDataTermino
            // 
            checkBoxHabilitadoDataTermino.AutoSize = true;
            checkBoxHabilitadoDataTermino.Location = new Point(19, 180);
            checkBoxHabilitadoDataTermino.Name = "checkBoxHabilitadoDataTermino";
            checkBoxHabilitadoDataTermino.Size = new Size(15, 14);
            checkBoxHabilitadoDataTermino.TabIndex = 25;
            checkBoxHabilitadoDataTermino.UseVisualStyleBackColor = true;
            // 
            // checkBoxHabilitadoDataInicio
            // 
            checkBoxHabilitadoDataInicio.AutoSize = true;
            checkBoxHabilitadoDataInicio.Location = new Point(19, 138);
            checkBoxHabilitadoDataInicio.Name = "checkBoxHabilitadoDataInicio";
            checkBoxHabilitadoDataInicio.Size = new Size(15, 14);
            checkBoxHabilitadoDataInicio.TabIndex = 26;
            checkBoxHabilitadoDataInicio.UseVisualStyleBackColor = true;
            // 
            // FiltroConvenioUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            Controls.Add(checkBoxHabilitadoDataInicio);
            Controls.Add(checkBoxHabilitadoDataTermino);
            Controls.Add(labelMenor);
            Controls.Add(labelMaior);
            Controls.Add(botaoLimpar);
            Controls.Add(checkBoxMenorDataTermino);
            Controls.Add(checkBoxMaiorDataTermino);
            Controls.Add(checkBoxMenorDataInicio);
            Controls.Add(checkBoxMaiorDataInicio);
            Controls.Add(checkBoxMenorValor);
            Controls.Add(checkBoxMaiorValor);
            Controls.Add(botaoFiltrar);
            Controls.Add(botaoFechar);
            Controls.Add(dateTimePickerDataTermino);
            Controls.Add(textBoxIdEmpresa);
            Controls.Add(textBoxIdEscola);
            Controls.Add(dateTimePickerDataInicio);
            Controls.Add(textBoxValor);
            Controls.Add(textBoxObjeto);
            Controls.Add(idEmpresaLabel);
            Controls.Add(idEscolaLabel);
            Controls.Add(dataTerminoLabel);
            Controls.Add(dataInicioLabel);
            Controls.Add(valorLabel);
            Controls.Add(objetoLabel);
            Name = "FiltroConvenioUserControl";
            Size = new Size(420, 264);
            Load += FiltroConvenioUserControl_Load;
            Paint += FiltroConvenioUserControl_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label objetoLabel;
        private Label valorLabel;
        private Label dataInicioLabel;
        private Label dataTerminoLabel;
        private Label idEscolaLabel;
        private Label idEmpresaLabel;
        private TextBox textBoxObjeto;
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
        private Label labelMaior;
        private Label labelMenor;
        private CheckBox checkBoxHabilitadoDataTermino;
        private CheckBox checkBoxHabilitadoDataInicio;
    }
}
