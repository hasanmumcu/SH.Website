using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_DeleteMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure  sp_DeleteMessage
                                ( 
                                   @Subject varchar(200)
                                )        
                                As         
                                begin        
                                   DELETE FROM dbo.AdminContacts WHERE Subject= @Subject;        
                                End ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_DeleteMessage";


            migrationBuilder.Sql(procedure);

        }
    }
}
