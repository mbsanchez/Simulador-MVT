/* Simulador MVT es una Herramienta que sirve como un simulador visual para la Máquina Virtual de Tiny [1] 
 * la cual está descrita por su autor Kenneth Louden en su libro de Construcción de Compiladores.
 * 
 * Esta aplicación sirve de ayuda a los estudiantes de la materia Construcción de Compiladores, 
 * al permitirles visualizar, ejecutar y depurar el código escrito en el lenguanje de la Maquina 
 * Virtual de Tiny (TM). La aplicación realiza el resaltado de sintáxis de las instrucciones de la TM, 
 * permite poner puntos de interrupción en el código y visualizar la memoria de datos y es estado de los 
 * registros de la TM.
 * 
 * Para el desarrollo de este programa se utilizaron las librerías C#Lex [2] y C#Cup [2] desarrolladas 
 * por Samuel Imsra, las cuales permitieron escribir el analizador léxico y sintáctico del programa 
 * respectivamente.
 * 
 * Copyright (C) 2013 Manuel B. Sánchez
 * 
 * Este programa es software libre: puede redistribuirlo y/o modificarlo bajo los términos de la Licencia 
 * General Pública de GNU publicada por la Free Software Foundation, ya sea la versión 3 de la Licencia, 
 * o (a su elección) cualquier versión posterior.
 * 
 * Este programa se distribuye con la esperanza de que sea útil pero SIN NINGUNA GARANTÍA; incluso sin la 
 * garantía implícita de MERCANTIBILIDAD o CALIFICADA PARA UN PROPÓSITO EN PARTICULAR. Vea la Licencia 
 * General Pública de GNU para más detalles.
 * 
 * Usted ha debido de recibir una copia de la Licencia General Pública de GNU junto con este programa. 
 * Si no, vea <http://www.gnu.org/licenses/>. 
 * 
 * [1] Louden, K. C. (2004). Construcción de compiladores: Principios y práctica (3ra ed.). Thomson.
 * [2] Imriska, I. (2005). C#lexcup.  http://www.seclab.tuwien.ac.at/projects/cuplex/cup.htm
 */

