using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogApp.Models;
using System.Data.Entity;
using BlogApp.Helpers;

namespace BlogApp.BusinessLayer
{
    public class DbSeeder : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Name = "FIRSTUSER",
                    Email = "FIRSTUSER@FIRSTUSER.COM",
                    Password = Hasher.GetSha256Hash("one")
                },
                new User()
                {
                    Name = "SECONDUSER",
                    Email = "SECONDUSER@SECONDUSER.COM",
                    Password = Hasher.GetSha256Hash("two")
                },
                new User()
                {
                    Name = "THIRDUSER",
                    Email = "THIRDTUSER@THIRDUSER.COM",
                    Password = Hasher.GetSha256Hash("three")
                },
                new User()
                {
                    Name = "FOURTHUSER",
                    Email = "FOURTHUSER@FOURTHUSER.COM",
                    Password = Hasher.GetSha256Hash("four")
                },
            };

            List<Tag> tags = new List<Tag>()
            {
                new Tag(){Title = "APP" },
                new Tag(){Title = "WEBSIT" },
                new Tag(){Title = "BLOG" },
                new Tag(){Title = "SCIENCE" },
                new Tag(){Title = "SOCIAL" },
                new Tag(){Title = "FACEBOOK" },
                new Tag(){Title = "GOOGLE" },
                new Tag(){Title = "FICTION" },
                new Tag(){Title = "MOVIE" },
                new Tag(){Title = "DIRECTOR" },
                new Tag(){Title = "AVERYLONGNAMEDTAG" },
                new Tag(){Title = "SOMETHING" }
            };
            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                    Title = "This is comment number 1 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("first"))
                },
                 new Comment()
                {
                    Title = "This is comment number 2 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("second"))
                },
                  new Comment()
                {
                    Title = "This is comment number 3 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("fourth"))
                },
                   new Comment()
                {
                    Title = "This is comment number 4 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("second"))
                },
                    new Comment()
                {
                    Title = "This is comment number 5 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("second"))
                },
                     new Comment()
                {
                    Title = "This is comment number 6 and it is a long comment", PublishedAt = DateTime.Now, User=users.Find(x=>x.Name.ToLower().Contains("third"))
                }
            };


            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Title = "non sodales odio arcu eu enim. Suspendisse laoreet, nisi vitae cursus condimentum, mauris magna ornare ante, placerat varius lacus sapien at nisl. Aliquam erat volutpat. Praesent pellentesque ligula et leo accumsan elementum. Aliquam pretium porta ultrices.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce malesuada eleifend est eu pulvinar. Pellentesque a quam non mauris tincidunt pharetra. Donec sagittis elementum ligula. Morbi sit amet dignissim est. Integer dictum viverra sodales. Donec scelerisque dapibus sapien sed pharetra. Sed vitae purus malesuada odio ultrices dictum in vitae tellus. Nunc dictum, urna ac sollicitudin ullamcorper, orci enim tempus purus",
                    PublishedAt = DateTime.Now,
                    User = users.Find(x=>x.Name.ToLower().Contains("first")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("1") ).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("o") || x.Title.ToLower().Contains("g")).ToList()
                },
                new Post()
                {
                    Title = "vehicula dapibus non vel purus. Vestibulum iaculis imperdiet tincidunt. Cras mauris dolor, sodales ac auctor non, ullamcorper in neque. Proin non mi a",
                    Description = "Nunc cursus neque nibh. Sed sed arcu a diam ultrices lobortis in sit amet enim. Nullam non enim a nulla bibendum imperdiet. Phasellus ullamcorper rhoncus arcu a consectetur. Vestibulum at laoreet justo. Praesent varius diam a interdum mollis. Morbi a nunc id justo sodales varius. Integer dignissim euismod dolor id sagittis. Nulla lacinia eros lacus, vel condimentum sem condimentum tempus. Fusce id ligula sed sem",
                    PublishedAt = DateTime.Now,
                    User = users.Find(x=>x.Name.ToLower().Contains("second")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("3") || x.Title.ToLower().Contains("4")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("p") || x.Title.ToLower().Contains("d")).ToList()
                },
                new Post()
                {
                    Title = "Morbi pharetra lectus orci. Vivamus nec hendrerit sem. Vestibulum ut sapien vitae felis volutpat imperdiet. Nulla dignissim mattis ex feugiat scelerisque.",
                    Description = "Donec interdum lectus lectus, a placerat quam ultricies eget. Sed in urna in urna porta commodo. Etiam viverra ipsum non malesuada tincidunt. Sed venenatis est augue, ac consequat mauris lobortis et. Ut eu lectus et ipsum venenatis mollis non dapibus est. Donec pellentesque odio sed sollicitudin laoreet. ",
                    PublishedAt = DateTime.Now,
                    User = users.Find(x=>x.Name.ToLower().Contains("third")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("2") || x.Title.ToLower().Contains("6")|| x.Title.ToLower().Contains("5")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("f") || x.Title.ToLower().Contains("d")).ToList()
                },
                new Post()
                {
                    Title = "non sodales odio arcu eu enim. Suspendisse laoreet, nisi vitae cursus condimentum, mauris magna ornare ante, placerat varius lacus sapien at nisl. Aliquam erat volutpat. Praesent pellentesque ligula et leo accumsan elementum. Aliquam pretium porta ultrices.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce malesuada eleifend est eu pulvinar. Pellentesque a quam non mauris tincidunt pharetra. Donec sagittis elementum ligula. Morbi sit amet dignissim est. Integer dictum viverra sodales. Donec scelerisque dapibus sapien sed pharetra. Sed vitae purus malesuada odio ultrices dictum in vitae tellus. Nunc dictum, urna ac sollicitudin ullamcorper, orci enim tempus purus",
                    PublishedAt = DateTime.Now,
                    User = users.Find(x=>x.Name.ToLower().Contains("fourth")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("1") ).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("o") || x.Title.ToLower().Contains("s")).ToList()
                },
                new Post()
                {
                    Title = "vehicula dapibus non vel purus. Vestibulum iaculis imperdiet tincidunt. Cras mauris dolor, sodales ac auctor non, ullamcorper in neque. Proin non mi a",
                    Description = "Nunc cursus neque nibh. Sed sed arcu a diam ultrices lobortis in sit amet enim. Nullam non enim a nulla bibendum imperdiet. Phasellus ullamcorper rhoncus arcu a consectetur. Vestibulum at laoreet justo. Praesent varius diam a interdum mollis. Morbi a nunc id justo sodales varius. Integer dignissim euismod dolor id sagittis. Nulla lacinia eros lacus, vel condimentum sem condimentum tempus. Fusce id ligula sed sem",
                    PublishedAt = DateTime.Now,
                    User = users.Find(x=>x.Name.ToLower().Contains("second")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("3") || x.Title.ToLower().Contains("4")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("s") || x.Title.ToLower().Contains("d")).ToList()
                },
                new Post()
                {
                    Title = "Morbi pharetra lectus orci. Vivamus nec hendrerit sem. Vestibulum ut sapien vitae felis volutpat imperdiet. Nulla dignissim mattis ex feugiat scelerisque.",
                    Description = "Donec interdum lectus lectus, a placerat quam ultricies eget. Sed in urna in urna porta commodo. Etiam viverra ipsum non malesuada tincidunt. Sed venenatis est augue, ac consequat mauris lobortis et. Ut eu lectus et ipsum venenatis mollis non dapibus est. Donec pellentesque odio sed sollicitudin laoreet. ",
                    PublishedAt = DateTime.Now,
                    User = users.Find(x=>x.Name.ToLower().Contains("third")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("2") || x.Title.ToLower().Contains("6")|| x.Title.ToLower().Contains("5")).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("a") || x.Title.ToLower().Contains("v")).ToList()
                },
                new Post()
                {
                    Title = "non sodales odio arcu eu enim. Suspendisse laoreet, nisi vitae cursus condimentum, mauris magna ornare ante, placerat varius lacus sapien at nisl. Aliquam erat volutpat. Praesent pellentesque ligula et leo accumsan elementum. Aliquam pretium porta ultrices.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce malesuada eleifend est eu pulvinar. Pellentesque a quam non mauris tincidunt pharetra. Donec sagittis elementum ligula. Morbi sit amet dignissim est. Integer dictum viverra sodales. Donec scelerisque dapibus sapien sed pharetra. Sed vitae purus malesuada odio ultrices dictum in vitae tellus. Nunc dictum, urna ac sollicitudin ullamcorper, orci enim tempus purus",
                    PublishedAt = DateTime.Now,
                    User = users.Find(x=>x.Name.ToLower().Contains("first")),
                    Comments = comments.Where(x=>x.Title.ToLower().Contains("1") ).ToList(),
                    Tags = tags.Where(x=>x.Title.ToLower().Contains("i") || x.Title.ToLower().Contains("v")).ToList()
                }
            };



            try
            {
                users.ForEach(x => context.Users.Add(x));
                context.SaveChanges();
                comments.ForEach(x => context.Comments.Add(x));
                context.SaveChanges();
                tags.ForEach(x => context.Tags.Add(x));
                context.SaveChanges();
                posts.ForEach(x => context.Posts.Add(x));
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