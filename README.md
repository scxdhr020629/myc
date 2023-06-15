# 实验报告

- 课程名称：编程语言原理与编译
- 实验项目：期末大作业
- 专业班级：计算机2001 计算机2002
- 学生学号：32001027 320010
- 学生姓名：常睿嘉 司晨旭 
- 实验指导教师：郭鸣

## 实验内容

#### 分工：

| 姓名   | 学号     | 班级       | 任务                               | 权重   |
| ------ | -------- | ---------- | ---------------------------------- | ------ |
| Name   | No.      | Class      | Task                               | Factor |
| 常睿嘉 | 32001027 | 计算机2001 | 解释器（主要）、编译器、测试、文档 | 0.95   |
| 司晨旭 | 320010   | 计算机2002 | 解释器、编译器（主要）、测试、文档 | 0.95   |

#### 成员代码提交日志：

- 常睿嘉：

![commit_crj](assets/commit1.png)

![commit_crj](assets/commit2.png)

- 司晨旭：





#### 项目自评等级(1-5)：

| 功能                               | 评分 | 备注 |
| ---------------------------------- | ---- | ---- |
| 注释(* *)                          | 5    |      |
| __开头的名字不允许                 | 5    |      |
| DoWhile循环                        | 5    |      |
| DoUntil循环                        | 5    |      |
| 三目运算                           | 5    |      |
| +=、-=、*=、/=、%=语法糖           | 5    |      |
| for循环                            | 5    |      |
| for i in range(until)              | 5    |      |
| for i in range(start, until)       | 5    |      |
| for i in range(start, until, step) | 5    |      |
| i++  i--                           | 4    |      |
| ++i --i                            | 4    |      |
| switch case                        | 4    |      |
| 数据初值定义                       | 5    |      |
| float类型                          | 4    |      |
| bool类型                           | 5    |      |
| 各类数组，数组检查                 | 5    |      |
|                                    |      |      |

#### 项目说明：

- 前端：由`F#`语言编写而成
  - `Absyn.fs`: 抽象语法树结构的定义
  - `CLex.fsl`: 词法定义
    - `CLex.fs`：由`CLex.fsl`生成的词法分析器
  - `CPar.fsy`: 语法定义
    - `CPar.fs`：由`CPar.fsy`生成的语法分析器
  - `Parse.fs`: 语法解析器（从文件或字符串中获取抽象语法树）
  - `Interp.fs`: 解释器
  - `Comp.fs`: 编译器
  - `Contcomp.fs`: 优化编译器
  - `Machine.fs`: 栈式虚拟机指令的定义及将其转化为机器指令序列
- 后端：由`C`语言编写而成
  - `machine.c`: 栈式虚拟机
- 测试：测试程序放在`testCase`文件夹内

- 使用方法

  **解释器：**

  ```
  dotnet restore  interpc.fsproj
  dotnet clean  interpc.fsproj
  dotnet build -v n interpc.fsproj
  dotnet run -p interpc.fsproj .\example\myex1.c 3  # 解释执行
  ```

  **编译器：**

  ```
  dotnet restore  microc.fsproj
  dotnet clean  microc.fsproj
  dotnet build  microc.fsproj  
  gcc machine.c -o machine  # 不用每次  改了machine.c再编译过即可
  
  dotnet run -p microc.fsproj .\example\myex1.c 3  # 编译
  .\machine.exe .\example\myex1.out 3  # 执行
  ```

  **优化编译器**

  ```
  dotnet restore  microcc.fsproj
  dotnet clean  microcc.fsproj
  dotnet build  microcc.fsproj
  dotnet run -p microcc.fsproj .\example\myex1.c 3
  .\machine.exe .\example\myex1.out 3
  ```

#### 功能实现及解决技术要点说明：

<<<<<<< HEAD
### 1、增加注释的表示方式(* *)
=======
##### 1、增加注释的表示方式(* *)
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/starComment.c

未加(* *)时，输入2，输出5：

![test1](assets/test1_1.png)

![test1](assets/test1_2.png)

增加(* *)时，输入2，输出2：

![test1](assets/test1_3.png)

![test1](assets/test1_4.png)

生成的token序列以及抽象语法树：

![test1](assets/test1_5.png)

程序结束后的输出以及store环境：

![test1](assets/test1_6.png)

![test1](assets/test1_7.png)

##### 2、实现DoWhile

先执行函数体`body `的内容，因为执行`exec`会改变`store`的内容，所以先返回变更的环境；然后将`do`中表达式的值传给`v`  如果条件等于0（条件为真）就继续执行循环

测试代码testCase/doWhile.c

输入2，输出0：

![test2](assets/test2_1.png)

![test2](assets/test2_2.png)

输入5，输出10：

![test2](assets/test2_3.png)

生成的token序列以及抽象语法树：

![test2](assets/test2_4.png)

程序结束后的输出以及store环境：

![test2](assets/test2_5.png)

**编译器：**

测试：

![test2](assets/test2_6.png)

输出：（输入5 ，输出10）

![test2](assets/test2_7.png)

![test2](assets/test2_8.png)

<<<<<<< HEAD
### 3、实现DoUntil
=======
##### 3、实现DoUntil
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

与DoWhile类似，只不过`v`不等于0（条件为假）继续执行循环

测试代码testCase/test3.c

更名为 doUntil.c

无输入，经过do until循环后，输出5：

![test3](assets/test3_1.png)

![test3](assets/test3_2.png)

生成的token序列以及抽象语法树：

