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

