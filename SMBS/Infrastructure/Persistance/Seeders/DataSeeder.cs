public static class DataSeeder
{
    public static void Seed(AppContext context)
    {
        if (!context.UserStatuses.Any())
        {
            var userStatuses = new List<UserStatus>
            {
                new UserStatus { Name = "Active" },
                new UserStatus { Name = "Inactive" },
                new UserStatus { Name = "Banned" }
            };

            context.UserStatuses.AddRange(userStatuses);
            context.SaveChanges();
        }
    }
}