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
            panel3 = new Panel();
            button3 = new Button();
            panel2 = new Panel();
            button2 = new Button();
            panel1 = new Panel();
            button1 = new Button();
            panelBotaoFiltrar = new Panel();
            botaoFiltros = new Button();
            painelInferior = new Panel();
            botaoFechar = new Button();
            data = new Label();
            tempo = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            painelExibicao = new Panel();
            panelTopo1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoFiltrar.SuspendLayout();
            painelInferior.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopo1
            // 
            panelTopo1.BackColor = Color.DarkGray;
            panelTopo1.Controls.Add(panel3);
            panelTopo1.Controls.Add(panel2);
            panelTopo1.Controls.Add(panel1);
            panelTopo1.Controls.Add(panelBotaoFiltrar);
            panelTopo1.Dock = DockStyle.Top;
            panelTopo1.Location = new Point(0, 0);
            panelTopo1.Margin = new Padding(0);
            panelTopo1.Name = "panelTopo1";
            panelTopo1.Size = new Size(800, 94);
            panelTopo1.TabIndex = 0;
            panelTopo1.Paint += panelTopo1_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Location = new Point(444, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(134, 57);
            panel3.TabIndex = 39;
            panel3.Paint += panelBotaoFiltrar_Paint;
            // 
            // button3
            // 
            button3.BackColor = Color.Green;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.White;
            button3.FlatAppearance.MouseOverBackColor = Color.Yellow;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(113, 44);
            button3.TabIndex = 31;
            button3.Text = "Endereços";
            button3.UseVisualStyleBackColor = false;
            button3.Click += botaoEnderecos_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Location = new Point(304, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(134, 57);
            panel2.TabIndex = 38;
            panel2.Paint += panelBotaoFiltrar_Paint;
            // 
            // button2
            // 
            button2.BackColor = Color.Green;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.Yellow;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(113, 44);
            button2.TabIndex = 31;
            button2.Text = "Escolas";
            button2.UseVisualStyleBackColor = false;
            button2.Click += botaoEscolas_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Location = new Point(164, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(134, 57);
            panel1.TabIndex = 37;
            panel1.Paint += panelBotaoFiltrar_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.Yellow;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(113, 44);
            button1.TabIndex = 31;
            button1.Text = "Empresas";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button2_Click;
            // 
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.Controls.Add(botaoFiltros);
            panelBotaoFiltrar.Location = new Point(24, 16);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(134, 57);
            panelBotaoFiltrar.TabIndex = 36;
            panelBotaoFiltrar.Paint += panelBotaoFiltrar_Paint;
            // 
            // botaoFiltros
            // 
            botaoFiltros.BackColor = Color.Green;
            botaoFiltros.FlatAppearance.BorderSize = 0;
            botaoFiltros.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFiltros.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoFiltros.FlatStyle = FlatStyle.Flat;
            botaoFiltros.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoFiltros.ForeColor = Color.White;
            botaoFiltros.Location = new Point(3, 3);
            botaoFiltros.Name = "botaoFiltros";
            botaoFiltros.Size = new Size(113, 44);
            botaoFiltros.TabIndex = 31;
            botaoFiltros.Text = "Convênios";
            botaoFiltros.UseVisualStyleBackColor = false;
            botaoFiltros.Click += button1_Click;
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
            botaoFechar.Click += botaoFechar_Click;
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
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoFiltrar.ResumeLayout(false);
            painelInferior.ResumeLayout(false);
            painelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopo1;
        private Panel painelInferior;
        private Label data;
        private Label tempo;
        private System.Windows.Forms.Timer timer1;
        private Panel painelExibicao;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltros;
        private Panel panel2;
        private Button button2;
        private Panel panel1;
        private Button button1;
        private Panel panel3;
        private Button button3;
        private Button botaoFechar;
    }
}