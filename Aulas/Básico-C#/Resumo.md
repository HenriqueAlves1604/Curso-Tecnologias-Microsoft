**Curso Tecnologias Microsoft**

**Henrique Alves de Fernando - 16/05/2023**

# Aula 1 - Introdução a C#

## **1) Origem do C#:**
* **Linguagem de máquina:**
    - Programas carregados diretamente para a memória

* **Linguagem de baixo nível:**
    - Programas precisam ser ***montados*** por um **montador (assembler)** para serem carregados na memória
    - Totalmente **dependentes do processador**
    - Assembly

* **Linguagens de alto nível:**
    - Programas precisam ser ***compilados*** por um **compilador** ou ***interpretados*** por um **interpretador** para serem carregados na memória
    - Independentes do processador

* **Linguagens BCPL:**
    - Basic Combined Programming Language
    - Alto nível, procedural, desenvolvida para criação de compiladores para outras linguagens

* **Linguagem B:**
    - Origem: BCPL
    - Alto nível

* **Linguagem C:**
    - Origem: B
    - Transformação em linguagem tipada
    - Utilizada para desenvolvimento do sistema operacional Unix

* **Linguagem C++:**
    - Origem: C 
    - Introduz conceito de classes da POO
    - Difícil compreensão

* **Java:**
    - Inspirada no C e C++
    - Orientada a objetos

* **Linguagem J++:**
    -  "Java da Microsoft"
    -  Aplicações não rodavam em JVM que não a da própria Microsoft

* **Linguagem J#:**
    - Compatível com o Common Language Runtime (CLR) - equivalente a uma JVM, mas descolada do nome *Java*
    - Várias linguagem usaram o sufixo \# para indicar a compatibilidade com o **framework .NET**
    - Não compila para bytecode, mas para a linguageem intermediária do CLR

* **Linguagem C#:**
    - Supostamente inspirada no C++ e C. Na verdade, é a cópia legal do Java
    - Uma das mais utilizadas paraa o desenvolvimento do framework .NET

## **2) A Plataforma .NET:**

### **O que é o .NET:**

