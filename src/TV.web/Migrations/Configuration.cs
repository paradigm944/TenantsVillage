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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Hiawatha",
                    ZipCode = 52233

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Hiawatha",
                    ZipCode = 52233

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Hiawatha",
                    ZipCode = 52233

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Hiawatha",
                    ZipCode = 52233

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Hiawatha",
                    ZipCode = 52233

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Hiawatha",
                    ZipCode = 52233

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Hiawatha",
                    ZipCode = 52233

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Iowa City",
                    ZipCode = 52246

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Iowa City",
                    ZipCode = 52246

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Iowa City",
                    ZipCode = 52246

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Iowa City",
                    ZipCode = 52246

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
                    Street = "Burlington",
                    Rating = 3,
                    City = "Iowa City",
                    ZipCode = 52246

                },
            };
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Emkay Entertainments", LLemail = "bigMoney@hotmail.com", Post = "ivghcyuyxutxut", DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "The Empire", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Asadul Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Gargamel ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Ashley Mark Publishing Company", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "MuchMoreMusic Studios", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Victoria Music Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Abacus Agent", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Atomic", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Pyramid Posters", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Kingston Smith Financial Services Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 7, LandLord = "Garrett Axford PR", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Derek Boulton Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Total Concept Management (TCM)", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Billy Russell Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Stage Audio Services", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Windsong International", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Vivante Music Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Way to Blue", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Glasgow City Halls", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "The List", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Wilkinson Turner King", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "GSC Solicitors", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Vanessa Music Co", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "Regent Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "BBC Radio Lancashire", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Burlington", ZipCode = 52246, City = "Iowa City", User = user, Rating = 5, LandLord = "The Citadel Arts Centre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 52246, City = "Iowa City", User = user, Rating = 2.5, LandLord = "Villa Audio Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 52246, City = "Iowa City", User = user, Rating = 2.5, LandLord = "Astra travel", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 52246, City = "Iowa City", User = user, Rating = 2.5, LandLord = "Idle Eyes Printshop", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Miggins Music (UK)", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Magic 999", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Delga Group", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Zane Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Universal Music Operations", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Gotham Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Timbuktu Music Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Online Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Irish Music Magazine", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Savoy Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Temple Studios", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Gravity Shack Studio", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Dovehouse Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Citysounds Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 2.5, LandLord = "Revolver Music Publishing", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Jug Of Ale", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Isles FM 103", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Headscope", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Universal Music Ireland", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Zander Exports", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Midem (UK)", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "La Rocka Studios", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Warner Home DVD", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Music Room", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Blue Planet", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Dream 107.7FM", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Moneypenny Agency", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Artsun", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Clyde 2", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "9PR", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "River Studio's", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Start Entertainments Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Vinyl Tap Mail Order Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "N. Linn", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Passion Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "SuperVision Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 50522, City = "Ames", User = user, Rating = 6.5, LandLord = "Lite FM", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 50522, City = "Cedar Rapids", User = user, Rating = 6.5, LandLord = "ISIS Duplicating Company", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 6.5, LandLord = "Vanderbeek & Imrie Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 6.5, LandLord = "Glamorgan University", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 6.5, LandLord = "Web User", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 6.5, LandLord = "Farnborough Recreation Centre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Robert Owens/Musical Directions", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Magick Eye Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Alexandra Theatre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Keda Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Independiente Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Shurwood Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Fury Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Northumbria University", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Pop Muzik", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Jonsongs Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Hermana PR", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Sugarcane Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "JFM Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Black Market Records", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Float Your Boat Productions", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Creation Management", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "Bryter Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "The Headline Agency", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Govenor", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 9, LandLord = "MP Promotions", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "Modo Production Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "Nomadic Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "Reverb Records Ltd", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "SIBC", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "Marken Time Critical Express", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "102.2 Smooth FM", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "Chesterfield Arts Centre", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "The National Indoor Arena", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "Salisbury City Hall", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });
                context.Post.Add(new PostModel() { IsCompleted = 1, Street = "Dodge", ZipCode = 52233, City = "Cedar Rapids", User = user, Rating = 7, LandLord = "Minder Music", LLemail = "bigMoney@hotmail.com", IsDeleted = false, Title = "Seeded", LeaseYear = 2012, Rent = 900, Deposit = 750, DatePosted = DateTime.Now.ToString() });


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
                    ImageUrl =   "/Images/ugly-goth1.jpg",
                    Post = posts[6]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0014.jpg",
                    Post = posts[7]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/000_0015.jpg",
                    Post = posts[8]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/100_0022.jpg",
                    Post = posts[9]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0012.jpg",
                    Post = posts[10]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0006.jpg",
                    Post = posts[11]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010207.jpg",
                    Post = posts[6]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010210.jpg",
                    Post = posts[7]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IM000001.jpg",
                    Post = posts[8]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/CAM00001.jpg",
                    Post = posts[9]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/CAM00002.jpg",
                    Post = posts[10]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010203.jpg",
                    Post = posts[11]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010204.jpg",
                    Post = posts[6]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/P1010207.jpg",
                    Post = posts[7]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0166.jpg",
                    Post = posts[8]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0409.jpg",
                    Post = posts[9]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0394.jpg",
                    Post = posts[10]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0393.jpg",
                    Post = posts[11]
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
                //user.RegistrationCode = WebSecurity.GeneratePasswordResetToken(user.UserName, 1440);
                
                base.Seed(context);
            
        }
    }
}
