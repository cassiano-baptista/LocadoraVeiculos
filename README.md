# Projeto da Disciplina – Tecnologia .NET

# Sistema de Locação de Veículos

## 1. Introdução

Empresas de locação de veículos necessitam controlar clientes, veículos disponíveis e operações de locação. Quando esse processo é realizado manualmente ou através de planilhas, podem ocorrer inconsistências cadastrais, conflitos de reservas e dificuldades no controle da disponibilidade dos veículos.

Este projeto propõe o desenvolvimento de um sistema de locação de veículos com foco na modelagem do domínio utilizando os conceitos de Domain-Driven Design (DDD), permitindo que as regras de negócio sejam representadas de forma clara, organizada e alinhada à realidade do problema.

O sistema será desenvolvido utilizando a linguagem C# e os conceitos estudados na disciplina Tecnologia .NET.

---

# 2. Problema a Ser Resolvido

Uma locadora de veículos precisa controlar seus clientes e veículos, garantindo que:

* Apenas clientes válidos possam realizar locações;
* Um veículo não seja locado simultaneamente para mais de um cliente;
* O período de locação seja válido;
* O cálculo do valor da locação seja realizado corretamente;
* A disponibilidade dos veículos seja mantida de forma consistente.

Atualmente, esse processo pode ser realizado manualmente, aumentando o risco de erros operacionais e inconsistências nas informações.

---

# 3. Objetivo do Projeto

Desenvolver uma aplicação responsável por gerenciar:

* Cadastro de clientes;
* Cadastro de veículos;
* Criação de locações;
* Encerramento de locações;
* Controle de disponibilidade dos veículos;
* Cálculo do valor das locações.

O projeto terá foco na implementação das regras de negócio e na modelagem do domínio, não contemplando funcionalidades financeiras ou integrações externas.

---

# 4. Escopo

## Funcionalidades Incluídas

* Cadastro de Pessoa Física;
* Cadastro de Pessoa Jurídica;
* Cadastro de veículos;
* Realização de locações;
* Encerramento de locações;
* Consulta de disponibilidade dos veículos;
* Cálculo do valor da locação;
* Aplicação de desconto para clientes Pessoa Jurídica.

## Funcionalidades Fora do Escopo

* Controle financeiro;
* Emissão de boletos;
* Pagamentos;
* Controle de manutenção dos veículos;
* Controle de multas;
* Integrações com órgãos externos;
* Aplicações web ou mobile.

---

# 5. Usuários do Sistema

## Atendente

Responsável por:

* Cadastrar clientes;
* Cadastrar veículos;
* Criar locações;
* Encerrar locações.

## Gerente

Responsável por:

* Consultar locações;
* Consultar disponibilidade dos veículos;
* Acompanhar operações da locadora.

---

# 6. Linguagem Ubíqua (Ubiquitous Language)

Os seguintes termos serão utilizados durante toda a modelagem e implementação do sistema:

| Termo              | Definição                                      |
| ------------------ | ---------------------------------------------- |
| Cliente            | Pessoa autorizada a realizar locações          |
| Pessoa Física      | Cliente identificado por CPF                   |
| Pessoa Jurídica    | Cliente identificado por CNPJ                  |
| Veículo            | Bem disponível para locação                    |
| Locação            | Operação de aluguel de um veículo              |
| Devolução          | Encerramento de uma locação                    |
| Disponível         | Veículo apto para locação                      |
| Indisponível       | Veículo já vinculado a uma locação ativa       |
| Período de Locação | Intervalo entre início e fim da locação        |
| Diária             | Valor cobrado por dia de utilização do veículo |

---

# 7. Entidades

## Cliente

Representa um cliente da locadora.

Características:

* Possui identidade própria;
* É identificado por um Guid;
* Mantém informações cadastrais do cliente.

Atributos principais:

* Id
* Nome
* Email

### Especializações

#### PessoaFisica

Representa clientes cadastrados por CPF.

#### PessoaJuridica

Representa empresas cadastradas por CNPJ.

A utilização de herança permite especializar o comportamento dos diferentes tipos de clientes sem duplicação de responsabilidades.

---

## Veiculo

Representa um veículo disponível para locação.

Atributos principais:

* Id
* Placa
* Modelo
* ValorDaDiaria
* Disponivel

Responsabilidades:

* Controlar sua disponibilidade;
* Garantir consistência de seus dados.

---

## Locacao

Representa uma operação de aluguel.

Atributos principais:

* Id
* Cliente
* Veiculo
* PeriodoLocacao
* ValorTotal
* Status

Responsabilidades:

* Relacionar cliente e veículo;
* Controlar o período contratado;
* Registrar o valor calculado da locação.

