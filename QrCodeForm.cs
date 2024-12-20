using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    public partial class QrCodeForm : Form
    {
        public QrCodeForm()
        {
            InitializeComponent();
            GenerateQRCode();
        }

        private void GenerateQRCode()
        {
            string url = "https://docs.google.com/forms/d/e/1FAIpQLSeYks_tkuSQ3POZcM4uZ1wzIIFRWixJfC1hIffqvvC5adBj8Q/viewform?usp=dialog";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(3);

            qrCodePictureBox.Image = qrCodeImage;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void QrCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}

