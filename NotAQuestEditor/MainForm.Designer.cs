namespace NotAQuestEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDialogs = new System.Windows.Forms.ListBox();
            this.lbReplies = new System.Windows.Forms.ListBox();
            this.btnAddDialog = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddReply = new System.Windows.Forms.Button();
            this.btnRemoveReply = new System.Windows.Forms.Button();
            this.gbDialog = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbDialogReplies = new System.Windows.Forms.ListBox();
            this.btnDialogCancel = new System.Windows.Forms.Button();
            this.btnDialogApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDialogText = new System.Windows.Forms.TextBox();
            this.tbDialogId = new System.Windows.Forms.TextBox();
            this.gbReplies = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReplyActions = new System.Windows.Forms.TextBox();
            this.cbNextDialog = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReplyCancel = new System.Windows.Forms.Button();
            this.btnReplyApply = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbReplyText = new System.Windows.Forms.TextBox();
            this.tbReplyId = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveOnSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fdOpen = new System.Windows.Forms.OpenFileDialog();
            this.fdSave = new System.Windows.Forms.SaveFileDialog();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDialog.SuspendLayout();
            this.gbReplies.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDialogs
            // 
            this.lbDialogs.FormattingEnabled = true;
            this.lbDialogs.Location = new System.Drawing.Point(12, 27);
            this.lbDialogs.Name = "lbDialogs";
            this.lbDialogs.Size = new System.Drawing.Size(312, 316);
            this.lbDialogs.TabIndex = 0;
            this.lbDialogs.SelectedIndexChanged += new System.EventHandler(this.lbDialogs_SelectedIndexChanged);
            // 
            // lbReplies
            // 
            this.lbReplies.AllowDrop = true;
            this.lbReplies.FormattingEnabled = true;
            this.lbReplies.Location = new System.Drawing.Point(12, 358);
            this.lbReplies.Name = "lbReplies";
            this.lbReplies.Size = new System.Drawing.Size(312, 277);
            this.lbReplies.TabIndex = 1;
            this.lbReplies.SelectedIndexChanged += new System.EventHandler(this.lbReplies_SelectedIndexChanged);
            this.lbReplies.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbReplies_MouseDown);
            // 
            // btnAddDialog
            // 
            this.btnAddDialog.Location = new System.Drawing.Point(330, 27);
            this.btnAddDialog.Name = "btnAddDialog";
            this.btnAddDialog.Size = new System.Drawing.Size(26, 23);
            this.btnAddDialog.TabIndex = 2;
            this.btnAddDialog.Text = "+";
            this.btnAddDialog.UseVisualStyleBackColor = true;
            this.btnAddDialog.Click += new System.EventHandler(this.btnAddDialog_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(330, 56);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddReply
            // 
            this.btnAddReply.Location = new System.Drawing.Point(330, 358);
            this.btnAddReply.Name = "btnAddReply";
            this.btnAddReply.Size = new System.Drawing.Size(26, 23);
            this.btnAddReply.TabIndex = 2;
            this.btnAddReply.Text = "+";
            this.btnAddReply.UseVisualStyleBackColor = true;
            this.btnAddReply.Click += new System.EventHandler(this.btnAddReply_Click);
            // 
            // btnRemoveReply
            // 
            this.btnRemoveReply.Location = new System.Drawing.Point(330, 387);
            this.btnRemoveReply.Name = "btnRemoveReply";
            this.btnRemoveReply.Size = new System.Drawing.Size(26, 23);
            this.btnRemoveReply.TabIndex = 2;
            this.btnRemoveReply.Text = "-";
            this.btnRemoveReply.UseVisualStyleBackColor = true;
            this.btnRemoveReply.Click += new System.EventHandler(this.btnRemoveReply_Click);
            // 
            // gbDialog
            // 
            this.gbDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDialog.Controls.Add(this.label6);
            this.gbDialog.Controls.Add(this.label5);
            this.gbDialog.Controls.Add(this.lbDialogReplies);
            this.gbDialog.Controls.Add(this.btnDialogCancel);
            this.gbDialog.Controls.Add(this.btnDialogApply);
            this.gbDialog.Controls.Add(this.label4);
            this.gbDialog.Controls.Add(this.label3);
            this.gbDialog.Controls.Add(this.tbDialogText);
            this.gbDialog.Controls.Add(this.tbDialogId);
            this.gbDialog.Location = new System.Drawing.Point(362, 27);
            this.gbDialog.Name = "gbDialog";
            this.gbDialog.Size = new System.Drawing.Size(584, 367);
            this.gbDialog.TabIndex = 4;
            this.gbDialog.TabStop = false;
            this.gbDialog.Text = "Редактирование диалога";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Перетащите нужные реплики из списка слева";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Реплики";
            // 
            // lbDialogReplies
            // 
            this.lbDialogReplies.AllowDrop = true;
            this.lbDialogReplies.FormattingEnabled = true;
            this.lbDialogReplies.Location = new System.Drawing.Point(63, 153);
            this.lbDialogReplies.Name = "lbDialogReplies";
            this.lbDialogReplies.Size = new System.Drawing.Size(515, 121);
            this.lbDialogReplies.TabIndex = 4;
            this.lbDialogReplies.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbDialogReplies_DragDrop);
            this.lbDialogReplies.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbDialogReplies_DragEnter);
            this.lbDialogReplies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbDialogReplies_KeyDown);
            // 
            // btnDialogCancel
            // 
            this.btnDialogCancel.Location = new System.Drawing.Point(503, 284);
            this.btnDialogCancel.Name = "btnDialogCancel";
            this.btnDialogCancel.Size = new System.Drawing.Size(75, 23);
            this.btnDialogCancel.TabIndex = 3;
            this.btnDialogCancel.Text = "Отмена";
            this.btnDialogCancel.UseVisualStyleBackColor = true;
            this.btnDialogCancel.Click += new System.EventHandler(this.lbDialogs_SelectedIndexChanged);
            // 
            // btnDialogApply
            // 
            this.btnDialogApply.Location = new System.Drawing.Point(422, 284);
            this.btnDialogApply.Name = "btnDialogApply";
            this.btnDialogApply.Size = new System.Drawing.Size(75, 23);
            this.btnDialogApply.TabIndex = 2;
            this.btnDialogApply.Text = "Применить";
            this.btnDialogApply.UseVisualStyleBackColor = true;
            this.btnDialogApply.Click += new System.EventHandler(this.btnDialogApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Текст";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID";
            // 
            // tbDialogText
            // 
            this.tbDialogText.Location = new System.Drawing.Point(63, 52);
            this.tbDialogText.Multiline = true;
            this.tbDialogText.Name = "tbDialogText";
            this.tbDialogText.Size = new System.Drawing.Size(515, 95);
            this.tbDialogText.TabIndex = 0;
            this.tbDialogText.TextChanged += new System.EventHandler(this.tbDialogId_TextChanged);
            // 
            // tbDialogId
            // 
            this.tbDialogId.Location = new System.Drawing.Point(63, 26);
            this.tbDialogId.Name = "tbDialogId";
            this.tbDialogId.Size = new System.Drawing.Size(173, 20);
            this.tbDialogId.TabIndex = 0;
            this.tbDialogId.TextChanged += new System.EventHandler(this.tbDialogId_TextChanged);
            // 
            // gbReplies
            // 
            this.gbReplies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReplies.Controls.Add(this.label1);
            this.gbReplies.Controls.Add(this.tbReplyActions);
            this.gbReplies.Controls.Add(this.cbNextDialog);
            this.gbReplies.Controls.Add(this.label2);
            this.gbReplies.Controls.Add(this.btnReplyCancel);
            this.gbReplies.Controls.Add(this.btnReplyApply);
            this.gbReplies.Controls.Add(this.label7);
            this.gbReplies.Controls.Add(this.label8);
            this.gbReplies.Controls.Add(this.tbReplyText);
            this.gbReplies.Controls.Add(this.tbReplyId);
            this.gbReplies.Location = new System.Drawing.Point(362, 349);
            this.gbReplies.Name = "gbReplies";
            this.gbReplies.Size = new System.Drawing.Size(584, 285);
            this.gbReplies.TabIndex = 4;
            this.gbReplies.TabStop = false;
            this.gbReplies.Text = "Редактирование реплики";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Действия";
            // 
            // tbReplyActions
            // 
            this.tbReplyActions.Location = new System.Drawing.Point(63, 153);
            this.tbReplyActions.Multiline = true;
            this.tbReplyActions.Name = "tbReplyActions";
            this.tbReplyActions.Size = new System.Drawing.Size(515, 70);
            this.tbReplyActions.TabIndex = 8;
            this.tbReplyActions.TextChanged += new System.EventHandler(this.tbReplyId_TextChanged);
            // 
            // cbNextDialog
            // 
            this.cbNextDialog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNextDialog.FormattingEnabled = true;
            this.cbNextDialog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbNextDialog.Location = new System.Drawing.Point(63, 229);
            this.cbNextDialog.MaxDropDownItems = 16;
            this.cbNextDialog.Name = "cbNextDialog";
            this.cbNextDialog.Size = new System.Drawing.Size(515, 21);
            this.cbNextDialog.TabIndex = 7;
            this.cbNextDialog.SelectedValueChanged += new System.EventHandler(this.tbReplyId_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "След. диалог";
            // 
            // btnReplyCancel
            // 
            this.btnReplyCancel.Location = new System.Drawing.Point(503, 256);
            this.btnReplyCancel.Name = "btnReplyCancel";
            this.btnReplyCancel.Size = new System.Drawing.Size(75, 23);
            this.btnReplyCancel.TabIndex = 3;
            this.btnReplyCancel.Text = "Отмена";
            this.btnReplyCancel.UseVisualStyleBackColor = true;
            this.btnReplyCancel.Click += new System.EventHandler(this.lbReplies_SelectedIndexChanged);
            // 
            // btnReplyApply
            // 
            this.btnReplyApply.Location = new System.Drawing.Point(422, 256);
            this.btnReplyApply.Name = "btnReplyApply";
            this.btnReplyApply.Size = new System.Drawing.Size(75, 23);
            this.btnReplyApply.TabIndex = 2;
            this.btnReplyApply.Text = "Применить";
            this.btnReplyApply.UseVisualStyleBackColor = true;
            this.btnReplyApply.Click += new System.EventHandler(this.btnReplyApply_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Текст";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "ID";
            // 
            // tbReplyText
            // 
            this.tbReplyText.Location = new System.Drawing.Point(63, 52);
            this.tbReplyText.Multiline = true;
            this.tbReplyText.Name = "tbReplyText";
            this.tbReplyText.Size = new System.Drawing.Size(515, 95);
            this.tbReplyText.TabIndex = 0;
            this.tbReplyText.TextChanged += new System.EventHandler(this.tbReplyId_TextChanged);
            // 
            // tbReplyId
            // 
            this.tbReplyId.Location = new System.Drawing.Point(63, 26);
            this.tbReplyId.Name = "tbReplyId";
            this.tbReplyId.Size = new System.Drawing.Size(173, 20);
            this.tbReplyId.TabIndex = 0;
            this.tbReplyId.TextChanged += new System.EventHandler(this.tbReplyId_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.settingToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem3,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "Новый";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSaveOnSwitchToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingToolStripMenuItem.Text = "Настройки";
            // 
            // autoSaveOnSwitchToolStripMenuItem
            // 
            this.autoSaveOnSwitchToolStripMenuItem.Checked = true;
            this.autoSaveOnSwitchToolStripMenuItem.CheckOnClick = true;
            this.autoSaveOnSwitchToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSaveOnSwitchToolStripMenuItem.Name = "autoSaveOnSwitchToolStripMenuItem";
            this.autoSaveOnSwitchToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.autoSaveOnSwitchToolStripMenuItem.Text = "Автосохранение при переключении";
            // 
            // fdOpen
            // 
            this.fdOpen.Filter = "Episode-файлы|*.ep|Все файлы|*.*";
            // 
            // fdSave
            // 
            this.fdSave.Filter = "Episode-файлы|*.ep|Все файлы|*.*";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.gameToolStripMenuItem.Text = "Запустить игру";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.gameToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 644);
            this.Controls.Add(this.gbReplies);
            this.Controls.Add(this.gbDialog);
            this.Controls.Add(this.btnRemoveReply);
            this.Controls.Add(this.btnAddReply);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddDialog);
            this.Controls.Add(this.lbReplies);
            this.Controls.Add(this.lbDialogs);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Not A Quest Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.gbDialog.ResumeLayout(false);
            this.gbDialog.PerformLayout();
            this.gbReplies.ResumeLayout(false);
            this.gbReplies.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDialogs;
        private System.Windows.Forms.ListBox lbReplies;
        private System.Windows.Forms.Button btnAddDialog;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddReply;
        private System.Windows.Forms.Button btnRemoveReply;
        private System.Windows.Forms.GroupBox gbDialog;
        private System.Windows.Forms.Button btnDialogCancel;
        private System.Windows.Forms.Button btnDialogApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDialogId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDialogText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbDialogReplies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbReplies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReplyCancel;
        private System.Windows.Forms.Button btnReplyApply;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbReplyText;
        private System.Windows.Forms.TextBox tbReplyId;
        private System.Windows.Forms.ComboBox cbNextDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fdOpen;
        private System.Windows.Forms.SaveFileDialog fdSave;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSaveOnSwitchToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbReplyActions;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
    }
}

