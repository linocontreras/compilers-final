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

| simbol \ terminal | Int | Bool | Identifier | Print | If  | Then | End | Operator | LParen | RParen | Minus | $   |
| ----------------: |:---:| :---:| :--------: | :---: |:---:| :---:|:---:| :------: | :----: | :----: | :---: |:---:|
| program           | 1   | 1    | 1          | 1     | 1   |      |     |          |        |        |       | 1   |
| declaration-star  | 2   | 2    | 3          | 3     | 3   |      |     |          |        |        |       | 3   |
| declaration       |     |      |            |       |     |      |     |          |        |        |       |     |
| statement-star    |     |      |            |       |     |      |     |          |        |        |       |     |
| statement         |     |      |            |       |     |      |     |          |        |        |       |     |
| type              |     |      |            |       |     |      |     |          |        |        |       |     |
| assignment        |     |      |            |       |     |      |     |          |        |        |       |     |
| print             |     |      |            |       |     |      |     |          |        |        |       |     |
| condition         |     |      |            |       |     |      |     |          |        |        |       |     |
| expression        |     |      |            |       |     |      |     |          |        |        |       |     |
| expression-prime  |     |      |            |       |     |      |     |          |        |        |       |     |
| simple-expression |     |      |            |       |     |      |     |          |        |        |       |     |

