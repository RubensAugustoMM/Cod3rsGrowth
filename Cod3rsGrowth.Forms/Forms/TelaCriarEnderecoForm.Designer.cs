namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaCriarEnderecoForm
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
            textBoxCep = new TextBox();
            textBoxBairro = new TextBox();
            comboBoxEstado = new ComboBox();
            textBoxMunicipio = new TextBox();
            labelMunicipio = new Label();
            labelCep = new Label();
            labelBairro = new Label();
            textBoxRua = new TextBox();
            labelRua = new Label();
            textBoxComplemento = new TextBox();
            label2 = new Label();
            panelCriacao = new Panel();
            panelBotaoCancelar.SuspendLayout();
            panelBotaoSalvar.SuspendLayout();
            panelCriacao.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotaoCancelar
            // 
            panelBotaoCancelar.BackColor = Color.Transparent;
            panelBotaoCancelar.Controls.Add(botaoCancelar);
            panelBotaoCancelar.Location = new Point(64, 202);
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
            panelBotaoSalvar.Location = new Point(176, 202);
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
            labelTitulo.Location = new Point(92, 3);
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
            LabelEstado.Location = new Point(14, 76);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(97, 21);
            LabelEstado.TabIndex = 66;
            LabelEstado.Text = "Estado. . . . . .:";
            // 
            // textBoxCep
            // 
            textBoxCep.BackColor = Color.Cyan;
            textBoxCep.BorderStyle = BorderStyle.None;
            textBoxCep.ForeColor = Color.Black;
            textBoxCep.Location = new Point(133, 46);
            textBoxCep.Name = "textBoxCep";
            textBoxCep.Size = new Size(149, 16);
            textBoxCep.TabIndex = 73;
            textBoxCep.KeyPress += AoPressionarTecla_textBoxCep;
            // 
            // textBoxBairro
            // 
            textBoxBairro.BackColor = Color.Cyan;
            textBoxBairro.BorderStyle = BorderStyle.None;
            textBoxBairro.ForeColor = Color.Black;
            textBoxBairro.Location = new Point(133, 119);
            textBoxBairro.Name = "textBoxBairro";
            textBoxBairro.Size = new Size(149, 16);
            textBoxBairro.TabIndex = 72;
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.BackColor = Color.Cyan;
            comboBoxEstado.FlatStyle = FlatStyle.Flat;
            comboBoxEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstado.ForeColor = Color.Black;
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(133, 68);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(149, 23);
            comboBoxEstado.TabIndex = 67;
            comboBoxEstado.Format += AoFormatar_comboBoxEstado;
            // 
            // textBoxMunicipio
            // 
            textBoxMunicipio.BackColor = Color.Cyan;
            textBoxMunicipio.BorderStyle = BorderStyle.None;
            textBoxMunicipio.ForeColor = Color.Black;
            textBoxMunicipio.Location = new Point(133, 97);
            textBoxMunicipio.Name = "textBoxMunicipio";
            textBoxMunicipio.Size = new Size(149, 16);
            textBoxMunicipio.TabIndex = 71;
            // 
            // labelMunicipio
            // 
            labelMunicipio.AutoSize = true;
            labelMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMunicipio.ForeColor = Color.White;
            labelMunicipio.Location = new Point(14, 99);
            labelMunicipio.Name = "labelMunicipio";
            labelMunicipio.Size = new Size(103, 21);
            labelMunicipio.TabIndex = 68;
            labelMunicipio.Text = "Município . . .:";
            // 
            // labelCep
            // 
            labelCep.AutoSize = true;
            labelCep.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCep.ForeColor = Color.White;
            labelCep.Location = new Point(14, 46);
            labelCep.Name = "labelCep";
            labelCep.Size = new Size(103, 21);
            labelCep.TabIndex = 70;
            labelCep.Text = "CEP. . . . . . . . . :";
            // 
            // labelBairro
            // 
            labelBairro.AutoSize = true;
            labelBairro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelBairro.ForeColor = Color.White;
            labelBairro.Location = new Point(14, 120);
            labelBairro.Name = "labelBairro";
            labelBairro.Size = new Size(90, 21);
            labelBairro.TabIndex = 69;
            labelBairro.Text = "Bairro. . . . . :";
            // 
            // textBoxRua
            // 
            textBoxRua.BackColor = Color.Cyan;
            textBoxRua.BorderStyle = BorderStyle.None;
            textBoxRua.ForeColor = Color.White;
            textBoxRua.Location = new Point(133, 141);
            textBoxRua.Name = "textBoxRua";
            textBoxRua.Size = new Size(149, 16);
            textBoxRua.TabIndex = 76;
            // 
            // labelRua
            // 
            labelRua.AutoSize = true;
            labelRua.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRua.ForeColor = Color.White;
            labelRua.Location = new Point(14, 142);
            labelRua.Name = "labelRua";
            labelRua.Size = new Size(100, 21);
            labelRua.TabIndex = 75;
            labelRua.Text = "Rua . . . . . . . . :";
            // 
            // textBoxComplemento
            // 
            textBoxComplemento.BackColor = Color.Cyan;
            textBoxComplemento.BorderStyle = BorderStyle.None;
            textBoxComplemento.ForeColor = Color.Black;
            textBoxComplemento.Location = new Point(133, 163);
            textBoxComplemento.Name = "textBoxComplemento";
            textBoxComplemento.Size = new Size(149, 16);
            textBoxComplemento.TabIndex = 78;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 164);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 77;
            label2.Text = "Complemento:";
            // 
            // panelCriacao
            // 
            panelCriacao.BackColor = Color.BlueViolet;
            panelCriacao.Controls.Add(labelCep);
            panelCriacao.Controls.Add(panelBotaoCancelar);
            panelCriacao.Controls.Add(textBoxComplemento);
            panelCriacao.Controls.Add(panelBotaoSalvar);
            panelCriacao.Controls.Add(labelBairro);
            panelCriacao.Controls.Add(label2);
            panelCriacao.Controls.Add(labelMunicipio);
            panelCriacao.Controls.Add(textBoxRua);
            panelCriacao.Controls.Add(textBoxMunicipio);
            panelCriacao.Controls.Add(labelRua);
            panelCriacao.Controls.Add(comboBoxEstado);
            panelCriacao.Controls.Add(labelTitulo);
            panelCriacao.Controls.Add(textBoxBairro);
            panelCriacao.Controls.Add(LabelEstado);
            panelCriacao.Controls.Add(textBoxCep);
            panelCriacao.Location = new Point(-1, 1);
            panelCriacao.Name = "panelCriacao";
            panelCriacao.Size = new Size(301, 242);
            panelCriacao.TabIndex = 79;
            panelCriacao.Paint += AoRequererPintura_PanelCriacao;
            // 
            // TelaCriarEnderecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(312, 255);
            Controls.Add(panelCriacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCriarEnderecoForm";
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
        private Label LabelEstado;
        private TextBox textBoxCep;
        private TextBox textBoxBairro;
        private ComboBox comboBoxEstado;
        private TextBox textBoxMunicipio;
        private Label labelMunicipio;
        private Label labelCep;
        private Label labelBairro;
        private TextBox textBoxRua;
        private Label labelRua;
        private TextBox textBoxComplemento;
        private Label label2;
        private Panel panelCriacao;
    }
}