* Plataforma de desenvolvimento open-source e gratuita criada pela Microsoft
* Windows, MacOS, Linux
* Múltiplas linguagens (C#, F#, Visual Basics)
* Múltiplas IDEs
* Bibliotecas para diferentes tipos de aplicações

### **Funcionamento do .NET:**
* Semelhante ao Framework Java
* Programas compilados em uma linguagem intermediária (IL)semelhante aos bytecodes do Framework Java
* Código em IL interpretado por uma máquina virtual chamada CLR (Common Language Runtime)
* **Diferentes implemantações**
    - .NET Framework
    - .NET Core (somente .NET)
    - .NET Standard
* **Diversos Application Layers:**
    - Console: Aplicações que interagem com o usuário
    - ASP.NET Core: Aplicações Web baseadas em REST e microserviços
    - WPF e Windows Forms: Aplicações com uma GUI
    - UWP e WinUI 3: Aplicações com GUI e touch first
    - MAUI: Aplicações mobile em IOS e Android
* BCL: Base Class Library

### **Desenvolvimento em .NET:**
* **.NET SDK (Software Development Toolkit)**
    - .NET runtime e biblioteca padrão: CLR e BCL
    - .NET CLI: Command Line Interface: Comandos para serem usados no console
* **IDEs:**
    - Visual Studio Code
    - Visual Studio
* **Solution:**
    - Container para organizar projetos relacionados
    - .sln
    - Pode ser criada pelo CLI do .NET com o comando `dotnet new sln`
    - 
* **Projeto:**
    - Agrupa um conjunto de classes que funciona de maneira unificada
    - Arquivo XML com o sufixo .csproj
    - Biblioteca de classes ou App executável
    - Na criação de um projeto, especifica-se um **tipo** que inicializa o projeto com um template default para o tipo ("Console App", "Class Library", "Test Project", etc)
    - Opções de projeto:
        + Self contained X framework-dependent
        + Especificação do runtime (win-x64, linux-x64, ios-x64, etc)
        + Compilação ReadyToRun
        + Trimming
    - NuGet: Package Manager do .NET:
        + Instalando pacotes com o CLI: `dotnet new --install <NUGET_ID>`
        + Referenciando pacotes no projeto com o CLI: `dotnet add package <PACK_NAME>`
    - Documentação com as classes do BCL: https://docs.microsoft.com/en-us/dotnet/api/?view=net-6.0
    

## **3) Programação estruturada:**
* **Engenharia de Software:**
    - Boas práticas que tornam o desenvolvimento mais produtivo e eficiente
    - **Modularidade:** divide o programa em módulos mais simples. Recursivo e incremental.

* **Programação Estruturada:**
    - Uso de estruturas de fluxo de controle de seleção ao invés de go-tos
    - Blocos e subrotinas
    - Conceitos-chave:
        +  **Sequência:** código executado em sequência linear
        +  **Seleção:** estruturas condicionais para executar blocos de código
        +  **Repetição:** uso de laços
        +  **Sub-rotina:** uso de funções e procedimentos para organizar e modular o código. Reutilização e encapsulamento do código em blocos independentes
        +  **Evitar desvios incondicionais (go to):** Melhora legibilidade e evita problemas de fluxo complexo
 
* **Dados globais X dados locais:**
    - Uso de dados locais, que têm validade apenas em um módulo (subrotina)
    - Evita excesso de dados globais

* **Ocultamento de informação:**
    - **Variáveis locais:** nome e validade dentro de um escopo do módulo (mais compreensão, menos erros)
    - **Modos de acesso:** público ou privado

* **Programação estruturada:**
    - **Abstração:** Sub-rotinas complexas podem ser decomposta em várias sub-rotinas mais simples
    - **Acoplamento:** Dependência que uma sub-rotina tem com outras sub-rotinas. Pode ser circular.
    - **Coesão:** Sub-rotinas dizem respeito a um mesmo tema e podem ser reutilizadas em conjunto
    - Desejável **baixo acoplamento** e **alta coesão**
* **Encapsulamento:** várias variáveis compõem uma variável composta (TAD)
* **Objetos:** Instância de um TAD que proporciona encapsulamento de procedimentos (classe), ocultamento de informações e mecanismo de herança. É um tipo sofisticado de variável, que encapsula fields e métodos
* **Herança:** Novos tipos de dados podem ser definidos via extensão
* **Classe:** Tipo de dado abstrato que suporta herança
    - ***Fields*:** Variáveis encapsuladas na classe
    - ***Métodos*:** sub-rotinas encapsuladas na classe

##  **4) Programação Orientada a Objetos:**
Deve-se pensar no conjunto de objetos que, interagindo entre si, realizam uma tarefa. A interação manda mensagens que correspondem à invocação de métodos. Há um foco maior na definição dos objetos úteis.
### **Conceitos:**

* **Objetos:** similar ao conceito cotidiano; instâncias de classes
* **Classes:** suportam herança, podem ter métodos abstratos (definidos nas sub-classes) - torna-se classe abstrata
* **Fields e métodos estáticos:** pertencem à classe. Podem ser acessados sem criar uma instância da classe
* **Classes Estáticas:** todos os fields e métodos são estáticos; não é possível criar um objeto de classe estática
* **Polimorfismo:** Habilidade do objeto ser visto como instância de qualquer classe da hierarquia à qual pertence
*  **Overriding:** Sub-classe redefine um método da classe mãe
*  **Dynamic binding (ligação dinâmica):** quando há overriding, é por meio desse mecanismo que determina-se qual método será executado.
*  **Overloaging:** Métodos com mesmo nome, mas com assinaturas diferentes
*  **Construtor:** Permite criação da instância a partir de um conjunto mínimo de informações. Uma classe pode ter vários
*  **Desconstrutor:** A partir de um objeto, recorta-se informações internas e restaura-se os parâmetros originais
*  **Propriedades (gets e sets):** Fields privados podem ser recuperados (gets) e redefinidos (sets)
*  **Interface:** 
    - Especificação de métodos e seus parâmetros sem a implementação
    - Funciona como um tipo de classe abstrata, sem definição de fields
    - Resolve problema de herança múltipla
    - Classes podem implementar uma interface
    - Objetos polimórficos são interfaces que implementam
* **Ponto de Entrada:** main. C# cria automaticamente se não especificado um.
