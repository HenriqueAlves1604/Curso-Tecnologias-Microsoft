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

## **3) Herança:**
* Alterar o comportamento de uma classe já existente
* Evita repetição de código 
```
public class Asset           // Classe mãe
{
  public string Name;
}

public class Stock : Asset   // Classe filha que herda de Asset
{
  public long SharesOwned;
}

public class House : Asset   // Classe filha que herda de Asset
{
  public decimal Mortgage;
}
```

* Permite usar o conceito de polimorfismo: Podemos escrever operações para a classe mãe e usá-los em classes filhas
```
Display(new Stock { Name="MSFT", SharesOwned=1000 });     // MSFT
Display(new House { Name="Mansion", Mortgage=100000 });   // Mansion

void Display(Asset asset)   // Uso de polimorfismo, isto é, tanto Stock como House são Assets
{
  Console.WriteLine(asset.Name);
}
```
* **Conversões de referência:**
    - Upcast: Tipo filho vira tipo mãe
    - Downcast: Tipo mãe para tipo filho
  
  
```
Stock msft = new Stock();     // Tipo filho
Asset a = msft;               // Upcast para o tipo mãe

// Após o upcast, as duas variáveis ainda referenciam o mesmo objeto
Console.WriteLine(a == msft);  // True
```

```
Stock msft = new Stock();
Asset a = msft;                      // Upcast para o tipo mãe

Stock s = (Stock)a;                  // Downcast para tipo filho com conversão explícita

Console.WriteLine(s.SharesOwned); 
Console.WriteLine(s == a);          // True
Console.WriteLine(s == msft);       // True

House h = new House();
Asset a2 = h;               // Upcast sempre funciona
Stock s2 = (Stock)a2;       // ERROR: Downcast falhou: a não é uma Stock
```

* Operador `is` testa uma conversão de referência. Similar a `instanceof`
* Operador `as` realiza conversão para um tipo mais especializado
```
Asset a = new Asset();
Stock s = a as Stock;       // s é nulo; nenhuma exceção é lançada
// O operador as é similar ao operador is: 
// expression is type ? (type)expression : (type)null
```

* **Sobrescrita:**
    - Métodos não podem ser **sobrescritos** nas classes filhas. 
    - Podemos permitir a sobrescrita usando a palavra-chave `virtual` na classe mãe e `override` na classe filha. 
    - Essas palavras vêm logo depois da visibilidade. 
    - O tipo de retorno deve ser igual ou mais específico que do método original
    - Um método sobrescrito pode usar a palavra-chave `sealed` paraa selar sua implementação e impedir a sobrescrita por outras classes herdeiras
```
House mansion = new House { Name="McMansion", Mortgage=250000 };

Console.WriteLine(mansion.Liability);      // 250000

public class Asset
{
  public string Name;
  public virtual decimal Liability => 0;    // Método virtual
}

public class House : Asset
{
  public decimal Mortgage;
  public sealed override decimal Liability => Mortgage;   // Método sobrescrito e selado
}

// Podemos também selar uma classe inteira, implicitamente selando todos os seus métodos virtuais
public sealed class Stock : Asset { /* ... */ }
```

  
* **Classes abstratas** nunca podem ser instanciadas e devem conter somente membros abstratos

* Operador `base`: chama o construtor da classe mãe (se não for explicitamente chamado, é chamado de maneira implícita)

```
new Subclass (123);

public class Baseclass                      // Classe mãe
{
  public int X;
  public Baseclass() { }                    // Construtor da classe mãe
  public Baseclass(int x) { this.X = x; }   // Construtor da classe mãe
}

public class Subclass : Baseclass           // Classe filha
{
  public Subclass(int x) : base(x) { }      // Construtor da classe filha, note que o construtor da classe mãe foi chamado com o operador base
}
```

## **4) Modificadores de Acesso:**
* Implementam o encapsulamento
* Evitam que o objeto externe dados, operações e responsabilidades que não deveriam ser expostos
* `public`
* `private`
* `protected`: Acesso permitido na mesma classe e em classes filhas
* `internal`: Acesso permitido a qualquer código no messmo *Assembly* (mesma biblioteca). É o modificador padrão (quando nenhum é explicitado)

