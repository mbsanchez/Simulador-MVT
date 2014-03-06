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
using TinyMachine.parser;

namespace TinyMachine
{
    class CPU
    {
        public const int REG_SIZE=8;
        public const int PC_REG=7;

        private int[] registros;
        private MaquinaTiny maquina;

        public enum EjecucionStatus { OK, HALT };
        public enum TipoOperacionAcceso { NINGUNA, REG_CAMBIADO, MEMORIA_CAMBIADA };

        public class ResultadoEjecucion
        {
            public EjecucionStatus Status { get; set; }
            public int Info { get; set; }
            public TipoOperacionAcceso TipoAcceso { get; set; }

            public ResultadoEjecucion()
            {
                Status = EjecucionStatus.OK;
                Info = -1;
                TipoAcceso = TipoOperacionAcceso.NINGUNA;
            }
        }

        public int[] Registros { get { return registros; } }
        
        public CPU(MaquinaTiny m) {
            maquina = m;
            registros = new int[REG_SIZE];
            Reset();
        }

        public void Reset() {
            for (int i = 0; i < registros.Length; i++)
                registros[i] = 0;
        }

        public ResultadoEjecucion EjecutarInstruccion()
        {
            ResultadoEjecucion result = new ResultadoEjecucion();
            int pc = registros[PC_REG];
            int memDir, r, s, t;

            if( !maquina.IMem.Instrucciones.ContainsKey(pc) ){
                result.Status = EjecucionStatus.HALT;
                return result;
            }
            
            Operacion op = maquina.IMem.Instrucciones[pc];
            registros[PC_REG]+=1;
            r = (int)op.R.value;
            s = (int)op.S.value;
            t = (int)op.T.value;
            memDir = s + registros[t];

            result.TipoAcceso = TipoOperacionAcceso.REG_CAMBIADO;
            result.Info = r;

            switch (op.Opcode.sym)
            {
                /* Operaciones RO*/
                case TokenDef.HALT:
                    result.Status = EjecucionStatus.HALT;
                    result.TipoAcceso = TipoOperacionAcceso.NINGUNA;
                    break;
                case TokenDef.IN:
                    int valor = maquina.DispararLeerValorEvent();
                    registros[r] = valor;
                    break;
                case TokenDef.OUT:
                    maquina.DispararMostarValorEvent(registros[r]);
                    break;
                case TokenDef.ADD:
                    registros[r] = registros[s] + registros[t];
                    break;
                case TokenDef.SUB:
                    registros[r] = registros[s] - registros[t];
                    break;
                case TokenDef.MUL:
                    registros[r] = registros[s] * registros[t];
                    break;
                case TokenDef.DIV:
                    if (registros[t] == 0)
                        throw new DivisionPorCeroException(op.NumeroOp);
                    registros[r] = registros[s] / registros[t];
                    break;
                /* Operaciones RM*/
                case TokenDef.LD:
                    if (!EsValidaDirMem(memDir))
                        throw new ErrorAccesoMemoriaException(memDir);

                    registros[r] = maquina.DMem[memDir];
                    break;
                case TokenDef.ST:
                    if (!EsValidaDirMem(memDir))
                        throw new ErrorAccesoMemoriaException(memDir);

                    maquina.DMem[memDir] = registros[r];
                    result.TipoAcceso = TipoOperacionAcceso.MEMORIA_CAMBIADA;
                    result.Info = memDir;
                    break;
                /* Operaciones RA*/
                case TokenDef.LDA:
                    registros[r] = memDir;
                    break;
                case TokenDef.LDC:
                    registros[r] = s;
                    break;
                case TokenDef.JLT:
                    if (registros[r] < 0)
                        registros[PC_REG] = memDir;
                    result.Info = PC_REG;
                    break;
                case TokenDef.JLE:
                    if (registros[r] <= 0)
                        registros[PC_REG] = memDir;
                    result.Info = PC_REG;
                    break;
                case TokenDef.JGE:
                    if (registros[r] >= 0)
                        registros[PC_REG] = memDir;
                    result.Info = PC_REG;
                    break;
                case TokenDef.JGT:
                    if (registros[r] > 0)
                        registros[PC_REG] = memDir;
                    result.Info = PC_REG;
                    break;
                case TokenDef.JEQ:
                    if (registros[r] == 0)
                        registros[PC_REG] = memDir;
                    result.Info = PC_REG;
                    break;
                case TokenDef.JNE:
                    if (registros[r] != 0)
                        registros[PC_REG] = memDir;
                    result.Info = PC_REG;
                    break;
            }

            return result;
        }

        private bool EsValidaDirMem(int dirMem) {
            return dirMem >= 0 && dirMem < MaquinaTiny.RAM_SIZE; 
        }
    }
}
