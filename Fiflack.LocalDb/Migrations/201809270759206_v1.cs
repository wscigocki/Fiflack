namespace Fiflack.LocalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompetitionMatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Competition_Id = c.Int(),
                        Match_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id)
                .ForeignKey("dbo.MatchScores", t => t.Match_Id)
                .Index(t => t.Competition_Id)
                .Index(t => t.Match_Id);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatchScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoalsOfPlayer_1 = c.Int(nullable: false),
                        GoalsOfPlayer_2 = c.Int(nullable: false),
                        Player_1_Id = c.Int(),
                        Player_2_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_1_Id)
                .ForeignKey("dbo.Players", t => t.Player_2_Id)
                .Index(t => t.Player_1_Id)
                .Index(t => t.Player_2_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompetitionMatches", "Match_Id", "dbo.MatchScores");
            DropForeignKey("dbo.MatchScores", "Player_2_Id", "dbo.Players");
            DropForeignKey("dbo.MatchScores", "Player_1_Id", "dbo.Players");
            DropForeignKey("dbo.CompetitionMatches", "Competition_Id", "dbo.Competitions");
            DropIndex("dbo.Players", new[] { "Login" });
            DropIndex("dbo.MatchScores", new[] { "Player_2_Id" });
            DropIndex("dbo.MatchScores", new[] { "Player_1_Id" });
            DropIndex("dbo.CompetitionMatches", new[] { "Match_Id" });
            DropIndex("dbo.CompetitionMatches", new[] { "Competition_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.MatchScores");
            DropTable("dbo.Competitions");
            DropTable("dbo.CompetitionMatches");
        }
    }
}
