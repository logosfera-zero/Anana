using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using ANANA.Properties;

namespace Cliente_FFMPEG
{
    class ayudanteConfiguracion
    {

        private string motorVideo;
        private bool audiovisual;
        private string entorno;
        private string carpetaExportaciones;
        string rutaFFMPEG;
        string rutaTEMPORAL;
        string rutaPLAY;


        public ayudanteConfiguracion()
        {
            this.motorVideo = ConfigurationManager.AppSettings["motorVideo"].ToString();
            this.carpetaExportaciones = ConfigurationManager.AppSettings["exportaciones"].ToString();
            this.entorno = ConfigurationManager.AppSettings["entorno"].ToString();
            this.rutaFFMPEG = ConfigurationManager.AppSettings["rutaFFMPEG"].ToString();
            this.rutaTEMPORAL = ConfigurationManager.AppSettings["rutaTEMPORAL"].ToString();
            this.rutaPLAY = ConfigurationManager.AppSettings["rutaPLAY"].ToString();

            if (this.entorno == "audiovisual")
            {
                this.audiovisual = true;
            } else
            {
                this.audiovisual = false;
            }


        }

        public string getCarpetaExportacion()
        {
            return this.carpetaExportaciones;
        }

        public string getMotorVideo()
        {
            return this.motorVideo;
        }

        public string getRutaFFMPEG()
        {
            return this.rutaFFMPEG;
        }

        public string getRutaTEMPORAL()
        {
            return this.rutaTEMPORAL;
        }

        public string getRutaPLAY()
        {
            return this.rutaPLAY;
        }

        public void setCarpetaExportacion(string ruta)
        {

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove("exportaciones");
            configuration.AppSettings.Settings.Add("exportaciones", ruta);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        

        public bool getAudiovisual()
        {
            return this.audiovisual;
        }


        public void setMotorVideo(string motor)
        {

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove("motorVideo");
            configuration.AppSettings.Settings.Add("motorVideo", motor);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


        public void tildarOpcionMenuMotorVideoCorrecta(string cambiarMotorA,ToolStripMenuItem software, ToolStripMenuItem nvidia,
            ToolStripMenuItem amd, ToolStripMenuItem intel)
        { 
            if (!cambiarMotorA.Equals("")) {
                this.motorVideo = cambiarMotorA;
                this.setMotorVideo(cambiarMotorA);
            }

            switch (this.motorVideo)
            {
                case "x264":
                    software.Checked = true;
                    nvidia.Checked = false;
                    amd.Checked = false;
                    intel.Checked = false;
                    break;
                case "NVENC":
                    software.Checked = false;
                    nvidia.Checked = true;
                    amd.Checked = false;
                    intel.Checked = false;
                    break;
                case "AMDAVC":
                    software.Checked = false;
                    nvidia.Checked = false;
                    amd.Checked = true;
                    intel.Checked = false;
                    break;
                case "INTELQS":
                    software.Checked = false;
                    nvidia.Checked = false;
                    amd.Checked = false;
                    intel.Checked = true;
                    break;
            }
        }



    }
}
