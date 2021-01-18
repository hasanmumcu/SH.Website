using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_GetAllRowsOfViewUserMailBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_GetAllRowsOfViewUserMailBox
                                    as
                                    Begin
                                       select   
                                                [to],  
                                                Subject,  
                                                Message,  
                                                Timestamp
                                            from dbo.view_UserMailBox
                                        End";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_GetAllRowsOfViewUserMailBox";


            migrationBuilder.Sql(procedure);
        }
    }
}
