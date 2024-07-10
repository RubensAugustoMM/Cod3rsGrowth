namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaCriarConvenioForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelBotaoCancelar = new Panel();
            botaoCancelar = new Button();
            panelBotaoSalvar = new Panel();
            botaoSalvar = new Button();
            labelTitulo = new Label();
            LabelEstado = new Label();
            textBoxNumeroProcesso = new TextBox();
            labelMunicipio = new Label();
            labelCep = new Label();
            labelRua = new Label();
            panelCriacao = new Panel();
            dateTimePickerDataTermino = new DateTimePicker();
            richTextBoxObjeto = new RichTextBox();
            textBoxValor = new TextBox();
            panelDataGrid = new Panel();
            textBoxEmpresa = new TextBox();
            panelBotaoSelecionar = new Panel();
            botaoSelecionar = new Button();
            textBoxEscola = new TextBox();
            panelBotaoEmpresas = new Panel();
            botaoEmpresa = new Button();
            label3 = new Label();
            panelBotaoEscolas = new Panel();
            botaoEscola = new Button();
            label2 = new Label();
            dataGridViewEscolasEmpresas = new DataGridView();
            panelBotaoCancelar.SuspendLayout();
            panelBotaoSalvar.SuspendLayout();
            panelCriacao.SuspendLayout();
            panelDataGrid.SuspendLayout();
            panelBotaoSelecionar.SuspendLayout();
            panelBotaoEmpresas.SuspendLayout();
            panelBotaoEscolas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEscolasEmpresas).BeginInit();
            SuspendLayout();
            // 
            // panelBotaoCancelar
            // 
            panelBotaoCancelar.BackColor = Color.Transparent;
            panelBotaoCancelar.Controls.Add(botaoCancelar);
            panelBotaoCancelar.Location = new Point(87, 340);
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
            panelBotaoSalvar.Location = new Point(199, 340);
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
            labelTitulo.Location = new Point(97, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(114, 19);
            labelTitulo.TabIndex = 74;
            labelTitulo.Text = "Criação Endereço";
            // 
            // LabelEstado
            // 
            LabelEstado.AutoSize = true;
            LabelEstado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelEstado.ForeColor = Color.White;
            LabelEstado.Location = new Point(13, 56);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(123, 21);
            LabelEstado.TabIndex = 66;
            LabelEstado.Text = "Valor . . . . . . . . . . :";
            // 
            // textBoxNumeroProcesso
            // 
            textBoxNumeroProcesso.BackColor = Color.Cyan;
            textBoxNumeroProcesso.BorderStyle = BorderStyle.None;
            textBoxNumeroProcesso.ForeColor = Color.Black;
            textBoxNumeroProcesso.Location = new Point(156, 31);
            textBoxNumeroProcesso.Name = "textBoxNumeroProcesso";
            textBoxNumeroProcesso.Size = new Size(149, 16);
            textBoxNumeroProcesso.TabIndex = 73;
            textBoxNumeroProcesso.KeyPress += AoPressionarTecla_textBoxNumeroProcesso;
            // 
            // labelMunicipio
            // 
            labelMunicipio.AutoSize = true;
            labelMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMunicipio.ForeColor = Color.White;
            labelMunicipio.Location = new Point(13, 92);
            labelMunicipio.Name = "labelMunicipio";
            labelMunicipio.Size = new Size(140, 21);
            labelMunicipio.TabIndex = 68;
            labelMunicipio.Text = "Data Término . . . . .:";
            // 
            // labelCep
            // 
            labelCep.AutoSize = true;
            labelCep.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCep.ForeColor = Color.White;
            labelCep.Location = new Point(13, 31);
            labelCep.Name = "labelCep";
            labelCep.Size = new Size(137, 21);
            labelCep.TabIndex = 70;
            labelCep.Text = "Numero Processo:";
            // 
            // labelRua
            // 
            labelRua.AutoSize = true;
            labelRua.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRua.ForeColor = Color.White;
            labelRua.Location = new Point(13, 145);
            labelRua.Name = "labelRua";
            labelRua.Size = new Size(64, 21);
            labelRua.TabIndex = 75;
            labelRua.Text = "Objeto :";
            // 
            // panelCriacao
            // 
            panelCriacao.BackColor = Color.BlueViolet;
            panelCriacao.Controls.Add(dateTimePickerDataTermino);
            panelCriacao.Controls.Add(richTextBoxObjeto);
            panelCriacao.Controls.Add(textBoxValor);
            panelCriacao.Controls.Add(panelBotaoSalvar);
            panelCriacao.Controls.Add(panelBotaoCancelar);
            panelCriacao.Controls.Add(panelDataGrid);
            panelCriacao.Controls.Add(labelCep);
            panelCriacao.Controls.Add(labelMunicipio);
            panelCriacao.Controls.Add(labelRua);
            panelCriacao.Controls.Add(labelTitulo);
            panelCriacao.Controls.Add(LabelEstado);
            panelCriacao.Controls.Add(textBoxNumeroProcesso);
            panelCriacao.Location = new Point(-1, 1);
            panelCriacao.Name = "panelCriacao";
            panelCriacao.Size = new Size(661, 380);
            panelCriacao.TabIndex = 79;
            panelCriacao.Paint += AoRequererPintura_PanelCriacao;
            // 
            // dateTimePickerDataTermino
            // 
            dateTimePickerDataTermino.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataTermino.CalendarForeColor = Color.Cyan;
            dateTimePickerDataTermino.CalendarMonthBackground = Color.Cyan;
            dateTimePickerDataTermino.CalendarTitleBackColor = Color.Cyan;
            dateTimePickerDataTermino.CalendarTitleForeColor = Color.Cyan;
            dateTimePickerDataTermino.CalendarTrailingForeColor = Color.Cyan;
            dateTimePickerDataTermino.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDataTermino.Format = DateTimePickerFormat.Short;
            dateTimePickerDataTermino.Location = new Point(156, 91);
            dateTimePickerDataTermino.Name = "dateTimePickerDataTermino";
            dateTimePickerDataTermino.Size = new Size(149, 22);
            dateTimePickerDataTermino.TabIndex = 99;
            dateTimePickerDataTermino.ValueChanged += AoAlterarValor_dateTimePickerDataInicioAtividade;
            // 
            // richTextBoxObjeto
            // 
            richTextBoxObjeto.BackColor = Color.Cyan;
            richTextBoxObjeto.BorderStyle = BorderStyle.None;
            richTextBoxObjeto.ForeColor = Color.Black;
            richTextBoxObjeto.Location = new Point(13, 169);
            richTextBoxObjeto.Name = "richTextBoxObjeto";
            richTextBoxObjeto.Size = new Size(292, 154);
            richTextBoxObjeto.TabIndex = 84;
            richTextBoxObjeto.Text = "";
            // 
            // textBoxValor
            // 
            textBoxValor.BackColor = Color.Cyan;
            textBoxValor.BorderStyle = BorderStyle.None;
            textBoxValor.ForeColor = Color.Black;
            textBoxValor.Location = new Point(156, 56);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(149, 16);
            textBoxValor.TabIndex = 83;
            textBoxValor.KeyPress += AoPressionarTecla_textBoxValor;
            // 
            // panelDataGrid
            // 
            panelDataGrid.BackColor = Color.Silver;
            panelDataGrid.Controls.Add(textBoxEmpresa);
            panelDataGrid.Controls.Add(panelBotaoSelecionar);
            panelDataGrid.Controls.Add(textBoxEscola);
            panelDataGrid.Controls.Add(panelBotaoEmpresas);
            panelDataGrid.Controls.Add(label3);
            panelDataGrid.Controls.Add(panelBotaoEscolas);
            panelDataGrid.Controls.Add(label2);
            panelDataGrid.Controls.Add(dataGridViewEscolasEmpresas);
            panelDataGrid.Dock = DockStyle.Right;
            panelDataGrid.Location = new Point(311, 0);
            panelDataGrid.Name = "panelDataGrid";
            panelDataGrid.Size = new Size(350, 380);
            panelDataGrid.TabIndex = 82;
            panelDataGrid.Paint += AoRequererPintura_panelEscolas;
            // 
            // textBoxEmpresa
            // 
            textBoxEmpresa.BackColor = Color.Black;
            textBoxEmpresa.BorderStyle = BorderStyle.None;
            textBoxEmpresa.ForeColor = Color.Red;
            textBoxEmpresa.Location = new Point(178, 329);
            textBoxEmpresa.Name = "textBoxEmpresa";
            textBoxEmpresa.ReadOnly = true;
            textBoxEmpresa.ShortcutsEnabled = false;
            textBoxEmpresa.Size = new Size(149, 16);
            textBoxEmpresa.TabIndex = 104;
            textBoxEmpresa.Text = "Selecionar...";
            // 
            // panelBotaoSelecionar
            // 
            panelBotaoSelecionar.BackColor = Color.Transparent;
            panelBotaoSelecionar.Controls.Add(botaoSelecionar);
            panelBotaoSelecionar.Location = new Point(221, 12);
            panelBotaoSelecionar.Name = "panelBotaoSelecionar";
            panelBotaoSelecionar.Size = new Size(126, 40);
            panelBotaoSelecionar.TabIndex = 64;
            panelBotaoSelecionar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoSelecionar
            // 
            botaoSelecionar.BackColor = Color.Red;
            botaoSelecionar.FlatAppearance.BorderSize = 0;
            botaoSelecionar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoSelecionar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoSelecionar.FlatStyle = FlatStyle.Flat;
            botaoSelecionar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoSelecionar.ForeColor = Color.White;
            botaoSelecionar.Location = new Point(3, 3);
            botaoSelecionar.Name = "botaoSelecionar";
            botaoSelecionar.Size = new Size(105, 27);
            botaoSelecionar.TabIndex = 22;
            botaoSelecionar.Text = "Selecionar";
            botaoSelecionar.UseVisualStyleBackColor = false;
            botaoSelecionar.Click += AoClicar_botaoSelecionar;
            // 
            // textBoxEscola
            // 
            textBoxEscola.BackColor = Color.Black;
            textBoxEscola.BorderStyle = BorderStyle.None;
            textBoxEscola.ForeColor = Color.Red;
            textBoxEscola.HideSelection = false;
            textBoxEscola.Location = new Point(178, 307);
            textBoxEscola.Name = "textBoxEscola";
            textBoxEscola.ReadOnly = true;
            textBoxEscola.ShortcutsEnabled = false;
            textBoxEscola.Size = new Size(149, 16);
            textBoxEscola.TabIndex = 103;
            textBoxEscola.Text = "Selecionar...";
            // 
            // panelBotaoEmpresas
            // 
            panelBotaoEmpresas.BackColor = Color.Transparent;
            panelBotaoEmpresas.Controls.Add(botaoEmpresa);
            panelBotaoEmpresas.Location = new Point(114, 12);
            panelBotaoEmpresas.Name = "panelBotaoEmpresas";
            panelBotaoEmpresas.Size = new Size(106, 40);
            panelBotaoEmpresas.TabIndex = 63;
            panelBotaoEmpresas.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoEmpresa
            // 
            botaoEmpresa.BackColor = Color.Green;
            botaoEmpresa.FlatAppearance.BorderSize = 0;
            botaoEmpresa.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEmpresa.FlatAppearance.MouseOverBackColor = Color.Cyan;
            botaoEmpresa.FlatStyle = FlatStyle.Flat;
            botaoEmpresa.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEmpresa.ForeColor = Color.White;
            botaoEmpresa.Location = new Point(3, 3);
            botaoEmpresa.Name = "botaoEmpresa";
            botaoEmpresa.Size = new Size(85, 27);
            botaoEmpresa.TabIndex = 22;
            botaoEmpresa.Text = "Empresas";
            botaoEmpresa.UseVisualStyleBackColor = false;
            botaoEmpresa.Click += AoClicar_botaoEmpresa;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 335);
            label3.Name = "label3";
            label3.Size = new Size(112, 21);
            label3.TabIndex = 102;
            label3.Text = "Empresa . . . . . :";
            // 
            // panelBotaoEscolas
            // 
            panelBotaoEscolas.BackColor = Color.Transparent;
            panelBotaoEscolas.Controls.Add(botaoEscola);
            panelBotaoEscolas.Location = new Point(2, 12);
            panelBotaoEscolas.Name = "panelBotaoEscolas";
            panelBotaoEscolas.Size = new Size(106, 40);
            panelBotaoEscolas.TabIndex = 62;
            panelBotaoEscolas.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoEscola
            // 
            botaoEscola.BackColor = Color.Green;
            botaoEscola.FlatAppearance.BorderSize = 0;
            botaoEscola.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEscola.FlatAppearance.MouseOverBackColor = Color.Cyan;
            botaoEscola.FlatStyle = FlatStyle.Flat;
            botaoEscola.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEscola.ForeColor = Color.White;
            botaoEscola.Location = new Point(3, 3);
            botaoEscola.Name = "botaoEscola";
            botaoEscola.Size = new Size(85, 27);
            botaoEscola.TabIndex = 22;
            botaoEscola.Text = "Escolas";
            botaoEscola.UseVisualStyleBackColor = false;
            botaoEscola.Click += AoClicar_botaoEscola;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 314);
            label2.Name = "label2";
            label2.Size = new Size(99, 21);
            label2.TabIndex = 101;
            label2.Text = "Escola  . . . . . :";
            // 
            // dataGridViewEscolasEmpresas
            // 
            dataGridViewEscolasEmpresas.BackgroundColor = Color.Blue;
            dataGridViewEscolasEmpresas.BorderStyle = BorderStyle.None;
            dataGridViewEscolasEmpresas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Blue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewEscolasEmpresas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewEscolasEmpresas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEscolasEmpresas.EnableHeadersVisualStyles = false;
            dataGridViewEscolasEmpresas.GridColor = Color.White;
            dataGridViewEscolasEmpresas.Location = new Point(22, 56);
            dataGridViewEscolasEmpresas.Name = "dataGridViewEscolasEmpresas";
            dataGridViewEscolasEmpresas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewEscolasEmpresas.RowTemplate.Height = 25;
            dataGridViewEscolasEmpresas.Size = new Size(305, 240);
            dataGridViewEscolasEmpresas.TabIndex = 85;
            dataGridViewEscolasEmpresas.CellFormatting += AoFormatarCelula_dataGridViewEscolasEmpresas;
            // 
            // TelaCriarConvenioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(674, 402);
            Controls.Add(panelCriacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCriarConvenioForm";
            Text = "TelaCriarEnderecoForm";
            Load += AoCarregar_TelaCriarConvenioForm;
            panelBotaoCancelar.ResumeLayout(false);
            panelBotaoSalvar.ResumeLayout(false);
            panelCriacao.ResumeLayout(false);
            panelCriacao.PerformLayout();
            panelDataGrid.ResumeLayout(false);
            panelDataGrid.PerformLayout();
            panelBotaoSelecionar.ResumeLayout(false);
            panelBotaoEmpresas.ResumeLayout(false);
            panelBotaoEscolas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEscolasEmpresas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBotaoCancelar;
        private Button botaoCancelar;
        private Panel panelBotaoSalvar;
        private Button botaoSalvar;
        private Label labelTitulo;
        private Label LabelEstado;
        private TextBox textBoxNumeroProcesso;
        private Label labelMunicipio;
        private Label labelCep;
        private Label labelBairro;
        private Label labelRua;
        private Panel panelCriacao;
        private Panel panelEmpresas;
        private Panel panelEscolas;
        private TextBox textBoxValor;
        private DataGridView dataGridViewEmpresas;
        private DataGridView dataGridViewEscolas;
        private RichTextBox richTextBoxObjeto;
        private Label labelEmpresas;
        private Panel panel2;
        private Button botaoEmpresa;
        private Panel panel1;
        private Button botaoEscola;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePickerDataTermino;
        private Panel panel3;
        private Button botaoSelecionar;
        private Label label3;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox3;
        private Panel panelDataGrid;
        private DataGridView dataGridViewEscolasEmpresas;
        private Panel panelBotaoSelecionar;
        private Panel panelBotaoEmpresas;
        private Panel panelBotaoEscolas;
        private TextBox textBoxEmpresa;
        private TextBox textBoxEscola;
    }
}