---

# 8. Value Objects

## CPF

Representa um CPF válido.

Características:

* Imutável;
* Validado no momento da criação;
* Não possui identidade própria.

---

## CNPJ

Representa um CNPJ válido.

Características:

* Imutável;
* Validado no momento da criação;
* Não possui identidade própria.

---

## Email

Representa um endereço de e-mail válido.

Características:

* Imutável;
* Validado no momento da criação;
* Não possui identidade própria.

---

## PeriodoLocacao

Representa o intervalo da locação.

Composto por:

* DataInicio
* DataFim

Regra:

* A data final deve ser posterior à data inicial.

Características:

* Imutável;
* Não possui identidade própria.

---

# 9. Aggregate Roots

## Aggregate Cliente

Raiz do agregado:

* Cliente

Objetos pertencentes ao agregado:

* CPF
* CNPJ
* Email

O Cliente é responsável por garantir a consistência dos dados pertencentes ao seu agregado.

---

## Aggregate Veiculo

Raiz do agregado:

* Veiculo

O próprio Veículo é responsável por garantir sua consistência e disponibilidade.

---

## Aggregate Locacao

Raiz do agregado:

* Locacao

Objetos pertencentes ao agregado:

* PeriodoLocacao

A Locação é responsável por garantir a validade das informações relacionadas ao período contratado.

---

# 10. Regras de Negócio

## RN01

Um veículo somente poderá ser locado se estiver disponível.

---

## RN02

Um cliente não poderá possuir mais de uma locação ativa simultaneamente.

---

## RN03

A data final da locação deve ser posterior à data inicial.

---

## RN04

Clientes Pessoa Jurídica recebem desconto de 10% sobre o valor total calculado da locação.

---

## RN05

Ao iniciar uma locação, o veículo deverá ser marcado como indisponível.

---

## RN06

Ao finalizar uma locação, o veículo deverá ser marcado novamente como disponível.

---

## RN07

O valor da diária do veículo deverá ser maior que zero.

---

# 11. Domain Services

## CalculadoraLocacaoService

Responsável pelo cálculo do valor total da locação.

Responsabilidades:

* Calcular quantidade de diárias;
* Multiplicar pela diária do veículo;
* Aplicar desconto para Pessoa Jurídica.

### Justificativa

O cálculo depende simultaneamente de informações pertencentes a diferentes entidades do domínio, como Cliente, Veículo e Locação.

Por esse motivo, a regra não pertence exclusivamente a nenhuma entidade específica, sendo modelada como um Domain Service.

---

# 12. Factories

## ClienteFactory

Responsável pela criação de objetos válidos do domínio.

Objetos criados:

* PessoaFisica;
* PessoaJuridica.

### Justificativa

A responsabilidade da Factory é exclusivamente a construção de objetos válidos.

Ela não contém regras de negócio relacionadas à locação.

---

# 13. Repositories

## IClienteRepository

Responsável pelas operações de persistência dos clientes.

---

## IVeiculoRepository

Responsável pelas operações de persistência dos veículos.

---

## ILocacaoRepository

Responsável pelas operações de persistência das locações.

---

# 14. Bounded Contexts

## Contexto de Cadastro

Responsável pelas informações cadastrais dos clientes.

Principais elementos:

* Cliente;
* PessoaFisica;
* PessoaJuridica;
* CPF;
* CNPJ;
* Email.

---

## Contexto de Locação

Responsável pelas operações de aluguel de veículos.

Principais elementos:

* Veiculo;
* Locacao;
* PeriodoLocacao;
* CalculadoraLocacaoService.

---

# 15. Context Map

O relacionamento entre os contextos ocorre da seguinte forma:

Cadastro → Locação

O Contexto de Locação depende das informações disponibilizadas pelo Contexto de Cadastro para validar os clientes envolvidos nas operações de locação.

O Contexto de Cadastro não depende do Contexto de Locação, caracterizando uma relação unidirecional.

---

# 16. Anti-Corruption Layer (ACL)

Para evitar acoplamento direto entre os Bounded Contexts, será utilizada uma camada Anti-Corruption Layer.

A ACL terá como responsabilidade traduzir as informações provenientes do Contexto de Cadastro para o formato esperado pelo Contexto de Locação.

Dessa forma, alterações internas realizadas no modelo do Contexto de Cadastro não impactarão diretamente o modelo do Contexto de Locação.

Essa abordagem reduz o acoplamento entre contextos e facilita a evolução independente de cada parte do sistema.

---

# 17. Considerações Finais

