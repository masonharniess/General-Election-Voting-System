using GEVS_API.Controllers;
using GEVS_API.Entities;
using GEVS_API.Services;
using Microsoft.EntityFrameworkCore;
namespace GEVS_API.Context;

public class GevsContext : DbContext
{
    public GevsContext(DbContextOptions<GevsContext> options) : base(options) {}

    public DbSet<UserEntity> UserEntities { get; set; }
    public DbSet<ElectionEntity> ElectionEntities { get; set; }
    public DbSet<CandidateEntity> CandidateEntities { get; set; }
    public DbSet<ConstituencyEntity> ConstituencyEntities { get; set; }
    public DbSet<VoteEntity> VoteEntities { get; set; }
    public DbSet<PartyEntity> PartyEntities { get; set; }
    public DbSet<RoleEntity> RoleEntities { get; set; }
    public DbSet<UvcEntity> UvcEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ROLES

        RoleEntity voter = new RoleEntity()
        {
            Id = new Guid("ee137f00-1c56-49e4-83f8-02c336a287d9"),
            Title = "Voter"
        };

        RoleEntity admin = new RoleEntity()
        {
            Id = new Guid("c8a458ed-01ad-47fe-bdcf-86eb7cc25bb7"),
            Title = "Admin"
        };

        RoleEntity[] roles = new[]
        {
            voter,
            admin
        };

        modelBuilder.Entity<RoleEntity>().HasData(roles);


        // CONSTITUENCIES

        ConstituencyEntity constituencyA = new ConstituencyEntity()
        {
            Id = new Guid("2EB9E977-D88D-4F15-B7A1-49A98BE60EF7"),
            Name = "Shangri-la-Town"
        };

        ConstituencyEntity constituencyB = new ConstituencyEntity()
        {
            Id = new Guid("15AFD41C-99F5-4B66-B1F8-12980103C583"),
            Name = "Northern-Kunlun-Mountain"
        };

        ConstituencyEntity constituencyC = new ConstituencyEntity()
        {
            Id = new Guid("9A876053-F634-40DA-94C3-AED77B7C5E64"),
            Name = "Western-Shangri-la"
        };

        ConstituencyEntity constituencyD = new ConstituencyEntity()
        {
            Id = new Guid("35745314-D6BC-43DD-B108-B1E793126B0A"),
            Name = "Naboo-Vallery"
        };

        ConstituencyEntity constituencyE = new ConstituencyEntity()
        {
            Id = new Guid("F9C66B4E-AB57-4BC7-A8E0-632FEFCF9842"),
            Name = "New-Felucia"
        };

        ConstituencyEntity[] constituencies = new[]
        {
            constituencyA, constituencyB, constituencyC, constituencyD, constituencyE
        };

        modelBuilder.Entity<ConstituencyEntity>().HasData(constituencies);
        
        // PARTIES

        PartyEntity partyA = new PartyEntity()
        {
            Id = new Guid("EC1CD589-3006-46C1-AE7B-F3EF28B758CB"),
            Name = "Blue Party"
        };

        PartyEntity partyB = new PartyEntity()
        {
            Id = new Guid("179C885C-7FFD-4540-A579-2E58A9FB3AFE"),
            Name = "Red Party"
        };

        PartyEntity partyC = new PartyEntity()
        {
            Id = new Guid("3BACEB86-1E40-4E57-A848-C2A0D83D5D0B"),
            Name = "Yellow Party"
        };

        PartyEntity partyD = new PartyEntity()
        {
            Id = new Guid("B2F8DEAB-FCC3-4D66-AA7B-3104D0FE14A1"),
            Name = "Independent"
        };

        PartyEntity[] parties = new[]
        {
            partyA, partyB, partyC, partyD
        };

        modelBuilder.Entity<PartyEntity>().HasData(parties);
        
        // UVCs
        
