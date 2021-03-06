## Gramática

> **Minúsculas**: No terminales <br/>
> **Mayúsculas**: Terminales

### Gramática original

```
program -> declaration-star statement-star

declaration-star -> declaration declaration-star
declaration-star -> ''

declaration -> type Identifier

statement-star -> statement statement-star
statement-star -> ''

statement -> assignment
statement -> print
statement -> condition

type -> Int
type -> Bool

assignment -> Identifier Equals expression

print -> Print expression

condition -> If expression Then statement-star End

expression -> expression Operator simple-expression
expression -> simple-expression

simple-expression -> Identifier
simple-expression -> Integer
simple-expression -> Boolean
simple-expression -> LParen expression RParen
simple-expression -> Minus simple-expression
```

## Gramática final
```
program -> declaration-star statement-star

declaration-star -> declaration declaration-star
declaration-star -> ''

declaration -> type Identifier

statement-star -> statement statement-star
statement-star -> ''

statement -> assignment
statement -> print
statement -> condition

type -> Int
type -> Bool

assignment -> Identifier Equals expression

print -> Print expression

condition -> If expression Then statement-star End

expression -> simple-expression expression-prime
expression-prime -> Operator simple-expression expression-prime
expression-prime -> ''

simple-expression -> Identifier
simple-expression -> Integer
simple-expression -> Boolean
simple-expression -> LParen expression RParen
simple-expression -> Minus simple-expression
```

## Conjuntos First y Follow

### First

| symbol | set |
| ----: | :---|
| program | Int, Bool, Identifier, Print, If, ε |
| declaration-star | Int, Bool, ε |
| declaration | Int, Bool |
| statement-star | Identifier, Print, If, ε |
| statement | Identifier, Print, If |
| type | Int, Bool |
| assignment | Identifier |
| print | Print |
| condition | If |
| expression | Identifier, Integer, Boolean, LParen, Minus |
| expression-prime | Operator, ε |
| simple-expression | Identifier, Integer, Boolean, LParen, Minus |


### Follow

| symbol | set |
| ----: | :---|
| program | $ |
| declaration-star | Identifier, Print, If, $ |
| declaration | Int, Bool, Identifier, Print, If, $ |
| statement-star | End, $ |
| statement | Identifier, Print, If, End, $ |
| type | Identifier |
| assignment | Identifier, Print, If, End, $ |
| print | Identifier, Print, If, End, $ |
| condition | Identifier, Print, If, End, $ |
| expression | Identifier, Print, If, Then, RParen, End, $ |
| expression-prime | Identifier, Print, If, Then, RParen, End, $ |
| simple-expression | Identifier, Print, If, Then, Rparen, End, Operator, $ |

## Tabla

### Producciones
| id  | production |
|:---:| :--------- |
1 | program -> declaration-star statement-star
2 | declaration-star -> declaration declaration-star
3 | declaration-star -> ''
4 | declaration -> type Identifier
5 | statement-star -> statement statement-star
6 | statement-star -> ''
7 | statement -> assignment
8 | statement -> print
9 | statement -> condition
10| type -> Int
11| type -> Bool
12| assignment -> Identifier Equals expression
13| print -> Print expression
14| condition -> If expression Then statement-star End
15| expression -> simple-expression expression-prime
16| expression-prime -> Operator simple-expression expression-prime
17| expression-prime -> ''
18| simple-expression -> Identifier
19| simple-expression -> Integer
20| simple-expression -> Boolean
21| simple-expression -> LParen expression RParen
22| simple-expression -> Minus simple-expression


### Tabla

| simbol \ terminal | Identifier | Int | Bool | Equals | Print | If  | Then | End | Operator | Integer | Boolean | LParen | RParen | Minus | $   |
| ----------------: | :--------: |:---:| :---:| :----: | :---: |:---:| :---:|:---:| :------: | :-----: | :-----: | :----: | :----: | :---: |:---:|
| program           | 1          | 1   | 1    |        | 1     | 1   |      |     |          |         |         |        |        |       | 1   |
| declaration-star  | 3          | 2   | 2    |        | 3     | 3   |      |     |          |         |         |        |        |       | 3   |
| declaration       |            | 4   | 4    |        |       |     |      |     |          |         |         |        |        |       |     |
| statement-star    | 5          |     |      |        | 5     | 5   |      | 6   |          |         |         |        |        |       | 6   |
| statement         | 7          |     |      |        | 8     | 9   |      |     |          |         |         |        |        |       |     |
| type              |            | 10  | 11   |        |       |     |      |     |          |         |         |        |        |       |     |
| assignment        | 12         |     |      |        |       |     |      |     |          |         |         |        |        |       |     |
| print             |            |     |      |        | 13    |     |      |     |          |         |         |        |        |       |     |
| condition         |            |     |      |        |       | 14  |      |     |          |         |         |        |        |       |     |
| expression        | 15         |     |      |        |       |     |      |     |          | 15      | 15      | 15     |        | 15    |     |
| expression-prime  | 17         |     |      |        | 17    | 17  | 17   | 17  | 16       |         |         |        | 17     |       | 17  |
| simple-expression | 18         |     |      |        |       |     |      |     |          | 19      | 20      | 21     |        | 22    |     |

## Dependencias
Este proyecto fue compilado utilizando las siguientes dependencias

- dotnet-runtime 3.1.2.sdk102-1
- dotnet-sdk 3.1.2.sdk102-1

## Compilar
Dentro del directorio Compilador, ejecuta los siguientes comandos:
```bash
# Restore the dependencies and tools for the projects
dotnet restore
# Build the solution
dotnet build
```

## Uso
Dentro del directorio Compilador, ejecuta el siguiente comando:
```bash
# Run the compiler. If no file is provided it uses stdin as input
dotnet run /Path/To/Source.any
```

