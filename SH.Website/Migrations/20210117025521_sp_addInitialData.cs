using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_addInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_addInitialData       
                                (      
                                    @Id VARCHAR(500),    
                                    @Name varchar(100),     
                                    @Email VARCHAR(100),      
                                    @Password VARCHAR(100),      
                                    @ConfirmPassword VARCHAR(100),  
                                    @ACCESS_LEVEL varchar(100),  
                                    @WRITE_ACCESS varchar(100),   
                                    @Active varchar(100),
                                    @Timestamp varchar(100)     
                                )
                                As       
                                Begin       
                                    Insert into dbo.Registers (Id,Name,Email,Password, ConfirmPassword,ACCESS_LEVEL,WRITE_ACCESS,Active,Timestamp)       
                                    Values (@Id,@Name,@Email,@Password, @ConfirmPassword,@ACCESS_LEVEL, @WRITE_ACCESS,@Active,@Timestamp)      
                                End";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_addInitialData";


            migrationBuilder.Sql(procedure);
        }
    }
}
