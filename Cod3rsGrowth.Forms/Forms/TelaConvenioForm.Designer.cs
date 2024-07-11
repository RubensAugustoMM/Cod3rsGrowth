namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaConvenioForm
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
            dataGridViewConvenios = new DataGridView();
            painelLateral = new Panel();
            panelBotaoDeletar = new Panel();
            botaoDeletar = new Button();
            panelBotaoEditar = new Panel();
            botaoEditar = new Button();
            panelBotaoCriar = new Panel();
            botaoCriar = new Button();
            panel1 = new Panel();
            botaoPesquisar = new Button();
            panelBotaoFiltros = new Panel();
            botaoFiltros = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConvenios).BeginInit();
            painelLateral.SuspendLayout();
            panelBotaoDeletar.SuspendLayout();
            panelBotaoEditar.SuspendLayout();
            panelBotaoCriar.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewConvenios
            // 
            dataGridViewConvenios.AllowUserToAddRows = false;
            dataGridViewConvenios.AllowUserToDeleteRows = false;
            dataGridViewConvenios.AllowUserToOrderColumns = true;
            dataGridViewConvenios.AllowUserToResizeRows = false;
            dataGridViewConvenios.BackgroundColor = Color.Blue;
            dataGridViewConvenios.BorderStyle = BorderStyle.None;
            dataGridViewConvenios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Blue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewConvenios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConvenios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewConvenios.EnableHeadersVisualStyles = false;
            dataGridViewConvenios.GridColor = Color.White;
            dataGridViewConvenios.Location = new Point(165, 12);
            dataGridViewConvenios.MultiSelect = false;
            dataGridViewConvenios.Name = "dataGridViewConvenios";
            dataGridViewConvenios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewConvenios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewConvenios.RowTemplate.Height = 25;
            dataGridViewConvenios.Size = new Size(623, 299);
            dataGridViewConvenios.TabIndex = 2;
            dataGridViewConvenios.VisibleChanged += AoMudarVisibilidade_dataGridView1;
            // 
            // painelLateral
            // 
            painelLateral.BackColor = Color.DarkGray;
            painelLateral.Controls.Add(panelBotaoDeletar);
            painelLateral.Controls.Add(panelBotaoEditar);
            painelLateral.Controls.Add(panelBotaoCriar);
            painelLateral.Controls.Add(panel1);
            painelLateral.Controls.Add(panelBotaoFiltros);
            painelLateral.Dock = DockStyle.Left;
            painelLateral.Location = new Point(0, 0);
            painelLateral.Name = "painelLateral";
            painelLateral.Size = new Size(164, 323);
            painelLateral.TabIndex = 1;
            painelLateral.Paint += AoRequererPintura_painelLateral;
            // 
            // panelBotaoDeletar
            // 
            panelBotaoDeletar.Controls.Add(botaoDeletar);
            panelBotaoDeletar.Location = new Point(12, 190);
            panelBotaoDeletar.Name = "panelBotaoDeletar";
            panelBotaoDeletar.Size = new Size(133, 49);
            panelBotaoDeletar.TabIndex = 35;
            panelBotaoDeletar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoDeletar
            // 
            botaoDeletar.BackColor = Color.Green;
            botaoDeletar.FlatAppearance.BorderSize = 0;
            botaoDeletar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoDeletar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoDeletar.FlatStyle = FlatStyle.Flat;
            botaoDeletar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoDeletar.ForeColor = Color.White;
            botaoDeletar.Location = new Point(3, 3);
            botaoDeletar.Name = "botaoDeletar";
            botaoDeletar.Size = new Size(112, 36);
            botaoDeletar.TabIndex = 31;
            botaoDeletar.Text = "Deletar";
            botaoDeletar.UseVisualStyleBackColor = false;
            // 
            // panelBotaoEditar
            // 
            panelBotaoEditar.Controls.Add(botaoEditar);
            panelBotaoEditar.Location = new Point(12, 135);
            panelBotaoEditar.Name = "panelBotaoEditar";
            panelBotaoEditar.Size = new Size(133, 49);
            panelBotaoEditar.TabIndex = 34;
            panelBotaoEditar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoEditar
            // 
            botaoEditar.BackColor = Color.Green;
            botaoEditar.FlatAppearance.BorderSize = 0;
            botaoEditar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEditar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoEditar.FlatStyle = FlatStyle.Flat;
            botaoEditar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEditar.ForeColor = Color.White;
            botaoEditar.Location = new Point(3, 3);
            botaoEditar.Name = "botaoEditar";
            botaoEditar.Size = new Size(112, 36);
            botaoEditar.TabIndex = 31;
            botaoEditar.Text = "Editar";
            botaoEditar.UseVisualStyleBackColor = false;
            // 
            // panelBotaoCriar
            // 
            panelBotaoCriar.Controls.Add(botaoCriar);
            panelBotaoCriar.Location = new Point(12, 80);
            panelBotaoCriar.Name = "panelBotaoCriar";
            panelBotaoCriar.Size = new Size(133, 49);
            panelBotaoCriar.TabIndex = 33;
            panelBotaoCriar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoCriar
            // 
            botaoCriar.BackColor = Color.Green;
            botaoCriar.FlatAppearance.BorderSize = 0;
            botaoCriar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoCriar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoCriar.FlatStyle = FlatStyle.Flat;
            botaoCriar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoCriar.ForeColor = Color.White;
            botaoCriar.Location = new Point(3, 3);
            botaoCriar.Name = "botaoCriar";
            botaoCriar.Size = new Size(112, 36);
            botaoCriar.TabIndex = 31;
            botaoCriar.Text = "Criar";
            botaoCriar.UseVisualStyleBackColor = false;
            botaoCriar.Click += AoClicar_botaoCriar;
            // 
            // panel1
            // 
            panel1.Controls.Add(botaoPesquisar);
            panel1.Location = new Point(12, 245);
            panel1.Name = "panel1";
            panel1.Size = new Size(133, 49);
            panel1.TabIndex = 33;
            panel1.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoPesquisar
            // 
            botaoPesquisar.BackColor = Color.Green;
            botaoPesquisar.FlatAppearance.BorderSize = 0;
            botaoPesquisar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoPesquisar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoPesquisar.FlatStyle = FlatStyle.Flat;
            botaoPesquisar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoPesquisar.ForeColor = Color.White;
            botaoPesquisar.Location = new Point(3, 3);
            botaoPesquisar.Name = "botaoPesquisar";
            botaoPesquisar.Size = new Size(112, 36);
            botaoPesquisar.TabIndex = 31;
            botaoPesquisar.Text = "Pesquisar";
            botaoPesquisar.UseVisualStyleBackColor = false;
            botaoPesquisar.Click += AoClicar_botaoPesquisar;
            // 
            // panelBotaoFiltros
            // 
            panelBotaoFiltros.Controls.Add(botaoFiltros);
            panelBotaoFiltros.Location = new Point(12, 25);
            panelBotaoFiltros.Name = "panelBotaoFiltros";
            panelBotaoFiltros.Size = new Size(133, 49);
            panelBotaoFiltros.TabIndex = 32;
            panelBotaoFiltros.Paint += AoRequererPintura_panelSombraBotoes;
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
            botaoFiltros.Size = new Size(112, 36);
            botaoFiltros.TabIndex = 31;
            botaoFiltros.Text = "Filtros";
            botaoFiltros.UseVisualStyleBackColor = false;
            botaoFiltros.Click += AoClicar_botaoFiltros;
            // 
            // TelaConvenioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(800, 323);
            Controls.Add(dataGridViewConvenios);
            Controls.Add(painelLateral);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaConvenioForm";
            Text = "TelaConvenioForm";
            Load += AoCarregarForm_TelaConvenioForm;
            Paint += AoRequererPintura_TelaConvenioForm;
            ((System.ComponentModel.ISupportInitialize)dataGridViewConvenios).EndInit();
            painelLateral.ResumeLayout(false);
            panelBotaoDeletar.ResumeLayout(false);
            panelBotaoEditar.ResumeLayout(false);
            panelBotaoCriar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoFiltros.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel painelLateral;
        private Button botaoFiltros;
        private DataGridView dataGridViewConvenios;
        private Panel panelBotaoFiltros;
        private Panel panel1;
        private Button botaoPesquisar;
        private Panel panelBotaoDeletar;
        private Button botaoDeletar;
        private Panel panelBotaoEditar;
        private Button botaoEditar;
        private Panel panelBotaoCriar;
        private Button botaoCriar;
    }
}