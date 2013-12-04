//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using TV.web.Models;
//using System.Collections;


//namespace TV.web.Models
//{
//    public class TVDataIntitializer : DropCreateDatabaseIfModelChanges<TVContext>
//    {

//        protected override void Seed(TVContext context)
//        {

//           var posts = new List<PostModel>
//            {
//                new PostModel
//                {
//                    LandLord = "ANC",
//                    LLemail = "1@f.com",
//                    Post = "All work and no play makes Jack  dull boy",
//                    DatePosted = DateTime.Now.ToString(),
//                    User = user

//                },
//                new PostModel
//                {
//                    LandLord = "Heritage",
//                    LLemail = "1hhh@fkkkk.com",
//                    DatePosted = DateTime.Now.ToString(),
//                    Post = "Hope is a good thing, maybe the best of things",
//                    User = user

//                },
//                new PostModel
//                {
//                    LandLord = "Apts Downtown",
//                    LLemail = "apt@dog.edu",
//                    Post = "There but for the grace of god go I",
//                    DatePosted = DateTime.Now.ToString(),
//                    User = user

//                },
//                new PostModel
//                {
//                    LandLord = "Micheals",
//                    LLemail = "micheals@bbbb.com",
//                    Post = "Now yous's can't leave",
//                    DatePosted = DateTime.Now.ToString(),
//                    User = user

//                },
//            };

//            var images = new List<ImageModel>
//            {
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0382.jpg",
//                    Post = posts[1]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0388.jpg",
//                    Post = posts[1]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0389.jpg",
//                    Post = posts[1]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0380.jpg",
//                    Post = posts[1]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0382.jpg",
//                    Post = posts[2]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0388.jpg",
//                    Post = posts[2]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0389.jpg",
//                    Post = posts[2]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0380.jpg",
//                    Post = posts[2]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0380.jpg",
//                    Post = posts[3]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0382.jpg",
//                    Post = posts[3]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0388.jpg",
//                    Post = posts[3]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0389.jpg",
//                    Post = posts[3]
//                },
//                new ImageModel
//                {
//                    ImageUrl =   "/Images/IMAG0380.jpg",
//                    Post = posts[3]
//                }

//            };