A modelagem proposta aplica os principais conceitos de Domain-Driven Design estudados na disciplina, incluindo Linguagem Ubíqua, Entidades, Value Objects, Aggregate Roots, Repositories, Domain Services, Factories, Bounded Contexts, Context Map e Anti-Corruption Layer.

A implementação do projeto será realizada em C#, utilizando os princípios de Orientação a Objetos, SOLID, GRASP e testes unitários, garantindo um domínio rico em comportamento, com alta coesão, baixo acoplamento e foco nas regras de negócio.





# 18. Mapeamento das Rubricas da Disciplina

Esta seção apresenta o mapeamento direto entre os critérios de avaliação da disciplina e os artefatos desenvolvidos no projeto, indicando onde cada requisito pode ser localizado na documentação e no código-fonte.

---

## Rubrica 1

### Aplicar os conceitos de Orientação a Objetos com C#

**Requisito:**

O aluno implementou as classes aplicando os conceitos básicos de OO como Encapsulamento, Abstração, Herança e Polimorfismo?

**Localização na documentação:**

* Seção 7 – Entidades
* Seção 8 – Value Objects

**Localização no código:**

```text
Domain/Entities
├── Cliente.cs
├── PessoaFisica.cs
├── PessoaJuridica.cs
├── Veiculo.cs
└── Locacao.cs
```

**Evidências:**

* Encapsulamento através de propriedades com `private set`;
* Abstração através da classe abstrata `Cliente`;
* Herança através das classes `PessoaFisica : Cliente` e `PessoaJuridica : Cliente`;
* Especialização dos tipos de cliente utilizando uma hierarquia orientada a objetos.

---

## Rubrica 2

### Aplicar os conceitos de Orientação a Objetos com C#

**Requisito:**

O aluno implementou as classes e objetos em C#, aplicando corretamente modificadores de acesso, propriedades, métodos e construtores?

**Localização no código:**

```text
Domain
├── Entities
├── ValueObjects
├── Services
└── Factories
```

**Evidências:**

* Utilização de construtores para garantir objetos válidos;
* Utilização de propriedades encapsuladas;
* Utilização de métodos de domínio para alteração de estado;
* Utilização de modificadores de acesso adequados.

---

## Rubrica 3

### Aplicar os conceitos de Orientação a Objetos com C#

**Requisito:**

O aluno aplicou herança e polimorfismo em C# para criar hierarquias de classes flexíveis e extensíveis?

**Localização no código:**

```text
Domain/Entities
├── Cliente.cs
├── PessoaFisica.cs
└── PessoaJuridica.cs
```

**Evidências:**

```text
PessoaFisica : Cliente
PessoaJuridica : Cliente
```

A modelagem utiliza uma hierarquia de especialização baseada na abstração Cliente.

---

## Rubrica 4

### Aplicar os conceitos de Orientação a Objetos com C#

**Requisito:**

O aluno aplicou abstração e encapsulamento em C# para ocultar detalhes de implementação e expor interfaces claras e concisas?

**Localização no código:**

```text
Domain/Entities
├── Cliente.cs
├── Veiculo.cs
└── Locacao.cs
```

**Evidências:**

* Classe abstrata `Cliente`;
* Utilização de propriedades com `private set`;
* Alteração de estado realizada através de métodos de domínio.

---

## Rubrica 5

### Modelar aplicações utilizando Domain-Driven Design

**Requisito:**

O aluno modelou o domínio utilizando Ubiquitous Language, Entities, Value Objects e Repositories de forma coerente com os conceitos de DDD?

**Localização na documentação:**

* Seção 6 – Linguagem Ubíqua
* Seção 7 – Entidades
* Seção 8 – Value Objects
* Seção 13 – Repositories

**Localização no código:**

```text
Domain
├── Entities
├── ValueObjects
└── Repositories
```

---

## Rubrica 6

### Modelar aplicações utilizando Domain-Driven Design

**Requisito:**

O aluno modelou o domínio utilizando Aggregate, Bounded Contexts e Domain Services de maneira estruturada e adequada ao problema?

**Localização na documentação:**

* Seção 9 – Aggregate Roots
* Seção 11 – Domain Services
* Seção 14 – Bounded Contexts

**Localização no código:**

```text
Domain
├── Entities
│   └── Locacao.cs
│
└── Services
    └── CalculadoraLocacaoService.cs
```

**Evidências:**

* Aggregate Root: `Locacao`;
* Domain Service: `CalculadoraLocacaoService`.

---

## Rubrica 7

### Modelar aplicações utilizando Domain-Driven Design

**Requisito:**

O aluno diferenciou claramente Domain Services e Factories na modelagem do domínio, justificando sua escolha com base na responsabilidade de cada elemento?

