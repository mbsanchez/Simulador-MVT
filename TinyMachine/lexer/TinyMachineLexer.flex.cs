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


public class TinyMachineLexer : TUVienna.CS_CUP.Runtime.Scanner {
	private const int YY_BUFFER_SIZE = 512;
	private const int YY_F = -1;
	private const int YY_NO_STATE = -1;
	private const int YY_NOT_ACCEPT = 0;
	private const int YY_START = 1;
	private const int YY_END = 2;
	private const int YY_NO_ANCHOR = 4;
	private const int YY_BOL = 128;
	private const int YY_EOF = 129;

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
	private System.IO.TextReader yy_reader;
	private int yy_buffer_index;
	private int yy_buffer_read;
	private int yy_buffer_start;
	private int yy_buffer_end;
	private char[] yy_buffer;
	private int yyline;
	private bool yy_at_bol;
	private int yy_lexical_state;

	public TinyMachineLexer (System.IO.TextReader yy_reader1) : this() {
		if (null == yy_reader1) {
			throw (new System.Exception("Error: Bad input stream initializer."));
		}
		yy_reader = yy_reader1;
	}

	private TinyMachineLexer () {
		yy_buffer = new char[YY_BUFFER_SIZE];
		yy_buffer_read = 0;
		yy_buffer_index = 0;
		yy_buffer_start = 0;
		yy_buffer_end = 0;
		yyline = 0;
		yy_at_bol = true;
		yy_lexical_state = YYINITIAL;
	}

