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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TUVienna.CS_CUP.Runtime;
using System.IO;
using TinyMachine.parser;

namespace TinyMachine
{
    public partial class Form1 : Form
    {
        private TextBox[] registros;
        MaquinaTiny machine;
        private string archivoActual;
        private List<int> puntosInterrupcion;
        private CPU.EjecucionStatus statusCPU;
        private TipoEjecucion tipoEjecucion;
        private int lineaOperacionAterior;
        private bool lecturaActivada;
        private string textoLeido;

        public enum TipoEjecucion { PasoPaso, Continua };

        public Form1()
        {
            InitializeComponent();
            registros = new TextBox[] { reg0, reg1, reg2, reg3, reg4, reg5, reg6, reg7};
            machine = new MaquinaTiny();
            puntosInterrupcion = new List<int>();
            archivoActual = "";

            machine.LeerValorEvent = LeerValor;
            machine.MostrarValorEvent = MostrarValor;
            machine.ResultadoInstruccionEvent = SincronizarEstadoMaquina;
            machine.ActivarDepuracionEvent = ActivarDepuracion;
            statusCPU = CPU.EjecucionStatus.HALT;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusCPU == CPU.EjecucionStatus.OK)
            {
                MessageBox.Show("Debe finalizar la ejecución del programa actual para abrir uno nuevo");
                return;
            }

            openFileDialog.FileName = "";
            openFileDialog.Filter = "Programas en lenguaje de la TM (*.tm)|*.tm";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            CargarProgramaEnEditor(openFileDialog.FileName);
        }

        private void CargarProgramaEnEditor(string nombreArchivo) {
            StreamReader reader = new StreamReader(nombreArchivo, Encoding.UTF8);
            limpiarControles();
            codigoFuente.Text = reader.ReadToEnd();
            reader.Close();

            ResaltarSintaxis();
            cerrarToolStripMenuItem.Enabled = true;
            archivoActual = nombreArchivo;
            toggleMenu();
        }

        private void ResaltarSintaxis()
        {
            StringReader input = new StringReader(codigoFuente.Text);
            TinyMachineLexer lexer = new TinyMachineLexer(input);
            Symbol sym;

            int textOffset = 0, lineaActual=0;
            codigoFuente.Enabled = false;
            while ((sym = lexer.next_token()).sym != TokenDef.EOF) {
                if (sym.sym == TokenDef.FIN_LINEA)
                {
                    textOffset += codigoFuente.Lines[lineaActual++].Length + 1;
                    continue;
                }

                PropiedadesTexto p = ObtenerPropiedadesToken(sym);

                codigoFuente.Select(textOffset+sym.right-1, p.longitud);
                codigoFuente.SelectionColor = p.colorTexto;

                if (sym.sym == TokenDef.FIN_LINEA || sym.sym == TokenDef.COMENTARIO_LINEA || sym.sym == TokenDef.COMENTARIO_FIN)
                    textOffset += codigoFuente.Lines[lineaActual++].Length + 1;
            }
            codigoFuente.SelectionStart = 0;
            codigoFuente.SelectionLength = 0;
            codigoFuente.Enabled = true;
        }

        private PropiedadesTexto ObtenerPropiedadesToken(Symbol sym)
        {
            PropiedadesTexto p = new PropiedadesTexto();
            switch (sym.sym)
            {
                case TinyMachine.parser.TokenDef.COMENTARIO_FIN:
                case TinyMachine.parser.TokenDef.COMENTARIO_LINEA:
                    p.colorTexto = Color.Green;
                    p.longitud = sym.value.ToString().Length;
                    break;
                case TinyMachine.parser.TokenDef.COLON:
                    p.colorTexto = Color.Brown;
                    break;
                case TinyMachine.parser.TokenDef.ENTERO:
                    p.colorTexto = Color.Brown;
                    p.longitud = ((Symbol)sym.value).value.ToString().Length;
                    break;
                case TinyMachine.parser.TokenDef.LD:
                case TinyMachine.parser.TokenDef.ST:
                case TinyMachine.parser.TokenDef.IN:
                    p.colorTexto = Color.Blue;
                    p.longitud = 2;
                    break;
                case TinyMachine.parser.TokenDef.HALT:
                    p.colorTexto = Color.Blue;
                    p.longitud = 4;
                    break;
                case TinyMachine.parser.TokenDef.ADD:
                case TinyMachine.parser.TokenDef.DIV:
                case TinyMachine.parser.TokenDef.JEQ:
                case TinyMachine.parser.TokenDef.JGE:
                case TinyMachine.parser.TokenDef.JGT:
                case TinyMachine.parser.TokenDef.JLE:
                case TinyMachine.parser.TokenDef.JLT:
                case TinyMachine.parser.TokenDef.JNE:
                case TinyMachine.parser.TokenDef.LDA:
                case TinyMachine.parser.TokenDef.LDC:
                case TinyMachine.parser.TokenDef.MUL:
                case TinyMachine.parser.TokenDef.OUT:
                case TinyMachine.parser.TokenDef.SUB:
                    p.colorTexto = Color.Blue;
                    p.longitud = 3;
                    break;
            }

            return p;
        }

