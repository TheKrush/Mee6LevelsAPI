using System;
using System.Reflection;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Xunit;

namespace Mee6LevelsAPI.Tests
{
    public sealed class Mee6DtoTests
    {
        [Fact]
        public void Mee6UserInfo_JsonSerialization_RoundTripsFields()
        {
            Mee6UserInfo original = new()
            {
                Avatar = "avatar-hash",
                DetailedXp = new[] { 10, 20, 30 },
                Discriminator = "1234",
                GuildId = "987654321",
                Id = "123456789",
                Level = 7,
                MessageCount = 42,
                Username = "TestUser",
                Xp = 12345
            };

            string json = JsonConvert.SerializeObject(original);
            Mee6UserInfo deserialized = JsonConvert.DeserializeObject<Mee6UserInfo>(json);

            Assert.Equal(original.Avatar, deserialized.Avatar);
            Assert.Equal(original.DetailedXp, deserialized.DetailedXp);
            Assert.Equal(original.Discriminator, deserialized.Discriminator);
            Assert.Equal(original.GuildId, deserialized.GuildId);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.Level, deserialized.Level);
            Assert.Equal(original.MessageCount, deserialized.MessageCount);
            Assert.Equal(original.Username, deserialized.Username);
            Assert.Equal(original.Xp, deserialized.Xp);
        }