	private bool yy_eof_done = false;
	private const int YYINITIAL = 0;
	private static readonly int[] yy_state_dtrans =new int[] {
		0
	};
	private void yybegin (int state) {
		yy_lexical_state = state;
	}
	private int yy_advance ()
	{
		int next_read;
		int i;
		int j;

		if (yy_buffer_index < yy_buffer_read) {
			return yy_buffer[yy_buffer_index++];
		}

		if (0 != yy_buffer_start) {
			i = yy_buffer_start;
			j = 0;
			while (i < yy_buffer_read) {
				yy_buffer[j] = yy_buffer[i];
				++i;
				++j;
			}
			yy_buffer_end = yy_buffer_end - yy_buffer_start;
			yy_buffer_start = 0;
			yy_buffer_read = j;
			yy_buffer_index = j;
			next_read = yy_reader.Read(yy_buffer,
					yy_buffer_read,
					yy_buffer.Length - yy_buffer_read);
			if ( next_read<=0) {
				return YY_EOF;
			}
			yy_buffer_read = yy_buffer_read + next_read;
		}

		while (yy_buffer_index >= yy_buffer_read) {
			if (yy_buffer_index >= yy_buffer.Length) {
				yy_buffer = yy_double(yy_buffer);
			}
			next_read = yy_reader.Read(yy_buffer,
					yy_buffer_read,
					yy_buffer.Length - yy_buffer_read);
			if ( next_read<=0) {
				return YY_EOF;
			}
			yy_buffer_read = yy_buffer_read + next_read;
		}
		return yy_buffer[yy_buffer_index++];
	}
	private void yy_move_end () {
		if (yy_buffer_end > yy_buffer_start &&
		    '\n' == yy_buffer[yy_buffer_end-1])
			yy_buffer_end--;
		if (yy_buffer_end > yy_buffer_start &&
		    '\r' == yy_buffer[yy_buffer_end-1])
			yy_buffer_end--;
	}
	private bool yy_last_was_cr=false;
	private void yy_mark_start () {
		int i;
		for (i = yy_buffer_start; i < yy_buffer_index; ++i) {
			if ('\n' == yy_buffer[i] && !yy_last_was_cr) {
				++yyline;
			}
			if ('\r' == yy_buffer[i]) {
				++yyline;
				yy_last_was_cr=true;
			} else yy_last_was_cr=false;
		}
		yy_buffer_start = yy_buffer_index;
	}
	private void yy_mark_end () {
		yy_buffer_end = yy_buffer_index;
	}
	private void yy_to_mark () {
		yy_buffer_index = yy_buffer_end;
		yy_at_bol = (yy_buffer_end > yy_buffer_start) &&
		            ('\r' == yy_buffer[yy_buffer_end-1] ||
		             '\n' == yy_buffer[yy_buffer_end-1] ||
		             2028/*LS*/ == yy_buffer[yy_buffer_end-1] ||
		             2029/*PS*/ == yy_buffer[yy_buffer_end-1]);
	}
	private string yytext () {
		return (new string(yy_buffer,
			yy_buffer_start,
			yy_buffer_end - yy_buffer_start));
	}
	private int yylength () {
		return yy_buffer_end - yy_buffer_start;
	}
	private char[] yy_double (char[] buf) {
		int i;
		char[] newbuf;
		newbuf = new char[2*buf.Length];
		for (i = 0; i < buf.Length; ++i) {
			newbuf[i] = buf[i];
		}
		return newbuf;
	}
	private const int YY_E_INTERNAL = 0;
	private const int YY_E_MATCH = 1;
	private string[] yy_error_string = {
		"Error: Internal error.\n",
		"Error: Unmatched input.\n"
	};
	private void yy_error (int code,bool fatal) {
		 System.Console.Write(yy_error_string[code]);
		 System.Console.Out.Flush();
		if (fatal) {
			throw new System.Exception("Fatal Error.\n");
		}
	}
	private static int[][] unpackFromString(int size1, int size2, string st) {
		int colonIndex = -1;
		string lengthString;
		int sequenceLength = 0;
		int sequenceInteger = 0;

		int commaIndex;
		string workString;

		int[][] res = new int[size1][];
		for(int i=0;i<size1;i++) res[i]=new int[size2];
		for (int i= 0; i < size1; i++) {
			for (int j= 0; j < size2; j++) {
				if (sequenceLength != 0) {
					res[i][j] = sequenceInteger;
					sequenceLength--;
					continue;
				}
				commaIndex = st.IndexOf(',');
				workString = (commaIndex==-1) ? st :
					st.Substring(0, commaIndex);
				st = st.Substring(commaIndex+1);
				colonIndex = workString.IndexOf(':');
				if (colonIndex == -1) {
					res[i][j]=System.Int32.Parse(workString);
					continue;
				}
				lengthString =
					workString.Substring(colonIndex+1);
				sequenceLength=System.Int32.Parse(lengthString);
				workString=workString.Substring(0,colonIndex);
				sequenceInteger=System.Int32.Parse(workString);
				res[i][j] = sequenceInteger;
				sequenceLength--;
			}
		}
		return res;
	}
	private int[] yy_acpt = {
		/* 0 */ YY_NOT_ACCEPT,
		/* 1 */ YY_NO_ANCHOR,
		/* 2 */ YY_NO_ANCHOR,
		/* 3 */ YY_NO_ANCHOR,
		/* 4 */ YY_NO_ANCHOR,
		/* 5 */ YY_NO_ANCHOR,
		/* 6 */ YY_NO_ANCHOR,
		/* 7 */ YY_NO_ANCHOR,
		/* 8 */ YY_NO_ANCHOR,
		/* 9 */ YY_NO_ANCHOR,
		/* 10 */ YY_NO_ANCHOR,
		/* 11 */ YY_NO_ANCHOR,
		/* 12 */ YY_NO_ANCHOR,
		/* 13 */ YY_NO_ANCHOR,
		/* 14 */ YY_NO_ANCHOR,
		/* 15 */ YY_NO_ANCHOR,
		/* 16 */ YY_NO_ANCHOR,
		/* 17 */ YY_NO_ANCHOR,
		/* 18 */ YY_NO_ANCHOR,
		/* 19 */ YY_NO_ANCHOR,
		/* 20 */ YY_NO_ANCHOR,
		/* 21 */ YY_NO_ANCHOR,
		/* 22 */ YY_NO_ANCHOR,
		/* 23 */ YY_NO_ANCHOR,
		/* 24 */ YY_NO_ANCHOR,
		/* 25 */ YY_NO_ANCHOR,
		/* 26 */ YY_NO_ANCHOR,
		/* 27 */ YY_NO_ANCHOR,
		/* 28 */ YY_NOT_ACCEPT,
		/* 29 */ YY_NO_ANCHOR,
		/* 30 */ YY_NO_ANCHOR,
		/* 31 */ YY_NOT_ACCEPT,
		/* 32 */ YY_NO_ANCHOR,
		/* 33 */ YY_NOT_ACCEPT,
		/* 34 */ YY_NO_ANCHOR,
		/* 35 */ YY_NOT_ACCEPT,
		/* 36 */ YY_NO_ANCHOR,
		/* 37 */ YY_NOT_ACCEPT,
		/* 38 */ YY_NO_ANCHOR,
		/* 39 */ YY_NOT_ACCEPT,
		/* 40 */ YY_NO_ANCHOR,
		/* 41 */ YY_NOT_ACCEPT,
		/* 42 */ YY_NO_ANCHOR,
		/* 43 */ YY_NOT_ACCEPT,
		/* 44 */ YY_NO_ANCHOR,
		/* 45 */ YY_NOT_ACCEPT,
		/* 46 */ YY_NO_ANCHOR,
		/* 47 */ YY_NOT_ACCEPT,
		/* 48 */ YY_NO_ANCHOR,
		/* 49 */ YY_NOT_ACCEPT,
		/* 50 */ YY_NO_ANCHOR
	};
	private int[] yy_cmap = unpackFromString(1,130,
"29:9,26,27,29,26,28,29:18,26,29:7,19,20,23,29,22,24,29:2,25:10,21,29:6,2,11" +
",14,9,16,29,17,1,5,15,29,3,12,6,7,29,18,29,10,4,8,13,29:31,26,29:9,0:2")[0];

