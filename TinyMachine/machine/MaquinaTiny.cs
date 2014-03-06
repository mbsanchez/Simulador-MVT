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
using System.Linq;
using System.Text;
using TinyMachine.ast;
using System.IO;
using TinyMachine.parser;
using TinyMachine.util;
using TinyMachine.semantical;
using System.Threading;

namespace TinyMachine
{
    class MaquinaTiny
    {
        public const int RAM_SIZE = 1024;

        private Programa iMem;
        private int[] dMem;
        private CPU cpu;
        private string programaActual;
        private Dictionary<int, int> lineasOperacion;

        public Programa IMem { get { return iMem; } }
        public int[] DMem { get { return dMem; } }
        public CPU Cpu { get { return cpu; } }
        public string ProgramaActual { get { return programaActual; } }
        public Dictionary<int, int> LineasOperacion { get { return lineasOperacion; } }

        public delegate int LeerValor();
        public delegate void MostarrValor(int valor);
        public delegate void ResultadoInstruccion(CPU.ResultadoEjecucion cambios);
        public delegate void ActivarDepuracion(int linea);

        public LeerValor LeerValorEvent;
        public MostarrValor MostrarValorEvent;
        public ResultadoInstruccion ResultadoInstruccionEvent;
        public ActivarDepuracion ActivarDepuracionEvent;

        public MaquinaTiny()
        {
            cpu = new CPU(this);
            dMem = new int[RAM_SIZE];
            LeerValorEvent = null;
            MostrarValorEvent = null;
            ResultadoInstruccionEvent = null;
            ActivarDepuracionEvent = null;
            lineasOperacion = new Dictionary<int, int>();
            ResetHardware();
        }

        public void ResetHardware() {
            ResetSoftware();
            iMem = null;
            programaActual = null;
            Utilidades.errorList.Clear();
            lineasOperacion.Clear();
        }

        public void ResetSoftware() {
            cpu.Reset();
            for (int i = 0; i < dMem.Length; i++)
            {
                dMem[i] = 0;
            }
            dMem[0] = RAM_SIZE - 1;
        }

        public void cargarPrograma(string nombreArchivo){
            StreamReader input = null;
            try
            {
                ResetHardware();
                input = new StreamReader(nombreArchivo);

                TinyMachineLexer lexer = new TinyMachineLexer(input);
                lexer.setNombreArchivo(System.IO.Path.GetFileName(nombreArchivo));

                TinyMachineParser parser = new TinyMachineParser(lexer);
                iMem = (Programa)(parser.parse().value);

                if (Utilidades.errorList.Count > 0)
                    throw new ErrorAnalisisException("Se ha producido un error durante el análisis sintáctico");

                SemanticalParser.SemanticalParse(lexer.getNombreArchivo(), iMem);

                if (Utilidades.errorList.Count > 0)
                    throw new ErrorAnalisisException("Se ha producido un error durante el análisis semántico");

                programaActual = nombreArchivo;

                //LLenar diccionario con las líneas físicas de cada instrucción y el numero de operación de la misma.
                foreach (KeyValuePair<int, Operacion> entry in iMem.Instrucciones)
                {
                    lineasOperacion.Add(entry.Value.Opcode.left, entry.Value.NumeroOp);
                }
            }
            catch (Exception ex)
            {
                programaActual = null;
                iMem = null;
                throw ex;
            }
            finally
            {
                if(input!=null) 
                    input.Close();
            }
        }

        public int DispararLeerValorEvent()
        {
            if (LeerValorEvent == null)
                throw new EventoNoAsignadoException("El evento de lectura no ha sido asignado");
            return LeerValorEvent();
        }

        public void DispararMostarValorEvent(int valor)
        {
            if (MostrarValorEvent == null)
                throw new EventoNoAsignadoException("El evento de lectura no ha sido asignado");
            MostrarValorEvent(valor);
        }

        public void EjecutarInstruccion() {
            if (iMem == null)
                throw new ProgramaNoCargadoException();

            CPU.ResultadoEjecucion result = cpu.EjecutarInstruccion();

            if (ResultadoInstruccionEvent != null)
                ResultadoInstruccionEvent(result);
        }

        public void EjecutarHastaFin(List<int> puntosInterrupcion)
        {
            if (iMem == null)
                throw new ProgramaNoCargadoException();
        
            CPU.ResultadoEjecucion result;
            do {
                result = cpu.EjecutarInstruccion();

                if (iMem.Instrucciones.ContainsKey(cpu.Registros[CPU.PC_REG]))
                {
                    if (puntosInterrupcion.Contains(iMem.Instrucciones[cpu.Registros[CPU.PC_REG]].Opcode.left))
                    {
                        if (ActivarDepuracionEvent != null)
                            ActivarDepuracionEvent(iMem.Instrucciones[cpu.Registros[CPU.PC_REG]].Opcode.left);
                        break;
                    }
                }

                if (ResultadoInstruccionEvent != null)
                    ResultadoInstruccionEvent(result);
                Thread.Sleep(0);
            }while(result.Status!=CPU.EjecucionStatus.HALT);
        }
    }

    class ErrorAnalisisException : Exception {
        public ErrorAnalisisException()
            : base("Ha ocurrido un error durante la fase de análisis")
        {
        }

        public ErrorAnalisisException(string msg)
            : base(msg)
        {
        }
    }

    class DivisionPorCeroException : Exception
    {
        private int numeroOp;

        public int NumeroOp { get { return numeroOp; } }
        public DivisionPorCeroException(int numeroOp )
            : base("Ha ocurrido un error de división por cero en la instrucción: "+numeroOp)
        {
            this.numeroOp = numeroOp;
        }

        public DivisionPorCeroException(int numeroOp, string msg)
            : base(msg)
        {
            this.numeroOp = numeroOp;
        }
    }

    class ErrorAccesoMemoriaException : Exception
    {
        public int memDir;

        public int MemDir { get { return memDir; } }
        public ErrorAccesoMemoriaException(int dir)
            : base("Ha ocurrido un error de acceso a memoria en la dirección: "+dir)
        {
            memDir =  dir;
        }

        public ErrorAccesoMemoriaException(string msg)
            : base(msg)
        {
        }
    }

    class ErrorAccesoInstruccionException : Exception
    {
        private int numeroOp;

        public int NumeroOp { get { return numeroOp; } }
        public ErrorAccesoInstruccionException(int numeroOp)
            : base("Ha ocurrido un error accediendo a la instrucción "+numeroOp)
        {
            this.numeroOp = numeroOp;
        }

        public ErrorAccesoInstruccionException(int numeroOp, string msg)
            : base(msg)
        {
            this.numeroOp = numeroOp;
        }
    }

    class ProgramaNoCargadoException : Exception
    {
        public ProgramaNoCargadoException()
            : base("El programa no ha sido cargado a memoria")
        {
        }

        public ProgramaNoCargadoException(string msg)
            : base(msg)
        {
        }
    }

    class EventoNoAsignadoException : Exception
    {
        public EventoNoAsignadoException()
            : base("El evento no ha sido asignado")
        {
        }

        public EventoNoAsignadoException(string msg)
            : base(msg)
        {
        }
    }
}
