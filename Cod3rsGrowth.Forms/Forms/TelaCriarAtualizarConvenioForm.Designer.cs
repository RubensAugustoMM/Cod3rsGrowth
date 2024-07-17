namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaCriarAtualizarConvenioForm
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
            LabelEstado = new Label();
            labelMunicipio = new Label();
            labelRua = new Label();
            panelCriacao = new Panel();
            dateTimePickerDataTermino = new DateTimePicker();
            richTextBoxObjeto = new RichTextBox();
            textBoxValor = new TextBox();
            panelDataGrid = new Panel();
            listBoxEscolaEmpresa = new ListBox();
            textBoxEmpresaSelecionada = new TextBox();
            textBoxEscolaSelecionada = new TextBox();
            panelBotaoEmpresas = new Panel();
            botaoEmpresa = new Button();
            label3 = new Label();
            panelBotaoEscolas = new Panel();
            botaoEscola = new Button();
            label2 = new Label();
            panelBotaoCancelar.SuspendLayout();
            panelBotaoSalvar.SuspendLayout();
            panelCriacao.SuspendLayout();
            panelDataGrid.SuspendLayout();
            panelBotaoEmpresas.SuspendLayout();
            panelBotaoEscolas.SuspendLayout();
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
            panelBotaoCancelar.Paint += AoPintarPainelBotoes;
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
            botaoCancelar.Click += AoClicarEmCancelar;
            // 
            // panelBotaoSalvar
            // 
            panelBotaoSalvar.BackColor = Color.Transparent;
            panelBotaoSalvar.Controls.Add(botaoSalvar);
            panelBotaoSalvar.Location = new Point(199, 340);
            panelBotaoSalvar.Name = "panelBotaoSalvar";
            panelBotaoSalvar.Size = new Size(106, 40);
            panelBotaoSalvar.TabIndex = 60;
            panelBotaoSalvar.Paint += AoPintarPainelBotoes;
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
            botaoSalvar.Click += AoClicarEmSalvar;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(97, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(116, 19);
            labelTitulo.TabIndex = 74;
            labelTitulo.Text = "Criação Convênio";
            // 
            // LabelEstado
            // 
            LabelEstado.AutoSize = true;
            LabelEstado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelEstado.ForeColor = Color.White;
            LabelEstado.Location = new Point(13, 30);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(123, 21);
            LabelEstado.TabIndex = 66;
            LabelEstado.Text = "Valor . . . . . . . . . . :";
            // 
            // labelMunicipio
            // 
            labelMunicipio.AutoSize = true;
            labelMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMunicipio.ForeColor = Color.White;
            labelMunicipio.Location = new Point(13, 85);
            labelMunicipio.Name = "labelMunicipio";
            labelMunicipio.Size = new Size(140, 21);
            labelMunicipio.TabIndex = 68;
            labelMunicipio.Text = "Data Término . . . . .:";
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
            panelCriacao.Controls.Add(labelMunicipio);
            panelCriacao.Controls.Add(labelRua);
            panelCriacao.Controls.Add(labelTitulo);
            panelCriacao.Controls.Add(LabelEstado);
            panelCriacao.Location = new Point(-1, 1);
            panelCriacao.Name = "panelCriacao";
            panelCriacao.Size = new Size(661, 380);
            panelCriacao.TabIndex = 79;
            panelCriacao.Paint += AoPintarTela;
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
            dateTimePickerDataTermino.Location = new Point(156, 84);
            dateTimePickerDataTermino.Name = "dateTimePickerDataTermino";
            dateTimePickerDataTermino.Size = new Size(149, 22);
            dateTimePickerDataTermino.TabIndex = 99;
            dateTimePickerDataTermino.ValueChanged += AoAlterarValorDateTimePickerDataTermino;
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
            textBoxValor.Location = new Point(156, 30);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.ShortcutsEnabled = false;
            textBoxValor.Size = new Size(149, 16);
            textBoxValor.TabIndex = 83;
            textBoxValor.KeyPress += AoPressionarTeclaEmCaixaTextoValor;
            // 
            // panelDataGrid
            // 
            panelDataGrid.BackColor = Color.Silver;
            panelDataGrid.Controls.Add(listBoxEscolaEmpresa);
            panelDataGrid.Controls.Add(textBoxEmpresaSelecionada);
            panelDataGrid.Controls.Add(textBoxEscolaSelecionada);
            panelDataGrid.Controls.Add(panelBotaoEmpresas);
            panelDataGrid.Controls.Add(label3);
            panelDataGrid.Controls.Add(panelBotaoEscolas);
            panelDataGrid.Controls.Add(label2);
            panelDataGrid.Dock = DockStyle.Right;
            panelDataGrid.Location = new Point(311, 0);
            panelDataGrid.Name = "panelDataGrid";
            panelDataGrid.Size = new Size(350, 380);
            panelDataGrid.TabIndex = 82;
            panelDataGrid.Paint += AoPintarPainelEscolas;
            // 
            // listBoxEscolaEmpresa
            // 
            listBoxEscolaEmpresa.BackColor = Color.Blue;
            listBoxEscolaEmpresa.BorderStyle = BorderStyle.None;
            listBoxEscolaEmpresa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxEscolaEmpresa.ForeColor = Color.White;
            listBoxEscolaEmpresa.FormattingEnabled = true;
            listBoxEscolaEmpresa.HorizontalScrollbar = true;
            listBoxEscolaEmpresa.ItemHeight = 21;
            listBoxEscolaEmpresa.Location = new Point(22, 58);
            listBoxEscolaEmpresa.Name = "listBoxEscolaEmpresa";
            listBoxEscolaEmpresa.Size = new Size(305, 231);
            listBoxEscolaEmpresa.TabIndex = 105;
            listBoxEscolaEmpresa.SelectedIndexChanged += AoMudarIndexSelecionadoListBoxEscolaEmpresa;
            listBoxEscolaEmpresa.Format += AoFormatarListBoxEscolaEmpresa;
            // 
            // textBoxEmpresaSelecionada
            // 
            textBoxEmpresaSelecionada.BackColor = Color.Black;
            textBoxEmpresaSelecionada.BorderStyle = BorderStyle.None;
            textBoxEmpresaSelecionada.ForeColor = Color.Red;
            textBoxEmpresaSelecionada.Location = new Point(137, 329);
            textBoxEmpresaSelecionada.Name = "textBoxEmpresaSelecionada";
            textBoxEmpresaSelecionada.ReadOnly = true;
            textBoxEmpresaSelecionada.ShortcutsEnabled = false;
            textBoxEmpresaSelecionada.Size = new Size(190, 16);
            textBoxEmpresaSelecionada.TabIndex = 104;
            textBoxEmpresaSelecionada.Text = "Selecionar...";
            // 
            // textBoxEscolaSelecionada
            // 
            textBoxEscolaSelecionada.BackColor = Color.Black;
            textBoxEscolaSelecionada.BorderStyle = BorderStyle.None;
            textBoxEscolaSelecionada.ForeColor = Color.Red;
            textBoxEscolaSelecionada.HideSelection = false;
            textBoxEscolaSelecionada.Location = new Point(137, 307);
            textBoxEscolaSelecionada.Name = "textBoxEscolaSelecionada";
            textBoxEscolaSelecionada.ReadOnly = true;
            textBoxEscolaSelecionada.ShortcutsEnabled = false;
            textBoxEscolaSelecionada.Size = new Size(190, 16);
            textBoxEscolaSelecionada.TabIndex = 103;
            textBoxEscolaSelecionada.Text = "Selecionar...";
            // 
            // panelBotaoEmpresas
            // 
            panelBotaoEmpresas.BackColor = Color.Transparent;
            panelBotaoEmpresas.Controls.Add(botaoEmpresa);
            panelBotaoEmpresas.Location = new Point(134, 11);
            panelBotaoEmpresas.Name = "panelBotaoEmpresas";
            panelBotaoEmpresas.Size = new Size(106, 40);
            panelBotaoEmpresas.TabIndex = 63;
            panelBotaoEmpresas.Paint += AoPintarPainelBotoes;
            // 
            // botaoEmpresa
            // 
            botaoEmpresa.BackColor = Color.Green;
            botaoEmpresa.FlatAppearance.BorderSize = 0;
            botaoEmpresa.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEmpresa.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoEmpresa.FlatStyle = FlatStyle.Flat;
            botaoEmpresa.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEmpresa.ForeColor = Color.White;
            botaoEmpresa.Location = new Point(3, 3);
            botaoEmpresa.Name = "botaoEmpresa";
            botaoEmpresa.Size = new Size(85, 27);
            botaoEmpresa.TabIndex = 22;
            botaoEmpresa.Text = "Empresas";
            botaoEmpresa.UseVisualStyleBackColor = false;
            botaoEmpresa.Click += AoClicarEmEmpresa;
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
            panelBotaoEscolas.Location = new Point(22, 11);
            panelBotaoEscolas.Name = "panelBotaoEscolas";
            panelBotaoEscolas.Size = new Size(106, 40);
            panelBotaoEscolas.TabIndex = 62;
            panelBotaoEscolas.Paint += AoPintarPainelBotoes;
            // 
            // botaoEscola
            // 
            botaoEscola.BackColor = Color.Green;
            botaoEscola.FlatAppearance.BorderSize = 0;
            botaoEscola.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEscola.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoEscola.FlatStyle = FlatStyle.Flat;
            botaoEscola.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEscola.ForeColor = Color.White;
            botaoEscola.Location = new Point(3, 3);
            botaoEscola.Name = "botaoEscola";
            botaoEscola.Size = new Size(85, 27);
            botaoEscola.TabIndex = 22;
            botaoEscola.Text = "Escolas";
            botaoEscola.UseVisualStyleBackColor = false;
            botaoEscola.Click += AoClicarEmEscola;
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
            // TelaCriarConvenioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(671, 399);
            Controls.Add(panelCriacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCriarConvenioForm";
            Text = "TelaCriarEnderecoForm";
            Load += AoCarregarTela;
            panelBotaoCancelar.ResumeLayout(false);
            panelBotaoSalvar.ResumeLayout(false);
            panelCriacao.ResumeLayout(false);
            panelCriacao.PerformLayout();
            panelDataGrid.ResumeLayout(false);
            panelDataGrid.PerformLayout();
            panelBotaoEmpresas.ResumeLayout(false);
            panelBotaoEscolas.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBotaoCancelar;
        private Button botaoCancelar;
        private Panel panelBotaoSalvar;
        private Button botaoSalvar;
        private Label labelTitulo;
        private Label LabelEstado;
        private Label labelMunicipio;
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
        private Label label3;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox3;
        private Panel panelDataGrid;
        private Panel panelBotaoEmpresas;
        private Panel panelBotaoEscolas;
        private TextBox textBoxEmpresaSelecionada;
        private TextBox textBoxEscolaSelecionada;
        private ListBox listBoxEscolaEmpresa;
    }
}