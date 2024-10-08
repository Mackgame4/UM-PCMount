#import "cover.typ": cover
#import "template.typ": *

#show: project

#cover(title: "PCMount", authors: (
  (name: "Fabio Magalhaes", number: "A104365"), 
  (name: "Aluno 2", number: "a100002"),
  (name: "Aluno 2", number: "a100002"), 
  (name: "Aluno 2", number: "a100002"),
  (name: "Aluno 3", number: "a100003")), 
  "Outubro, 2024")

#set page(numbering: "i", number-align: center)
#counter(page).update(1)

#heading(numbering: none, outlined: false)[Resumo]
<\<O resumo tem como objectivo descrever de forma sucinta o trabalho realizado. Deverá conter uma pequena introdução, seguida por uma breve descrição do trabalho realizado e terminando com uma indicação sumária do seu estado final. Não deverá exceder as 400 palavras.>>   

#v(2em)

*Área de Aplicação*: Processos de construção de software e especificação e desenvolvimento de aplicações do mundo real.

*Palavras-Chave*: .NET, C\#, Base de Dados, Web, Web App, SQL Server, Entity Framework, ASP.NET Core, Razor, Blazor, HTML, CSS, Diagrama UML, Modelo Dominio, Entidades, Relacionamentos, Diagrama de Classes, Diagrama de Casos de Uso, Diagrama de Sequência, Engenharia Software, Interface do Utilizador

#show outline: it => {
    show heading: set text(size: 18pt)
    it
}

#{
  show outline.entry.where(level: 1): it => {
    v(5pt)
    strong(it)
  }

  outline(
    title: [Índice], 
    indent: true, 
  )
}

#v(-0.4em)
#outline(
  title: none,
  target: figure.where(kind: "attachment"),
  indent: n => 1em,
)

#outline(
  title: [Índice de Figuras],
  target: figure.where(kind: image),
)

#outline(
  title: [Índice de Tabelas],
  target: figure.where(kind: table),
)

#set page(numbering: "1", number-align: center)
#counter(page).update(1)

#import "pages/mainPage.typ" as mainPage

#mainPage