## **5) Interfaces:**
* Estrutura para padronizar o modo de comunicação com um objeto
* Especifica conjunto de métodos que caracterizam um modo de interação com um objeto que a implementa
* Um objeto implementa a interface quando sua classe possui todos os métodos definidos na interface
* Parece com uma classe abstrata sem fields
* Solução para o problema da herança múltipla, pois uma classe pode implementar várias interfaces
* Mecanismo de herança semelhante
```
IEnumerator e = new Countdown();    // Uso de polimorfismo 

while (e.MoveNext())
  Console.Write(e.Current);         // 109876543210

public interface IEnumerator        // Declaração de uma interface com métodos prototipados
{
  bool MoveNext();
  object Current { get; }
  void Reset();
}

class Countdown : IEnumerator       // Implementação de interface e seus métodos por uma classe
{
  int count = 11;
  public bool MoveNext () => count-- > 0;
  public object Current   => count;
  public void Reset()     { throw new NotSupportedException(); }
}
```
* Diferentes classes podem implementar a mesma interface de diferentes maneiras
* Para resolver problema de colisão de assinaturas, deve-se fazer a implementação explícita da interface 
```
Widget w = new Widget();
w.Foo();                        // Widget's implementation of I1.Foo
((I1)w).Foo();                  // Widget's implementation of I1.Foo
((I2)w).Foo();                  // Widget's implementation of I2.Foo

interface I1 { void Foo(); }
interface I2 { int Foo(); }

public class Widget : I1, I2    // Implementação de múltiplas interfaces
{
  public void Foo ()
  {
    Console.WriteLine("Widget's implementation of I1.Foo");
  }
  
  int I2.Foo()                  // Implementação explicita de método da interface
  {
    Console.WriteLine("Widget's implementation of I2.Foo");
    return 42;
  }
}
```
* Métodos implicitamente selados. Devem ser marcados como `virtual` para serem implementados nas classes filhas
* Reimplementação de interface em classe filha pode gerar problemas. Boa prática: fazer a conversão do objeto para o tipo que implementa a interface que se deseja chamar.
* Interfaces podem conter uma implementação padrão. Nesse caso, não é necessáario reimplementar o método na classe do objeto
* Permitem o uso de propriedade estática

## **6) Enums:**
* Permitem a especificação de constantes numéricas nomeadas
```
BorderSide topSide = BorderSide.Top;
bool isTop = (topSide == BorderSide.Top);  

Console.WriteLine(isTop);       // True

// Definição de um enum com quatro constantes
public enum BorderSide { Left, Right, Top, Bottom }

// Podemos especificar um tipo alternativo de dado
public enum BorderSideByte : byte { Left, Right, Top, Bottom }

// Também podemos especificar valores explícitos para cada constante
public enum BorderSideExplicit : byte { Left=1, Right=2, Top=10, Bottom=11 }

public enum BorderSidePartiallyExplicit : byte { Left=1, Right, Top=10, Bottom }
```
* É possível converter instâncias de enum para seu tipo integral e vice-versa

```
int i = (int)BorderSide.Left;
Console.WriteLine(i);                   // 0

BorderSide side = (BorderSide)i;
Console.WriteLine(side);                // Left

bool leftOrRight = (int)side <= 2;
Console.WriteLine(leftOrRight);         // True

HorizontalAlignment h = (HorizontalAlignment)BorderSide.Right;
Console.WriteLine(h);                   // Right

BorderSide b = 0; 
Console.WriteLine(b);                   // Left

public enum BorderSide { Left, Right, Top, Bottom }

public enum HorizontalAlignment
{
  Left = BorderSide.Left,
  Right = BorderSide.Right,
  Center
}
```
## **7) Struct:**
* Classe sem métodos
* tipo por valor, não por referência

```
Point p1 = new Point();       // p1.x e p1.y serão 1
Point p2 = new Point(2, 2);   // p2.x e p2.y serão 2

Console.WriteLine(p1);
Console.WriteLine(p2);

struct Point                  // Declaração de uma struct
{
  public int x, y;
  public Point()             { this.x = 1; this.y = 1; }
  public Point(int x, int y) { this.x = x; this.y = y; }
}
```

## **8) Tipos Aninhados:**
* Declarado dentro do escopo de outro tipo
* Devem respeitar modificadores de visibilidade

```
public class TopLevel
{
  public class Nested { }               // Classe aninhada
  public enum Color { Red, Blue, Tan }  // Enum aninhado
}

static void Main()
{
  TopLevel.Color color = TopLevel.Color.Red;  
}
```