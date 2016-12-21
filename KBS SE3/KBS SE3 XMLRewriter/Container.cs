using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLRewriter.Core;

namespace XMLRewriter {
    public partial class Container : Form {
        public Container() {
            InitializeComponent();
            fileSettingsContainer.SetHeaderText("File");
            convertContainer.SetHeaderText("Convert Details");
        }

        private void browseFileBtn_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select XML File";
            dialog.Filter = "XML Files|*.xml|OSM Files|*.osm";
            dialog.InitialDirectory = @"C:\";
            if(dialog.ShowDialog() == DialogResult.OK) {
                fileLocationBox.Text = dialog.FileName;
                destinationFileSelectBtn.Enabled = true;
            }    
        }

        private void destinationFileSelectBtn_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK) {
                fileDestinationBox.Text = dialog.SelectedPath;
                convertBtn.Enabled = true;
            }
        }

        private void convertBtn_Click(object sender, EventArgs e) {
            XMLFileReader reader = new XMLFileReader(fileLocationBox.Text, fileDestinationBox.Text, outputNameBox.Text);
            reader.DataLog = convertDataLog;
            reader.StatusBar = convertStatusBar;
            convertBtn.Enabled = false;
            reader.convert();
        }
    }
}
