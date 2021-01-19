using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_DeleteMessageFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_DeleteMessageFromUser       
                                ( 
                                   @Subject varchar(200)
                                )        
                                As         
                                begin        
                                   DELETE FROM dbo.UserContacts WHERE Subject= @Subject;        
                                End ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_DeleteMessageFromUser";


            migrationBuilder.Sql(procedure);
        }
    }
}
