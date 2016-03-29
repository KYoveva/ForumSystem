namespace ForumSystem.Data.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ForumPostsSeeder : IDataSeeder
    {
        public static Random Rand = new Random();

        public void Seed(ForumSystemDbContext context)
        {
            string authorUserName = "krisi@abv.bg";

            var isAuthorSeeded = context.Users.Any(u => u.UserName == authorUserName);

            if (!isAuthorSeeded)
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                userManager.Create(new User() { UserName = authorUserName, Email = authorUserName }, "123456");

                var author = context.Users.FirstOrDefault(u => u.UserName == authorUserName);

                var categories = new List<ForumPostCategory>
                {
                    new ForumPostCategory() { Name = "C#" , Description = "Here you can ask questions and find answers about programming with C#."},
                    new ForumPostCategory() { Name = "JavaScript", Description = "Here you can ask questions and find answers about programming with JavaScript." },
                    new ForumPostCategory() { Name = "Java", Description = "Here you can ask questions and find answers about programming with Java." },
                    new ForumPostCategory() { Name = "SQL", Description = "Here you can ask questions and find answers about programming with SQL." },
                    new ForumPostCategory() { Name = "HTML", Description = "Here you can ask questions and find answers about programming with HTML." },
                    new ForumPostCategory() { Name = "CSS", Description = "Here you can ask questions and find answers about programming with CSS." }
                };

                foreach (var item in categories)
                {
                    context.ForumPostCategories.Add(item);
                }

                var posts = new List<ForumPost>
                {
                    new ForumPost() {
                        Title = "File Upload ASP.NET MVC 3.0",
                        Content = "I want to upload file in asp.net-mvc. How can I upload the file using html input file control?",
                        AuthorId = author.Id,
                        Category = categories[0],
                        DateCreated = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                    new ForumPost() {
                        Title = "Aren't promises just callbacks?",
                        Content = "I've been developing JavaScript for a few years and I don't understand the fuss about promises at all.",
                        AuthorId = author.Id,
                        Category = categories[1],
                        DateCreated = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                    new ForumPost() {
                        Title = "How to correctly add jar library?",
                        Content = "I have a programm uses JDBC. In intellij Idea programm run correctly, but in cmd after i compile class and run it i have Exception.What's the problem? I'm add source code by requestion.",
                        AuthorId = author.Id,
                        Category = categories[2],
                        DateCreated = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                    new ForumPost() {
                        Title = "SQL Logic: Finding Non-Duplicates with Similar Rows",
                        Content = "I'll do my best to summarize what I am having trouble with. I never used much SQL until recently.Currently I am using SQL Server 2012 at work and have been tasked with trying to find oddities in SQL tables. Specifically, the tables contain similar information regarding servers.Kind of meta, I know. So they each share a column called \"DB_NAME\".After that, there are no similar columns.So I need to compare Table A and Table B and produce a list of records (servers)where a server is NOT listed in BOTH Table A and B.Additionally, this query is being ran against an exception list.I'm not 100% sure of the logic to best handle this. And while I would love to get something \"extremely efficient\", I am more-so looking at something that just plain works at the time being.",
                        AuthorId = author.Id,
                        Category = categories[3],
                        DateCreated = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                    new ForumPost() {
                        Title = "How can I copy HTML in <pre> tags to Libreoffice without losing empty lines?",
                        Content = "I want to copy formatted source code from my IDE to LibreOffice, but in the pasted code all empty lines are lost. The problem can be boiled down to this: If I paste HTML in < pre > tags to LibreOffice, multiple < br > tags have the same effect as one.",
                        AuthorId = author.Id,
                        Category = categories[4],
                        DateCreated = DateTime.Now.AddDays(Rand.Next(-8, 0))},
                    new ForumPost() {
                        Title = "Select element but not certain inner elements in CSS",
                        Content = "Is it possible to write a simple CSS style to color the words Example and here. to red but leave the text to default color?",
                        AuthorId = author.Id,
                        Category = categories[5],
                        DateCreated = DateTime.Now.AddDays(Rand.Next(-8, 0))},

                };

                foreach (var item in posts)
                {
                    context.ForumPosts.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
