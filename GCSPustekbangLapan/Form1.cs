using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;

namespace GCSPustekbangLapan
{
    public partial class frmMain : Form
    {
        int width;
        int height;
        byte[,] message;
        int subCountY;
        int subCountX;
        int subSize = 8;

        byte messageByte;
        char messageChar;
        string longMessage;
        Bitmap image;
        int selectedMode;
        int DCBefore = 0;

        int byteIndexHeight = 0;
        int byteIndexWidth = 0;
        int indexY = 0;
        int indexX = 0;

        public frmMain()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize user component
            cmbbxPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxBaudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxParity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxStop.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxHand.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxMode.DropDownStyle = ComboBoxStyle.DropDownList;
            btnSerial.Enabled = false;
            btnOpen.Enabled = false;
            btnClose.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            rchtxtTerminal.ReadOnly = true;
            rchtxtTerminal.WordWrap = false;
            serialPort.ReadTimeout = 1000;
            width = Convert.ToInt16(txtWidth.Text);
            height = Convert.ToInt16(txtHeight.Text);
            message = new byte[height, (width * 3)];
            image = new Bitmap(200, 200);

            //get available port name
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbbxPort.Items.Add(port);
            }
            if (cmbbxPort.Items.Count > 0)
            {
                cmbbxPort.SelectedIndex = 0;
            }

            //baudrate option
            string[] baudrates = {"9600", "19200", "38400", "57600", "115200"};
            foreach (string baudrate in baudrates)
            {
                cmbbxBaudrate.Items.Add(baudrate);
            }
            cmbbxBaudrate.SelectedIndex = 3;

            //parity option
            foreach (string parity in Enum.GetNames(typeof(Parity)))
            {
                cmbbxParity.Items.Add(parity);
            }
            cmbbxParity.SelectedIndex = 0;

            //data bits option
            string[] dataBits = { "5", "6", "7", "8", "9" };
            foreach (string data in dataBits)
            {
                cmbbxData.Items.Add(data);
            }
            cmbbxData.SelectedIndex = 3;

            //stop bit option
            foreach (string stop in Enum.GetNames(typeof(StopBits)))
            {
                cmbbxStop.Items.Add(stop);
            }
            cmbbxStop.SelectedIndex = 1;

            //handshake option
            foreach (string hand in Enum.GetNames(typeof(Handshake)))
            {
                cmbbxHand.Items.Add(hand);
            }
            cmbbxHand.SelectedIndex = 0;

            //mode option
            string[] imageMode = { "RGB", "Grayscale", "Compress" };
            foreach(string mode in imageMode)
            {
                cmbbxMode.Items.Add(mode);
            }
            cmbbxMode.SelectedIndex = 0;

            //check missing input value
            if (cmbbxPort.SelectedItem != null)
            {
                btnSerial.Enabled = true;
            }

