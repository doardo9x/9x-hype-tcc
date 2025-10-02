using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ninexhype.Migrations
{
    /// <inheritdoc />
    public partial class SeedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Foto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tiporoupa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiporoupa", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_usuario_login_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_regra_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_usuario_token_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil_regra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_regra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_perfil_regra_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario_perfil",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_perfil", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_usuario_perfil_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoRoupaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Foto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoria_tiporoupa_TipoRoupaId",
                        column: x => x.TipoRoupaId,
                        principalTable: "tiporoupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    QtdeEstoque = table.Column<int>(type: "int", nullable: false),
                    ValorCusto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Destaque = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "longtext", nullable: true),
                    Cor = table.Column<string>(type: "longtext", nullable: true),
                    Material = table.Column<string>(type: "longtext", nullable: true),
                    AtividadeRecomendada = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produto_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutoFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    ArquivoFoto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoFoto_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "Foto", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", 0, "f39c33c6-9528-40c9-8e4c-13eb08537bee", new DateTime(1981, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "gallojunior@gmail.com", true, "/img/usuarios/ddf093a6-6cb5-4ff7-9a64-83da34aee005.png", true, null, "José Antonio Gallo Junior", "GALLOJUNIOR@GMAIL.COM", "GALLOJUNIOR", "AQAAAAIAAYagAAAAEPSQABJOUNMFiKeaRmUHzkATTgNNov+FrTQAIPk/r+06TV8xm/wKYuI2YW+JqrPWgQ==", null, false, "eaf63937-64ca-43e6-8d8b-51813ef76348", false, "GalloJunior" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee006", 0, "aa4d8682-ad14-43f5-a29d-9a117a7a14e4", new DateTime(1981, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduardo010304@gmail.com", true, "/img/usuarios/ddf093a6-6cb5-4ff7-9a64-83da34aee005.png", true, null, "Eduardo Ribeiro", "EDUARDO010304@GMAIL.COM", "EDUARDORIBEIRO", "AQAAAAIAAYagAAAAEOoLkKyLhSDhFWowmdkbukdkWxpnMlpRLPgXmYWM04LBn99GkokBGpwrNUZn3GMEXg==", null, false, "c0490f2c-f55f-4aee-9204-be990f02731f", false, "EduardoRibeiro" }
                });

            migrationBuilder.InsertData(
                table: "perfil",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", null, "Administrador", "ADMINISTRADOR" },
                    { "bec71b05-8f3d-4849-88bb-0e8d518d2de8", null, "Funcionário", "FUNCIONÁRIO" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", null, "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "tiporoupa",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Roupa" },
                    { 2, "Tenis" }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Foto", "Nome", "TipoRoupaId" },
                values: new object[,]
                {
                    { 1, null, "Tênis", 2 },
                    { 2, null, "Camisas", 1 },
                    { 3, null, "Blusas", 1 },
                    { 4, null, "Jaquetas", 1 },
                    { 5, null, "Shorts", 1 },
                    { 6, null, "Calças", 1 },
                    { 7, null, "Acessórios", 1 },
                    { 8, null, "Destaques", 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario_perfil",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { "bec71b05-8f3d-4849-88bb-0e8d518d2de8", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" }
                });

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "Id", "AtividadeRecomendada", "CategoriaId", "Cor", "Descricao", "Destaque", "Genero", "Marca", "Material", "Nome", "QtdeEstoque", "ValorCusto", "ValorVenda" },
                values: new object[,]
                {
                    { 1, "Casual", 1, "Branco", "Tênis casual branco clássico", false, 3, "Nike", "Couro", "Nike Air Force 1", 25, 300.00m, 449.99m },
                    { 2, "Corrida", 1, "Preto", "Tênis esportivo com amortecimento", false, 3, "Adidas", "Tecido Knit", "Adidas Ultraboost", 18, 380.00m, 599.99m },
                    { 3, "Casual", 1, "Colorido", "Tênis estiloso retrô", false, 1, "Puma", "Tecido e Sintético", "Puma RS-X", 20, 320.00m, 489.90m },
                    { 4, "Skate", 1, "Preto", "Tênis skatista em lona e camurça", false, 1, "Vans", "Lona e Camurça", "Vans Old Skool", 22, 200.00m, 349.99m },
                    { 5, "Casual", 1, "Cinza", "Tênis retrô confortável", false, 3, "New Balance", "Suede e Malha", "New Balance 574", 15, 280.00m, 419.99m },
                    { 6, "Casual", 1, "Preto", "Tênis cano alto icônico", false, 3, "Converse", "Lona", "Converse Chuck Taylor", 30, 150.00m, 269.99m },
                    { 7, "Corrida", 1, "Azul", "Tênis de corrida com suporte", false, 3, "Asics", "Mesh", "Asics Gel-Kayano 28", 12, 400.00m, 649.99m },
                    { 8, "Casual", 1, "Colorido", "Tênis streetwear com cores vibrantes", false, 3, "Nike", "Couro e Sintético", "Nike Dunk Low", 10, 360.00m, 549.99m },
                    { 9, "Corrida", 1, "Preto", "Tênis de performance com amortecimento", false, 1, "Mizuno", "Mesh e Borracha", "Mizuno Wave Prophecy", 8, 500.00m, 799.99m },
                    { 10, "Casual", 1, "Branco", "Tênis chunky retrô", false, 2, "Fila", "Sintético", "Fila Disruptor II", 14, 220.00m, 369.99m },
                    { 11, "Casual", 1, "Branco", "Tênis casual vintage", false, 3, "Reebok", "Couro", "Reebok Classic", 16, 180.00m, 299.99m },
                    { 12, "Corrida", 1, "Preto", "Tênis esportivo respirável", false, 1, "Under Armour", "Tecido Knit", "Under Armour HOVR", 10, 310.00m, 459.99m },
                    { 13, "Casual", 1, "Preto/Vermelho", "Tênis icônico da linha Jordan", false, 1, "Nike Jordan", "Couro", "Jordan 1 Mid", 6, 450.00m, 749.99m },
                    { 14, "Trilha", 1, "Marrom", "Tênis robusto e confortável", false, 1, "Oakley", "Couro e Borracha", "Oakley Modoc", 18, 280.00m, 399.99m },
                    { 15, "Corrida", 1, "Branco/Verde", "Tênis de corrida profissional", false, 1, "Nike", "Mesh", "Nike ZoomX Vaporfly", 5, 600.00m, 999.99m },
                    { 16, "Casual", 2, "Branco", "100% algodão, modelagem larga", false, 1, "9xHype", "Algodão", "Camiseta Oversized Branca", 50, 40.00m, 79.90m },
                    { 17, "Casual", 6, "Preto", "Com bolsos laterais e ajuste no tornozelo", false, 1, "9xHype", "Algodão e Poliéster", "Calça Cargo Preta", 30, 90.00m, 149.99m },
                    { 18, "Esportivo", 4, "Cinza", "Impermeável e leve, ideal para dias chuvosos", false, 3, "9xHype", "Poliéster", "Jaqueta Corta-Vento", 12, 120.00m, 219.99m },
                    { 19, "Casual", 3, "Cinza", "Moletom peluciado unissex", false, 3, "9xHype", "Algodão", "Moletom Liso com Capuz", 25, 80.00m, 129.90m },
                    { 20, "Casual", 5, "Bege", "Estilo casual, com bolsos laterais", false, 1, "9xHype", "Sarja", "Bermuda de Sarja Bege", 35, 60.00m, 99.99m },
                    { 21, "Social", 2, "Branca", "Camisa masculina, algodão, modelagem justa", false, 1, "9xHype", "Algodão", "Camisa Social Slim", 20, 70.00m, 119.99m },
                    { 22, "Casual", 2, "Floral", "Vestido leve para o verão", false, 2, "9xHype", "Viscose", "Vestido Midi Floral", 18, 90.00m, 149.90m },
                    { 23, "Casual", 6, "Azul Jeans", "Jeans com elastano para conforto", false, 3, "9xHype", "Jeans com Elastano", "Calça Jeans Skinny", 28, 100.00m, 169.99m },
                    { 24, "Casual", 4, "Azul Jeans", "Estilo urbano e confortável", false, 2, "9xHype", "Jeans", "Jaqueta Jeans Feminina", 10, 130.00m, 199.99m },
                    { 25, "Casual", 5, "Cinza", "Conforto para o dia a dia", false, 3, "9xHype", "Moletom", "Shorts de Moletom", 40, 50.00m, 89.99m },
                    { 26, "Casual", 2, "Preto", "100% algodão, gola careca", false, 2, "9xHype", "Algodão", "Camiseta Polo Preta Feminina", 60, 35.00m, 69.90m },
                    { 27, "Casual", 2, "Preto", "Look prático e estiloso", false, 2, "9xHype", "Viscose", "Macacão Feminino", 14, 110.00m, 179.99m },
                    { 28, "Casual", 3, "Rosa", "Estilo jovem e leve", false, 2, "9xHype", "Poliéster", "Blusa Cropped Texturizada", 22, 45.00m, 79.99m },
                    { 29, "Casual", 2, "Marrom", "Elegância casual", false, 1, "9xHype", "Algodão", "Camisa Polo Texturizada Masculina Marrom", 19, 65.00m, 109.99m },
                    { 30, "Treino", 2, "Cinza", "Ideal para treinos", false, 3, "9xHype", "Poliéster", "Regata Dry Fit", 50, 30.00m, 59.90m },
                    { 31, "Casual", 8, "Branco", "Tênis casual branco clássico", false, 0, "Nike", "Couro", "Nike Air Force 1", 25, 300.00m, 449.99m },
                    { 32, "Corrida", 8, "Preto", "Tênis esportivo com amortecimento", false, 0, "Adidas", "Tecido Knit", "Adidas Ultraboost", 18, 380.00m, 599.99m },
                    { 33, "Casual", 8, "Colorido", "Tênis estiloso retrô", false, 0, "Puma", "Tecido e Sintético", "Puma RS-X", 20, 320.00m, 489.90m },
                    { 34, "Skate", 8, "Preto", "Tênis skatista em lona e camurça", false, 0, "Vans", "Lona e Camurça", "Vans Old Skool", 22, 200.00m, 349.99m },
                    { 35, "Casual", 8, "Cinza", "Tênis retrô confortável", false, 0, "New Balance", "Suede e Malha", "New Balance 574", 15, 280.00m, 419.99m },
                    { 36, "Casual", 8, "Preto", "Tênis cano alto icônico", false, 0, "Converse", "Lona", "Converse Chuck Taylor", 30, 150.00m, 269.99m },
                    { 37, "Corrida", 8, "Azul", "Tênis de corrida com suporte", false, 0, "Asics", "Mesh", "Asics Gel-Kayano 28", 12, 400.00m, 649.99m },
                    { 38, "Casual", 8, "Colorido", "Tênis streetwear com cores vibrantes", false, 0, "Nike", "Couro e Sintético", "Nike Dunk Low", 10, 360.00m, 549.99m },
                    { 39, "Corrida", 8, "Preto", "Tênis de performance com amortecimento", false, 0, "Mizuno", "Mesh e Borracha", "Mizuno Wave Prophecy", 8, 500.00m, 799.99m },
                    { 40, "Casual", 8, "Branco", "Tênis chunky retrô", false, 0, "Fila", "Sintético", "Fila Disruptor II", 14, 220.00m, 369.99m }
                });

            migrationBuilder.InsertData(
                table: "ProdutoFoto",
                columns: new[] { "Id", "ArquivoFoto", "Descricao", "ProdutoId" },
                values: new object[,]
                {
                    { 1, "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/4f37fca8-6bce-43e7-ad07-f57ae3c13142/AIR+FORCE+1+%2707.png", null, 1 },
                    { 2, "/img/500x500/AdidasUltraboost.png", null, 2 },
                    { 3, "https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa,w_750,h_750/global/395984/02/sv01/fnd/PNA/fmt/png/RS-X-Retro-Resort-Women's-Sneakers", null, 3 },
                    { 4, "https://http2.mlstatic.com/D_NQ_NP_812678-MLB84265928797_052025-O.webp", null, 4 },
                    { 5, "https://nb.scene7.com/is/image/NB/wl574cor_nb_05_i?$pdpflexf2$&qlt=80&fmt=webp&wid=440&hei=440", null, 5 },
                    { 6, "https://www.converse.com/dw/image/v2/BCZC_PRD/on/demandware.static/-/Sites-cnv-master-catalog/default/dw187c312e/images/a_08/M7650_A_08X1.jpg?sw=406", null, 6 },
                    { 7, "https://images.asics.com/is/image/asics/1011B189_001_SR_RT_GLB?$sfcc-product$", null, 7 },
                    { 8, "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/d14fc386-1067-4a72-961e-9f8134680703/W+NIKE+DUNK+LOW.png", null, 8 },
                    { 9, "https://http2.mlstatic.com/D_NQ_NP_825783-MLA74802964877_022024-O.webp", null, 9 },
                    { 10, "https://tse3.mm.bing.net/th/id/OIP.Edb0M5R6mDPgYzo4vrq3dQHaFS?rs=1&pid=ImgDetMain", null, 10 },
                    { 11, "https://tse3.mm.bing.net/th/id/OIP.Edb0M5R6mDPgYzo4vrq3dQHaFS?rs=1&pid=ImgDetMain", null, 10 },
                    { 12, "https://tse3.mm.bing.net/th/id/OIP.Edb0M5R6mDPgYzo4vrq3dQHaFS?rs=1&pid=ImgDetMain", null, 10 },
                    { 13, "/img/500x500/ReebokClassic1.png", null, 11 },
                    { 14, "/img/500x500/ReebokClassic2.png", null, 11 },
                    { 15, "/img/500x500/ReebokClassic3.png", null, 11 },
                    { 16, "/img/500x500/UnderArmourHOVR1.png", null, 12 },
                    { 17, "/img/500x500/UnderArmourHOVR2.png", null, 12 },
                    { 18, "/img/500x500/UnderArmourHOVR3.png", null, 12 },
                    { 19, "/img/500x500/Jordan1Mid1.png", null, 13 },
                    { 20, "/img/500x500/Jordan1Mid2.png", null, 13 },
                    { 21, "/img/500x500/Jordan1Mid3.png", null, 13 },
                    { 22, "/img/500x500/OakleyModoc1.png", null, 14 },
                    { 23, "/img/500x500/OakleyModoc2.png", null, 14 },
                    { 24, "/img/500x500/OakleyModoc3.png", null, 14 },
                    { 25, "/img/500x500/NikeZoomXVaporfly1.png", null, 15 },
                    { 26, "/img/500x500/NikeZoomXVaporfly2.png", null, 15 },
                    { 27, "/img/500x500/NikeZoomXVaporfly3.png", null, 15 },
                    { 28, "/img/500x500/CamisetaOversizedBranca1.png", null, 16 },
                    { 29, "/img/500x500/CamisetaOversizedBranca2.png", null, 16 },
                    { 30, "/img/500x500/CalcaCargoPreta1.png", null, 17 },
                    { 31, "/img/500x500/CalcaCargoPreta2.png", null, 17 },
                    { 32, "/img/500x500/CalcaCargoPreta3.png", null, 17 },
                    { 33, "/img/500x500/JaquetaCortaVento.png", null, 18 },
                    { 34, "/img/500x500/JaquetaCorta-Vento2.png", null, 18 },
                    { 35, "/img/500x500/JaquetaCorta-Vento3.png", null, 18 },
                    { 36, "/img/500x500/MoletomLisoCapuz1.png", null, 19 },
                    { 37, "/img/500x500/MoletomLisoCapuz2.png", null, 19 },
                    { 38, "/img/500x500/MoletomLisoCapuz3.png", null, 19 },
                    { 39, "/img/500x500/BermudaSarjaBege1.png", null, 20 },
                    { 40, "/img/500x500/BermudaSarjaBege1.png", null, 20 },
                    { 41, "/img/500x500/CamisaSocialSlim1.png", null, 21 },
                    { 42, "/img/500x500/CamisaSocialSlim2.png", null, 21 },
                    { 43, "/img/500x500/CamisaSocialSlim3.png", null, 21 },
                    { 44, "/img/500x500/VestidoMidiFloral1.png", null, 22 },
                    { 45, "/img/500x500/VestidoMidiFloral2.png", null, 22 },
                    { 46, "/img/500x500/VestidoMidiFloral3.png", null, 22 },
                    { 47, "/img/500x500/CalçaJeansSkinny1.png", null, 23 },
                    { 48, "/img/500x500/CalçaJeansSkinny2.png", null, 23 },
                    { 49, "/img/500x500/CalçaJeansSkinny3.png", null, 23 },
                    { 50, "/img/500x500/JaquetaJeansFeminina1.png", null, 24 },
                    { 51, "/img/500x500/JaquetaJeansFeminina2.png", null, 24 },
                    { 52, "/img/500x500/ShortsMoletom1.png", null, 25 },
                    { 53, "/img/500x500/ShortsMoletom2.png", null, 25 },
                    { 54, "/img/500x500/ShortsMoletom3.png", null, 25 },
                    { 55, "/img/500x500/CamisetaPoloPretaFeminina1.png", null, 26 },
                    { 56, "/img/500x500/CamisetaPoloPretaFeminina2.png", null, 26 },
                    { 57, "/img/500x500/MacacãoFeminino1.png", null, 27 },
                    { 58, "/img/500x500/MacacãoFeminino2.png", null, 27 },
                    { 59, "/img/500x500/MacacãoFeminino3.png", null, 27 },
                    { 60, "/img/500x500/BlusaCroppedTexturizada1.png", null, 28 },
                    { 61, "/img/500x500/BlusaCroppedTexturizada2.png", null, 28 },
                    { 62, "/img/500x500/BlusaCroppedTexturizada3.png", null, 28 },
                    { 63, "/img/500x500/CamisaPoloTexturizadaMasculinaMarrom1.png", null, 29 },
                    { 64, "/img/500x500/CamisaPoloTexturizadaMasculinaMarrom2.png", null, 29 },
                    { 65, "/img/500x500/RegataDryFit1.png", null, 30 },
                    { 66, "/img/500x500/RegataDryFit2.png", null, 30 },
                    { 97, "/img/FotosCarrossel/fotosGrandes/NikeAirForce1.png", null, 31 },
                    { 98, "/img/FotosCarrossel/fotosGrandes/AdidasUltraboost.png", null, 32 },
                    { 99, "/img/FotosCarrossel/fotosGrandes/PumaRS-X.png", null, 33 },
                    { 100, "/img/FotosCarrossel/fotosGrandes/VansOldSkool.png", null, 34 },
                    { 101, "/img/FotosCarrossel/fotosGrandes/NewBalance574.png", null, 35 },
                    { 102, "/img/FotosCarrossel/fotosGrandes/ConverseChuckTaylor.png", null, 36 },
                    { 103, "/img/FotosCarrossel/fotosGrandes/AsicsGel-Kayano.png", null, 37 },
                    { 104, "/img/FotosCarrossel/fotosGrandes/NikeDunkLow.png", null, 38 },
                    { 105, "/img/FotosCarrossel/fotosGrandes/MizunoWaveProphecy.png", null, 39 },
                    { 106, "/img/FotosCarrossel/fotosGrandes/FilaDisruptorII.png", null, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categoria_TipoRoupaId",
                table: "categoria",
                column: "TipoRoupaId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "perfil",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_perfil_regra_RoleId",
                table: "perfil_regra",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_CategoriaId",
                table: "produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFoto_ProdutoId",
                table: "ProdutoFoto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_login_UserId",
                table: "usuario_login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfil_RoleId",
                table: "usuario_perfil",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_regra_UserId",
                table: "usuario_regra",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfil_regra");

            migrationBuilder.DropTable(
                name: "ProdutoFoto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "usuario_login");

            migrationBuilder.DropTable(
                name: "usuario_perfil");

            migrationBuilder.DropTable(
                name: "usuario_regra");

            migrationBuilder.DropTable(
                name: "usuario_token");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "tiporoupa");
        }
    }
}
