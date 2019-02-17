using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cliente_FFMPEG
{
    public class ayudanteItemsEnColaTrabajo
    {

        /*
         * Esta función llamada desde el formulario incorporará mediante otras f aux
         * el archivo pasado como parametro, según tenga los procesos indicados
         * cada archivo terminará agrupado según corresponda, y el grupo se creará si es necesario.
         */
        public static void agregarItemsProcesamiento(String archivo, ListView listaViewtrabajos,
                    CheckedListBox chequeoVideo, CheckedListBox chequeoAudio, Label etiquetaMensajes)
        {

          


            
        //variables requeridas para cada ejecución del bucle
        String[] urlArchivo = archivo.Split('\\');
        string escan = Tramite.esEntrelazado(archivo);
        ListViewGroup grupo = obtenerGrupoExistente(etiquetaMensajes, listaViewtrabajos, urlArchivo);

        incorporarProcesosChequeadosDeArchivoEnCola("Video",chequeoVideo, listaViewtrabajos, archivo, grupo, escan);
        incorporarProcesosChequeadosDeArchivoEnCola("Audio",chequeoAudio, listaViewtrabajos, archivo, grupo, "N/A");





  


        }


        /*
         * Incorpora en la cola de procesamiento según archivo y grupo indicado, 
         * los procesos de la lista pasados. Generico para audio o video
         */
        private static void incorporarProcesosChequeadosDeArchivoEnCola(String tipo,CheckedListBox lista, ListView listaViewtrabajos, String archivo, ListViewGroup grupoSeleccionado,string escan)
        {

            if (lista.CheckedItems != null)
            {
                foreach (String procesoSelec in lista.CheckedItems)
                {
                    // Por cada proceso seleccionado para hacer
                    // se agregan todos los datos necesarios y se incorporan al grupo
                    // de la lista de procesos
                    

                    String[] fila = { archivo, tipo, procesoSelec,escan };
                    var listViewItem = new ListViewItem(fila, grupoSeleccionado);
                    listaViewtrabajos.Items.Insert(listaViewtrabajos.Items.Count, listViewItem);
                    
                }
            }


            // Luego de crear los items de la cola de trabajo
            // se deseleccionan todos los procesos de audio y video
            // para dejar limpia la interface
            /*
            for (int i = 0; i < lista.Items.Count; i++)
            {
                lista.SetItemCheckState(i, CheckState.Unchecked);
            }
            */


        }








        /*
         * Devuelve el indice del grupo donde se encuentra el archivo indicado
         * Si no posee un grupo, se crea el mismo y se devuelve el indice
         */
        private static ListViewGroup obtenerGrupoExistente(Label etiquetaMensajes, ListView listaViewtrabajos, String[] urlArchivo)
        {
            int elGrupoYaExiste = -1;
            int ultimoSegmento = urlArchivo.Length - 1;
            


            // Se recorre cada grupo existente en la lista de trabajos
            // para encontrar si el archivo actual pertenece a un grupo
            // que ya exista (distintos procesamientos para el mismo archivo)
            for (int i = 0; i< listaViewtrabajos.Groups.Count ; i++)
            {

                if (listaViewtrabajos.Groups[i].Header.ToString().Equals(urlArchivo[ultimoSegmento]))
                {
                    elGrupoYaExiste = i;
                    etiquetaMensajes.Text = "Agregando " + urlArchivo[ultimoSegmento].ToString() + " al grupo existente: " + elGrupoYaExiste.ToString();

                }

            }

            if (elGrupoYaExiste == -1)
            {
                // Creación del grupo
                ListViewGroup nuevoGrupo = new ListViewGroup(urlArchivo[ultimoSegmento]);
                listaViewtrabajos.Groups.Add(nuevoGrupo);


                etiquetaMensajes.Text = "Agregando " + urlArchivo[ultimoSegmento].ToString() + " a un nuevo grupo con id " + listaViewtrabajos.Groups.IndexOf(nuevoGrupo);
                Console.WriteLine("Agregando " + urlArchivo[ultimoSegmento].ToString() + " a un nuevo grupo con id " + listaViewtrabajos.Groups.IndexOf(nuevoGrupo));
                elGrupoYaExiste = listaViewtrabajos.Groups.IndexOf(nuevoGrupo);
                return listaViewtrabajos.Groups[elGrupoYaExiste];
                    
            }
            else
            {
                return listaViewtrabajos.Groups[elGrupoYaExiste];

            }
             



            
        }



        public static void tareasDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        public static void tareasDrop(ListView listaViewtrabajos, CheckedListBox chequeoVideo, 
            CheckedListBox chequeoAudio, Label etiquetaMensajes, object sender, DragEventArgs e)
        {
            // Si la data dropeada es archivo
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //convertir en lista de string la data
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));

                // por cada string (url de lo arrastrado) en el listado
                foreach (string fileLoc in filePaths)
                {
                    // si el string es un archivo
                    if (File.Exists(fileLoc))
                    {


                        String archivo = fileLoc;
                        agregarItemsProcesamiento(archivo, listaViewtrabajos, chequeoVideo, chequeoAudio, etiquetaMensajes);
                    }
                }

            }
        }

    }
}
