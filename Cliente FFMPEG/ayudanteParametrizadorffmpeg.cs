using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Threading.Tasks;

namespace Cliente_FFMPEG
{
    class ayudanteParametrizadorffmpeg
    {


        public static string textoArgumentoFfmpeg(string urlArchivo, string parametroListado, string escan, CheckedListBox listadoTareasVideo, ayudanteConfiguracion anana_config)
        {

            string[] segmentosUrlArchivo = urlArchivo.Split('\\');
            int nroUltSegUrl = segmentosUrlArchivo.Length - 1;
            string nombreArchivoConExtension = segmentosUrlArchivo[nroUltSegUrl];
            string nombreArchivoSinExtension = nombreArchivoConExtension.Substring(0, nombreArchivoConExtension.Length - 4);
            string llamadaFFMPEG = "";

            String rutaFFMPEG = anana_config.getRutaFFMPEG();
            String carpetaExportacion = anana_config.getCarpetaExportacion();
            String motorVideo = anana_config.getMotorVideo();
            String rutaTEMPORAL = anana_config.getRutaTEMPORAL();
            String fps = ConfigurationManager.AppSettings["fpsExports"].ToString();
            fps = "-r " + fps;

            // ONDEMAND
            if (parametroListado.Equals(listadoTareasVideo.Items[0].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 18000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension,"VOD") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 18M -bufsize 8M -maxrate 18M -bf 2 -g 150 -b 18M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "VOD") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 18000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "VOD") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 18000K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "VOD") + ".mp4\"";
                        break;
                }
            }

            // YOUTUBE
            if (parametroListado.Equals(listadoTareasVideo.Items[1].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 15000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "YT") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 15M -bufsize 8M -maxrate 15M -bf 2 -g 150 -b 18M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "YT") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 15000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "YT") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 15000K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\YT - " + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "YT") + ".mp4\"";
                        break;
                }
            }

            // FACEBOOK
            if (parametroListado.Equals(listadoTareasVideo.Items[2].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 8000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "FB") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 8M -bufsize 8M -maxrate 8M -bf 2 -g 150 -b 8M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "FB") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 8000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "FB") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 8000K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "FB") + ".mp4\"";
                        break;
                }
            }

            // TWITTER
            if (parametroListado.Equals(listadoTareasVideo.Items[3].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -video_size 1280x720 -c:v libx264 " + fps + " -b:v 2000k -profile:v high -level 4.1 -c:a aac -b:a 256k -map 0 -segment_time 00:02:19 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "TW") + "_%03d.mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -video_size 1280x720 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 2M -bufsize 8M -maxrate 2M -bf 2 -g 150 -b 2M -c:a aac -b:a 256k -map 0 -segment_time 00:02:19 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "TW") + "_ %03d.mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 2000K -c:a aac -b:a 256k -map 0 -segment_time 00:02:19 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "TW") + "_ %03d.mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -vcodec h264_amf -preset slow " + fps + " -b:v 2000K -c:a aac -b:a 256k -map 0 -segment_time 00:02:19 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "TW") + "_ %03d.mp4\"";
                        break;
                }
            }

            // IGTV
            if (parametroListado.Equals(listadoTareasVideo.Items[4].ToString()))
            {
                llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"transpose = 1\"  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "IGTV") + ".mp4\"";

            }

            // INSTAGRAM
            if (parametroListado.Equals(listadoTareasVideo.Items[5].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -video_size 1280x720 -c:v libx264 " + fps + " -b:v 2500k  -c:a aac -b:a 128k -map 0 -segment_time 00:00:57 -f segment -reset_timestamps 1 \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "IG") + "_%03d.mp4";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -video_size 1280x720 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 2.5M -bufsize 2M -maxrate 2.5M -bf 2 -g 150 -b 2.5M -c:a aac -b:a 128k -map 0 -segment_time 00:00:57 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "IG") + "_%03d.mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 2500K -c:a aac -b:a 128k -map 0 -segment_time 00:00:57 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "IG") + "_%03d.mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\" " + interlacedArg(escan) + " -vcodec h264_amf -preset slow " + fps + " -b:v 2500K -c:a aac -b:a 128 -map 0 -segment_time 00:00:57 -f segment -reset_timestamps 1  \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "IG") + "_%03d.mp4\"";
                        break;
                }
            }

            // WHATSAPP O TELEGRAM
            // @TODO El maximo tamaño deberia ir en algun lugar mas normalizado, tipo en la config
            if (parametroListado.Equals(listadoTareasVideo.Items[6].ToString()))
            {

                // Todos estos calculos es para obtener el bitrate en Kb/s
                // maximo posible segun el tamaño
                // Si el limite esta muy por arriba
                int duracionMs = Tramite.duracion(urlArchivo);
                Console.WriteLine("La duracion es " + duracionMs);
                double duracionsegDouble = duracionMs / 1000;
                double duracionSeg = Math.Round(duracionsegDouble, 0); ;
                double maximoTamanioMB = 64.0; // EL MAXIMO TAMAÑO DE WHATSAPP

                // Si la duracion es menor de 2 minutos (7Megas)
                if (duracionSeg <= 120)
                {
                    maximoTamanioMB = 8.0;
                }

                // Si la duracion es mayor de 3 minutos y menor de 4 minutos
                if (duracionSeg > 120 && duracionSeg <= 240)
                {
                    maximoTamanioMB = 15.0;
                }

                // Si la duracion es mayor de 4 minutos y menor de 6 minutos
                if (duracionSeg > 240 && duracionSeg <= 360)
                {
                    maximoTamanioMB = 20.0;
                }

                // Si la duracion es mayor de 6 minutos y menor de 8 minutos
                if (duracionSeg > 360 && duracionSeg <= 480)
                {
                    maximoTamanioMB = 28.0;
                }

                // Si la duracion es mayor de 8 minutos y menor de 10 minutos
                if (duracionSeg > 480 && duracionSeg <= 600)
                {
                    maximoTamanioMB = 36.0;
                }

                // Si la duracion es mayor de 10 minutos y menor de 15 minutos
                if (duracionSeg > 600 && duracionSeg <= 900)
                {
                    maximoTamanioMB = 42.0;
                }

                // Si la duracion es mayor de 15 minutos y menor de 20 minutos
                if (duracionSeg > 900 && duracionSeg <= 1200)
                {
                    maximoTamanioMB = 64.0;
                }

                // Si la duracion es mayor de 20 minutos
                if (duracionSeg > 1200)
                {
                    maximoTamanioMB = 64.0;
                }

                // Calculo para llegar al bitrate optimo segun el tamaño especificado
                double bitrateKbFijoAudio = 96.0;
                double tamanioAudioKb = bitrateKbFijoAudio * duracionSeg;
                double tamanioAudioMb = tamanioAudioKb / 1000.0;
                double tamanioAudioMB = tamanioAudioMb / 8.0;

                double maximoTamanioMb = (maximoTamanioMB - tamanioAudioMB) * 8.0;
                Console.WriteLine("El duracionSeg es: " + duracionSeg);
                Console.WriteLine("El maximoTamanioMb es: " + maximoTamanioMb);
                double maximobitRateMb = maximoTamanioMb / duracionSeg;

                Console.WriteLine("El maximobitRateMb es: " + maximobitRateMb);

                maximobitRateMb = Math.Round(maximobitRateMb, 2);

                double maximobitRateKbDouble = maximobitRateMb * 1000.0;
                int maximobitRateKb = (int)Math.Round(maximobitRateKbDouble, 0);

                string bitrate = maximobitRateKb + "k";



                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v " + bitrate + "  -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "CHAT") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\"  " + interlacedArg(escan) + " -video_size 1280x720 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile main -b:v " + bitrate + " -bufsize 8M -maxrate " + bitrate + " -bf 2 -g 150 -b " + bitrate + " -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "CHAT") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\"  " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v " + bitrate + " -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "CHAT") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale = 1280:720\"  " + interlacedArg(escan) + " -vcodec h264_amf -preset slow " + fps + " -b:v " + bitrate + " -c:a aac -b:a 96k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "CHAT") + ".mp4\"";
                        break;
                }
            }

            // MOSCA
            if (parametroListado.Equals(listadoTareasVideo.Items[7].ToString()))
            {
                string rutaMosca = ConfigurationManager.AppSettings["rutaMosca"].ToString();

                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMosca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 18000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "VOD") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMosca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 18M -bufsize 8M -maxrate 18M -bf 2 -g 150 -b 18M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "VOD") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMosca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 18000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "VOD") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMosca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 18000K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "VOD") + ".mp4\"";
                        break;
                }
            }

            // MARCA DE AGUA
            if (parametroListado.Equals(listadoTareasVideo.Items[8].ToString()))
            {
                string rutaMarca = ConfigurationManager.AppSettings["rutaMarca"].ToString();

                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMarca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 5000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PREV") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMarca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 5M -bufsize 8M -maxrate 5M -bf 2 -g 150 -b 5M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PREV") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMarca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 5000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PREV") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -i \"" + rutaMarca + "\"  -filter_complex \"[0:v][1:v]overlay = 10:10\" " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 5000K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PREV") + ".mp4\"";
                        break;
                }
            }

            // DNxHD 120
            if (parametroListado.Equals(listadoTareasVideo.Items[9].ToString()))
            {
                llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vcodec dnxhd -b:v 120M -s 1920x1080 -pix_fmt yuv422p " + fps + " -c:a pcm_s16le -ar 48000 \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "DNxHD_120") + ".mov\"";
            }

            // DNxHD 36
            if (parametroListado.Equals(listadoTareasVideo.Items[10].ToString()))
            {
                llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vcodec dnxhd -b:v 36M -s 1920x1080 -pix_fmt yuv422p " + fps + " -c:a pcm_s16le -ar 48000 \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "DNxHD_36") + ".mov\"";
            }

            // H264 Edicion
            if (parametroListado.Equals(listadoTareasVideo.Items[11].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 20000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "EDIT") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 20M -bufsize 8M -maxrate 20M -bf 2 -g 150 -b 20M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "EDIT") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 20000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "EDIT") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 20000K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "EDIT") + ".mp4\"";
                        break;
                }
            }

            // TS
            if (parametroListado.Equals(listadoTareasVideo.Items[12].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 20000k -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".ts\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc " + fps + " -preset slow  -profile high -b:v 20M -bufsize 5M -maxrate 21M -bf 2 -g 150 -b 20M -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".ts\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 20000K -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".ts\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 20000K " + fps + " -c:a aac -b:a 256k -bsf:v h264_mp4toannexb -f mpegts \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".ts\"";
                        break;
                }
            }

            // SD
            if (parametroListado.Equals(listadoTareasVideo.Items[13].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  -vf \"scale=854:480\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 1500k  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "SD") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale=854:480\" " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 1.5M -bufsize 8M -maxrate 1.5M -bf 2 -g 150 -b 1.5M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "SD") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale=854:480\" " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 1500K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "SD") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -vf \"scale=854:480\" " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 1500K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "SD") + ".mp4\"";
                        break;
                }
            }

            // PAL
            if (parametroListado.Equals(listadoTareasVideo.Items[14].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  -filter:v \"pad = iw:iw * 3 / 4:(ow - iw) / 2:(oh - ih) / 2,scale = 720:576\" " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 2500k -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PAL") + ".mp4\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -filter:v \"pad = iw:iw * 3 / 4:(ow - iw) / 2:(oh - ih) / 2,scale = 720:576\" " + interlacedArg(escan) + " -video_size 720x576 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 2.5M -bufsize 8M -maxrate 2.5M -bf 2 -g 150 -b 2.5M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PAL") + ".mp4\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -filter:v \"pad = iw:iw * 3 / 4:(ow - iw) / 2:(oh - ih) / 2,scale = 720:576\" " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 2500K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PAL") + ".mp4\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\" -filter:v \"pad = iw:iw * 3 / 4:(ow - iw) / 2:(oh - ih) / 2,scale = 720:576\" " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 2500K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PAL") + ".mp4\"";
                        break;
                }
            }

            // H264 Edicion
            if (parametroListado.Equals(listadoTareasVideo.Items[15].ToString()))
            {
                switch (motorVideo)
                {
                    case "x264":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -c:v libx264 " + fps + " -b:v 25000k -profile:v high -level 4.1  -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PGM") + ".mov\"";
                        break;

                    case "NVENC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -video_size 1920x1080 -pix_fmt yuv420p -c:v h264_nvenc -preset slow " + fps + " -profile high -b:v 25M -bufsize 15M -maxrate 25M -bf 2 -g 150 -b 25M -c:a aac -b:a 256k \"" + carpetaExportacion + "\\PGM - " + nombreArchivoSinExtension + ".mov\"";
                        break;

                    case "INTELQS":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_qsv -look_ahead_depth 0 -preset slow " + fps + " -b:v 25000K -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PGM") + ".mov\"";
                        break;

                    case "AMDAVC":
                        llamadaFFMPEG = "-y -i \"" + urlArchivo + "\"  " + interlacedArg(escan) + " -vcodec h264_amf -preset slow -b:v 25000K " + fps + " -c:a aac -b:a 256k \"" + carpetaExportacion + "\\" + nuevoNombreDelArchivo(nombreArchivoSinExtension, "PGM") + ".mov\"";
                        break;
                }
                      }

            return llamadaFFMPEG;
        }


        public static string textoArgumentoFfmpegAudio(string urlArchivo, string parametroListado, string escan, CheckedListBox listadoTareasAudio, ayudanteConfiguracion anana_config)
        {

            string[] segmentosUrlArchivo = urlArchivo.Split('\\');
            int nroUltSegUrl = segmentosUrlArchivo.Length - 1;
            string nombreArchivoConExtension = segmentosUrlArchivo[nroUltSegUrl];
            string nombreArchivoSinExtension = nombreArchivoConExtension.Substring(0, nombreArchivoConExtension.Length - 4);
            string llamadaFFMPEG = "";

            String rutaFFMPEG = anana_config.getRutaFFMPEG();
            String carpetaExportacion = anana_config.getCarpetaExportacion();




            if (parametroListado.Equals(listadoTareasAudio.Items[0].ToString()))
            {
                llamadaFFMPEG = " -y -i \"" + urlArchivo + "\" -acodec libmp3lame -b:a 96k -ac 2 -ar 48000 \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".mp3\"";

            }

            if (parametroListado.Equals(listadoTareasAudio.Items[1].ToString()))
            {
                llamadaFFMPEG = " -y -i \"" + urlArchivo + "\" -acodec libmp3lame -b:a 256k -ac 2 -ar 48000 \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".mp3\"";

            }

            if (parametroListado.Equals(listadoTareasAudio.Items[2].ToString()))
            {
                llamadaFFMPEG = " -y -i \"" + urlArchivo + "\" -vn -ar 48000  \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".wav\"";

            }

            if (parametroListado.Equals(listadoTareasAudio.Items[3].ToString()))
            {
                llamadaFFMPEG = " -y -i \"" + urlArchivo + "\" -vn -ar 44100  \"" + carpetaExportacion + "\\" + nombreArchivoSinExtension + ".wav\"";

            }


            return llamadaFFMPEG;




        }




        public static string interlacedArg(string escan)
        {
            if (escan.Equals("Entrelazado"))
            {
                return "-vf yadif";
            }

            else if (escan.Equals("Progresivo"))
            {
                return "";
            } else
            {
                return "";
            }
        }




        public static string nuevoNombreDelArchivo(string nombreArchivoSinExtension, string nuevoPrefijo)
        {
            if (nombreArchivoSinExtension.Substring(0, 6).Equals("PGM - "))
            {
                return nuevoPrefijo + " - " + nombreArchivoSinExtension.Substring(6);
            }

            else if (nombreArchivoSinExtension.Substring(0, 6).Equals(nuevoPrefijo))
            {
                return "REVISAR - " + nuevoPrefijo + " - " + nombreArchivoSinExtension;
            }
            else
            {
                return nuevoPrefijo + " - " + nombreArchivoSinExtension;
            }
        }


    }

    
}