        private class PropiedadesTexto
        {
            public Color colorTexto;
            public int longitud;

            public PropiedadesTexto()
            {
                colorTexto = Color.Black;
                longitud = 1;
            }
        }

        private void toggleMenu() {
            iniciarToolStripMenuItem.Enabled = cerrarToolStripMenuItem.Enabled && statusCPU == CPU.EjecucionStatus.HALT;
            puntoDeInterrupciónToolStripMenuItem.Enabled = cerrarToolStripMenuItem.Enabled;
            siguientePasoToolStripMenuItem.Enabled = tipoEjecucion == TipoEjecucion.PasoPaso && statusCPU == CPU.EjecucionStatus.OK;
            continuarToolStripMenuItem.Enabled = siguientePasoToolStripMenuItem.Enabled;
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                statusCPU = CPU.EjecucionStatus.HALT;
                consola.Text = "";
                if (archivoActual.Equals(machine.ProgramaActual))
                    machine.ResetSoftware();
                else
                {
                    machine.cargarPrograma(archivoActual);
                }
                LlenarMemoriaDatos();
                ActualizarRegistros();
                statusCPU = CPU.EjecucionStatus.OK;
                tipoEjecucion = TipoEjecucion.Continua;
            }
            catch (Exception ex)
            {
                StringBuilder memoryText = new StringBuilder();

                foreach(string error in util.Utilidades.errorList){
                    memoryText.AppendLine(error);
                }
                memoryText.AppendLine();
                memoryText.AppendLine("Se encontraron errores en el código");
                consola.Text = memoryText.ToString();
            }

