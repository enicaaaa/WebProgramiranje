// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_server.Models;

namespace Web_server.Migrations
{
    [DbContext(typeof(GarageContext))]
    partial class GarageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_server.Models.Garaza", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Broj")
                        .HasColumnType("int")
                        .HasColumnName("Broj");

                    b.Property<int>("Broj_mesta")
                        .HasColumnType("int")
                        .HasColumnName("Broj mesta");

                    b.Property<int>("Broj_nivoa")
                        .HasColumnType("int")
                        .HasColumnName("Broj nivoa");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.Property<string>("Ulica")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Ulica");

                    b.HasKey("ID");

                    b.ToTable("Garaza");
                });

            modelBuilder.Entity("Web_server.Models.ParkingMesto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GarazaID")
                        .HasColumnType("int");

                    b.Property<bool>("Tip")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.Property<int?>("VoziloID")
                        .HasColumnType("int");

                    b.Property<int>("Vreme")
                        .HasColumnType("int")
                        .HasColumnName("Vreme parkiranja");

                    b.HasKey("ID");

                    b.HasIndex("GarazaID");

                    b.HasIndex("VoziloID");

                    b.ToTable("Parking mesto");
                });

            modelBuilder.Entity("Web_server.Models.Vozilo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Broj_telefona")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Broj telefona");

                    b.Property<string>("Ime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Ime");

                    b.Property<string>("Prezime")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Prezime");

                    b.Property<string>("Registarska_oznaka")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("Registarska oznaka");

                    b.HasKey("ID");

                    b.ToTable("Vozilo");
                });

            modelBuilder.Entity("Web_server.Models.ParkingMesto", b =>
                {
                    b.HasOne("Web_server.Models.Garaza", "Garaza")
                        .WithMany("ParkingMesta")
                        .HasForeignKey("GarazaID");

                    b.HasOne("Web_server.Models.Vozilo", "Vozilo")
                        .WithMany()
                        .HasForeignKey("VoziloID");

                    b.Navigation("Garaza");

                    b.Navigation("Vozilo");
                });

            modelBuilder.Entity("Web_server.Models.Garaza", b =>
                {
                    b.Navigation("ParkingMesta");
                });
#pragma warning restore 612, 618
        }
    }
}
