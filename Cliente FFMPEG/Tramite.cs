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

using ANANA.Properties;

namespace Cliente_FFMPEG
{
    class Tramite
    {

        public static void ejecutar (String argumento, String rutaArchivo, Label etiquetaMensajes, ProgressBar barraDeProgreso)
        {
            String rutaFFMPEG = ConfigurationManager.AppSettings["rutaFFMPEG"].ToString();
            String rutaEXIF = ConfigurationManager.AppSettings["rutaEXIF"].ToString();
            String[] frame ;
            int frameActual = 0;
            int frameTotal = 0;





            Process procprobe = new System.Diagnostics.Process();

            procprobe.StartInfo.FileName = rutaEXIF;
            procprobe.EnableRaisingEvents = true;
            procprobe.StartInfo.CreateNoWindow = true;
            procprobe.StartInfo.Domain = "";
            procprobe.StartInfo.LoadUserProfile = false;
            procprobe.StartInfo.Password = null;
            procprobe.StartInfo.RedirectStandardError = true;
            procprobe.StartInfo.RedirectStandardOutput = true;
            procprobe.StartInfo.StandardErrorEncoding = null;
            procprobe.StartInfo.StandardOutputEncoding = null;
            procprobe.StartInfo.UserName = "";
            procprobe.StartInfo.UseShellExecute = false;
            procprobe.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            procprobe.StartInfo.WorkingDirectory = "C:\\DMAOPS\\TRABAJOS";
           // procprobe.StartInfo.Arguments = "-v error -count_frames -select_streams v:0 -show_entries stream=nb_read_frames -of default=nokey=1:noprint_wrappers=1 \"" + rutaArchivo + "\"";
            procprobe.StartInfo.Arguments = "-MediaDuration \"" + rutaArchivo + "\"";
            Console.WriteLine(procprobe.StartInfo.Arguments);
            procprobe.OutputDataReceived += new DataReceivedEventHandler(
            (s, e) =>
            {
                if (frameTotal == 0)
                {
                    try { 
                    String[] duracion_raw = e.Data.Substring(34).Split(':');
                    int fps = Tramite.obtenerFPS(rutaArchivo);
                    Console.WriteLine("#### que corno es el tiempo");
                    Console.WriteLine(duracion_raw[0]);
                    Console.WriteLine(duracion_raw[1]);
                    Console.WriteLine(duracion_raw[2]);
                    int segundos = Int32.Parse(duracion_raw[0]) * 3600 + Int32.Parse(duracion_raw[1]) * 60 + Int32.Parse(duracion_raw[2]);
                    frameTotal = segundos * fps + 1;
                    Console.WriteLine("##### El frametotal es: " + frameTotal.ToString());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Algun error impidió revisar la metadata");
                    }
                }
            }
        );


          
            procprobe.Start();
            procprobe.BeginOutputReadLine();
            procprobe.BeginErrorReadLine();
            procprobe.WaitForExit();
            procprobe.Close();
            procprobe.Dispose();
            


            Process procesador = new System.Diagnostics.Process();
            procesador.StartInfo.FileName = rutaFFMPEG;
            procesador.StartInfo.Arguments = argumento;
            procesador.EnableRaisingEvents = true;
            procesador.StartInfo.CreateNoWindow = true;
            procesador.StartInfo.Domain = "";
            procesador.StartInfo.LoadUserProfile = false;
            procesador.StartInfo.Password = null;
            procesador.StartInfo.RedirectStandardError = true;
            procesador.StartInfo.RedirectStandardOutput = true;
            procesador.StartInfo.StandardErrorEncoding = null;
            procesador.StartInfo.StandardOutputEncoding = null;
            procesador.StartInfo.UserName = "";
            procesador.StartInfo.UseShellExecute = false;
            procesador.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            procesador.StartInfo.WorkingDirectory = "C:\\DMAOPS\\TRABAJOS";




           
            procesador.OutputDataReceived += new DataReceivedEventHandler(
            (s, a) =>
            {
                etiquetaMensajes.Text = a.Data;
                if (a.Data != null)
                {
                    if (a.Data.ToString().Length > 6)
                    {
                        if (a.Data.Substring(0, 5) == "frame=")
                        {
                            frame = a.Data.Split('=');
                            try
                            {
                                frameActual = Int32.Parse(frame[1].Substring(0, frame[1].Length - 3));
                                barraDeProgreso.Value = frameActual * 100 / frameTotal;

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se pudo obtener el frame actual");
                            }


                        }
                    }
                }
            }
        );

            
            procesador.ErrorDataReceived += new DataReceivedEventHandler(
            (s, a) =>
            {

               etiquetaMensajes.Text = a.Data;

                try
                {
                    frame = a.Data.Split('=');
                    frameActual = Int32.Parse(frame[1].Substring(0, frame[1].Length - 3));
                    barraDeProgreso.Value = frameActual * 100 / frameTotal;

                }
                catch (Exception)
                {
                    Console.WriteLine("No se pudo obtener el frame actual");
                }

               

                


            }
        );
            
           
               



            procesador.Start();
            procesador.BeginOutputReadLine();
            procesador.BeginErrorReadLine();
            procesador.WaitForExit();
            procesador.Close();
            procesador.Dispose();


            //  Console.WriteLine(rutaFFMPEG + " " + argumento);

        }


