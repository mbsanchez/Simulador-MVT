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
using TinyMachine.util;

namespace TinyMachine.semantical
{
    class SemanticalParser
    {
        public static void SemanticalParse(string filename, Programa programa){
            for (int i = 0; i < programa.Instrucciones.Count; i++)
            {
                Operacion instruccion = (Operacion)programa.Instrucciones[i];
                switch (instruccion.Opcode.sym) { 
                    case TokenDef.HALT:
                    case TokenDef.IN:
                    case TokenDef.OUT:
                    case TokenDef.ADD:
                    case TokenDef.SUB:
                    case TokenDef.MUL:
                    case TokenDef.DIV:
                        if (!isRegValid((int)instruccion.R.value))
                            Utilidades.reportError(filename, "el número de registro debe estar entre 0 y " + CPU.REG_SIZE, instruccion.R);
                        if (!isRegValid((int)instruccion.S.value))
                            Utilidades.reportError(filename, "el número de registro debe estar entre 0 y " + CPU.REG_SIZE, instruccion.S);
                        if (!isRegValid((int)instruccion.R.value))
                            Utilidades.reportError(filename, "el número de registro debe estar entre 0 y " + CPU.REG_SIZE, instruccion.T);
                        break;
                    case TokenDef.LD:
                    case TokenDef.LDA:
                    case TokenDef.LDC:
                    case TokenDef.ST:
                    case TokenDef.JLT:
                    case TokenDef.JLE:
                    case TokenDef.JGE:
                    case TokenDef.JGT:
                    case TokenDef.JEQ:
                    case TokenDef.JNE:
                        if (!isRegValid((int)instruccion.R.value))
                            Utilidades.reportError(filename, "el número de registro debe estar entre 0 y " + CPU.REG_SIZE, instruccion.R);
                        if (!isRegValid((int)instruccion.R.value))
                            Utilidades.reportError(filename, "el número de registro debe estar entre 0 y " + CPU.REG_SIZE, instruccion.T);
                        break;
                }
            }
        }

        private static bool isRegValid(int reg) {
            return reg >= 0 && reg < TinyMachine.CPU.REG_SIZE;
        }
    }
}
