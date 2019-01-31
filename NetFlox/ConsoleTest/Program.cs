using Microsoft.EntityFrameworkCore;
using NetFlox.DAL;
using System;
using System.Linq;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NetFloxEntities.DbFilePath);

            using (var context = new NetFloxEntities())
            {
                var query = "kub";
                var result = context.Celebrites
                    .Where(c => EF.Functions.Like(c.Nom, "%" + query + "%"))
                    .OrderByDescending(c => c.RoleCelebriteFilms.Count)
                    .ThenByDescending(c => c.Nom)
                    .ToList();
            }
        }

        //public static void ResetDatabase()
        //{
        //    using (var entities = new NetFloxEntities())
        //    {
        //        entities.Database.EnsureDeleted();
        //        entities.Database.EnsureCreated();

        //        var user = entities.Utilisateurs.Add(new Utilisateur
        //        {
        //            Nom = "Demo",
        //            Prenom = "demo",
        //            AdresseEmail = "demo@demo.com",
        //            DateInscription = DateTime.Now,
        //        });                

        //        var acteur = entities.Roles.Add(new Role
        //        {
        //            Id = 1,
        //            Libelle = "Acteur",
        //        });
        //        var realisateur = entities.Roles.Add(new Role
        //        {
        //            Id = 2,
        //            Libelle = "Réalisateur",
        //        });
        //        var producteur = entities.Roles.Add(new Role
        //        {
        //            Id = 3,
        //            Libelle = "Producteur",
        //        });
        //        var doubleur = entities.Roles.Add(new Role
        //        {
        //            Id = 4,
        //            Libelle = "Doubleur",
        //        });

        //        var sharknado = entities.Films.Add(new Film
        //        {
        //            Titre = "Sharknado",
        //            Pays = "USA",
        //            Annee = 2013,
        //            UrlAffiche = "https://m.media-amazon.com/images/M/MV5BODcwZWFiNTEtNDgzMC00ZmE2LWExMzYtNzZhZDgzNDc5NDkyXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SY1000_CR0,0,654,1000_AL_.jpg",
        //        });
        //        var mechaShark = entities.Films.Add(new Film
        //        {
        //            Titre = "Mega Shark vs. Mecha Shark",
        //            Pays = "USA",
        //            Annee = 2014,
        //            UrlAffiche = "https://m.media-amazon.com/images/M/MV5BMTQzMDIyMjgxMF5BMl5BanBnXkFtZTgwODYzNjg4MDE@._V1_SY1000_CR0,0,713,1000_AL_.jpg",
        //        });
        //        var crocosaurus = entities.Films.Add(new Film
        //        {
        //            Titre = "Mega Shark vs. Crocosaurus",
        //            Pays = "USA",
        //            Annee = 2010,
        //            UrlAffiche = "https://m.media-amazon.com/images/M/MV5BNDY2NTM2MzAyM15BMl5BanBnXkFtZTcwNjk1MTIwNA@@._V1_.jpg",
        //        });
        //        var sharktopus = entities.Films.Add(new Film
        //        {
        //            Titre = "Sharktopus",
        //            Pays = "USA",
        //            Annee = 2010,
        //            UrlAffiche = "https://m.media-amazon.com/images/M/MV5BMTc5MTE5MzY2Nl5BMl5BanBnXkFtZTcwMTQ0NzAzOA@@._V1_.jpg",
        //        });

        //        var anthonyFerrante = entities.Celebrites.Add(new Celebrite
        //        {
        //            Nom = "Anthony Ferrante",
        //            DateNaissance = null,
        //            UrlPhoto = "https://m.media-amazon.com/images/M/MV5BMTY2NjM2MDcyMl5BMl5BanBnXkFtZTcwOTcyNjU3Mw@@._V1_UY317_CR5,0,214,317_AL_.jpg",
        //        });
        //        entities.RoleCelebriteFilms.Add(new RoleCelebriteFilm()
        //        {
        //            Role = realisateur.Entity,
        //            Celebrite = anthonyFerrante.Entity,
        //            Film = sharknado.Entity,
        //            NomPersonnage = null,
        //        });

        //        entities.Favoris.Add(new Favori
        //        {
        //            Utilisateur = user.Entity,
        //            Film = sharknado.Entity,
        //            DateAjout = DateTime.Now,
        //        });

        //        entities.SaveChanges();
        //    }
        //}
    }
}
