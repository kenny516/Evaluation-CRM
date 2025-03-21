using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EvaluationCrm.Models.entity;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContractSetting> ContractSettings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerLoginInfo> CustomerLoginInfos { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<GoogleDriveFile> GoogleDriveFiles { get; set; }

    public virtual DbSet<LeadAction> LeadActions { get; set; }

    public virtual DbSet<LeadSetting> LeadSettings { get; set; }

    public virtual DbSet<OauthUser> OauthUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TicketSetting> TicketSettings { get; set; }

    public virtual DbSet<TriggerContract> TriggerContracts { get; set; }

    public virtual DbSet<TriggerLead> TriggerLeads { get; set; }

    public virtual DbSet<TriggerTicket> TriggerTickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=crm;uid=root;pwd=2004", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ContractSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract_settings");

            entity.HasIndex(e => e.AmountEmailTemplate, "amount_email_template");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.DescriptionEmailTemplate, "description_email_template");

            entity.HasIndex(e => e.EndEmailTemplate, "end_email_template");

            entity.HasIndex(e => e.StartEmailTemplate, "start_email_template");

            entity.HasIndex(e => e.StatusEmailTemplate, "status_email_template");

            entity.HasIndex(e => e.SubjectEmailTemplate, "subject_email_template");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.AmountEmailTemplate).HasColumnName("amount_email_template");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DescriptionEmailTemplate).HasColumnName("description_email_template");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.EndEmailTemplate).HasColumnName("end_email_template");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StartEmailTemplate).HasColumnName("start_email_template");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StatusEmailTemplate).HasColumnName("status_email_template");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.SubjectEmailTemplate).HasColumnName("subject_email_template");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.AmountEmailTemplateNavigation).WithMany(p => p.ContractSettingAmountEmailTemplateNavigations)
                .HasForeignKey(d => d.AmountEmailTemplate)
                .HasConstraintName("contract_settings_ibfk_3");

            entity.HasOne(d => d.Customer).WithMany(p => p.ContractSettings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("contract_settings_ibfk_8");

            entity.HasOne(d => d.DescriptionEmailTemplateNavigation).WithMany(p => p.ContractSettingDescriptionEmailTemplateNavigations)
                .HasForeignKey(d => d.DescriptionEmailTemplate)
                .HasConstraintName("contract_settings_ibfk_5");

            entity.HasOne(d => d.EndEmailTemplateNavigation).WithMany(p => p.ContractSettingEndEmailTemplateNavigations)
                .HasForeignKey(d => d.EndEmailTemplate)
                .HasConstraintName("contract_settings_ibfk_7");

            entity.HasOne(d => d.StartEmailTemplateNavigation).WithMany(p => p.ContractSettingStartEmailTemplateNavigations)
                .HasForeignKey(d => d.StartEmailTemplate)
                .HasConstraintName("contract_settings_ibfk_6");

            entity.HasOne(d => d.StatusEmailTemplateNavigation).WithMany(p => p.ContractSettingStatusEmailTemplateNavigations)
                .HasForeignKey(d => d.StatusEmailTemplate)
                .HasConstraintName("contract_settings_ibfk_2");

            entity.HasOne(d => d.SubjectEmailTemplateNavigation).WithMany(p => p.ContractSettingSubjectEmailTemplateNavigations)
                .HasForeignKey(d => d.SubjectEmailTemplate)
                .HasConstraintName("contract_settings_ibfk_4");

            entity.HasOne(d => d.User).WithMany(p => p.ContractSettings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("contract_settings_ibfk_1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.ProfileId, "profile_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Facebook)
                .HasMaxLength(255)
                .HasColumnName("facebook");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasColumnName("position");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .HasColumnName("state");
            entity.Property(e => e.Twitter)
                .HasMaxLength(255)
                .HasColumnName("twitter");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Youtube)
                .HasMaxLength(255)
                .HasColumnName("youtube");

            entity.HasOne(d => d.Profile).WithMany(p => p.Customers)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("customer_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("customer_ibfk_1");
        });

        modelBuilder.Entity<CustomerLoginInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customer_login_info");

            entity.HasIndex(e => e.Token, "token").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PasswordSet)
                .HasDefaultValueSql("'0'")
                .HasColumnName("password_set");
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .HasColumnName("token");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PRIMARY");

            entity.ToTable("email_template");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.JsonDesign)
                .HasColumnType("text")
                .HasColumnName("json_design");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.EmailTemplates)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("email_template_ibfk_1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("employee")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(80)
                .HasColumnName("password");
            entity.Property(e => e.Provider)
                .HasMaxLength(45)
                .HasColumnName("provider");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PRIMARY");

            entity.ToTable("file");

            entity.HasIndex(e => e.ContractId, "contract_id");

            entity.HasIndex(e => e.LeadId, "lead_id");

            entity.Property(e => e.FileId).HasColumnName("file_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.FileData)
                .HasColumnType("blob")
                .HasColumnName("file_data");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .HasColumnName("file_name");
            entity.Property(e => e.FileType)
                .HasMaxLength(255)
                .HasColumnName("file_type");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");

            entity.HasOne(d => d.Contract).WithMany(p => p.Files)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("file_ibfk_2");

            entity.HasOne(d => d.Lead).WithMany(p => p.Files)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("file_ibfk_1");
        });

        modelBuilder.Entity<GoogleDriveFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("google_drive_file");

            entity.HasIndex(e => e.ContractId, "contract_id");

            entity.HasIndex(e => e.LeadId, "lead_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.DriveFileId)
                .HasMaxLength(255)
                .HasColumnName("drive_file_id");
            entity.Property(e => e.DriveFolderId)
                .HasMaxLength(255)
                .HasColumnName("drive_folder_id");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");

            entity.HasOne(d => d.Contract).WithMany(p => p.GoogleDriveFiles)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("google_drive_file_ibfk_2");

            entity.HasOne(d => d.Lead).WithMany(p => p.GoogleDriveFiles)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("google_drive_file_ibfk_1");
        });

        modelBuilder.Entity<LeadAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lead_action");

            entity.HasIndex(e => e.LeadId, "lead_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("action");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadActions)
                .HasForeignKey(d => d.LeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lead_action_ibfk_1");
        });

        modelBuilder.Entity<LeadSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lead_settings");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.MeetingEmailTemplate, "meeting_email_template");

            entity.HasIndex(e => e.NameEmailTemplate, "name_email_template");

            entity.HasIndex(e => e.PhoneEmailTemplate, "phone_email_template");

            entity.HasIndex(e => e.StatusEmailTemplate, "status_email_template");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Meeting).HasColumnName("meeting");
            entity.Property(e => e.MeetingEmailTemplate).HasColumnName("meeting_email_template");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NameEmailTemplate).HasColumnName("name_email_template");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.PhoneEmailTemplate).HasColumnName("phone_email_template");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StatusEmailTemplate).HasColumnName("status_email_template");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.LeadSettings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("lead_settings_ibfk_6");

            entity.HasOne(d => d.MeetingEmailTemplateNavigation).WithMany(p => p.LeadSettingMeetingEmailTemplateNavigations)
                .HasForeignKey(d => d.MeetingEmailTemplate)
                .HasConstraintName("lead_settings_ibfk_4");

            entity.HasOne(d => d.NameEmailTemplateNavigation).WithMany(p => p.LeadSettingNameEmailTemplateNavigations)
                .HasForeignKey(d => d.NameEmailTemplate)
                .HasConstraintName("lead_settings_ibfk_5");

            entity.HasOne(d => d.PhoneEmailTemplateNavigation).WithMany(p => p.LeadSettingPhoneEmailTemplateNavigations)
                .HasForeignKey(d => d.PhoneEmailTemplate)
                .HasConstraintName("lead_settings_ibfk_3");

            entity.HasOne(d => d.StatusEmailTemplateNavigation).WithMany(p => p.LeadSettingStatusEmailTemplateNavigations)
                .HasForeignKey(d => d.StatusEmailTemplate)
                .HasConstraintName("lead_settings_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.LeadSettings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("lead_settings_ibfk_1");
        });

        modelBuilder.Entity<OauthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("oauth_users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.UserId, "oauth_users_ibfk_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessToken)
                .HasMaxLength(255)
                .HasColumnName("access_token");
            entity.Property(e => e.AccessTokenExpiration)
                .HasColumnType("datetime")
                .HasColumnName("access_token_expiration");
            entity.Property(e => e.AccessTokenIssuedAt)
                .HasColumnType("datetime")
                .HasColumnName("access_token_issued_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.GrantedScopes)
                .HasMaxLength(255)
                .HasColumnName("granted_scopes");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(255)
                .HasColumnName("refresh_token");
            entity.Property(e => e.RefreshTokenExpiration)
                .HasColumnType("datetime")
                .HasColumnName("refresh_token_expiration");
            entity.Property(e => e.RefreshTokenIssuedAt)
                .HasColumnType("datetime")
                .HasColumnName("refresh_token_issued_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.OauthUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("oauth_users_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TicketSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ticket_settings");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.DescriptionEmailTemplate, "description_email_template");

            entity.HasIndex(e => e.SubjectEmailTemplate, "phone_email_template");

            entity.HasIndex(e => e.PriorityEmailTemplate, "priority_email_template");

            entity.HasIndex(e => e.StatusEmailTemplate, "status_email_template");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DescriptionEmailTemplate).HasColumnName("description_email_template");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.PriorityEmailTemplate).HasColumnName("priority_email_template");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StatusEmailTemplate).HasColumnName("status_email_template");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.SubjectEmailTemplate).HasColumnName("subject_email_template");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.TicketSettings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("ticket_settings_ibfk_6");

            entity.HasOne(d => d.DescriptionEmailTemplateNavigation).WithMany(p => p.TicketSettingDescriptionEmailTemplateNavigations)
                .HasForeignKey(d => d.DescriptionEmailTemplate)
                .HasConstraintName("ticket_settings_ibfk_5");

            entity.HasOne(d => d.PriorityEmailTemplateNavigation).WithMany(p => p.TicketSettingPriorityEmailTemplateNavigations)
                .HasForeignKey(d => d.PriorityEmailTemplate)
                .HasConstraintName("ticket_settings_ibfk_4");

            entity.HasOne(d => d.StatusEmailTemplateNavigation).WithMany(p => p.TicketSettingStatusEmailTemplateNavigations)
                .HasForeignKey(d => d.StatusEmailTemplate)
                .HasConstraintName("ticket_settings_ibfk_2");

            entity.HasOne(d => d.SubjectEmailTemplateNavigation).WithMany(p => p.TicketSettingSubjectEmailTemplateNavigations)
                .HasForeignKey(d => d.SubjectEmailTemplate)
                .HasConstraintName("ticket_settings_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.TicketSettings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ticket_settings_ibfk_1");
        });

        modelBuilder.Entity<TriggerContract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PRIMARY");

            entity.ToTable("trigger_contract");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.LeadId, "lead_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10)
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.GoogleDrive).HasColumnName("google_drive");
            entity.Property(e => e.GoogleDriveFolderId)
                .HasMaxLength(255)
                .HasColumnName("google_drive_folder_id");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.TriggerContracts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("trigger_contract_ibfk_3");

            entity.HasOne(d => d.Lead).WithMany(p => p.TriggerContracts)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("trigger_contract_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.TriggerContracts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("trigger_contract_ibfk_2");
        });

        modelBuilder.Entity<TriggerLead>(entity =>
        {
            entity.HasKey(e => e.LeadId).HasName("PRIMARY");

            entity.ToTable("trigger_lead");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.HasIndex(e => e.EmployeeId, "employee_id");

            entity.HasIndex(e => e.MeetingId, "meeting_info").IsUnique();

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.GoogleDrive).HasColumnName("google_drive");
            entity.Property(e => e.GoogleDriveFolderId)
                .HasMaxLength(255)
                .HasColumnName("google_drive_folder_id");
            entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.TriggerLeads)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trigger_lead_ibfk_1");

            entity.HasOne(d => d.Employee).WithMany(p => p.TriggerLeadEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("trigger_lead_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.TriggerLeadUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("trigger_lead_ibfk_2");
        });

        modelBuilder.Entity<TriggerTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("trigger_ticket");

            entity.HasIndex(e => e.CustomerId, "fk_ticket_customer");

            entity.HasIndex(e => e.EmployeeId, "fk_ticket_employee");

            entity.HasIndex(e => e.ManagerId, "fk_ticket_manager");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Priority)
                .HasMaxLength(50)
                .HasColumnName("priority");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("subject");

            entity.HasOne(d => d.Customer).WithMany(p => p.TriggerTickets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ticket_customer");

            entity.HasOne(d => d.Employee).WithMany(p => p.TriggerTicketEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("fk_ticket_employee");

            entity.HasOne(d => d.Manager).WithMany(p => p.TriggerTicketManagers)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("fk_ticket_manager");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("hire_date");
            entity.Property(e => e.IsPasswordSet)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_password_set");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .HasColumnName("token");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_roles_ibfk_2"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_roles_ibfk_1"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("user_roles");
                        j.HasIndex(new[] { "RoleId" }, "role_id");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_profile");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .HasColumnName("department");
            entity.Property(e => e.Facebook)
                .HasMaxLength(255)
                .HasColumnName("facebook");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.OauthUserImageLink)
                .HasMaxLength(255)
                .HasColumnName("oauth_user_image_link");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasPrecision(10, 2)
                .HasColumnName("salary");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Twitter)
                .HasMaxLength(255)
                .HasColumnName("twitter");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserImage)
                .HasColumnType("blob")
                .HasColumnName("user_image");
            entity.Property(e => e.Youtube)
                .HasMaxLength(255)
                .HasColumnName("youtube");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_profile_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