	private int[] yy_rmap = unpackFromString(1,51,
"0,1,2,1:5,3,1,4,5,1:16,6,7,1,8,9,10,1,11,12,13,14,15,16,17,18,19,20,21,22,2" +
"3,3,24,25")[0];

	private int[][] yy_nxt = unpackFromString(26,30,
"1,2,29,32,34,36,34,38,34,40,42,34,44,34:2,46,34:3,3,4,5,6,7,48,8,9,10,50,34" +
",-1:32,28,-1:52,8,-1:32,30,-1:3,15,-1:11,16,-1:18,49,-1:35,31,-1:29,14,-1:2" +
"9,11,-1:24,17,-1:38,18,-1:22,12,-1:34,19,-1:26,33,-1:24,20,-1:31,35,-1:28,2" +
"1,-1:11,22,-1:17,13,-1:3,37,-1:37,23,-1:21,39,-1:39,24,-1:14,41,-1:2,43,-1:" +
"9,45,47,-1:16,25,-1:11,26,-1:17,27,-1:52,30,-1:2");

	public TUVienna.CS_CUP.Runtime.Symbol next_token ()
 {
		int yy_lookahead;
		int yy_anchor = YY_NO_ANCHOR;
		int yy_state = yy_state_dtrans[yy_lexical_state];
		int yy_next_state = YY_NO_STATE;
		int yy_last_accept_state = YY_NO_STATE;
		bool yy_initial = true;
		int yy_this_accept;

		yy_mark_start();
		yy_this_accept = yy_acpt[yy_state];
		if (YY_NOT_ACCEPT != yy_this_accept) {
			yy_last_accept_state = yy_state;
			yy_mark_end();
		}
		while (true) {
			if (yy_initial && yy_at_bol) yy_lookahead = YY_BOL;
			else yy_lookahead = yy_advance();
			yy_next_state = YY_F;
			yy_next_state = yy_nxt[yy_rmap[yy_state]][yy_cmap[yy_lookahead]];
			if (YY_EOF == yy_lookahead && true == yy_initial) {

  return new Symbol(TokenDef.EOF);
			}
			if (YY_F != yy_next_state) {
				yy_state = yy_next_state;
				yy_initial = false;
				yy_this_accept = yy_acpt[yy_state];
				if (YY_NOT_ACCEPT != yy_this_accept) {
					yy_last_accept_state = yy_state;
					yy_mark_end();
				}
			}
			else {
				if (YY_NO_STATE == yy_last_accept_state) {
					throw (new System.Exception("Lexical Error: Unmatched Input."));
				}
				else {
					yy_anchor = yy_acpt[yy_last_accept_state];
					if (0 != (YY_END & yy_anchor)) {
						yy_move_end();
					}
					yy_to_mark();
					switch (yy_last_accept_state) {
					case 1:
						break;
					case -2:
						break;
					case 2:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -3:
						break;
					case 3:
						{ Symbol sym = new Symbol(TokenDef.PARENT_IZQ, getLinea(), getColumna()); updateColumn(); return sym;}
					case -4:
						break;
					case 4:
						{ Symbol sym = new Symbol(TokenDef.PARENT_DER, getLinea(), getColumna()); updateColumn(); return sym;}
					case -5:
						break;
					case 5:
						{ Symbol sym = new Symbol(TokenDef.COLON, getLinea(), getColumna()); updateColumn(); return sym;}
					case -6:
						break;
					case 6:
						{ Symbol sym = new Symbol(TokenDef.COMA, getLinea(), getColumna()); updateColumn(); return sym;}
					case -7:
						break;
					case 7:
						{ comentario="*";  char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_LINEA, getLinea(), col, comentario); }
					case -8:
						break;
					case 8:
						{ Symbol sym = new Symbol(TokenDef.ENTERO, getLinea(), getColumna(), new Symbol(TokenDef.ENTERO, getLinea(), getColumna(), int.Parse(yytext()))); updateColumn(); return sym;}
					case -9:
						break;
					case 9:
						{ updateColumn(); break;}
					case -10:
						break;
					case 10:
						{ Symbol sym = new Symbol(TokenDef.FIN_LINEA, getLinea(), getColumna()); updateColumn(); return sym;}
					case -11:
						break;
					case 11:
						{ Symbol sym = new Symbol(TokenDef.LD, getLinea(), getColumna(), new Symbol(TokenDef.LD, getLinea(), getColumna())); updateColumn(); return sym;}
					case -12:
						break;
					case 12:
						{ Symbol sym = new Symbol(TokenDef.IN, getLinea(), getColumna(), new Symbol(TokenDef.IN, getLinea(), getColumna())); updateColumn(); return sym;}
					case -13:
						break;
					case 13:
						{ Symbol sym = new Symbol(TokenDef.ST, getLinea(), getColumna(), new Symbol(TokenDef.ST, getLinea(), getColumna())); updateColumn(); return sym;}
					case -14:
						break;
					case 14:
						{ Symbol sym = new Symbol(TokenDef.ADD, getLinea(), getColumna(), new Symbol(TokenDef.ADD, getLinea(), getColumna())); updateColumn(); return sym;}
					case -15:
						break;
					case 15:
						{ Symbol sym = new Symbol(TokenDef.LDA, getLinea(), getColumna(), new Symbol(TokenDef.LDA, getLinea(), getColumna())); updateColumn(); return sym;}
					case -16:
						break;
					case 16:
						{ Symbol sym = new Symbol(TokenDef.LDC, getLinea(), getColumna(), new Symbol(TokenDef.LDC, getLinea(), getColumna())); updateColumn(); return sym;}
					case -17:
						break;
					case 17:
						{ Symbol sym = new Symbol(TokenDef.OUT, getLinea(), getColumna(), new Symbol(TokenDef.OUT, getLinea(), getColumna())); updateColumn(); return sym;}
					case -18:
						break;
					case 18:
						{ Symbol sym = new Symbol(TokenDef.DIV, getLinea(), getColumna(), new Symbol(TokenDef.DIV, getLinea(), getColumna())); updateColumn(); return sym;}
					case -19:
						break;
					case 19:
						{ Symbol sym = new Symbol(TokenDef.SUB, getLinea(), getColumna(), new Symbol(TokenDef.SUB, getLinea(), getColumna())); updateColumn(); return sym;}
					case -20:
						break;
					case 20:
						{ Symbol sym = new Symbol(TokenDef.MUL, getLinea(), getColumna(), new Symbol(TokenDef.MUL, getLinea(), getColumna())); updateColumn(); return sym;}
					case -21:
						break;
					case 21:
						{ Symbol sym = new Symbol(TokenDef.JLT, getLinea(), getColumna(), new Symbol(TokenDef.JLT, getLinea(), getColumna())); updateColumn(); return sym;}
					case -22:
						break;
					case 22:
						{ Symbol sym = new Symbol(TokenDef.JLE, getLinea(), getColumna(), new Symbol(TokenDef.JLE, getLinea(), getColumna())); updateColumn(); return sym;}
					case -23:
						break;
					case 23:
						{ Symbol sym = new Symbol(TokenDef.JNE, getLinea(), getColumna(), new Symbol(TokenDef.JNE, getLinea(), getColumna())); updateColumn(); return sym;}
					case -24:
						break;
					case 24:
						{ Symbol sym = new Symbol(TokenDef.JEQ, getLinea(), getColumna(), new Symbol(TokenDef.JEQ, getLinea(), getColumna())); updateColumn(); return sym;}
					case -25:
						break;
					case 25:
						{ Symbol sym = new Symbol(TokenDef.JGT, getLinea(), getColumna(), new Symbol(TokenDef.JGT, getLinea(), getColumna())); updateColumn(); return sym;}
					case -26:
						break;
					case 26:
						{ Symbol sym = new Symbol(TokenDef.JGE, getLinea(), getColumna(), new Symbol(TokenDef.JGE, getLinea(), getColumna())); updateColumn(); return sym;}
					case -27:
						break;
					case 27:
						{ Symbol sym = new Symbol(TokenDef.HALT, getLinea(), getColumna(), new Symbol(TokenDef.HALT, getLinea(), getColumna())); updateColumn(); return sym;}
					case -28:
						break;
					case 29:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -29:
						break;
					case 30:
						{ Symbol sym = new Symbol(TokenDef.FIN_LINEA, getLinea(), getColumna()); updateColumn(); return sym;}
					case -30:
						break;
					case 32:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -31:
						break;
					case 34:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -32:
						break;
					case 36:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -33:
						break;
					case 38:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -34:
						break;
					case 40:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -35:
						break;
					case 42:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -36:
						break;
					case 44:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -37:
						break;
					case 46:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -38:
						break;
					case 48:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -39:
						break;
					case 50:
						{ comentario = yytext(); char c = (char)yy_advance(); while(c!='\n'){ if(c!='\r') comentario += c; c = (char)yy_advance(); }
						  int col = getColumna();
						  yycolumn = 0; return new Symbol(TokenDef.COMENTARIO_FIN, getLinea(), col, comentario); }
					case -40:
						break;
					default:
						yy_error(YY_E_INTERNAL,false);break;
					}
					yy_initial = true;
					yy_state = yy_state_dtrans[yy_lexical_state];
					yy_next_state = YY_NO_STATE;
					yy_last_accept_state = YY_NO_STATE;
					yy_mark_start();
					yy_this_accept = yy_acpt[yy_state];
					if (YY_NOT_ACCEPT != yy_this_accept) {
						yy_last_accept_state = yy_state;
						yy_mark_end();
					}
				}
			}
		}
	}
}
