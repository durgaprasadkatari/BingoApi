using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bingo.Api.Models
{
    public partial class sarathkatari07_BingoDBContext : DbContext
    {
        public sarathkatari07_BingoDBContext()
        {
        }

        public sarathkatari07_BingoDBContext(DbContextOptions<sarathkatari07_BingoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogin> AdminLogin { get; set; }
        public virtual DbSet<BingoBoard> BingoBoard { get; set; }
        public virtual DbSet<GameDetails> GameDetails { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=sql.freeasphost.net\\MSSQL2016;Initial Catalog=sarathkatari07_BingoDB;Integrated Security=False;User ID=sarathkatari07;Password=admin123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BingoBoard>(entity =>
            {
                entity.HasKey(e => e.BoardId);

                entity.Property(e => e.BoardId).HasColumnName("BoardID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrimaryPlayerid).HasColumnName("primary_playerid");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<GameDetails>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.Property(e => e.CoinCounterid).HasColumnName("coin_counterid");

                entity.Property(e => e.CurrentNumber).HasColumnName("current_number");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Previousnumbers).HasColumnName("previousnumbers");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TicketPrice)
                    .HasColumnName("ticket_price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalPrize)
                    .HasColumnName("total_prize")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.GameDetails)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK_GameDetails_BingoBoard");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmptyMessage).HasMaxLength(50);

                entity.Property(e => e.Message).HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Playerid)
                    .HasColumnName("playerid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Boardid).HasColumnName("boardid");

                entity.Property(e => e.PlayerName)
                    .HasColumnName("player_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.Boardid)
                    .HasConstraintName("FK_Player_BingoBoard");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Ticketid)
                    .HasColumnName("ticketid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gameid).HasColumnName("gameid");

                entity.Property(e => e.NoOfTickets).HasColumnName("no_of_tickets");

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.TicketContent).HasColumnName("ticket_content");

                entity.Property(e => e.TicketPath)
                    .HasColumnName("ticket_path")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TicketPrice)
                    .HasColumnName("ticket_price")
                    .HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
