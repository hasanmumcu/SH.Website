using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_UpdateProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure sp_UpdateProject        
                                (        
                                   @projectDescription  VARCHAR(200),   
                                   @status VARCHAR(200),  
                                   @clientCompany VARCHAR(200),        
                                   @projectLeader  VARCHAR(200),      
                                   @estimatedBudget VARCHAR(200),      
                                   @totalAmountSpent	 VARCHAR(200), 
                                   @estimatedProjectDuration  VARCHAR(200)
                                )        
                                As        
                                begin        
                                   Update dbo.Projects         
                                   set projectDescription = @projectDescription,  
                                   status=@status,  
                                   clientCompany=@clientCompany,      
                                   projectLeader=@projectLeader,        
                                   estimatedBudget=@estimatedBudget,      
                                   totalAmountSpent=@totalAmountSpent,   
                                   estimatedProjectDuration=@estimatedProjectDuration   
      
                                End ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_UpdateProject";


            migrationBuilder.Sql(procedure);
        }
    }
}