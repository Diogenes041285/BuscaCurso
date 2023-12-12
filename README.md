# BuscaCurso
Projeto RPA exemplificando o uso do WebDriver e injeção de dependencia.

Frameworks/Versões:

  - .NET6;
  - Selenium WebDriver 4.15;
  - ChromeDriver 119;; 
  - Entity Framework 7;
  - SQL Server;

Camadas:

  - Data (conexão com fontes externas de dados e persistência/CRUD);
  - Domínio (representação das entidades, lógicas e regras de negócio);
  - Interfaces (telas de interação entre o sistema e os usuários, consoles ou windows services);
  - Services (conexão com serviços externos. Ex: api's e rpa's).

Obs: Também é possível fazer a busca dos cursos com "crawler" (mapeamento das requisições com Fiddler e chamadas com RestSharp). Com crawler o desenvolvimento é um pouco mais complexo, porém a performance é muito maior.
