using Microsoft.EntityFrameworkCore.Migrations;

namespace Parser.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageUploads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageUploads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainChunks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageUploadTransactionId = table.Column<int>(nullable: false),
                    FinancialInstitution = table.Column<string>(nullable: true),
                    FXSettlementDate = table.Column<string>(nullable: true),
                    ReconciliationFileID = table.Column<string>(nullable: true),
                    TransactionCurrency = table.Column<string>(nullable: true),
                    ReconciliationCurrency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainChunks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainChunks_PageUploads_PageUploadTransactionId",
                        column: x => x.PageUploadTransactionId,
                        principalTable: "PageUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainChunkDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainChunkId = table.Column<int>(nullable: false),
                    SettlementCategory = table.Column<string>(nullable: true),
                    TransactionAmountCredit = table.Column<double>(nullable: false),
                    ReconciliationAmntCredit = table.Column<double>(nullable: false),
                    FeeAmountCredit = table.Column<double>(nullable: false),
                    TransactionAmountDebit = table.Column<double>(nullable: false),
                    ReconciliationAmntDebit = table.Column<double>(nullable: false),
                    FeeAmountDebit = table.Column<double>(nullable: false),
                    CountTotal = table.Column<int>(nullable: false),
                    NetValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainChunkDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainChunkDetails_MainChunks_MainChunkId",
                        column: x => x.MainChunkId,
                        principalTable: "MainChunks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainChunkDetails_MainChunkId",
                table: "MainChunkDetails",
                column: "MainChunkId");

            migrationBuilder.CreateIndex(
                name: "IX_MainChunks_PageUploadTransactionId",
                table: "MainChunks",
                column: "PageUploadTransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainChunkDetails");

            migrationBuilder.DropTable(
                name: "MainChunks");

            migrationBuilder.DropTable(
                name: "PageUploads");
        }
    }
}
