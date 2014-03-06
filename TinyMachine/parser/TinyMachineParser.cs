
//----------------------------------------------------
// The following code was generated by C# CUP v0.1
// 06-03-2014 07:18:42 p.m.
//----------------------------------------------------

namespace TinyMachine.parser
 {

using TinyMachine.ast;
using TinyMachine.util;
using System.Collections;
using TUVienna.CS_CUP.Runtime;
using TUVienna.CS_CUP;
using System;

/** C# CUP v0.1 generated parser.
  * @version 06-03-2014 07:18:42 p.m.
  */
public class TinyMachineParser : TUVienna.CS_CUP.Runtime.lr_parser {

  /** Default constructor. */
  public TinyMachineParser():base() {;}

  /** Constructor which sets the default scanner. */
  public TinyMachineParser(TUVienna.CS_CUP.Runtime.Scanner s): base(s) {;}

  /** Production table. */
  protected static readonly short[][] _production_table = 
    unpackFromStrings(new string[] {
    "/000/037/000/002/002/004/000/002/003/003/000/002/004" +
    "/004/000/002/004/003/000/002/004/003/000/002/005/003" +
    "/000/002/005/006/000/002/005/006/000/002/012/003/000" +
    "/002/012/003/000/002/012/003/000/002/012/002/000/002" +
    "/006/004/000/002/006/004/000/002/006/004/000/002/006" +
    "/004/000/002/006/004/000/002/006/004/000/002/006/004" +
    "/000/002/010/007/000/002/007/004/000/002/007/004/000" +
    "/002/007/004/000/002/007/004/000/002/007/004/000/002" +
    "/007/004/000/002/007/004/000/002/007/004/000/002/007" +
    "/004/000/002/007/004/000/002/011/010" });

  /** Access to production table. */
  public override short[][] production_table() {return _production_table;}

  /** Parse-action table. */
  protected static readonly short[][] _action_table = 
    unpackFromStrings(new string[] {
    "/000/076/000/010/003/007/032/005/035/011/001/002/000" +
    "/010/002/ufffe/032/ufffe/035/ufffe/001/002/000/010/002/ufffc" +
    "/032/ufffc/035/ufffc/001/002/000/010/002/000/032/005/035" +
    "/011/001/002/000/010/002/ufffd/032/ufffd/035/ufffd/001/002" +
    "/000/004/002/077/001/002/000/004/027/012/001/002/000" +
    "/044/004/025/005/027/006/017/007/033/010/035/011/030" +
    "/012/032/013/014/014/024/015/020/016/023/017/022/020" +
    "/031/021/021/022/034/023/016/024/015/001/002/000/014" +
    "/002/ufff6/032/061/033/060/034/062/035/ufff6/001/002/000" +
    "/004/035/045/001/002/000/004/035/045/001/002/000/004" +
    "/035/045/001/002/000/004/035/037/001/002/000/004/035" +
    "/045/001/002/000/004/035/045/001/002/000/004/035/045" +
    "/001/002/000/004/035/045/001/002/000/004/035/045/001" +
    "/002/000/004/035/037/001/002/000/014/002/ufff6/032/061" +
    "/033/060/034/062/035/ufff6/001/002/000/004/035/037/001" +
    "/002/000/004/035/037/001/002/000/004/035/045/001/002" +
    "/000/004/035/037/001/002/000/004/035/037/001/002/000" +
    "/004/035/045/001/002/000/004/035/037/001/002/000/014" +
    "/002/ufff1/032/ufff1/033/ufff1/034/ufff1/035/ufff1/001/002/000" +
    "/004/030/040/001/002/000/004/035/041/001/002/000/004" +
    "/030/042/001/002/000/004/035/043/001/002/000/014/002" +
    "/uffee/032/uffee/033/uffee/034/uffee/035/uffee/001/002/000/014" +
    "/002/uffe6/032/uffe6/033/uffe6/034/uffe6/035/uffe6/001/002/000" +
    "/004/030/046/001/002/000/004/035/047/001/002/000/004" +
    "/026/050/001/002/000/004/035/051/001/002/000/004/025" +
    "/052/001/002/000/014/002/uffe3/032/uffe3/033/uffe3/034/uffe3" +
    "/035/uffe3/001/002/000/014/002/ufff2/032/ufff2/033/ufff2/034" +
    "/ufff2/035/ufff2/001/002/000/014/002/uffef/032/uffef/033/uffef" +
    "/034/uffef/035/uffef/001/002/000/014/002/uffe8/032/uffe8/033" +
    "/uffe8/034/uffe8/035/uffe8/001/002/000/014/002/ufff0/032/ufff0" +
    "/033/ufff0/034/ufff0/035/ufff0/001/002/000/014/002/ufff4/032" +
    "/ufff4/033/ufff4/034/ufff4/035/ufff4/001/002/000/010/002/ufff8" +
    "/032/ufff8/035/ufff8/001/002/000/010/002/ufff7/032/ufff7/035" +
    "/ufff7/001/002/000/010/002/ufff9/032/ufff9/035/ufff9/001/002" +
    "/000/010/002/ufffa/032/ufffa/035/ufffa/001/002/000/014/002" +
    "/ufff5/032/ufff5/033/ufff5/034/ufff5/035/ufff5/001/002/000/014" +
    "/002/uffec/032/uffec/033/uffec/034/uffec/035/uffec/001/002/000" +
    "/014/002/uffea/032/uffea/033/uffea/034/uffea/035/uffea/001/002" +
    "/000/014/002/uffe9/032/uffe9/033/uffe9/034/uffe9/035/uffe9/001" +
    "/002/000/014/002/uffe7/032/uffe7/033/uffe7/034/uffe7/035/uffe7" +
    "/001/002/000/014/002/uffeb/032/uffeb/033/uffeb/034/uffeb/035" +
    "/uffeb/001/002/000/014/002/ufff3/032/ufff3/033/ufff3/034/ufff3" +
    "/035/ufff3/001/002/000/014/002/uffe5/032/uffe5/033/uffe5/034" +
    "/uffe5/035/uffe5/001/002/000/014/002/uffe4/032/uffe4/033/uffe4" +
    "/034/uffe4/035/uffe4/001/002/000/014/002/uffed/032/uffed/033" +
    "/uffed/034/uffed/035/uffed/001/002/000/010/002/ufffb/032/ufffb" +
    "/035/ufffb/001/002/000/004/002/001/001/002/000/010/002" +
    "/uffff/032/uffff/035/uffff/001/002" });

  /** Access to parse-action table. */
  public override short[][] action_table() {return _action_table;}

  /** <code>reduce_goto</code> table. */
  protected static readonly short[][] _reduce_table = 
    unpackFromStrings(new string[] {
    "/000/076/000/010/003/007/004/005/005/003/001/001/000" +
    "/002/001/001/000/002/001/001/000/004/005/077/001/001" +
    "/000/002/001/001/000/002/001/001/000/002/001/001/000" +
    "/006/006/012/007/025/001/001/000/004/012/075/001/001" +
    "/000/004/011/074/001/001/000/004/011/073/001/001/000" +
    "/004/011/072/001/001/000/004/010/071/001/001/000/004" +
    "/011/070/001/001/000/004/011/067/001/001/000/004/011" +
    "/066/001/001/000/004/011/065/001/001/000/004/011/064" +
    "/001/001/000/004/010/063/001/001/000/004/012/062/001" +
    "/001/000/004/010/056/001/001/000/004/010/055/001/001" +
    "/000/004/011/054/001/001/000/004/010/053/001/001/000" +
    "/004/010/052/001/001/000/004/011/043/001/001/000/004" +
    "/010/035/001/001/000/002/001/001/000/002/001/001/000" +
    "/002/001/001/000/002/001/001/000/002/001/001/000/002" +
    "/001/001/000/002/001/001/000/002/001/001/000/002/001" +
    "/001/000/002/001/001/000/002/001/001/000/002/001/001" +
    "/000/002/001/001/000/002/001/001/000/002/001/001/000" +
    "/002/001/001/000/002/001/001/000/002/001/001/000/002" +
    "/001/001/000/002/001/001/000/002/001/001/000/002/001" +
    "/001/000/002/001/001/000/002/001/001/000/002/001/001" +
    "/000/002/001/001/000/002/001/001/000/002/001/001/000" +
    "/002/001/001/000/002/001/001/000/002/001/001/000/002" +
    "/001/001/000/002/001/001/000/002/001/001/000/002/001" +
    "/001" });

  /** Access to <code>reduce_goto</code> table. */
  public override short[][] reduce_table() {return _reduce_table;}

  /** Instance of action encapsulation class. */
  protected CUP_TinyMachineParser_actions action_obj;

  /** Action encapsulation object initializer. */
  protected override void init_actions()
    {
      action_obj = new CUP_TinyMachineParser_actions(this);
    }

  /** Invoke a user supplied parse action. */
  public override TUVienna.CS_CUP.Runtime.Symbol do_action(
    int                        act_num,
    TUVienna.CS_CUP.Runtime.lr_parser parser,
    System.Collections.Stack            xstack1,
    int                        top)
  {
  mStack CUP_parser_stack= new mStack(xstack1);
    /* call code in generated class */
    return action_obj.CUP_TinyMachineParser_do_action(act_num, parser, stack, top);
  }

  /** Indicates start state. */
  public override int start_state() {return 0;}
  /** Indicates start production. */
  public override int start_production() {return 0;}

  /** <code>EOF</code> Symbol index. */
  public override int EOF_sym() {return 0;}

  /** <code>error</code> Symbol index. */
  public override int error_sym() {return 1;}



    int omerrs = 0;

    public int getOmerrs(){
        return omerrs;
    }

    public override void syntax_error(Symbol cur_token) {
        int lineno = cur_token.left;
        int column = cur_token.right;
		string filename = action_obj.getNombreArchivo();
		string errorMsg = filename + ": " + lineno  + ":" + column + ": error de sintáxis cerca de " + Utilidades.tokenEnTexto(cur_token);

		Utilidades.reportError(errorMsg);
 
		omerrs++;
		if (Utilidades.errorList.Count>50) {
			Utilidades.reportError("El análisis se ha detenido porque se encontraron muchos errores");
			throw new ErrorAnalisisException("El análisis se ha detenido porque se encontraron muchos errores");
		}
    }

    public override void unrecovered_syntax_error(Symbol cur_token)
	{
    }

	public override void report_fatal_error(string   message, object   info)
	{
		Utilidades.reportError("ha ocurrido un error irrecuperable");
		throw new ErrorAnalisisException("ha ocurrido un error irrecuperable");
	}

}

/** Cup generated class to encapsulate user supplied action code.*/
public class CUP_TinyMachineParser_actions {

 

    public int getLinea() {
		return ((TinyMachineLexer)my_parser.getScanner()).getLinea();
    }

    public int getColumna(){
        return ((TinyMachineLexer)my_parser.getScanner()).getColumna();
    }

    public string getNombreArchivo() {
		return ((TinyMachineLexer)my_parser.getScanner()).getNombreArchivo();
    }

  private TinyMachineParser my_parser;

  /** Constructor */
  public CUP_TinyMachineParser_actions(TinyMachineParser t_parser) {
    this.my_parser = t_parser;
  }

  /** Method with the actual generated action code. */
  public   TUVienna.CS_CUP.Runtime.Symbol CUP_TinyMachineParser_do_action(
    int                        CUP_TinyMachineParser_act_num,
    TUVienna.CS_CUP.Runtime.lr_parser CUP_TinyMachineParser_parser,
    System.Collections.Stack            xstack1,
    int                        CUP_TinyMachineParser_top)
    {
      /* Symbol object for return from actions */
      mStack CUP_TinyMachineParser_stack =new mStack(xstack1);
      TUVienna.CS_CUP.Runtime.Symbol CUP_TinyMachineParser_result;

      /* select the action based on the action number */
      switch (CUP_TinyMachineParser_act_num)
        {
          /*. . . . . . . . . . . . . . . . . . . .*/
          case 30: // argRO ::= ENTERO COMA ENTERO PARENT_IZQ ENTERO PARENT_DER 
            {
              Operacion RESULT = null;
		Symbol r = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-5)).value;
		Symbol s = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-3)).value;
		Symbol t = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		 RESULT = new Operacion(r, s, t); 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(7/*argRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 29: // sentenciaRO ::= JNE argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 28: // sentenciaRO ::= JEQ argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 27: // sentenciaRO ::= JGT argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 26: // sentenciaRO ::= JGE argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 25: // sentenciaRO ::= JLE argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 24: // sentenciaRO ::= JLT argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 23: // sentenciaRO ::= ST argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 22: // sentenciaRO ::= LDC argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 21: // sentenciaRO ::= LDA argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 20: // sentenciaRO ::= LD argRO 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(5/*sentenciaRO*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 19: // argRM ::= ENTERO COMA ENTERO COMA ENTERO 
            {
              Operacion RESULT = null;
		Symbol r = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-4)).value;
		Symbol s = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-2)).value;
		Symbol t = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 RESULT = new Operacion(r,s,t); 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(6/*argRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 18: // sentenciaRM ::= DIV argRM 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(4/*sentenciaRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 17: // sentenciaRM ::= MUL argRM 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(4/*sentenciaRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 16: // sentenciaRM ::= SUB argRM 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(4/*sentenciaRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 15: // sentenciaRM ::= ADD argRM 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(4/*sentenciaRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 14: // sentenciaRM ::= OUT argRM 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(4/*sentenciaRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 13: // sentenciaRM ::= IN argRM 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(4/*sentenciaRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 12: // sentenciaRM ::= HALT argRM 
            {
              Operacion RESULT = null;
		Symbol op = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.Opcode = op; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(4/*sentenciaRM*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 11: // fin_sent ::= 
            {
              string RESULT = null;

              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(8/*fin_sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 10: // fin_sent ::= COMENTARIO_LINEA 
            {
              string RESULT = null;
		string c = (string)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 RESULT = c; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(8/*fin_sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 9: // fin_sent ::= COMENTARIO_FIN 
            {
              string RESULT = null;
		string c = (string)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 RESULT = c; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(8/*fin_sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 8: // fin_sent ::= FIN_LINEA 
            {
              string RESULT = null;
		 RESULT = ""; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(8/*fin_sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 7: // sent ::= ENTERO COLON sentenciaRO fin_sent 
            {
              Operacion RESULT = null;
		Symbol l = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-3)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		string c = (string)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.NumeroOp = (int)l.value; i.Comentario = c; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(3/*sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 6: // sent ::= ENTERO COLON sentenciaRM fin_sent 
            {
              Operacion RESULT = null;
		Symbol l = (Symbol)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-3)).value;
		Operacion i = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		string c = (string)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 i.NumeroOp = (int)l.value; i.Comentario = c; RESULT = i; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(3/*sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 5: // sent ::= COMENTARIO_LINEA 
            {
              Operacion RESULT = null;
		 RESULT = null; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(3/*sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 4: // secuencia_sent ::= error 
            {
              Programa RESULT = null;

              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(2/*secuencia_sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 3: // secuencia_sent ::= sent 
            {
              Programa RESULT = null;
		Operacion s = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 RESULT = new Programa(); if(s!=null) RESULT.Instrucciones[s.NumeroOp] = s; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(2/*secuencia_sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 2: // secuencia_sent ::= secuencia_sent sent 
            {
              Programa RESULT = null;
		Programa sc = (Programa)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		Operacion s = (Operacion)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 if(s!=null) sc.Instrucciones[s.NumeroOp] = s; RESULT = sc; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(2/*secuencia_sent*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 1: // programa ::= secuencia_sent 
            {
              Programa RESULT = null;
		Programa sc = (Programa)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-0)).value;
		 RESULT = sc; 
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(1/*programa*/, RESULT);
            }
          return CUP_TinyMachineParser_result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 0: // $START ::= programa EOF 
            {
              object RESULT = null;
		Programa start_val = (Programa)((TUVienna.CS_CUP.Runtime.Symbol) CUP_TinyMachineParser_stack.elementAt(CUP_TinyMachineParser_top-1)).value;
		RESULT = start_val;
              CUP_TinyMachineParser_result = new TUVienna.CS_CUP.Runtime.Symbol(0/*$START*/, RESULT);
            }
          /* ACCEPT */
          CUP_TinyMachineParser_parser.done_parsing();
          return CUP_TinyMachineParser_result;

          /* . . . . . .*/
          default:
            throw new System.Exception(
               "Invalid action number found in internal parse table");

        }
    }
}

}