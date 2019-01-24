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
using AutoUpdaterDotNET;

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

            if (!anana_config.getAudiovisual())
            {
                chequeoVideo.Enabled = false;
            }

            AutoUpdater.Start("http://rbsoft.org/updates/AutoUpdaterTest.xml");
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
                String[] urlArchivo = archivoTratar.Split('\\');
                int ultimoSegmento = urlArchivo.Length - 1;
                String finalURL = urlArchivo[ultimoSegmento].Substring(0, urlArchivo[ultimoSegmento].Length - 4);
                String tipo = trabajo.SubItems[1].Text.ToString();
                etiquetaMensajes.Text = tipo;
                String parametro = trabajo.SubItems[2].Text.ToString();
                String llamadaFFMPEG = "";
                String rutaFFMPEG = anana_config.getRutaFFMPEG();
                String carpetaExportacion = anana_config.getCarpetaExportacion();
                String motorVideo = anana_config.getMotorVideo();
                String rutaTEMPORAL = anana_config.getRutaTEMPORAL();

                for (int i = 0; i < listaViewtrabajos.Items.Count; i++)
                {
                    listaViewtrabajos.Items[i].Selected = false;
                }


                listaViewtrabajos.Items[trabajosCorriendo].Selected = true;


                if (tipo == "Audio")
                {
                    switch(parametro)
                    {
                        case "MP3 en Calidad Liviana":
                            llamadaFFMPEG = " -y -i \"" + archivoTratar + "\" -acodec libmp3lame -b:a 96k -ac 2 -ar 48000 \"" + carpetaExportacion + "\\" + finalURL + ".mp3\"";
                            break;

                        case "MP3 en Calidad Alta":
                            llamadaFFMPEG = " -y -i \"" + archivoTratar + "\" -acodec libmp3lame -b:a 256k -ac 2 -ar 48000 \"" + carpetaExportacion + "\\" + finalURL + ".mp3\"";
                            break;

                        case "WAV para edición (Mejor calidad y 48Khz)":
                            llamadaFFMPEG = " -y -i \"" + archivoTratar + "\" -vn -ar 48000  \"" + carpetaExportacion + "\\" + finalURL + ".wav\"";
                            break;



                    }
                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);





                } else if (tipo == "Video")
                {
                    switch (parametro)
                    {

/*
 * 
 *   INTERNET + MOSCA
 * 
*/
                        case "Para subir a internet ( FB / Youtube ) + Mosca":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -c:v libx264  -b:v 8000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\VOD_" + finalURL + "_internet.mp4\"";
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -video_size 1920x1080 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset slow  -profile high -b:v 8M -bufsize 8M -maxrate 8M -bf 2 -g 150 -b 8M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\VOD_" + finalURL + "_internet.mp4\"";
                                    break;

                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 8000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\VOD_" + finalURL + "_internet.mp4\"";
                                    break;

                                case "AMDAVC":
                                    llamadaFFMPEG ="-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -vcodec h264_amf -preset slow -b:v 8000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\VOD_" + finalURL + "_internet.mp4\"";
                                    break;
                            }



                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;


/*
* 
*   INTERNET  (NO  MOSCA)
* 
*/

                        case "Para subir a internet ( FB / Youtube )":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -deinterlace -c:v libx264  -b:v 8000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_internet.mp4\"";
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -deinterlace -video_size 1920x1080 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset slow  -profile high -b:v 5M -bufsize 8M -maxrate 10M -bf 2 -g 150 -b 8M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_internet.mp4\"";
                                    break;

                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 8000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_internet.mp4\"";
                                    break;

                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -deinterlace -vcodec h264_amf -preset slow -b:v 8000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_internet.mp4\"";
                                    break;
                            }



                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;



                        /*
                         * 
                         *   CHAT + MOSCA 
                         * 
                         */
                        case "Para pasar por Chat ( Whatsapp / Telegram) + Mosca":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -vf scale=1280:720 -deinterlace -video_size 1280x720 -c:v libx264   -b:v 5000k  -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\"  -i \"C:\\DMAOPS\\ASSETS\\mosca720.png\" -filter_complex \"[0:v][1:v]overlay = 10:10 \" -c:v libx264  -b:v 1200k  -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -video_size 1280x720 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset medium  -profile high -b:v 5M -bufsize 5M -maxrate 5M -bf 2 -g 150 -b 5M -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca720.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10 \" -video_size 1280x720 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset slow  -profile main -b:v 1.2M -bufsize 1.2M -maxrate 1.2M -bf 2 -g 150 -b 1.2M -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;




                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset medium -b:v 5000K -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca720.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10 \" -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 1200K -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;








                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -vcodec h264_amf -preset slow -b:v 5000K -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca720.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10 \" -vcodec h264_amf -preset slow -b:v 1200K -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;
                            }
                           // Console.WriteLine("####### vamos a ejecutar asi");
                          //  Console.WriteLine(llamadaFFMPEG);
                          //  Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;



                        /*
                         * 
                         *   CHAT (SIN MOSCA) 
                         * 
                         */
                        case "Para pasar por Chat ( Whatsapp / Telegram)":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -vf scale=1280:720 -deinterlace 3-video_size 1280x720 -c:v libx264  -b:v 1200k  -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -video_size 1280x720 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset slow  -profile main -b:v 1.2M -bufsize 1.2M -maxrate 1.2-bf 2 -g 150 -b 0.8M -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    break;




                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 1200K -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                   break;








                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -vcodec h264_amf -preset slow -b:v 1200K -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + finalURL + "_chat.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                              
                                    break;
                            }
                            // Console.WriteLine("####### vamos a ejecutar asi");
                            //  Console.WriteLine(llamadaFFMPEG);
                            //  Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;




                        /*
                         * 
                         * MARCA DE AGUA
                         * 
                         */



                        case "Para mostrar a un tercero ( Marca de Agua )":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -vf scale=1280:720 -deinterlace -video_size 1280x720 -c:v libx264 -b:v 5000k  -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\"  -i \"C:\\DMAOPS\\ASSETS\\watermark720.png\" -filter_complex \"[0:v][1:v]overlay = 10:10 \" -c:v libx264 -b:v 1200k  -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_muestra.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -video_size 1280x720 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset medium  -profile high -b:v 5M -bufsize 5M -maxrate 5M -bf 2 -g 150 -b 5M -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\" -i \"C:\\DMAOPS\\ASSETS\\watermark720.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10 \" -video_size 1280x720 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset medium  -profile high -b:v 1.2M -bufsize 5M -maxrate 1.2M -bf 2 -g 150 -b 1.2M -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_muestra.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;




                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset medium -b:v 5000K -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\" -i \"C:\\DMAOPS\\ASSETS\\watermark720.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10 \" -look_ahead 0 -look_ahead_depth 0 -preset medium -b:v 1200K -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_muestra.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;








                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=1280:720 -deinterlace -vcodec h264_amf -preset slow -b:v 5000K -c:a aac -b:a 256k \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    llamadaFFMPEG = "-y -i \"" + rutaTEMPORAL + "\\" + finalURL + ".mp4" + "\" -i \"C:\\DMAOPS\\ASSETS\\watermark720.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10 \" -vcodec h264_amf -preset slow -b:v 1200K -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_muestra.mp4";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    Tramite.limpiarTemporales();
                                    break;
                            }
                            // Console.WriteLine("####### vamos a ejecutar asi");
                            //  Console.WriteLine(llamadaFFMPEG);
                            //  Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;



