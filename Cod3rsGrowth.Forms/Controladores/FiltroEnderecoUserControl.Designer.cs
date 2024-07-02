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
            comboBoxEstado = new ComboBox();
            labelMunicipio = new Label();
            labelBairro = new Label();
            labelCep = new Label();
            textBoxMunicipio = new TextBox();
            textBoxBairro = new TextBox();
            textBoxCep = new TextBox();
            panelFiltro = new Panel();
            panel3 = new Panel();
            botaoFechar = new Button();
            panel2 = new Panel();
            botaoLimpar = new Button();
            panelBotaoFiltrar = new Panel();
            botaoFiltrar = new Button();
            labelTitulo = new Label();
            panelFiltro.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panelBotaoFiltrar.SuspendLayout();
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
            // comboBoxEstado
            // 
            comboBoxEstado.BackColor = Color.Black;
            comboBoxEstado.FlatStyle = FlatStyle.Flat;
            comboBoxEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstado.ForeColor = Color.White;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(147, 18);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(149, 23);
            comboBoxEstado.TabIndex = 41;
            comboBoxEstado.Click += comboBoxEstado_Click;
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
            textBoxMunicipio.Location = new Point(147, 46);
            textBoxMunicipio.Name = "textBoxMunicipio";
            textBoxMunicipio.Size = new Size(149, 16);
            textBoxMunicipio.TabIndex = 45;
            // 
            // textBoxBairro
            // 
            textBoxBairro.BackColor = Color.Black;
            textBoxBairro.BorderStyle = BorderStyle.None;
            textBoxBairro.ForeColor = Color.Yellow;
            textBoxBairro.Location = new Point(147, 67);
            textBoxBairro.Name = "textBoxBairro";
            textBoxBairro.Size = new Size(149, 16);
            textBoxBairro.TabIndex = 46;
            // 
            // textBoxCep
            // 
            textBoxCep.BackColor = Color.Black;
            textBoxCep.BorderStyle = BorderStyle.None;
            textBoxCep.ForeColor = Color.Yellow;
            textBoxCep.Location = new Point(147, 89);
            textBoxCep.Name = "textBoxCep";
            textBoxCep.Size = new Size(149, 16);
            textBoxCep.TabIndex = 47;
            // 
            // panelFiltro
            // 
            panelFiltro.BackColor = Color.DarkGray;
            panelFiltro.Controls.Add(labelTitulo);
            panelFiltro.Controls.Add(panel3);
            panelFiltro.Controls.Add(panel2);
            panelFiltro.Controls.Add(panelBotaoFiltrar);
            panelFiltro.Controls.Add(LabelEstado);
            panelFiltro.Controls.Add(textBoxCep);
            panelFiltro.Controls.Add(textBoxBairro);
            panelFiltro.Controls.Add(comboBoxEstado);
            panelFiltro.Controls.Add(textBoxMunicipio);
            panelFiltro.Controls.Add(labelMunicipio);
            panelFiltro.Controls.Add(labelCep);
            panelFiltro.Controls.Add(labelBairro);
            panelFiltro.Location = new Point(0, 0);
            panelFiltro.Margin = new Padding(0);
            panelFiltro.Name = "panelFiltro";
            panelFiltro.Size = new Size(367, 153);
            panelFiltro.TabIndex = 62;
            panelFiltro.Paint += panelFiltro_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(botaoFechar);
            panel3.Location = new Point(20, 113);
            panel3.Name = "panel3";
            panel3.Size = new Size(106, 40);
            panel3.TabIndex = 64;
            panel3.Paint += panelBotaoFiltrar_Paint;
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
            botaoFechar.TextAlign = ContentAlignment.BottomCenter;
            botaoFechar.UseVisualStyleBackColor = false;
            botaoFechar.Click += botaoFechar_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(botaoLimpar);
            panel2.Location = new Point(132, 114);
            panel2.Name = "panel2";
            panel2.Size = new Size(106, 40);
            panel2.TabIndex = 33;
            panel2.Paint += panelBotaoFiltrar_Paint;
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
            botaoLimpar.TextAlign = ContentAlignment.BottomCenter;
            botaoLimpar.UseVisualStyleBackColor = false;
            botaoLimpar.Click += botaoLimpar_Click;
            // 
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.Controls.Add(botaoFiltrar);
            panelBotaoFiltrar.Location = new Point(244, 114);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(106, 40);
            panelBotaoFiltrar.TabIndex = 63;
            panelBotaoFiltrar.Paint += panelBotaoFiltrar_Paint;
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
            botaoFiltrar.TextAlign = ContentAlignment.BottomCenter;
            botaoFiltrar.UseVisualStyleBackColor = false;
            botaoFiltrar.Click += botaoFiltrar_Click;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(132, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(100, 19);
            labelTitulo.TabIndex = 65;
            labelTitulo.Text = "Filtro Endereço";
            // 
            // FiltroEnderecoUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panelFiltro);
            Name = "FiltroEnderecoUserControl";
            Size = new Size(377, 172);
            Load += FiltroConvenioUserControl_Load;
            Paint += FiltroEnderecoUserControl_Paint;
            panelFiltro.ResumeLayout(false);
            panelFiltro.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelBotaoFiltrar.ResumeLayout(false);
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
        private CheckBox checkBoxMaiorValor;
        private CheckBox checkBoxMenorValor;
        private CheckBox checkBoxMaiorDataInicio;
        private CheckBox checkBoxMenorDataInicio;
        private CheckBox checkBoxMaiorDataTermino;
        private CheckBox checkBoxMenorDataTermino;
        private ComboBox comboBoxEstado;
        private Label labelMunicipio;
        private Label labelBairro;
        private Label labelCep;
        private TextBox textBoxMunicipio;
        private TextBox textBoxBairro;
        private TextBox textBoxCep;
        private Label labelMaior;
        private Label labelMenor;
        private Panel panelFiltro;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltrar;
        private Panel panel2;
        private Button botaoLimpar;
        private Panel panel3;
        private Button botaoFechar;
        private Label labelTitulo;
    }
}
