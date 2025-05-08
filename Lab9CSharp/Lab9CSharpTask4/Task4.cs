using System.Collections;

namespace  Lab9CSharp.Lab9CSharpTask4 {
    public class Task4 {
        public void Task() {
            Console.WriteLine("\n >>> Task 4");

            MusicCatalog catalog = new MusicCatalog();

            var disc1 = new MusicDisc("Rock Hits");
            var disc2 = new MusicDisc("Pop Stars");

            catalog.AddDisc(disc1);
            catalog.AddDisc(disc2);

            catalog.AddSongToDisc("Rock Hits", new Song("Thunderstruck", "AC/DC", TimeSpan.FromSeconds(292)));
            catalog.AddSongToDisc("Rock Hits", new Song("Nothing Else Matters", "Metallica", TimeSpan.FromSeconds(388)));
            catalog.AddSongToDisc("Pop Stars", new Song("Bad Romance", "Lady Gaga", TimeSpan.FromSeconds(295)));
            catalog.AddSongToDisc("Pop Stars", new Song("Shallow", "Lady Gaga", TimeSpan.FromSeconds(215)));

            Console.WriteLine("Catalog: ");
            catalog.ViewCatalog();

            Console.WriteLine("Pop star disc: ");
            catalog.ViewDisc("Pop Stars");

            Console.WriteLine("\nПошук Lady Gaga");
            catalog.SearchByArtist("Lady Gaga");

            catalog.RemoveSongFromDisc("Pop Stars", "Shallow");

            Console.WriteLine("\nПісля видалення пісні 'Shallow'");
            catalog.ViewDisc("Pop Stars");

            // Видалення диска
            catalog.RemoveDisc("Rock Hits");

            Console.WriteLine("\nПісля видалення диска 'Rock Hits'");
            catalog.ViewCatalog();
        }
    }
    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }

        public Song(string title, string artist, TimeSpan duration)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist} ({Duration:mm\\:ss})";
        }
    }

    class MusicDisc
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }

        public MusicDisc(string name)
        {
            Name = name;
            Songs = new List<Song>();
        }

        public void AddSong(Song song) => Songs.Add(song);

        public void RemoveSong(string title) => Songs.RemoveAll(s => s.Title == title);

        public override string ToString()
        {
            string result = $"Диск: {Name}\n";
            foreach (var song in Songs)
                result += "  " + song + "\n";

            return result;
        }
    }

    class MusicCatalog
    {
        private Hashtable catalog = new Hashtable();

        public void AddDisc(MusicDisc disc)
        {
            if (!catalog.ContainsKey(disc.Name))
                catalog[disc.Name] = disc;
        }

        public void RemoveDisc(string discName)
        {
            catalog.Remove(discName);
        }

        public void AddSongToDisc(string discName, Song song)
        {
            if (catalog.ContainsKey(discName))
                ((MusicDisc)catalog[discName]).AddSong(song);
        }

        public void RemoveSongFromDisc(string discName, string songTitle)
        {
            if (catalog != null && catalog.ContainsKey(discName))
                ((MusicDisc)catalog[discName]).RemoveSong(songTitle);
        }

        public void ViewCatalog()
        {
            foreach (DictionaryEntry entry in catalog)
                Console.WriteLine(entry.Value);
        }

        public void ViewDisc(string discName)
        {
            if (catalog.ContainsKey(discName))
                Console.WriteLine(catalog[discName]);
            else
                Console.WriteLine($"Диск '{discName}' не знайдено.");
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Пошук пісень виконавця: {artist}");
            foreach (DictionaryEntry entry in catalog)
            {
                if(entry.Value == null) continue;
                var disc = (MusicDisc)entry.Value;

                foreach (var song in disc.Songs)
                    if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine($"{disc.Name}: {song}");
            }
        }


    }


}