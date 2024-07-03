namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaPrincipalForm
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
            components = new System.ComponentModel.Container();
            panelTopo = new Panel();
            panelBotaoEnderecos = new Panel();
            botaoEnderecos = new Button();
            panelBotaoEscolas = new Panel();
            botaoEscolas = new Button();
            panelBotaoEmpresas = new Panel();
            botaoEmpresas = new Button();
            panelBotaoConvenios = new Panel();
            botaoConvenios = new Button();
            painelInferior = new Panel();
            botaoFechar = new Button();
            data = new Label();
            tempo = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            painelExibicao = new Panel();
            panelTopo.SuspendLayout();
            panelBotaoEnderecos.SuspendLayout();
            panelBotaoEscolas.SuspendLayout();
            panelBotaoEmpresas.SuspendLayout();
            panelBotaoConvenios.SuspendLayout();
            painelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopo
            // 
            panelTopo.BackColor = Color.DarkGray;
            panelTopo.Controls.Add(panelBotaoEnderecos);
            panelTopo.Controls.Add(panelBotaoEscolas);
            panelTopo.Controls.Add(panelBotaoEmpresas);
            panelTopo.Controls.Add(panelBotaoConvenios);
            panelTopo.Dock = DockStyle.Top;
            panelTopo.Location = new Point(0, 0);
            panelTopo.Margin = new Padding(0);
            panelTopo.Name = "panelTopo";
            panelTopo.Size = new Size(800, 94);
            panelTopo.TabIndex = 0;
            panelTopo.Paint += AoRequererPintura_panelTopo;
            // 
            // panelBotaoEnderecos
            // 
            panelBotaoEnderecos.Controls.Add(botaoEnderecos);
            panelBotaoEnderecos.Location = new Point(444, 16);
            panelBotaoEnderecos.Name = "panelBotaoEnderecos";
            panelBotaoEnderecos.Size = new Size(134, 57);
            panelBotaoEnderecos.TabIndex = 39;
            panelBotaoEnderecos.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoEnderecos
            // 
            botaoEnderecos.BackColor = Color.Green;
            botaoEnderecos.FlatAppearance.BorderSize = 0;
            botaoEnderecos.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEnderecos.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoEnderecos.FlatStyle = FlatStyle.Flat;
            botaoEnderecos.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEnderecos.ForeColor = Color.White;
            botaoEnderecos.Location = new Point(3, 3);
            botaoEnderecos.Name = "botaoEnderecos";
            botaoEnderecos.Size = new Size(113, 44);
            botaoEnderecos.TabIndex = 31;
            botaoEnderecos.Text = "Endereços";
            botaoEnderecos.UseVisualStyleBackColor = false;
            botaoEnderecos.Click += AoClicar_botaoEnderecos;
            // 
            // panelBotaoEscolas
            // 
            panelBotaoEscolas.Controls.Add(botaoEscolas);
            panelBotaoEscolas.Location = new Point(304, 16);
            panelBotaoEscolas.Name = "panelBotaoEscolas";
            panelBotaoEscolas.Size = new Size(134, 57);
            panelBotaoEscolas.TabIndex = 38;
            panelBotaoEscolas.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoEscolas
            // 
            botaoEscolas.BackColor = Color.Green;
            botaoEscolas.FlatAppearance.BorderSize = 0;
            botaoEscolas.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEscolas.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoEscolas.FlatStyle = FlatStyle.Flat;
            botaoEscolas.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEscolas.ForeColor = Color.White;
            botaoEscolas.Location = new Point(3, 3);
            botaoEscolas.Name = "botaoEscolas";
            botaoEscolas.Size = new Size(113, 44);
            botaoEscolas.TabIndex = 31;
            botaoEscolas.Text = "Escolas";
            botaoEscolas.UseVisualStyleBackColor = false;
            botaoEscolas.Click += AoClicar_botaoEscolas;
            // 
            // panelBotaoEmpresas
            // 
            panelBotaoEmpresas.Controls.Add(botaoEmpresas);
            panelBotaoEmpresas.Location = new Point(164, 16);
            panelBotaoEmpresas.Name = "panelBotaoEmpresas";
            panelBotaoEmpresas.Size = new Size(134, 57);
            panelBotaoEmpresas.TabIndex = 37;
            panelBotaoEmpresas.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoEmpresas
            // 
            botaoEmpresas.BackColor = Color.Green;
            botaoEmpresas.FlatAppearance.BorderSize = 0;
            botaoEmpresas.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEmpresas.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoEmpresas.FlatStyle = FlatStyle.Flat;
            botaoEmpresas.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEmpresas.ForeColor = Color.White;
            botaoEmpresas.Location = new Point(3, 3);
            botaoEmpresas.Name = "botaoEmpresas";
            botaoEmpresas.Size = new Size(113, 44);
            botaoEmpresas.TabIndex = 31;
            botaoEmpresas.Text = "Empresas";
            botaoEmpresas.UseVisualStyleBackColor = false;
            botaoEmpresas.Click += AoClicar_botaoEmpresa;
            // 
            // panelBotaoConvenios
            // 
            panelBotaoConvenios.Controls.Add(botaoConvenios);
            panelBotaoConvenios.Location = new Point(24, 16);
            panelBotaoConvenios.Name = "panelBotaoConvenios";
            panelBotaoConvenios.Size = new Size(134, 57);
            panelBotaoConvenios.TabIndex = 36;
            panelBotaoConvenios.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoConvenios
            // 
            botaoConvenios.BackColor = Color.Green;
            botaoConvenios.FlatAppearance.BorderSize = 0;
            botaoConvenios.FlatAppearance.MouseDownBackColor = Color.White;
            botaoConvenios.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoConvenios.FlatStyle = FlatStyle.Flat;
            botaoConvenios.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoConvenios.ForeColor = Color.White;
            botaoConvenios.Location = new Point(3, 3);
            botaoConvenios.Name = "botaoConvenios";
            botaoConvenios.Size = new Size(113, 44);
            botaoConvenios.TabIndex = 31;
            botaoConvenios.Text = "Convênios";
            botaoConvenios.UseVisualStyleBackColor = false;
            botaoConvenios.Click += button1_Click;
            // 
            // painelInferior
            // 
            painelInferior.BackColor = Color.DarkGray;
            painelInferior.Controls.Add(botaoFechar);
            painelInferior.Controls.Add(data);
            painelInferior.Controls.Add(tempo);
            painelInferior.Dock = DockStyle.Bottom;
            painelInferior.Location = new Point(0, 417);
            painelInferior.Margin = new Padding(0);
            painelInferior.Name = "painelInferior";
            painelInferior.Size = new Size(800, 33);
            painelInferior.TabIndex = 1;
            // 
            // botaoFechar
            // 
            botaoFechar.BackColor = Color.Green;
            botaoFechar.FlatAppearance.BorderSize = 0;
            botaoFechar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFechar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoFechar.FlatStyle = FlatStyle.Flat;
            botaoFechar.Font = new Font("Bahnschrift Light Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            botaoFechar.ForeColor = Color.White;
            botaoFechar.Location = new Point(687, 0);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new Size(113, 33);
            botaoFechar.TabIndex = 4;
            botaoFechar.Text = "Fechar";
            botaoFechar.UseVisualStyleBackColor = false;
            botaoFechar.Click += AoClicar_botaoFechar;
            // 
            // data
            // 
            data.AutoSize = true;
            data.ForeColor = Color.Black;
            data.Location = new Point(12, 9);
            data.Name = "data";
            data.Size = new Size(31, 15);
            data.TabIndex = 1;
            data.Text = "Data";
            // 
            // tempo
            // 
            tempo.AutoSize = true;
            tempo.ForeColor = Color.Black;
            tempo.Location = new Point(363, 9);
            tempo.Name = "tempo";
            tempo.Size = new Size(43, 15);
            tempo.TabIndex = 0;
            tempo.Text = "Tempo";
            // 
            // timer1
            // 
            timer1.Tick += AoPassarTempo_temporizador;
            // 
            // painelExibicao
            // 
            painelExibicao.BackColor = Color.Blue;
            painelExibicao.Dock = DockStyle.Fill;
            painelExibicao.Location = new Point(0, 94);
            painelExibicao.Margin = new Padding(0);
            painelExibicao.Name = "painelExibicao";
            painelExibicao.Size = new Size(800, 323);
            painelExibicao.TabIndex = 2;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(800, 450);
            Controls.Add(painelExibicao);
            Controls.Add(painelInferior);
            Controls.Add(panelTopo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaPrincipalForm";
            Load += AoCarregar_TelaPrincipalForm;
            panelTopo.ResumeLayout(false);
            panelBotaoEnderecos.ResumeLayout(false);
            panelBotaoEscolas.ResumeLayout(false);
            panelBotaoEmpresas.ResumeLayout(false);
            panelBotaoConvenios.ResumeLayout(false);
            painelInferior.ResumeLayout(false);
            painelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopo;
        private Panel painelInferior;
        private Label data;
        private Label tempo;
        private System.Windows.Forms.Timer timer1;
        private Panel painelExibicao;
        private Panel panelBotaoConvenios;
        private Button botaoConvenios;
        private Panel panelBotaoEscolas;
        private Button botaoEscolas;
        private Panel panelBotaoEmpresas;
        private Button botaoEmpresas;
        private Panel panelBotaoEnderecos;
        private Button botaoEnderecos;
        private Button botaoFechar;
    }
}