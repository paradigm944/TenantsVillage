namespace TV.web.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using TV.web.Models;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<TV.web.Models.TVContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TV.web.Models.TVContext context)
        {
            
                WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection",
                    "UserProfile",
                    "UserId",
                    "UserName", autoCreateTables: true);

                if (!Roles.RoleExists("Administrator"))
                    Roles.CreateRole("Administrator");

                if (!WebSecurity.UserExists("seedAdmin"))
                    WebSecurity.CreateUserAndAccount(
                        "seedAdmin",
                        "password");

                var user = context.UserProfiles.Where(u => u.UserName == "seedAdmin").SingleOrDefault();
                user.Email = "paradigm944@gmail.com";
                user.isVerified = true;

                if (!Roles.GetRolesForUser("seedAdmin").Contains("Administrator"))
                    Roles.AddUsersToRoles(new[] { "seedAdmin" }, new[] { "Administrator" });


                var posts = new List<PostModel>
            {
                new PostModel
                {
                    LandLord = "ANC",
                    LLemail = "1@f.com",
                    Post = "All work and no play makes Jack  dull boy",
                    DatePosted = DateTime.Now.ToString(),
                    User = user,
                    IsDeleted = false,
                    Title = "Seeded",
                    LeaseYear = 2012,
                    Rent = 900,
                    Deposit = 750,
                    IsCompleted = 1,
                    Street = "Burlington"

                },
                new PostModel
                {
                    LandLord = "ANC",
                    LLemail = "1@f.com",
                    Post = "All work and no play makes Jack  dull boy",
                    DatePosted = DateTime.Now.ToString(),
                    User = user,
                    IsDeleted = false,
                    Title = "Seeded",
                    LeaseYear = 2012,
                    Rent = 900,
                    Deposit = 750,
                    IsCompleted = 1,
                    Street = "Burlington"

                },
                new PostModel
                {
                    LandLord = "ANC",
                    LLemail = "1@f.com",
                    Post = "All work and no play makes Jack  dull boy",
                    DatePosted = DateTime.Now.ToString(),
                    User = user,
                    IsDeleted = false,
                    Title = "Seeded",
                    LeaseYear = 2012,
                    Rent = 900,
                    Deposit = 750,
                    IsCompleted = 1,
                    Street = "Burlington"

                },
                new PostModel
                {
                    LandLord = "Heritage",
                    LLemail = "1hhh@fkkkk.com",
                    DatePosted = DateTime.Now.ToString(),
                    Post = "Hope is a good thing, maybe the best of things",
                    User = user,
                    IsDeleted = false,
                    Title = "Seeded",
                    LeaseYear = 2012,
                    Rent = 900,
                    Deposit = 750,
                    IsCompleted = 1,
                    Street = "Burlington"

                },
                new PostModel
                {
                    LandLord = "Apts Downtown",
                    LLemail = "apt@dog.edu",
                    Post = "There but for the grace of god go I",
                    DatePosted = DateTime.Now.ToString(),
                    User = user,
                    IsDeleted = false,
                    Title = "Seeded",
                    LeaseYear = 2012,
                    Rent = 900,
                    Deposit = 750,
                    IsCompleted = 1,
                    Street = "Burlington"

                },
                new PostModel
                {
                    LandLord = "Micheals",
                    LLemail = "micheals@bbbb.com",
                    Post = "Now yous's can't leave",
                    DatePosted = DateTime.Now.ToString(),
                    User = user,
                    IsDeleted = false,
                    Title = "Seeded",
                    LeaseYear = 2012,
                    Rent = 900,
                    Deposit = 750,
                    IsCompleted = 1,
                    Street = "Burlington"

                },
            };
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Emkay Entertainments", LLemail = "bigMoney@hotmail.com", Post = "ivghcyuyxutxut", DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "The Empire", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Asadul Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Gargamel ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Ashley Mark Publishing Company", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "MuchMoreMusic Studios", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Victoria Music Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Abacus Agent", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Atomic", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Pyramid Posters", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Kingston Smith Financial Services Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Garrett Axford PR", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Derek Boulton Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Total Concept Management (TCM)", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Billy Russell Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Stage Audio Services", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Windsong International", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Vivante Music Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Way to Blue", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Glasgow City Halls", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "The List", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Wilkinson Turner King", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "GSC Solicitors", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Vanessa Music Co", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "Regent Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "BBC Radio Lancashire", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", User = user, LandLord = "The Citadel Arts Centre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Villa Audio Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Astra travel", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Idle Eyes Printshop", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Miggins Music (UK)", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Magic 999", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Delga Group", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Zane Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Universal Music Operations", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Gotham Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Timbuktu Music Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Online Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Irish Music Magazine", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Savoy Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Temple Studios", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Gravity Shack Studio", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Dovehouse Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Citysounds Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Revolver Music Publishing", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Jug Of Ale", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Isles FM 103", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Headscope", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Universal Music Ireland", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Zander Exports", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Midem (UK)", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "La Rocka Studios", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Warner Home DVD", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Music Room", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Blue Planet", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Dream 107.7FM", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Moneypenny Agency", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Artsun", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Clyde 2", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "9PR", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "River Studio's", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Start Entertainments Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Vinyl Tap Mail Order Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", User = user, LandLord = "Passion Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "SuperVision Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Lite FM", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "ISIS Duplicating Company", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Vanderbeek & Imrie Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Glamorgan University", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Web User", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Farnborough Recreation Centre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Robert Owens/Musical Directions", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Magick Eye Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Alexandra Theatre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Keda Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Independiente Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Shurwood Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Fury Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Northumbria University", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Pop Muzik", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Jonsongs Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Hermana PR", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Sugarcane Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "JFM Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Black Market Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Float Your Boat Productions", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Creation Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "Bryter Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "The Headline Agency", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", User = user, LandLord = "MP Promotions", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "Modo Production Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "Nomadic Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "Reverb Records Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "SIBC", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "Marken Time Critical Express", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "102.2 Smooth FM", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "Chesterfield Arts Centre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "The National Indoor Arena", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "Salisbury City Hall", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", User = user, LandLord = "Minder Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });


                var images = new List<ImageModel>
            {
                new ImageModel
                {
                    ImageUrl =   "/Images/ugly-goth1.jpg",
                    Post = posts[0]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0014.jpg",
                    Post = posts[1]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/000_0015.jpg",
                    Post = posts[2]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/100_0022.jpg",
                    Post = posts[3]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0012.jpg",
                    Post = posts[4]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0006.jpg",
                    Post = posts[5]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010207.jpg",
                    Post = posts[0]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010210.jpg",
                    Post = posts[1]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IM000001.jpg",
                    Post = posts[2]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/CAM00001.jpg",
                    Post = posts[3]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/CAM00002.jpg",
                    Post = posts[4]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010203.jpg",
                    Post = posts[5]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010204.jpg",
                    Post = posts[0]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010207.jpg",
                    Post = posts[1]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0166.jpg",
                    Post = posts[2]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0409.jpg",
                    Post = posts[3]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0394.jpg",
                    Post = posts[4]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0393.jpg",
                    Post = posts[5]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010217.jpg",
                    Post = posts[0]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0389.jpg",
                    Post = posts[1]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0078.jpg",
                    Post = posts[2]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0076.jpg",
                    Post = posts[3]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0382.jpg",
                    Post = posts[4]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0388.jpg",
                    Post = posts[5]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0389.jpg",
                    Post = posts[4]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/CAM00098.jpg",
                    Post = posts[3]
                }

            };

                

                ////add to context

                
                //var errors = context.GetValidationErrors();

                posts.ForEach(x => context.Post.Add(x));
                images.ForEach(x => context.Image.Add(x));

                context.SaveChanges();

                //errors = context.GetValidationErrors();

                base.Seed(context);
            
        }
    }
}
