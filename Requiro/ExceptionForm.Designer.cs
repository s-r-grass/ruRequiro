namespace Requiro
{
    partial class ExceptionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_ExceptionType = new System.Windows.Forms.TextBox();
            this.m_StackTrace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_SendButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.m_Message = new System.Windows.Forms.TextBox();
            this.m_ProgramVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.warningIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.warningIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "В программе существует множество ошибок, за возникновение которые мы приносим Вам" +
    " свои извинения.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип исключения:";
            // 
            // m_ExceptionType
            // 
            this.m_ExceptionType.Location = new System.Drawing.Point(15, 119);
            this.m_ExceptionType.Name = "m_ExceptionType";
            this.m_ExceptionType.ReadOnly = true;
            this.m_ExceptionType.Size = new System.Drawing.Size(450, 21);
            this.m_ExceptionType.TabIndex = 2;
            // 
            // m_StackTrace
            // 
            this.m_StackTrace.Location = new System.Drawing.Point(15, 242);
            this.m_StackTrace.Multiline = true;
            this.m_StackTrace.Name = "m_StackTrace";
            this.m_StackTrace.ReadOnly = true;
            this.m_StackTrace.Size = new System.Drawing.Size(450, 258);
            this.m_StackTrace.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Трассировка стека:";
            // 
            // m_SendButton
            // 
            this.m_SendButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_SendButton.Location = new System.Drawing.Point(390, 509);
            this.m_SendButton.Name = "m_SendButton";
            this.m_SendButton.Size = new System.Drawing.Size(75, 23);
            this.m_SendButton.TabIndex = 5;
            this.m_SendButton.Text = "Ок";
            this.m_SendButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Сообщение:";
            // 
            // m_Message
            // 
            this.m_Message.Location = new System.Drawing.Point(15, 159);
            this.m_Message.Multiline = true;
            this.m_Message.Name = "m_Message";
            this.m_Message.ReadOnly = true;
            this.m_Message.Size = new System.Drawing.Size(450, 64);
            this.m_Message.TabIndex = 9;
            // 
            // m_ProgramVersion
            // 
            this.m_ProgramVersion.AutoSize = true;
            this.m_ProgramVersion.Location = new System.Drawing.Point(12, 514);
            this.m_ProgramVersion.Name = "m_ProgramVersion";
            this.m_ProgramVersion.Size = new System.Drawing.Size(101, 13);
            this.m_ProgramVersion.TabIndex = 10;
            this.m_ProgramVersion.Text = "Версия програмы: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Не переживайте!";
            // 
            // warningIcon
            // 
            this.warningIcon.Location = new System.Drawing.Point(14, 9);
            this.warningIcon.Name = "warningIcon";
            this.warningIcon.Size = new System.Drawing.Size(40, 44);
            this.warningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.warningIcon.TabIndex = 12;
            this.warningIcon.TabStop = false;
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 541);
            this.Controls.Add(this.warningIcon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_ProgramVersion);
            this.Controls.Add(this.m_Message);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_SendButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_StackTrace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_ExceptionType);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "К сожалению! Произошло что-то странное...";
            this.Load += new System.EventHandler(this.ExceptionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warningIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_ExceptionType;
        private System.Windows.Forms.TextBox m_StackTrace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_SendButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_Message;
        private System.Windows.Forms.Label m_ProgramVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox warningIcon;
    }
}