using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_GetAllRowsOfViewAdminReadMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_GetAllRowsOfViewAdminReadMail
                                    as
                                    Begin
                                       select   
                                                [to],  
                                                Subject,  
                                                Message,  
                                                Timestamp
                                            from dbo.view_AdminReadMail
                                        End";

            migrationBuilder.Sql(procedure);
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_GetAllRowsOfViewAdminReadMail";


            migrationBuilder.Sql(procedure);
        }
    }
}
