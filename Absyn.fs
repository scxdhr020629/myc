(* File MicroC/Absyn.fs
   Abstract syntax of micro-C, an imperative language.
   sestoft@itu.dk 2009-09-25

   Must precede Interp.fs, Comp.fs and Contcomp.fs in Solution Explorer
 *)

module Absyn

// 基本类型
// 注意，数组、指针是递归类型
// 这里没有函数类型，注意与上次课的 MicroML 对比
type typ =
  | TypI                             (* Type int                    *)
  | TypC                             (* Type char                   *)
  | TypA of typ * int option         (* Array type                  *)
  | TypP of typ                      (* Pointer type                *)
  | TypS 
  | TypF
  | TypStruct of string
                                                                   
and expr =                           // 表达式，右值                                                
  | Access of access                 (* x    or  *p    or  a[e]     *) //访问左值（右值）
  | Assign of access * expr          (* x=e  or  *p=e  or  a[e]=e   *)
  | AddAss of access * expr          (* += 表达式 *)
  | MinusAss of access * expr        (* -= 表达式 *)
  | TimesAss of access * expr        (* *= 表达式 *)
  | DivAss of access * expr          (* /= 表达式 *)
  | ModAss of access * expr          (* %= 表达式 *)
  | OpAssign of string * access * expr
  | Addr of access                   (* &x   or  &*p   or  &a[e]    *)
  | CstI of int                      (* Constant                    *)
  | CstC of char                      //char
  | CstS of string
  | CstF of float32
  | Prim1 of string * expr           (* Unary primitive operator    *)
  | Prim2 of string * expr * expr    (* Binary primitive operator   *)
  | Prim3 of expr * expr * expr      (* 三目运算 e1 ? e2 : e3        *)
  | Printf of string * expr list     (* 格式化输出 *)  
  | Andalso of expr * expr           (* Sequential and              *)
  | Orelse of expr * expr            (* Sequential or               *)
  | Call of string * expr list       (* Function call f(...)        *)
  | PreAdd of access                 (* ++i *)
  | PreMinus of access               (* --i *)
  | NextAdd of access                (* x++ *)
  | NextMinus of access                (* x-- *)
  | Bino of expr * expr * expr       (* 三目运算 *)
                                                                   
and access =                         //左值，存储的位置                                            
  | AccVar of string                 (* Variable access        x    *) 
  | AccDeref of expr                 (* Pointer dereferencing  *p   *)
  | AccIndex of access * expr        (* Array indexing         a[e] *)
  | VarAccess of string
                                                                   
and stmt =                                                         
  | If of expr * stmt * stmt         (* Conditional                 *)
  | While of expr * stmt             (* While loop                  *)
  | Expr of expr                     (* Expression statement   e;   *)
  | Return of expr option            (* Return from method          *)
  | Block of stmtordec list          (* Block: grouping and scope   *)
  | DoWhile of stmt * expr
  | DoUntil of stmt * expr
  | For of expr * expr * stmt * stmt (* for(i=0;i<5;i+=1;){...} *)
  | ForInRange1 of string * expr * stmt (* for x in range(5){...} *)
  | ForInRange2 of string * expr * expr * stmt (* for x in range(5,10){...} *)
  | ForInRange3 of string * expr * expr * expr * stmt (* for x in range(5,10,2){...} *)
  | Switch of expr * stmt list
  | Case of expr * stmt
  | Break
  | Continue  

  // 语句块内部，可以是变量声明 或语句的列表                                                              

and stmtordec =                                                    
  | Dec of typ * string              (* Local variable declaration  *)
  | Stmt of stmt                     (* A statement                 *)
  | DecWithAssign of  typ * string * expr (*声明且定义*)

// 顶级声明 可以是函数声明或变量声明
and topdec = 
  | Fundec of typ option * string * (typ * string) list * stmt
  | Vardec of typ * string
  | VarDecWithAssign of typ * string * expr

// 程序是顶级声明的列表
and program = 
  | Prog of topdec list
