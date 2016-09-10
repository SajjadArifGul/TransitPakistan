namespace TransitSMS
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ExportRecordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectionStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessagesGridView = new System.Windows.Forms.DataGridView();
            this.TestMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QueryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPointColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndPointColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RespondedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessagesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportRecordsMenuItem,
            this.ConnectionStatusMenuItem,
            this.TestMessageMenuItem,
            this.AboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ExportRecordsMenuItem
            // 
            this.ExportRecordsMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExportRecordsMenuItem.Name = "ExportRecordsMenuItem";
            this.ExportRecordsMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ExportRecordsMenuItem.Text = "Export";
            this.ExportRecordsMenuItem.Click += new System.EventHandler(this.ExportRecordsMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // ConnectionStatusMenuItem
            // 
            this.ConnectionStatusMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ConnectionStatusMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConnectionStatusMenuItem.Name = "ConnectionStatusMenuItem";
            this.ConnectionStatusMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ConnectionStatusMenuItem.Text = "Status";
            this.ConnectionStatusMenuItem.Click += new System.EventHandler(this.ConnectionStatusMenuItem_Click);
            // 
            // MessagesGridView
            // 
            this.MessagesGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.MessagesGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MessagesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MessagesGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.MessagesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessagesGridView.CausesValidation = false;
            this.MessagesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MessagesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.MessagesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MessagesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SenderColumn,
            this.QueryColumn,
            this.StartPointColumn,
            this.EndPointColumn,
            this.ResponseColumn,
            this.RespondedColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MessagesGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.MessagesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.MessagesGridView.EnableHeadersVisualStyles = false;
            this.MessagesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(187)))), ((int)(((byte)(102)))));
            this.MessagesGridView.Location = new System.Drawing.Point(0, 24);
            this.MessagesGridView.Margin = new System.Windows.Forms.Padding(5);
            this.MessagesGridView.Name = "MessagesGridView";
            this.MessagesGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.MessagesGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.MessagesGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessagesGridView.Size = new System.Drawing.Size(754, 377);
            this.MessagesGridView.TabIndex = 24;
            this.MessagesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MessagesGridView_CellContentClick);
            // 
            // TestMessageMenuItem
            // 
            this.TestMessageMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TestMessageMenuItem.Name = "TestMessageMenuItem";
            this.TestMessageMenuItem.Size = new System.Drawing.Size(89, 20);
            this.TestMessageMenuItem.Text = "Test Message";
            this.TestMessageMenuItem.Click += new System.EventHandler(this.TestMessageMenuItem_Click);
            // 
            // SenderColumn
            // 
            this.SenderColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SenderColumn.FillWeight = 150F;
            this.SenderColumn.HeaderText = "Sender";
            this.SenderColumn.Name = "SenderColumn";
            // 
            // QueryColumn
            // 
            this.QueryColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QueryColumn.HeaderText = "Query";
            this.QueryColumn.Name = "QueryColumn";
            // 
            // StartPointColumn
            // 
            this.StartPointColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StartPointColumn.HeaderText = "Start Point";
            this.StartPointColumn.Name = "StartPointColumn";
            // 
            // EndPointColumn
            // 
            this.EndPointColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndPointColumn.HeaderText = "End Point";
            this.EndPointColumn.Name = "EndPointColumn";
            // 
            // ResponseColumn
            // 
            this.ResponseColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ResponseColumn.FillWeight = 250F;
            this.ResponseColumn.HeaderText = "Response";
            this.ResponseColumn.Name = "ResponseColumn";
            // 
            // RespondedColumn
            // 
            this.RespondedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RespondedColumn.FillWeight = 80F;
            this.RespondedColumn.HeaderText = "Replied";
            this.RespondedColumn.Name = "RespondedColumn";
            this.RespondedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RespondedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(754, 401);
            this.Controls.Add(this.MessagesGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TransitSMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessagesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExportRecordsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConnectionStatusMenuItem;
        internal System.Windows.Forms.DataGridView MessagesGridView;
        private System.Windows.Forms.ToolStripMenuItem TestMessageMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPointColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndPointColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RespondedColumn;
    }
}

