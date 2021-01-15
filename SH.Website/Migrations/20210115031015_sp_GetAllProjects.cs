using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class sp_GetAllProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string procedure = @"Create procedure sp_GetAllProjects
                                    as
                                    Begin
                                       select   
                                                projectName,  
                                                projectDescription,  
                                                status,  
                                                clientCompany,  
                                                projectLeader,      
                                                estimatedBudget,  
                                                totalAmountSpent,  
                                                estimatedProjectDuration  
                                            from dbo.Projects      
                                        End";

            migrationBuilder.Sql(procedure);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure sp_GetAllProjects";


            migrationBuilder.Sql(procedure);

        }
    }
}
