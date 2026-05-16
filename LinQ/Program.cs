/*
ENUNCIADO.
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
// [ x ] Obter uma musica especifica da playlist
// [ x ] Remover musica da playlist
// [ x ] Tocar uma musica aleatoria da playlist
// [ x ] Reordenar musicas segundo alguma logica especifica (ex. duracao)
// [ ] Uma playlist nao pode ter musicas repetidas
// [ ] Exibir as 10 musicas mais tocadas em todas as playlists (ranking)
// [ ] Player de musica com:
// [ ] - Fila de reproducao (para musicas avulsas e/ou playlists)
// [ ] - Historico de reproducao

// ===========================================================================================================
using System.Collections;
using System.Threading.Channels;

var musica1 = new Musica { Titulo = "Que Pais é Esse?", Artista = "Legião Urbana", Duracao = 350 };
var musica2 = new Musica { Titulo = "Tempo Perdido", Artista = "Legião Urbana", Duracao = 455 };
var musica3 = new Musica { Titulo = "Pro Dia Nascer Feliz", Artista = "Barão Vermelho", Duracao = 345 };
var musica4 = new Musica { Titulo = "Eduardo e Mônica", Artista = "Legião Urbana", Duracao = 530 };
var musica5 = new Musica { Titulo = "Geração Coca-Cola", Artista = "Legião Urbana", Duracao = 380 };

var rockNacional = new Playlist { Nome = "Rock Nacional" };

rockNacional.Add(musica2);
rockNacional.Add(musica1);
rockNacional.Add(musica3);
rockNacional.Add(musica4);
rockNacional.Add(musica5);

ExibirPlaylist(rockNacional);

void ObterMusicaAleatorio(Playlist playlist)
{
    var musicaAleatoria = rockNacional.ObterAleatorio();
    if (musicaAleatoria is not null)
    {
        Console.WriteLine($"A música aleatória é {musicaAleatoria.Titulo}");
    }
    else
    {
        Console.WriteLine("Não há músicas na playlist.");
    }
}

void RemoverMusicaPeloTitulo(Playlist playlist)
{
    var musicaEncontrada = rockNacional.ObterPeloTitulo("Eduardo e Mônica");
    if (musicaEncontrada is not null)
    {
        Console.WriteLine("Removendo música...");
        rockNacional.Remove(musicaEncontrada);
    }
    else
    {
        Console.WriteLine("Musica não encontrada");
    }
}

void ExibirPlaylist(Playlist playlist)
    {
        Console.WriteLine($"Tocando as músicas de {playlist.Nome}");
        foreach (var musica in playlist)
        {
            Console.WriteLine($"- {musica.Titulo} / {musica.Artista} / {musica.Duracao}");
        }
    }


rockNacional.OrdernarPorDuracao();

ExibirPlaylist(rockNacional);

rockNacional.OrdernarPorArtista();  

// ===========================================================================================================
class Musica : IComparable
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }
    public int CompareTo(object? obj) // Se iguais, retorna zero; se menor, retorna -1; se maior, retorna 1.
    {
        if (obj is null) return -1;
        if (obj is Musica outraMusica) return this.Duracao.CompareTo(outraMusica.Duracao); // Compara se é um objeto do tipo música e depois compara com outra música.
        return -1;
    }
}
class PorArtista : IComparer<Musica> // Um comparador para músicas de artista.
{
public int Compare(Musica? x, Musica? y)
    {
        if (x is null && y is null) return 0; // Se ambos nulos, são iguais.
        if (x is null) return 1; // Se x for nulo, x é "maior" (vai pro final)
        if (y is null) return -1; // Se y for nulo, x é "menor" (vai pro começo)
        return x.Artista.CompareTo(y.Artista);
    }
}

class PorTitulo : IComparer<Musica> // Um comparador para músicas de título
{
    public int Compare(Musica? x, Musica? y)
    {
        if (x is null && y is null) return 0; // Se ambos nulos, são iguais.
        if (x is null) return 1; // Se x for nulo, x é "maior" (vai pro final)
        if (y is null) return -1; // Se y for nulo, x é "menor" (vai pro começo)
        return x.Titulo.CompareTo(y.Titulo);
    }
}


class Playlist : ICollection<Musica> // IColletion implementa as propriedades Add, Clear, Contais, CopyTo, Remove
{
    // Lista de Músicas já implementa, naturalmente, o ICollection
    private List<Musica> lista = [];

    public string Nome { get; set; }

    // ICollection (Add, Clear, Contais, CopyTo, Remove)

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(Musica musica)
    {
        lista.Add(musica);
    }

    public void Clear()
    {
        lista.Clear();
    }

    public bool Contains(Musica musica)
    {
        return (lista.Contains(musica));
    }

    public void CopyTo(Musica[] array, int arrayIndex)
    {
        lista.CopyTo(array, arrayIndex);
    }

    public bool Remove(Musica musica)
    {
        return lista.Remove(musica);
    }

    // Obtendo Música aleatória com new Random()
    public Musica? ObterAleatorio()
    {
        if (lista.Count == 0) return null;
        var random = new Random();
        var indiceAleatorio = random.Next(0, lista.Count - 1); // Do zero ao último indice.
        return lista[indiceAleatorio];
    }


    // Obtendo Música pelo Título
    public Musica? ObterPeloTitulo(string titulo)
    {
        foreach (var musica in lista)
        {
            if (musica.Titulo == titulo) return musica;
        }
        return null;
    }

    public void OrdernarPorDuracao()
    {
        lista.Sort(); // .Sort() é o método de ordenação crescente. Ele segue a lógica determinada por IComparable, na classe Música
    }
    public void OrdernarPorArtista()
    {
        lista.Sort(new PorArtista()); // Passando o objeto Por Artista, para comparar por artista.
    }

    public void OrdernarPorTitulo()
    {
        lista.Sort(new PorTitulo()); // Passando o objeto Por Artista, para comparar por artista.
    }

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

/* 
Definindo Sort().
-> Sort() ordena uma lista. Sem parâmetros, usa a lógica padrão do CompareTo. Com parâmetros, usa a lógica de um Comparer específico.
CompareTo retorna -1 (menor), 0 (igual) ou 1 (maior). Funciona para qualquer tipo que implemente IComparable, não só números.
Criou-se a classe Comparer para ter múltiplas formas de ordenação sem alterar a classe Musica.
 
Porque implementar Comparers?
-> A classe Musica implementa IComparable com a lógica padrão (por duração). Isso é o "comportamento padrão" da classe.
Os Comparers (PorArtista, PorTitulo) são lógicas adicionais, sem alterar a classe Musica.
 
 */