using System;
using System.Dynamic;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace firstlab{
    
    class Music{
        public string name;
        public string genre;
        public bool like;

        public void SetMusic(string name_music, string genre_music, bool like){
            this.name = name_music;
            this.genre = genre_music;
            this.like = like;    
        }        
    }

    class Album{
        public string name;
        public Music music = new Music();
        public void setAlbum(string name_album, string music_album, string genre_music, bool like){
            name = name_album;
            music.SetMusic(music_album, genre_music, like); 
        }
    }
    class Author{
        public string name;
        public Album album = new Album();
        public void SetAuthor(string name_author, string name_album, string music_album, string genre_music, bool like){
            name = name_author;
            album.setAlbum(name_album, music_album, genre_music, like);
        }
    }

    class Collection{
        public string name;
        public string author_name;
        public string music;
        public string genre;

        public void SetCollection(string name_collection, Author author){
            name = name_collection;
            author_name = author.name;
            music = author.album.music.name;
            genre = author.album.music.genre;
        }
    }

    class MusicCatalog{
        static void Main(){
            
            Author[] authors = new Author[5];
            authors[0] = new Author();
            authors[0].SetAuthor("Maruv", "Album Maruva", "Siren Song", "pop", false);
            authors[1] = new Author();
            authors[1].SetAuthor("Просто Лера", "Альбом Леры", "Мне 20", "pop", true);
            authors[2] = new Author();
            authors[2].SetAuthor("Maruv", "Album Maruva", "Drunk Groove", "rok", false);
            authors[3] = new Author();
            authors[3].SetAuthor("Sub Urban", "Album Urban", "Isolate", "djaz", true);
            authors[4] = new Author();
            authors[4].SetAuthor("Sub Urban", "Album Sub", "Vacuum Boy", "rok", false);
            
            Collection[] collections = new Collection[5];
            for(int i = 0; i < 5; i++){
                if(authors[i].album.music.like == true){
                    collections[i] = new Collection();
                    collections[i].SetCollection("likely", authors[i]);
                }
                else{
                    collections[i] = new Collection();
                    collections[i].SetCollection("not likely", authors[i]);
                }
            }

            string value = "", znachenie = "", value_z = "";
            while (value != "end"){
                System.Console.Write("Что хотите найти (author, music, genre, album, collection)? ");
                value = Console.ReadLine();
                if (value == "author"){
                    System.Console.Write("По какому параметру будем искать (name, music, genre, album)? ");
                    znachenie = Console.ReadLine();
                    switch(znachenie){
                        case "name":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].name == value_z){
                                    System.Console.WriteLine("Альбом: "+authors[i].album.name+"; песня: "+authors[i].album.music.name+"; жанр: "+authors[i].album.music.genre);
                                }
                            }
                            break;
                        case "album":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.name == value_z){
                                    System.Console.WriteLine("Музыкант: "+authors[i].name);
                                }
                            }
                            break;
                    
                        case "music":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.name == value_z){
                                    System.Console.WriteLine("Музыкант: "+authors[i].name);
                                }
                            }
                            break;
                        case "genre":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.genre == value_z){
                                    System.Console.WriteLine("Музыкант: "+authors[i].name);
                                }
                            }
                            break;
                    }
                }
                else if(value == "album"){
                    System.Console.Write("По какому параметру будем искать (name, author, music, genre)? ");
                    znachenie = Console.ReadLine();
                    switch(znachenie){
                        case "name":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.name == value_z){
                                    System.Console.WriteLine("Музыкант: "+authors[i].name+"; песня: "+authors[i].album.music.name+"; жанр: "+authors[i].album.music.genre);
                                }
                            }
                            break;
                        case "author":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].name == value_z){
                                    System.Console.WriteLine("Альбом: "+authors[i].album.name);
                                }
                            }
                            break;
                        case "music":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.name == value_z){
                                    System.Console.WriteLine("Альбом: "+authors[i].album.name);
                                }
                            }
                            break;
                        case "genre":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.genre == value_z){
                                    System.Console.WriteLine("Альбом: "+authors[i].album.name);
                                }
                            }
                            break;
                    }
                }
                else if(value == "genre"){
                    System.Console.Write("По какому параметру будем искать (name, author, music, album)? ");
                    znachenie = Console.ReadLine();
                    switch(znachenie){
                        case "name":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.genre == value_z){
                                    System.Console.WriteLine("Музыкант: "+authors[i].name+"; песня: "+authors[i].album.music.name+"; альбом: "+authors[i].album.name);
                                }
                            }
                            break;
                        case "author":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].name == value_z){
                                    System.Console.WriteLine("Жанр: "+authors[i].album.music.genre);
                                }
                            }
                            break;
                        case "music":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.name == value_z){
                                    System.Console.WriteLine("Жанр: "+authors[i].album.music.genre);
                                }
                            }
                            break;
                        case "album":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.name == value_z){
                                    System.Console.WriteLine("Жанр: "+authors[i].album.music.genre);
                                }
                            }
                            break;
                    }
                }
                else if(value == "music"){
                    System.Console.Write("По какому параметру будем искать (name, author, album, genre)? ");
                    znachenie = Console.ReadLine();
                    switch(znachenie){
                        case "name":
                            System.Console.Write("Введите значение этого параметра: ");
                           value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.name == value_z){
                                    System.Console.WriteLine("Музыкант: "+authors[i].name+"; альбом: "+authors[i].album.name+"; жанр: "+authors[i].album.music.genre);
                                }
                            }
                            break;
                        case "author":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].name == value_z){
                                    System.Console.WriteLine("Песня: "+authors[i].album.music.name);
                                }
                            }
                            break;
                        case "album":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.name == value_z){
                                    System.Console.WriteLine("Песня: "+authors[i].album.music.name);
                                }
                            }
                            break;
                        case "genre":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.genre == value_z){
                                    System.Console.WriteLine("Песня: "+authors[i].album.music.name);
                                }
                            }
                            break;
                    }
                }
                else if(value == "collection"){
                    System.Console.Write("По какому параметру будем искать (name, author, album, genre)? ");
                    znachenie = Console.ReadLine();
                    switch(znachenie){
                        case "name":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(collections[i].name == value_z){
                                    System.Console.WriteLine("Музыкант: "+collections[i].author_name+"; жанр: "+collections[i].genre);
                                }
                            }
                            break;
                        case "author":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(collections[i].author_name == value_z){
                                    System.Console.WriteLine("Сборник: "+collections[i].name);
                                }
                            }
                            break;
                        case "genre":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(collections[i].genre == value_z){
                                    System.Console.WriteLine("Сборник: "+collections[i].name);
                                }
                            }
                            break;
                    }
                }
            }
        }
    } 
}