//            context.Post.Add(new PostModel() { User = user, LandLord = "Emkay Entertainments", LLemail = "Nobel House, Regent Centre", Post = "ivghcyuyxutxut", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "The Empire", LLemail = "Milton Keynes Leisure Plaza", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Asadul Ltd", LLemail = "Hophouse", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Gargamel ltd", LLemail = "", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Ashley Mark Publishing Company", LLemail = "1-2 Vance Court", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "MuchMoreMusic Studios", LLemail = "Unit 29", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Victoria Music Ltd", LLemail = "Unit 215", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Abacus Agent", LLemail = "Regent Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Atomic", LLemail = "133 Longacre", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Pyramid Posters", LLemail = "The Works", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Kingston Smith Financial Services Ltd", LLemail = "105 St Peter's Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Garrett Axford PR", LLemail = "Harbour House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Derek Boulton Management", LLemail = "76 Carlisle Mansions", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Total Concept Management (TCM)", LLemail = "PO Box 128", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Billy Russell Management", LLemail = "Binny Estate", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Stage Audio Services", LLemail = "Unit 2", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Windsong International", LLemail = "Heather Court", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Vivante Music Ltd", LLemail = "32 The Netherlands", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Way to Blue", LLemail = "First Floor", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Glasgow City Halls", LLemail = "32 Albion Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "The List", LLemail = "14 High St", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Wilkinson Turner King", LLemail = "10A London Road", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "GSC Solicitors", LLemail = "31-32 Ely Place", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Vanessa Music Co", LLemail = "35 Tower Way", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Regent Records", LLemail = "PO Box 528", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "BBC Radio Lancashire", LLemail = "20-26 Darwen St", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "The Citadel Arts Centre", LLemail = "Waterloo Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Villa Audio Ltd", LLemail = "Baileys Yard", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Astra travel", LLemail = "", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Idle Eyes Printshop", LLemail = "81 Sheen Court", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Miggins Music (UK)", LLemail = "33 Mandarin Place", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Magic 999", LLemail = "St Paul's Square", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Delga Group", LLemail = "Seaplane House, Riverside Est.", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Zane Music", LLemail = "162 Castle Hill", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Universal Music Operations", LLemail = "Chippenham Drive", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Gotham Records", LLemail = "PO Box 6003", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Timbuktu Music Ltd", LLemail = "99C Talbot Road", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Online Music", LLemail = "Unit 18, Croydon House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Irish Music Magazine", LLemail = "11 Clare St", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Savoy Records", LLemail = "PO Box 271", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Temple Studios", LLemail = "97A Kenilworth Road", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Gravity Shack Studio", LLemail = "Unit 3 ", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Dovehouse Records", LLemail = "Crabtree Cottage", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Citysounds Ltd", LLemail = "5 Kirby Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Revolver Music Publishing", LLemail = "152 Goldthorn Hill", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Jug Of Ale", LLemail = "43 Alcester Road", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Isles FM 103", LLemail = "PO Box 333", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Headscope", LLemail = "Headrest", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Universal Music Ireland", LLemail = "9 Whitefriars", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Zander Exports", LLemail = "34 Sapcote Trading Centre", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Midem (UK)", LLemail = "Walmar House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "La Rocka Studios", LLemail = "Post Mark House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Warner Home DVD", LLemail = "Warner House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Music Room", LLemail = "The Old Library", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Blue Planet", LLemail = "96 York Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Dream 107.7FM", LLemail = "Cater House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Moneypenny Agency", LLemail = "The Stables, Westwood House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Artsun", LLemail = "18 Sparkle Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Clyde 2", LLemail = "Clydebank Business Park", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "9PR", LLemail = "65-69 White Lion Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "River Studio's", LLemail = "3 Grange Yard", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Start Entertainments Ltd", LLemail = "3 Warmair House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Vinyl Tap Mail Order Music", LLemail = "1 Minerva Works", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Passion Music", LLemail = "20 Blyth  Rd", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "SuperVision Management", LLemail = "Zeppelin Building", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Lite FM", LLemail = "2nd Floor", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "ISIS Duplicating Company", LLemail = "Sales & Production", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Vanderbeek & Imrie Ltd", LLemail = "15 Marvig", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Glamorgan University", LLemail = "Student Union", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Web User", LLemail = "IPC Media", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Farnborough Recreation Centre", LLemail = "1 Westmead", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Robert Owens/Musical Directions", LLemail = "352A Kilburn Lane", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Magick Eye Records", LLemail = "PO Box 3037", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Alexandra Theatre", LLemail = "Station Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Keda Records", LLemail = "The Sight And Sound Centre", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Independiente Ltd", LLemail = "The Drill Hall", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Shurwood Management", LLemail = "Tote Hill Cottage", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Fury Records", LLemail = "PO Box 52", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Northumbria University", LLemail = "Union Building", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Pop Muzik", LLemail = "Haslemere", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Jonsongs Music", LLemail = "3 Farrers Place", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Hermana PR", LLemail = "Unit 244, Bon Marche Centre", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Sugarcane Music", LLemail = "32 Blackmore Avenue", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "JFM Records", LLemail = "11 Alexander House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Black Market Records", LLemail = "25 D'Arblay Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Float Your Boat Productions", LLemail = "5 Ralphs Retreat", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Creation Management", LLemail = "2 Berkley Grove", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Bryter Music", LLemail = "Marlinspike Hall", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "The Headline Agency", LLemail = "39 Churchfields", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "MP Promotions", LLemail = "13 Greave", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Modo Production Ltd", LLemail = "Ground Floor", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Nomadic Music", LLemail = "Unit 18", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Reverb Records Ltd", LLemail = "Reverb House", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "SIBC", LLemail = "Market Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Marken Time Critical Express", LLemail = "Unit 2", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "102.2 Smooth FM", LLemail = "26-27 Castlereagh Street", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Chesterfield Arts Centre", LLemail = "Chesterfield College", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "The National Indoor Arena", LLemail = "King Edward's Road", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Salisbury City Hall", LLemail = "Malthouse Lane", DatePosted = DateTime.Now.ToString() });
//            context.Post.Add(new PostModel() { User = user, LandLord = "Minder Music", LLemail = "", DatePosted = DateTime.Now.ToString() });


//            ////add to context

//            users.ForEach(x => context.UserProfiles.Add(x));
//            //var errors = context.GetValidationErrors();

//            posts.ForEach(x => context.Post.Add(x));
//            images.ForEach(x => context.Image.Add(x));

//            context.SaveChanges();

//            //errors = context.GetValidationErrors();

//            base.Seed(context);
//        }
//    }
//}
    

