using EF6SQLWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLWebApplication.Data
{
    public partial class ShipmentContext : DbContext
    {
        public ShipmentContext()
        {
        }

        public ShipmentContext(DbContextOptions<ShipmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<DriverTruck> DriverTrucks { get; set; } = null!;
        public virtual DbSet<Place> Places { get; set; } = null!;
        public virtual DbSet<Models.Route> Routes { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Truck> Trucks { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Shipment;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargo");

                entity.Property(e => e.Volume).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.RecipientContact)
                    .WithMany(p => p.CargoRecipientContacts)
                    .HasForeignKey(d => d.RecipientContactId)
                    .HasConstraintName("FK__Cargo__Recipient__49C3F6B7");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK__Cargo__RouteId__48CFD27E");

                entity.HasOne(d => d.SenderContact)
                    .WithMany(p => p.CargoSenderContacts)
                    .HasForeignKey(d => d.SenderContactId)
                    .HasConstraintName("FK__Cargo__SenderCon__47DBAE45");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DriverTruck>(entity =>
            {
                entity.ToTable("DriverTruck");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverTrucks)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverTru__Drive__4AB81AF0");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.DriverTrucks)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverTru__Truck__4BAC3F29");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("Place");

                entity.Property(e => e.PlaceName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Place__StateId__4CA06362");
            });

            modelBuilder.Entity<Models.Route>(entity =>
            {
                entity.ToTable("Route");

                entity.HasOne(d => d.DestinationWaterhouse)
                    .WithMany(p => p.RouteDestinationWaterhouses)
                    .HasForeignKey(d => d.DestinationWaterhouseId)
                    .HasConstraintName("FK__Route__Destinati__4E88ABD4");

                entity.HasOne(d => d.OriginWaterhouse)
                    .WithMany(p => p.RouteOriginWaterhouses)
                    .HasForeignKey(d => d.OriginWaterhouseId)
                    .HasConstraintName("FK__Route__OriginWat__4D94879B");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.Property(e => e.CompletionDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("FK__Shipment__CargoI__5165187F");

                entity.HasOne(d => d.DriverTruck)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.DriverTruckId)
                    .HasConstraintName("FK__Shipment__Driver__5070F446");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK__Shipment__RouteI__4F7CD00D");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.StateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.ToTable("Truck");

                entity.Property(e => e.Brand)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Year).HasColumnType("datetime");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("FK__Warehouse__Place__52593CB8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
