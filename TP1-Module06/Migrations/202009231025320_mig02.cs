namespace TP1_Module06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SamouraiArtMartials", "Samourai_Id", "dbo.Samourais");
            DropForeignKey("dbo.SamouraiArtMartials", "ArtMartial_Id", "dbo.ArtMartials");
            AddForeignKey("dbo.SamouraiArtMartials", "Samourai_Id", "dbo.Samourais", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SamouraiArtMartials", "ArtMartial_Id", "dbo.ArtMartials", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SamouraiArtMartials", "ArtMartial_Id", "dbo.ArtMartials");
            DropForeignKey("dbo.SamouraiArtMartials", "Samourai_Id", "dbo.Samourais");
            AddForeignKey("dbo.SamouraiArtMartials", "ArtMartial_Id", "dbo.ArtMartials", "Id");
            AddForeignKey("dbo.SamouraiArtMartials", "Samourai_Id", "dbo.Samourais", "Id");
        }
    }
}
