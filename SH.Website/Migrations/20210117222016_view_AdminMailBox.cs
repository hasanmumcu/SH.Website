using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class view_AdminMailBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string view = @"CREATE VIEW view_AdminMailBox AS
                            SELECT  [to],         
                                    a.Subject,                       
                                    a.Message,               
                                    a.Timestamp            
                                    from dbo.AnalystContacts
                                    AS a JOIN dbo.Registers AS  r  
                                    ON [to] = r.Email WHERE r.ACCESS_LEVEL = 'DIRECTOR' ;  
                                    GO";

            migrationBuilder.Sql(view);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string view = @"Drop view view_AdminMailBox";


            migrationBuilder.Sql(view);
        }
    }
}
