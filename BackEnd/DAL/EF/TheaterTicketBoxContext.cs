using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
	public class TheaterTicketBoxContext : IdentityDbContext
	{
		public TheaterTicketBoxContext()
		   : base("name=MyDbConnection")
		{
			Database.SetInitializer<TheaterTicketBoxContext>(new Initializer());
		}

		public DbSet<Hall> Halls { get; set; }
		public DbSet<Performance> Performances { get; set; }
		public DbSet<Seat> Seats { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<UserProfile> Profiles { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			base.OnModelCreating(modelBuilder);
		}

	}
	public class Initializer : DropCreateDatabaseIfModelChanges<TheaterTicketBoxContext>
	{
		protected override void Seed(TheaterTicketBoxContext context)
		{
			var managerUser = new MyUserManager(new UserStore<UserLogin>(context));
			var managerRole = new MyRoleManager(new RoleStore<UserRole>(context));

			UserRole role1 = new UserRole { Name = "Main admin" };
			UserRole role2 = new UserRole { Name = "Admin" };
			UserRole role3 = new UserRole { Name = "User" };
			managerRole.Create(role1);
			managerRole.Create(role2);
			managerRole.Create(role3);

			UserLogin admin = new UserLogin { Email = "egor_egor2009@ukr.net",UserName = "egor_egor2009@ukr.net",
				PhoneNumber = "0973701542" };
			managerUser.Create(admin, "Qwerty12");
			UserLogin user1 = new UserLogin { Email = "useremail1@user.mail", UserName = "useremail1@user.mail",
				PhoneNumber = "1234554321" };
			managerUser.Create(user1, "Qwerty12");
		

			UserProfile profile1 = new UserProfile()
			{
				Name = "Egor",
				Surname = "Pavlenko",
				UserLogin = admin
			};
			UserProfile profile2 = new UserProfile()
			{
				Name = "Vasiliy",
				Surname = "Petrov",
				UserLogin = user1
			};
			Performance performance1 = new Performance()
			{
				Name = "Love",
				Author = "Author1",
				Director = "Director1",
				Genre = "Genre1",
				PhotoPath = "https://localhost:44310/Photos/photo1.jpg"
			};
			Hall hall = new Hall()
			{
				Name = "Hall1",
				NumberOfSeats = 200,
				NumberOfRows = 10,
				NumberOfSeatsInRow = 20,
			};
			List<Seat> seats = new List<Seat>();
			for (int i = 1; i <= hall.NumberOfRows; i++)
			{
				for (int k = 1; k <= hall.NumberOfSeatsInRow; k++)
				{
					Seat seat = new Seat
					{
						HallId = hall.Id,
						Hall = hall,
						SeatNumber = k,
						RowNumber = i
					};
					seats.Add(seat);
					context.Seats.Add(seat);
				}
			}

			hall.Seats = seats;
			context.Halls.Add(hall);
			context.SaveChanges();
			Hall hall2 = new Hall()
			{
				Name = "Hall2",
				NumberOfSeats = 200,
				NumberOfRows = 20,
				NumberOfSeatsInRow = 10,
			};
			List<Seat> seats2 = new List<Seat>();
			for (int i = 1; i <= hall2.NumberOfRows; i++)
			{
				for (int k = 1; k <= hall2.NumberOfSeatsInRow; k++)
				{
					Seat seat = new Seat
					{
						HallId = hall2.Id,
						Hall = hall2,
						SeatNumber = k,
						RowNumber = i
					};
					seats2.Add(seat);
					context.Seats.Add(seat);
				}
			}
			hall2.Seats = seats2;
			context.Halls.Add(hall2);
			context.Performances.Add(performance1);
			

			context.Profiles.Add(profile1);
			context.Profiles.Add(profile2);

			context.SaveChanges();
		
            managerUser.AddToRole(admin.Id, role1.Name);
			managerUser.AddToRole(admin.Id, role2.Name);
			managerUser.AddToRole(admin.Id, role3.Name);
			managerUser.AddToRole(user1.Id, role3.Name);
			
			context.SaveChanges();

			

			base.Seed(context);
		}
	}
}