        [Fact]
        public void Mee6GuildInfo_JsonSerialization_RoundTripsFields()
        {
            Mee6GuildInfo original = new()
            {
                AllowJoin = true,
                Icon = "icon-hash",
                Id = "123456789",
                InviteLeaderboard = true,
                LeaderboardURL = "https://mee6.xyz/leaderboard/123456789",
                Name = "Test Guild",
                Premium = false
            };

            string json = JsonConvert.SerializeObject(original);
            Mee6GuildInfo deserialized = JsonConvert.DeserializeObject<Mee6GuildInfo>(json);

            Assert.Equal(original.AllowJoin, deserialized.AllowJoin);
            Assert.Equal(original.Icon, deserialized.Icon);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.InviteLeaderboard, deserialized.InviteLeaderboard);
            Assert.Equal(original.LeaderboardURL, deserialized.LeaderboardURL);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Premium, deserialized.Premium);
        }

        [Fact]
        public void Mee6Role_JsonSerialization_RoundTripsFields()
        {
            Mee6Role original = new()
            {
                Color = 0x00FF00,
                Hoist = true,
                Id = "987654321",
                Managed = false,
                Mentionable = true,
                Name = "Tester",
                Permissions = 123456789L,
                Position = 5
            };

            string json = JsonConvert.SerializeObject(original);
            Mee6Role deserialized = JsonConvert.DeserializeObject<Mee6Role>(json);

            Assert.Equal(original.Color, deserialized.Color);
            Assert.Equal(original.Hoist, deserialized.Hoist);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.Managed, deserialized.Managed);
            Assert.Equal(original.Mentionable, deserialized.Mentionable);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Permissions, deserialized.Permissions);
            Assert.Equal(original.Position, deserialized.Position);
        }

        [Fact]
        public void Mee6RoleInfo_JsonSerialization_RoundTripsFields()
        {
            Mee6RoleInfo original = new()
            {
                Rank = 1,
                Role = new Mee6Role
                {
                    Color = 0xFF0000,
                    Hoist = false,
                    Id = "role-id",
                    Managed = true,
                    Mentionable = false,
                    Name = "RoleName",
                    Permissions = 777,
                    Position = 10
                }
            };

            string json = JsonConvert.SerializeObject(original);
            Mee6RoleInfo deserialized = JsonConvert.DeserializeObject<Mee6RoleInfo>(json);

            Assert.Equal(original.Rank, deserialized.Rank);
            Assert.Equal(original.Role.Color, deserialized.Role.Color);
            Assert.Equal(original.Role.Hoist, deserialized.Role.Hoist);
            Assert.Equal(original.Role.Id, deserialized.Role.Id);
            Assert.Equal(original.Role.Managed, deserialized.Role.Managed);
            Assert.Equal(original.Role.Mentionable, deserialized.Role.Mentionable);
            Assert.Equal(original.Role.Name, deserialized.Role.Name);
            Assert.Equal(original.Role.Permissions, deserialized.Role.Permissions);
            Assert.Equal(original.Role.Position, deserialized.Role.Position);
        }

        [Fact]
        public void Mee6Server_JsonSerialization_RoundTripsFields()
        {
            Mee6UserInfo user = new()
            {
                Avatar = "avatar-hash",
                DetailedXp = new[] { 100, 200 },
                Discriminator = "0001",
                GuildId = "guild-1",
                Id = "user-1",
                Level = 3,
                MessageCount = 10,
                Username = "User1",
                Xp = 300
            };

            Mee6RoleInfo roleInfo = new()
            {
                Rank = 1,
                Role = new Mee6Role
                {
                    Color = 1,
                    Hoist = false,
                    Id = "role-1",
                    Managed = false,
                    Mentionable = true,
                    Name = "Role1",
                    Permissions = 42,
                    Position = 1
                }
            };

            Mee6Server original = new()
            {
                Admin = true,
                BannerURL = "https://example.com/banner.png",
                Guild = new Mee6GuildInfo
                {
                    AllowJoin = true,
                    Icon = "icon-hash",
                    Id = "guild-1",
                    InviteLeaderboard = false,
                    LeaderboardURL = "https://mee6.xyz/leaderboard/guild-1",
                    Name = "Guild One",
                    Premium = true
                },
                IsMember = true,
                Page = 1,
                Users = new[] { user },
                RewardRoles = new[] { roleInfo },
                XPPerMessage = new[] { 5L, 10L },
                XPRate = 2
            };

            string json = JsonConvert.SerializeObject(original);
            Mee6Server deserialized = JsonConvert.DeserializeObject<Mee6Server>(json);

            Assert.Equal(original.Admin, deserialized.Admin);
            Assert.Equal(original.BannerURL, deserialized.BannerURL);

            Assert.Equal(original.Guild.AllowJoin, deserialized.Guild.AllowJoin);
            Assert.Equal(original.Guild.Icon, deserialized.Guild.Icon);
            Assert.Equal(original.Guild.Id, deserialized.Guild.Id);
            Assert.Equal(original.Guild.InviteLeaderboard, deserialized.Guild.InviteLeaderboard);
            Assert.Equal(original.Guild.LeaderboardURL, deserialized.Guild.LeaderboardURL);
            Assert.Equal(original.Guild.Name, deserialized.Guild.Name);
            Assert.Equal(original.Guild.Premium, deserialized.Guild.Premium);

            Assert.Equal(original.IsMember, deserialized.IsMember);
            Assert.Equal(original.Page, deserialized.Page);

            Assert.NotNull(deserialized.Users);
            _ = Assert.Single(deserialized.Users);
            Assert.Equal(original.Users[0].Id, deserialized.Users[0].Id);
            Assert.Equal(original.Users[0].Username, deserialized.Users[0].Username);
            Assert.Equal(original.Users[0].Xp, deserialized.Users[0].Xp);

            Assert.NotNull(deserialized.RewardRoles);
            _ = Assert.Single(deserialized.RewardRoles);
            Assert.Equal(original.RewardRoles[0].Rank, deserialized.RewardRoles[0].Rank);
            Assert.Equal(original.RewardRoles[0].Role.Name, deserialized.RewardRoles[0].Role.Name);

            Assert.Equal(original.XPPerMessage, deserialized.XPPerMessage);
            Assert.Equal(original.XPRate, deserialized.XPRate);
        }

        [Theory]
        [InlineData(typeof(Mee6UserInfo), "Avatar", "avatar")]
        [InlineData(typeof(Mee6UserInfo), "DetailedXp", "detailed_xp")]
        [InlineData(typeof(Mee6UserInfo), "Discriminator", "discriminator")]
        [InlineData(typeof(Mee6UserInfo), "GuildId", "guild_id")]
        [InlineData(typeof(Mee6UserInfo), "Id", "id")]
        [InlineData(typeof(Mee6UserInfo), "Level", "level")]
        [InlineData(typeof(Mee6UserInfo), "MessageCount", "message_count")]
        [InlineData(typeof(Mee6UserInfo), "Username", "username")]
        [InlineData(typeof(Mee6UserInfo), "Xp", "xp")]
        public void Mee6UserInfo_HasExpectedJsonPropertyAttributes(Type type, string fieldName, string expectedJsonName)
        {
            FieldInfo? field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);

            JsonPropertyAttribute? attr = field!.GetCustomAttribute<JsonPropertyAttribute>();
            Assert.NotNull(attr);
            Assert.Equal(expectedJsonName, attr!.PropertyName);
        }

        [Theory]
        [InlineData(typeof(Mee6GuildInfo), "AllowJoin", "allow_join")]
        [InlineData(typeof(Mee6GuildInfo), "Icon", "icon")]
        [InlineData(typeof(Mee6GuildInfo), "Id", "id")]
        [InlineData(typeof(Mee6GuildInfo), "InviteLeaderboard", "invite_leaderboard")]
        [InlineData(typeof(Mee6GuildInfo), "LeaderboardURL", "leaderboard_url")]
        [InlineData(typeof(Mee6GuildInfo), "Name", "name")]
        [InlineData(typeof(Mee6GuildInfo), "Premium", "premium")]
        public void Mee6GuildInfo_HasExpectedJsonPropertyAttributes(Type type, string fieldName, string expectedJsonName)
        {
            FieldInfo? field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);

            JsonPropertyAttribute? attr = field!.GetCustomAttribute<JsonPropertyAttribute>();
            Assert.NotNull(attr);
            Assert.Equal(expectedJsonName, attr!.PropertyName);
        }

        [Theory]
        [InlineData(typeof(Mee6Role), "Color", "color")]
        [InlineData(typeof(Mee6Role), "Hoist", "hoist")]
        [InlineData(typeof(Mee6Role), "Id", "id")]
        [InlineData(typeof(Mee6Role), "Managed", "managed")]
        [InlineData(typeof(Mee6Role), "Mentionable", "mentionable")]
        [InlineData(typeof(Mee6Role), "Name", "name")]
        [InlineData(typeof(Mee6Role), "Permissions", "permissions")]
        [InlineData(typeof(Mee6Role), "Position", "position")]
        public void Mee6Role_HasExpectedJsonPropertyAttributes(Type type, string fieldName, string expectedJsonName)
        {
            FieldInfo? field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);

            JsonPropertyAttribute? attr = field!.GetCustomAttribute<JsonPropertyAttribute>();
            Assert.NotNull(attr);
            Assert.Equal(expectedJsonName, attr!.PropertyName);
        }

        [Theory]
        [InlineData(typeof(Mee6Server), "Admin", "admin")]
        [InlineData(typeof(Mee6Server), "BannerURL", "banner_url")]
        [InlineData(typeof(Mee6Server), "Guild", "guild")]
        [InlineData(typeof(Mee6Server), "IsMember", "is_member")]
        [InlineData(typeof(Mee6Server), "Page", "page")]
        [InlineData(typeof(Mee6Server), "Users", "players")]
        [InlineData(typeof(Mee6Server), "RewardRoles", "role_rewards")]
        [InlineData(typeof(Mee6Server), "XPPerMessage", "xp_per_message")]
        [InlineData(typeof(Mee6Server), "XPRate", "xp_rate")]
        public void Mee6Server_HasExpectedJsonPropertyAttributes(Type type, string fieldName, string expectedJsonName)
        {
            FieldInfo? field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);

            JsonPropertyAttribute? attr = field!.GetCustomAttribute<JsonPropertyAttribute>();
            Assert.NotNull(attr);
            Assert.Equal(expectedJsonName, attr!.PropertyName);
        }
    }

    // ----------------------------------------------------------------------
    // NOTE: The methods below (Mee6.GetServer / GetServerAsync / GetUserInfo /
    // GetAvatarAsync) create HttpClient internally and hit the real Mee6 /
    // Discord APIs. To truly unit test them, you’ll want to refactor Mee6 to
    // accept an HttpClient (or an IMee6Api abstraction) so you can inject a
    // fake handler in tests.
    //
    // For now, you could write integration tests like this, replacing the
    // IDs with real ones from your server:
    // ----------------------------------------------------------------------
    public sealed class Mee6IntegrationExamples
    {
        // Replace with a real guild ID that has Mee6 levels enabled.
        private const long ExampleGuildId = 123456789012345678;

        // Replace with a real user ID in that guild.
        private const long ExampleUserId = 234567890123456789;

        [Fact(Skip = "Integration example – hits the real Mee6 API; configure IDs before enabling.")]
        public async Task GetServerAsync_ReturnsUsers_ForRealGuild()
        {
            Mee6Server server = await Mee6.GetServerAsync(ExampleGuildId);

            Assert.NotNull(server.Users);
            Assert.NotEmpty(server.Users);
        }

        [Fact(Skip = "Integration example – hits the real Mee6 API; configure IDs before enabling.")]
        public void GetUserInfo_ReturnsUser_ForRealGuildAndUser()
        {
            Mee6UserInfo user = Mee6.GetUserInfo(ExampleGuildId, ExampleUserId);

            Assert.False(string.IsNullOrEmpty(user.Id));
            Assert.False(string.IsNullOrEmpty(user.Username));
        }
    }
}
