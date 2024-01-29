# Azure Functions - Aplicação Serverless de Envio de E-mail de Boas-Vindas

Este projeto apresenta uma aplicação serverless utilizando Azure Functions para enviar e-mails de boas-vindas para novos autores cadastrados em uma tabela.

## Arquitetura

A aplicação utiliza o serviço Azure Functions como um serviço serverless para lidar com o processamento de solicitações. O gatilho da função é acionado por um HTTP request, que atua como o ponto de entrada da aplicação. A função consulta uma tabela (por exemplo, uma tabela do Azure Cosmos DB ou do Azure SQL Database) para recuperar o primeiro elemento (novo autor cadastrado) e, em seguida, envia um e-mail de boas-vindas usando um serviço de e-mail como o SendGrid.

## Funcionalidades Principais

- **HTTP Trigger:** A função é acionada por um HTTP request, que é o trigger para a execução da função.
- **Consulta de Tabela:** A função consulta uma tabela para recuperar o primeiro elemento (um novo autor cadastrado) que será processado.
- **Envio de E-mail de Boas-Vindas:** Após recuperar o autor, a função envia um e-mail de boas-vindas utilizando um serviço de e-mail configurado.

## Configuração do Projeto

Para configurar e executar o projeto localmente, siga estas etapas:

1. Clone o repositório: `git clone https://github.com/seu-usuario/nome-do-repositorio.git`
2. Instale as dependências do projeto: `npm install`
3. Configure as variáveis de ambiente necessárias, incluindo as credenciais para o acesso à tabela e ao serviço de e-mail.
4. Execute a aplicação: `npm start` ou `func start`

Certifique-se de ter uma tabela configurada no Azure (por exemplo, Azure Cosmos DB ou Azure SQL Database) e um serviço de e-mail configurado (por exemplo, SendGrid) para que a aplicação funcione corretamente.
