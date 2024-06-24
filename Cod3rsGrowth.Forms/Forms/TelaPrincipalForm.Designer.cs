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
            menuStrip1 = new MenuStrip();
            açõesToolStripMenuItem = new ToolStripMenuItem();
            exibirToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            botaoPesquisar = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { exibirToolStripMenuItem, açõesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // açõesToolStripMenuItem
            // 
            açõesToolStripMenuItem.Name = "açõesToolStripMenuItem";
            açõesToolStripMenuItem.Size = new Size(51, 20);
            açõesToolStripMenuItem.Text = "Ações";
            açõesToolStripMenuItem.Click += opçõesToolStripMenuItem_Click;
            // 
            // exibirToolStripMenuItem
            // 
            exibirToolStripMenuItem.Name = "exibirToolStripMenuItem";
            exibirToolStripMenuItem.Size = new Size(48, 20);
            exibirToolStripMenuItem.Text = "Exibir";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(800, 366);
            dataGridView1.TabIndex = 1;
            // 
            // botaoPesquisar
            // 
            botaoPesquisar.Location = new Point(713, 53);
            botaoPesquisar.Name = "botaoPesquisar";
            botaoPesquisar.Size = new Size(75, 23);
            botaoPesquisar.TabIndex = 2;
            botaoPesquisar.Text = "Pesquisar";
            botaoPesquisar.UseVisualStyleBackColor = true;
            botaoPesquisar.Click += botaoPesquisar_Click;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(botaoPesquisar);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipalForm";
            Text = "TelaPrincipalForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem exibirToolStripMenuItem;
        private ToolStripMenuItem açõesToolStripMenuItem;
        private DataGridView dataGridView1;
        private Button botaoPesquisar;
    }
}