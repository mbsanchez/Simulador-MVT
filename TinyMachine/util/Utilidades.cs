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
using TUVienna.CS_CUP.Runtime;
using TinyMachine.parser;

namespace TinyMachine.util
{
    class Utilidades
    {
        private static string padding = "    ";
        public static readonly LinkedList<string> errorList = new LinkedList<string>();

        public static string tokenEnTexto(Symbol s)
        {
            switch(s.sym){
                case TinyMachine.parser.TokenDef.ADD:
                    return("ADD");
                case TinyMachine.parser.TokenDef.COLON:
                    return(":");
                case TinyMachine.parser.TokenDef.COMA:
                    return(",");
                case TinyMachine.parser.TokenDef.COMENTARIO_FIN:
                case TinyMachine.parser.TokenDef.COMENTARIO_LINEA:
                    return("COMENTARIO");
                case TinyMachine.parser.TokenDef.DIV:
                    return("DIV");
                case TinyMachine.parser.TokenDef.ENTERO:
                    return("ENTERO");
                case TinyMachine.parser.TokenDef.EOF:
                    return("EOF");
                case TinyMachine.parser.TokenDef.ERROR:
                    return("ERROR: "+s.value);
                case TinyMachine.parser.TokenDef.HALT:
                    return("HALT");
                case TinyMachine.parser.TokenDef.IN:
                    return("IN");
                case TinyMachine.parser.TokenDef.JEQ:
                    return("JEQ");
                case TinyMachine.parser.TokenDef.JGE:
                    return("JGE");
                case TinyMachine.parser.TokenDef.JGT:
                    return("JGT");
                case TinyMachine.parser.TokenDef.JLE:
                    return("JLE");
                case TinyMachine.parser.TokenDef.JLT:
                    return("JLT");
                case TinyMachine.parser.TokenDef.JNE:
                    return("JNE");
                case TinyMachine.parser.TokenDef.LD:
                    return("LD");
                case TinyMachine.parser.TokenDef.LDA:
                    return("LDA");
                case TinyMachine.parser.TokenDef.LDC:
                    return("LDC");
                case TinyMachine.parser.TokenDef.MUL:
                    return("MUL");
                case TinyMachine.parser.TokenDef.OUT:
                    return("OUT");
                case TinyMachine.parser.TokenDef.PARENT_DER:
                    return("(");
                case TinyMachine.parser.TokenDef.PARENT_IZQ:
                    return(")");
                case TinyMachine.parser.TokenDef.ST:
                    return("ST");
                case TinyMachine.parser.TokenDef.SUB:
                    return("SUB");
                case TinyMachine.parser.TokenDef.FIN_LINEA:
                    return("SALTO DE LINEA");
                default:
                    return ("<Token inválido: " + s.sym + ">");
            }
        }

        public static string tokenEnTextoConValor(Symbol s)
        {
            string str = "#" + s.left + ":" + s.right + ": " + tokenEnTexto(s);

            switch (s.sym)
            {
                case TokenDef.ENTERO:
                case TokenDef.COMENTARIO_FIN:
                case TokenDef.COMENTARIO_LINEA:
                    str += " = " + s.value;
                    break;
                case TokenDef.error:
                case TokenDef.ERROR:
                    str += " = \"" + s.value + "\"";
                    break;
            }

            return str;
        }

        public static void dumpToken(System.IO.TextWriter str, Symbol s)
        {
            str.Write("#" + s.left + ":" + s.right + ": " + tokenEnTexto(s));

            switch (s.sym)
            {
                case TokenDef.ENTERO:
                case TokenDef.COMENTARIO_FIN:
                case TokenDef.COMENTARIO_LINEA:
                    str.Write(" = " + s.value);
                    break;
                case TokenDef.error:
                case TokenDef.ERROR:
                    str.Write(" = \"");
                    str.Write(s.value);
                    str.Write("\"");
                    break;
            }
            str.WriteLine("");
        }

        public static String pad(int n)
        {
            if (n > 80)
            {
                return padding;
            }
            if (n < 0)
            {
                return "";
            }
            return padding.Substring(0, n);
        }

        public static void reportError(String msg)
        {
            errorList.AddLast(msg);
        }

        public static void reportError(string filename, string msg, Symbol s){
            reportError(filename + ": " + s.left + ":" + s.right + ": error: " + msg);
        }
    }
}
