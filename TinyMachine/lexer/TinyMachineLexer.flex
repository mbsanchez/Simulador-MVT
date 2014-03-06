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

using TUVienna.CS_CUP;
using TUVienna.CS_CUP.Runtime;
using System.Collections;
using TinyMachine.parser;
%%
%{
	private string nombreArchivo;
	private int yycolumn;
	private string comentario;
	
	public int getLinea(){
		return yyline+1;
	}
	
	public int getColumna(){
		return yycolumn+1;
	}

    public void setNombreArchivo(string nombre) {
		this.nombreArchivo = nombre;
    }

    public string getNombreArchivo() {
		return nombreArchivo;
    }
	
	void updateColumn()
	{
		int i;

		for (i = 0; i<yytext().Length; i++)
			if (yytext()[i] == '\n')
				yycolumn = 0;
			else if (yytext()[i] == '\t')
				yycolumn += 8 - (yycolumn % 8);
			else
				yycolumn++;
	}
%}
%public
%class TinyMachineLexer
%line
%cup

%eofval{
  return new Symbol(TokenDef.EOF);
%eofval}

FIN_LINEA = \n|\r\n|\n\r
BLANCO = [ ]|\t|\v|\f
%%
<YYINITIAL>HALT			{ Symbol sym = new Symbol(TokenDef.HALT, getLinea(), getColumna(), new Symbol(TokenDef.HALT, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>IN			{ Symbol sym = new Symbol(TokenDef.IN, getLinea(), getColumna(), new Symbol(TokenDef.IN, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>OUT			{ Symbol sym = new Symbol(TokenDef.OUT, getLinea(), getColumna(), new Symbol(TokenDef.OUT, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>ADD			{ Symbol sym = new Symbol(TokenDef.ADD, getLinea(), getColumna(), new Symbol(TokenDef.ADD, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>SUB			{ Symbol sym = new Symbol(TokenDef.SUB, getLinea(), getColumna(), new Symbol(TokenDef.SUB, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>MUL			{ Symbol sym = new Symbol(TokenDef.MUL, getLinea(), getColumna(), new Symbol(TokenDef.MUL, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>DIV			{ Symbol sym = new Symbol(TokenDef.DIV, getLinea(), getColumna(), new Symbol(TokenDef.DIV, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>LD			{ Symbol sym = new Symbol(TokenDef.LD, getLinea(), getColumna(), new Symbol(TokenDef.LD, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>LDA			{ Symbol sym = new Symbol(TokenDef.LDA, getLinea(), getColumna(), new Symbol(TokenDef.LDA, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>LDC			{ Symbol sym = new Symbol(TokenDef.LDC, getLinea(), getColumna(), new Symbol(TokenDef.LDC, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>ST			{ Symbol sym = new Symbol(TokenDef.ST, getLinea(), getColumna(), new Symbol(TokenDef.ST, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>JLT			{ Symbol sym = new Symbol(TokenDef.JLT, getLinea(), getColumna(), new Symbol(TokenDef.JLT, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>JLE			{ Symbol sym = new Symbol(TokenDef.JLE, getLinea(), getColumna(), new Symbol(TokenDef.JLE, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>JGE			{ Symbol sym = new Symbol(TokenDef.JGE, getLinea(), getColumna(), new Symbol(TokenDef.JGE, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>JGT			{ Symbol sym = new Symbol(TokenDef.JGT, getLinea(), getColumna(), new Symbol(TokenDef.JGT, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>JEQ			{ Symbol sym = new Symbol(TokenDef.JEQ, getLinea(), getColumna(), new Symbol(TokenDef.JEQ, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>JNE			{ Symbol sym = new Symbol(TokenDef.JNE, getLinea(), getColumna(), new Symbol(TokenDef.JNE, getLinea(), getColumna())); updateColumn(); return sym;}
<YYINITIAL>"("			{ Symbol sym = new Symbol(TokenDef.PARENT_IZQ, getLinea(), getColumna()); updateColumn(); return sym;}
<YYINITIAL>")"			{ Symbol sym = new Symbol(TokenDef.PARENT_DER, getLinea(), getColumna()); updateColumn(); return sym;}
<YYINITIAL>":"			{ Symbol sym = new Symbol(TokenDef.COLON, getLinea(), getColumna()); updateColumn(); return sym;}
<YYINITIAL>","			{ Symbol sym = new Symbol(TokenDef.COMA, getLinea(), getColumna()); updateColumn(); return sym;}
<YYINITIAL>"*"			{ comentario="*";  char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_LINEA, getLinea(), col, comentario); }
<YYINITIAL>-?[0-9]+		{ Symbol sym = new Symbol(TokenDef.ENTERO, getLinea(), getColumna(), new Symbol(TokenDef.ENTERO, getLinea(), getColumna(), int.Parse(yytext()))); updateColumn(); return sym;}
<YYINITIAL>{BLANCO}		{ updateColumn(); break;}
<YYINITIAL>{FIN_LINEA}	{ Symbol sym = new Symbol(TokenDef.FIN_LINEA, getLinea(), getColumna()); updateColumn(); return sym;}
<YYINITIAL>[^*]		    { comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
<YYINITIAL>.			{ Symbol sym = new Symbol(TokenDef.ERROR, getLinea(), getColumna(), yytext()); updateColumn(); return sym;}