/*
 * 
 *  EDITAR EN ISLA DNXHD
 *  
 */

                        case "Para editar en Isla de Edición":

                            
                                
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -vcodec dnxhd -b:v 120M -s 1920x1080 -pix_fmt yuv422p -r 25 -c:a pcm_s16le -ar 48000 \"" + carpetaExportacion + "\\" + finalURL + "_DNxHD120.mov";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    
                            break;


                            /*
                             * 
                             * EDITARN EN PC MENOR DNXHD 36MBPS
                             * 
                             */



                        case "Para editar en una PC de Producción":



                            llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -vcodec dnxhd -b:v 36M -s 1920x1080 -pix_fmt yuv422p -r 25 -c:a pcm_s16le -ar 48000 \"" + carpetaExportacion + "\\" + finalURL + "_DNxHD36.mov";
                            Console.WriteLine("####### vamos a ejecutar asi");
                            Console.WriteLine(llamadaFFMPEG);
                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);

                            break;


                        /*
                         * 
                         * TRANSPORT STREAM
                         * 
                         */


                        case "Flujo de Transporte de Video ( TS )":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\"  -deinterlace -video_size 1920x1080 -c:v libx264  -b:v 20000k -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + finalURL + ".ts";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -deinterlace -video_size 1920x1080 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset slow  -profile high -b:v 20M -bufsize 5M -maxrate 21M -bf 2 -g 150 -b 20M -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + finalURL + ".ts";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    break;




                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 20000K -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + finalURL + ".ts";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                                    break;



                                   


                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -deinterlace -vcodec h264_amf -preset slow -b:v 20000K -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + finalURL + ".ts";
                                    Console.WriteLine("####### vamos a ejecutar asi");
                                    Console.WriteLine(llamadaFFMPEG);
                                    Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);

                                    break;
                            }
                      
                            break;



                        /*
                         * 
                         * H264 PARA ONDEMAND + MOSCA
                         * 
                         */

                        case "Para subir a OnDemand ( H264 ) + Mosca":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -c:v libx264 -b:v 20000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_VOD.mp4\"";
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -video_size 1920x1080 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset medium  -profile high -b:v 20M -bufsize 5M -maxrate 20M -bf 2 -g 150 -b 20M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_VOD.mp4\"";
                                    break;

                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 20000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_VOD.mp4\"";
                                    break;

                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -vcodec h264_amf -preset slow -b:v 20000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_VOD.mp4\"";
                                    break;
                            }



                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;





                        case "Bajar resolución a SD":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=853:480 -deinterlace -c:v libx264 -b:v 900k -profile:v high -level 4.1  -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_sd.mp4\"";
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=853:480 -deinterlace -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset medium  -profile high -b:v 0.9M -bufsize 5M -maxrate 0.5M -bf 2 -g 150 -b 0.5M -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_sd.mp4\"";
                                    break;

                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=853:480 -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 900K -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_sd.mp4\"";
                                    break;

                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf scale=853:480 -deinterlace -vcodec h264_amf -preset slow -b:v 900K -c:a aac -b:a 128k \"" + carpetaExportacion + "\\" + finalURL + "_sd.mp4\"";
                                    break;
                            }



                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;




                        case "Para subir a IGTV":

                           
                          llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -vf \"transpose = 1\"  \"" + carpetaExportacion + "\\" + finalURL + "_IGTV.mp4\"";
                             



                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;



                        case "Para fragmentar en videominutos (Instagram)":

                            llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -c copy -map 0 -segment_time 00:00:58 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + finalURL + "_INSTAGRAM_%03d.mp4\"";




                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;








                        case "Para resguardo en UNITV ( Archivo Histórico )":

                            switch (motorVideo)
                            {
                                case "x264":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -c:v libx264  -b:v 20000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_RAH.mp4\"";
                                    break;

                                case "NVENC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -video_size 1920x1080 -pix_fmt yuv420p -r 25 -c:v h264_nvenc -preset slow  -profile high -b:v 20M -bufsize 5M -maxrate 20M -bf 2 -g 150 -b 20M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_RAH.mp4\"";
                                    break;

                                case "INTELQS":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -look_ahead 0 -look_ahead_depth 0 -preset slow -b:v 20000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_RAH.mp4\"";
                                    break;

                                case "AMDAVC":
                                    llamadaFFMPEG = "-y -i \"" + archivoTratar + "\" -i \"C:\\DMAOPS\\ASSETS\\mosca.png\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" -deinterlace -vcodec h264_amf -preset slow -b:v 20000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + finalURL + "_RAH.mp4\"";
                                    break;
                            }



                            Tramite.ejecutar(llamadaFFMPEG, archivoTratar, etiquetaMensajes, barraDeProgreso);
                            break;
                    }
                    }

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

 
    }
}