    public static void limpiarTemporales()
        {
            String rutaTEMPORAL = ConfigurationManager.AppSettings["rutaTEMPORAL"].ToString();
            Process borrador = new System.Diagnostics.Process();

            borrador.StartInfo.FileName = "cmd.exe";
            borrador.EnableRaisingEvents = true;
            borrador.StartInfo.CreateNoWindow = true;
            borrador.StartInfo.Domain = "";
            borrador.StartInfo.LoadUserProfile = false;
            borrador.StartInfo.Password = null;
            borrador.StartInfo.RedirectStandardError = true;
            borrador.StartInfo.RedirectStandardOutput = true;
            borrador.StartInfo.StandardErrorEncoding = null;
            borrador.StartInfo.StandardOutputEncoding = null;
            borrador.StartInfo.UserName = "";
            borrador.StartInfo.UseShellExecute = false;
            borrador.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            borrador.StartInfo.WorkingDirectory = "C:\\DMAOPS\\TRABAJOS";
            borrador.StartInfo.Arguments = "/c del /Q " + rutaTEMPORAL;
            Console.WriteLine(borrador.StartInfo.Arguments);
            

            borrador.Start();
            borrador.BeginOutputReadLine();
            borrador.BeginErrorReadLine();
            borrador.WaitForExit();
            borrador.Close();
            borrador.Dispose();

        }



        public static int obtenerFPS(String rutaArchivo)
        {
            String rutaEXIF = ConfigurationManager.AppSettings["rutaEXIF"].ToString();
            Process borrador = new System.Diagnostics.Process();
            int framerate = 0;

            borrador.StartInfo.FileName = rutaEXIF;
            borrador.EnableRaisingEvents = true;
            borrador.StartInfo.CreateNoWindow = true;
            borrador.StartInfo.Domain = "";
            borrador.StartInfo.LoadUserProfile = false;
            borrador.StartInfo.Password = null;
            borrador.StartInfo.RedirectStandardError = true;
            borrador.StartInfo.RedirectStandardOutput = true;
            borrador.StartInfo.StandardErrorEncoding = null;
            borrador.StartInfo.StandardOutputEncoding = null;
            borrador.StartInfo.UserName = "";
            borrador.StartInfo.UseShellExecute = false;
            borrador.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            borrador.StartInfo.WorkingDirectory = "C:\\DMAOPS\\TRABAJOS";
            borrador.StartInfo.Arguments = "-VideoFrameRate \"" + rutaArchivo + "\"";
            Console.WriteLine(borrador.StartInfo.Arguments);




            borrador.OutputDataReceived += new DataReceivedEventHandler(
            (s, e) =>
            {
               
                if (framerate == 0)
                {
                    try
                    {
                        framerate = Int32.Parse(e.Data.Substring(34));

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo obtener el frame rate" + e.Data);
                    }
                }
                            
                           


                        }
                    
                
            
        );


            borrador.ErrorDataReceived += new DataReceivedEventHandler(
            (s, e) =>
            {


                if (framerate == 0)
                {
                    try
                    {
                        framerate = Int32.Parse(e.Data.Substring(34));

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No se pudo obtener el frame rate" + e.Data);
                    }
                }

            }






            
        );






            borrador.Start();
            borrador.BeginOutputReadLine();
            borrador.BeginErrorReadLine();
            borrador.WaitForExit();
            borrador.Close();
            borrador.Dispose();
            return framerate;

        }
    }
}
