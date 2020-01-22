using Microsoft.EntityFrameworkCore;

namespace Narcissus.DbModels
{
    public partial class NarcissusContext : DbContext
    {
        public NarcissusContext()
        {
        }

        public NarcissusContext(DbContextOptions<NarcissusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apps> Apps { get; set; }
        public virtual DbSet<AppsTokens> AppsTokens { get; set; }
        public virtual DbSet<CoolDown> CoolDown { get; set; }
        public virtual DbSet<LogsApps> LogsApps { get; set; }
        public virtual DbSet<LogsUsers> LogsUsers { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersInfo> UsersInfo { get; set; }
        public virtual DbSet<UsersOptions> UsersOptions { get; set; }
        public virtual DbSet<UsersRegistrationInfo> UsersRegistrationInfo { get; set; }
        public virtual DbSet<UsersSecurity> UsersSecurity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apps>(entity =>
            {
                entity.HasKey(e => e.AppId)
                    .HasName("PRIMARY");

                entity.ToTable("apps");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasColumnType("int(11)")
                    .HasComment("应用ID");

                entity.Property(e => e.AppDescription)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("应用描述")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("应用名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<AppsTokens>(entity =>
            {
                entity.HasKey(e => e.AppTokenId)
                    .HasName("PRIMARY");

                entity.ToTable("apps_tokens");

                entity.Property(e => e.AppTokenId)
                    .HasColumnName("AppTokenID")
                    .HasColumnType("int(11)")
                    .HasComment("应用令牌ID");

                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("通过应用令牌")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasColumnType("int(11)")
                    .HasComment("应用ID");

                entity.Property(e => e.ClientIp)
                    .IsRequired()
                    .HasColumnName("ClientIP")
                    .HasColumnType("text")
                    .HasComment("应用客户端IP")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClientToken)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("应用客户端令牌")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ExpireTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("过期时间");

                entity.Property(e => e.IssueTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("颁发时间");
            });

            modelBuilder.Entity<CoolDown>(entity =>
            {
                entity.ToTable("cool_down");

                entity.Property(e => e.CoolDownId)
                    .HasColumnName("CoolDownID")
                    .HasColumnType("int(11)")
                    .HasComment("冷却ID");

                entity.Property(e => e.CoolDownEndTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("冷却结束时间");

                entity.Property(e => e.CoolDownLevel)
                    .HasColumnType("int(11)")
                    .HasComment("冷却等级");

                entity.Property(e => e.LastTryTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("最后尝试时间");

                entity.Property(e => e.TryTimes)
                    .HasColumnType("int(11)")
                    .HasComment("尝试次数");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<LogsApps>(entity =>
            {
                entity.HasKey(e => e.LogAppId)
                    .HasName("PRIMARY");

                entity.ToTable("logs_apps");

                entity.Property(e => e.LogAppId)
                    .HasColumnName("LogAppID")
                    .HasColumnType("int(11)")
                    .HasComment("应用操作日志ID");

                entity.Property(e => e.AppId)
                    .HasColumnName("AppID")
                    .HasColumnType("int(11)")
                    .HasComment("应用ID");

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("用户操作")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("用户操作结果")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Time)
                    .HasColumnType("bigint(20)")
                    .HasComment("操作时间");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<LogsUsers>(entity =>
            {
                entity.HasKey(e => e.LogUserId)
                    .HasName("PRIMARY");

                entity.ToTable("logs_users");

                entity.Property(e => e.LogUserId)
                    .HasColumnName("LogUserID")
                    .HasColumnType("int(11)")
                    .HasComment("用户操作日志ID");

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("用户操作")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("用户操作结果")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Time)
                    .HasColumnType("bigint(20)")
                    .HasComment("操作时间");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<Tokens>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PRIMARY");

                entity.ToTable("tokens");

                entity.Property(e => e.TokenId)
                    .HasColumnName("TokenID")
                    .HasColumnType("int(11)")
                    .HasComment("令牌ID");

                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("令牌")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClientIp)
                    .IsRequired()
                    .HasColumnName("ClientIP")
                    .HasColumnType("text")
                    .HasComment("客户端IP")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClientToken)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("客户端令牌")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ExpireTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("令牌过期时间");

                entity.Property(e => e.IssueTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("令牌颁发时间");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(1)")
                    .HasComment("令牌状态");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasComment("用户主要邮箱")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.OpenUserId)
                    .IsRequired()
                    .HasColumnName("OpenUserID")
                    .HasColumnType("text")
                    .HasComment("开放用户ID")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("密码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("密码盐")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("text")
                    .HasComment("用户主要手机号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PhoneCountryCode)
                    .HasColumnType("text")
                    .HasComment("用户主要手机号国别代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(1)")
                    .HasComment("用户状态");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("用户名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<UsersInfo>(entity =>
            {
                entity.ToTable("users_info");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");

                entity.Property(e => e.Avatar)
                    .HasColumnType("text")
                    .HasComment("用户头像")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Experience)
                    .HasColumnType("int(11)")
                    .HasComment("用户经验");

                entity.Property(e => e.FirstName)
                    .HasColumnType("text")
                    .HasComment("用户名字")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasComment("用户性别");

                entity.Property(e => e.LastName)
                    .HasColumnType("text")
                    .HasComment("用户姓氏")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Level)
                    .HasColumnType("int(11)")
                    .HasComment("用户等级");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("用户昵称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Signature)
                    .HasColumnType("text")
                    .HasComment("用户签名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.WebSite)
                    .HasColumnType("text")
                    .HasComment("用户网站")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<UsersOptions>(entity =>
            {
                entity.ToTable("users_options");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");

                entity.Property(e => e.IsShowEmail).HasComment("是否显示用户邮箱");

                entity.Property(e => e.IsShowExperience).HasComment("是否显示用户经验");

                entity.Property(e => e.IsShowGender).HasComment("是否显示用户性别");

                entity.Property(e => e.IsShowLevel).HasComment("是否显示用户等级");

                entity.Property(e => e.IsShowPhone).HasComment("是否显示用户手机号");

                entity.Property(e => e.IsShowWebsite).HasComment("是否显示用户网站");
            });

            modelBuilder.Entity<UsersRegistrationInfo>(entity =>
            {
                entity.ToTable("users_registration_info");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");

                entity.Property(e => e.RegisterEmail)
                    .HasColumnType("text")
                    .HasComment("注册时邮箱")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RegisterIp)
                    .IsRequired()
                    .HasColumnName("RegisterIP")
                    .HasColumnType("text")
                    .HasComment("注册IP")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RegisterPhone)
                    .HasColumnType("text")
                    .HasComment("注册时手机号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RegisterPhoneCountryCode)
                    .HasColumnType("text")
                    .HasComment("注册时手机号国别代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RegisterTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("注册时间");
            });

            modelBuilder.Entity<UsersSecurity>(entity =>
            {
                entity.ToTable("users_security");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");

                entity.Property(e => e.LastLoginIp)
                    .HasColumnName("LastLoginIP")
                    .HasColumnType("text")
                    .HasComment("最后登录IP")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnType("bigint(20)")
                    .HasComment("最后登录时间");

                entity.Property(e => e.LastLoginToken)
                    .HasColumnType("text")
                    .HasComment("最后登录令牌")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SecurityAnswer)
                    .HasColumnType("text")
                    .HasComment("安全问题答案")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SecurityQuestion)
                    .HasColumnType("text")
                    .HasComment("安全问题")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
