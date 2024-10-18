# Notificacao Coleta Api
Api para notificações de coleta de lixo, criado para fins estudantis.

## Pré-requisitos

Antes de executar o projeto, verifique se você possui as seguintes ferramentas instaladas:

- [Docker](https://docs.docker.com/get-docker/) (incluindo Docker Compose)

## Estrutura do Projeto

```plaintext
.
├── Dockerfile
├── docker-compose.yml
├── src
│   └── ... (código-fonte do projeto)
└── README.md
```

## Executando o Projeto com Docker Compose
Para executar o projeto usando Docker Compose, siga os passos abaixo:
Certifique-se de estar no diretório do projeto.

Construa e inicie os containers:

```plaintext
docker-compose up --build
```
O comando acima irá construir as imagens do Docker e iniciar os containers definidos no arquivo docker-compose.yml.

Acesse a aplicação:
Após a inicialização dos containers, você pode acessar sua aplicação no navegador em:

```
http://localhost:8080 (ou conforme definido em docker-compose.yml)
```

Parando a Aplicação
Para parar a aplicação e remover os containers, você pode usar:
```plaintext
docker-compose down
```
## Comandos Úteis
Recriar containers:
Se você fez alterações no Dockerfile ou no docker-compose.yml, você pode recriar os containers usando:

```plaintext
docker-compose up --build
```

## Ver logs dos containers:
Para ver os logs dos containers em execução, você pode usar:

```plaintext
docker-compose logs
```

## Problemas Comuns
```plaintext
Conexões recusadas:
Certifique-se de que os serviços estão configurados corretamente e que os containers estão em execução.
Erros de dependência:
Verifique se todas as dependências estão instaladas e corretamente configuradas no Dockerfile e no docker-compose.yml.
```
