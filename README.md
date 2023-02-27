<h1 align="center"> Livraria </h1>

<h2>Sobre o Projeto:</h2>
<p>A proposta do projeto é de ser uma Web API para gerenciamento de Estoque de uma Livraria.</p>
<br>
<p>Funcionalidades:</p>
<p>-Listar;</p>
<p>-Adicionar;</p>
<p>-Alterar;</p>
<p>-Deletar;</p>
<p>-Filtrar por Título, Autor e Editora.</p>
<br>
<hr>

<h2>Linguagens e ferramentas utilizadas:</h2>
<p>-O projeto foi criado utilizando Dontnet 6.0.406 e Angular 15.1.6;</p>
<p>-No front-end foi utilizada a ferramenta Bootstrap;</p>
<p>-O banco de dados utilizado foi o SQL Server 16.0.1.</p>
<br>
<hr>

<h2>O que você vai precisar para rodar o projeto na sua máquina?</h2>
<p><b>Tenha instalado em sua máquina as ferramentas listadas acima e também o Visual Studio Code</b>
<p>Seu SQL Server deve estar configurado com autenticação do Windows, caso contrário você terá que no arquivo no appsettings.json do projeto adequar a sua ConnectionStrings.</p> 
<p><b>1-</b> Ao Clonar o projeto abra-o no Visual Studio Code</p>
<br>
<p><b>2-</b>Localize dentro da Pasta Back/Data a Pasta Migrations e a exclua;</p>
<br>
<p><b>3-</b> Abra um terminal no o projeto e caminhe até a pasta Livraria  (cd Back\src\Livraria);</p>
<br>
<p><b>4-</b>Execute o comando: dotnet ef migrations add inicial -o Data/Migrations;</p>
<br>
<p><b>5-</b>Em seguida execute o comando: dotnet ef database update;</p>
<br>
<p><b>6-</b> Execute o comando dotnet watch run;</p>
<br>
<p><b>7-</b> Abra um novo terminal no projeto e caminhe até a pasta Livraria-App (cd Front\Livraria-App);</p>
<br>
<p><b>8-</b> Execute o comando npm install e em seguida o comando ng serve -o;</p>
<br>
<p>-Seu navegador abrirá o link da Aplicação.</p>
<br>
<h3>Prontinho! O projeto já deve rodar em sua máquina.</h3>
<br>
<hr>
<h2>Telas Funcionais da aplicação:</h2>
<br>
<p>Listagem dos Livros Cadastrados:</p>
<p>Ao Passar o mouse na imagem do livro é possível visualizar um pequeno resumo do mesmo.</p>
<br> 

![Listagem](https://user-images.githubusercontent.com/105614600/221443596-898d9b1a-7174-459e-85e0-31e56339ab97.gif)
<br>
<br>
<hr>

<p>Na tela inicial temos a opção de Filtrar os livros por Titulo, Autor e Editora:</p>
<br>

![fitragem](https://user-images.githubusercontent.com/105614600/221443630-891ebded-b18b-4d20-9fb2-44ea9ff2a393.gif)
<br>
<br>
<hr>

<p>Ao clicar em editar abrirá uma página com os campos preenchidos com as informações atuais do Livro:</p>
<p>Basta atualizar a informação desejada, clicar em Salvar e em seguida Listar Livros.</p>
<br>

![editar](https://user-images.githubusercontent.com/105614600/221443935-7fba9e6e-9ccf-42a2-9573-811f7a78934d.gif)

<br>
<br>
<hr>

<p>Na página inicial ao clicar em Adicionar abre uma página com os campos a serem preenchidos:</p>
<br>

![Adicionar](https://user-images.githubusercontent.com/105614600/221443957-39edf481-2ac1-4abd-8e01-f6f2db253c7a.gif)

<br>

<p>Página do Livro adicionado acima:<p>
<br>

![Imgur](https://i.imgur.com/1cA3E2s.png)

<br>
<br>
<hr>

<p>Para adicionar ou editar os dados de um livros temos validadores nos campos obrigatórios:</p>
<br>

![Imgur](https://i.imgur.com/HsGzV3Z.jpg)

<br>
<br>
<hr>

<p>Validadores nos campos que determinam a quantidade mínima de caracteres:</p>
<br>

![Imgur](https://i.imgur.com/l0kRC7I.jpg)

<br>
<br>
<hr>

<p>E Validadores nos campos que determinam a quantidade máxima de caracteres:</p>
<br>

![Imgur](https://i.imgur.com/OghRtia.jpg)

<br>
<p>Note que enquanto o que foi digitado não cumpre os requisitos dos validadores o botão de salvar fica desabilitado:</p>
<br>
<br>
<hr>

<p>Na tela inicial podemos Deletar um livro:</p>
<br>

![deletar](https://user-images.githubusercontent.com/105614600/221443686-26a74baf-a4a1-4aeb-bfd8-f133d8d75c71.gif)

<br>
<hr>


