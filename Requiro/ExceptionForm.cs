using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Requiro
{
    public partial class ExceptionForm : Form
    {
        public ExceptionForm(Exception ex, Version programVersion)
        {
            InitializeComponent();

            this.m_ExceptionType.Text = ex.GetType().ToString();
            this.m_StackTrace.Text = ex.StackTrace;
            this.m_Message.Text = ex.Message;
            this.m_ProgramVersion.Text += this.Text = String.Format("Requiro v{0}.{1}.{2} build {3}", programVersion.Major, programVersion.Minor, programVersion.Build, programVersion.Revision); 
        }

        private void ExceptionForm_Load(object sender, EventArgs e)
        {
            warningIcon.Image = SystemIcons.Warning.ToBitmap();
        }
    }
}
