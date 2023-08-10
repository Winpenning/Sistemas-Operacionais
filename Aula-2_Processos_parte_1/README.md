# Aula 2 - Processos

---

## Visões top down e bottom up

![Diagrama sem nome.drawio.svg](Aula%202%20-%20Processos%2005e9dce1e3f9490887cc21424a5c4554/Diagrama_sem_nome.drawio.svg)

---

## Programa

<aside>
💡 É um conjunto de instruções armazenados na memória secundária.

</aside>

Enquanto estiver instalado, um programa sempre existirá.

---

## Processos

<aside>
💡 É uma instância de execução de um programa.

</aside>

Ex: Se abrir o word o processo será executado se fechá-lo o processo acabará.

> Processos tem ciclo de vida, iniciam e se findam (exemplo: o que está no gerenciador de tarefas ou no top)
> 

---

## Bloco de Controle de Processo

**************************************Bloco de Controle:************************************** Informações do processo.

- Variáveis de controle
- Id do processo
- Quem é o pai
- do processo
- Estado Atual
- Tempo em execução

**************Stack:************** Espaço dinâmico para chamada de funções recursivas (empilha dados de acordo com a necessidade dos processos)

**************Heap:************** Espaço dinâmico geralmente aloca ou desaloca pequenos trechos de memória de acordo com a necessidade dos dados/objetos (não é muito eficiente mas é bastante flexível pois não impõe um modelo)

**************Bloco de dados:************** Armazena memória para os processos e variáveis 

![Diagrama sem nome.drawio (1).svg](Aula%202%20-%20Processos%2005e9dce1e3f9490887cc21424a5c4554/Diagrama_sem_nome.drawio_(1).svg)

---

## Como criar processos

- Executando programas;
- Processos podem criar outros processos;
- Iniciar o Sistema Operacional.

## Como Finalizar processos

- Término voluntário: Concluiu a execução das instruções, erros não fatais;
- Término involuntario: Quando um processo finaliza outro processo;
- Erro fatal: endereço de memória inválida, exceptions.

---
