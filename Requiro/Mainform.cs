using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Security.Permissions;
using System.Runtime.InteropServices;

// Code comments yet to be written

namespace Requiro
{
    public partial class Mainform : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        private Dictionary<string, long> m_DirectorySizes = new Dictionary<string,long>();
        private DirectoryCache m_DirectoryCache = new DirectoryCache();
        private Stopwatch m_Stopwatch = new Stopwatch();
        private Color[] m_Colors = new Color[64];
        private Version m_Version;
        private int m_MaxDirs = 0;
        private Dictionary<string, long> m_PieDirList = new Dictionary<string, long>();
        bool m_SearchSuccesful = false;
        private long m_TotalPieSize = 0;

        const string m_strStartAnalysis = "Начать анализ";
        const string m_strStopAnalysis = "Остановить анализ";

        public Mainform()
        {
            InitializeComponent();   
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            m_Colors = GetColorArray();
        //    m_Version = Assembly.GetExecutingAssembly().GetName().Version;
        //    label1.Text += " v" + m_Version.Major + "." + m_Version.Minor + "." + m_Version.Build + " (build " + m_Version.Revision + ")";
        //    Text = string.Format("Requiro v{0}.{1}.{2}", m_Version.Major, m_Version.Minor, m_Version.Build);
            // Create the column sorter
            lvwColumnSorter = new ListViewColumnSorter();
            this.m_FileList.ListViewItemSorter = lvwColumnSorter;
        }

        #region Cache
        private void BuildListFromCache()
        {
            Dictionary<string, long> files = m_DirectoryCache.GetPathFiles(m_PathBox.Text);
            m_Stopwatch.Stop();
            
            m_FileList.Items.Clear();
            AddParentDirectoryItem();
            long totalSize = 0;
            foreach (KeyValuePair<string, long> kvp in files)
            {
                string path = kvp.Key;
                long size = kvp.Value;
                path = path.Replace(m_PathBox.Text, "");
                if (path.StartsWith("\\"))
                    path = path.Remove(0, 1);
                AddDirectoryToList(path, kvp.Key, size);
                totalSize += size;
            }

            totalSize += AddCurrentDirectoryFiles(m_PathBox.Text);
            CollectPieChartData();
            BuildTextStatistics(totalSize);
            m_SearchSuccesful = true;
            m_PieChart.Refresh();
            UpdateWithStopwatch(true);
        }

        private void AddFilesToCache()
        {
            Dictionary<string, long> files = new Dictionary<string, long>();

            foreach (ListViewItem lvi in m_FileList.Items)
            {
                if (!Directory.Exists(lvi.Tag.ToString()))
                    continue;
                if (lvi.Text == "Родительский каталог")
                    continue;
                files.Add(lvi.Tag.ToString(), Convert.ToInt64(lvi.SubItems[1].Tag.ToString()));
            }
            if (files.Count > 0)
                m_DirectoryCache.AddPathFiles(m_PathBox.Text, files);
        }

        #endregion
        #region Labels for interface
        private void UpdateWithStopwatch(bool cached)
        {
            string count, cacheAppend = "";
            if (cached)
            {
                count = m_FileList.Items.Count.ToString();
                cacheAppend = " (из кэша)";
            }
            else
            {
                count = m_DirectorySizes.Count.ToString();
            }
            m_StatusLabel.Text = "Анализ завершен. Обработано " + count + " каталогов ";
            String secs = String.Format("{0}.{1:##}", m_Stopwatch.Elapsed.Seconds, m_Stopwatch.Elapsed.Milliseconds);
            m_StatusLabel.Text += "за " + secs + " секунд.";
            m_StatusLabel.Text += cacheAppend;
        }

        private void BuildTextStatistics(long size)
        {
            // Set directory info
            string root = Directory.GetDirectoryRoot(m_PathBox.Text);
            m_PathLabel.Text = "Данные о " + m_PathBox.Text;
            m_DriveInfoLabel.Text = "Данные о " + root;
            m_SubfoldersCount.Text = String.Format("{0} ({1} показно)", m_DirectorySizes.Count, m_FileList.Items.Count);
            m_SizeCount.Text = FormatBytes(size);
            // Check if the root matches to the drives in the system (meaning it's a valid drive)
            foreach (DriveInfo di in (from drive in DriveInfo.GetDrives() where drive.Name.Equals(root) select drive))
            {
                m_UsagePercent.Text = String.Format("{0:P} занято", (float)size / (di.TotalSize - di.AvailableFreeSpace),
                    FormatBytes(di.TotalSize - di.AvailableFreeSpace), FormatBytes(di.AvailableFreeSpace), di.Name);
                m_DriveSize.Text = FormatBytes(di.TotalSize);
                m_AvailableSpace.Text = FormatBytes(di.AvailableFreeSpace) + String.Format(" ({0:##%})", (float)di.AvailableFreeSpace / di.TotalSize);
                m_UsedSpace.Text = FormatBytes(di.TotalSize - di.AvailableFreeSpace) + String.Format(" ({0:##%})", (float)(di.TotalSize - di.AvailableFreeSpace) / di.TotalSize);
            }
        }

