namespace Cod3rsGrowth.Forms.Controladores
{
    partial class FiltroEnderecoUserControl
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
            LabelEstado = new Label();
            botaoFechar = new Button();
            botaoFiltrar = new Button();
            botaoLimpar = new Button();
            comboBoxEstado = new ComboBox();
            labelMunicipio = new Label();
            labelBairro = new Label();
            labelCep = new Label();
            textBoxMunicipio = new TextBox();
            textBoxBairro = new TextBox();
            textBoxCep = new TextBox();
            checkBoxHabilitadoEstado = new CheckBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LabelEstado
            // 
            LabelEstado.AutoSize = true;
            LabelEstado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelEstado.ForeColor = Color.White;
            LabelEstado.Location = new Point(34, 20);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(76, 21);
            LabelEstado.TabIndex = 5;
            LabelEstado.Text = "Estado. . .:";
            // 
            // botaoFechar
            // 
            botaoFechar.FlatAppearance.BorderSize = 0;
            botaoFechar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFechar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFechar.FlatStyle = FlatStyle.Flat;
            botaoFechar.ForeColor = Color.White;
            botaoFechar.Location = new Point(43, 156);
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
            botaoFiltrar.Location = new Point(189, 156);
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
            botaoLimpar.Location = new Point(116, 156);
            botaoLimpar.Name = "botaoLimpar";
            botaoLimpar.Size = new Size(67, 40);
            botaoLimpar.TabIndex = 22;
            botaoLimpar.Text = "Limpar";
            botaoLimpar.UseVisualStyleBackColor = true;
            botaoLimpar.Click += botaoLimpar_Click;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.BackColor = Color.Yellow;
            comboBoxEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(104, 18);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(149, 23);
            comboBoxEstado.TabIndex = 41;
            // 
            // labelMunicipio
            // 
            labelMunicipio.AutoSize = true;
            labelMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMunicipio.ForeColor = Color.White;
            labelMunicipio.Location = new Point(34, 41);
            labelMunicipio.Name = "labelMunicipio";
            labelMunicipio.Size = new Size(82, 21);
            labelMunicipio.TabIndex = 42;
            labelMunicipio.Text = "Município:";
            // 
            // labelBairro
            // 
            labelBairro.AutoSize = true;
            labelBairro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelBairro.ForeColor = Color.White;
            labelBairro.Location = new Point(34, 62);
            labelBairro.Name = "labelBairro";
            labelBairro.Size = new Size(72, 21);
            labelBairro.TabIndex = 43;
            labelBairro.Text = "Bairro. . .:";
            // 
            // labelCep
            // 
            labelCep.AutoSize = true;
            labelCep.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCep.ForeColor = Color.White;
            labelCep.Location = new Point(38, 83);
            labelCep.Name = "labelCep";
            labelCep.Size = new Size(75, 21);
            labelCep.TabIndex = 44;
            labelCep.Text = "CEP. . . . . :";
            // 
            // textBoxMunicipio
            // 
            textBoxMunicipio.BackColor = Color.Black;
            textBoxMunicipio.BorderStyle = BorderStyle.None;
            textBoxMunicipio.ForeColor = Color.Yellow;
            textBoxMunicipio.Location = new Point(104, 46);
            textBoxMunicipio.Name = "textBoxMunicipio";
            textBoxMunicipio.Size = new Size(149, 16);
            textBoxMunicipio.TabIndex = 45;
            // 
            // textBoxBairro
            // 
            textBoxBairro.BackColor = Color.Black;
            textBoxBairro.BorderStyle = BorderStyle.None;
            textBoxBairro.ForeColor = Color.Yellow;
            textBoxBairro.Location = new Point(104, 67);
            textBoxBairro.Name = "textBoxBairro";
            textBoxBairro.Size = new Size(149, 16);
            textBoxBairro.TabIndex = 46;
            // 
            // textBoxCep
            // 
            textBoxCep.BackColor = Color.Black;
            textBoxCep.BorderStyle = BorderStyle.None;
            textBoxCep.ForeColor = Color.Yellow;
            textBoxCep.Location = new Point(104, 89);
            textBoxCep.Name = "textBoxCep";
            textBoxCep.Size = new Size(149, 16);
            textBoxCep.TabIndex = 47;
            // 
            // checkBoxHabilitadoEstado
            // 
            checkBoxHabilitadoEstado.AutoSize = true;
            checkBoxHabilitadoEstado.FlatAppearance.BorderSize = 0;
            checkBoxHabilitadoEstado.ForeColor = Color.White;
            checkBoxHabilitadoEstado.Location = new Point(13, 20);
            checkBoxHabilitadoEstado.Name = "checkBoxHabilitadoEstado";
            checkBoxHabilitadoEstado.Size = new Size(15, 14);
            checkBoxHabilitadoEstado.TabIndex = 61;
            checkBoxHabilitadoEstado.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(LabelEstado);
            panel1.Controls.Add(botaoFiltrar);
            panel1.Controls.Add(checkBoxHabilitadoEstado);
            panel1.Controls.Add(botaoFechar);
            panel1.Controls.Add(textBoxCep);
            panel1.Controls.Add(botaoLimpar);
            panel1.Controls.Add(textBoxBairro);
            panel1.Controls.Add(comboBoxEstado);
            panel1.Controls.Add(textBoxMunicipio);
            panel1.Controls.Add(labelMunicipio);
            panel1.Controls.Add(labelCep);
            panel1.Controls.Add(labelBairro);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 216);
            panel1.TabIndex = 62;
            // 
            // FiltroEnderecoUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel1);
            Name = "FiltroEnderecoUserControl";
            Size = new Size(296, 222);
            Load += FiltroConvenioUserControl_Load;
            Paint += FiltroConvenioUserControl_Paint;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label dataInicioLabel;
        private Label dataTerminoLabel;
        private Label LabelEstado;
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
        private ComboBox comboBoxEstado;
        private Label labelMunicipio;
        private Label labelBairro;
        private Label labelCep;
        private TextBox textBoxMunicipio;
        private TextBox textBoxBairro;
        private TextBox textBoxCep;
        private Label labelMaior;
        private Label labelMenor;
        private CheckBox checkBoxHabilitadoEstado;
        private Panel panel1;
    }
}
