using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SPPF_API.Models;

public partial class DashboardContext : DbContext
{
    public DashboardContext()
    {
    }

    public DashboardContext(DbContextOptions<DashboardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AlarmRecord> AlarmRecords { get; set; }

    public virtual DbSet<AlarmSetting> AlarmSettings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ConnectionStatus> ConnectionStatuses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<EnvRecord> EnvRecords { get; set; }

    public virtual DbSet<OperatorRecord> OperatorRecords { get; set; }

    public virtual DbSet<PlcSetting> PlcSettings { get; set; }

    public virtual DbSet<PrismaMigration> PrismaMigrations { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SolidRecord> SolidRecords { get; set; }

    public virtual DbSet<SpeedRecord> SpeedRecords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VerificationToken> VerificationTokens { get; set; }

    public virtual DbSet<ViscosityRecord> ViscosityRecords { get; set; }

    public virtual DbSet<VocRecord> VocRecords { get; set; }

    public virtual DbSet<WeightRecord> WeightRecords { get; set; }

    public virtual DbSet<WmvRecord> WmvRecords { get; set; }

    public virtual DbSet<WorkOrder> WorkOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Dashboard;Username=postgres;Password=sppf;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Account_pkey");

            entity.ToTable("Account");

            entity.HasIndex(e => new { e.Provider, e.ProviderAccountId }, "Account_provider_providerAccountId_key").IsUnique();

            entity.HasIndex(e => e.UserId, "Account_userId_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessToken).HasColumnName("access_token");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.IdToken).HasColumnName("id_token");
            entity.Property(e => e.Provider).HasColumnName("provider");
            entity.Property(e => e.ProviderAccountId).HasColumnName("providerAccountId");
            entity.Property(e => e.RefreshToken).HasColumnName("refresh_token");
            entity.Property(e => e.Scope).HasColumnName("scope");
            entity.Property(e => e.SessionState).HasColumnName("session_state");
            entity.Property(e => e.TokenType).HasColumnName("token_type");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Account_userId_fkey");
        });

        modelBuilder.Entity<AlarmRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("alarm_record_pkey");

            entity.ToTable("alarm_record");

            entity.HasIndex(e => e.AlarmId, "alarm_record_alarm_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlarmId).HasColumnName("alarm_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");

            entity.HasOne(d => d.Alarm).WithMany(p => p.AlarmRecords)
                .HasForeignKey(d => d.AlarmId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("alarm_record_alarm_id_fkey");
        });

        modelBuilder.Entity<AlarmSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("alarm_setting_pkey");

            entity.ToTable("alarm_setting");

            entity.HasIndex(e => e.DeviceId, "alarm_setting_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.IsEnable).HasColumnName("is_enable");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Device).WithMany(p => p.AlarmSettings)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("alarm_setting_device_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<ConnectionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("connection_status_pkey");

            entity.ToTable("connection_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("device_pkey");

            entity.ToTable("device");

            entity.HasIndex(e => e.CategoryId, "device_category_id_idx");

            entity.HasIndex(e => e.DeviceId, "device_device_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Enable)
                .HasDefaultValue(true)
                .HasColumnName("enable");
            entity.Property(e => e.Line).HasColumnName("line");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OfficeGroup).HasColumnName("office_group");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Category).WithMany(p => p.Devices)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("device_category_id_fkey");
        });

        modelBuilder.Entity<EnvRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("env_record_pkey");

            entity.ToTable("env_record");

            entity.HasIndex(e => e.DeviceId, "env_record_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");

