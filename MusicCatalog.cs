using System;
using System.Dynamic;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace firstlab{
    
    class Music{
        public string name;
        public string zhanr;
        public bool mne_nravitsya;

        public void setmusic(string name_music, string zhanr_music, bool nravitsya){
            this.name = name_music;
            this.zhanr = zhanr_music;
            this.mne_nravitsya = nravitsya;    
        }        
    }

    class Album{
        public string name;
        public Music music = new Music();
        public void setAlbum(string name_album, string music_album, string zhanr_music, bool nravitsya){
            name = name_album;
            music.setmusic(music_album, zhanr_music, nravitsya); 
        }
    }
    class Author{
        public string name;
        public Album album = new Album();
        public void SetAuthor(string name_author, string name_album, string music_album, string zhanr_music, bool nravitsya){
            name = name_author;
            album.setAlbum(name_album, music_album, zhanr_music, nravitsya);
        }
    }

    class Sbornik{
        public string name;
        public string author_name;
        public string music;
        public string zhanr;

        public void SetSbornic(string name_sbornic, Author author){
            name = name_sbornic;
            author_name = author.name;
            music = author.album.music.name;
            zhanr = author.album.music.zhanr;
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
            
            Sbornik[] sborniks = new Sbornik[5];
            for(int i = 0; i < 5; i++){
                if(authors[i].album.music.mne_nravitsya == true){
                    sborniks[i] = new Sbornik();
                    sborniks[i].SetSbornic("likely", authors[i]);
                }
                else{
                    sborniks[i] = new Sbornik();
                    sborniks[i].SetSbornic("not likely", authors[i]);
                }
            }

            string value = "", znachenie = "", value_z = "";
            while (value != "end"){
                System.Console.Write("Что хотите найти (author, music, zhanr, album, collection)? ");
                value = Console.ReadLine();
                if (value == "author"){
                    System.Console.Write("По какому параметру будем искать (name, music, zhanr, album)? ");
                    znachenie = Console.ReadLine();
                    switch(znachenie){
                        case "name":
                        System.Console.WriteLine("Введите значение этого параметра: ");
                        value_z = Console.ReadLine();
                        for(int i = 0; i < 5; i++){
                            if(authors[i].name == value_z){
                                System.Console.WriteLine("Альбом: "+authors[i].album.name+"; песня: "+authors[i].album.music.name+"; жанр: "+authors[i].album.music.zhanr);
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
                    
                        case "zhanr":
                            System.Console.Write("Введите значение этого параметра: ");
                            value_z = Console.ReadLine();
                            for(int i = 0; i < 5; i++){
                                if(authors[i].album.music.zhanr == value_z){
                                    System.Console.WriteLine("Музыкант: "+authors[i].name);
                                }
                            }
                            break;
                        }
                    }
                    else if(value == "album"){
                        System.Console.Write("По какому параметру будем искать (name, author, music, zhanr)? ");
                        znachenie = Console.ReadLine();
                        switch(znachenie){
                            case "name":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].album.name == value_z){
                                        System.Console.WriteLine("Музыкант: "+authors[i].name+"; песня: "+authors[i].album.music.name+"; жанр: "+authors[i].album.music.zhanr);
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
                            case "zhanr":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].album.music.zhanr == value_z){
                                        System.Console.WriteLine("Альбом: "+authors[i].album.name);
                                    }
                                }
                                break;
                            }
                        break;
                    }
                    else if(value == "zhanr"){
                        System.Console.Write("По какому параметру будем искать (name, author, music, album)? ");
                        znachenie = Console.ReadLine();
                        switch(znachenie){
                            case "name":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].album.music.zhanr == value_z){
                                        System.Console.WriteLine("Музыкант: "+authors[i].name+"; песня: "+authors[i].album.music.name+"; альбом: "+authors[i].album.name);
                                    }
                                }
                                break;
                            case "author":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].name == value_z){
                                        System.Console.WriteLine("Жанр: "+authors[i].album.music.zhanr);
                                    }
                                }
                                break;
                            case "music":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].album.music.name == value_z){
                                        System.Console.WriteLine("Жанр: "+authors[i].album.music.zhanr);
                                    }
                                }
                                break;
                            case "album":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].album.name == value_z){
                                        System.Console.WriteLine("Жанр: "+authors[i].album.music.zhanr);
                                    }
                                }
                                break;
                            }
                        break;
                    }
                    else if(value == "music"){
                        System.Console.Write("По какому параметру будем искать (name, author, album, zhanr)? ");
                        znachenie = Console.ReadLine();
                        switch(znachenie){
                            case "name":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].album.music.name == value_z){
                                        System.Console.WriteLine("Музыкант: "+authors[i].name+"; альбом: "+authors[i].album.name+"; жанр: "+authors[i].album.music.zhanr);
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
                            case "zhanr":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(authors[i].album.music.zhanr == value_z){
                                        System.Console.WriteLine("Песня: "+authors[i].album.music.name);
                                    }
                                }
                                break;
                            }
                        break;
                    }
                    else if(value == "sbornik"){
                        System.Console.Write("По какому параметру будем искать (name, author, album, zhanr)? ");
                        znachenie = Console.ReadLine();
                        switch(znachenie){
                            case "name":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(sborniks[i].name == value_z){
                                        System.Console.WriteLine("Музыкант: "+sborniks[i].author_name+"; жанр: "+sborniks[i].zhanr);
                                    }
                                }
                                break;
                            case "author":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(sborniks[i].author_name == value_z){
                                        System.Console.WriteLine("Сборник: "+sborniks[i].name);
                                    }
                                }
                                break;
                            case "zhanr":
                                System.Console.Write("Введите значение этого параметра: ");
                                value_z = Console.ReadLine();
                                for(int i = 0; i < 5; i++){
                                    if(sborniks[i].zhanr == value_z){
                                        System.Console.WriteLine("Сборник: "+sborniks[i].name);
                                    }
                                }
                                break;
                            }
                        break;
                    }
                }
            }
        }
       
    }

