using Microsoft.EntityFrameworkCore.Migrations;

namespace SH.Website.Migrations
{
    public partial class spUpdateProjectByName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spUpdateProjectByName(
                                    @projectName VarChar(200), @projectDescription VarChar(200), @status VarChar(200), @clientCompany VarChar(200), @projectLeader VarChar(200), @estimatedBudget VarChar(200), @totalAmountSpent VarChar(200), @estimatedProjectDuration VarChar(200) )
                                    as
                                    Begin
                                        UPDATE dbo.Projects SET  projectDescription = @projectDescription ,status = @status, clientCompany =@clientCompany, projectLeader =@projectLeader, estimatedBudget =@estimatedBudget,  totalAmountSpent =@totalAmountSpent, estimatedProjectDuration =@estimatedProjectDuration  WHERE projectName =@projectName
                                    End";

            migrationBuilder.Sql(procedure);


                                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spUpdateProjectByName";

            migrationBuilder.Sql(procedure);
        }
    }
}
