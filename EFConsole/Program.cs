﻿namespace EFConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        using (AppContext db = new())
        {
            var user1 = new User { Name = "Arthur", Role = "Admin" };
            var user2 = new User { Name = "Bob", Role = "Admin" };
            var user3 = new User { Name = "Clark", Role = "User" };
            var user4 = new User { Name = "Dan", Role = "User" };

            db.Users.Add(user2);
            db.SaveChanges();

            db.Users.AddRange(user1, user3, user4);

            var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
            var user2Creds = new UserCredential { Login = "BobJ", Password = "asdfgh585" };
            var user3Creds = new UserCredential { Login = "ClarkK", Password = "111zlt777" };
            var user4Creds = new UserCredential { Login = "DanE", Password = "zxc333vbn" };

            user1Creds.User = user1;
            user2Creds.UserId = user2.Id;
            user3.UserCredential = user3Creds;
            user4.UserCredential = user4Creds;

            db.UserCredentials.AddRange(user2Creds, user3Creds, user4Creds);

            db.SaveChanges();
        }
    }
}