            try
            {
                if (statusCPU == CPU.EjecucionStatus.OK)
                    machine.EjecutarHastaFin(puntosInterrupcion);
            }catch(Exception ex){
                statusCPU = CPU.EjecucionStatus.HALT;
                toggleMenu();
                MessageBox.Show(ex.Message, "El programa ha generado una excepción y debe detenerse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void continuarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusCPU == CPU.EjecucionStatus.HALT)
                MessageBox.Show("La ejecución del programa ha finalizado, debe reiniciarlo para continuar");

            //TODO: hay que hacer un try catch
            try
            {
                DesmarcarLineaAnterior();
                machine.EjecutarHastaFin(puntosInterrupcion);
            }
            catch (Exception ex)
            {
                statusCPU = CPU.EjecucionStatus.HALT;
                toggleMenu();
                MessageBox.Show(ex.Message, "El programa ha generado una excepción y debe detenerse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siguientePasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusCPU == CPU.EjecucionStatus.HALT)
                MessageBox.Show("La ejecución del programa ha finalizado, debe reiniciarlo para continuar");
            else
            {
                //TODO: hay que hacer un try catch
                try
                {
                    tipoEjecucion = TipoEjecucion.PasoPaso;
                    machine.EjecutarInstruccion();

                    //Desmarcar la línea anterior y marcar la actual;
                    DesmarcarLineaAnterior();
                    if (statusCPU == CPU.EjecucionStatus.OK && machine.IMem.Instrucciones.ContainsKey(machine.Cpu.Registros[CPU.PC_REG]))
                    {
                        lineaOperacionAterior = machine.IMem.Instrucciones[machine.Cpu.Registros[CPU.PC_REG]].Opcode.left - 1;
                        ResaltarFondoActivarLinea(lineaOperacionAterior, Color.CadetBlue);
                    }
                }
                catch (Exception ex)
                {
                    statusCPU = CPU.EjecucionStatus.HALT;
                    DesmarcarLineaAnterior();
                    toggleMenu();
                    MessageBox.Show(ex.Message, "El programa ha generado una excepción y debe detenerse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DesmarcarLineaAnterior()
        {
            if (!puntosInterrupcion.Contains(lineaOperacionAterior + 1))
                ResaltarFondoActivarLinea(lineaOperacionAterior, Color.White);
            else
                ResaltarFondoActivarLinea(lineaOperacionAterior, Color.RosyBrown);
        }

        private void LlenarMemoriaDatos() {
            dMem.Rows.Clear();

            dMem.Rows.Add(MaquinaTiny.RAM_SIZE);
            int ls = MaquinaTiny.RAM_SIZE - 1;
            for (int i = ls; i >= 0; i--) {
                int pos = ls - i;
                dMem.Rows[pos].SetValues(new Object[] { i, machine.DMem[i] });
            }
        }

        private void ActualizarRegistros()
        {
            for (int i = 0; i < registros.Length; i++)
            {
                registros[i].ForeColor = statusCPU == CPU.EjecucionStatus.HALT || registros[i].Text.Equals("")
                                                      || int.Parse(registros[i].Text) == machine.Cpu.Registros[i] ? Color.Black : Color.Red;
                registros[i].Text = machine.Cpu.Registros[i].ToString();
            }
        }

        public void ActualizarMemoriaDatos(int pos) {
            int posTabla = MaquinaTiny.RAM_SIZE - pos - 1;

            for (int i = 0; i < MaquinaTiny.RAM_SIZE; i++)
            {
                if (i != posTabla)
                    dMem.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                else
                {
                    dMem.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    dMem.Rows[i].Cells[1].Value = machine.DMem[pos];
                    if(tipoEjecucion == TipoEjecucion.PasoPaso)
                        dMem.FirstDisplayedScrollingRowIndex = i;
                }
            }
        }

        private void puntoDeInterrupciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selStart =  codigoFuente.SelectionStart;
            int selLength = codigoFuente.SelectionLength;
            int firstcharindex = codigoFuente.GetFirstCharIndexOfCurrentLine();
            int currentline = codigoFuente.GetLineFromCharIndex(firstcharindex);
            string currentlinetext = codigoFuente.Lines[currentline];

            Color backColor;
            if (puntosInterrupcion.Contains(currentline + 1))
            {
                backColor = Color.White;
                puntosInterrupcion.Remove(currentline + 1);
            }
            else
            {
                backColor = Color.RosyBrown;
                puntosInterrupcion.Add(currentline + 1);
            }

            codigoFuente.Select(firstcharindex, currentlinetext.Length);
            if (codigoFuente.SelectionColor == Color.Green)
            {
                backColor = Color.White;
                puntosInterrupcion.Remove(currentline + 1);
            }
            codigoFuente.SelectionBackColor = backColor;

            codigoFuente.SelectionStart = selStart;
            codigoFuente.SelectionLength = selLength;
        }

        public void ResaltarFondoActivarLinea(int linea, Color backColor)
        {
            int firstcharindex = codigoFuente.GetFirstCharIndexFromLine(linea);
            string currentlinetext = codigoFuente.Lines[linea];

            codigoFuente.Select(firstcharindex, currentlinetext.Length);
            codigoFuente.SelectionBackColor = backColor;

            codigoFuente.SelectionLength = 0;
        }

        public int LeerValor() {
            consola.AppendText("Ingrese un valor entero: ");
            lecturaActivada = true;
            textoLeido = "";

            while (lecturaActivada == true)
                Application.DoEvents();

            return int.Parse(textoLeido);
        }

        public void MostrarValor(int valor)
        {
            consola.AppendText("Resultado (Instrucción OUT): " + valor + System.Environment.NewLine);
        }

        internal void SincronizarEstadoMaquina(CPU.ResultadoEjecucion result) {
            int i = result.Info;

            if (result.TipoAcceso ==  CPU.TipoOperacionAcceso.MEMORIA_CAMBIADA)
                ActualizarMemoriaDatos(i);

            statusCPU = result.Status;
            ActualizarRegistros();

            if (statusCPU == CPU.EjecucionStatus.HALT)
                toggleMenu();
        }

        public void ActivarDepuracion(int linea)
        {
            tipoEjecucion = TipoEjecucion.PasoPaso;
            ActualizarRegistros();
            ActualizarMemoriaDatos(MaquinaTiny.RAM_SIZE);
            lineaOperacionAterior = linea - 1;
            ResaltarFondoActivarLinea(lineaOperacionAterior, Color.CadetBlue);
            toggleMenu();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (lecturaActivada == false)
                return;

            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.D0:
                case Keys.D1:              
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                    string Key = new KeysConverter().ConvertToString(e.KeyData);
                    string caracter = Key.Substring(Key.Length - 1);
                    textoLeido += caracter;
                    consola.AppendText(caracter);
                    break;
                case Keys.Enter:
                    if (textoLeido.Length > 0)
                    {
                        lecturaActivada = false;
                        consola.AppendText(System.Environment.NewLine);
                    }
                    break;
                case Keys.Back:
                    if (textoLeido.Length > 0)
                    {
                        textoLeido = textoLeido.Substring(0, textoLeido.Length - 1);
                        consola.Text = consola.Text.Substring(0, consola.Text.Length - 1);
                        consola.SelectionStart = consola.Text.Length;
                        consola.SelectionLength = 0;
                    }
                    break;
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusCPU == CPU.EjecucionStatus.OK)
            {
                MessageBox.Show("Debe finalizar la ejecución del programa actual para poder cerrarlo");
                return;
            }

            cerrarToolStripMenuItem.Enabled = false;
            limpiarControles();
        }

        public void limpiarControles() {
            codigoFuente.Clear();
            dMem.Rows.Clear();
            lecturaActivada = false;
            textoLeido = "";
            archivoActual = "";
            puntosInterrupcion.Clear();
            statusCPU = CPU.EjecucionStatus.HALT;
            lineaOperacionAterior = 0;
            consola.Clear();

            for (int i = 0; i < registros.Length; i++) {
                registros[i].Clear();
            }

            machine.ResetHardware();
           toggleMenu();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !Salir();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Salir())
                Application.Exit();
        }

        private bool Salir()
        {
            if (statusCPU == CPU.EjecucionStatus.OK)
            {
                MessageBox.Show("Debe finalizar la ejecución del programa actual para cerrar la aplicación");
                return false;
            }
            else
                return true;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe About = new AcercaDe();
            About.ShowDialog();
        }
    }
}
