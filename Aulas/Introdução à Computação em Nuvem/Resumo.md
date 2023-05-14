**Curso de Tecnologias Microsoft**

**Henrique Alves de Fernando - 14/05/2023**

# **Introdução a Computação Em Nuvem**

## **1) Antes da Computação em Nuvem:**

* Empresas armazenavam seus dados em servidores locais
* Caro, exige recursos de TI (servidores, banco de dados, softwares, equipe de especialistas, etc)
* Backup necessário
* Armazenamento em áreas físicas
* Forma de comunicação: email (pode gerar problemas de versionamento de arquivos)

## **2) Virtualização:**
### **2.1) Aspectos gerais:**
* Técnica que permite que um único computador execute múltiplos sistemas operacionais e aplicativos em ambientes isolados e independentes
* Otimizar a utilização do hardware, permitindo que diversas aplicações e SOs sejam executados simultaneamente em uma máquina
* Criação de recursos de computação virtualizados, como servidores, armazenamento, redes e até SO em um ambiente compartilhado
* Permite a criação de máquinas virtuais ou contêineres que são isolados e executados em um hardqare físico subjacente
* Vantagens:
    - **Isolamento:** diferentes VMs executadas isoladamente (evita conflitos e interferências entre diferentes aplicativos ou serviços)
    - **Alocação eficiente de recursos:** compartilhamento eficiente de CPU, memória, armazenamento entre VMs. Podem ser alocados dinamicamente conforme demanda
    - **Flexibilidade e escalabilidade**
    - **Migração e recuperação de desastres:** 
    - **Economia de energia**
    - **Facilidade de implementação de novas VMs**


### **2.2) Máquina virtual:**
* É um ambiente computacional virtualizado que emula um computador completo dentro de outro SO ou hardware físico
* Usa tecnologia de virtualização para ser independente do hardware físico
* **Hipervisor:** Software responsável pela criação e gerência de VMs
    - Tipo 1, nativo (BareMetal): Instalado no hardware físico e gerencia VMs diretamente. Acesso direto ao hardware. Não necessita de SO. Servidores e data centers
    - Tipo 2, hospedado (Hosted): Aplicativo no SO host e gerencia as VMs dentro desse ambiente. Depende do SO host para acessar os recursos. Desktops e laptops

* **VM:** Instância virtualizada de um SO que é executada dentro da VM. Possui memória, CPU, armazenamento, etc próprios. Funciona como computador autônomo
* **Recursos de Hardware Virtualizados:** Hipervisor aloca os recursos e cada VM compartilha o mesmo hardware físico eficientemente
* **Sistema Operacional:** Cada VM possui SO próprio. Cada VM interage com o SO por meio do hipervisor e é executada como um computador físico dedicado
* **Isolamento:** VMs isoladas entre si e do SO ou hardware físico. Cada VM é independente. Problema em uma não afeta as outras.

## **3) O que é Computação em nuvem:**
* Modelo para permitir acesso onipresente, conveniente e sob demanda a um conjunto compartilhado de recursos de computação configuráveis que pode ser rapidamente provisionados e liberados com essforço mínimo de gerenciamento ou iteração do provedor de serviços
* Uso de uma rede de servidores remotos hospedados na internet para armazenar, gerenciar e processar dados em vez de um servidor local
* Amazon Web Servise (AWS), Microsoft Azure
  
## **4) On-Primise X Computação em Nuvem:**
* On-Primise: Recursos e sistemas computacionais são implantados localmente
* **Escalabilidade**
    - **On-Primise:** Custo maior, menos opções, dificuldade na redução do poder de processamento, mais infraestrutura e manutenção
    - **Computação em nuvem:** Paga apenas o que usar, provisões mais fáceis e rápidas

* **Armazenamento de Servidores**
    - **On-Primise:**  Muito espaço físico para servidores, energia e manutenção
    - **Computação em nuvem:** Oferecido por provedores que gerenciam e mantém os servidores; economia de dinheiro e espaço

 * **Segurança de dados**
    - **On-Primise:** Menos segurança
    - **Computação em nuvem:** Mais seguro, evita monitoramento

* **Perda de dados**
    - **On-Primise:** Baixa chance de recuperação
    - **Computação em nuvem:** Medidas robustas para recuperação de dados de forma rápida e fácil

* **Manutenção**
    - **On-Primise:** Equipes para manter hardware e software; mais custoso
    - **Computação em nuvem:** Mantidos pelos provedores; maior economia

* **Desenvolvimento**
    - **On-Primise:**  Recursos implantados internamente, empresa responsável por manter
    - **Computação em nuvem:** recursos hospedados nas instalações do provedor, empresas podem acessar e usar quanto quiser
  
* **Custo**
    - **On-Primise:** Empresa responsável pelo custo de hardware, software, energia e espaço físico
    - **Computação em nuvem:** Empresas pagam pelo recurso que usa 

* **Controle**
    - **On-Primise:** Empresa retém seus dados e têm controle total sobre o que acontece com eles
    - **Computação em nuvem:** Propriedade e segurança dos dados pertencente a terceiros

* **Segurança**
    - **On-Primise:** Da empresa
    - **Computação em nuvem:** Problema, ameaças

* **Compilance**
    - **On-Primise:** Controle regulatório
    - **Computação em nuvem:** Provedor deve estar em dia com os mandatos regulatórios de seu setor

## **5) Benefícios da Computação em Nuvem:**
* **Velocidade:** Grande quantidade de recursos provisionada em minutos
* **Custo:** Elimina a despesa de compra de hardware e software
* **Escalabilidade:** Fácil aumentar a capacidade na nuvem
* **Acessibilidade:** Fácil acesso dos dados de qualquer lugar
* **Segurança:** Dados armazenados em um local ceguro e centralizado

## **6) Tipos de Computação em Nuvem:**

### **6.1) Modelos de Implantação:**
* Nuvem pública: Disponíveis ao público e de propriedade de provedores de serviços de nuvem
* Nuvem privada: Operada exclusivamente por uma única organização
* Nuvem híbrida: Combinação de pública e privada


### **6.2) Modelos de Serviço:**
* Infraestrutura como serviço: Empresa que requer recursos como armazenamento ou VMs
* Plataforma como serviço: Empresa que requer 