namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaCaixaDialogoErroForm
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
            botaoOk = new Button();
            labelTitulo = new Label();
            panelCriacao = new Panel();
            listBoxErros = new ListBox();
            panelBotaoCancelar.SuspendLayout();
            panelCriacao.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotaoCancelar
            // 
            panelBotaoCancelar.BackColor = Color.Transparent;
            panelBotaoCancelar.Controls.Add(botaoOk);
            panelBotaoCancelar.Location = new Point(96, 202);
            panelBotaoCancelar.Name = "panelBotaoCancelar";
            panelBotaoCancelar.Size = new Size(106, 40);
            panelBotaoCancelar.TabIndex = 61;
            panelBotaoCancelar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoOk
            // 
            botaoOk.BackColor = Color.DodgerBlue;
            botaoOk.FlatAppearance.BorderSize = 0;
            botaoOk.FlatAppearance.MouseDownBackColor = Color.White;
            botaoOk.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoOk.FlatStyle = FlatStyle.Flat;
            botaoOk.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoOk.ForeColor = Color.Black;
            botaoOk.Location = new Point(3, 3);
            botaoOk.Name = "botaoOk";
            botaoOk.Size = new Size(85, 27);
            botaoOk.TabIndex = 22;
            botaoOk.Text = "Ok";
            botaoOk.UseVisualStyleBackColor = false;
            botaoOk.Click += AoClicar_botaoOk;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(126, 3);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(58, 19);
            labelTitulo.TabIndex = 74;
            labelTitulo.Text = "!ERROS!";
            // 
            // panelCriacao
            // 
            panelCriacao.BackColor = Color.DarkRed;
            panelCriacao.Controls.Add(listBoxErros);
            panelCriacao.Controls.Add(panelBotaoCancelar);
            panelCriacao.Controls.Add(labelTitulo);
            panelCriacao.Location = new Point(-1, 1);
            panelCriacao.Name = "panelCriacao";
            panelCriacao.Size = new Size(301, 242);
            panelCriacao.TabIndex = 79;
            panelCriacao.Paint += AoRequererPintura_PanelErros;
            // 
            // listBoxErros
            // 
            listBoxErros.BackColor = Color.DarkRed;
            listBoxErros.BorderStyle = BorderStyle.None;
            listBoxErros.ForeColor = Color.DodgerBlue;
            listBoxErros.FormattingEnabled = true;
            listBoxErros.ItemHeight = 15;
            listBoxErros.Location = new Point(13, 25);
            listBoxErros.Name = "listBoxErros";
            listBoxErros.Size = new Size(269, 165);
            listBoxErros.TabIndex = 75;
            // 
            // TelaCaixaDialogoErroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(312, 255);
            Controls.Add(panelCriacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCaixaDialogoErroForm";
            Text = "TelaCriarEnderecoForm";
            Load += AoCarregar_TelaCaixaDialogoErroForm;
            panelBotaoCancelar.ResumeLayout(false);
            panelCriacao.ResumeLayout(false);
            panelCriacao.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBotaoCancelar;
        private Button botaoOk;
        private Label labelTitulo;
        private Panel panelCriacao;
        private ListBox listBoxErros;
    }
}