![test3](assets/test3_3.png)

程序结束后的输出以及store环境：

![test3](assets/test3_4.png)

**编译器：**

测试：

![test3](assets/test3_5.png)

输出：5

![test3](assets/test3_6.png)

<<<<<<< HEAD
### 4、三目运算
=======
##### 4、三目运算
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

三目运算符为右值表达式，如果`?`前的表达式的值为真时，将`:`前的值存入，否则存入`:`后的值

测试代码testCase/tco.c  (*ternary conditional operator*)

当`?`前的表达式的值为真时：

![test4](assets/test4_1.png)

![test4](assets/test4_2.png)

当`?`前的表达式的值为假时：

![test4](assets/test4_3.png)

![test4](assets/test4_4.png)

生成的token序列以及抽象语法树：

![test4](assets/test4_5.png)

程序结束后的输出以及store环境：

![test4](assets/test4_6.png)

<<<<<<< HEAD
### 5、+=、-=、*=、/=、%=
=======
##### 5、+=、-=、*=、/=、%=
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/assignmentOperators.c

![test6](assets/test6_1.png)

![test6](assets/test6_2.png)

生成的token序列以及抽象语法树：

![test6](assets/test6_3.png)

程序结束后的输出以及store环境：

![test6](assets/test6_4.png)

**+=编译器：**

测试代码：

![test6](assets/test6_7.png)

成功编译：

![test6](assets/test6_5.png)

![test6](assets/test6_8.png)

虚拟机构建与执行：输出为2

![test6](assets/test6_6.png)

<<<<<<< HEAD
### 6、for i in range(until){...}
=======
##### 6、for i in range(until){...}
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/test7.c

更名为 forIn1.c

![test7](assets/test7_1.png)

![test7](assets/test7_2.png)

<<<<<<< HEAD
### 7、for i in range(start, until){...}
=======
##### 7、for i in range(start, until){...}
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/forIn2.c

![test8](assets/test8_1.png)

![test8](assets/test8_2.png)

生成的token序列以及抽象语法树：

![test8](assets/test8_3.png)

程序结束后的输出以及store环境：

![test8](assets/test8_4.png)

<<<<<<< HEAD
### 8、for i in range(start, until, step){...}
=======
##### 8、for i in range(start, until, step){...}
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/forIn3.c

![test9](assets/test9_1.png)

![test9](assets/test9_2.png)

生成的token序列以及抽象语法树：

![test9](assets/test9_3.png)

程序结束后的输出以及store环境：

![test9](assets/test9_4.png)

<<<<<<< HEAD
### 9、i++ i--和++i --i
=======
##### 9、i++ i--和++i --i
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/incAndDec.c

![test10](assets/test10_1.png)

![test10](assets/test10_2.png)

生成的token序列以及抽象语法树：

![test10](assets/test10_3.png)

程序结束后的输出以及store环境：

![test10](assets/test10_4.png)

**编译器：**

测试：

![test10](assets/test10_5.png)

输出：9 9 10 10

![test10](assets/test10_6.png)

<<<<<<< HEAD
### 10、switch case
=======
##### 10、switch case
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/mySwitch.c

![test11](assets/test11_1.png)

![test11](assets/test11_2.png)

生成的token序列以及抽象语法树：

![test11](assets/test11_3.png)

程序结束后的输出以及store环境：

![test11](assets/test11_4.png)

**编译器：**

测试：

![test11](assets/test11_5.png)

输出：（输入为2，输出2）

![test11](assets/test11_6.png)

<<<<<<< HEAD
### 11、变量声明时赋值
=======
##### 11、变量声明时赋值
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/varInit.c

![test12](assets/test12_1.png)

![test12](assets/test12_2.png)

生成的token序列以及抽象语法树：

![test12](assets/test12_3.png)

程序结束后的输出以及store环境：

![test12](assets/test12_4.png)

**编译器：**

测试：

![test12](assets/test12_5.png)

输出：1

![test12](assets/test12_6.png)

<<<<<<< HEAD
### 12、 两个下划线开头的名字__是内部保留，不允许
=======
##### 12、 两个下划线开头的名字__是内部保留，不允许
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398

测试代码testCase/test13.c

改名为 _var.c

![test13](assets/test13_1.png)

出错提醒：cannot use variable with start __

![test13](assets/test13_2.png)

<<<<<<< HEAD
### 13、float



### 14、bool等
=======
##### 13、float

##### 14、bool等
>>>>>>> 527d89821cecf1efc1d378e9ca84348cde1aa398





#### 心得体会（结合自己情况具体说明）：

大作业开发过程心得：

- 常睿嘉： 

  这学期的学业压力较重，特别是在面对编译原理这门比较难的科目时，我认为这门课程是大学四年相对困难的课程，之前完全没有接触过相关内容，在课堂上学习到的知识总是一知半解，课后还需要在理论知识上花费大量的时间去理解，觉得知识量太广太深。经历过这次大作业后，真正动手做工程，不仅仅停留在表面的理论，收获颇丰，对编译的本质和F#这门语言有了更具深刻的理解。

- 司晨旭：



本课程建议：

- 常睿嘉： 

  课程难度还是有点高，特别是大作业，突然从理论到写代码。希望老师能在平时课堂上就带着大家写写代码，实现小功能，讲解流程和理论。

  希望老师平时能讲一讲平时作业或者提供相应的答案

  希望大作业的比分降低一些，照顾大部分人的过课率

- 司晨旭：





