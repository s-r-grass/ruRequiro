namespace Requiro
{
    partial class Mainform
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Directories", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.m_DirectoryBox = new System.Windows.Forms.GroupBox();
            this.m_PathBox = new System.Windows.Forms.ComboBox();
            this.m_AnalyzeButton = new System.Windows.Forms.Button();
            this.m_BrowseButton = new System.Windows.Forms.Button();
            this.m_FileList = new System.Windows.Forms.ListView();
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_SizeCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_SubfoldersCount = new System.Windows.Forms.Label();
            this.m_PieChart = new System.Windows.Forms.PictureBox();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.m_FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.m_StatusLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_DriveSize = new System.Windows.Forms.Label();
            this.m_AvailableSpace = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_UsedSpace = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_DriveInfoLabel = new System.Windows.Forms.Label();
            this.m_UsagePercent = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_PathLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_toolBarImages = new System.Windows.Forms.ImageList(this.components);
            this.m_RefreshButton = new System.Windows.Forms.Button();
            this.m_DeleteSelectedItemButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.Label();
            this.m_DirectoryBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PieChart)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_DirectoryBox
            // 
            this.m_DirectoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DirectoryBox.Controls.Add(this.m_PathBox);
            this.m_DirectoryBox.Controls.Add(this.m_AnalyzeButton);
            this.m_DirectoryBox.Controls.Add(this.m_BrowseButton);
            this.m_DirectoryBox.Location = new System.Drawing.Point(8, 12);
            this.m_DirectoryBox.Name = "m_DirectoryBox";
            this.m_DirectoryBox.Size = new System.Drawing.Size(1054, 53);
            this.m_DirectoryBox.TabIndex = 0;
            this.m_DirectoryBox.TabStop = false;
            this.m_DirectoryBox.Text = "Полный путь к целевому каталогу";
            // 
            // m_PathBox
            // 
            this.m_PathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PathBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_PathBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_PathBox.FormattingEnabled = true;
            this.m_PathBox.Location = new System.Drawing.Point(6, 20);
            this.m_PathBox.Name = "m_PathBox";
            this.m_PathBox.Size = new System.Drawing.Size(869, 21);
            this.m_PathBox.TabIndex = 3;
            // 
            // m_AnalyzeButton
            // 
            this.m_AnalyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_AnalyzeButton.Location = new System.Drawing.Point(919, 18);
            this.m_AnalyzeButton.Name = "m_AnalyzeButton";
            this.m_AnalyzeButton.Size = new System.Drawing.Size(129, 23);
            this.m_AnalyzeButton.TabIndex = 2;
            this.m_AnalyzeButton.Text = "Начать анализ";
            this.m_AnalyzeButton.UseVisualStyleBackColor = true;
            this.m_AnalyzeButton.Click += new System.EventHandler(this.m_AnalyzeButton_Click);
            // 
            // m_BrowseButton
            // 
            this.m_BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BrowseButton.Location = new System.Drawing.Point(881, 18);
            this.m_BrowseButton.Name = "m_BrowseButton";
            this.m_BrowseButton.Size = new System.Drawing.Size(33, 23);
            this.m_BrowseButton.TabIndex = 1;
            this.m_BrowseButton.Text = "...";
            this.m_BrowseButton.UseVisualStyleBackColor = true;
            this.m_BrowseButton.Click += new System.EventHandler(this.m_BrowseButton_Click);
            // 
            // m_FileList
            // 
            this.m_FileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.path,
            this.totalSize});
            this.m_FileList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_FileList.FullRowSelect = true;
            listViewGroup1.Header = "Directories";
            listViewGroup1.Name = "Directories";
            listViewGroup2.Header = "Files";
            listViewGroup2.Name = "Files";
            this.m_FileList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.m_FileList.Location = new System.Drawing.Point(8, 85);
            this.m_FileList.Name = "m_FileList";
            this.m_FileList.Size = new System.Drawing.Size(552, 374);
            this.m_FileList.SmallImageList = this.m_imageList;
            this.m_FileList.TabIndex = 6;
            this.m_FileList.UseCompatibleStateImageBehavior = false;
            this.m_FileList.View = System.Windows.Forms.View.Details;
            this.m_FileList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_FileList_ColumnClick);
            this.m_FileList.DoubleClick += new System.EventHandler(this.m_FileList_DoubleClick);
            // 
            // path
            // 
            this.path.Text = "Подкаталог";
            this.path.Width = 400;
            // 
            // totalSize
            // 
            this.totalSize.Text = "Размер";
            this.totalSize.Width = 100;
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "folder.png");
            this.m_imageList.Images.SetKeyName(1, "arrow_undo.png");
            // 
            // m_SizeCount
            // 
            this.m_SizeCount.AutoSize = true;
            this.m_SizeCount.Location = new System.Drawing.Point(106, 35);
            this.m_SizeCount.Name = "m_SizeCount";
            this.m_SizeCount.Size = new System.Drawing.Size(38, 13);
            this.m_SizeCount.TabIndex = 5;
            this.m_SizeCount.Text = "0.0 ГБ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Полный размер:";
            // 
            // m_SubfoldersCount
            // 
            this.m_SubfoldersCount.AutoSize = true;
            this.m_SubfoldersCount.Location = new System.Drawing.Point(106, 22);
            this.m_SubfoldersCount.Name = "m_SubfoldersCount";
            this.m_SubfoldersCount.Size = new System.Drawing.Size(13, 13);
            this.m_SubfoldersCount.TabIndex = 2;
            this.m_SubfoldersCount.Text = "0";
            this.m_SubfoldersCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_PieChart
            // 
            this.m_PieChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PieChart.Location = new System.Drawing.Point(566, 85);
            this.m_PieChart.Name = "m_PieChart";
            this.m_PieChart.Size = new System.Drawing.Size(496, 298);
            this.m_PieChart.TabIndex = 11;
            this.m_PieChart.TabStop = false;
            this.m_PieChart.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.m_PieChart_LoadCompleted);
            this.m_PieChart.SizeChanged += new System.EventHandler(this.m_PieChart_SizeChanged);
            this.m_PieChart.Paint += new System.Windows.Forms.PaintEventHandler(this.m_PieChart_Paint);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // m_FolderBrowser
            // 
            this.m_FolderBrowser.Description = "Select the directory the contents of which you want to analyze.";
            this.m_FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.m_FolderBrowser.ShowNewFolderButton = false;
            // 
            // m_StatusLabel
            // 
            this.m_StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_StatusLabel.AutoSize = true;
            this.m_StatusLabel.Location = new System.Drawing.Point(5, 471);
            this.m_StatusLabel.Name = "m_StatusLabel";
            this.m_StatusLabel.Size = new System.Drawing.Size(95, 13);
            this.m_StatusLabel.TabIndex = 14;
            this.m_StatusLabel.Text = "Анализ не начат.";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_DriveSize);
            this.panel2.Controls.Add(this.m_AvailableSpace);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.m_UsedSpace);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_DriveInfoLabel);
            this.panel2.Controls.Add(this.m_UsagePercent);
            this.panel2.Controls.Add(this.m_SizeCount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.m_SubfoldersCount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.m_PathLabel);
            this.panel2.Location = new System.Drawing.Point(566, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 70);
            this.panel2.TabIndex = 9;
            // 
            // m_DriveSize
            // 
            this.m_DriveSize.Location = new System.Drawing.Point(422, 22);
            this.m_DriveSize.Name = "m_DriveSize";
            this.m_DriveSize.Size = new System.Drawing.Size(67, 13);
            this.m_DriveSize.TabIndex = 13;
            this.m_DriveSize.Text = "0.0 ГБ";
            this.m_DriveSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_AvailableSpace
            // 
            this.m_AvailableSpace.Location = new System.Drawing.Point(371, 35);
            this.m_AvailableSpace.Name = "m_AvailableSpace";
            this.m_AvailableSpace.Size = new System.Drawing.Size(118, 13);
            this.m_AvailableSpace.TabIndex = 12;
            this.m_AvailableSpace.Text = "0.0 ГБ";
            this.m_AvailableSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Занято:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Раздел диска:";
            // 
            // m_UsedSpace
            // 
            this.m_UsedSpace.Location = new System.Drawing.Point(383, 48);
            this.m_UsedSpace.Name = "m_UsedSpace";
            this.m_UsedSpace.Size = new System.Drawing.Size(106, 13);
            this.m_UsedSpace.TabIndex = 9;
            this.m_UsedSpace.Text = "0.0 ГБ";
            this.m_UsedSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Доступно:";
            // 
            // m_DriveInfoLabel
            // 
            this.m_DriveInfoLabel.AutoSize = true;
            this.m_DriveInfoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_DriveInfoLabel.Location = new System.Drawing.Point(313, 9);
            this.m_DriveInfoLabel.Name = "m_DriveInfoLabel";
            this.m_DriveInfoLabel.Size = new System.Drawing.Size(182, 13);
            this.m_DriveInfoLabel.TabIndex = 7;
            this.m_DriveInfoLabel.Text = "Данные о: <не выбран диск>";
            // 
            // m_UsagePercent
            // 
            this.m_UsagePercent.AutoSize = true;
            this.m_UsagePercent.Location = new System.Drawing.Point(106, 48);
            this.m_UsagePercent.Name = "m_UsagePercent";
            this.m_UsagePercent.Size = new System.Drawing.Size(34, 13);
            this.m_UsagePercent.TabIndex = 6;
            this.m_UsagePercent.Text = "0.0%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Занято разделом:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Подкаталогов:";
            // 
            // m_PathLabel
            // 
            this.m_PathLabel.AutoSize = true;
            this.m_PathLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PathLabel.Location = new System.Drawing.Point(3, 9);
            this.m_PathLabel.Name = "m_PathLabel";
            this.m_PathLabel.Size = new System.Drawing.Size(182, 13);
            this.m_PathLabel.TabIndex = 0;
            this.m_PathLabel.Text = "Данные о: <не выбран диск>";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(955, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Лицензия: BSD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Результаты поиска";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(563, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 21;
            this.label9.Text = "Статистика";
            // 
            // m_toolBarImages
            // 
            this.m_toolBarImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_toolBarImages.ImageStream")));
            this.m_toolBarImages.TransparentColor = System.Drawing.Color.Transparent;
            this.m_toolBarImages.Images.SetKeyName(0, "arrow_refresh.png");
            this.m_toolBarImages.Images.SetKeyName(1, "delete.png");
            // 
            // m_RefreshButton
            // 
            this.m_RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_RefreshButton.ImageIndex = 0;
            this.m_RefreshButton.ImageList = this.m_toolBarImages;
            this.m_RefreshButton.Location = new System.Drawing.Point(470, 465);
            this.m_RefreshButton.Name = "m_RefreshButton";
            this.m_RefreshButton.Size = new System.Drawing.Size(90, 25);
            this.m_RefreshButton.TabIndex = 22;
            this.m_RefreshButton.Text = "Обновить";
            this.m_RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_RefreshButton.UseVisualStyleBackColor = true;
            this.m_RefreshButton.Click += new System.EventHandler(this.m_RefreshButton_Click);
            // 
            // m_DeleteSelectedItemButton
            // 
            this.m_DeleteSelectedItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DeleteSelectedItemButton.ImageIndex = 1;
            this.m_DeleteSelectedItemButton.ImageList = this.m_toolBarImages;
            this.m_DeleteSelectedItemButton.Location = new System.Drawing.Point(389, 465);
            this.m_DeleteSelectedItemButton.Name = "m_DeleteSelectedItemButton";
            this.m_DeleteSelectedItemButton.Size = new System.Drawing.Size(75, 25);
            this.m_DeleteSelectedItemButton.TabIndex = 23;
            this.m_DeleteSelectedItemButton.Text = "Удалить";
            this.m_DeleteSelectedItemButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_DeleteSelectedItemButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_DeleteSelectedItemButton.UseVisualStyleBackColor = true;
            this.m_DeleteSelectedItemButton.Click += new System.EventHandler(this.m_DeleteSelectedItemButton_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(930, 477);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 13);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.Text = "КонтинентСвободы.рф";
            // 
            // Mainform
            // 
            this.AcceptButton = this.m_AnalyzeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 499);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.m_PieChart);
            this.Controls.Add(this.m_DeleteSelectedItemButton);
            this.Controls.Add(this.m_RefreshButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_StatusLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_FileList);
            this.Controls.Add(this.m_DirectoryBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ruRequiro";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.m_DirectoryBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_PieChart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox m_DirectoryBox;
        private System.Windows.Forms.Button m_BrowseButton;
        private System.Windows.Forms.Button m_AnalyzeButton;
        private System.Windows.Forms.ListView m_FileList;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader totalSize;
        private System.Windows.Forms.Label m_SizeCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label m_SubfoldersCount;
        private System.Windows.Forms.PictureBox m_PieChart;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.FolderBrowserDialog m_FolderBrowser;
        private System.Windows.Forms.Label m_StatusLabel;
        private System.Windows.Forms.ImageList m_imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label m_UsagePercent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label m_PathLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_DriveSize;
        private System.Windows.Forms.Label m_AvailableSpace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label m_UsedSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_DriveInfoLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox m_PathBox;
        private System.Windows.Forms.ImageList m_toolBarImages;
        private System.Windows.Forms.Button m_RefreshButton;
        private System.Windows.Forms.Button m_DeleteSelectedItemButton;
        private System.Windows.Forms.Label linkLabel1;
    }
}

