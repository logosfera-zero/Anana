using System;
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
//using AutoUpdaterDotNET;

namespace Cliente_FFMPEG
{
    public partial class Form1 : Form
    {

        ayudanteConfiguracion anana_config;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += panel1_DragEnter;
            this.DragDrop += panel1_DragDrop;
            
        }


        // EVENTO BOTÓN "AGREGAR"
        private void botonAgregar_Click(object sender, EventArgs e)
        {

            // No hacer nada si no hay ningún tipo de operación seleccionado
            if (chequeoVideo.CheckedItems.Count == 0 && chequeoAudio.CheckedItems.Count == 0)
            {

                etiquetaMensajes.ForeColor = System.Drawing.Color.Red;
                etiquetaMensajes.Text = "POR FAVOR, ELIJA QUE TIPO DE OPERACIÓN REALIZAR PRIMERO";
            }
            // Mostrar el diálogo de selección de archivos, si hay operación(es)
            else
            {
                etiquetaMensajes.ForeColor = System.Drawing.SystemColors.ControlText;
                etiquetaMensajes.Text = "...";

                openFileDialogo.ShowDialog();

            }
        }


        // EVENTO ARCHIVO(s) SELECCIONADO(s) EN EL DIALOGO DE SELECCIÓN
        private void openFileDialogo_FileOk(object sender, CancelEventArgs e)
        {

            // Por cada archivo seleccionado 
            foreach (String archivo in openFileDialogo.FileNames)
            {

                ayudanteItemsEnColaTrabajo.agregarItemsProcesamiento(archivo, listaViewtrabajos, chequeoVideo, chequeoAudio, etiquetaMensajes);

            }

        }


        // EVENTO BOTÓN "QUITAR"
        private void botonQuitar_Click(object sender, EventArgs e)
        {

            if (listaViewtrabajos.SelectedItems != null)
            {

                foreach (ListViewItem item in listaViewtrabajos.SelectedItems)
                {
                    listaViewtrabajos.Items.Remove(item);
                }
            }
        }








        private void Form1_Load(object sender, EventArgs e)
        {
            this.anana_config = new ayudanteConfiguracion();

            

            folderBrowserDialog1.SelectedPath = anana_config.getCarpetaExportacion();


            anana_config.tildarOpcionMenuMotorVideoCorrecta("",softwareX264ToolStripMenuItem, hardwareNvidiaNvencToolStripMenuItem, hardwareAMDATIVCEToolStripMenuItem, hardwareIntelQuickSyncToolStripMenuItem);
            anana_config.tildarOpcionMenuLenguajeCorrecta("", españolToolStripMenuItem, inglesToolStripMenuItem);

            if (!anana_config.getAudiovisual())
            {
                chequeoVideo.Enabled = false;
            }

           // AutoUpdater.Start("https://www.logos.net.ar/images/software/actualizacion/anana.xml");
        }

        

