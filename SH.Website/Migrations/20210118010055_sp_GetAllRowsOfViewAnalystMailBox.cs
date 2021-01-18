using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_GetAllRowsOfViewAnalystMailBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_GetAllRowsOfViewAnalystMailBox
                                    as
                                    Begin
                                       select   
                                                [to],  
                                                Subject,  
                                                Message,  
                                                Timestamp
                                            from dbo.view_AnalystMailBox
                                        End";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_GetAllRowsOfViewAnalystMailBox";


            migrationBuilder.Sql(procedure);
        }
    }
}
