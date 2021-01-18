using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_GetAllRowsOfViewAdminMailBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_GetAllRowsOfViewAdminMailBox
                                    as
                                    Begin
                                       select   
                                                [to],  
                                                Subject,  
                                                Message,  
                                                Timestamp
                                            from dbo.view_AdminMailBox
                                        End";

            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_GetAllRowsOfViewAdminMailBox";


            migrationBuilder.Sql(procedure);
        }
    }
}
