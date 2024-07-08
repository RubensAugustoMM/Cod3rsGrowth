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
            panelBotaoCancelar.SuspendLayout();
            panelBotaoSalvar.SuspendLayout();
            SuspendLayout();
            // 
            // panelBotaoCancelar
            // 
            panelBotaoCancelar.BackColor = Color.Transparent;
            panelBotaoCancelar.Controls.Add(botaoCancelar);
            panelBotaoCancelar.Location = new Point(554, 245);
            panelBotaoCancelar.Name = "panelBotaoCancelar";
            panelBotaoCancelar.Size = new Size(106, 40);
            panelBotaoCancelar.TabIndex = 61;
            panelBotaoCancelar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoCancelar
            // 
            botaoCancelar.BackColor = Color.Green;
            botaoCancelar.FlatAppearance.BorderSize = 0;
            botaoCancelar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoCancelar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoCancelar.FlatStyle = FlatStyle.Flat;
            botaoCancelar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoCancelar.ForeColor = Color.White;
            botaoCancelar.Location = new Point(3, 3);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(85, 27);
            botaoCancelar.TabIndex = 22;
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.UseVisualStyleBackColor = false;
            // 
            // panelBotaoSalvar
            // 
            panelBotaoSalvar.BackColor = Color.Transparent;
            panelBotaoSalvar.Controls.Add(botaoSalvar);
            panelBotaoSalvar.Location = new Point(666, 245);
            panelBotaoSalvar.Name = "panelBotaoSalvar";
            panelBotaoSalvar.Size = new Size(106, 40);
            panelBotaoSalvar.TabIndex = 60;
            panelBotaoSalvar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoSalvar
            // 
            botaoSalvar.BackColor = Color.Green;
            botaoSalvar.FlatAppearance.BorderSize = 0;
            botaoSalvar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoSalvar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoSalvar.FlatStyle = FlatStyle.Flat;
            botaoSalvar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoSalvar.ForeColor = Color.White;
            botaoSalvar.Location = new Point(3, 3);
            botaoSalvar.Name = "botaoSalvar";
            botaoSalvar.Size = new Size(85, 27);
            botaoSalvar.TabIndex = 31;
            botaoSalvar.Text = "Salvar";
            botaoSalvar.UseVisualStyleBackColor = false;
            // 
            // TelaCriarEnderecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(784, 284);
            Controls.Add(panelBotaoCancelar);
            Controls.Add(panelBotaoSalvar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaCriarEnderecoForm";
            Text = "TelaCriarEnderecoForm";
            Load += AoPintar_TelaCriarEnderecoForm;
            Paint += AoRequererPintura_TelaCriarEnderecoForm;
            panelBotaoCancelar.ResumeLayout(false);
            panelBotaoSalvar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBotaoCancelar;
        private Button botaoCancelar;
        private Panel panelBotaoSalvar;
        private Button botaoSalvar;
    }
}