namespace GCSPustekbangLapan
{
    partial class frmMain
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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.cmbbxPort = new System.Windows.Forms.ComboBox();
            this.cmbbxBaudrate = new System.Windows.Forms.ComboBox();
            this.cmbbxParity = new System.Windows.Forms.ComboBox();
            this.grpbxSerial = new System.Windows.Forms.GroupBox();
            this.btnSerial = new System.Windows.Forms.Button();
            this.lblHand = new System.Windows.Forms.Label();
            this.cmbbxHand = new System.Windows.Forms.ComboBox();
            this.lblStop = new System.Windows.Forms.Label();
            this.cmbbxStop = new System.Windows.Forms.ComboBox();
            this.cmbbxData = new System.Windows.Forms.ComboBox();
            this.lblBits = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblBaudrate = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.rchtxtTerminal = new System.Windows.Forms.RichTextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.grpbxTerminal = new System.Windows.Forms.GroupBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pctrbxImage = new System.Windows.Forms.PictureBox();
            this.grpbxPicture = new System.Windows.Forms.GroupBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.rchtxtDebug = new System.Windows.Forms.RichTextBox();
            this.grpbxDebug = new System.Windows.Forms.GroupBox();
            this.cmbbxMode = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.grpbxSerial.SuspendLayout();
            this.grpbxTerminal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxImage)).BeginInit();
            this.grpbxPicture.SuspendLayout();
            this.grpbxDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // cmbbxPort
            // 
            this.cmbbxPort.FormattingEnabled = true;
            this.cmbbxPort.Location = new System.Drawing.Point(76, 27);
            this.cmbbxPort.Name = "cmbbxPort";
            this.cmbbxPort.Size = new System.Drawing.Size(121, 21);
            this.cmbbxPort.TabIndex = 0;
            this.cmbbxPort.DropDown += new System.EventHandler(this.cmbbxPort_DropDown);
            // 
            // cmbbxBaudrate
            // 
            this.cmbbxBaudrate.FormattingEnabled = true;
            this.cmbbxBaudrate.Location = new System.Drawing.Point(76, 54);
            this.cmbbxBaudrate.Name = "cmbbxBaudrate";
            this.cmbbxBaudrate.Size = new System.Drawing.Size(121, 21);
            this.cmbbxBaudrate.TabIndex = 1;
            // 
            // cmbbxParity
            // 
            this.cmbbxParity.FormattingEnabled = true;
            this.cmbbxParity.Location = new System.Drawing.Point(76, 81);
            this.cmbbxParity.Name = "cmbbxParity";
            this.cmbbxParity.Size = new System.Drawing.Size(121, 21);
            this.cmbbxParity.TabIndex = 2;
            // 
            // grpbxSerial
            // 
            this.grpbxSerial.Controls.Add(this.btnSerial);
            this.grpbxSerial.Controls.Add(this.lblHand);
            this.grpbxSerial.Controls.Add(this.cmbbxHand);
            this.grpbxSerial.Controls.Add(this.lblStop);
            this.grpbxSerial.Controls.Add(this.cmbbxStop);
            this.grpbxSerial.Controls.Add(this.cmbbxData);
            this.grpbxSerial.Controls.Add(this.lblBits);
            this.grpbxSerial.Controls.Add(this.lblParity);
            this.grpbxSerial.Controls.Add(this.lblBaudrate);
            this.grpbxSerial.Controls.Add(this.lblPort);
            this.grpbxSerial.Controls.Add(this.cmbbxPort);
            this.grpbxSerial.Controls.Add(this.cmbbxParity);
            this.grpbxSerial.Controls.Add(this.cmbbxBaudrate);
            this.grpbxSerial.Location = new System.Drawing.Point(12, 57);
            this.grpbxSerial.Name = "grpbxSerial";
            this.grpbxSerial.Size = new System.Drawing.Size(208, 233);
            this.grpbxSerial.TabIndex = 3;
            this.grpbxSerial.TabStop = false;
            this.grpbxSerial.Text = "Serial Setting";
            // 
            // btnSerial
            // 
            this.btnSerial.Location = new System.Drawing.Point(10, 198);
            this.btnSerial.Name = "btnSerial";
            this.btnSerial.Size = new System.Drawing.Size(187, 23);
            this.btnSerial.TabIndex = 12;
            this.btnSerial.Text = "Set";
            this.btnSerial.UseVisualStyleBackColor = true;
            this.btnSerial.Click += new System.EventHandler(this.btnSerial_Click);
            // 
            // lblHand
            // 
            this.lblHand.AutoSize = true;
            this.lblHand.Location = new System.Drawing.Point(7, 167);
            this.lblHand.Name = "lblHand";
            this.lblHand.Size = new System.Drawing.Size(62, 13);
            this.lblHand.TabIndex = 11;
            this.lblHand.Text = "Handshake";
            // 
            // cmbbxHand
            // 
            this.cmbbxHand.FormattingEnabled = true;
            this.cmbbxHand.Location = new System.Drawing.Point(76, 164);
            this.cmbbxHand.Name = "cmbbxHand";
            this.cmbbxHand.Size = new System.Drawing.Size(121, 21);
            this.cmbbxHand.TabIndex = 10;
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Location = new System.Drawing.Point(7, 140);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(44, 13);
            this.lblStop.TabIndex = 9;
            this.lblStop.Text = "Stop Bit";
            // 
            // cmbbxStop
            // 
            this.cmbbxStop.FormattingEnabled = true;
            this.cmbbxStop.Location = new System.Drawing.Point(76, 137);
            this.cmbbxStop.Name = "cmbbxStop";
            this.cmbbxStop.Size = new System.Drawing.Size(121, 21);
            this.cmbbxStop.TabIndex = 8;
            // 
            // cmbbxData
            // 
            this.cmbbxData.FormattingEnabled = true;
            this.cmbbxData.Location = new System.Drawing.Point(76, 110);
            this.cmbbxData.Name = "cmbbxData";
            this.cmbbxData.Size = new System.Drawing.Size(121, 21);
            this.cmbbxData.TabIndex = 7;
            // 
            // lblBits
            // 
            this.lblBits.AutoSize = true;
            this.lblBits.Location = new System.Drawing.Point(7, 113);
            this.lblBits.Name = "lblBits";
            this.lblBits.Size = new System.Drawing.Size(50, 13);
            this.lblBits.TabIndex = 6;
            this.lblBits.Text = "Data Bits";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(7, 84);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(33, 13);
            this.lblParity.TabIndex = 5;
            this.lblParity.Text = "Parity";
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.AutoSize = true;
            this.lblBaudrate.Location = new System.Drawing.Point(7, 57);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(50, 13);
            this.lblBaudrate.TabIndex = 4;
            this.lblBaudrate.Text = "Baudrate";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(7, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port";
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Location = new System.Drawing.Point(12, 20);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(122, 13);
            this.lblMain.TabIndex = 4;
            this.lblMain.Text = "GCS Pustekbang Lapan";
            // 
            // rchtxtTerminal
            // 
            this.rchtxtTerminal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rchtxtTerminal.Location = new System.Drawing.Point(13, 27);
            this.rchtxtTerminal.Name = "rchtxtTerminal";
            this.rchtxtTerminal.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rchtxtTerminal.Size = new System.Drawing.Size(339, 194);
            this.rchtxtTerminal.TabIndex = 5;
            this.rchtxtTerminal.Text = "";
            this.rchtxtTerminal.WordWrap = false;
            this.rchtxtTerminal.TextChanged += new System.EventHandler(this.rchtxtTerminal_TextChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(358, 27);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 23);
            this.btnOpen.TabIndex = 13;
            this.btnOpen.Text = "Open Port";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // grpbxTerminal
            // 
            this.grpbxTerminal.Controls.Add(this.btnFile);
            this.grpbxTerminal.Controls.Add(this.btnClear);
            this.grpbxTerminal.Controls.Add(this.btnSave);
            this.grpbxTerminal.Controls.Add(this.btnClose);
            this.grpbxTerminal.Controls.Add(this.rchtxtTerminal);
            this.grpbxTerminal.Controls.Add(this.btnOpen);
            this.grpbxTerminal.Location = new System.Drawing.Point(227, 57);
            this.grpbxTerminal.Name = "grpbxTerminal";
            this.grpbxTerminal.Size = new System.Drawing.Size(444, 233);
            this.grpbxTerminal.TabIndex = 14;
            this.grpbxTerminal.TabStop = false;
            this.grpbxTerminal.Text = "Serial Terminal";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(358, 132);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(80, 23);
            this.btnFile.TabIndex = 17;
            this.btnFile.Text = "Open File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(358, 165);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear Term";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(358, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save Term";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(358, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close Port";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pctrbxImage
            // 
            this.pctrbxImage.Location = new System.Drawing.Point(10, 22);
            this.pctrbxImage.Name = "pctrbxImage";
            this.pctrbxImage.Size = new System.Drawing.Size(200, 200);
            this.pctrbxImage.TabIndex = 15;
            this.pctrbxImage.TabStop = false;
            // 
            // grpbxPicture
            // 
            this.grpbxPicture.Controls.Add(this.lblMode);
            this.grpbxPicture.Controls.Add(this.cmbbxMode);
            this.grpbxPicture.Controls.Add(this.btnImage);
            this.grpbxPicture.Controls.Add(this.txtHeight);
            this.grpbxPicture.Controls.Add(this.lblHeight);
            this.grpbxPicture.Controls.Add(this.lblWidth);
            this.grpbxPicture.Controls.Add(this.txtWidth);
            this.grpbxPicture.Controls.Add(this.pctrbxImage);
            this.grpbxPicture.Location = new System.Drawing.Point(12, 291);
            this.grpbxPicture.Name = "grpbxPicture";
            this.grpbxPicture.Size = new System.Drawing.Size(306, 234);
            this.grpbxPicture.TabIndex = 16;
            this.grpbxPicture.TabStop = false;
            this.grpbxPicture.Text = "Picture";
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(215, 199);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(83, 23);
            this.btnImage.TabIndex = 18;
            this.btnImage.Text = "Set";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(215, 77);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(83, 20);
            this.txtHeight.TabIndex = 19;
            this.txtHeight.Text = "0";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(216, 61);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 18;
            this.lblHeight.Text = "Height";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(216, 22);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 17;
            this.lblWidth.Text = "Width";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(215, 38);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(83, 20);
            this.txtWidth.TabIndex = 16;
            this.txtWidth.Text = "0";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rchtxtDebug
            // 
            this.rchtxtDebug.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rchtxtDebug.Location = new System.Drawing.Point(12, 22);
            this.rchtxtDebug.Name = "rchtxtDebug";
            this.rchtxtDebug.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rchtxtDebug.Size = new System.Drawing.Size(329, 200);
            this.rchtxtDebug.TabIndex = 18;
            this.rchtxtDebug.Text = "";
            this.rchtxtDebug.WordWrap = false;
            // 
            // grpbxDebug
            // 
            this.grpbxDebug.Controls.Add(this.rchtxtDebug);
            this.grpbxDebug.Location = new System.Drawing.Point(324, 291);
            this.grpbxDebug.Name = "grpbxDebug";
            this.grpbxDebug.Size = new System.Drawing.Size(347, 234);
            this.grpbxDebug.TabIndex = 19;
            this.grpbxDebug.TabStop = false;
            this.grpbxDebug.Text = "Debug";
            // 
            // cmbbxMode
            // 
            this.cmbbxMode.FormattingEnabled = true;
            this.cmbbxMode.Location = new System.Drawing.Point(215, 116);
            this.cmbbxMode.Name = "cmbbxMode";
            this.cmbbxMode.Size = new System.Drawing.Size(83, 21);
            this.cmbbxMode.TabIndex = 13;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(216, 100);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 20;
            this.lblMode.Text = "Mode";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 536);
            this.Controls.Add(this.grpbxDebug);
            this.Controls.Add(this.grpbxPicture);
            this.Controls.Add(this.grpbxTerminal);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.grpbxSerial);
            this.Name = "frmMain";
            this.Text = "GCS Pustekbang Lapan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpbxSerial.ResumeLayout(false);
            this.grpbxSerial.PerformLayout();
            this.grpbxTerminal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxImage)).EndInit();
            this.grpbxPicture.ResumeLayout(false);
            this.grpbxPicture.PerformLayout();
            this.grpbxDebug.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cmbbxPort;
        private System.Windows.Forms.ComboBox cmbbxBaudrate;
        private System.Windows.Forms.ComboBox cmbbxParity;
        private System.Windows.Forms.GroupBox grpbxSerial;
        private System.Windows.Forms.ComboBox cmbbxData;
        private System.Windows.Forms.Label lblBits;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblBaudrate;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.ComboBox cmbbxStop;
        private System.Windows.Forms.Label lblHand;
        private System.Windows.Forms.ComboBox cmbbxHand;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Button btnSerial;
        private System.Windows.Forms.RichTextBox rchtxtTerminal;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.GroupBox grpbxTerminal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pctrbxImage;
        private System.Windows.Forms.GroupBox grpbxPicture;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.RichTextBox rchtxtDebug;
        private System.Windows.Forms.GroupBox grpbxDebug;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cmbbxMode;
    }
}

