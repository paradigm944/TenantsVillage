using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TV.web.Models.DataRepository
{
    public class DataRepository

{

       
        public static IList<PostModel> postData = new List<PostModel>();

      
        public static IList<PostModel> GetPosts()
        {
            var ctx = ObjectFactory.GetInstance<TVContext>();

            postData = ctx.Post.Select(p => p).Where(p => p.IsDeleted == false).Where(m => m.IsCompleted == 1).ToList<PostModel>();
            
            //if (postData != null)
            //{
                
            //    postData.Add(new CreatePostModel() { LandLord = "Emkay Entertainments", LLemail = "Nobel House, Regent Centre", Post = "ivghcyuyxutxut" });
            //    postData.Add(new CreatePostModel() { LandLord = "The Empire", LLemail = "Milton Keynes Leisure Plaza", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Asadul Ltd", LLemail = "Hophouse", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Gargamel ltd", LLemail = "", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Ashley Mark Publishing Company", LLemail = "1-2 Vance Court", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "MuchMoreMusic Studios", LLemail = "Unit 29", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Victoria Music Ltd", LLemail = "Unit 215", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Abacus Agent", LLemail = "Regent Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Atomic", LLemail = "133 Longacre", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Pyramid Posters", LLemail = "The Works", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Kingston Smith Financial Services Ltd", LLemail = "105 St Peter's Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Garrett Axford PR", LLemail = "Harbour House", DatePosted = DateTime.Now.ToString()});
            //    postData.Add(new CreatePostModel() { LandLord = "Derek Boulton Management", LLemail = "76 Carlisle Mansions", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Total Concept Management (TCM)", LLemail = "PO Box 128", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Billy Russell Management", LLemail = "Binny Estate", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Stage Audio Services", LLemail = "Unit 2", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Windsong International", LLemail = "Heather Court", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Vivante Music Ltd", LLemail = "32 The Netherlands", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Way to Blue", LLemail = "First Floor", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Glasgow City Halls", LLemail = "32 Albion Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "The List", LLemail = "14 High St", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Wilkinson Turner King", LLemail = "10A London Road", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "GSC Solicitors", LLemail = "31-32 Ely Place", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Vanessa Music Co", LLemail = "35 Tower Way", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Regent Records", LLemail = "PO Box 528", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "BBC Radio Lancashire", LLemail = "20-26 Darwen St", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "The Citadel Arts Centre", LLemail = "Waterloo Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Villa Audio Ltd", LLemail = "Baileys Yard", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Astra travel", LLemail = "", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Idle Eyes Printshop", LLemail = "81 Sheen Court", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Miggins Music (UK)", LLemail = "33 Mandarin Place", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Magic 999", LLemail = "St Paul's Square", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Delga Group", LLemail = "Seaplane House, Riverside Est.", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Zane Music", LLemail = "162 Castle Hill", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Universal Music Operations", LLemail = "Chippenham Drive", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Gotham Records", LLemail = "PO Box 6003", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Timbuktu Music Ltd", LLemail = "99C Talbot Road", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Online Music", LLemail = "Unit 18, Croydon House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Irish Music Magazine", LLemail = "11 Clare St", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Savoy Records", LLemail = "PO Box 271", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Temple Studios", LLemail = "97A Kenilworth Road", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Gravity Shack Studio", LLemail = "Unit 3 ", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Dovehouse Records", LLemail = "Crabtree Cottage", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Citysounds Ltd", LLemail = "5 Kirby Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Revolver Music Publishing", LLemail = "152 Goldthorn Hill", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Jug Of Ale", LLemail = "43 Alcester Road", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Isles FM 103", LLemail = "PO Box 333", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Headscope", LLemail = "Headrest", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Universal Music Ireland", LLemail = "9 Whitefriars", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Zander Exports", LLemail = "34 Sapcote Trading Centre", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Midem (UK)", LLemail = "Walmar House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "La Rocka Studios", LLemail = "Post Mark House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Warner Home DVD", LLemail = "Warner House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Music Room", LLemail = "The Old Library", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Blue Planet", LLemail = "96 York Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Dream 107.7FM", LLemail = "Cater House", DatePosted = DateTime.Now.ToString()});
            //    postData.Add(new CreatePostModel() { LandLord = "Moneypenny Agency", LLemail = "The Stables, Westwood House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Artsun", LLemail = "18 Sparkle Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Clyde 2", LLemail = "Clydebank Business Park", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "9PR", LLemail = "65-69 White Lion Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "River Studio's", LLemail = "3 Grange Yard", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Start Entertainments Ltd", LLemail = "3 Warmair House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Vinyl Tap Mail Order Music", LLemail = "1 Minerva Works", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Passion Music", LLemail = "20 Blyth  Rd", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "SuperVision Management", LLemail = "Zeppelin Building", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Lite FM", LLemail = "2nd Floor", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "ISIS Duplicating Company", LLemail = "Sales & Production", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Vanderbeek & Imrie Ltd", LLemail = "15 Marvig", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Glamorgan University", LLemail = "Student Union", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Web User", LLemail = "IPC Media", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Farnborough Recreation Centre", LLemail = "1 Westmead", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Robert Owens/Musical Directions", LLemail = "352A Kilburn Lane", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Magick Eye Records", LLemail = "PO Box 3037", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Alexandra Theatre", LLemail = "Station Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Keda Records", LLemail = "The Sight And Sound Centre", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Independiente Ltd", LLemail = "The Drill Hall", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Shurwood Management", LLemail = "Tote Hill Cottage", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Fury Records", LLemail = "PO Box 52", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Northumbria University", LLemail = "Union Building", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Pop Muzik", LLemail = "Haslemere", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Jonsongs Music", LLemail = "3 Farrers Place", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Hermana PR", LLemail = "Unit 244, Bon Marche Centre", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Sugarcane Music", LLemail = "32 Blackmore Avenue", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "JFM Records", LLemail = "11 Alexander House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Black Market Records", LLemail = "25 D'Arblay Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Float Your Boat Productions", LLemail = "5 Ralphs Retreat", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Creation Management", LLemail = "2 Berkley Grove", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Bryter Music", LLemail = "Marlinspike Hall", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "The Headline Agency", LLemail = "39 Churchfields", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "MP Promotions", LLemail = "13 Greave", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Modo Production Ltd", LLemail = "Ground Floor", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Nomadic Music", LLemail = "Unit 18", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Reverb Records Ltd", LLemail = "Reverb House", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "SIBC", LLemail = "Market Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Marken Time Critical Express", LLemail = "Unit 2", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "102.2 Smooth FM", LLemail = "26-27 Castlereagh Street", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Chesterfield Arts Centre", LLemail = "Chesterfield College", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "The National Indoor Arena", LLemail = "King Edward's Road", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Salisbury City Hall", LLemail = "Malthouse Lane", DatePosted = DateTime.Now.ToString() });
            //    postData.Add(new CreatePostModel() { LandLord = "Minder Music", LLemail = "", DatePosted = DateTime.Now.ToString() });
            //}
            return postData;
        }

        public static IList<PostModel> GetUserPosts()
        {
            var ctx = ObjectFactory.GetInstance<TVContext>();

            postData = ctx.Post.Select(p => p).Where(p => p.User.UserName == HttpContext.Current.User.Identity.Name && p.IsDeleted == false).ToList<PostModel>();
            return postData;
        }

        public static IList<Company> CompanyData = null;

        /// <summary>
        /// Method that returns all companies used in this example
        /// </summary>
        /// <returns>List of companies</returns>
        public static IList<Company> GetCompanies()
        {
            if (CompanyData == null)
            {
                CompanyData = new List<Company>();
                CompanyData.Add(new Company() { Name = "Emkay Entertainments", Address = "Nobel House, Regent Centre", Town = "Lothian" });
                CompanyData.Add(new Company() { Name = "The Empire", Address = "Milton Keynes Leisure Plaza", Town = "Buckinghamshire" });
                CompanyData.Add(new Company() { Name = "Asadul Ltd", Address = "Hophouse", Town = "Essex" });
                CompanyData.Add(new Company() { Name = "Gargamel ltd", Address = "", Town = "" });
                CompanyData.Add(new Company() { Name = "Ashley Mark Publishing Company", Address = "1-2 Vance Court", Town = "Tyne & Wear" });
                CompanyData.Add(new Company() { Name = "MuchMoreMusic Studios", Address = "Unit 29", Town = "London" });
                CompanyData.Add(new Company() { Name = "Victoria Music Ltd", Address = "Unit 215", Town = "London" });
                CompanyData.Add(new Company() { Name = "Abacus Agent", Address = "Regent Street", Town = "London" });
                CompanyData.Add(new Company() { Name = "Atomic", Address = "133 Longacre", Town = "London" });
                CompanyData.Add(new Company() { Name = "Pyramid Posters", Address = "The Works", Town = "Leicester" });
                CompanyData.Add(new Company() { Name = "Kingston Smith Financial Services Ltd", Address = "105 St Peter's Street", Town = "Herts" });
                CompanyData.Add(new Company() { Name = "Garrett Axford PR", Address = "Harbour House", Town = "West Sussex" });
                CompanyData.Add(new Company() { Name = "Derek Boulton Management", Address = "76 Carlisle Mansions", Town = "London" });
                CompanyData.Add(new Company() { Name = "Total Concept Management (TCM)", Address = "PO Box 128", Town = "West Yorks" });
                CompanyData.Add(new Company() { Name = "Billy Russell Management", Address = "Binny Estate", Town = "Edinburgh" });
                CompanyData.Add(new Company() { Name = "Stage Audio Services", Address = "Unit 2", Town = "Stourbridge" });
                CompanyData.Add(new Company() { Name = "Windsong International", Address = "Heather Court", Town = "Kent" });
                CompanyData.Add(new Company() { Name = "Vivante Music Ltd", Address = "32 The Netherlands", Town = "Surrey" });
                CompanyData.Add(new Company() { Name = "Way to Blue", Address = "First Floor", Town = "London" });
                CompanyData.Add(new Company() { Name = "Glasgow City Halls", Address = "32 Albion Street", Town = "Lanarkshire" });
                CompanyData.Add(new Company() { Name = "The List", Address = "14 High St", Town = "Edinburgh" });
                CompanyData.Add(new Company() { Name = "Wilkinson Turner King", Address = "10A London Road", Town = "Cheshire" });
                CompanyData.Add(new Company() { Name = "GSC Solicitors", Address = "31-32 Ely Place", Town = "London" });
                CompanyData.Add(new Company() { Name = "Vanessa Music Co", Address = "35 Tower Way", Town = "Devon" });
                CompanyData.Add(new Company() { Name = "Regent Records", Address = "PO Box 528", Town = "West Midlands" });
                CompanyData.Add(new Company() { Name = "BBC Radio Lancashire", Address = "20-26 Darwen St", Town = "Blackburn" });
                CompanyData.Add(new Company() { Name = "The Citadel Arts Centre", Address = "Waterloo Street", Town = "Merseyside" });
                CompanyData.Add(new Company() { Name = "Villa Audio Ltd", Address = "Baileys Yard", Town = "Essex" });
                CompanyData.Add(new Company() { Name = "Astra travel", Address = "", Town = "" });
                CompanyData.Add(new Company() { Name = "Idle Eyes Printshop", Address = "81 Sheen Court", Town = "Surrey" });
                CompanyData.Add(new Company() { Name = "Miggins Music (UK)", Address = "33 Mandarin Place", Town = "Oxon" });
                CompanyData.Add(new Company() { Name = "Magic 999", Address = "St Paul's Square", Town = "Lancashire" });
                CompanyData.Add(new Company() { Name = "Delga Group", Address = "Seaplane House, Riverside Est.", Town = "Kent" });
                CompanyData.Add(new Company() { Name = "Zane Music", Address = "162 Castle Hill", Town = "Berkshire" });
                CompanyData.Add(new Company() { Name = "Universal Music Operations", Address = "Chippenham Drive", Town = "Milton Keynes" });
                CompanyData.Add(new Company() { Name = "Gotham Records", Address = "PO Box 6003", Town = "Birmingham" });
                CompanyData.Add(new Company() { Name = "Timbuktu Music Ltd", Address = "99C Talbot Road", Town = "London" });
                CompanyData.Add(new Company() { Name = "Online Music", Address = "Unit 18, Croydon House", Town = "Surrey" });
                CompanyData.Add(new Company() { Name = "Irish Music Magazine", Address = "11 Clare St", Town = "Ireland" });
                CompanyData.Add(new Company() { Name = "Savoy Records", Address = "PO Box 271", Town = "Surrey" });
                CompanyData.Add(new Company() { Name = "Temple Studios", Address = "97A Kenilworth Road", Town = "Middlesex" });
                CompanyData.Add(new Company() { Name = "Gravity Shack Studio", Address = "Unit 3 ", Town = "London" });
                CompanyData.Add(new Company() { Name = "Dovehouse Records", Address = "Crabtree Cottage", Town = "Oxon" });
                CompanyData.Add(new Company() { Name = "Citysounds Ltd", Address = "5 Kirby Street", Town = "London" });
                CompanyData.Add(new Company() { Name = "Revolver Music Publishing", Address = "152 Goldthorn Hill", Town = "West Midlands" });
                CompanyData.Add(new Company() { Name = "Jug Of Ale", Address = "43 Alcester Road", Town = "West Midlands" });
                CompanyData.Add(new Company() { Name = "Isles FM 103", Address = "PO Box 333", Town = "Western Isles" });
                CompanyData.Add(new Company() { Name = "Headscope", Address = "Headrest", Town = "East Sussex" });
                CompanyData.Add(new Company() { Name = "Universal Music Ireland", Address = "9 Whitefriars", Town = "Ireland" });
                CompanyData.Add(new Company() { Name = "Zander Exports", Address = "34 Sapcote Trading Centre", Town = "London" });
                CompanyData.Add(new Company() { Name = "Midem (UK)", Address = "Walmar House", Town = "London" });
                CompanyData.Add(new Company() { Name = "La Rocka Studios", Address = "Post Mark House", Town = "London" });
                CompanyData.Add(new Company() { Name = "Warner Home DVD", Address = "Warner House", Town = "London" });
                CompanyData.Add(new Company() { Name = "Music Room", Address = "The Old Library", Town = "London" });
                CompanyData.Add(new Company() { Name = "Blue Planet", Address = "96 York Street", Town = "London" });
                CompanyData.Add(new Company() { Name = "Dream 107.7FM", Address = "Cater House", Town = "Chelmsford" });
                CompanyData.Add(new Company() { Name = "Moneypenny Agency", Address = "The Stables, Westwood House", Town = "East Yorks" });
                CompanyData.Add(new Company() { Name = "Artsun", Address = "18 Sparkle Street", Town = "Manchester" });
                CompanyData.Add(new Company() { Name = "Clyde 2", Address = "Clydebank Business Park", Town = "Glasgow" });
                CompanyData.Add(new Company() { Name = "9PR", Address = "65-69 White Lion Street", Town = "London" });
                CompanyData.Add(new Company() { Name = "River Studio's", Address = "3 Grange Yard", Town = "London" });
                CompanyData.Add(new Company() { Name = "Start Entertainments Ltd", Address = "3 Warmair House", Town = "Middx" });
                CompanyData.Add(new Company() { Name = "Vinyl Tap Mail Order Music", Address = "1 Minerva Works", Town = "West Yorkshire" });
                CompanyData.Add(new Company() { Name = "Passion Music", Address = "20 Blyth  Rd", Town = "Middlesex" });
                CompanyData.Add(new Company() { Name = "SuperVision Management", Address = "Zeppelin Building", Town = "London" });
                CompanyData.Add(new Company() { Name = "Lite FM", Address = "2nd Floor", Town = "Peterborough" });
                CompanyData.Add(new Company() { Name = "ISIS Duplicating Company", Address = "Sales & Production", Town = "Merseyside" });
                CompanyData.Add(new Company() { Name = "Vanderbeek & Imrie Ltd", Address = "15 Marvig", Town = "Scotland" });
                CompanyData.Add(new Company() { Name = "Glamorgan University", Address = "Student Union", Town = "Mid Glamorgan" });
                CompanyData.Add(new Company() { Name = "Web User", Address = "IPC Media", Town = "London " });
                CompanyData.Add(new Company() { Name = "Farnborough Recreation Centre", Address = "1 Westmead", Town = "Hampshire" });
                CompanyData.Add(new Company() { Name = "Robert Owens/Musical Directions", Address = "352A Kilburn Lane", Town = "London" });
                CompanyData.Add(new Company() { Name = "Magick Eye Records", Address = "PO Box 3037", Town = "Berks" });
                CompanyData.Add(new Company() { Name = "Alexandra Theatre", Address = "Station Street", Town = "West Midlands" });
                CompanyData.Add(new Company() { Name = "Keda Records", Address = "The Sight And Sound Centre", Town = "Middlesex" });
                CompanyData.Add(new Company() { Name = "Independiente Ltd", Address = "The Drill Hall", Town = "London" });
                CompanyData.Add(new Company() { Name = "Shurwood Management", Address = "Tote Hill Cottage", Town = "West Sussex" });
                CompanyData.Add(new Company() { Name = "Fury Records", Address = "PO Box 52", Town = "Kent" });
                CompanyData.Add(new Company() { Name = "Northumbria University", Address = "Union Building", Town = "Newcastle upon Tyne" });
                CompanyData.Add(new Company() { Name = "Pop Muzik", Address = "Haslemere", Town = "W. Sussex" });
                CompanyData.Add(new Company() { Name = "Jonsongs Music", Address = "3 Farrers Place", Town = "Surrey" });
                CompanyData.Add(new Company() { Name = "Hermana PR", Address = "Unit 244, Bon Marche Centre", Town = "London" });
                CompanyData.Add(new Company() { Name = "Sugarcane Music", Address = "32 Blackmore Avenue", Town = "Middlesex" });
                CompanyData.Add(new Company() { Name = "JFM Records", Address = "11 Alexander House", Town = "London" });
                CompanyData.Add(new Company() { Name = "Black Market Records", Address = "25 D'Arblay Street", Town = "London" });
                CompanyData.Add(new Company() { Name = "Float Your Boat Productions", Address = "5 Ralphs Retreat", Town = "Bucks" });
                CompanyData.Add(new Company() { Name = "Creation Management", Address = "2 Berkley Grove", Town = "London" });
                CompanyData.Add(new Company() { Name = "Bryter Music", Address = "Marlinspike Hall", Town = "Suffolk" });
                CompanyData.Add(new Company() { Name = "The Headline Agency", Address = "39 Churchfields", Town = "Ireland" });
                CompanyData.Add(new Company() { Name = "MP Promotions", Address = "13 Greave", Town = "Cheshire" });
                CompanyData.Add(new Company() { Name = "Modo Production Ltd", Address = "Ground Floor", Town = "London" });
                CompanyData.Add(new Company() { Name = "Nomadic Music", Address = "Unit 18", Town = "London" });
                CompanyData.Add(new Company() { Name = "Reverb Records Ltd", Address = "Reverb House", Town = "London" });
                CompanyData.Add(new Company() { Name = "SIBC", Address = "Market Street", Town = "Lerwick" });
                CompanyData.Add(new Company() { Name = "Marken Time Critical Express", Address = "Unit 2", Town = "Isleworth" });
                CompanyData.Add(new Company() { Name = "102.2 Smooth FM", Address = "26-27 Castlereagh Street", Town = "London" });
                CompanyData.Add(new Company() { Name = "Chesterfield Arts Centre", Address = "Chesterfield College", Town = "Derbyshire" });
                CompanyData.Add(new Company() { Name = "The National Indoor Arena", Address = "King Edward's Road", Town = "West Midlands" });
                CompanyData.Add(new Company() { Name = "Salisbury City Hall", Address = "Malthouse Lane", Town = "Wiltshire" });
                CompanyData.Add(new Company() { Name = "Minder Music", Address = "", Town = "" });
            }
            return CompanyData;
        }
    }
}
    