        private void carpetaDeExportaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {

                anana_config.setCarpetaExportacion(folderBrowserDialog1.SelectedPath.ToString());

            }




        }





        private void botonComenzar_Click(object sender, EventArgs e)
        {
            int trabajosCorriendo = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (ListViewItem trabajo in listaViewtrabajos.Items)
            {

             
                Console.WriteLine("EJECUTANDO ESTO POR VEZ NRO " + trabajosCorriendo.ToString());
                String archivoTratar = trabajo.SubItems[0].Text.ToString();  
                String tipo = trabajo.SubItems[1].Text.ToString();
                String scan = trabajo.SubItems[3].Text.ToString();
                etiquetaMensajes.Text = tipo;
                String parametro = trabajo.SubItems[2].Text.ToString();
                String llamadaFFMPEG = "";
                String rutaFFMPEG = anana_config.getRutaFFMPEG();
                String carpetaExportacion = anana_config.getCarpetaExportacion();
      

                // Limpiar la seleccion de trabajos y activar la actual
                for (int i = 0; i < listaViewtrabajos.Items.Count; i++)
                {
                    listaViewtrabajos.Items[i].Selected = false;
                }
                listaViewtrabajos.Items[trabajosCorriendo].Selected = true;


                if (tipo.Equals("Video"))
                {
                    llamadaFFMPEG = ayudanteParametrizadorffmpeg.textoArgumentoFfmpeg(archivoTratar, parametro, scan, chequeoVideo, anana_config);
                } else if (tipo.Equals("Audio")) {
                    llamadaFFMPEG = ayudanteParametrizadorffmpeg.textoArgumentoFfmpegAudio(archivoTratar, parametro, scan, chequeoAudio, anana_config);

                }
                Console.WriteLine("======================================================");
                Console.WriteLine(llamadaFFMPEG);
                Console.WriteLine("======================================================");
                Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);


                trabajosCorriendo++;
                
            }

            etiquetaMensajes.ForeColor = System.Drawing.Color.Blue;
            etiquetaMensajes.Text = "TERMINAMOS DE PROCESAR TODA LA COLA DE TRABAJO";
        }






        /*
         * 
         * CONFIGURACION DEL MOTOR DE VIDEO
         * 
         */
        private void softwareX264ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anana_config.tildarOpcionMenuMotorVideoCorrecta("x264", softwareX264ToolStripMenuItem, hardwareNvidiaNvencToolStripMenuItem, hardwareAMDATIVCEToolStripMenuItem, hardwareIntelQuickSyncToolStripMenuItem);
        }

        private void hardwareNvidiaNvencToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anana_config.tildarOpcionMenuMotorVideoCorrecta("NVENC", softwareX264ToolStripMenuItem, hardwareNvidiaNvencToolStripMenuItem, hardwareAMDATIVCEToolStripMenuItem, hardwareIntelQuickSyncToolStripMenuItem);
        }

        private void hardwareIntelQuickSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
             anana_config.tildarOpcionMenuMotorVideoCorrecta("INTELQS", softwareX264ToolStripMenuItem, hardwareNvidiaNvencToolStripMenuItem, hardwareAMDATIVCEToolStripMenuItem, hardwareIntelQuickSyncToolStripMenuItem);
        }

        private void hardwareAMDATIVCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anana_config.tildarOpcionMenuMotorVideoCorrecta("AMDAVC", softwareX264ToolStripMenuItem, hardwareNvidiaNvencToolStripMenuItem, hardwareAMDATIVCEToolStripMenuItem, hardwareIntelQuickSyncToolStripMenuItem);
        }


      




        /*
         * 
         * DRAG AND DROP
         * 
         */
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {

            ayudanteItemsEnColaTrabajo.tareasDrop(listaViewtrabajos, chequeoVideo, chequeoAudio, etiquetaMensajes, sender, e);
        }



        private void listaViewtrabajos_DragDrop(object sender, DragEventArgs e)
        {
            ayudanteItemsEnColaTrabajo.tareasDrop(listaViewtrabajos, chequeoVideo, chequeoAudio, etiquetaMensajes, sender, e);

        }




        /*
         * DRAG ENTER
         */
        private void listaViewtrabajos_DragEnter(object sender, DragEventArgs e)
        {
            ayudanteItemsEnColaTrabajo.tareasDragEnter(sender, e);

        }


        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            ayudanteItemsEnColaTrabajo.tareasDragEnter(sender, e);
        }





        /*
         * VISTA PREVIA
         */
        private void reproducirVideo(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'r')
            {
                Process firstProc = new Process();
                firstProc.StartInfo.FileName = anana_config.getRutaPLAY();
                firstProc.StartInfo.Arguments = " -x 853 -y 480 -stats -window_title \"ANANA REPRODUCIENDO: "+ listaViewtrabajos.SelectedItems[0].SubItems[0].Text.ToString() + " \"  -i \"" + listaViewtrabajos.SelectedItems[0].SubItems[0].Text.ToString() + "\" -stats ";
                firstProc.EnableRaisingEvents = true;
                Console.WriteLine(firstProc.StartInfo.FileName);
                firstProc.Start();

                firstProc.WaitForExit();
            }
        }

        /*
         * NO SE USAN 
         */


        private void chequeoVideo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void codificadorDeVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listaViewtrabajos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chequeoVideo_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void chequeoAudio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anana_config.tildarOpcionMenuLenguajeCorrecta("es", españolToolStripMenuItem, inglesToolStripMenuItem);
            etiquetaMensajes.Text = "Debe reiniciar Anana para que los cambios del idioma tengan efecto";
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anana_config.tildarOpcionMenuLenguajeCorrecta("en", españolToolStripMenuItem, inglesToolStripMenuItem);
            etiquetaMensajes.Text = "You must reset Anana in order to changes take effect";
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