            //image init
            Graphics flagGraphics = Graphics.FromImage(image);
            flagGraphics.FillRectangle(Brushes.White, 0, 0, 200, 200);
            pctrbxImage.Image = image;
        }

        private void btnSerial_Click(object sender, EventArgs e)
        {
            serialPort.PortName = cmbbxPort.SelectedItem.ToString();
            serialPort.BaudRate = Int32.Parse(cmbbxBaudrate.SelectedItem.ToString());
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbbxParity.SelectedItem.ToString());
            serialPort.DataBits = Int32.Parse(cmbbxData.SelectedItem.ToString());
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbbxStop.SelectedItem.ToString());
            serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cmbbxHand.SelectedItem.ToString());
            
            btnOpen.Enabled = true;
            
        }

        private void cmbbxPort_DropDown(object sender, EventArgs e)
        {
            cmbbxPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            
            //get available port name
            foreach (string port in ports)
            {
                cmbbxPort.Items.Add(port);
            }
            if (cmbbxPort.Items.Count > 0)
            {
                cmbbxPort.SelectedIndex = 0;
            }

            //check missing input value
            if (cmbbxPort.SelectedItem != null)
            {
                btnSerial.Enabled = true;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            serialPort.Open();
            if (serialPort.IsOpen)
            {
                btnClose.Enabled = true;
                btnOpen.Enabled = false;
                btnSerial.Enabled = false;
                cmbbxBaudrate.Enabled = false;
                cmbbxData.Enabled = false;
                cmbbxParity.Enabled = false;
                cmbbxPort.Enabled = false;
                cmbbxStop.Enabled = false;
                cmbbxHand.Enabled = false;
                btnImage.Enabled = false;
                txtHeight.Enabled = false;
                txtWidth.Enabled = false;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            if (!serialPort.IsOpen)
            {
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                btnSerial.Enabled = true;
                cmbbxBaudrate.Enabled = true;
                cmbbxData.Enabled = true;
                cmbbxParity.Enabled = true;
                cmbbxPort.Enabled = true;
                cmbbxStop.Enabled = true;
                cmbbxHand.Enabled = true;
                btnImage.Enabled = true;
                txtWidth.Enabled = true;
                txtHeight.Enabled = true;
            }
        }

        private void debugMessage(object sender, EventArgs e)
        {
            rchtxtTerminal.AppendText(cmbbxMode.SelectedIndex.ToString());
            //rchtxtTerminal.AppendText("nah!!");
            rchtxtTerminal.AppendText(Environment.NewLine);
        }
        private void displayMessage(object sender, EventArgs e)
        {
            //rchtxtTerminal.AppendText(messageChar.ToString());
            rchtxtTerminal.AppendText(messageByte.ToString());
            rchtxtTerminal.AppendText(",");
        }
        private void displayLongMessage(object sender, EventArgs e)
        {
            rchtxtTerminal.AppendText(longMessage);
            rchtxtTerminal.AppendText(Environment.NewLine);
        }

        private void newlineMessage(object sender, EventArgs e)
        {
            rchtxtTerminal.AppendText(Environment.NewLine);
        }

        private void displayImage(object sender, EventArgs e)
        {
            int i = byteIndexHeight;
            int red, green, blue;

            for (int j = 0; j < width; j++)
            {
            
                /*
                red = Convert.ToUInt16(Math.Round((
                    (Convert.ToDouble(message[i, ((j * 3) + 0)]) - 33.0) / 223.0) * 256.0));
                rchtxtDebug.AppendText(red.ToString());
                rchtxtDebug.AppendText(",");
                green = Convert.ToUInt16(Math.Round((
                    (Convert.ToDouble(message[i, ((j * 3) + 1)]) - 33.0) / 223.0) * 256.0));
                rchtxtDebug.AppendText(green.ToString());
                rchtxtDebug.AppendText(",");
                blue = Convert.ToUInt16(Math.Round((
                    (Convert.ToDouble(message[i, ((j * 3) + 2)]) - 33.0) / 223.0) * 256.0));
                */

                
                red = (message[i, ((j * 3) + 0)] - 127) * 2;
                green = (message[i, ((j * 3) + 1)] - 127) * 2;
                blue = (message[i, ((j * 3) + 2)] - 127) * 2;
                

                
                Color color = Color.FromArgb(
                    red,
                    green,
                    blue);
                image.SetPixel(i, j, color);
            }
            pctrbxImage.Image = image; 
        }

        private void displayGrayImage(object sender, EventArgs e)
        {

            int i = byteIndexHeight;
            int red, green, blue;

            for (int j = 0; j < width; j++)
            {
                red = (message[i, j] - 127) * 2;
                green = (message[i, j] - 127) * 2;
                blue = (message[i, j] - 127) * 2;
                
                Color color = Color.FromArgb(
                    red,
                    green,
                    blue);
                image.SetPixel(i, j, color);
            }
            pctrbxImage.Image = image;            
        }

        private void displayJpegImage(object sender, EventArgs e)
        {
            int iByte = byteIndexHeight;
            int red, green, blue;

            //decomprise
            //inverse DPCM on DC component
            //inverse RLE on AC component
            int[] decodeArray = new int[message.GetLength(1)];
            for (int x = 0; x < decodeArray.GetLength(0); x++)
            {
                decodeArray[x] = 0;
            }

            int index = 1;
            decodeArray[0] = message[iByte, 0] + DCBefore;
            DCBefore = decodeArray[0];
            index = 1;
            for (int x = 1; x < message.GetLength(1); x++)
            {
                if (message[iByte, x] == 0)
                {
                    if (message[iByte, (x + 1)] != 0)
                    {
                        for (int count = 0; count < message[iByte, (x + 1)]; count++)
                        {
                            decodeArray[index] = 0;
                            index++;
                        }
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    decodeArray[index] = message[iByte, x];
                    index++;
                }
            }

            //unvectorize array
            int[,] unvecArray = new int[subSize, subSize];
            for (int y = 0; y < subSize; y++)
            {
                for (int x = 0; x < subSize; x++)
                {
                    unvecArray[y, x] = 0;
                }
            }
            int elemen = 0;
            for (int level = 0; level < subSize; level++)
            {
                if (level % 2 != 0)
                {
                    for (int vecIndex = 0; vecIndex < (level + 1); vecIndex++)
                    {
                        unvecArray[vecIndex, (level - vecIndex)] = decodeArray[elemen];
                        elemen++;
                    }
                }
                else
                {
                    for (int vecIndex = 0; vecIndex < (level + 1); vecIndex++)
                    {
                        unvecArray[(level - vecIndex), vecIndex] = decodeArray[elemen];
                        elemen++;
                    }
                }
            }
            for (int level = 0; level < subSize; level++)
            {
                if (level % 2 != 0)
                {
                    for (int vecIndex = 0; vecIndex < (subSize - (level + 1)); vecIndex++)
                    {
                        unvecArray[(vecIndex + 1 + level), (subSize - 1 - vecIndex)] = decodeArray[elemen];
                        elemen++;
                    }
                }
                else
                {
                    for (int vecIndex = 0; vecIndex < (subSize - (level + 1)); vecIndex++)
                    {
                        unvecArray[(subSize - 1 - vecIndex), (vecIndex + 1 + level)] = decodeArray[elemen];
                        elemen++;
                    }
                }
            }
            elemen = 0;
    
            //dequantize array
            int[,] standardArray = {{ 16,11,10,16,24,40,51,61 },
                { 12,12,14,19,26,58,60,55 },
                { 14,13,16,24,40,57,69,56 },
                { 14,17,22,29,51,87,80,62 },
                { 18,22,37,56,68,109,103,77 },
                { 24,35,55,64,81,104,113,92 },
                { 49,64,78,87,103,121,120,101 },
                { 72,92,95,98,112,100,103,99 }};
            int[,] dequantArray = new int[subSize, subSize];
            for (int v = 0; v < subSize; v++)
            {
                for (int u = 0; u < subSize; u++)
                {
                    dequantArray[v, u] = unvecArray[v, u] * standardArray[v, u];
                }
            }

            //inverse DCT
            double[,] iDCTArray = new double[subSize, subSize];
            double coefX = 0.0;
            double coefY = 0.0;
            double coefInit = 1.0 / (Math.Sqrt(2 * subSize));
            double coefZero = 1.0 / (Math.Sqrt(2));
            double coefNonZero = 1.0;
            double tempCosY = 0.0;
            double tempCosX = 0.0;
            double tempSigma = 0.0;
            for (int v = 0; v < subSize; v++)
            {
                for (int u = 0; u < subSize; u++)
                {
                    if (v == 0)
                    {
                        coefY = coefZero;
                    }
                    else
                    {
                        coefY = coefNonZero;
                    }
                    if (u == 0)
                    {
                        coefX = coefZero;
                    }
                    else
                    {
                        coefX = coefNonZero;
                    }
                    for (int j = 0; j < subSize; j++)
                    {
                        for (int i = 0; i < subSize; i++)
                        {
                            tempCosY = Math.Cos((((2.0 * j) + 1.0) * 3.14 * v) / (2.0 * subSize));
                            tempCosX = Math.Cos((((2.0 * i) + 1.0) * 3.14 * u) / (2.0 * subSize));
                            tempSigma = tempSigma + (dequantArray[j, i] * tempCosY * tempCosX);
                        }
                    }
                    iDCTArray[v, u] = tempSigma * coefY * coefX * coefInit;
                    tempSigma = 0;
                }
            }
            
            for (int j = 0; j < subSize; j++)
            {
                for(int i = 0; i < subSize; i++)
                {
                    red = Convert.ToInt16(Math.Round(iDCTArray[j,i]));
                    green = red;
                    blue = red;

                    Color color = Color.FromArgb(
                        red,
                        green,
                        blue);
                    image.SetPixel((indexY*subSize)+j, (indexX*subSize)+i, color);
                }
            }
            pctrbxImage.Image = image;
            indexY = Convert.ToInt16(byteIndexHeight / subSize);
            indexX = byteIndexHeight % subSize;
        }

        private void displayFullJpegImage(object sender, EventArgs e)
        {
            
            int red, green, blue;

            //decomprise
            //inverse DPCM on DC component
            //inverse RLE on AC component
            int[,] decodeArray = new int[message.GetLength(0), message.GetLength(1)];
            for (int y = 0; y < decodeArray.GetLength(0); y++)
            {
                for (int x = 0; x < decodeArray.GetLength(1); x++)
                {
                    decodeArray[y, x] = 0;
                }
            }

            int index = 1;
            for (int y = 0; y < message.GetLength(0); y++)
            {
                decodeArray[y, 0] = message[y, 0] + DCBefore;
                DCBefore = message[y, 0];
                index = 1;
                for (int x = 1; x < message.GetLength(1); x++)
                {
                    if (message[y, x] == 0)
                    {
                        if (message[y, (x + 1)] != 0)
                        {
                            for (int count = 0; count < message[y, (x + 1)]; count++)
                            {
                                decodeArray[y, index] = 0;
                                index++;
                            }
                            x++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        decodeArray[y, index] = message[y, x];
                        index++;
                    }
                }
            }

            //unvectorize array
            int[,] unvecArray = new int[(subCountY * subSize), (subCountX * subSize)];
            for (int y = 0; y < (subCountY * subSize); y++)
            {
                for (int x = 0; x < (subCountX * subSize); x++)
                {
                    unvecArray[y, x] = 0;
                }
            }
            int elemen = 0;
            for (int y = 0; y < subCountY; y++)
            {
                for (int x = 0; x < subCountX; x++)
                {
                    for (int level = 0; level < subSize; level++)
                    {
                        if (level % 2 != 0)
                        {
                            for (int vecIndex = 0; vecIndex < (level + 1); vecIndex++)
                            {
                                unvecArray[(y * subSize) + vecIndex, (x * subSize) + (level - vecIndex)] = decodeArray[y, elemen];
                                elemen++;
                            }
                        }
                        else
                        {
                            for (int vecIndex = 0; vecIndex < (level + 1); vecIndex++)
                            {
                                unvecArray[(y * subSize) + (level - vecIndex), (x * subSize) + vecIndex] = decodeArray[y, elemen];
                                elemen++;
                            }
                        }
                    }
                    for (int level = 0; level < subSize; level++)
                    {
                        if (level % 2 != 0)
                        {
                            for (int vecIndex = 0; vecIndex < (subSize - (level + 1)); vecIndex++)
                            {
                                unvecArray[(y * subSize) + (vecIndex + 1 + level), (x * subSize) + (subSize - 1 - vecIndex)] = decodeArray[y, elemen];
                                elemen++;
                            }
                        }
                        else
                        {
                            for (int vecIndex = 0; vecIndex < (subSize - (level + 1)); vecIndex++)
                            {
                                unvecArray[(y * subSize) + (subSize - 1 - vecIndex), (x * subSize) + (vecIndex + 1 + level)] = decodeArray[y, elemen];
                                elemen++;
                            }
                        }
                    }
                    elemen = 0;
                }
            }

            //dequantize array
            int[,] standardArray = {{ 16,11,10,16,24,40,51,61 },
                { 12,12,14,19,26,58,60,55 },
                { 14,13,16,24,40,57,69,56 },
                { 14,17,22,29,51,87,80,62 },
                { 18,22,37,56,68,109,103,77 },
                { 24,35,55,64,81,104,113,92 },
                { 49,64,78,87,103,121,120,101 },
                { 72,92,95,98,112,100,103,99 }};
            int[,] dequantArray = new int[(subCountY * subSize), (subCountX * subSize)];
            for (int y = 0; y < subCountY; y++)
            {
                for (int x = 0; x < subCountX; x++)
                {
                    for (int v = 0; v < subSize; v++)
                    {
                        for (int u = 0; u < subSize; u++)
                        {
                            dequantArray[(y * subSize) + v, (x * subSize) + u] = unvecArray[(y * subSize) + v, (x * subSize) + u] * standardArray[v, u];
                        }
                    }
                }
            }


            //inverse DCT
            double[,] iDCTArray = new double[(subCountY * subSize), (subCountX * subSize)];
            double coefX = 0.0;
            double coefY = 0.0;
            double coefInit = 1.0 / (Math.Sqrt(2 * subSize));
            double coefZero = 1.0 / (Math.Sqrt(2));
            double coefNonZero = 1.0;
            double tempCosY = 0.0;
            double tempCosX = 0.0;
            double tempSigma = 0.0;
            for (int y = 0; y < subCountY; y++)
            {
                for (int x = 0; x < subCountX; x++)
                {
                    for (int v = 0; v < subSize; v++)
                    {
                        for (int u = 0; u < subSize; u++)
                        {
                            if (v == 0)
                            {
                                coefY = coefZero;
                            }
                            else
                            {
                                coefY = coefNonZero;
                            }
                            if (u == 0)
                            {
                                coefX = coefZero;
                            }
                            else
                            {
                                coefX = coefNonZero;
                            }
                            for (int j = 0; j < subSize; j++)
                            {
                                for (int i = 0; i < subSize; i++)
                                {
                                    tempCosY = Math.Cos((((2.0 * j) + 1.0) * 3.14 * v) / (2.0 * subSize));
                                    tempCosX = Math.Cos((((2.0 * i) + 1.0) * 3.14 * u) / (2.0 * subSize));
                                    tempSigma = tempSigma + (dequantArray[(y * subSize) + j, (x * subSize) + i] * tempCosY * tempCosX);
                                }
                            }
                            iDCTArray[(y * subSize) + v, (x * subSize) + u] = tempSigma * coefY * coefX * coefInit;
                            tempSigma = 0;
                        }
                    }
                }
            }

            for (int j = 0; j < (subCountY*subSize); j++)
            {
                for (int i = 0; i < (subCountX*subSize); i++)
                {
                    red = Convert.ToInt16(Math.Round(iDCTArray[j, i]));
                    green = red;
                    blue = red;

                    Color color = Color.FromArgb(
                        red,
                        green,
                        blue);
                    image.SetPixel((indexY * subSize) + j, (indexX * subSize) + i, color);
                }
            }
            pctrbxImage.Image = image;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                //receiver v2
                /*
                messageByte = (byte)serialPort.ReadByte();
                this.Invoke(new EventHandler(displayMessage));
                if(messageByte == 10)
                {
                    this.Invoke(new EventHandler(newlineMessage));
                }
                */

                //receiver v1
                if (selectedMode == 0)
                {
                    
                    for (int j = 0; j < (width * 3) + 2; j++)
                    {
                        messageByte = (byte)serialPort.ReadByte();
                        if (messageByte == 255)
                        {
                            this.Invoke(new EventHandler(displayMessage));
                            messageByte = (byte)serialPort.ReadByte();
                        }
                        else if (messageByte == 10)
                        {
                            this.Invoke(new EventHandler(displayMessage));
                            this.Invoke(new EventHandler(newlineMessage));
                            break;
                        }
                        this.Invoke(new EventHandler(displayMessage));
                        message[byteIndexHeight, j] = messageByte;
                    }

                    this.Invoke(new EventHandler(displayImage));
                    byteIndexHeight++;

                    if (byteIndexHeight >= height)
                    {
                        byteIndexHeight = 0;
                    }
                }else if(selectedMode == 1)
                {
                    for (int j = 0; j < width + 2; j++)
                    {
                        messageByte = (byte)serialPort.ReadByte();
                        if (messageByte == 255)
                        {
                            this.Invoke(new EventHandler(displayMessage));
                            messageByte = (byte)serialPort.ReadByte();
                        }
                        else if (messageByte == 10)
                        {
                            this.Invoke(new EventHandler(displayMessage));
                            this.Invoke(new EventHandler(newlineMessage));
                            break;
                        }
                        this.Invoke(new EventHandler(displayMessage));
                        message[byteIndexHeight, j] = messageByte;
                    }

                    this.Invoke(new EventHandler(displayGrayImage));
                    byteIndexHeight++;

                    if (byteIndexHeight >= height)
                    {
                        byteIndexHeight = 0;
                    }
                }else if(selectedMode == 2)
                {
                    for (int j = 0; j < (Math.Pow(subSize,2)) + 2; j++)
                    {
                        messageByte = (byte)serialPort.ReadByte();
                        if (messageByte == 255)
                        {
                            this.Invoke(new EventHandler(displayMessage));
                            messageByte = (byte)serialPort.ReadByte();
                        }
                        else if (messageByte == 10)
                        {
                            this.Invoke(new EventHandler(displayMessage));
                            this.Invoke(new EventHandler(newlineMessage));
                            break;
                        }
                        this.Invoke(new EventHandler(displayMessage));
                        message[byteIndexHeight, j] = messageByte;
                    }

                    this.Invoke(new EventHandler(displayJpegImage));
                    byteIndexHeight++;

                    if (byteIndexHeight >= (subCountY*subCountX))
                    {
                        byteIndexHeight = 0;
                        this.Invoke(new EventHandler(displayFullJpegImage));
                    }
                }
                
            }

            catch (TimeoutException) { }
            catch (Exception) { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rchtxtTerminal.Clear();
            for(int i = 0; i<height; i++)
            {
                for(int j = 0; j<(width*3); j++)
                {
                    message[i, j] = 0;
                }
            }
        }

        private void rchtxtTerminal_TextChanged(object sender, EventArgs e)
        {
            if(rchtxtTerminal.TextLength > 0)
            {
                btnSave.Enabled = true;
                btnClear.Enabled = true;
            }else
            {
                btnSave.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();

            foreach(string line in rchtxtTerminal.Lines)
            {
                temp.Add(line);
            }
            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = "GCSOutput.txt";
            saveDialog.Filter = "Text File | *.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                {
                    foreach (string line in temp.ToArray())
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            
            btnSave.Enabled = false;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = "D:\\";
            openDialog.FileName = "GCSOutput.txt";
            openDialog.Filter = "Text File | *.txt";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Process.Start("notepad.exe", openDialog.FileName);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            width = Convert.ToInt16(txtWidth.Text);
            height = Convert.ToInt16(txtHeight.Text);
            if(height % 8 == 0)
            {
                subCountY = Convert.ToInt16(height / subSize);
            }else
            {
                subCountY = Convert.ToInt16(height / subSize) + 1;
            }
            if(width % 8 == 0)
            {
                subCountX = Convert.ToInt16(width / subSize);
            }else
            {
                subCountX = Convert.ToInt16(width / subSize) + 1;
            }

            if (cmbbxMode.SelectedIndex == 0)
            {
                message = new byte[height, (width * 3)];
                selectedMode = 0;
            }else if(cmbbxMode.SelectedIndex == 1)
            {
                message = new byte[height, width];
                selectedMode = 1;
            }else if(cmbbxMode.SelectedIndex == 2)
            {
                message = new byte[(subCountY*subCountX),(Convert.ToInt16(Math.Pow(subSize,2)))];
                selectedMode = 2;
            }
            image = new Bitmap(200, 200);
        }
    }
}