**Localização na documentação:**

* Seção 11 – Domain Services
* Seção 12 – Factories

**Localização no código:**

```text
Domain
├── Services
│   └── CalculadoraLocacaoService.cs
│
└── Factories
    └── ClienteFactory.cs
```

**Evidências:**

* `CalculadoraLocacaoService` responsável por cálculos de locação;
* `ClienteFactory` responsável pela criação de objetos válidos do domínio.

---

## Rubrica 8

### Modelar aplicações utilizando Domain-Driven Design

**Requisito:**

O aluno modelou o domínio considerando a integração entre Bounded Contexts, aplicando padrões como Anti-Corruption Layer e Context Map com clareza e eficácia?

**Localização na documentação:**

* Seção 14 – Bounded Contexts
* Seção 15 – Context Map
* Seção 16 – Anti-Corruption Layer

**Localização visual:**

* Diagrama de Domínio (DDD)

---

## Rubrica 9

### Criar aplicações empregando padrões de projeto – SOLID e GRASP

**Requisito:**

O aluno aplicou os princípios SOLID no design das classes, garantindo coesão, alta responsabilidade e baixo acoplamento?

**Localização no código:**

```text
Domain
├── Entities
├── Services
├── Factories
└── Repositories
```

**Evidências:**

* Responsabilidades bem definidas;
* Separação entre entidades, serviços, fábricas e repositórios;
* Baixo acoplamento através de interfaces.

---

## Rubrica 10

### Criar aplicações empregando padrões de projeto – SOLID e GRASP

**Requisito:**

O aluno utilizou corretamente o princípio de Single Responsibility nas classes, evitando a concentração excessiva de responsabilidades?

**Localização no código:**

```text
Domain/Services
└── CalculadoraLocacaoService.cs

Domain/Factories
└── ClienteFactory.cs

Domain/Entities
├── Veiculo.cs
└── Locacao.cs
```

**Evidências:**

Cada classe possui uma única responsabilidade claramente definida.

---

## Rubrica 11

### Criar aplicações empregando padrões de projeto – SOLID e GRASP

**Requisito:**

O aluno aplicou o padrão Low Coupling para garantir a independência entre as classes e promover a reutilização de código?

**Localização no código:**

```text
Domain/Repositories
├── IClienteRepository.cs
├── IVeiculoRepository.cs
└── ILocacaoRepository.cs
```

**Evidências:**

Utilização de contratos através de interfaces, reduzindo dependências diretas entre componentes.

---

## Rubrica 12

### Criar aplicações empregando padrões de projeto – SOLID e GRASP

**Requisito:**

O aluno utilizou o padrão Controller de forma adequada, promovendo a separação entre lógica de controle e demais responsabilidades?

**Localização no projeto:**

```text
Domain
├── Entities
├── Services
└── Factories
```

**Observação:**

Como o projeto possui foco exclusivo na camada de domínio, a coordenação das operações encontra-se distribuída entre Aggregate Roots, Domain Services e Factories, mantendo separação adequada das responsabilidades.

---

## Rubrica 13

### Desenvolver testes unitários e aplicar TDD

**Requisito:**

O aluno aplicou corretamente os princípios de testes unitários como isolamento, repetibilidade, rapidez, auto-verificação e abrangência?

**Localização no código:**

```text
Domain.Tests
```

**Evidências:**

Todos os testes executam de forma independente, repetível e sem dependência de recursos externos.

---

## Rubrica 14

### Desenvolver testes unitários e aplicar TDD

**Requisito:**

O aluno implementou testes unitários abrangendo todos os métodos que contêm regras de negócio relevantes?

**Localização no código:**

```text
Domain.Tests
├── ValueObjects
├── Entities
├── Services
└── Factories
```

---

## Rubrica 15

### Desenvolver testes unitários e aplicar TDD

**Requisito:**

O aluno utilizou mocks e stubs de maneira adequada para isolar o código sob teste durante a implementação dos testes unitários?

**Localização no projeto:**

```text
Domain.Tests
```

**Observação:**

O domínio desenvolvido não possui dependências externas, banco de dados ou integrações. Dessa forma, os testes permanecem isolados sem necessidade de mocks ou stubs.

---

## Rubrica 16

### Desenvolver testes unitários e aplicar TDD

**Requisito:**

O aluno implementou testes unitários com cobertura superior a 80% do código de domínio, garantindo qualidade e confiabilidade da aplicação?

**Localização no projeto:**

```text
Domain.Tests
```

<img width="1536" height="1024" alt="projeto_ net" src="https://github.com/user-attachments/assets/a60c67b7-b970-4d64-80b6-f74415ba1332" />






