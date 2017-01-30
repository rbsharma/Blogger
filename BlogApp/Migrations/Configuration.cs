namespace BlogApp.Migrations
{
    using Helpers;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<BlogApp.BusinessLayer.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlogApp.BusinessLayer.BlogDbContext";
        }

        protected override void Seed(BlogApp.BusinessLayer.BlogDbContext context)
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Name = "Rajesh",
                    Email = "rajlife2011@gmail.com",
                    Password = Hasher.GetSha256Hash("boungaboyz")
                },
                new User()
                {
                    Name = "Martin",
                    Email = "martin@gmail.com",
                    Password = Hasher.GetSha256Hash("boungaboyz")
                },
                new User()
                {
                    Name = "Alan Sen",
                    Email = "alan@gmail.com",
                    Password = Hasher.GetSha256Hash("password")
                },
                new User()
                {
                    Name = "Rick Martin",
                    Email = "rick@hotmail.com",
                    Password = Hasher.GetSha256Hash("password")
                },
                new User()
                {
                    Name = "Carlos Martin",
                    Email = "carlos@hotmail.com",
                    Password = Hasher.GetSha256Hash("password")
                },
            };

            List<Tag> tags = new List<Tag>()
            {
                new Tag(){Title = "APP" },
                new Tag(){Title = "WEBSITE" },
                new Tag(){Title = "BLOG" },
                new Tag(){Title = "SCIENCE" },
                new Tag(){Title = "SOCIAL" },
                new Tag(){Title = "FACEBOOK" },
                new Tag(){Title = "GOOGLE" },
                new Tag(){Title = "FICTION" },
                new Tag(){Title = "MOVIE" },
                new Tag(){Title = "DIRECTOR" },
                new Tag(){Title = "CARS" },
                new Tag(){Title = "READING" }
            };
            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                    Title = "This is comment number 1 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("raj"))
                },
                 new Comment()
                {
                    Title = "This is comment number 2 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("rick"))
                },
                  new Comment()
                {
                    Title = "This is comment number 3 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("mar"))
                },
                   new Comment()
                {
                    Title = "This is comment number 4 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("ala"))
                },
                    new Comment()
                {
                    Title = "This is comment number 5 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("raj"))
                },
                     new Comment()
                {
                    Title = "This is comment number 6 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("carl"))
                }
            };


            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Title = "A first few tweaks toward a better Blogger",
                    Description = "From New York to Jakarta, Blogger is one of the most popular ways to publish the things you’re passionate about. Still, we’ve heard that there’s more we can do to make the platform a better place to have your unique voice be heard. So we’ll be making some adjustments over time to bring you a faster, easier to use and more beautiful Blogger.To kick things off, we’ve taken a crack at simplifying Blogger’s dashboard so that it’s easier for you to get right to the tools you need.Now, whenever you open Blogger, you’ll be taken right to your blog with the most recent post, putting you one click or tap closer to drafting something new.",
                    PublishedAt = DateTime.Now,
                    User=users.Find(x=>x.Name.ToLower().Contains("raj")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("1") ).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("google") || x.Title.ToLower().Contains("read")).ToList()
                },
                new Post()
                {
                    Title = "More custom template flexibility",
                    Description = "Last May, we added some expressions to our templating language to make it easier for you to customize your blog’s look and feel. These new expressions proved popular with those of you who enjoy advanced blogging tools, so we wanted to offer you even more flexibility.Starting today, we’re introducing a new set of operators, which we’re calling lambda expressions, that allow you to apply rules to whole sets of data (think posts, comments, or labels), rather than just individual instances.Let’s say you wanted to add a flower image to all posts with the label “Flower,” for example.With lambda expressions, simply define a variable name that each item in the set will take, and then refer to the variable name as though it were each item.",
                    PublishedAt = DateTime.Now,
                    User=users.Find(x=>x.Name.ToLower().Contains("ala")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("3") || x.Title.ToLower().Contains("4")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("p") || x.Title.ToLower().Contains("d")).ToList()
                },
                new Post()
                {
                    Title = "Keep your readers interested with the AdSense Guide to Audience Engagement",
                    Description = "Today, information is at our fingertips and we can access it from anywhere on any device. Just a few taps pull up millions of websites all competing for our attention. For bloggers, engaging with your audience has never been more important or more challenging. To help lay the foundation to a winning engagement strategy, the AdSense team created the AdSense Guide to Audience Engagement.",
                    PublishedAt = DateTime.Now,
                    User=users.Find(x=>x.Name.ToLower().Contains("raj")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("2") || x.Title.ToLower().Contains("6")|| x.Title.ToLower().Contains("5")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("f") || x.Title.ToLower().Contains("d")).ToList()
                },
                new Post()
                {
                    Title = "Bringing HTTPS to all blogspot domain blogs",
                    Description = "HTTPS is fundamental to internet security; it protects the integrity and confidentiality of data sent between websites and visitors' browsers. Last September, we began rolling out HTTPS support for blogspot domain blogs so you could try it out. Today, we’re launching another milestone: an HTTPS version for every blogspot domain blog. With this change, visitors can access any blogspot domain blog over an encrypted channel.",
                    PublishedAt = DateTime.Now,
                    User=users.Find(x=>x.Name.ToLower().Contains("rick")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("1") ).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("o") || x.Title.ToLower().Contains("s")).ToList()
                },
                new Post()
                {
                    Title = "An update to the Blogger post editor to help with mixed content",
                    Description = "Back in September, we announced that HTTPS support was coming to blogspot.com, making it possible for you to encrypt connections to your blog; since then, many of you have enabled HTTPS for your blogs. In some cases, not all of your blog’s functionality has worked over HTTPS due to mixed content errors often stemming from your template, gadgets, or blog post content. To help spot and fix some of these errors, we're releasing a mixed content warning tool that alerts you to possible mixed content issues in your posts, and gives you the option to fix them automatically before saving.",
                    PublishedAt = DateTime.Now,
                    User=users.Find(x=>x.Name.ToLower().Contains("carl")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("3") || x.Title.ToLower().Contains("4")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("s") || x.Title.ToLower().Contains("d")).ToList()
                },
                new Post()
                {
                    Title = "Best practices for reviewing products you've received for free.",
                    Description = "Bloggers should use the nofollow tag on all such links because these links didn’t come about organically (i.e., the links wouldn’t exist if the company hadn’t offered to provide a free good or service in exchange for a link). Companies, or the marketing firms they’re working with, can do their part by reminding bloggers to use nofollow on these links.",
                    PublishedAt = DateTime.Now,
                    User=users.Find(x=>x.Name.ToLower().Contains("raj")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("2") || x.Title.ToLower().Contains("6")|| x.Title.ToLower().Contains("5")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("a") || x.Title.ToLower().Contains("v")).ToList()
                },
                new Post()
                {
                    Title = "An update on Google Friend Connect",
                    Description = "In 2011, we announced the retirement of Google Friend Connect for all non-Blogger sites. We made an exception for Blogger to give readers an easy way to follow blogs using a variety of accounts. Yet over time, we’ve seen that most people sign into Friend Connect with a Google Account. So, in an effort to streamline, in the next few weeks we’ll be making some changes that will eventually require readers to have a Google Account to sign into Friend Connect and follow blogs.  As part of this plan, starting the week of January 11, we’ll remove the ability for people with Twitter, Yahoo, Orkut or other OpenId providers to sign in to Google Friend Connect and follow blogs.At the same time, we’ll remove non - Google Account profiles so you may see a decrease in your blog follower count.",
                    PublishedAt = DateTime.Now,
                    User=users.Find(x=>x.Name.ToLower().Contains("alan")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("1") ).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("i") || x.Title.ToLower().Contains("v")).ToList()
                }
            };
            try
            {
                users.ForEach(x => context.Users.AddOrUpdate(s => s.Name, x));
                context.SaveChanges();
                comments.ForEach(x => context.Comments.AddOrUpdate(s => s.Title, x));
                context.SaveChanges();
                tags.ForEach(x => context.Tags.AddOrUpdate(s => s.Title, x));
                context.SaveChanges();
                posts.ForEach(x => context.Posts.AddOrUpdate(s => s.Title, x));
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //Write to file
                System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
                throw;

                // Showing it on screen
                throw new Exception(string.Join(",", outputLines.ToArray()));
            }

            base.Seed(context);
        }
    }
}
