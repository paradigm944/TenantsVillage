using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TV.web.Models;
using System.Collections;

namespace TV.web.Models
{
    public class TVDataIntitializer : DropCreateDatabaseIfModelChanges<TVContext>
    {

        protected override void Seed(TVContext context)
        {

            //TODO add users
            //var users = new List<User>
            //{
            //    new User
            //    {
            //        FirstName = "Jeremy",
            //        LastName = "Gilbert",
            //        UserName = "jdgilbert",
            //        EmailAddress = "joadgilbert@hotmail.com",
            //        PasswordSalt = "qxNddQcwBOHr5TkYR9iTD4b05LJPdSVYpNnrySm8E5F+aNF6KriJipVaOCbhT0VJQgkjr9qlsb8mgbG4aO/VzA==",
            //        PasswordHash = "Q6qG2JE4A4oL1W6VJfyRUqj9rG8QpbBKqgXk/p5wfRt8a2dQBLtzvhaFwEinDCPYwmkDhpQyDv9ELKK/P8UG5A==",
            //        CreatedAt = DateTime.Now,
            //        CreatedBy = "admin",
            //        PhoneNumber = "55555555555"

            //    }

            //};
            //    new UserModel
            //    {
            //        firstName = "Jeremy",
            //        lastName = "Gilbert",
            //        userName = "jdgilbert",
            //        Email = "joadgilbert@hotmail.com",
            //        password = "password"
            //    }
            //};
            var users = new List<UserProfile>
            {
                new UserProfile
                {
                    UserId = 1,
                    UserName = "paradigm"
                }

            };

            var posts = new List<PostModel>
            {
                new PostModel
                {
                    LandLord = "ANC",
                    LLemail = "1@f.com",
                    Post = "All work and no play makes Jack  dull boy",
                    DatePosted = DateTime.Now.ToString(),
                    User = users[0]

                },
                new PostModel
                {
                    LandLord = "Heritage",
                    LLemail = "1hhh@fkkkk.com",
                    DatePosted = DateTime.Now.ToString(),
                    Post = "Hope is a good thing, maybe the best of things",
                    User = users[0]

                },
                new PostModel
                {
                    LandLord = "Apts Downtown",
                    LLemail = "apt@dog.edu",
                    Post = "There but for the grace of god go I",
                    DatePosted = DateTime.Now.ToString(),
                    User = users[0]

                },
                new PostModel
                {
                    LandLord = "Micheals",
                    LLemail = "micheals@bbbb.com",
                    Post = "Now yous's can't leave",
                    DatePosted = DateTime.Now.ToString(),
                    User = users[0]

                },
            };

            var images = new List<ImageModel>
            {
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0382.jpg",
                    Post = posts[1]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0388.jpg",
                    Post = posts[1]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0389.jpg",
                    Post = posts[1]
                },
                new ImageModel
                {
                    ImageUrl =   "/Images/IMAG0380.jpg",
                    Post = posts[1]
                }

            };