        UvcEntity[] UVCs = new UvcEntity[] {
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "HH64FWPE", isUsed = true },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "BBMNS9ZJ", isUsed = true },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "KYMK9PUH", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "WL3K3YPT", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "JA9WCMAS", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "Z93G7PN9", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "WPC5GEHA", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "RXLNLTA6", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "7XUFD78Y", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "DBP4GQBQ", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "ZSRBTK9S", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "B7DMPWCQ", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "YADA47RL", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "9GTZQNKB", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "KSM9NB5L", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "BQCRWTSG", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "ML5NSKKG", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "D5BG6FDH", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "2LJFM6PM", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "38NWLPY3", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "2TEHRTHJ", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "G994LD9T", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "Q452KVQE", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "75NKUXAH", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "DHKVCU8T", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "TH9A6HUB", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "2E5BHT5R", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "556JTA32", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "LUFKZAHW", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "DBAD57ZR", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "K96JNSXY", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "PFXB8QXM", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "8TEXF2HD", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "N6HBFD2X", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "K3EVS3NM", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "5492AC6V", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "U5LGC65X", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "BKMKJN5S", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "JF2QD3UF", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "NW9ETHS7", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "VFBH8W6W", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "7983XU4M", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "2GYDT5D3", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "LVTFN8G5", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "UNP4A5T7", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "UMT3RLVS", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "TZZZCJV8", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "UVE5M7FR", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "W44QP7XJ", isUsed = false },
            new UvcEntity() { Id = Guid.NewGuid(), UniqueVoterCode = "9FCV9RMT", isUsed = false },
        };
        
        modelBuilder.Entity<UvcEntity>().HasData(UVCs);
        
        // Users

        HashingService hash = new HashingService();
        
        UserEntity user1 = new UserEntity()
        {
            Id = new Guid("edcd167a-2475-47d1-8170-aa5d85879ccb"),
            Email = "test@outlook.com",
            Password = hash.HashPassword("Pass"),
            Name = "Mason Harniess",
            DoB = new DateOnly(2001, 2, 14),
            RoleId = voter.Id,
            ConstituencyId = constituencyA.Id,
            UvcId = UVCs[0].Id,
        };

        modelBuilder.Entity<UserEntity>().HasData(user1);
        
        UserEntity user2 = new UserEntity()
        {
            Id = new Guid("C8A458ED-01AD-47FE-BDCF-86EB7CC25BB7"),
            Email = "election@shangrila.gov.sr",
            Password = hash.HashPassword("shangrila2024$") ,
            Name = "Admin",
            DoB = new DateOnly(2000, 1, 1),
            RoleId = admin.Id,
            ConstituencyId = constituencyA.Id,
            UvcId = UVCs[3].Id,
        };
        
        modelBuilder.Entity<UserEntity>().HasData(user2);
        
        // CANDIDATE

        CandidateEntity candidate1 = new CandidateEntity()
        {
            Id = new Guid("34755256-2C12-4D88-A0BA-5D325850AFE1"),
            Name = "John Politician",
            ConstituencyId = constituencyA.Id,
            PartyId = partyA.Id
        };

        modelBuilder.Entity<CandidateEntity>().HasData(candidate1);
        
        CandidateEntity candidate2 = new CandidateEntity()
        {
            Id = new Guid("D8317768-C9D7-4CF9-AF5D-7FE035A04456"),
            Name = "George Sears",
            ConstituencyId = constituencyB.Id,
            PartyId = partyB.Id
        };

        modelBuilder.Entity<CandidateEntity>().HasData(candidate2);
        
        CandidateEntity candidate3 = new CandidateEntity()
        {
            Id = new Guid("B501397B-49B8-4C4A-805E-D6C1244DCD2A"),
            Name = "Steven Armstrong",
            ConstituencyId = constituencyC.Id,
            PartyId = partyC.Id
        };

        modelBuilder.Entity<CandidateEntity>().HasData(candidate3);
        
        CandidateEntity candidate4 = new CandidateEntity()
        {
            Id = new Guid("25A5F7F5-BAC1-4D4A-BD23-DC4A06821933"),
            Name = "David Oh",
            ConstituencyId = constituencyD.Id,
            PartyId = partyD.Id
        };

        modelBuilder.Entity<CandidateEntity>().HasData(candidate4);

        // VOTES

        VoteEntity vote1 = new VoteEntity()
        {
            Id = new Guid("322CDB1F-2396-4F47-8AE2-188E067F315B"),
            UserId = user1.Id,
            CandidateId = candidate1.Id
        };

        modelBuilder.Entity<VoteEntity>().HasData(vote1);
    }
}