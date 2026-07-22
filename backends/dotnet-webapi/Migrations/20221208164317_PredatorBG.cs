using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class PredatorBG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avatars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    Imagepath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ETeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagepath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PChar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Character = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PChar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    DamageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PredatorGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeRound = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Phase = table.Column<int>(type: "int", nullable: false),
                    ActivePlayer = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    SpecialValue = table.Column<int>(type: "int", nullable: false),
                    SpecialMissed = table.Column<int>(type: "int", nullable: false),
                    HillsId = table.Column<int>(type: "int", nullable: true),
                    RuinsId = table.Column<int>(type: "int", nullable: true),
                    RiverId = table.Column<int>(type: "int", nullable: true),
                    GraveyardId = table.Column<int>(type: "int", nullable: true),
                    UndergroundId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredatorGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredatorGame_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayersNum = table.Column<int>(type: "int", nullable: false),
                    LobbyGameId = table.Column<int>(type: "int", nullable: true),
                    Movie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lobbies_PredatorGame_LobbyGameId",
                        column: x => x.LobbyGameId,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    Imagepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurAtt = table.Column<int>(type: "int", nullable: false),
                    CurRec = table.Column<int>(type: "int", nullable: false),
                    OnTurn = table.Column<bool>(type: "bit", nullable: false),
                    MarkNum = table.Column<int>(type: "int", nullable: false),
                    Avoid = table.Column<int>(type: "int", nullable: false),
                    Scan = table.Column<int>(type: "int", nullable: false),
                    Kill = table.Column<int>(type: "int", nullable: false),
                    Convert = table.Column<int>(type: "int", nullable: false),
                    Heal = table.Column<int>(type: "int", nullable: false),
                    HealMin = table.Column<int>(type: "int", nullable: false),
                    Free = table.Column<int>(type: "int", nullable: false),
                    Coordinated = table.Column<bool>(type: "bit", nullable: false),
                    GotCoord = table.Column<int>(type: "int", nullable: false),
                    PredatorGameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_PredatorGame_PredatorGameId",
                        column: x => x.PredatorGameId,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredatorGameId4 = table.Column<int>(type: "int", nullable: true),
                    Dmg = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    PredatorGameId = table.Column<int>(type: "int", nullable: true),
                    PredatorGameId1 = table.Column<int>(type: "int", nullable: true),
                    Health = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    FaceDown = table.Column<bool>(type: "bit", nullable: true),
                    Enemy_PredatorGameId = table.Column<int>(type: "int", nullable: true),
                    Enemy_PredatorGameId1 = table.Column<int>(type: "int", nullable: true),
                    PredatorGameId2 = table.Column<int>(type: "int", nullable: true),
                    PredatorGameId3 = table.Column<int>(type: "int", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    Playable_TeamId = table.Column<int>(type: "int", nullable: true),
                    AttPoint = table.Column<int>(type: "int", nullable: true),
                    RecPoint = table.Column<int>(type: "int", nullable: true),
                    Activated = table.Column<bool>(type: "bit", nullable: true),
                    CoordinateBy = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Playable_PlayerId = table.Column<int>(type: "int", nullable: true),
                    PlayerId1 = table.Column<int>(type: "int", nullable: true),
                    PlayerId2 = table.Column<int>(type: "int", nullable: true),
                    PlayerId3 = table.Column<int>(type: "int", nullable: true),
                    Playable_PredatorGameId = table.Column<int>(type: "int", nullable: true),
                    Playable_PredatorGameId1 = table.Column<int>(type: "int", nullable: true),
                    Playable_PredatorGameId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_ETeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "ETeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PChar_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "PChar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PClass_ClassId",
                        column: x => x.ClassId,
                        principalTable: "PClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Player_Playable_PlayerId",
                        column: x => x.Playable_PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Player_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Player_PlayerId2",
                        column: x => x.PlayerId2,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Player_PlayerId3",
                        column: x => x.PlayerId3,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_Enemy_PredatorGameId",
                        column: x => x.Enemy_PredatorGameId,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_Enemy_PredatorGameId1",
                        column: x => x.Enemy_PredatorGameId1,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_Playable_PredatorGameId",
                        column: x => x.Playable_PredatorGameId,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_Playable_PredatorGameId1",
                        column: x => x.Playable_PredatorGameId1,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_Playable_PredatorGameId2",
                        column: x => x.Playable_PredatorGameId2,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_PredatorGameId",
                        column: x => x.PredatorGameId,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_PredatorGameId1",
                        column: x => x.PredatorGameId1,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_PredatorGameId2",
                        column: x => x.PredatorGameId2,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_PredatorGameId3",
                        column: x => x.PredatorGameId3,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PredatorGame_PredatorGameId4",
                        column: x => x.PredatorGameId4,
                        principalTable: "PredatorGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_PTeam_Playable_TeamId",
                        column: x => x.Playable_TeamId,
                        principalTable: "PTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    PlayableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSkill_Cards_PlayableId",
                        column: x => x.PlayableId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CharacterId",
                table: "Cards",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ClassId",
                table: "Cards",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Enemy_PredatorGameId",
                table: "Cards",
                column: "Enemy_PredatorGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Enemy_PredatorGameId1",
                table: "Cards",
                column: "Enemy_PredatorGameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Playable_PlayerId",
                table: "Cards",
                column: "Playable_PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Playable_PredatorGameId",
                table: "Cards",
                column: "Playable_PredatorGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Playable_PredatorGameId1",
                table: "Cards",
                column: "Playable_PredatorGameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Playable_PredatorGameId2",
                table: "Cards",
                column: "Playable_PredatorGameId2");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Playable_TeamId",
                table: "Cards",
                column: "Playable_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerId",
                table: "Cards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerId1",
                table: "Cards",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerId2",
                table: "Cards",
                column: "PlayerId2");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerId3",
                table: "Cards",
                column: "PlayerId3");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PredatorGameId",
                table: "Cards",
                column: "PredatorGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PredatorGameId1",
                table: "Cards",
                column: "PredatorGameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PredatorGameId2",
                table: "Cards",
                column: "PredatorGameId2");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PredatorGameId3",
                table: "Cards",
                column: "PredatorGameId3");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PredatorGameId4",
                table: "Cards",
                column: "PredatorGameId4");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TeamId",
                table: "Cards",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DSkill_DamageId",
                table: "DSkill",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_ESkill_EnemyId",
                table: "ESkill",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_LobbyGameId",
                table: "Lobbies",
                column: "LobbyGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PredatorGameId",
                table: "Player",
                column: "PredatorGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PredatorGame_GraveyardId",
                table: "PredatorGame",
                column: "GraveyardId");

            migrationBuilder.CreateIndex(
                name: "IX_PredatorGame_HillsId",
                table: "PredatorGame",
                column: "HillsId");

            migrationBuilder.CreateIndex(
                name: "IX_PredatorGame_LocationId",
                table: "PredatorGame",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PredatorGame_RiverId",
                table: "PredatorGame",
                column: "RiverId");

            migrationBuilder.CreateIndex(
                name: "IX_PredatorGame_RuinsId",
                table: "PredatorGame",
                column: "RuinsId");

            migrationBuilder.CreateIndex(
                name: "IX_PredatorGame_UndergroundId",
                table: "PredatorGame",
                column: "UndergroundId");

            migrationBuilder.CreateIndex(
                name: "IX_PSkill_PlayableId",
                table: "PSkill",
                column: "PlayableId");

            migrationBuilder.AddForeignKey(
                name: "FK_DSkill_Cards_DamageId",
                table: "DSkill",
                column: "DamageId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ESkill_Cards_EnemyId",
                table: "ESkill",
                column: "EnemyId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PredatorGame_Cards_GraveyardId",
                table: "PredatorGame",
                column: "GraveyardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PredatorGame_Cards_HillsId",
                table: "PredatorGame",
                column: "HillsId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PredatorGame_Cards_RiverId",
                table: "PredatorGame",
                column: "RiverId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PredatorGame_Cards_RuinsId",
                table: "PredatorGame",
                column: "RuinsId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PredatorGame_Cards_UndergroundId",
                table: "PredatorGame",
                column: "UndergroundId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_ETeam_TeamId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PChar_CharacterId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PClass_ClassId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Player_Playable_PlayerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Player_PlayerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Player_PlayerId1",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Player_PlayerId2",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Player_PlayerId3",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_Enemy_PredatorGameId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_Enemy_PredatorGameId1",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_Playable_PredatorGameId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_Playable_PredatorGameId1",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_Playable_PredatorGameId2",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_PredatorGameId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_PredatorGameId1",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_PredatorGameId2",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_PredatorGameId3",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PredatorGame_PredatorGameId4",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Avatars");

            migrationBuilder.DropTable(
                name: "DSkill");

            migrationBuilder.DropTable(
                name: "ESkill");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "PSkill");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ETeam");

            migrationBuilder.DropTable(
                name: "PChar");

            migrationBuilder.DropTable(
                name: "PClass");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "PredatorGame");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PTeam");
        }
    }
}
