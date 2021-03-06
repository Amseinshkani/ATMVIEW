// <auto-generated />
using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TrueATM.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Entity.TblUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("HolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassWord")
                        .HasColumnType("int");

                    b.Property<long>("cash")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("tblUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
