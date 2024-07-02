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
            panelTopo1 = new Panel();
            botaoEnderecos = new Button();
            botaoEscolas = new Button();
            button2 = new Button();
            button1 = new Button();
            painelInferior = new Panel();
            botaoFechar = new Button();
            data = new Label();
            tempo = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            painelExibicao = new Panel();
            panelTopo1.SuspendLayout();
            painelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopo1
            // 
            panelTopo1.BackColor = Color.Silver;
            panelTopo1.Controls.Add(botaoEnderecos);
            panelTopo1.Controls.Add(botaoEscolas);
            panelTopo1.Controls.Add(button2);
            panelTopo1.Controls.Add(button1);
            panelTopo1.Dock = DockStyle.Top;
            panelTopo1.Location = new Point(0, 0);
            panelTopo1.Margin = new Padding(0);
            panelTopo1.Name = "panelTopo1";
            panelTopo1.Size = new Size(800, 94);
            panelTopo1.TabIndex = 0;
            panelTopo1.Paint += panelTopo1_Paint;
            // 
            // botaoEnderecos
            // 
            botaoEnderecos.FlatAppearance.BorderSize = 0;
            botaoEnderecos.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEnderecos.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoEnderecos.FlatStyle = FlatStyle.Flat;
            botaoEnderecos.Font = new Font("Bahnschrift Light Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            botaoEnderecos.ForeColor = Color.White;
            botaoEnderecos.Location = new Point(383, 26);
            botaoEnderecos.Name = "botaoEnderecos";
            botaoEnderecos.Size = new Size(113, 44);
            botaoEnderecos.TabIndex = 3;
            botaoEnderecos.Text = "Endereços";
            botaoEnderecos.UseVisualStyleBackColor = true;
            botaoEnderecos.Click += botaoEnderecos_Click;
            // 
            // botaoEscolas
            // 
            botaoEscolas.FlatAppearance.BorderSize = 0;
            botaoEscolas.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEscolas.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoEscolas.FlatStyle = FlatStyle.Flat;
            botaoEscolas.Font = new Font("Bahnschrift Light Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            botaoEscolas.ForeColor = Color.White;
            botaoEscolas.Location = new Point(264, 26);
            botaoEscolas.Name = "botaoEscolas";
            botaoEscolas.Size = new Size(113, 44);
            botaoEscolas.TabIndex = 2;
            botaoEscolas.Text = "Escolas";
            botaoEscolas.UseVisualStyleBackColor = true;
            botaoEscolas.Click += botaoEscolas_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Bahnschrift Light Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(145, 26);
            button2.Name = "button2";
            button2.Size = new Size(113, 44);
            button2.TabIndex = 1;
            button2.Text = "Empresas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift Light Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(26, 26);
            button1.Name = "button1";
            button1.Size = new Size(113, 44);
            button1.TabIndex = 0;
            button1.Text = "Convênios";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            botaoFechar.FlatAppearance.BorderSize = 0;
            botaoFechar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFechar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFechar.FlatStyle = FlatStyle.Flat;
            botaoFechar.Font = new Font("Bahnschrift Light Condensed", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            botaoFechar.ForeColor = Color.White;
            botaoFechar.Location = new Point(687, 0);
            botaoFechar.Name = "botaoFechar";
            botaoFechar.Size = new Size(113, 33);
            botaoFechar.TabIndex = 4;
            botaoFechar.Text = "Fechar";
            botaoFechar.UseVisualStyleBackColor = true;
            botaoFechar.Click += botaoFechar_Click;
            // 
            // data
            // 
            data.AutoSize = true;
            data.ForeColor = Color.White;
            data.Location = new Point(12, 9);
            data.Name = "data";
            data.Size = new Size(31, 15);
            data.TabIndex = 1;
            data.Text = "Data";
            // 
            // tempo
            // 
            tempo.AutoSize = true;
            tempo.ForeColor = Color.White;
            tempo.Location = new Point(363, 9);
            tempo.Name = "tempo";
            tempo.Size = new Size(43, 15);
            tempo.TabIndex = 0;
            tempo.Text = "Tempo";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
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
            Controls.Add(panelTopo1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaPrincipalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TelaPrincipalForm";
            Load += TelaPrincipalForm_Load;
            panelTopo1.ResumeLayout(false);
            painelInferior.ResumeLayout(false);
            painelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopo1;
        private Button button1;
        private Button botaoEnderecos;
        private Button botaoEscolas;
        private Button button2;
        private Panel painelInferior;
        private Label data;
        private Label tempo;
        private System.Windows.Forms.Timer timer1;
        private Panel painelExibicao;
        private Button botaoFechar;
    }
}