        #endregion
        #region Search related functions

        private void StartSearch(bool wantCache)
        {
            ToolTip tip = new ToolTip();

            tip.IsBalloon = true;
            tip.InitialDelay = 5000;
            tip.ToolTipIcon = ToolTipIcon.Error;
            tip.UseFading = true;
            tip.ToolTipTitle = "Ошибка";

            m_PieChart.Invalidate();

            if (!Directory.Exists(m_PathBox.Text))
            {
                tip.Show("Неверный путь. Выберите действительный физический диск или сетевой путь.", m_PathBox, new Point(200, -65));
                return;
            }
            if (m_AnalyzeButton.Text == m_strStopAnalysis)
            {
                StopSearch();
                return;
            }

            if (m_DirectoryCache.HasPath(m_PathBox.Text) && wantCache)
            {
                m_Stopwatch.Reset();
                m_Stopwatch.Start();
                BuildListFromCache();
                return;
            }

            m_FileList.Items.Clear();
            m_DirectorySizes.Clear();
            m_StatusLabel.Text = "Начинается анализ...";
            m_AnalyzeButton.Text = m_strStopAnalysis;
            bgWorker.RunWorkerAsync(m_PathBox.Text);
            m_Stopwatch.Reset();
            m_Stopwatch.Start();
            m_StatusLabel.Text = "Идёт анализ " + m_PathBox.Text + " ... ";
        }

        private void StopSearch()
        {
            if (bgWorker.IsBusy)
                bgWorker.CancelAsync();
            m_StatusLabel.Text = "Анализ отменен.";
            m_AnalyzeButton.Text = m_strStartAnalysis;
            m_SearchSuccesful = false;
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = sender as BackgroundWorker;

            string path = (string)e.Argument;

            try
            {
                this.ProcessDirectory(path, bg, e);
            }

            catch (Exception ex)
            {
                // Cancel the current search
                StopSearch();
                ExceptionForm exfm = new ExceptionForm(ex, m_Version);
                exfm.ShowDialog(this);
            }
        }

        // Returns the size of the directory by adding up the size of the files inside it
        private long GetDirectoryFileSize(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            long size = 0;
            foreach (FileInfo fi in di.GetFiles())
                size += fi.Length;
            return size;
        }

        private void ProcessDirectory(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException("Неверный путь");

            // Check if we can access the path
            try
            {
                FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Read, path);
            }
            catch (System.Security.SecurityException)
            {
                worker.CancelAsync();
            }

