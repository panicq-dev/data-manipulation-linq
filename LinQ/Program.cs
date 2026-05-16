/*
Seja um aplicativo de gerenciamento de músicas onde os usuários podem organizar suas faixas
favoritas em playlists personalizadas. Para cada playlist, é essencial que o usuário tenha
controle total sobre a sequência de reprodução das músicas, permitindo reordená-las
livremente a qualquer momento. Além disso, o aplicativo precisa oferecer a funcionalidade de
reprodução aleatória para uma playlist específica, proporcionando uma experiência de audição
dinâmica e variada, sem, contudo, alterar a ordem original que o usuário definiu. O desafio
é criar uma estrutura robusta que suporte a adição e remoção eficiente de músicas, a
reordenação flexível dentro das playlists e a seleção de faixas tanto em modo sequencial
quanto aleatório.
*/

// Funcoes que vamos implementar:
// [ x ] Criar as classes para musicas e playlist
// [ x ] Listar musicas da playlist
// [ x ] Adicionar musica à playlist
// [ ] Obter uma musica especifica da playlist
// [ ] Remover musica da playlist
// [ ] Tocar uma musica aleatoria da playlist
// [ ] Reordenar musicas segundo alguma logica especifica (ex. duracao)
// [ ] Uma playlist nao pode ter musicas repetidas
// [ ] Exibir as 10 musicas mais tocadas em todas as playlists (ranking)
// [ ] Player de musica com:
// [ ] - Fila de reproducao (para musicas avulsas e/ou playlists)
// [ ] - Historico de reproducao


using System.Collections;

var musica1 = new Musica { Titulo = "Que Pais é Esse?", Artista = "Legião Urbana", Duracao = 350 };
var musica2 = new Musica { Titulo = "Tempo Perdido", Artista = "Legião Urbana", Duracao = 455 };
var musica3 = new Musica { Titulo = "Pro Dia Nascer Feliz", Artista = "Barão Vermelho", Duracao = 345 };
var musica4 = new Musica { Titulo = "Eduardo e Mônica", Artista = "Legião Urbana", Duracao = 530 };
var musica5 = new Musica { Titulo = "Geração Coca-Cola", Artista = "Legião Urbana", Duracao = 350 };

var rockNacional = new Playlist { Nome = "Rock Nacional" };

rockNacional.AdicionarMusica(musica1);
rockNacional.AdicionarMusica(musica2);
rockNacional.AdicionarMusica(musica3);
rockNacional.AdicionarMusica(musica4);
rockNacional.AdicionarMusica(musica5);

ExibirPlaylist(rockNacional);

void ExibirPlaylist(Playlist playlist)
{
    Console.WriteLine($"Tocando as músicas de {playlist.Nome}");
    foreach (var musica in playlist)
    {
        Console.WriteLine($"- {musica.Titulo}");
    }
}
class Musica
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }


}

class Playlist : IEnumerable<Musica> // Define que essa classe é percorrível e que vai fornecer objetos do tipo Música.
{
    // Lista de Músicas
    private List<Musica> lista = [];

    // Adicionando Música.
    public void AdicionarMusica(Musica musica)
    {
        lista.Add(musica);
    }
    public string Nome { get; set; }

    // IEnumerator & IEnumerable
    public IEnumerator<Musica> GetEnumerator()
    {
        return lista.GetEnumerator(); // O foreach chama o GetEnumerator como padrão. No caso, esse GetEnumerator retorna a lista. Logo, o foreach percorre a lista.
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
