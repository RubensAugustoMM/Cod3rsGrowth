namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaCaixaDialogoConfirmacaoDelecaoForm
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
            panelBotaoExcluir = new Panel();
            botaoExcluir = new Button();
            labelTitulo = new Label();
            panelCriacao = new Panel();
            panelTextos = new Panel();
            labelDetalhes = new Label();
            labelLinha = new Label();
            labelEntidadeExcluir = new Label();
            panelBotaoCancelar = new Panel();
            botaoCancelar = new Button();
            panelBotaoExcluir.SuspendLayout();
            panelCriacao.SuspendLayout();
            panelTextos.SuspendLayout();
            panelBotaoCancelar.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotaoExcluir
            // 
            panelBotaoExcluir.BackColor = Color.Transparent;
            panelBotaoExcluir.Controls.Add(botaoExcluir);
            panelBotaoExcluir.Location = new Point(176, 205);
            panelBotaoExcluir.Name = "panelBotaoExcluir";
            panelBotaoExcluir.Size = new Size(106, 40);
            panelBotaoExcluir.TabIndex = 61;
            panelBotaoExcluir.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoExcluir
            // 
            botaoExcluir.BackColor = Color.DodgerBlue;
            botaoExcluir.FlatAppearance.BorderSize = 0;
            botaoExcluir.FlatAppearance.MouseDownBackColor = Color.White;
            botaoExcluir.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoExcluir.FlatStyle = FlatStyle.Flat;
            botaoExcluir.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoExcluir.ForeColor = Color.Black;
            botaoExcluir.Location = new Point(3, 3);
            botaoExcluir.Name = "botaoExcluir";
            botaoExcluir.Size = new Size(85, 27);
            botaoExcluir.TabIndex = 22;
            botaoExcluir.Text = "Excluir";
            botaoExcluir.UseVisualStyleBackColor = false;
            botaoExcluir.Click += AoClicar_botaoExcluir;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(126, 3);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(61, 19);
            labelTitulo.TabIndex = 74;
            labelTitulo.Text = "Certeza?";
            // 
            // panelCriacao
            // 
            panelCriacao.BackColor = Color.DarkRed;
            panelCriacao.Controls.Add(panelTextos);
            panelCriacao.Controls.Add(panelBotaoCancelar);
            panelCriacao.Controls.Add(panelBotaoExcluir);
            panelCriacao.Controls.Add(labelTitulo);
            panelCriacao.Location = new Point(-1, 1);
            panelCriacao.Name = "panelCriacao";
            panelCriacao.Size = new Size(307, 242);
            panelCriacao.TabIndex = 79;
            panelCriacao.Paint += AoRequererPintura_PanelErros;
            // 
            // panelTextos
            // 
            panelTextos.AutoScroll = true;
            panelTextos.Controls.Add(labelDetalhes);
            panelTextos.Controls.Add(labelLinha);
            panelTextos.Controls.Add(labelEntidadeExcluir);
            panelTextos.Location = new Point(25, 25);
            panelTextos.Name = "panelTextos";
            panelTextos.Size = new Size(257, 174);
            panelTextos.TabIndex = 76;
            // 
            // labelDetalhes
            // 
            labelDetalhes.AutoSize = true;
            labelDetalhes.Dock = DockStyle.Top;
            labelDetalhes.ForeColor = Color.White;
            labelDetalhes.Location = new Point(0, 30);
            labelDetalhes.MaximumSize = new Size(257, 0);
            labelDetalhes.Name = "labelDetalhes";
            labelDetalhes.Size = new Size(133, 15);
            labelDetalhes.TabIndex = 76;
            labelDetalhes.Text = "EntidadeExcluirDetalhes";
            // 
            // labelLinha
            // 
            labelLinha.AutoSize = true;
            labelLinha.Dock = DockStyle.Top;
            labelLinha.ForeColor = Color.White;
            labelLinha.Location = new Point(0, 15);
            labelLinha.MaximumSize = new Size(257, 0);
            labelLinha.Name = "labelLinha";
            labelLinha.Size = new Size(88, 15);
            labelLinha.TabIndex = 77;
            labelLinha.Text = "LinhaIgualdade";
            // 
            // labelEntidadeExcluir
            // 
            labelEntidadeExcluir.AutoSize = true;
            labelEntidadeExcluir.Dock = DockStyle.Top;
            labelEntidadeExcluir.ForeColor = Color.White;
            labelEntidadeExcluir.Location = new Point(0, 0);
            labelEntidadeExcluir.MaximumSize = new Size(257, 0);
            labelEntidadeExcluir.Name = "labelEntidadeExcluir";
            labelEntidadeExcluir.Size = new Size(88, 15);
            labelEntidadeExcluir.TabIndex = 75;
            labelEntidadeExcluir.Text = "EntidadeExcluir";
            // 
            // panelBotaoCancelar
            // 
            panelBotaoCancelar.BackColor = Color.Transparent;
            panelBotaoCancelar.Controls.Add(botaoCancelar);
            panelBotaoCancelar.Location = new Point(25, 205);
            panelBotaoCancelar.Name = "panelBotaoCancelar";
            panelBotaoCancelar.Size = new Size(106, 40);
            panelBotaoCancelar.TabIndex = 62;
            panelBotaoCancelar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoCancelar
            // 
            botaoCancelar.BackColor = Color.DodgerBlue;
            botaoCancelar.FlatAppearance.BorderSize = 0;
            botaoCancelar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoCancelar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoCancelar.FlatStyle = FlatStyle.Flat;
            botaoCancelar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoCancelar.ForeColor = Color.Black;
            botaoCancelar.Location = new Point(3, 3);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(85, 27);
            botaoCancelar.TabIndex = 22;
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.UseVisualStyleBackColor = false;
            botaoCancelar.Click += AoClicar_botaoCancelar;
            // 
            // TelaCaixaDialogoConfirmacaoDelecaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(318, 255);
            Controls.Add(panelCriacao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCaixaDialogoConfirmacaoDelecaoForm";
            Text = "TelaCriarEnderecoForm";
            Load += AoCarregar_TelaCaixaDialogoErroForm;
            panelBotaoExcluir.ResumeLayout(false);
            panelCriacao.ResumeLayout(false);
            panelCriacao.PerformLayout();
            panelTextos.ResumeLayout(false);
            panelTextos.PerformLayout();
            panelBotaoCancelar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBotaoExcluir;
        private Button botaoExcluir;
        private Label labelTitulo;
        private Panel panelCriacao;
        private Panel panelBotaoCancelar;
        private Button botaoCancelar;
        private Panel panelTextos;
        private Label labelEntidadeExcluir;
        private Label labelDetalhes;
        private Label labelLinha;
    }
}