            try
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    string[] entries = Directory.GetDirectories(path);
                    foreach (string currentDir in entries)
                    {
                        // Check for errors
                        // - Skip hidden files
                        // - Skip directories that don't exist
                        // - Skip directories that we don't have access to
                        // We do this by asking read permission for this directory. If it gets denied, then we skip it                      
                        if ((File.GetAttributes(currentDir) & FileAttributes.Hidden) == FileAttributes.Hidden)
                            continue;
                        if (!Directory.Exists(currentDir)) // Should never occur. Just in case.
                            continue;

                        long length = 0;

                        try
                        {
                            length = GetDirectoryFileSize(currentDir);
                            if (!m_DirectorySizes.ContainsKey(currentDir))
                                m_DirectorySizes.Add(currentDir, length);
                        }
                        // avoid all IO, security and user access exceptions - if we can't access something 
                        catch (Exception ex) 
                        {
                            continue;
                        }
                            
                        DirectoryInfo parent = new DirectoryInfo(currentDir).Parent;

                        // Since we have to take the size of sub-folders into account the algorithm
                        // must iterate backwards towards the parent directories and add the size of the current
                        // directory to it.
                        while (parent != null && !this.bgWorker.CancellationPending)
                        {
                            if (m_DirectorySizes.ContainsKey(parent.FullName))
                            {
                                m_DirectorySizes[parent.FullName] += length;
                                parent = parent.Parent;
                            }
                            else
                                break;
                        }

                        ProcessDirectory(currentDir, worker, e);
                    }
                }
            }

            catch (Exception ex)
            {
                StopSearch();
                ExceptionForm exfm = new ExceptionForm(ex, m_Version);
                exfm.ShowDialog(this);
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                m_Stopwatch.Stop();
                m_SearchSuccesful = false;
                if (!e.Cancelled)
                {
                    AddParentDirectoryItem();
                    if (m_DirectorySizes.Count == 0)
                    {
                        long size = AddCurrentDirectoryFiles(m_PathBox.Text);
                        //AddFilesToCache();
                        UpdateWithStopwatch(false);
                        BuildTextStatistics(size);
                        CollectPieChartData();
                        m_SearchSuccesful = true;
                        m_PieChart.Refresh();
                    }
                    else
                    {
                        List<string> subfolders = new List<string>();
                        long totalSize = 0;
                        foreach (KeyValuePair<string, long> kvp in m_DirectorySizes)
                        {
                            string subfolder = kvp.Key;
                            long size = kvp.Value;

                            // Remove start slash and initial path
                            subfolder = subfolder.Replace(m_PathBox.Text, "");
                            if (subfolder.StartsWith("\\"))
                                subfolder = subfolder.Remove(0, 1);

                            // Check if it's a direct subfolder
                            bool matched = false;
                            foreach (string sf in subfolders)
                            {
                                Match m = Regex.Match(subfolder, Regex.Escape(sf + "\\"));
                                //Match m = Regex.Match(subfolder, sf);
                                if (m.Success)
                                    matched = true;
                            }
                            // Not a subfolder's subfolder, so we can add it to the list of current directories
                            if (!matched)
                            {
                                subfolders.Add(subfolder);
                                AddDirectoryToList(subfolder, kvp.Key, size);
                                totalSize += size;
                            }
                        }

                        totalSize += AddCurrentDirectoryFiles(m_PathBox.Text);
                        UpdateWithStopwatch(false);

                        BuildTextStatistics(totalSize);
                        m_SearchSuccesful = true;
                        m_DirectorySizes.Clear();
                        m_MaxDirs = (int)(((m_PieChart.Size.Height * 0.75)) / 10);
                        CollectPieChartData();
                        AddFilesToCache();
                        m_PieChart.Refresh();
                    }
                    m_AnalyzeButton.Text = m_strStartAnalysis;
                }
            }

            catch (Exception ex)
            {
                StopSearch();
                ExceptionForm exfm = new ExceptionForm(ex, m_Version);
                exfm.ShowDialog(this);
            }
        }

        #endregion
        #region File list functions

        // Adds the files in the current directory into the file list
        private long AddCurrentDirectoryFiles(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            long size = 0;
            foreach (System.IO.FileInfo file in di.GetFiles())
            {
                string key = file.Extension;

                switch (key.ToUpperInvariant())
                {
                    case ".EXE":
                    case ".LNK":
                        key = System.IO.Path.GetFileNameWithoutExtension(file.FullName);
                        break;
                }

                if (!this.m_imageList.Images.Keys.Contains(key))
                {
                    this.m_imageList.Images.Add(key, System.Drawing.Icon.ExtractAssociatedIcon(file.FullName));
                }

                int index = this.m_imageList.Images.Keys.IndexOf(key);
                long fileSize = file.Length;
                ListViewItem item = new ListViewItem();

                item.Text = file.Name;
    
                item.ImageIndex = index;
                item.SubItems.Add(FormatBytes(fileSize));
                item.SubItems[1].Tag = fileSize;
                size += fileSize;
                item.Tag = file.FullName;
                item.Group = m_FileList.Groups["Файлы"];

                this.m_FileList.Items.Add(item);
            }
            return size;
        }

        /// <summary>
        /// Adds "Parent directory" to the list. Should be used before adding anything.
        /// </summary>
        private void AddParentDirectoryItem()
        {
            string path = m_PathBox.Text;
            if (Directory.GetDirectoryRoot(path) != path)
            {
                ListViewItem lvi = new ListViewItem();
                string parentPath = Directory.GetParent(path).FullName;
                lvi.Text = "Родительский каталог";
                lvi.Tag = parentPath;
                lvi.ImageIndex = 1;
                lvi.SubItems.Add("");
                lvi.SubItems[1].Tag = -1;
                lvi.Group = m_FileList.Groups[0];
                m_FileList.Items.Add(lvi);
            }
        }

        // It's amazing how much stuff we have to do by ourselves
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };

        // Need this to get folder icons
        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags
        );

        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);

        // Adds a directory to the file list. The real path is stored in the tag for sorting purposes.
        private void AddDirectoryToList(string displayName, string realPath, long size)
        {
            if (!this.m_imageList.Images.Keys.Contains(realPath))
            {
                this.m_imageList.Images.Add(realPath, GetFolderIcon(realPath));
            }
            ListViewItem newItem = new ListViewItem();
            newItem.Text = displayName;
            newItem.Tag = realPath;
            newItem.SubItems.Add(FormatBytes(size));
            newItem.SubItems[1].Tag = size;
            newItem.ImageIndex = m_imageList.Images.Keys.IndexOf(realPath);
            newItem.Group = m_FileList.Groups["Каталоги"];
            newItem.Name = displayName;

            m_FileList.Items.Add(newItem);
        }

        // Gets the folder icon for the folder
        public static System.Drawing.Icon GetFolderIcon(string name)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            uint flags = 0x000000100 | 0x000000010; // ICON & dwFileAttributes
            // Small size
            flags += 0x000000001;
            // Get the file information, 0x00000010 indicates this is a folder
            SHGetFileInfo(name,  0x00000010, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), flags);
            // Extract the icon
            System.Drawing.Icon icon = (System.Drawing.Icon) System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            DestroyIcon(shfi.hIcon);
            return icon;
        }

        #endregion
        #region Useful functions
        // Truncates a string
        private string Truncate(string str, int maxLen)
        {
            if (str.Length > maxLen)
                return str.Substring(0, maxLen) + "...";
            else return str;
        }

        // Format the size labels according to locale
        public string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "ТБ", "ГБ", "МБ", "КБ", "Б" };
            long max = (long)Math.Pow(scale, 4);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Б";
        }
        #endregion
        #region Interface
        private void m_FileList_DoubleClick(object sender, EventArgs e)
        {
            if (m_FileList.SelectedItems.Count > 0)
            {
                string selectedPath = m_FileList.SelectedItems[0].Tag.ToString();
                if (Directory.Exists(selectedPath)) {
                    m_PathBox.Text = m_FileList.SelectedItems[0].Tag.ToString();
                    StartSearch(true);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text);
            }
            catch (Exception ex)
            {
                // Do nothing. If a firewall blocks the start of the browser the process will not start and we ignore it.
            }
        }

        private void m_RefreshButton_Click(object sender, EventArgs e)
        {
            StartSearch(false);
        }

        private void m_DeleteSelectedItemButton_Click(object sender, EventArgs e)
        {
            if (m_FileList.SelectedItems.Count == 0)
                return;

            List<String> toBeDeleted = new List<String>();
            foreach (ListViewItem lvi in m_FileList.SelectedItems)
            {
                // Won't delete parent directory
                if (lvi.Text == "Родительский каталог")
                    continue;
                toBeDeleted.Add(lvi.Tag.ToString());
            }
            if (MessageBox.Show("Вы уверены, что хотите удалить " + toBeDeleted.Count + " выбранный элемент(ы)? Восстановление невозможно.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Loop through directories to be deleted
                foreach (string path in toBeDeleted)
                {
                    try
                    {
                        // Can't delete a directory/file with the same call
                        if (Directory.Exists(path))
                        {
                            DirectoryInfo di = new DirectoryInfo(path);
                            di.Delete(true);
                            // Remove from cache
                            m_DirectoryCache.DeletePathFromPath(m_PathBox.Text, path);
                        }
                        else
                        {
                            FileInfo fi = new FileInfo(path);
                            fi.Delete();
                            m_DirectoryCache.DeletePathFromPath(m_PathBox.Text, path);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось удалить, причина: " + ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Refresh the current view from the cache
            StartSearch(true);
        }

        // Code source: http://support.microsoft.com/kb/319401
        private void m_FileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.m_FileList.Sort();

        }

        private void m_BrowseButton_Click(object sender, EventArgs e)
        {
            m_FolderBrowser.ShowDialog();
            m_PathBox.Text = m_FolderBrowser.SelectedPath;
        }

        private void m_AnalyzeButton_Click(object sender, EventArgs e)
        {
            StartSearch(true);
        }

        #endregion
        #region Pie chart stuff
        /// <summary>
        /// Collects pie chart data
        /// </summary>
        private void CollectPieChartData()
        {
            m_TotalPieSize = 0;
            m_PieDirList.Clear();
            for (int c = 0; c < m_MaxDirs && c < m_FileList.Items.Count; c++)
            {
                ListViewItem lvi = m_FileList.Items[c];
                // Skip files
                //if (!Directory.Exists(lvi.Tag.ToString()))
                //    continue;
                if (lvi.Text == "Родительский каталог")
                    continue;
                long size = (long)lvi.SubItems[1].Tag;
                m_PieDirList.Add(lvi.Text, size);
                m_TotalPieSize += size;
            }
        }

        private void m_PieChart_Paint(object sender, PaintEventArgs e)
        {
            if (!m_SearchSuccesful)
                return;

            if (m_PieChart.Size.Width == 1 || m_PieChart.Size.Height == 1)
                return;

            int boxSize = 12;

            Graphics g = e.Graphics;
            g.Clear(this.BackColor);
            Pen pen = new Pen(Color.FromArgb(192, 0, 0, 0), 1.0f);

            Size sz = new Size((int)(m_PieChart.Size.Width * 0.6), (int)(m_PieChart.Size.Height * 0.9));
            Point pt = new Point(0, (int)(sz.Height * 0.05));
            Rectangle rec = new Rectangle(pt, sz);
            Random rand = new Random();

            // Calculate the approximate size for the legends
            // The font we use is 7.5 points high, the default Windows points per pixel is 96
            // So 7.5 points is about 10 pixels, thus divide the leftover size by that
            // Our width is the remaining drawing area plus the size of a box and 10 pixels for padding
            int truncateLen = (int)(((sz.Width * 0.6) + boxSize + 10) / 10);
            List<float> pieslices = new List<float>(m_MaxDirs);

            if (m_FileList.Items.Count == 1)
            {
                g.DrawString("Пустой каталог или не выбран каталог.", new Font("Tahoma", 8.0f), new SolidBrush(Color.Black), new Point(sz.Width - 130, sz.Height - 100));
                return;
            }

            // Sort the dictionary first (insignificant directories can be left out when there's too much to draw)
            var directories = (from entry in m_PieDirList orderby entry.Value descending select entry).Take(m_MaxDirs);
            // Calculate pieslices 
            foreach (KeyValuePair<string, long> kvp in directories)
            {
                float size = (kvp.Value / (float)m_TotalPieSize) * 360;
                pieslices.Add(size);
            }
            g.Clear(Mainform.DefaultBackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Draw pie slices
            float startLoc = 0;
            for (int i = 0; i < pieslices.Count; i++)
            {
                g.DrawPie(pen, rec, startLoc, pieslices[i]);
                g.FillPie(new SolidBrush(m_Colors[i]), rec, startLoc, pieslices[i]);
                startLoc += pieslices[i];
            }
            int count = 0;
            int y = 0;

            // Draw Legend
            foreach (KeyValuePair<string, long> kvp in directories)
            {
                if (count >= m_MaxDirs)
                {
                    g.DrawString("(" + (m_PieDirList.Count - m_MaxDirs).ToString() + " более)", new Font("Tahoma", 7.5F), new SolidBrush(Color.Black), new Point(sz.Width + 8, y + 5));
                    break;
                }
                string percentage = String.Format(" - {0:P}", ((pieslices[count] / 360)));
                Color rectColor = m_Colors[count];
                Brush rectBrush = new SolidBrush(m_Colors[count]);
                g.DrawRectangle(new Pen(Color.Black), new Rectangle(sz.Width + 10, y, boxSize, boxSize));
                g.FillRectangle(rectBrush, sz.Width + 10, y, boxSize, boxSize);
                g.DrawString(Truncate(kvp.Key, truncateLen) + percentage, new Font("Tahoma", 7.5F), new SolidBrush(Color.Black), new Point(sz.Width + 25, y));
                y += boxSize;
                count += 1;
            }
        }

        private void m_PieChart_SizeChanged(object sender, EventArgs e)
        {
            m_PieChart.Refresh();
        }

        private void m_PieChart_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        Color[] GetColorArray()
        {

            // declare an Array for 64 colors
            Color[] colors = new Color[64];
            Random r = new Random();

            // fill the array of colors for chart items
            // use browser-safe colors (multiples of #33)
            for (int i = 0; i < 64; i++)
            {
                colors[i] = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }

            return colors;
        }

        #endregion
    }
}
