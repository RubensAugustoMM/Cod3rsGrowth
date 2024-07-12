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
            textBoxIdEscola = new TextBox();
            textBoxIdEmpresa = new TextBox();
            dateTimePickerDataTermino = new DateTimePicker();
            botaoFechar = new Button();
            botaoFiltrar = new Button();
            botaoLimpar = new Button();
            panelBotaoFiltrar = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            labelTitulo = new Label();
            panelFiltro = new Panel();
            labelRazaoSocialEmpresa = new Label();
            textBoxRazaoSocialEmpresa = new TextBox();
            labelNomeEscola = new Label();
            textBoxNomeEscola = new TextBox();
            comboMaiorMenorIgualDataTermino = new ComboBox();
            comboMaiorMenorIgualDataInicio = new ComboBox();
            comboMaiorMenorIgualValor = new ComboBox();
            panelBotaoFiltrar.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelFiltro.SuspendLayout();
            SuspendLayout();
            // 
            // objetoLabel
            // 
            objetoLabel.AutoSize = true;
            objetoLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            objetoLabel.ForeColor = Color.White;
            objetoLabel.Location = new Point(18, 29);
            objetoLabel.Name = "objetoLabel";
            objetoLabel.Size = new Size(170, 17);
            objetoLabel.TabIndex = 0;
            objetoLabel.Text = "Objeto . . . . . . . . . . . . . . :";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            valorLabel.ForeColor = Color.White;
            valorLabel.Location = new Point(18, 51);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new Size(169, 17);
            valorLabel.TabIndex = 1;
            valorLabel.Text = "Valor . . . . . . . . . . . . . . . :";
            // 
            // dataInicioLabel
            // 
            dataInicioLabel.AutoSize = true;
            dataInicioLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataInicioLabel.ForeColor = Color.White;
            dataInicioLabel.Location = new Point(18, 188);
            dataInicioLabel.Name = "dataInicioLabel";
            dataInicioLabel.Size = new Size(98, 17);
            dataInicioLabel.TabIndex = 2;
            dataInicioLabel.Text = "Data Inicio . . :";
            // 
            // dataTerminoLabel
            // 
            dataTerminoLabel.AutoSize = true;
            dataTerminoLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataTerminoLabel.ForeColor = Color.White;
            dataTerminoLabel.Location = new Point(18, 219);
            dataTerminoLabel.Name = "dataTerminoLabel";
            dataTerminoLabel.Size = new Size(110, 17);
            dataTerminoLabel.TabIndex = 3;
            dataTerminoLabel.Text = "Data Termino . :";
            // 
            // idEscolaLabel
            // 
            idEscolaLabel.AutoSize = true;
            idEscolaLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            idEscolaLabel.ForeColor = Color.White;
            idEscolaLabel.Location = new Point(18, 73);
            idEscolaLabel.Name = "idEscolaLabel";
            idEscolaLabel.Size = new Size(161, 17);
            idEscolaLabel.TabIndex = 4;
            idEscolaLabel.Text = "Id  Escola . . . . . . . . . . .:";
            // 
            // idEmpresaLabel
            // 
            idEmpresaLabel.AutoSize = true;
            idEmpresaLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            idEmpresaLabel.ForeColor = Color.White;
            idEmpresaLabel.Location = new Point(18, 120);
            idEmpresaLabel.Name = "idEmpresaLabel";
            idEmpresaLabel.Size = new Size(167, 17);
            idEmpresaLabel.TabIndex = 5;
            idEmpresaLabel.Text = "Id Empresa . . . . . . . . . . :";
            // 
            // textBoxObjeto
            // 
            textBoxObjeto.BackColor = Color.Black;
            textBoxObjeto.BorderStyle = BorderStyle.None;
            textBoxObjeto.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxObjeto.ForeColor = Color.White;
            textBoxObjeto.Location = new Point(204, 32);
            textBoxObjeto.Name = "textBoxObjeto";
            textBoxObjeto.Size = new Size(149, 16);
            textBoxObjeto.TabIndex = 6;
            // 
            // textBoxValor
            // 
            textBoxValor.BackColor = Color.Black;
            textBoxValor.BorderStyle = BorderStyle.None;
            textBoxValor.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxValor.ForeColor = Color.White;
            textBoxValor.Location = new Point(204, 54);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(149, 16);
            textBoxValor.TabIndex = 7;
            textBoxValor.KeyPress += AoPressionarTecla_TextBox_somenteValoresReais;
            // 
            // dateTimePickerDataInicio
            // 
            dateTimePickerDataInicio.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicio.CalendarForeColor = SystemColors.Window;
            dateTimePickerDataInicio.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataInicio.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataInicio.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataInicio.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataInicio.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataInicio.Format = DateTimePickerFormat.Short;
            dateTimePickerDataInicio.Location = new Point(151, 186);
            dateTimePickerDataInicio.Name = "dateTimePickerDataInicio";
            dateTimePickerDataInicio.Size = new Size(149, 22);
            dateTimePickerDataInicio.TabIndex = 8;
            dateTimePickerDataInicio.ValueChanged += AoAlterarValor_dateTimePickerDataInicio;
            // 
            // textBoxIdEscola
            // 
            textBoxIdEscola.BackColor = Color.Black;
            textBoxIdEscola.BorderStyle = BorderStyle.None;
            textBoxIdEscola.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxIdEscola.ForeColor = Color.White;
            textBoxIdEscola.Location = new Point(204, 76);
            textBoxIdEscola.Name = "textBoxIdEscola";
            textBoxIdEscola.Size = new Size(149, 16);
            textBoxIdEscola.TabIndex = 9;
            textBoxIdEscola.KeyPress += AoPressionarTecla_TextBox_somenteValoresNaturais;
            // 
            // textBoxIdEmpresa
            // 
            textBoxIdEmpresa.BackColor = Color.Black;
            textBoxIdEmpresa.BorderStyle = BorderStyle.None;
            textBoxIdEmpresa.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxIdEmpresa.ForeColor = Color.White;
            textBoxIdEmpresa.Location = new Point(204, 120);
            textBoxIdEmpresa.Name = "textBoxIdEmpresa";
            textBoxIdEmpresa.Size = new Size(149, 16);
            textBoxIdEmpresa.TabIndex = 10;
            textBoxIdEmpresa.KeyPress += AoPressionarTecla_TextBox_somenteValoresNaturais;
            // 
            // dateTimePickerDataTermino
            // 
            dateTimePickerDataTermino.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataTermino.CalendarForeColor = Color.White;
            dateTimePickerDataTermino.CalendarMonthBackground = Color.Silver;
            dateTimePickerDataTermino.CalendarTitleBackColor = Color.Yellow;
            dateTimePickerDataTermino.CalendarTitleForeColor = Color.Gray;
            dateTimePickerDataTermino.CalendarTrailingForeColor = Color.Silver;
            dateTimePickerDataTermino.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataTermino.Format = DateTimePickerFormat.Short;
            dateTimePickerDataTermino.Location = new Point(151, 214);
            dateTimePickerDataTermino.Name = "dateTimePickerDataTermino";
            dateTimePickerDataTermino.Size = new Size(149, 22);
            dateTimePickerDataTermino.TabIndex = 11;
            dateTimePickerDataTermino.ValueChanged += AoAlterarValor_dateTimePickerDataTermino;
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
            botaoFechar.Click += AoCLicar_botaoFechar;
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
            botaoFiltrar.Click += AoClicar_botaoFiltrar;
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
            botaoLimpar.Click += AoClicar_botaoLimpar;
            // 
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.BackColor = Color.Transparent;
            panelBotaoFiltrar.Controls.Add(botaoFiltrar);
            panelBotaoFiltrar.Location = new Point(377, 251);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(106, 40);
            panelBotaoFiltrar.TabIndex = 31;
            panelBotaoFiltrar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(botaoLimpar);
            panel1.Location = new Point(265, 251);
            panel1.Name = "panel1";
            panel1.Size = new Size(106, 40);
            panel1.TabIndex = 32;
            panel1.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(botaoFechar);
            panel2.Location = new Point(151, 251);
            panel2.Name = "panel2";
            panel2.Size = new Size(106, 40);
            panel2.TabIndex = 33;
            panel2.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(178, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(109, 17);
            labelTitulo.TabIndex = 34;
            labelTitulo.Text = "Filtros Convênio";
            // 
            // panelFiltro
            // 
            panelFiltro.BackColor = Color.DarkGray;
            panelFiltro.Controls.Add(labelRazaoSocialEmpresa);
            panelFiltro.Controls.Add(textBoxRazaoSocialEmpresa);
            panelFiltro.Controls.Add(labelNomeEscola);
            panelFiltro.Controls.Add(textBoxNomeEscola);
            panelFiltro.Controls.Add(comboMaiorMenorIgualDataTermino);
            panelFiltro.Controls.Add(comboMaiorMenorIgualDataInicio);
            panelFiltro.Controls.Add(comboMaiorMenorIgualValor);
            panelFiltro.Controls.Add(objetoLabel);
            panelFiltro.Controls.Add(labelTitulo);
            panelFiltro.Controls.Add(valorLabel);
            panelFiltro.Controls.Add(panel2);
            panelFiltro.Controls.Add(dataInicioLabel);
            panelFiltro.Controls.Add(panel1);
            panelFiltro.Controls.Add(dataTerminoLabel);
            panelFiltro.Controls.Add(panelBotaoFiltrar);
            panelFiltro.Controls.Add(idEscolaLabel);
            panelFiltro.Controls.Add(idEmpresaLabel);
            panelFiltro.Controls.Add(textBoxObjeto);
            panelFiltro.Controls.Add(textBoxValor);
            panelFiltro.Controls.Add(dateTimePickerDataTermino);
            panelFiltro.Controls.Add(dateTimePickerDataInicio);
            panelFiltro.Controls.Add(textBoxIdEmpresa);
            panelFiltro.Controls.Add(textBoxIdEscola);
            panelFiltro.Location = new Point(0, 0);
            panelFiltro.Name = "panelFiltro";
            panelFiltro.Size = new Size(502, 291);
            panelFiltro.TabIndex = 35;
            panelFiltro.Paint += AoRequererPintura_panelFiltro;
            // 
            // labelRazaoSocialEmpresa
            // 
            labelRazaoSocialEmpresa.AutoSize = true;
            labelRazaoSocialEmpresa.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelRazaoSocialEmpresa.ForeColor = Color.White;
            labelRazaoSocialEmpresa.Location = new Point(18, 142);
            labelRazaoSocialEmpresa.Name = "labelRazaoSocialEmpresa";
            labelRazaoSocialEmpresa.Size = new Size(155, 17);
            labelRazaoSocialEmpresa.TabIndex = 47;
            labelRazaoSocialEmpresa.Text = "Razão Social Empresa:";
            // 
            // textBoxRazaoSocialEmpresa
            // 
            textBoxRazaoSocialEmpresa.BackColor = Color.Black;
            textBoxRazaoSocialEmpresa.BorderStyle = BorderStyle.None;
            textBoxRazaoSocialEmpresa.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxRazaoSocialEmpresa.ForeColor = Color.White;
            textBoxRazaoSocialEmpresa.Location = new Point(204, 142);
            textBoxRazaoSocialEmpresa.Name = "textBoxRazaoSocialEmpresa";
            textBoxRazaoSocialEmpresa.Size = new Size(149, 16);
            textBoxRazaoSocialEmpresa.TabIndex = 48;
            // 
            // labelNomeEscola
            // 
            labelNomeEscola.AutoSize = true;
            labelNomeEscola.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelNomeEscola.ForeColor = Color.White;
            labelNomeEscola.Location = new Point(18, 96);
            labelNomeEscola.Name = "labelNomeEscola";
            labelNomeEscola.Size = new Size(171, 17);
            labelNomeEscola.TabIndex = 45;
            labelNomeEscola.Text = "Nome Escola . . . . . . . . . :";
            // 
            // textBoxNomeEscola
            // 
            textBoxNomeEscola.BackColor = Color.Black;
            textBoxNomeEscola.BorderStyle = BorderStyle.None;
            textBoxNomeEscola.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNomeEscola.ForeColor = Color.White;
            textBoxNomeEscola.Location = new Point(204, 98);
            textBoxNomeEscola.Name = "textBoxNomeEscola";
            textBoxNomeEscola.Size = new Size(149, 16);
            textBoxNomeEscola.TabIndex = 46;
            // 
            // comboMaiorMenorIgualDataTermino
            // 
            comboMaiorMenorIgualDataTermino.BackColor = Color.Black;
            comboMaiorMenorIgualDataTermino.FlatStyle = FlatStyle.Flat;
            comboMaiorMenorIgualDataTermino.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboMaiorMenorIgualDataTermino.ForeColor = Color.White;
            comboMaiorMenorIgualDataTermino.FormattingEnabled = true;
            comboMaiorMenorIgualDataTermino.Location = new Point(303, 214);
            comboMaiorMenorIgualDataTermino.Name = "comboMaiorMenorIgualDataTermino";
            comboMaiorMenorIgualDataTermino.Size = new Size(125, 23);
            comboMaiorMenorIgualDataTermino.TabIndex = 44;
            // 
            // comboMaiorMenorIgualDataInicio
            // 
            comboMaiorMenorIgualDataInicio.BackColor = Color.Black;
            comboMaiorMenorIgualDataInicio.FlatStyle = FlatStyle.Flat;
            comboMaiorMenorIgualDataInicio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboMaiorMenorIgualDataInicio.ForeColor = Color.White;
            comboMaiorMenorIgualDataInicio.FormattingEnabled = true;
            comboMaiorMenorIgualDataInicio.Location = new Point(303, 185);
            comboMaiorMenorIgualDataInicio.Name = "comboMaiorMenorIgualDataInicio";
            comboMaiorMenorIgualDataInicio.Size = new Size(125, 23);
            comboMaiorMenorIgualDataInicio.TabIndex = 43;
            // 
            // comboMaiorMenorIgualValor
            // 
            comboMaiorMenorIgualValor.BackColor = Color.Black;
            comboMaiorMenorIgualValor.FlatStyle = FlatStyle.Flat;
            comboMaiorMenorIgualValor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboMaiorMenorIgualValor.ForeColor = Color.White;
            comboMaiorMenorIgualValor.FormattingEnabled = true;
            comboMaiorMenorIgualValor.Location = new Point(356, 51);
            comboMaiorMenorIgualValor.Name = "comboMaiorMenorIgualValor";
            comboMaiorMenorIgualValor.Size = new Size(125, 23);
            comboMaiorMenorIgualValor.TabIndex = 42;
            // 
            // FiltroConvenioUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panelFiltro);
            Name = "FiltroConvenioUserControl";
            Size = new Size(512, 310);
            Load += FiltroConvenioUserControl_Load;
            Paint += AoRequererPintura_FiltroConvenioUserControl1;
            panelBotaoFiltrar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelFiltro.ResumeLayout(false);
            panelFiltro.PerformLayout();
            ResumeLayout(false);
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
        private TextBox textBoxIdEscola;
        private TextBox textBoxIdEmpresa;
        private DateTimePicker dateTimePickerDataTermino;
        private Button botaoFechar;
        private Button botaoFiltrar;
        private Button botaoLimpar;
        private Panel panelBotaoFiltrar;
        private Panel panel1;
        private Panel panel2;
        private Label labelTitulo;
        private Panel panelFiltro;
        private ComboBox comboMaiorMenorIgualValor;
        private ComboBox comboMaiorMenorIgualDataTermino;
        private ComboBox comboMaiorMenorIgualDataInicio;
        private Label labelNomeEscola;
        private TextBox textBoxNomeEscola;
        private Label labelRazaoSocialEmpresa;
        private TextBox textBoxRazaoSocialEmpresa;
    }
}
