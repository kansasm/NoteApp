using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteApp.Models;

namespace NoteApp.Repo
{
    public static class DbInitializer
    {
        public static void Initialize(NoteContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var user = new User[]
            {
            new User{Email="Test@gmail.com",Name="Test Name",CreatedOn=DateTime.Parse("2018-04-29")},
            new User{Email="Bob@gmail.com",Name="Bob Barker",CreatedOn=DateTime.Parse("2018-04-29")},
            new User{Email="Cruise@gmail.com",Name="Tom Cruise",CreatedOn=DateTime.Parse("2018-04-29")},
            new User{Email="Sam@gmail.com",Name="Sam Jackson",CreatedOn=DateTime.Parse("2018-04-29")}
            };
            foreach (User u in user)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
            new Category{Name="Internet Programming"},
            new Category{Name="Calculus"},
            new Category{Name="Database"},
            new Category{Name="Network Sec"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var notes = new Note[]
            {
                new Note{Title="CSC 435 Week 1",Notes="Test",CreatedOn=DateTime.Parse("2018-04-28"),CategoryId=1,UserId=1,IsDeleted=false },
                new Note{Title="CSC 435 Week 2",Notes="Test 2",CreatedOn=DateTime.Parse("2018-04-28"),CategoryId=2,UserId=2,IsDeleted=false },
                new Note{Title="CSC 435 Week 3",Notes="Test 3",CreatedOn=DateTime.Parse("2018-04-28"),CategoryId=3,UserId=3,IsDeleted=false }
            };
            foreach (Note n in notes)
            {
                context.Notes.Add(n);
            }
            context.SaveChanges();
        }
    }
}