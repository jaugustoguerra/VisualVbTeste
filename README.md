
# Projeto VB.NET - Gerenciamento de Transações Financeiras

Este projeto é um sistema de gerenciamento de transações financeiras desenvolvido em VB.NET (Visual Basic .NET). Ele se conecta a um banco de dados SQL Server para realizar operações CRUD (Create, Read, Update, Delete) em uma tabela de transações.

## Funcionalidades

- **Adicionar Transação**: Insere uma nova transação no banco de dados.
- **Editar Transação**: Atualiza uma transação existente.
- **Excluir Transação**: Remove uma transação do banco de dados.
- **Carregar Transações**: Exibe todas as transações em um DataGridView.
- **Validação de Dados**: Verifica se os campos estão preenchidos corretamente antes de inserir ou atualizar.

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes itens instalados:

### Visual Studio:

Recomenda-se o Visual Studio 2019 ou superior.

Disponível em: [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/).

### .NET Framework:

O projeto foi desenvolvido para o .NET Framework 4.8 ou superior.

Certifique-se de que o .NET Framework está instalado no seu sistema.

### SQL Server:

O projeto se conecta a um banco de dados SQL Server.

Certifique-se de que o SQL Server está instalado e configurado.

Crie um banco de dados chamado `Financeiro` e uma tabela chamada `Transacoes` com a seguinte estrutura:

```sql
CREATE TABLE Transacoes (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255),
    CPF NVARCHAR(14),
    Valor DECIMAL(18, 2),
    DataTransacao DATETIME,
    Descricao NVARCHAR(255),
    TipoTransacao NVARCHAR(50)
);
```

### String de Conexão:

Atualize a string de conexão no arquivo `App.config` ou diretamente no código para refletir as credenciais do seu SQL Server.

Exemplo de string de conexão:

```xml
<connectionStrings>
    <add name="FinanceiroConnection" 
         connectionString="Data Source=localhost;Initial Catalog=Financeiro;Integrated Security=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Como Executar o Projeto

### 1. Clone o Repositório:

Clone este repositório para o seu computador:

```bash
git clone https://github.com/jaugustoguerra/VisualVbTeste.git
```

### 2. Abra o Projeto no Visual Studio:

Abra o arquivo `.sln` no Visual Studio.

### 3. Configure a String de Conexão:

Atualize a string de conexão no arquivo `App.config` ou no código para se conectar ao seu banco de dados.

### 4. Compile e Execute:

Compile o projeto pressionando F5 ou clicando em **Iniciar** no Visual Studio.

A interface gráfica será exibida, permitindo que você gerencie as transações.

## Estrutura do Projeto

- **Form1.vb**: Contém a interface gráfica e a lógica principal do sistema.
- **App.config**: Armazena a string de conexão com o banco de dados.
- **Transacoes.sql**: Script SQL para criar a tabela `Transacoes` no banco de dados.

## Tecnologias Utilizadas

- **VB.NET**: Linguagem de programação usada para desenvolver o sistema.
- **SQL Server**: Banco de dados para armazenar as transações.
- **ADO.NET**: Biblioteca para conexão e manipulação de dados no SQL Server.
- **Windows Forms**: Framework para criar a interface gráfica.

## Capturas de Tela

Aqui estão algumas capturas de tela do sistema em funcionamento:

- **Tela Principal**:
- **Adicionar Transação**:
- **Editar Transação**:

## Contribuição

Se você deseja contribuir para este projeto, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`).
3. Commit suas alterações (`git commit -m 'Adicionando nova feature'`).
4. Push para a branch (`git push origin feature/nova-feature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo `LICENSE` para mais detalhes.

## Contato

Se você tiver alguma dúvida ou sugestão, entre em contato:

- **Nome**: [Jose Augusto Guerra]
- **E-mail**: [auguscontas@gmail.com]
- **GitHub**: jaugustoguerra
