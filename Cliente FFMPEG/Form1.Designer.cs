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
            this.columnScan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.listaViewtrabajos);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.UseWaitCursor = true;
            // 
            // listaViewtrabajos
            // 
            resources.ApplyResources(this.listaViewtrabajos, "listaViewtrabajos");
            this.listaViewtrabajos.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listaViewtrabajos.AllowColumnReorder = true;
            this.listaViewtrabajos.AllowDrop = true;
            this.listaViewtrabajos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnaArchivo,
            this.columnaOperacion,
            this.columnaParametro,
            this.columnScan});
            this.listaViewtrabajos.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.listaViewtrabajos.FullRowSelect = true;
            this.listaViewtrabajos.HideSelection = false;
            this.listaViewtrabajos.Name = "listaViewtrabajos";
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
            resources.ApplyResources(this.columnaArchivo, "columnaArchivo");
            // 
            // columnaOperacion
            // 
            resources.ApplyResources(this.columnaOperacion, "columnaOperacion");
            // 
            // columnaParametro
            // 
            resources.ApplyResources(this.columnaParametro, "columnaParametro");
            // 
            // columnScan
            // 
            resources.ApplyResources(this.columnScan, "columnScan");
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.chequeoVideo);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.UseWaitCursor = true;
            // 
            // chequeoVideo
            // 
            resources.ApplyResources(this.chequeoVideo, "chequeoVideo");
            this.chequeoVideo.FormattingEnabled = true;
            this.chequeoVideo.Items.AddRange(new object[] {
            resources.GetString("chequeoVideo.Items"),
            resources.GetString("chequeoVideo.Items1"),
            resources.GetString("chequeoVideo.Items2"),
            resources.GetString("chequeoVideo.Items3"),
            resources.GetString("chequeoVideo.Items4"),
            resources.GetString("chequeoVideo.Items5"),
            resources.GetString("chequeoVideo.Items6"),
            resources.GetString("chequeoVideo.Items7"),
            resources.GetString("chequeoVideo.Items8"),
            resources.GetString("chequeoVideo.Items9"),
            resources.GetString("chequeoVideo.Items10"),
            resources.GetString("chequeoVideo.Items11"),
            resources.GetString("chequeoVideo.Items12"),
            resources.GetString("chequeoVideo.Items13"),
            resources.GetString("chequeoVideo.Items14"),
            resources.GetString("chequeoVideo.Items15")});
            this.chequeoVideo.Name = "chequeoVideo";
            this.chequeoVideo.UseWaitCursor = true;
            this.chequeoVideo.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chequeoVideo_ItemCheck);
            this.chequeoVideo.SelectedIndexChanged += new System.EventHandler(this.chequeoVideo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.chequeoAudio);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.groupBox3.UseWaitCursor = true;
            // 
            // chequeoAudio
            // 
            resources.ApplyResources(this.chequeoAudio, "chequeoAudio");
            this.chequeoAudio.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chequeoAudio.FormattingEnabled = true;
            this.chequeoAudio.Items.AddRange(new object[] {
            resources.GetString("chequeoAudio.Items"),
            resources.GetString("chequeoAudio.Items1"),
            resources.GetString("chequeoAudio.Items2"),
            resources.GetString("chequeoAudio.Items3")});
            this.chequeoAudio.Name = "chequeoAudio";
            this.chequeoAudio.UseWaitCursor = true;
            this.chequeoAudio.SelectedIndexChanged += new System.EventHandler(this.chequeoAudio_SelectedIndexChanged);
            // 
            // botonAgregar
            // 
            resources.ApplyResources(this.botonAgregar, "botonAgregar");
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.UseWaitCursor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // botonQuitar
            // 
            resources.ApplyResources(this.botonQuitar, "botonQuitar");
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.UseVisualStyleBackColor = true;
            this.botonQuitar.UseWaitCursor = true;
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // botonComenzar
            // 
            resources.ApplyResources(this.botonComenzar, "botonComenzar");
            this.botonComenzar.Name = "botonComenzar";
            this.botonComenzar.UseVisualStyleBackColor = true;
            this.botonComenzar.UseWaitCursor = true;
            this.botonComenzar.Click += new System.EventHandler(this.botonComenzar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // openFileDialogo
            // 
            this.openFileDialogo.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialogo, "openFileDialogo");
            this.openFileDialogo.Multiselect = true;
            this.openFileDialogo.RestoreDirectory = true;
            this.openFileDialogo.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogo_FileOk);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // archivoToolStripMenuItem
            // 
            resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirColaDeTrabajoToolStripMenuItem,
            this.guardarColaDeTrabajoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            // 
            // abrirColaDeTrabajoToolStripMenuItem
            // 
            resources.ApplyResources(this.abrirColaDeTrabajoToolStripMenuItem, "abrirColaDeTrabajoToolStripMenuItem");
            this.abrirColaDeTrabajoToolStripMenuItem.Name = "abrirColaDeTrabajoToolStripMenuItem";
            // 
            // guardarColaDeTrabajoToolStripMenuItem
            // 
            resources.ApplyResources(this.guardarColaDeTrabajoToolStripMenuItem, "guardarColaDeTrabajoToolStripMenuItem");
            this.guardarColaDeTrabajoToolStripMenuItem.Name = "guardarColaDeTrabajoToolStripMenuItem";
            // 
            // salirToolStripMenuItem
            // 
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            // 
            // configuraciónToolStripMenuItem
            // 
            resources.ApplyResources(this.configuraciónToolStripMenuItem, "configuraciónToolStripMenuItem");
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carpetaDeExportaciónToolStripMenuItem,
            this.codificadorDeVideoToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            // 
            // carpetaDeExportaciónToolStripMenuItem
            // 
            resources.ApplyResources(this.carpetaDeExportaciónToolStripMenuItem, "carpetaDeExportaciónToolStripMenuItem");
            this.carpetaDeExportaciónToolStripMenuItem.Name = "carpetaDeExportaciónToolStripMenuItem";
            this.carpetaDeExportaciónToolStripMenuItem.Click += new System.EventHandler(this.carpetaDeExportaciónToolStripMenuItem_Click);
            // 
            // codificadorDeVideoToolStripMenuItem
            // 
            resources.ApplyResources(this.codificadorDeVideoToolStripMenuItem, "codificadorDeVideoToolStripMenuItem");
            this.codificadorDeVideoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareX264ToolStripMenuItem,
            this.hardwareNvidiaNvencToolStripMenuItem,
            this.hardwareIntelQuickSyncToolStripMenuItem,
            this.hardwareAMDATIVCEToolStripMenuItem});
            this.codificadorDeVideoToolStripMenuItem.Name = "codificadorDeVideoToolStripMenuItem";
            this.codificadorDeVideoToolStripMenuItem.Click += new System.EventHandler(this.codificadorDeVideoToolStripMenuItem_Click);
            // 
            // softwareX264ToolStripMenuItem
            // 
            resources.ApplyResources(this.softwareX264ToolStripMenuItem, "softwareX264ToolStripMenuItem");
            this.softwareX264ToolStripMenuItem.Name = "softwareX264ToolStripMenuItem";
            this.softwareX264ToolStripMenuItem.Click += new System.EventHandler(this.softwareX264ToolStripMenuItem_Click);
            // 
            // hardwareNvidiaNvencToolStripMenuItem
            // 
            resources.ApplyResources(this.hardwareNvidiaNvencToolStripMenuItem, "hardwareNvidiaNvencToolStripMenuItem");
            this.hardwareNvidiaNvencToolStripMenuItem.Name = "hardwareNvidiaNvencToolStripMenuItem";
            this.hardwareNvidiaNvencToolStripMenuItem.Click += new System.EventHandler(this.hardwareNvidiaNvencToolStripMenuItem_Click);
            // 
            // hardwareIntelQuickSyncToolStripMenuItem
            // 
            resources.ApplyResources(this.hardwareIntelQuickSyncToolStripMenuItem, "hardwareIntelQuickSyncToolStripMenuItem");
            this.hardwareIntelQuickSyncToolStripMenuItem.Name = "hardwareIntelQuickSyncToolStripMenuItem";
            this.hardwareIntelQuickSyncToolStripMenuItem.Click += new System.EventHandler(this.hardwareIntelQuickSyncToolStripMenuItem_Click);
            // 
            // hardwareAMDATIVCEToolStripMenuItem
            // 
            resources.ApplyResources(this.hardwareAMDATIVCEToolStripMenuItem, "hardwareAMDATIVCEToolStripMenuItem");
            this.hardwareAMDATIVCEToolStripMenuItem.Name = "hardwareAMDATIVCEToolStripMenuItem";
            this.hardwareAMDATIVCEToolStripMenuItem.Click += new System.EventHandler(this.hardwareAMDATIVCEToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            resources.ApplyResources(this.idiomaToolStripMenuItem, "idiomaToolStripMenuItem");
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.españolToolStripMenuItem,
            this.inglesToolStripMenuItem});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Click += new System.EventHandler(this.idiomaToolStripMenuItem_Click);
            // 
            // españolToolStripMenuItem
            // 
            resources.ApplyResources(this.españolToolStripMenuItem, "españolToolStripMenuItem");
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // inglesToolStripMenuItem
            // 
            resources.ApplyResources(this.inglesToolStripMenuItem, "inglesToolStripMenuItem");
            this.inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            this.inglesToolStripMenuItem.Click += new System.EventHandler(this.inglesToolStripMenuItem_Click);
            // 
            // etiquetaMensajes
            // 
            resources.ApplyResources(this.etiquetaMensajes, "etiquetaMensajes");
            this.etiquetaMensajes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.etiquetaMensajes.Name = "etiquetaMensajes";
            this.etiquetaMensajes.UseWaitCursor = true;
            this.etiquetaMensajes.Click += new System.EventHandler(this.label1_Click);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // barraDeProgreso
            // 
            resources.ApplyResources(this.barraDeProgreso, "barraDeProgreso");
            this.barraDeProgreso.Name = "barraDeProgreso";
            this.barraDeProgreso.UseWaitCursor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barraDeProgreso);
            this.Controls.Add(this.etiquetaMensajes);
            this.Controls.Add(this.botonComenzar);
            this.Controls.Add(this.botonQuitar);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
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
        private System.Windows.Forms.ColumnHeader columnScan;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inglesToolStripMenuItem;
    }
}

