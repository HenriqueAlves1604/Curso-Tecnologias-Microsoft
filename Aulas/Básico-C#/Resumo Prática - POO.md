**Curso Tecnologias Microsoft**

**Henrique Alves de Fernando - 15/05/2023**

# **Prática - Programação Orientada a Objetos**

## **1) Classes**
* Declaração com a palavra-chave `class`
* Para ser instanciada, usamos `new`
* **Atributos do tipo de leitura:** `readonly` não podem ser modificados
* Constantes são fatoradas em tempo de compilação, mesmo quando sua definição envolve cálculos
* **Métodos "encorporados por expressão" (*expression-embodied*):** declarados sem especificar um corpo

```
Console.WriteLine(Foo1(10) == Foo2(10));    // True

int Foo1(int x) { return x * 2; }
int Foo2(int x) => x * 2;                   // Expression-embodied notation
```

* Representação encorporada por expressão utiliza a notação "Expressão Lambda"

* **Métodos locais:** métodos dentro de outros métodos

* **Métodos de alto nível (*top-level*):** Implicitamente locais, podemos acessar variáveis declaradas externamente ao método

* **Sobrecarga:** Métodos com mesmo nome e assinatura diferentes. Mudar o tipo de retorno não configura sobrecarga
* **Construtores:** 
    - Inicializar atributos e executar funcionalidades no momento da instanciação
    - Têm o mesmo nome da classe e não têm tipo de retorno
    - Podem ser sobrecarregados
    - Comando `this()` refere-se ao outro construtor. Um construtor pode chamar outros construtores da classe
    - Construtores estáticos inicializam uma vez por tipo, não por objeto

* **Desconstrutores:** 
    - Determinam como os atributos podem ser separados quando a desconstrução é chamada
    - **DUVIDA**


* Campos e propriedades também podem ser inicializados em uma declaração única em conjunto ou depois da construção
 ```
Bunny b1 = new Bunny { Name="Bo", LikesCarrots=true, LikesHumans=false }; // Inicialização em conjunto, com a nomeação das propriedades e campos
Bunny b2 = new Bunny ("Bo")     { LikesCarrots=true, LikesHumans=false }; // Inicialização após a chamada do construtor

Console.WriteLine(b1.Name);   // Bo
Console.WriteLine(b2.Name);   // Bo

public class Bunny
{
  public string Name;
  public bool LikesCarrots;
  public bool LikesHumans;
  
  public Bunny () {}
  public Bunny (string n) { Name = n; }
}
 ```

 * Passagem de parâmetros pode ser opcional
```
Bunny b1 = new Bunny(name: "Bo");
Bunny b2 = new Bunny(name: "Bo", likesCarrots: true); // Sobrescrita de parâmetro opcional likesCarrots

Console.WriteLine(b1.LikesCarrots);   // False
Console.WriteLine(b2.LikesCarrots);   // True

public class Bunny
{
  public string Name;
  public bool LikesCarrots;
  public bool LikesHumans;

  public Bunny (string name, bool likesCarrots = false, bool likesHumans = false) // 1 parâmetro obrigatório e 2 opcionais
  {
    Name = name;
    LikesCarrots = likesCarrots;
    LikesHumans = likesHumans; 
  }
}
```

* Palavra-chave `this` é uma referência ao próprio objeto
* **Propriedades (property):** 
    - Possui gets e sets
    - Pode ser feita automaticamente em C#
    - Têm visibilidade de acesso definida por public, private, etc 

Exemplo 1: gets e sets
```
var stock = new Stock();

stock.CurrentPrice = 123.45M;
Console.WriteLine(stock.CurrentPrice);        // 123.45
  
var stock2 = new Stock { CurrentPrice = 83.12M };
Console.WriteLine(stock2.CurrentPrice);       // 83.12

public class Stock
{
  decimal currentPrice;           // Atributo privado
  
  public decimal CurrentPrice     // Propriedade pública
  {
    get { return currentPrice; } set { currentPrice = value; }
  }
}
```

Exemplo 2: gets e sets automáticos e propriedades inicializadas
```
var stock = new Stock();

Console.WriteLine(stock.CurrentPrice);  // 123
Console.WriteLine(stock.Maximum);       // 999

public class Stock
{
  public decimal CurrentPrice { get; set; } = 123;   // Inicialização
  public int Maximum { get; } = 999;                 // Inicialização
}
```

* **Indexadores (*indexers*):** Declaração feita com o operador de referência this:
```
Sentence s = new Sentence();
Console.WriteLine(s[3]);       // fox

s[3] = "kangaroo";
Console.WriteLine(s[3]);       // kangaroo

// Faixas de indices também são permitidos
Console.WriteLine(s[^1]);               // fox  
string[] firstTwoWords = s[..2];        // (The, quick)

class Sentence
{
  string[] words = "The quick brown fox".Split();     // Separa a string em um vetor de palavras
  
  public string this[int wordNum]      // Declaração do índice
  { 
    get { return words[wordNum];  }
    set { words[wordNum] = value; }
  }

  public string this[Index index] => words[index];
  public string[] this[Range range] => words[range];

}
```

* **Tipos parciais (*partial*):** 
    - Definição de um tipo é realizada em múltiplos arquivos
    - Pode conter métodos parciais
```
new PaymentForm{ X = 3, Y = 4 };

partial class PaymentForm { public int X; }
partial class PaymentForm { public int Y; }
```

* Operador `nameof` -> retorna o nome de variáveis
* Palavra-chave `using` -> necessário para usar recursos de outras classes. Semelhante ao `import` de Java
* `namespaces` -> organizar as classes. Semelhante a um pacote
* Construção padrão de um arquivo:
```
using System;

class Program
{
  static void Main()
  {
    Console.WriteLine(FeetToInches (30));      // 360
    Console.WriteLine(FeetToInches (100));     // 1200
  }

  static int FeetToInches (int feet)
  {
    int inches = feet * 12;
    return inches;
  }
}
```

## **2) O Tipo Object:**
* Classe base para todos os outros tipos
* ***Boxing*** é a operação de converter um tipo de dado para o tipo mais ancestral. ***Unboxing*** é o processo reverso. Estamos usando polimorfismo
```
int x = 9;
object obj = x;           // Box para int
int y = (int)obj;         // Unbox para int

Console.WriteLine(y);     // 9
```
* Quando fazemos *unboxing*, os tipos devem combinar
```
object obj = 9;           // 9 é inferido como tipo int
long x = (long) obj;      // InvalidCastException
```

```
object obj = 9;

// Unbox para int, com conversão implícita para long
long x = (int) obj;
Console.WriteLine(x);     // 9

// Também pode ser escrito assim:
object obj2 = 3.5;              // 3.5 é inferido como sendo do tipo double
int y = (int)(double) obj2;    // x agora vale 3
Console.WriteLine(y);     // 3
```

* Formas de se obter o tipo do objeto:
    - método `GetType`
    - operador `typeof`