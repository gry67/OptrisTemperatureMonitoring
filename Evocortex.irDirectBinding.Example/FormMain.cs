using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evocortex.irDirectBinding.Example {
    public partial class FormMain : Form {

        //Instance of IrDirectInterface
        IrDirectInterface _irDirectInterface;
        //Thread for pulling images
        Thread _imageGrabberThread;
        bool _grabImages = true;

        //YeniForm için
        public ThermalPaletteImage termalGoruntu;
        public FormMain() {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            //Initialize IrDirectInterface from generic.xml file located in applictaion path
            _irDirectInterface = IrDirectInterface.Instance;
            _irDirectInterface.Connect("generic.xml");

            //Or connect with tcp-ip:
            //_irDirectInterface.Connect("localhost", 1337);


            //Add available OptrisColoringPalette to seletion
            _cmbPalette.Items.AddRange(Enum.GetNames(typeof(OptrisColoringPalette)));

            //Create thread for grabbing and display new images
            _imageGrabberThread = new Thread(new ThreadStart(ImageGrabberMethode));
            _imageGrabberThread.Start();
        }

        private void ImageGrabberMethode() {
            while (_grabImages) {
                //get the newest image, blocks till new image
                ThermalPaletteImage images = _irDirectInterface.GetThermalPaletteImage();
                
                termalGoruntu = images;
               

                //calculate min/max Temperature
                //Warning 
                ushort minTemp = ushort.MaxValue, maxTemp = ushort.MinValue;
                Point minTempIndex = new Point(), maxTempIndex = new Point();

                int rows = images.ThermalImage.GetLength(0);
                int columns = images.ThermalImage.GetLength(1);

                double mean = 0;
                for (int row = 0; row < rows; row++) {
                    for (int column = 0; column < columns; column++) {
                        ushort value = images.ThermalImage[row, column];
                        mean += value;
                    }
                }



                //Calculates mean value: meanSum / pixelCount
                mean /= (rows) * (columns);

                //convert to real temperature value
                mean = (mean - 1000.0) / 10.0;

                //Invoke UI-Thread for update of ui
                this.BeginInvoke((MethodInvoker)(() => {
                    _pbPaletteImage.Image = images.PaletteImage;
                    _labTemp.Text = $"Mean temperature is {mean}";
                }));
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            //stop image grabber thread
            _grabImages = false;

            //wait for finish thread
            _imageGrabberThread.Join(3000);

            //clean up
            _irDirectInterface.Disconnect();
        }

        private void _btnForceShutter_Click(object sender, EventArgs e) {
            //trigger one shutter cycle
            _irDirectInterface.TriggerShutterFlag();
        }

        private void _cmbPalette_SelectedIndexChanged(object sender, EventArgs e) {
            //change coloring palette on selected item
            _irDirectInterface.SetPaletteFormat(
                (OptrisColoringPalette)Enum.Parse(typeof(OptrisColoringPalette), (string)_cmbPalette.SelectedItem),
                OptrisPaletteScalingMethod.MinMax);
        }

     
        private void btnYeniForm_Click(object sender, EventArgs e)
        {
            var yeniForm = new YeniForm();

            yeniForm.mainForm = this;
            yeniForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var img = _irDirectInterface.GetThermalPaletteImage();

            //var data =  img.ThermalImage[100, 100];

            var d1 =  img.ThermalImage.GetUpperBound(0);
            var d2 =  img.ThermalImage.GetUpperBound(1);

            MessageBox.Show(d1+" "+ d2);
        }
    }
}
