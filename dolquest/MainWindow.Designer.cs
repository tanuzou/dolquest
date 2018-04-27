namespace dolquest
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnSearch = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.qPrevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qFollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbSkill = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCrono = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbContq = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFin = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCard = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFreeword = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDiscType = new System.Windows.Forms.ComboBox();
            this.tabList = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tabView = new System.Windows.Forms.TabControl();
            this.chkUnvisibleMQ = new System.Windows.Forms.CheckBox();
            this.chkUnvisibleFQ = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkUnvisibleCQ = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(661, 84);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 29);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(804, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qPrevToolStripMenuItem,
            this.qFollToolStripMenuItem,
            this.toolStripSeparator1,
            this.dDBToolStripMenuItem,
            this.googleToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 98);
            // 
            // qPrevToolStripMenuItem
            // 
            this.qPrevToolStripMenuItem.Name = "qPrevToolStripMenuItem";
            this.qPrevToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.qPrevToolStripMenuItem.Text = "前提";
            // 
            // qFollToolStripMenuItem
            // 
            this.qFollToolStripMenuItem.Name = "qFollToolStripMenuItem";
            this.qFollToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.qFollToolStripMenuItem.Text = "後続";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // dDBToolStripMenuItem
            // 
            this.dDBToolStripMenuItem.Name = "dDBToolStripMenuItem";
            this.dDBToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.dDBToolStripMenuItem.Text = "大航海時代データベース";
            this.dDBToolStripMenuItem.Click += new System.EventHandler(this.dDBToolStripMenuItem_Click);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.googleToolStripMenuItem.Text = "Google検索";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.googleToolStripMenuItem_Click);
            // 
            // cmbSkill
            // 
            this.cmbSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill.FormattingEnabled = true;
            this.cmbSkill.Location = new System.Drawing.Point(55, 12);
            this.cmbSkill.Name = "cmbSkill";
            this.cmbSkill.Size = new System.Drawing.Size(152, 20);
            this.cmbSkill.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "学問";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "都市";
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(55, 38);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(152, 20);
            this.cmbCity.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "クロノ";
            // 
            // cmbCrono
            // 
            this.cmbCrono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCrono.FormattingEnabled = true;
            this.cmbCrono.Location = new System.Drawing.Point(55, 90);
            this.cmbCrono.Name = "cmbCrono";
            this.cmbCrono.Size = new System.Drawing.Size(152, 20);
            this.cmbCrono.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "オファー";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(55, 64);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(152, 20);
            this.cmbType.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "連クエ";
            // 
            // cmbContq
            // 
            this.cmbContq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContq.FormattingEnabled = true;
            this.cmbContq.Location = new System.Drawing.Point(257, 64);
            this.cmbContq.Name = "cmbContq";
            this.cmbContq.Size = new System.Drawing.Size(159, 20);
            this.cmbContq.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "発見";
            // 
            // cmbFin
            // 
            this.cmbFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFin.FormattingEnabled = true;
            this.cmbFin.Location = new System.Drawing.Point(257, 12);
            this.cmbFin.Name = "cmbFin";
            this.cmbFin.Size = new System.Drawing.Size(159, 20);
            this.cmbFin.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "カード";
            // 
            // cmbCard
            // 
            this.cmbCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCard.FormattingEnabled = true;
            this.cmbCard.Location = new System.Drawing.Point(257, 38);
            this.cmbCard.Name = "cmbCard";
            this.cmbCard.Size = new System.Drawing.Size(159, 20);
            this.cmbCard.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(422, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "クエスト/発見物";
            // 
            // txtFreeword
            // 
            this.txtFreeword.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtFreeword.Location = new System.Drawing.Point(509, 12);
            this.txtFreeword.Name = "txtFreeword";
            this.txtFreeword.Size = new System.Drawing.Size(136, 20);
            this.txtFreeword.TabIndex = 18;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(661, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 29);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "データ更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "種別";
            // 
            // cmbDiscType
            // 
            this.cmbDiscType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscType.FormattingEnabled = true;
            this.cmbDiscType.Location = new System.Drawing.Point(257, 89);
            this.cmbDiscType.Name = "cmbDiscType";
            this.cmbDiscType.Size = new System.Drawing.Size(159, 20);
            this.cmbDiscType.TabIndex = 20;
            // 
            // tabList
            // 
            this.tabList.BackColor = System.Drawing.SystemColors.Control;
            this.tabList.Controls.Add(this.dataGridView);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(796, 394);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "検索結果";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 18;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(790, 388);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dataGridView_RowContextMenuStripNeeded);
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.tabList);
            this.tabView.Location = new System.Drawing.Point(0, 116);
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.tabView.Size = new System.Drawing.Size(804, 420);
            this.tabView.TabIndex = 22;
            // 
            // chkUnvisibleMQ
            // 
            this.chkUnvisibleMQ.AutoSize = true;
            this.chkUnvisibleMQ.Checked = true;
            this.chkUnvisibleMQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnvisibleMQ.Location = new System.Drawing.Point(469, 38);
            this.chkUnvisibleMQ.Name = "chkUnvisibleMQ";
            this.chkUnvisibleMQ.Size = new System.Drawing.Size(48, 16);
            this.chkUnvisibleMQ.TabIndex = 23;
            this.chkUnvisibleMQ.Text = "交易";
            this.chkUnvisibleMQ.UseVisualStyleBackColor = true;
            // 
            // chkUnvisibleFQ
            // 
            this.chkUnvisibleFQ.AutoSize = true;
            this.chkUnvisibleFQ.Checked = true;
            this.chkUnvisibleFQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnvisibleFQ.Location = new System.Drawing.Point(523, 38);
            this.chkUnvisibleFQ.Name = "chkUnvisibleFQ";
            this.chkUnvisibleFQ.Size = new System.Drawing.Size(48, 16);
            this.chkUnvisibleFQ.TabIndex = 23;
            this.chkUnvisibleFQ.Text = "海事";
            this.chkUnvisibleFQ.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(508, 84);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 29);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkUnvisibleCQ
            // 
            this.chkUnvisibleCQ.AutoSize = true;
            this.chkUnvisibleCQ.Checked = true;
            this.chkUnvisibleCQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnvisibleCQ.Location = new System.Drawing.Point(577, 37);
            this.chkUnvisibleCQ.Name = "chkUnvisibleCQ";
            this.chkUnvisibleCQ.Size = new System.Drawing.Size(48, 16);
            this.chkUnvisibleCQ.TabIndex = 25;
            this.chkUnvisibleCQ.Text = "勅命";
            this.chkUnvisibleCQ.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(422, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "非表示";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 561);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkUnvisibleCQ);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkUnvisibleFQ);
            this.Controls.Add(this.chkUnvisibleMQ);
            this.Controls.Add(this.tabView);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbDiscType);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtFreeword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbFin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbContq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCrono);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSkill);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "大航海時代Online クエスト管理";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ComboBox cmbSkill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCrono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbContq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFreeword;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDiscType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem qPrevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qFollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.CheckBox chkUnvisibleMQ;
        private System.Windows.Forms.CheckBox chkUnvisibleFQ;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkUnvisibleCQ;
        private System.Windows.Forms.Label label10;
    }
}

