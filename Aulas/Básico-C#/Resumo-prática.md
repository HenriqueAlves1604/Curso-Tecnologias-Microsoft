**Curso Tecnologias Microsoft**

**Henrique Alves de Fernando - 15/05/2023**

# **Prática - Comandos Básicos C#**
## **1) Criando um projeto:**
* Necessário criar um **solution** e associar pelo menos um **projeto** a ela. 
* Podemos usar o [CLI do dotnet](https://learn.microsoft.com/en-us/dotnet/core/tools/) ou diretamente pelo VS-Code
* Criar diretório, mover-se a ele, criar arquivo .sln (solution), criar projeto e acomodá-lo no subdiretório \<DIR\>
* Se não usarmos `--output <DIR>` o projeto é criado no próprio diretório da solution
```
mkdir Teste
cd Teste
dotnet new sln
dotnet new console --output <DIR>
```
* Dois arquivos criados. Um **.cs** é template para o programa em C#; Desenvolvemos o programa nele. **.csproj** é um arquivo XML que descreve detalhes do projeto ([diretivas](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview))
* Vincular o projeto à solution e compilação:
```
dotnet sln add <DIR>
dotnet build
```

## **2) Tipos de dados em C#:**
* Linguagem fortemente tipada (variáveis devem ser precedidas pelo seu tipo)
* Tipos de dados primitivos = **tipos por valor (value types)**
* Objetos = **tipo por referência (reference types)**

### **2.1) Dados Numéricos:**
* **Dados inteiros com sinal:**
    - `sbyte`: 1 byte (8 bits); -128 a 127
    - `short`: 2 bytes (16 bits); -32768 a 32767
    - `int`: 4 bytes (32 bits); - 2 bilhões a 2 bilhões
    - `long` (L): 8 bytes (64 bits); - 9 \* 10^18 a 9 \* 10^18
*** Dados inteiros sem sinal (unsigned):** Mesma quantidade de bytes, vai de 0 até o limite positivo (é o dobro do anterior)
    - `byte`
    - `ushort`
    - `uint` (U)
    - `ulong` (UL)
 * **Dados reais:** Muda a quantidade de bytes para a notação ponto flutuante
    - `float` (F): 4 bytes
    - `double` (D): 8 bytes
    - `decimal` (M): 16 bytes

* **Notação hexadecimal:** prefixo `0x`
* **Numeros binários:** prefixo `0b`
* **Conversões implícitas:** destinatário pode representar o valor da origem. Caso contrário, é necessária uma **conversão explícita**

* **Exemplo sufixos:**
```
long i = 5;            // Conversão implícita de int para long
double x = 4.0;        // O sufixo D é redundante
float f = 4.5F;        // Não irá compilar sem o sufixo F
decimal d = -1.23M;    // Não irá compilar sem o sufixo M
```

* **Exemplos gerais:**
```
long y = 0x7F;
int b = 0b1010_1011_1100_1101_1110_1111;
int million = 1_000_000;
double doubleMillion = 1E06; // Notação exponencial: sufixo E
```

### **2.2) Dados Booleanos:**
* `true`, `false`
* `==`, `!=`
* `&&`, `||`, `!`
* `condition ? a : b` = se `condition` é true, `a` é avaliado. Se é `false`, `b` é avaliado

### **2.3) Dados Literais:**
* `char` representam um caracter e ocupa dois bytes em memória; 
* `String` é tipo de referência; opera com `==`
* **Sequências de escape:**
    - Quebra de linha: `'\n'`
    - Backslash (barra invertida): `'\\'`
    - Tab: `'\t'`
    - Escaped: `"\r\n"` - cursor volta para o começo da linha e avança para a próxima linha; quebra de linha completa
    - Verbatim: `@` - evita escape de caracteres especiais
* **Operador `+`: **concatenação
* String precedida pelo caractere $ é uma **string interpolada:**
```
int x = 4;
Console.WriteLine($"A square has {x} sides"); // S square has 4 sides

const string greeting = "Hello";
const string message = $"{greeting}, world";

Console.WriteLine(message);
```

### **2.4) Dados Matriciais (arrays):**
* Vetor é um conjunto de elementos de um tipo particular. Seu tamanho é sempre definido na inicialização
* 0 indexado
* Valores de um vetor de int são inicializados como 0 (default)
* vec\[^i\] acessa o i-ésimo último elemento do vetor
```
char[] vowels = new char[5];
int[] nums = {1, 2, 3, 4};
vowels[0] = 'a';
vowels[1] = 'e';
vowels[2] = 'i';
vowels[3] = 'o';
vowels[4] = 'u';
vowels[^1] = 'u';

char[] firstTwo = vowels[..2];     // 'a', 'e'
char[] lastThree = vowels[2..];    // 'i', 'o', 'u'
char[] middleOne = vowels[2..3];   // 'i'

char[] lastTwo = vowels[^2..];     // 'o', 'u'

Range firstTwoRange = 0..2;
char[] firstTwo2 = vowels[firstTwoRange];   // 'a', 'e'
```

* Inicializando uma matriz:
    - Usando laços
    ```
    int[,] matrix = new int[3,3];

    for (int i = 0; i < matrix.GetLength(0); i++) 
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = i * 3 + j;
    ```
    - Usando new e definição na mão:
    ```
    int[,] matrix2 = new int[,]
    {
        {0,1,2},
        {3,4,5},
        {6,7,8}
    };
    ```
    - Usando definição na mão apenas:
    ```
    int[,] rectangularMatrix =
    {
        {0,1,2},
        {3,4,5},
        {6,7,8}
    };
    ```
    - Definindo na mão e usando new para cada linha:
    ```
    int[][] jaggedMatrix =
    {
        new int[] {0,1,2},
        new int[] {3,4,5},
        new int[] {6,7,8}
    };
    ```
## **3) Operadores e Expressões:**
### **3.1) Operador null:**

* Tipo por referência
* Não estão apontando para um objeto válido
* Operador `??` -> null-coalescing; `a ?? b` retorna `a` se não for nulo ou `b`, caso contrário
* Operador `??=` -> `a ??= b` se `a` é null, substitui seu valor por `b` e mantém o valor de `a`, caso contrário

### **4.1) Definição de Variáveis:**
* Variáveis de mesmo tipo podem ser declaradas na mesma linha, desde que separadas por vírgula
* Constantes são declaradas com `const`. Não podem ser alteradas
* Omitir o tipo e C# faz a inferência durante a compilação: `var`

## **5) Laços de Controle de Fluxo e de Repetição:**

### **5.1) If, else:**
* Comando de fluxo
* Não é necessário definir o escopo com {} quando há apenas um comando

### **5.2) Switch:**
* Mais claro e simples que múltiplos *if*
* Quando a avaliação de mais de um valor leva à mesma execução, é possível listar vários *cases* sequencialmente

### **5.3) While, do:**
* *while* avalia a expressão antes do corpo do laço
* *do{} while()* avalia depois

### **5.4) For, foreach:**
* *for* é igual a java
* É possível adicionar mais de de uma variável na inicialização do laço
* *foreach* itera sobre elementos enumeráveis
```
foreach(char c in "beer")   // c é a variável de iteração
  Console.WriteLine(c);
```

### **5.5) Break, continue:**
* `break;` quebra o laço *for, while, switch*
* `continue;` faz o laço *for, while, switch* começar a próxima iteração