# Music Playlist Manager 

Projeto desenvolvido em C# com foco em estruturas de dados, coleções genéricas e manipulação de playlists musicais.

> Este projeto foi desenvolvido como treino/prática de programação, com objetivo de aprofundar conhecimentos em C#, Collections, interfaces (`IEnumerable`, `IEnumerator`, `IComparable`, `IComparer` ...) e modelagem de sistemas.

---

## Sobre

O sistema simula um aplicativo de gerenciamento de músicas, permitindo a criação e organização de playlists personalizadas.

O projeto foi desenvolvido como uma aplicação Console, utilizando exclusivamente o arquivo `Program.cs`, centralizando toda a lógica de negócio, estruturas de dados e implementação das classes no mesmo arquivo para fins de estudo e experimentação.

Além da manipulação de playlists, o sistema também possui um player com fila de reprodução e histórico de músicas tocadas.

---

## Funcionalidades implementadas

- Criação de músicas e playlists
- Adição e remoção de músicas
- Busca de músicas por título
- Reprodução aleatória sem alterar a ordem original
- Ordenação de músicas por:
  - duração
  - artista
  - título
- Prevenção de músicas duplicadas em playlists
- Ranking das músicas mais adicionadas
- Player de música com:
  - fila de reprodução (`Queue`)
  - histórico de reprodução (`Stack`)
- Suporte a iteração com `foreach`
- Uso de `yield return`
- Sobrecarga de métodos
- Comparadores customizados

---

## Conceitos Trabalhados

Este projeto foi desenvolvido principalmente como exercício prático dos seguintes conceitos:

### Programação Orientada a Objetos (POO)

- Classes e objetos
- Encapsulamento
- Sobrescrita de métodos
- Sobrecarga de métodos

### Collections e Estruturas de Dados

- `List<T>`
- `HashSet<T>`
- `Dictionary<TKey, TValue>`
- `Queue<T>`
- `Stack<T>`

### Interfaces do .NET

- `ICollection<T>`
- `IEnumerable<T>`
- `IEnumerator`
- `IComparable`
- `IComparer<T>`

### Outros conceitos

- Ordenação customizada
- Iteração com `yield return`
- Controle de duplicidade com `Equals()` e `GetHashCode()`
- Lógica de ranking
- Randomização de elementos

---

## Estrutura Atual do Projeto

Atualmente, toda a aplicação está centralizada no arquivo:

```bash
📦 MusicPlaylistManager
 ┣ 📜 Program.cs
 ┗ 📜 README.md
```

As classes, comparadores, métodos auxiliares e regras de negócio foram implementados diretamente no `Program.cs` com foco em aprendizado, simplificação da execução e prática dos conceitos da linguagem.

---

## Exemplo de Uso

```csharp
var playlist = new Playlist { Nome = "Rock Nacional" };

playlist.Add(new Musica
{
    Titulo = "Tempo Perdido",
    Artista = "Legião Urbana",
    Duracao = 455
});

foreach (var musica in playlist)
{
    Console.WriteLine(musica.Titulo);
}
```

---

## Destaques Técnicos

### Controle de músicas duplicadas

O projeto utiliza `HashSet<Musica>` juntamente com sobrescrita de:

- `Equals()`
- `GetHashCode()`

para impedir músicas repetidas dentro da mesma playlist.

---

### Reprodução e histórico

O player utiliza:

- `Queue<T>` → fila de reprodução (FIFO)
- `Stack<T>` → histórico de músicas tocadas (LIFO)

simulando o comportamento de players de música.

---

### Ordenações personalizadas

As músicas podem ser ordenadas utilizando:

- `IComparable`
- `IComparer<T>`

permitindo múltiplas estratégias de ordenação.

---

## Tecnologias Utilizadas

- C#
- .NET
- Console Application
- Collections Framework

---

## Objetivo

O principal objetivo deste projeto foi praticar lógica de programação e conceitos fundamentais/intermediários do ecossistema .NET através de um sistema simples, mas com regras de negócio verídicas.

O projeto também serviu como exercício para entender melhor como estruturar dados.

---

## Possíveis melhorias

- Separação das classes em arquivos individuais
- Interface gráfica
- Persistência em banco de dados
- Reprodução real de arquivos MP3
- API REST com ASP.NET Core
- Testes unitários
- Sistema de usuários
- Playlists públicas e privadas
- Sistema de favoritos
- Estatísticas de reprodução

---

## Autor

Desenvolvido por Gabriel como projeto de estudo e prática em C#/.NET.
