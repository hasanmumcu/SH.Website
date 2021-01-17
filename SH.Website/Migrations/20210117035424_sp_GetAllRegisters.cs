using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_GetAllRegisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_GetAllRegisters
                                    as
                                    Begin
                                       select   
                                                Id,  
                                                Name,  
                                                Email,  
                                                Password,  
                                                ConfirmPassword,      
                                                ACCESS_LEVEL,  
                                                WRITE_ACCESS,  
                                                Active,
                                                Timestamp
                                            from dbo.Registers      
                                        End";

            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_GetAllRegisters";


            migrationBuilder.Sql(procedure);
        }
    }
}