            entity.HasOne(d => d.Device).WithMany(p => p.EnvRecords)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("env_record_device_id_fkey");
        });

        modelBuilder.Entity<OperatorRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("operator_record_pkey");

            entity.ToTable("operator_record");

            entity.HasIndex(e => e.DeviceId, "operator_record_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Username).HasColumnName("username");

            entity.HasOne(d => d.Device).WithMany(p => p.OperatorRecords)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("operator_record_device_id_fkey");
        });

        modelBuilder.Entity<PlcSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("plc_setting_pkey");

            entity.ToTable("plc_setting");

            entity.HasIndex(e => e.DeviceId, "plc_setting_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.Ip).HasColumnName("ip");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Protocol).HasColumnName("protocol");
            entity.Property(e => e.Second).HasColumnName("second");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Device).WithMany(p => p.PlcSettings)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("plc_setting_device_id_fkey");
        });

        modelBuilder.Entity<PrismaMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("_prisma_migrations_pkey");

            entity.ToTable("_prisma_migrations");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.AppliedStepsCount)
                .HasDefaultValue(0)
                .HasColumnName("applied_steps_count");
            entity.Property(e => e.Checksum)
                .HasMaxLength(64)
                .HasColumnName("checksum");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
            entity.Property(e => e.Logs).HasColumnName("logs");
            entity.Property(e => e.MigrationName)
                .HasMaxLength(255)
                .HasColumnName("migration_name");
            entity.Property(e => e.RolledBackAt).HasColumnName("rolled_back_at");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Session_pkey");

            entity.ToTable("Session");

            entity.HasIndex(e => e.SessionToken, "Session_sessionToken_key").IsUnique();

            entity.HasIndex(e => e.UserId, "Session_userId_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expires)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("expires");
            entity.Property(e => e.SessionToken).HasColumnName("sessionToken");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Session_userId_fkey");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("setting_pkey");

            entity.ToTable("setting");

            entity.HasIndex(e => e.DeviceId, "setting_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Device).WithMany(p => p.Settings)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("setting_device_id_fkey");
        });

        modelBuilder.Entity<SolidRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("solid_record_pkey");

            entity.ToTable("solid_record");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Solid).HasColumnName("solid");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");
        });

        modelBuilder.Entity<SpeedRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("speed_record_pkey");

            entity.ToTable("speed_record");

            entity.HasIndex(e => e.DeviceId, "speed_record_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");

            entity.HasOne(d => d.Device).WithMany(p => p.SpeedRecords)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("speed_record_device_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "User_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EmailVerified)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("emailVerified");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("User_department_id_fkey");
        });

        modelBuilder.Entity<VerificationToken>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VerificationToken");

            entity.HasIndex(e => new { e.Identifier, e.Token }, "VerificationToken_identifier_token_key").IsUnique();

            entity.HasIndex(e => e.Token, "VerificationToken_token_key").IsUnique();

            entity.Property(e => e.Expires)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("expires");
            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.Token).HasColumnName("token");
        });

        modelBuilder.Entity<ViscosityRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("viscosity_record_pkey");

            entity.ToTable("viscosity_record");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Viscosity).HasColumnName("viscosity");
        });

        modelBuilder.Entity<VocRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("voc_record_pkey");

            entity.ToTable("voc_record");

            entity.HasIndex(e => e.DeviceId, "voc_record_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Voc).HasColumnName("voc");

            entity.HasOne(d => d.Device).WithMany(p => p.VocRecords)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("voc_record_device_id_fkey");
        });

        modelBuilder.Entity<WeightRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("weight_record_pkey");

            entity.ToTable("weight_record");

            entity.HasIndex(e => e.DeviceId, "weight_record_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Device).WithMany(p => p.WeightRecords)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("weight_record_device_id_fkey");
        });

        modelBuilder.Entity<WmvRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wmv_record_pkey");

            entity.ToTable("wmv_record");

            entity.HasIndex(e => e.DeviceId, "wmv_record_device_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.ProductTime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("product_time");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("time");

            entity.HasOne(d => d.Device).WithMany(p => p.WmvRecords)
                .HasPrincipalKey(p => p.DeviceId)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("wmv_record_device_id_fkey");
        });

        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("work_orders_pkey");

            entity.ToTable("work_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.Line).HasColumnName("line");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderName)
                .HasDefaultValueSql("''::text")
                .HasColumnName("order_name");
            entity.Property(e => e.ProductNumber).HasColumnName("product_number");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("''::text")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