            context.Post.Add(new PostModel() { LandLord = "Emkay Entertainments", LLemail = "Nobel House, Regent Centre", Post = "ivghcyuyxutxut", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "The Empire", LLemail = "Milton Keynes Leisure Plaza", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Asadul Ltd", LLemail = "Hophouse", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Gargamel ltd", LLemail = "", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Ashley Mark Publishing Company", LLemail = "1-2 Vance Court", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "MuchMoreMusic Studios", LLemail = "Unit 29", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Victoria Music Ltd", LLemail = "Unit 215", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Abacus Agent", LLemail = "Regent Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Atomic", LLemail = "133 Longacre", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Pyramid Posters", LLemail = "The Works", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Kingston Smith Financial Services Ltd", LLemail = "105 St Peter's Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Garrett Axford PR", LLemail = "Harbour House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Derek Boulton Management", LLemail = "76 Carlisle Mansions", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Total Concept Management (TCM)", LLemail = "PO Box 128", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Billy Russell Management", LLemail = "Binny Estate", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Stage Audio Services", LLemail = "Unit 2", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Windsong International", LLemail = "Heather Court", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Vivante Music Ltd", LLemail = "32 The Netherlands", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Way to Blue", LLemail = "First Floor", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Glasgow City Halls", LLemail = "32 Albion Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "The List", LLemail = "14 High St", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Wilkinson Turner King", LLemail = "10A London Road", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "GSC Solicitors", LLemail = "31-32 Ely Place", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Vanessa Music Co", LLemail = "35 Tower Way", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Regent Records", LLemail = "PO Box 528", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "BBC Radio Lancashire", LLemail = "20-26 Darwen St", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "The Citadel Arts Centre", LLemail = "Waterloo Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Villa Audio Ltd", LLemail = "Baileys Yard", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Astra travel", LLemail = "", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Idle Eyes Printshop", LLemail = "81 Sheen Court", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Miggins Music (UK)", LLemail = "33 Mandarin Place", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Magic 999", LLemail = "St Paul's Square", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Delga Group", LLemail = "Seaplane House, Riverside Est.", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Zane Music", LLemail = "162 Castle Hill", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Universal Music Operations", LLemail = "Chippenham Drive", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Gotham Records", LLemail = "PO Box 6003", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Timbuktu Music Ltd", LLemail = "99C Talbot Road", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Online Music", LLemail = "Unit 18, Croydon House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Irish Music Magazine", LLemail = "11 Clare St", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Savoy Records", LLemail = "PO Box 271", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Temple Studios", LLemail = "97A Kenilworth Road", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Gravity Shack Studio", LLemail = "Unit 3 ", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Dovehouse Records", LLemail = "Crabtree Cottage", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Citysounds Ltd", LLemail = "5 Kirby Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Revolver Music Publishing", LLemail = "152 Goldthorn Hill", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Jug Of Ale", LLemail = "43 Alcester Road", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Isles FM 103", LLemail = "PO Box 333", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Headscope", LLemail = "Headrest", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Universal Music Ireland", LLemail = "9 Whitefriars", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Zander Exports", LLemail = "34 Sapcote Trading Centre", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Midem (UK)", LLemail = "Walmar House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "La Rocka Studios", LLemail = "Post Mark House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Warner Home DVD", LLemail = "Warner House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Music Room", LLemail = "The Old Library", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Blue Planet", LLemail = "96 York Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Dream 107.7FM", LLemail = "Cater House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Moneypenny Agency", LLemail = "The Stables, Westwood House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Artsun", LLemail = "18 Sparkle Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Clyde 2", LLemail = "Clydebank Business Park", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "9PR", LLemail = "65-69 White Lion Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "River Studio's", LLemail = "3 Grange Yard", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Start Entertainments Ltd", LLemail = "3 Warmair House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Vinyl Tap Mail Order Music", LLemail = "1 Minerva Works", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Passion Music", LLemail = "20 Blyth  Rd", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "SuperVision Management", LLemail = "Zeppelin Building", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Lite FM", LLemail = "2nd Floor", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "ISIS Duplicating Company", LLemail = "Sales & Production", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Vanderbeek & Imrie Ltd", LLemail = "15 Marvig", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Glamorgan University", LLemail = "Student Union", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Web User", LLemail = "IPC Media", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Farnborough Recreation Centre", LLemail = "1 Westmead", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Robert Owens/Musical Directions", LLemail = "352A Kilburn Lane", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Magick Eye Records", LLemail = "PO Box 3037", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Alexandra Theatre", LLemail = "Station Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Keda Records", LLemail = "The Sight And Sound Centre", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Independiente Ltd", LLemail = "The Drill Hall", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Shurwood Management", LLemail = "Tote Hill Cottage", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Fury Records", LLemail = "PO Box 52", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Northumbria University", LLemail = "Union Building", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Pop Muzik", LLemail = "Haslemere", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Jonsongs Music", LLemail = "3 Farrers Place", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Hermana PR", LLemail = "Unit 244, Bon Marche Centre", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Sugarcane Music", LLemail = "32 Blackmore Avenue", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "JFM Records", LLemail = "11 Alexander House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Black Market Records", LLemail = "25 D'Arblay Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Float Your Boat Productions", LLemail = "5 Ralphs Retreat", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Creation Management", LLemail = "2 Berkley Grove", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Bryter Music", LLemail = "Marlinspike Hall", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "The Headline Agency", LLemail = "39 Churchfields", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "MP Promotions", LLemail = "13 Greave", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Modo Production Ltd", LLemail = "Ground Floor", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Nomadic Music", LLemail = "Unit 18", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Reverb Records Ltd", LLemail = "Reverb House", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "SIBC", LLemail = "Market Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Marken Time Critical Express", LLemail = "Unit 2", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "102.2 Smooth FM", LLemail = "26-27 Castlereagh Street", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Chesterfield Arts Centre", LLemail = "Chesterfield College", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "The National Indoor Arena", LLemail = "King Edward's Road", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Salisbury City Hall", LLemail = "Malthouse Lane", DatePosted = DateTime.Now.ToString() });
            context.Post.Add(new PostModel() { LandLord = "Minder Music", LLemail = "", DatePosted = DateTime.Now.ToString() });


            ////add to context

            users.ForEach(x => context.UserProfiles.Add(x));
            //var errors = context.GetValidationErrors();

            posts.ForEach(x => context.Post.Add(x));
            images.ForEach(x => context.Image.Add(x));

            context.SaveChanges();

            //errors = context.GetValidationErrors();

            base.Seed(context);
        }
    }
}
    

