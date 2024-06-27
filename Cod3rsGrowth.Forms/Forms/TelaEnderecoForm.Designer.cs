﻿namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaEnderecoForm
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
            painelPrincipal = new Panel();
            dataGridView1 = new DataGridView();
            painelLateral = new Panel();
            botaoPesquisar = new Button();
            botaoFiltros = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            painelLateral.SuspendLayout();
            SuspendLayout();
            // 
            // painelPrincipal
            // 
            painelPrincipal.Location = new Point(670, 253);
            painelPrincipal.Name = "painelPrincipal";
            painelPrincipal.Size = new Size(776, 305);
            painelPrincipal.TabIndex = 0;
            painelPrincipal.Paint += painelPrincipal_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Navy;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Blue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.FromArgb(0, 0, 192);
            dataGridView1.Location = new Point(165, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(599, 276);
            dataGridView1.TabIndex = 2;
            // 
            // painelLateral
            // 
            painelLateral.Controls.Add(botaoPesquisar);
            painelLateral.Controls.Add(botaoFiltros);
            painelLateral.Dock = DockStyle.Left;
            painelLateral.Location = new Point(0, 0);
            painelLateral.Name = "painelLateral";
            painelLateral.Size = new Size(164, 305);
            painelLateral.TabIndex = 1;
            painelLateral.Paint += painelLateral_Paint;
            // 
            // botaoPesquisar
            // 
            botaoPesquisar.FlatAppearance.BorderSize = 0;
            botaoPesquisar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoPesquisar.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoPesquisar.FlatStyle = FlatStyle.Flat;
            botaoPesquisar.ForeColor = Color.White;
            botaoPesquisar.Location = new Point(30, 98);
            botaoPesquisar.Name = "botaoPesquisar";
            botaoPesquisar.Size = new Size(86, 54);
            botaoPesquisar.TabIndex = 3;
            botaoPesquisar.Text = "Pesquisar";
            botaoPesquisar.UseVisualStyleBackColor = true;
            botaoPesquisar.Click += botaoPesquisar_Click;
            botaoPesquisar.Paint += botaoPesquisar_Paint;
            // 
            // botaoFiltros
            // 
            botaoFiltros.FlatAppearance.BorderSize = 0;
            botaoFiltros.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFiltros.FlatAppearance.MouseOverBackColor = Color.MediumBlue;
            botaoFiltros.FlatStyle = FlatStyle.Flat;
            botaoFiltros.ForeColor = Color.White;
            botaoFiltros.Location = new Point(30, 38);
            botaoFiltros.Name = "botaoFiltros";
            botaoFiltros.Size = new Size(86, 54);
            botaoFiltros.TabIndex = 0;
            botaoFiltros.Text = "Filtros";
            botaoFiltros.UseVisualStyleBackColor = true;
            botaoFiltros.Click += botaoFiltros_Click;
            botaoFiltros.Paint += botaoFiltros_Paint;
            // 
            // TelaEnderecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(776, 305);
            Controls.Add(dataGridView1);
            Controls.Add(painelPrincipal);
            Controls.Add(painelLateral);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaEnderecoForm";
            Text = "TelaConvenioForm";
            Load += TelaConvenioForm_Load;
            Paint += TelaConvenioForm_Paint;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            painelLateral.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel painelPrincipal;
        private Panel painelLateral;
        private Button botaoFiltros;
        private Button botaoPesquisar;
        private DataGridView dataGridView1;
    }
}