## Ejemplos de salida con impresión de stack

En el directorio de output se puede encontrar el resultado de la evaluación de los ejemplos incluyendo el stack y el siguiente del input. Aquí se muestra el ejemplo de la cadena correcta.

`good.txt`
```
stack: { Program, TokenEOF, } next: [TokenInt]
stack: { DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { Declaration, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { Type, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { TokenInt, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { Declaration, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { Type, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { TokenInt, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { Declaration, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { Type, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { TokenBool, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenId] b1
stack: { DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { Declaration, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { Type, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { TokenBool, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenId] b2
stack: { DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { Declaration, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { Type, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { TokenInt, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenInt]
stack: { TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { Declaration, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { Type, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { TokenBool, TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenBool]
stack: { TokenId, DeclarationStar, StatementStar, TokenEOF, } next: [TokenId] b3
stack: { DeclarationStar, StatementStar, TokenEOF, } next: [TokenId] b1
stack: { StatementStar, TokenEOF, } next: [TokenId] b1
stack: { Statement, StatementStar, TokenEOF, } next: [TokenId] b1
stack: { Assigment, StatementStar, TokenEOF, } next: [TokenId] b1
stack: { TokenId, TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenId] b1
stack: { TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenEquals]
stack: { Expression, StatementStar, TokenEOF, } next: [TokenBoolean] True
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenBoolean] True
stack: { TokenBoolean, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenBoolean] True
stack: { ExpressionPrime, StatementStar, TokenEOF, } next: [TokenId] b2
stack: { StatementStar, TokenEOF, } next: [TokenId] b2
stack: { Statement, StatementStar, TokenEOF, } next: [TokenId] b2
stack: { Assigment, StatementStar, TokenEOF, } next: [TokenId] b2
stack: { TokenId, TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenId] b2
stack: { TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenEquals]
stack: { Expression, StatementStar, TokenEOF, } next: [TokenBoolean] False
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenBoolean] False
stack: { TokenBoolean, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenBoolean] False
stack: { ExpressionPrime, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { StatementStar, TokenEOF, } next: [TokenId] num1
stack: { Statement, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { Assigment, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { TokenId, TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenEquals]
stack: { Expression, StatementStar, TokenEOF, } next: [TokenInteger] 10
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenInteger] 10
stack: { TokenInteger, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenInteger] 10
stack: { ExpressionPrime, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { StatementStar, TokenEOF, } next: [TokenId] num2
stack: { Statement, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { Assigment, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { TokenId, TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { TokenEquals, Expression, StatementStar, TokenEOF, } next: [TokenEquals]
stack: { Expression, StatementStar, TokenEOF, } next: [TokenInteger] 1878
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenInteger] 1878
stack: { TokenInteger, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenInteger] 1878
stack: { ExpressionPrime, StatementStar, TokenEOF, } next: [TokenIf]
stack: { StatementStar, TokenEOF, } next: [TokenIf]
stack: { Statement, StatementStar, TokenEOF, } next: [TokenIf]
stack: { Condition, StatementStar, TokenEOF, } next: [TokenIf]
stack: { TokenIf, Expression, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenIf]
stack: { Expression, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { SimpleExpression, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { TokenId, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenOperator] LT
stack: { TokenOperator, SimpleExpression, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenOperator] LT
stack: { SimpleExpression, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { TokenId, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenThen]
stack: { TokenThen, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenThen]
stack: { StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { Statement, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { Assigment, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { TokenId, TokenEquals, Expression, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { TokenEquals, Expression, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenEquals]
stack: { Expression, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { TokenId, ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num1
stack: { ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenOperator] Prod
stack: { TokenOperator, SimpleExpression, ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenOperator] Prod
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { TokenId, ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenIf]
stack: { StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenIf]
stack: { Statement, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenIf]
stack: { Condition, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenIf]
stack: { TokenIf, Expression, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenIf]
stack: { Expression, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { SimpleExpression, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { TokenId, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num2
stack: { ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenOperator] LT
stack: { TokenOperator, SimpleExpression, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenOperator] LT
stack: { SimpleExpression, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { TokenId, ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { ExpressionPrime, TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenThen]
stack: { TokenThen, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenThen]
stack: { StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenPrint]
stack: { Statement, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenPrint]
stack: { Print, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenPrint]
stack: { TokenPrint, Expression, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenPrint]
stack: { Expression, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenBoolean] True
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenBoolean] True
stack: { TokenBoolean, ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenBoolean] True
stack: { ExpressionPrime, StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenEnd]
stack: { StatementStar, TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenEnd]
stack: { TokenEnd, StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenEnd]
stack: { StatementStar, TokenEnd, StatementStar, TokenEOF, } next: [TokenEnd]
stack: { TokenEnd, StatementStar, TokenEOF, } next: [TokenEnd]
stack: { StatementStar, TokenEOF, } next: [TokenPrint]
stack: { Statement, StatementStar, TokenEOF, } next: [TokenPrint]
stack: { Print, StatementStar, TokenEOF, } next: [TokenPrint]
stack: { TokenPrint, Expression, StatementStar, TokenEOF, } next: [TokenPrint]
stack: { Expression, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { SimpleExpression, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { TokenId, ExpressionPrime, StatementStar, TokenEOF, } next: [TokenId] num3
stack: { ExpressionPrime, StatementStar, TokenEOF, } next: [TokenEOF]
stack: { StatementStar, TokenEOF, } next: [TokenEOF]
stack: { TokenEOF, } next: [TokenEOF]
Compiled successfully!
```