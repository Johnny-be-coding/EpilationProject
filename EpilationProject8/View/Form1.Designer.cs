namespace EpilationProject8
{
    partial class Form1
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
        /// Designer support method — do not modify with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvEpilations = new System.Windows.Forms.DataGridView();
            this.groupBoxEditor = new System.Windows.Forms.GroupBox();
            this.txtDateLastEpilationTorseHands = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateLastEpilationTorseFeet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateLastEpilationIntim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateLastEpilationHead = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpilations)).BeginInit();
            this.groupBoxEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEpilations
            // 
            this.dgvEpilations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvEpilations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpilations.Location = new System.Drawing.Point(12, 12);
            this.dgvEpilations.MultiSelect = false;
            this.dgvEpilations.Name = "dgvEpilations";
            this.dgvEpilations.ReadOnly = true;
            this.dgvEpilations.RowTemplate.Height = 24;
            this.dgvEpilations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpilations.Size = new System.Drawing.Size(460, 426);
            this.dgvEpilations.TabIndex = 0;
            this.dgvEpilations.SelectionChanged += new System.EventHandler(this.dgvEpilations_SelectionChanged);
            // 
            // groupBoxEditor
            // 
            this.groupBoxEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEditor.Controls.Add(this.txtDateLastEpilationTorseHands);
            this.groupBoxEditor.Controls.Add(this.label5);
            this.groupBoxEditor.Controls.Add(this.txtDateLastEpilationTorseFeet);
            this.groupBoxEditor.Controls.Add(this.label4);
            this.groupBoxEditor.Controls.Add(this.txtDateLastEpilationIntim);
            this.groupBoxEditor.Controls.Add(this.label3);
            this.groupBoxEditor.Controls.Add(this.txtDateLastEpilationHead);
            this.groupBoxEditor.Controls.Add(this.label2);
            this.groupBoxEditor.Controls.Add(this.txtId);
            this.groupBoxEditor.Controls.Add(this.label1);
            this.groupBoxEditor.Controls.Add(this.btnCreate);
            this.groupBoxEditor.Controls.Add(this.btnUpdate);
            this.groupBoxEditor.Controls.Add(this.btnDelete);
            this.groupBoxEditor.Controls.Add(this.btnRefresh);
            this.groupBoxEditor.Location = new System.Drawing.Point(488, 12);
            this.groupBoxEditor.Name = "groupBoxEditor";
            this.groupBoxEditor.Size = new System.Drawing.Size(300, 426);
            this.groupBoxEditor.TabIndex = 1;
            this.groupBoxEditor.TabStop = false;
            this.groupBoxEditor.Text = "Database Editor";
            this.groupBoxEditor.Enter += new System.EventHandler(this.groupBoxEditor_Enter);
            // 
            // txtDateLastEpilationTorseHands
            // 
            this.txtDateLastEpilationTorseHands.Location = new System.Drawing.Point(12, 198);
            this.txtDateLastEpilationTorseHands.Name = "txtDateLastEpilationTorseHands";
            this.txtDateLastEpilationTorseHands.Size = new System.Drawing.Size(276, 20);
            this.txtDateLastEpilationTorseHands.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Дата последно ипелирани РЪЦЕ";
            // 
            // txtDateLastEpilationTorseFeet
            // 
            this.txtDateLastEpilationTorseFeet.Location = new System.Drawing.Point(12, 150);
            this.txtDateLastEpilationTorseFeet.Name = "txtDateLastEpilationTorseFeet";
            this.txtDateLastEpilationTorseFeet.Size = new System.Drawing.Size(276, 20);
            this.txtDateLastEpilationTorseFeet.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Дата последно ипелирани КРАКА";
            // 
            // txtDateLastEpilationIntim
            // 
            this.txtDateLastEpilationIntim.Location = new System.Drawing.Point(12, 100);
            this.txtDateLastEpilationIntim.Name = "txtDateLastEpilationIntim";
            this.txtDateLastEpilationIntim.Size = new System.Drawing.Size(276, 20);
            this.txtDateLastEpilationIntim.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Дата последно ипелиран ИНТИМ";
            // 
            // txtDateLastEpilationHead
            // 
            this.txtDateLastEpilationHead.Location = new System.Drawing.Point(12, 44);
            this.txtDateLastEpilationHead.Name = "txtDateLastEpilationHead";
            this.txtDateLastEpilationHead.Size = new System.Drawing.Size(276, 20);
            this.txtDateLastEpilationHead.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата последно ипелирана ГЛАВА";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 246);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(276, 20);
            this.txtId.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 292);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 36);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(206, 292);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 36);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(106, 292);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 353);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(276, 36);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh / Reload";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxEditor);
            this.Controls.Add(this.dgvEpilations);
            this.Name = "Form1";
            this.Text = "Form1 - Epilations CRUD";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpilations)).EndInit();
            this.groupBoxEditor.ResumeLayout(false);
            this.groupBoxEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEpilations;
        private System.Windows.Forms.GroupBox groupBoxEditor;
        private System.Windows.Forms.TextBox txtDateLastEpilationTorseHands;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDateLastEpilationTorseFeet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDateLastEpilationIntim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateLastEpilationHead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
    }
}

