namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaEscolaForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewEscolas = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusAtividadeDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codigoMecDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            inicioAtividadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoriaAdministrativaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            organizacaoAcademicaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idEnderecoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            escolaEnderecoOtdBindingSource = new BindingSource(components);
            painelLateral = new Panel();
            panelBotaoDeletar = new Panel();
            botaoDeletar = new Button();
            panel1 = new Panel();
            botaoPesquisar = new Button();
            panelBotaoEditar = new Panel();
            botaoEditar = new Button();
            panelBotaoFiltrar = new Panel();
            botaoFiltros = new Button();
            panelBotaoCriar = new Panel();
            botaoCriar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEscolas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)escolaEnderecoOtdBindingSource).BeginInit();
            painelLateral.SuspendLayout();
            panelBotaoDeletar.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoEditar.SuspendLayout();
            panelBotaoFiltrar.SuspendLayout();
            panelBotaoCriar.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewEscolas
            // 
            dataGridViewEscolas.AllowUserToAddRows = false;
            dataGridViewEscolas.AllowUserToDeleteRows = false;
            dataGridViewEscolas.AllowUserToResizeRows = false;
            dataGridViewEscolas.AutoGenerateColumns = false;
            dataGridViewEscolas.BackgroundColor = Color.Blue;
            dataGridViewEscolas.BorderStyle = BorderStyle.None;
            dataGridViewEscolas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Blue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewEscolas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEscolas.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, statusAtividadeDataGridViewCheckBoxColumn, nomeDataGridViewTextBoxColumn, codigoMecDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, inicioAtividadeDataGridViewTextBoxColumn, categoriaAdministrativaDataGridViewTextBoxColumn, organizacaoAcademicaDataGridViewTextBoxColumn, idEnderecoDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn });
            dataGridViewEscolas.DataSource = escolaEnderecoOtdBindingSource;
            dataGridViewEscolas.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewEscolas.EnableHeadersVisualStyles = false;
            dataGridViewEscolas.GridColor = Color.White;
            dataGridViewEscolas.Location = new Point(165, 12);
            dataGridViewEscolas.MultiSelect = false;
            dataGridViewEscolas.Name = "dataGridViewEscolas";
            dataGridViewEscolas.ReadOnly = true;
            dataGridViewEscolas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewEscolas.RowTemplate.Height = 25;
            dataGridViewEscolas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEscolas.Size = new Size(623, 299);
            dataGridViewEscolas.TabIndex = 2;
            dataGridViewEscolas.CellFormatting += AoFormatarCelulasDataGridViewEscolas;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Código Escola";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 97;
            // 
            // statusAtividadeDataGridViewCheckBoxColumn
            // 
            statusAtividadeDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            statusAtividadeDataGridViewCheckBoxColumn.DataPropertyName = "StatusAtividade";
            statusAtividadeDataGridViewCheckBoxColumn.HeaderText = "Status Atividade";
            statusAtividadeDataGridViewCheckBoxColumn.Name = "statusAtividadeDataGridViewCheckBoxColumn";
            statusAtividadeDataGridViewCheckBoxColumn.ReadOnly = true;
            statusAtividadeDataGridViewCheckBoxColumn.Width = 87;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            nomeDataGridViewTextBoxColumn.Width = 64;
            // 
            // codigoMecDataGridViewTextBoxColumn
            // 
            codigoMecDataGridViewTextBoxColumn.DataPropertyName = "CodigoMec";
            codigoMecDataGridViewTextBoxColumn.HeaderText = "Código Mec";
            codigoMecDataGridViewTextBoxColumn.Name = "codigoMecDataGridViewTextBoxColumn";
            codigoMecDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            telefoneDataGridViewTextBoxColumn.ReadOnly = true;
            telefoneDataGridViewTextBoxColumn.Width = 75;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "E-Mail";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 65;
            // 
            // inicioAtividadeDataGridViewTextBoxColumn
            // 
            inicioAtividadeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            inicioAtividadeDataGridViewTextBoxColumn.DataPropertyName = "InicioAtividade";
            inicioAtividadeDataGridViewTextBoxColumn.HeaderText = "Data Início da Atividade";
            inicioAtividadeDataGridViewTextBoxColumn.Name = "inicioAtividadeDataGridViewTextBoxColumn";
            inicioAtividadeDataGridViewTextBoxColumn.ReadOnly = true;
            inicioAtividadeDataGridViewTextBoxColumn.Width = 97;
            // 
            // categoriaAdministrativaDataGridViewTextBoxColumn
            // 
            categoriaAdministrativaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            categoriaAdministrativaDataGridViewTextBoxColumn.DataPropertyName = "CategoriaAdministrativa";
            categoriaAdministrativaDataGridViewTextBoxColumn.HeaderText = "Categoria Administrativa";
            categoriaAdministrativaDataGridViewTextBoxColumn.Name = "categoriaAdministrativaDataGridViewTextBoxColumn";
            categoriaAdministrativaDataGridViewTextBoxColumn.ReadOnly = true;
            categoriaAdministrativaDataGridViewTextBoxColumn.Width = 148;
            // 
            // organizacaoAcademicaDataGridViewTextBoxColumn
            // 
            organizacaoAcademicaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            organizacaoAcademicaDataGridViewTextBoxColumn.DataPropertyName = "OrganizacaoAcademica";
            organizacaoAcademicaDataGridViewTextBoxColumn.HeaderText = "Organização Acadêmica";
            organizacaoAcademicaDataGridViewTextBoxColumn.Name = "organizacaoAcademicaDataGridViewTextBoxColumn";
            organizacaoAcademicaDataGridViewTextBoxColumn.ReadOnly = true;
            organizacaoAcademicaDataGridViewTextBoxColumn.Width = 145;
            // 
            // idEnderecoDataGridViewTextBoxColumn
            // 
            idEnderecoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idEnderecoDataGridViewTextBoxColumn.DataPropertyName = "IdEndereco";
            idEnderecoDataGridViewTextBoxColumn.HeaderText = "Código Endereço";
            idEnderecoDataGridViewTextBoxColumn.Name = "idEnderecoDataGridViewTextBoxColumn";
            idEnderecoDataGridViewTextBoxColumn.ReadOnly = true;
            idEnderecoDataGridViewTextBoxColumn.Width = 112;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            estadoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            estadoDataGridViewTextBoxColumn.ReadOnly = true;
            estadoDataGridViewTextBoxColumn.Width = 66;
            // 
            // escolaEnderecoOtdBindingSource
            // 
            escolaEnderecoOtdBindingSource.DataSource = typeof(Dominio.ObjetosTranferenciaDados.EscolaEnderecoOtd);
            // 
            // painelLateral
            // 
            painelLateral.BackColor = Color.DarkGray;
            painelLateral.Controls.Add(panelBotaoDeletar);
            painelLateral.Controls.Add(panel1);
            painelLateral.Controls.Add(panelBotaoEditar);
            painelLateral.Controls.Add(panelBotaoFiltrar);
            painelLateral.Controls.Add(panelBotaoCriar);
            painelLateral.Dock = DockStyle.Left;
            painelLateral.Location = new Point(0, 0);
            painelLateral.Name = "painelLateral";
            painelLateral.Size = new Size(164, 323);
            painelLateral.TabIndex = 1;
            painelLateral.Paint += AoPintarPainelLateral;
            // 
            // panelBotaoDeletar
            // 
            panelBotaoDeletar.Controls.Add(botaoDeletar);
            panelBotaoDeletar.Location = new Point(12, 177);
            panelBotaoDeletar.Name = "panelBotaoDeletar";
            panelBotaoDeletar.Size = new Size(133, 49);
            panelBotaoDeletar.TabIndex = 38;
            panelBotaoDeletar.Paint += AoPintarPainelBotoes;
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
            botaoDeletar.Click += AoClicarEmDeletar;
            // 
            // panel1
            // 
            panel1.Controls.Add(botaoPesquisar);
            panel1.Location = new Point(12, 232);
            panel1.Name = "panel1";
            panel1.Size = new Size(133, 49);
            panel1.TabIndex = 36;
            panel1.Paint += AoPintarPainelBotoes;
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
            botaoPesquisar.Click += AoCLicarEmPesquisar;
            // 
            // panelBotaoEditar
            // 
            panelBotaoEditar.Controls.Add(botaoEditar);
            panelBotaoEditar.Location = new Point(12, 122);
            panelBotaoEditar.Name = "panelBotaoEditar";
            panelBotaoEditar.Size = new Size(133, 49);
            panelBotaoEditar.TabIndex = 37;
            panelBotaoEditar.Paint += AoPintarPainelBotoes;
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
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.Controls.Add(botaoFiltros);
            panelBotaoFiltrar.Location = new Point(12, 12);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(133, 49);
            panelBotaoFiltrar.TabIndex = 35;
            panelBotaoFiltrar.Paint += AoPintarPainelBotoes;
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
            botaoFiltros.Click += AoClicarEmFiltros;
            // 
            // panelBotaoCriar
            // 
            panelBotaoCriar.Controls.Add(botaoCriar);
            panelBotaoCriar.Location = new Point(12, 67);
            panelBotaoCriar.Name = "panelBotaoCriar";
            panelBotaoCriar.Size = new Size(133, 49);
            panelBotaoCriar.TabIndex = 36;
            panelBotaoCriar.Paint += AoPintarPainelBotoes;
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
            botaoCriar.Click += AoClicarEmCriar;
            // 
            // TelaEscolaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(800, 323);
            Controls.Add(dataGridViewEscolas);
            Controls.Add(painelLateral);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaEscolaForm";
            Text = "TelaConvenioForm";
            Load += AoCarregarTela;
            VisibleChanged += AoMudarVisibilidadeTela;
            Paint += AoPintarTela;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEscolas).EndInit();
            ((System.ComponentModel.ISupportInitialize)escolaEnderecoOtdBindingSource).EndInit();
            painelLateral.ResumeLayout(false);
            panelBotaoDeletar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoEditar.ResumeLayout(false);
            panelBotaoFiltrar.ResumeLayout(false);
            panelBotaoCriar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel painelLateral;
        private DataGridView dataGridViewEscolas;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltros;
        private Panel panel1;
        private Button botaoPesquisar;
        private Panel panelBotaoDeletar;
        private Button botaoDeletar;
        private Panel panelBotaoEditar;
        private Button botaoEditar;
        private Panel panelBotaoCriar;
        private Button botaoCriar;
        private BindingSource escolaEnderecoOtdBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn statusAtividadeDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codigoMecDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn inicioAtividadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoriaAdministrativaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn organizacaoAcademicaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEnderecoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
    }
}