namespace Cliente_FFMPEG
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaViewtrabajos = new System.Windows.Forms.ListView();
            this.columnaArchivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaOperacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaParametro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chequeoVideo = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chequeoAudio = new System.Windows.Forms.CheckedListBox();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.botonQuitar = new System.Windows.Forms.Button();
            this.botonComenzar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialogo = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirColaDeTrabajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarColaDeTrabajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carpetaDeExportaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codificadorDeVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softwareX264ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareNvidiaNvencToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareIntelQuickSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareAMDATIVCEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etiquetaMensajes = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.barraDeProgreso = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaViewtrabajos);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(848, 587);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Archivos";
            this.groupBox1.UseWaitCursor = true;
            // 
            // listaViewtrabajos
            // 
            this.listaViewtrabajos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listaViewtrabajos.AllowColumnReorder = true;
            this.listaViewtrabajos.AllowDrop = true;
            this.listaViewtrabajos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnaArchivo,
            this.columnaOperacion,
            this.columnaParametro});
            this.listaViewtrabajos.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.listaViewtrabajos.FullRowSelect = true;
            this.listaViewtrabajos.HideSelection = false;
            this.listaViewtrabajos.Location = new System.Drawing.Point(5, 21);
            this.listaViewtrabajos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listaViewtrabajos.Name = "listaViewtrabajos";
            this.listaViewtrabajos.Size = new System.Drawing.Size(836, 560);
            this.listaViewtrabajos.TabIndex = 0;
            this.listaViewtrabajos.UseCompatibleStateImageBehavior = false;
            this.listaViewtrabajos.UseWaitCursor = true;
            this.listaViewtrabajos.View = System.Windows.Forms.View.Details;
            this.listaViewtrabajos.SelectedIndexChanged += new System.EventHandler(this.listaViewtrabajos_SelectedIndexChanged);
            this.listaViewtrabajos.DragDrop += new System.Windows.Forms.DragEventHandler(this.listaViewtrabajos_DragDrop);
            this.listaViewtrabajos.DragEnter += new System.Windows.Forms.DragEventHandler(this.listaViewtrabajos_DragEnter);
            this.listaViewtrabajos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.reproducirVideo);
            // 
            // columnaArchivo
            // 
            this.columnaArchivo.Text = "Archivo";
            this.columnaArchivo.Width = 223;
            // 
            // columnaOperacion
            // 
            this.columnaOperacion.Text = "Operación";
            this.columnaOperacion.Width = 116;
            // 
            // columnaParametro
            // 
            this.columnaParametro.Text = "Parámetro";
            this.columnaParametro.Width = 483;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chequeoVideo);
            this.groupBox2.Location = new System.Drawing.Point(867, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(508, 432);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convertir a Video";
            this.groupBox2.UseWaitCursor = true;
            // 
            // chequeoVideo
            // 
            this.chequeoVideo.FormattingEnabled = true;
            this.chequeoVideo.HorizontalScrollbar = true;
            this.chequeoVideo.Items.AddRange(new object[] {
            "Para publicar en OnDemand (H264 1080p 18Mbits)",
            "Para publicar en Youtube  (H264 1080p 15Mbits)",
            "Para publicar en Facebook (H264 1080p 8Mbits)",
            "Para publicar en Twitter  (frag. subclips 137segs, H264 720 2Mbits)",
            "Para publicar en IGTV (transpone a 9:16)",
            "Para publicar en Instagram (frag. subclips 57segs, 720p 1Mbps)",
            "Para enviar por Whatsapp - Telegram (720p máximo de 64MB)",
            "Superponiendo mosca y para publicar en OnDemand (H264 1080p 18Mbits)",
            "Superponiendo mosca y para publicar en Youtube  (H264 1080p 15Mbits)",
            "Superponiendo mosca y para publicar en Facebook (H264 1080p 8Mbits)",
            "Superponiendo mosca y para publicar en Twitter  (frag. subclips 137segs, H264 720" +
                " 2Mbits)",
            "Superponiendo mosca y para publicar en IGTV (transpone a 9:16)",
            "Superponiendo mosca y para enviar por Whatsapp - Telegram (720p máximo de 64MB)",
            "Para mostrar a un tercero (Marca de Agua)",
            "Para editar en Isla de Edición (DNxHD)",
            "Para editar en una PC de Producción (H264)",
            "Flujo de Transporte de Video (MPEG2-TS)",
            "Bajar resolución a SD (853x480)",
            "Bajar resolución a PAL (720x576 MPEG2)",
            "Para resguardo en Archivo Histórico (H264 25Mbits)"});
            this.chequeoVideo.Location = new System.Drawing.Point(5, 25);
            this.chequeoVideo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chequeoVideo.Name = "chequeoVideo";
            this.chequeoVideo.Size = new System.Drawing.Size(491, 395);
            this.chequeoVideo.TabIndex = 0;
            this.chequeoVideo.UseWaitCursor = true;
            this.chequeoVideo.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chequeoVideo_ItemCheck);
            this.chequeoVideo.SelectedIndexChanged += new System.EventHandler(this.chequeoVideo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chequeoAudio);
            this.groupBox3.Location = new System.Drawing.Point(867, 480);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(507, 102);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Convertir a Sonido";
            this.groupBox3.UseWaitCursor = true;
            // 
            // chequeoAudio
            // 
            this.chequeoAudio.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chequeoAudio.FormattingEnabled = true;
            this.chequeoAudio.Items.AddRange(new object[] {
            "MP3 en Calidad Liviana",
            "MP3 en Calidad Alta",
            "WAV para edición (48.0Khz)",
            "WAV para edición (44.1Khz)"});
            this.chequeoAudio.Location = new System.Drawing.Point(5, 22);
            this.chequeoAudio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chequeoAudio.Name = "chequeoAudio";
            this.chequeoAudio.Size = new System.Drawing.Size(491, 72);
            this.chequeoAudio.TabIndex = 1;
            this.chequeoAudio.UseWaitCursor = true;
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(19, 638);
            this.botonAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(147, 46);
            this.botonAgregar.TabIndex = 3;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.UseWaitCursor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // botonQuitar
            // 
            this.botonQuitar.Location = new System.Drawing.Point(171, 638);
            this.botonQuitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.Size = new System.Drawing.Size(147, 46);
            this.botonQuitar.TabIndex = 4;
            this.botonQuitar.Text = "Quitar";
            this.botonQuitar.UseVisualStyleBackColor = true;
            this.botonQuitar.UseWaitCursor = true;
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // botonComenzar
            // 
            this.botonComenzar.Location = new System.Drawing.Point(616, 638);
            this.botonComenzar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonComenzar.Name = "botonComenzar";
            this.botonComenzar.Size = new System.Drawing.Size(237, 46);
            this.botonComenzar.TabIndex = 7;
            this.botonComenzar.Text = "Comenzar";
            this.botonComenzar.UseVisualStyleBackColor = true;
            this.botonComenzar.UseWaitCursor = true;
            this.botonComenzar.Click += new System.EventHandler(this.botonComenzar_Click);
            // 
            // openFileDialogo
            // 
            this.openFileDialogo.FileName = "openFileDialog1";
            this.openFileDialogo.Filter = "Videos de UNITV | *.mp4; *.mov; *.mxf; *.avi; *.mpg ; *.mpeg ; *.ts ; *.h264; *.m" +
    "kv; *.webm; *.divx";
            this.openFileDialogo.Multiselect = true;
            this.openFileDialogo.RestoreDirectory = true;
            this.openFileDialogo.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogo_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1386, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirColaDeTrabajoToolStripMenuItem,
            this.guardarColaDeTrabajoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirColaDeTrabajoToolStripMenuItem
            // 
            this.abrirColaDeTrabajoToolStripMenuItem.Name = "abrirColaDeTrabajoToolStripMenuItem";
            this.abrirColaDeTrabajoToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.abrirColaDeTrabajoToolStripMenuItem.Text = "Abrir Cola de Trabajo";
            // 
            // guardarColaDeTrabajoToolStripMenuItem
            // 
            this.guardarColaDeTrabajoToolStripMenuItem.Name = "guardarColaDeTrabajoToolStripMenuItem";
            this.guardarColaDeTrabajoToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.guardarColaDeTrabajoToolStripMenuItem.Text = "Guardar Cola de Trabajo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carpetaDeExportaciónToolStripMenuItem,
            this.codificadorDeVideoToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // carpetaDeExportaciónToolStripMenuItem
            // 
            this.carpetaDeExportaciónToolStripMenuItem.Name = "carpetaDeExportaciónToolStripMenuItem";
            this.carpetaDeExportaciónToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.carpetaDeExportaciónToolStripMenuItem.Text = "Carpeta de Exportación";
            this.carpetaDeExportaciónToolStripMenuItem.Click += new System.EventHandler(this.carpetaDeExportaciónToolStripMenuItem_Click);
            // 
            // codificadorDeVideoToolStripMenuItem
            // 
            this.codificadorDeVideoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareX264ToolStripMenuItem,
            this.hardwareNvidiaNvencToolStripMenuItem,
            this.hardwareIntelQuickSyncToolStripMenuItem,
            this.hardwareAMDATIVCEToolStripMenuItem});
            this.codificadorDeVideoToolStripMenuItem.Name = "codificadorDeVideoToolStripMenuItem";
            this.codificadorDeVideoToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.codificadorDeVideoToolStripMenuItem.Text = "Codificador de Video";
            this.codificadorDeVideoToolStripMenuItem.Click += new System.EventHandler(this.codificadorDeVideoToolStripMenuItem_Click);
            // 
            // softwareX264ToolStripMenuItem
            // 
            this.softwareX264ToolStripMenuItem.Name = "softwareX264ToolStripMenuItem";
            this.softwareX264ToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.softwareX264ToolStripMenuItem.Text = "Software (X264)";
            this.softwareX264ToolStripMenuItem.Click += new System.EventHandler(this.softwareX264ToolStripMenuItem_Click);
            // 
            // hardwareNvidiaNvencToolStripMenuItem
            // 
            this.hardwareNvidiaNvencToolStripMenuItem.Name = "hardwareNvidiaNvencToolStripMenuItem";
            this.hardwareNvidiaNvencToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.hardwareNvidiaNvencToolStripMenuItem.Text = "Hardware Nvidia (Nvenc)";
            this.hardwareNvidiaNvencToolStripMenuItem.Click += new System.EventHandler(this.hardwareNvidiaNvencToolStripMenuItem_Click);
            // 
            // hardwareIntelQuickSyncToolStripMenuItem
            // 
            this.hardwareIntelQuickSyncToolStripMenuItem.Name = "hardwareIntelQuickSyncToolStripMenuItem";
            this.hardwareIntelQuickSyncToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.hardwareIntelQuickSyncToolStripMenuItem.Text = "Hardware Intel (QuickSync)";
            this.hardwareIntelQuickSyncToolStripMenuItem.Click += new System.EventHandler(this.hardwareIntelQuickSyncToolStripMenuItem_Click);
            // 
            // hardwareAMDATIVCEToolStripMenuItem
            // 
            this.hardwareAMDATIVCEToolStripMenuItem.Name = "hardwareAMDATIVCEToolStripMenuItem";
            this.hardwareAMDATIVCEToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.hardwareAMDATIVCEToolStripMenuItem.Text = "Hardware AMD/ATI  (VCE)";
            this.hardwareAMDATIVCEToolStripMenuItem.Click += new System.EventHandler(this.hardwareAMDATIVCEToolStripMenuItem_Click);
            // 
            // etiquetaMensajes
            // 
            this.etiquetaMensajes.AutoSize = true;
            this.etiquetaMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaMensajes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.etiquetaMensajes.Location = new System.Drawing.Point(15, 686);
            this.etiquetaMensajes.Name = "etiquetaMensajes";
            this.etiquetaMensajes.Size = new System.Drawing.Size(23, 17);
            this.etiquetaMensajes.TabIndex = 9;
            this.etiquetaMensajes.Text = "...";
            this.etiquetaMensajes.UseWaitCursor = true;
            this.etiquetaMensajes.Click += new System.EventHandler(this.label1_Click);
            // 
            // barraDeProgreso
            // 
            this.barraDeProgreso.Location = new System.Drawing.Point(867, 638);
            this.barraDeProgreso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barraDeProgreso.Name = "barraDeProgreso";
            this.barraDeProgreso.Size = new System.Drawing.Size(507, 46);
            this.barraDeProgreso.TabIndex = 10;
            this.barraDeProgreso.UseWaitCursor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 705);
            this.Controls.Add(this.barraDeProgreso);
            this.Controls.Add(this.etiquetaMensajes);
            this.Controls.Add(this.botonComenzar);
            this.Controls.Add(this.botonQuitar);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "ANANA (Asistente Normalizador Audiovisual Nada Abrupto)";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView listaViewtrabajos;
        private System.Windows.Forms.ColumnHeader columnaArchivo;
        private System.Windows.Forms.ColumnHeader columnaOperacion;
        private System.Windows.Forms.ColumnHeader columnaParametro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chequeoVideo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Button botonQuitar;
        private System.Windows.Forms.Button botonComenzar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialogo;
        private System.Windows.Forms.CheckedListBox chequeoAudio;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirColaDeTrabajoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarColaDeTrabajoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        public System.Windows.Forms.Label etiquetaMensajes;
        private System.Windows.Forms.ToolStripMenuItem carpetaDeExportaciónToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar barraDeProgreso;
        private System.Windows.Forms.ToolStripMenuItem codificadorDeVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softwareX264ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareNvidiaNvencToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareIntelQuickSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareAMDATIVCEToolStripMenuItem;
    }
}