namespace TinyMachine
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecuciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continuarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siguientePasoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.puntoDeInterrupciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.codigoFuente = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dMem = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.consola = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.reg7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reg6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.reg5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.reg4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.reg3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reg2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reg1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reg0 = new System.Windows.Forms.TextBox();
            this.menuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dMem)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ejecuciónToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(782, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.cerrarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.abrirToolStripMenuItem.Text = "A&brir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Enabled = false;
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cerrarToolStripMenuItem.Text = "&Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ejecuciónToolStripMenuItem
            // 
            this.ejecuciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarToolStripMenuItem,
            this.continuarToolStripMenuItem,
            this.siguientePasoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.puntoDeInterrupciónToolStripMenuItem});
            this.ejecuciónToolStripMenuItem.Name = "ejecuciónToolStripMenuItem";
            this.ejecuciónToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ejecuciónToolStripMenuItem.Text = "&Ejecución";
            // 
            // iniciarToolStripMenuItem
            // 
            this.iniciarToolStripMenuItem.Enabled = false;
            this.iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            this.iniciarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.iniciarToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.iniciarToolStripMenuItem.Text = "Iniciar";
            this.iniciarToolStripMenuItem.Click += new System.EventHandler(this.iniciarToolStripMenuItem_Click);
            // 
            // continuarToolStripMenuItem
            // 
            this.continuarToolStripMenuItem.Enabled = false;
            this.continuarToolStripMenuItem.Name = "continuarToolStripMenuItem";
            this.continuarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.continuarToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.continuarToolStripMenuItem.Text = "&Continuar";
            this.continuarToolStripMenuItem.Click += new System.EventHandler(this.continuarToolStripMenuItem_Click);
            // 
            // siguientePasoToolStripMenuItem
            // 
            this.siguientePasoToolStripMenuItem.Enabled = false;
            this.siguientePasoToolStripMenuItem.Name = "siguientePasoToolStripMenuItem";
            this.siguientePasoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.siguientePasoToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.siguientePasoToolStripMenuItem.Text = "&Siguiente Paso";
            this.siguientePasoToolStripMenuItem.Click += new System.EventHandler(this.siguientePasoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(287, 6);
            // 
            // puntoDeInterrupciónToolStripMenuItem
            // 
            this.puntoDeInterrupciónToolStripMenuItem.Enabled = false;
            this.puntoDeInterrupciónToolStripMenuItem.Name = "puntoDeInterrupciónToolStripMenuItem";
            this.puntoDeInterrupciónToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.puntoDeInterrupciónToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.puntoDeInterrupciónToolStripMenuItem.Text = "Asignar/Quitar Punto de Interrupción";
            this.puntoDeInterrupciónToolStripMenuItem.Click += new System.EventHandler(this.puntoDeInterrupciónToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ay&uda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.acercaDeToolStripMenuItem.Text = "&Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(782, 407);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(450, 407);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.codigoFuente);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 407);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Código Fuente";
            // 
            // codigoFuente
            // 
            this.codigoFuente.BackColor = System.Drawing.Color.White;
            this.codigoFuente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codigoFuente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codigoFuente.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoFuente.Location = new System.Drawing.Point(3, 16);
            this.codigoFuente.Name = "codigoFuente";
            this.codigoFuente.ReadOnly = true;
            this.codigoFuente.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.codigoFuente.Size = new System.Drawing.Size(266, 388);
            this.codigoFuente.TabIndex = 0;
            this.codigoFuente.Text = "";
            this.codigoFuente.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dMem);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 407);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Memoria de Datos";
            // 
            // dMem
            // 
            this.dMem.AllowUserToAddRows = false;
            this.dMem.AllowUserToDeleteRows = false;
            this.dMem.AllowUserToResizeColumns = false;
            this.dMem.AllowUserToResizeRows = false;
            this.dMem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dMem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dMem.ColumnHeadersVisible = false;
            this.dMem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dMem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dMem.Location = new System.Drawing.Point(3, 16);
            this.dMem.MultiSelect = false;
            this.dMem.Name = "dMem";
            this.dMem.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dMem.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dMem.RowHeadersVisible = false;
            this.dMem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dMem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dMem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dMem.ShowCellErrors = false;
            this.dMem.ShowCellToolTips = false;
            this.dMem.ShowEditingIcon = false;
            this.dMem.ShowRowErrors = false;
            this.dMem.Size = new System.Drawing.Size(168, 388);
            this.dMem.TabIndex = 0;
            // 
            // Column1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.consola);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 287);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Consola";
            // 
            // consola
            // 
            this.consola.BackColor = System.Drawing.Color.White;
            this.consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consola.Location = new System.Drawing.Point(3, 16);
            this.consola.Multiline = true;
            this.consola.Name = "consola";
            this.consola.ReadOnly = true;
            this.consola.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consola.Size = new System.Drawing.Size(322, 268);
            this.consola.TabIndex = 3;
            this.consola.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.reg7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.reg6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.reg5);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.reg4);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.reg3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.reg2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.reg1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.reg0);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 120);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Registros de la Máquina Virtual de Tiny";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "7";
            // 
            // reg7
            // 
            this.reg7.BackColor = System.Drawing.Color.White;
            this.reg7.Location = new System.Drawing.Point(198, 95);
            this.reg7.Name = "reg7";
            this.reg7.ReadOnly = true;
            this.reg7.Size = new System.Drawing.Size(120, 20);
            this.reg7.TabIndex = 14;
            this.reg7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "6";
            // 
            // reg6
            // 
            this.reg6.BackColor = System.Drawing.Color.White;
            this.reg6.Location = new System.Drawing.Point(198, 69);
            this.reg6.Name = "reg6";
            this.reg6.ReadOnly = true;
            this.reg6.Size = new System.Drawing.Size(120, 20);
            this.reg6.TabIndex = 12;
            this.reg6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "5";
            // 
            // reg5
            // 
            this.reg5.BackColor = System.Drawing.Color.White;
            this.reg5.Location = new System.Drawing.Point(198, 43);
            this.reg5.Name = "reg5";
            this.reg5.ReadOnly = true;
            this.reg5.Size = new System.Drawing.Size(120, 20);
            this.reg5.TabIndex = 10;
            this.reg5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "4";
            // 
            // reg4
            // 
            this.reg4.BackColor = System.Drawing.Color.White;
            this.reg4.Location = new System.Drawing.Point(198, 17);
            this.reg4.Name = "reg4";
            this.reg4.ReadOnly = true;
            this.reg4.Size = new System.Drawing.Size(120, 20);
            this.reg4.TabIndex = 8;
            this.reg4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "3";
            // 
            // reg3
            // 
            this.reg3.BackColor = System.Drawing.Color.White;
            this.reg3.Location = new System.Drawing.Point(27, 94);
            this.reg3.Name = "reg3";
            this.reg3.ReadOnly = true;
            this.reg3.Size = new System.Drawing.Size(120, 20);
            this.reg3.TabIndex = 6;
            this.reg3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "2";
            // 
            // reg2
            // 
            this.reg2.BackColor = System.Drawing.Color.White;
            this.reg2.Location = new System.Drawing.Point(27, 68);
            this.reg2.Name = "reg2";
            this.reg2.ReadOnly = true;
            this.reg2.Size = new System.Drawing.Size(120, 20);
            this.reg2.TabIndex = 4;
            this.reg2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "1";
            // 
            // reg1
            // 
            this.reg1.BackColor = System.Drawing.Color.White;
            this.reg1.Location = new System.Drawing.Point(27, 42);
            this.reg1.Name = "reg1";
            this.reg1.ReadOnly = true;
            this.reg1.Size = new System.Drawing.Size(120, 20);
            this.reg1.TabIndex = 2;
            this.reg1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            // 
            // reg0
            // 
            this.reg0.BackColor = System.Drawing.Color.White;
            this.reg0.Location = new System.Drawing.Point(27, 16);
            this.reg0.Name = "reg0";
            this.reg0.ReadOnly = true;
            this.reg0.Size = new System.Drawing.Size(120, 20);
            this.reg0.TabIndex = 0;
            this.reg0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 431);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuPrincipal);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "Form1";
            this.Text = "Simulador MVT - Refiera a http://www.cs.sjsu.edu/~louden/cmptext/";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dMem)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ejecuciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continuarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siguientePasoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox codigoFuente;
        private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dMem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox consola;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox reg7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox reg6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox reg5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox reg4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox reg3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reg2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox reg1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reg0;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem puntoDeInterrupciónToolStripMenuItem;
    }
}

