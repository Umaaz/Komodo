﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Komodo.Core.Database.Validations;
using Komodo.Core.Types.Model;
using NHibernate;
using NHibernate.Linq;

namespace Komodo.Core.Database.Commands
{
    public class Add
    {
        private static ISession _session;
        
        private static Dictionary<string, Person> _personCache = new Dictionary<string, Person>();

        private static Person GetFromPersonCache(string name)
        {
            Person temp;
            _personCache.TryGetValue(name, out temp);
            return temp;
        }
        private static void AddToPersonCache(Person person)
        {
            if (!_personCache.ContainsKey(person.Name))
                _personCache.Add(person.Name, person);
        }

        private static Dictionary<string, Genre> _genreCache = new Dictionary<string, Genre>();

        private static Genre GetFromGenreCache(string genre)
        {
            Genre temp;
            _genreCache.TryGetValue(genre, out temp);
            return temp;
        }
        private static void AddToGenreCache(Genre genre)
        {
            if (!_genreCache.ContainsKey(genre.GenreName))
                _genreCache.Add(genre.GenreName, genre);
        }

        private static Dictionary<string, KeyWord>  _keyWordCache = new Dictionary<string, KeyWord>();

        private static KeyWord GetFromKeyWordCache(string word)
        {
            KeyWord temp;
            _keyWordCache.TryGetValue(word, out temp);
            return temp;
        }

        private static void AddToKeyWordCache(KeyWord keyWord)
        {
            if(!_keyWordCache.ContainsKey(keyWord.Word))
                _keyWordCache.Add(keyWord.Word,keyWord);
        }

        public static bool AddFilm(Film film)
        {
            if (film == null)
                throw new ArgumentNullException("film");

            var mayCommit = true;
            Film filmToAdd;
            _session = Context.GetSession();
            using(var tx = _session.BeginTransaction())
            {
                filmToAdd = new Film
                                    {
                                        Title = film.Title,
                                        Synopsis = film.Synopsis,
                                        ReleaseDate = film.ReleaseDate,
                                        Url = film.Url,
                                        Files = film.Files
                                    };

                FilterPersonCollection(film.Directors,filmToAdd);
                FilterPersonCollection(film.Writers, filmToAdd);

                foreach (var genre in film.Genres)
                {
                    var genre1 = genre;
                    var gen = GetFromGenreCache(genre1.GenreName) ??
                              _session.Query<Genre>().Where(x => x.GenreName == genre1.GenreName).SingleOrDefault() ??
                              genre;
                    AddToGenreCache(gen);
                    filmToAdd.Genres.Add(gen);
                }

                foreach (var keyWord in film.KeyWords)
                {
                    var keyWord1 = keyWord;
                    var key = GetFromKeyWordCache(keyWord1.Word) ??
                              _session.Query<KeyWord>().Where(x => x.Word == keyWord1.Word).SingleOrDefault() ?? 
                              keyWord;
                    AddToKeyWordCache(key);
                    filmToAdd.KeyWords.Add(key);
                }
                
                foreach (var role in film.Cast)
                {
                    var role1 = role;
                    var act = GetFromPersonCache(role1.Actor.Name) ??
                             _session.Query<Person>().Where(x => x.Name == role1.Actor.Name).SingleOrDefault() ?? 
                             role.Actor;
                    AddToPersonCache(act);
                    filmToAdd.Cast.Add(new Role{Actor = act,CharacterName = role1.CharacterName,Id = role1.Id});
                }

                var validator = new FilmValidator();
                var results = validator.Validate(filmToAdd);
                if (results.IsValid)
                {
                    _session.Save(filmToAdd);
                }
                else
                    mayCommit = false;
                if(mayCommit)
                    tx.Commit();
            }
            Index.Indexer.Index(filmToAdd);
            return mayCommit;
        }

        private static void FilterPersonCollection(IList<Person> collection, Film filmToAdd)
        {
            foreach (var person in collection)
            {
                var person1 = person;
                var per = GetFromPersonCache(person.Name) ??
                          _session.Query<Person>().Where(x => x.Name == person1.Name).SingleOrDefault() ??
                          person;
                AddToPersonCache(per);
                filmToAdd.Writers.Add(per);
            }
        }
    }
}
