using ninexhype.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ninexhype.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Categoria> categorias = new() {
            new Categoria { Id = 1, Nome = "Tenis" },
            new Categoria { Id = 2, Nome = "Roupas" },
        };
        builder.Entity<Categoria>().HasData(categorias);

        List<Produto> produtos = new List<Produto>
        {
            // Tenis
            new Produto { Id = 1, CategoriaId = 1, Nome = "Nike Air Force 1", Descricao = "Tênis casual branco clássico", ValorCusto = 300.00m, ValorVenda = 449.99m, QtdeEstoque = 25, Destaque = true },
            new Produto { Id = 2, CategoriaId = 1, Nome = "Adidas Ultraboost", Descricao = "Tênis esportivo com amortecimento", ValorCusto = 380.00m, ValorVenda = 599.99m, QtdeEstoque = 18, Destaque = true },
            new Produto { Id = 3, CategoriaId = 1, Nome = "Puma RS-X", Descricao = "Tênis estiloso retrô", ValorCusto = 320.00m, ValorVenda = 489.90m, QtdeEstoque = 20, Destaque = true},
            new Produto { Id = 4, CategoriaId = 1, Nome = "Vans Old Skool", Descricao = "Tênis skatista em lona e camurça", ValorCusto = 200.00m, ValorVenda = 349.99m, QtdeEstoque = 22, Destaque = true},
            new Produto { Id = 5, CategoriaId = 1, Nome = "New Balance 574", Descricao = "Tênis retrô confortável", ValorCusto = 280.00m, ValorVenda = 419.99m, QtdeEstoque = 15 },
            new Produto { Id = 6, CategoriaId = 1, Nome = "Converse Chuck Taylor", Descricao = "Tênis cano alto icônico", ValorCusto = 150.00m, ValorVenda = 269.99m, QtdeEstoque = 30 },
            new Produto { Id = 7, CategoriaId = 1, Nome = "Asics Gel-Kayano 28", Descricao = "Tênis de corrida com suporte", ValorCusto = 400.00m, ValorVenda = 649.99m, QtdeEstoque = 12 },
            new Produto { Id = 8, CategoriaId = 1, Nome = "Nike Dunk Low", Descricao = "Tênis streetwear com cores vibrantes", ValorCusto = 360.00m, ValorVenda = 549.99m, QtdeEstoque = 10 },
            new Produto { Id = 9, CategoriaId = 1, Nome = "Mizuno Wave Prophecy", Descricao = "Tênis de performance com amortecimento", ValorCusto = 500.00m, ValorVenda = 799.99m, QtdeEstoque = 8 },
            new Produto { Id = 10, CategoriaId = 1, Nome = "Fila Disruptor II", Descricao = "Tênis chunky retrô", ValorCusto = 220.00m, ValorVenda = 369.99m, QtdeEstoque = 14 },
            new Produto { Id = 11, CategoriaId = 1, Nome = "Reebok Classic", Descricao = "Tênis casual vintage", ValorCusto = 180.00m, ValorVenda = 299.99m, QtdeEstoque = 16 },
            new Produto { Id = 12, CategoriaId = 1, Nome = "Under Armour HOVR", Descricao = "Tênis esportivo respirável", ValorCusto = 310.00m, ValorVenda = 459.99m, QtdeEstoque = 10 },
            new Produto { Id = 13, CategoriaId = 1, Nome = "Jordan 1 Mid", Descricao = "Tênis icônico da linha Jordan", ValorCusto = 450.00m, ValorVenda = 749.99m, QtdeEstoque = 6 },
            new Produto { Id = 14, CategoriaId = 1, Nome = "Oakley Modoc", Descricao = "Tênis robusto e confortável", ValorCusto = 280.00m, ValorVenda = 399.99m, QtdeEstoque = 18 },
            new Produto { Id = 15, CategoriaId = 1, Nome = "Nike ZoomX Vaporfly", Descricao = "Tênis de corrida profissional", ValorCusto = 600.00m, ValorVenda = 999.99m, QtdeEstoque = 5 },
            // Roupas

            new Produto { Id = 16, CategoriaId = 2, Nome = "Camiseta Oversized Branca", Descricao = "100% algodão, modelagem larga", ValorCusto = 40.00m, ValorVenda = 79.90m, QtdeEstoque = 50, Destaque = true },
            new Produto { Id = 17, CategoriaId = 2, Nome = "Calça Cargo Preta", Descricao = "Com bolsos laterais e ajuste no tornozelo", ValorCusto = 90.00m, ValorVenda = 149.99m, QtdeEstoque = 30, Destaque = true},
            new Produto { Id = 18, CategoriaId = 2, Nome = "Jaqueta Corta-Vento", Descricao = "Impermeável e leve, ideal para dias chuvosos", ValorCusto = 120.00m, ValorVenda = 219.99m, QtdeEstoque = 12, Destaque = true},
            new Produto { Id = 19, CategoriaId = 2, Nome = "Moletom Liso com Capuz", Descricao = "Moletom peluciado unissex", ValorCusto = 80.00m, ValorVenda = 129.90m, QtdeEstoque = 25, Destaque = true},
            new Produto { Id = 20, CategoriaId = 2, Nome = "Bermuda de Sarja Bege", Descricao = "Estilo casual, com bolsos laterais", ValorCusto = 60.00m, ValorVenda = 99.99m, QtdeEstoque = 35, Destaque = true},
            new Produto { Id = 21, CategoriaId = 2, Nome = "Camisa Social Slim", Descricao = "Camisa masculina, algodão, modelagem justa", ValorCusto = 70.00m, ValorVenda = 119.99m, QtdeEstoque = 20 },
            new Produto { Id = 22, CategoriaId = 2, Nome = "Vestido Midi Floral", Descricao = "Vestido leve para o verão", ValorCusto = 90.00m, ValorVenda = 149.90m, QtdeEstoque = 18 },
            new Produto { Id = 23, CategoriaId = 2, Nome = "Calça Jeans Skinny", Descricao = "Jeans com elastano para conforto", ValorCusto = 100.00m, ValorVenda = 169.99m, QtdeEstoque = 28 },
            new Produto { Id = 24, CategoriaId = 2, Nome = "Jaqueta Jeans Oversized", Descricao = "Estilo urbano e confortável", ValorCusto = 130.00m, ValorVenda = 199.99m, QtdeEstoque = 10 },
            new Produto { Id = 25, CategoriaId = 2, Nome = "Shorts de Moletom", Descricao = "Conforto para o dia a dia", ValorCusto = 50.00m, ValorVenda = 89.99m, QtdeEstoque = 40 },
            new Produto { Id = 26, CategoriaId = 2, Nome = "Camiseta Básica Preta", Descricao = "100% algodão, gola careca", ValorCusto = 35.00m, ValorVenda = 69.90m, QtdeEstoque = 60 },
            new Produto { Id = 27, CategoriaId = 2, Nome = "Macacão Feminino", Descricao = "Look prático e estiloso", ValorCusto = 110.00m, ValorVenda = 179.99m, QtdeEstoque = 14 },
            new Produto { Id = 28, CategoriaId = 2, Nome = "Blusa Cropped Canelada", Descricao = "Estilo jovem e leve", ValorCusto = 45.00m, ValorVenda = 79.99m, QtdeEstoque = 22 },
            new Produto { Id = 29, CategoriaId = 2, Nome = "Camisa Polo Masculina", Descricao = "Elegância casual", ValorCusto = 65.00m, ValorVenda = 109.99m, QtdeEstoque = 19 },
            new Produto { Id = 30, CategoriaId = 2, Nome = "Regata Dry Fit", Descricao = "Ideal para treinos", ValorCusto = 30.00m, ValorVenda = 59.90m, QtdeEstoque = 50 }
};
        builder.Entity<Produto>().HasData(produtos);

        List<ProdutoFoto> produtoFotos = new List<ProdutoFoto>
        {
    // Produto 1 - Nike Air Force 1
    new ProdutoFoto { Id = 1, ProdutoId = 1, ArquivoFoto = "https://www.nike.com/w/white-air-force-1-shoes-4g797z5sj3yzy7ok" },
    new ProdutoFoto { Id = 2, ProdutoId = 1, ArquivoFoto = "https://www.nike.com/w/white-air-force-1-shoes-4g797z5sj3yzy7ok" },
    new ProdutoFoto { Id = 3, ProdutoId = 1, ArquivoFoto = "https://www.nike.com/w/white-air-force-1-shoes-4g797z5sj3yzy7ok" },

    // Produto 2 - Adidas Ultraboost
    new ProdutoFoto { Id = 4, ProdutoId = 2, ArquivoFoto = "https://www.adidas.com/us/ultraboost" },
    new ProdutoFoto { Id = 5, ProdutoId = 2, ArquivoFoto = "https://www.adidas.com/us/ultraboost" },
    new ProdutoFoto { Id = 6, ProdutoId = 2, ArquivoFoto = "https://www.adidas.com/us/ultraboost" },

    // Produto 3 - Puma RS-X
    new ProdutoFoto { Id = 7, ProdutoId = 3, ArquivoFoto = "https://us.puma.com/us/en/pd/rs-x-retro-resort-womens-sneakers/395984" },
    new ProdutoFoto { Id = 8, ProdutoId = 3, ArquivoFoto = "https://us.puma.com/us/en/pd/rs-x-retro-resort-womens-sneakers/395984" },
    new ProdutoFoto { Id = 9, ProdutoId = 3, ArquivoFoto = "https://us.puma.com/us/en/pd/rs-x-retro-resort-womens-sneakers/395984" },

    // Produto 4 - Vans Old Skool
    new ProdutoFoto { Id = 10, ProdutoId = 4, ArquivoFoto = "https://www.vans.ca/en-ca/categories/skate-collection-c5420/skate-old-skool-shoe-pvn0a5fcby28" },
    new ProdutoFoto { Id = 11, ProdutoId = 4, ArquivoFoto = "https://www.vans.ca/en-ca/categories/skate-collection-c5420/skate-old-skool-shoe-pvn0a5fcby28" },
    new ProdutoFoto { Id = 12, ProdutoId = 4, ArquivoFoto = "https://www.vans.ca/en-ca/categories/skate-collection-c5420/skate-old-skool-shoe-pvn0a5fcby28" },

    // Produto 5 - New Balance 574
    new ProdutoFoto { Id = 13, ProdutoId = 5, ArquivoFoto = "https://www.newbalance.com/574/" },
    new ProdutoFoto { Id = 14, ProdutoId = 5, ArquivoFoto = "https://www.newbalance.com/574/" },
    new ProdutoFoto { Id = 15, ProdutoId = 5, ArquivoFoto = "https://www.newbalance.com/574/" },

    // Produto 6 - Converse Chuck Taylor
    new ProdutoFoto { Id = 16, ProdutoId = 6, ArquivoFoto = "https://www.converse.com/shop/high-top-shoes" },
    new ProdutoFoto { Id = 17, ProdutoId = 6, ArquivoFoto = "https://www.converse.com/shop/high-top-shoes" },
    new ProdutoFoto { Id = 18, ProdutoId = 6, ArquivoFoto = "https://www.converse.com/shop/high-top-shoes" },

    // Produto 7 - Asics Gel-Kayano 28
    new ProdutoFoto { Id = 19, ProdutoId = 7, ArquivoFoto = "https://www.asics.com/au/en-au/gel-kayano-28/p/AOP_1011B189-001.html" },
    new ProdutoFoto { Id = 20, ProdutoId = 7, ArquivoFoto = "https://www.asics.com/au/en-au/gel-kayano-28/p/AOP_1011B189-001.html" },
    new ProdutoFoto { Id = 21, ProdutoId = 7, ArquivoFoto = "https://www.asics.com/au/en-au/gel-kayano-28/p/AOP_1011B189-001.html" },

    // Produto 8 - Nike Dunk Low
    new ProdutoFoto { Id = 22, ProdutoId = 8, ArquivoFoto = "https://www.nike.com/w/dunk-shoes-90aohzy7ok" },
    new ProdutoFoto { Id = 23, ProdutoId = 8, ArquivoFoto = "https://www.nike.com/w/dunk-shoes-90aohzy7ok" },
    new ProdutoFoto { Id = 24, ProdutoId = 8, ArquivoFoto = "https://www.nike.com/w/dunk-shoes-90aohzy7ok" },

    // Produto 9 - Mizuno Wave Prophecy
    new ProdutoFoto { Id = 25, ProdutoId = 9, ArquivoFoto = "https://www.mizuno.com/us/en-us/wave-prophecy/" },
    new ProdutoFoto { Id = 26, ProdutoId = 9, ArquivoFoto = "https://www.mizuno.com/us/en-us/wave-prophecy/" },
    new ProdutoFoto { Id = 27, ProdutoId = 9, ArquivoFoto = "https://www.mizuno.com/us/en-us/wave-prophecy/" },

    // Produto 10 - Fila Disruptor II
    new ProdutoFoto { Id = 28, ProdutoId = 10, ArquivoFoto = "https://www.fila.com/disruptor-ii-sneakers/" },
    new ProdutoFoto { Id = 29, ProdutoId = 10, ArquivoFoto = "https://www.fila.com/disruptor-ii-sneakers/" },
    new ProdutoFoto { Id = 30, ProdutoId = 10, ArquivoFoto = "https://www.fila.com/disruptor-ii-sneakers/" },

    // Produto 11 - Reebok Classic
    new ProdutoFoto { Id = 31, ProdutoId = 11, ArquivoFoto = "https://www.reebok.com/us/classic-leather-shoes" },
    new ProdutoFoto { Id = 32, ProdutoId = 11, ArquivoFoto = "https://www.reebok.com/us/classic-leather-shoes" },
    new ProdutoFoto { Id = 33, ProdutoId = 11, ArquivoFoto = "https://www.reebok.com/us/classic-leather-shoes" },

    // Produto 12 - Under Armour HOVR
    new ProdutoFoto { Id = 34, ProdutoId = 12, ArquivoFoto = "https://www.underarmour.com/en-us/p/shoes/ua-hovr-phantom-2-running-shoes/3024155.html" },
    new ProdutoFoto { Id = 35, ProdutoId = 12, ArquivoFoto = "https://www.underarmour.com/en-us/p/shoes/ua-hovr-phantom-2-running-shoes/3024155.html" },
    new ProdutoFoto { Id = 36, ProdutoId = 12, ArquivoFoto = "https://www.underarmour.com/en-us/p/shoes/ua-hovr-phantom-2-running-shoes/3024155.html" },

    // Produto 13 - Jordan 1 Mid
    new ProdutoFoto { Id = 37, ProdutoId = 13, ArquivoFoto = "https://www.nike.com/w/jordan-1-mid-shoes-6ealhzy7ok" },
    new ProdutoFoto { Id = 38, ProdutoId = 13, ArquivoFoto = "https://www.nike.com/w/jordan-1-mid-shoes-6ealhzy7ok" },
    new ProdutoFoto { Id = 39, ProdutoId = 13, ArquivoFoto = "https://www.nike.com/w/jordan-1-mid-shoes-6ealhzy7ok" },

    // Produto 14 - Oakley Modoc
    new ProdutoFoto { Id = 40, ProdutoId = 14, ArquivoFoto = "https://www.oakley.com/en-us/product/OO9406" },
    new ProdutoFoto { Id = 41, ProdutoId = 14, ArquivoFoto = "https://www.oakley.com/en-us/product/OO9406" },
    new ProdutoFoto { Id = 42, ProdutoId = 14, ArquivoFoto = "https://www.oakley.com/en-us/product/OO9406" },

    // Produto 15 - Nike ZoomX Vaporfly
    new ProdutoFoto { Id = 43, ProdutoId = 15, ArquivoFoto = "https://www.nike.com/w/zoomx-vaporfly-shoes-4g797z5sj3yzy7ok" },
    new ProdutoFoto { Id = 44, ProdutoId = 15, ArquivoFoto = "https://www.nike.com/w/zoomx-vaporfly-shoes-4g797z5sj3yzy7ok" },
    new ProdutoFoto { Id = 45, ProdutoId = 15, ArquivoFoto = "https://www.nike.com/w/zoomx-vaporfly-shoes-4g797z5sj3yzy7ok" },

        };
        builder.Entity<ProdutoFoto>().HasData(produtoFotos);


        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "bec71b05-8f3d-4849-88bb-0e8d518d2de8",
               Name = "Funcionário",
               NormalizedName = "FUNCIONÁRIO"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = new() {
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "gallojunior@gmail.com",
                NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
                UserName = "GalloJunior",
                NormalizedUserName = "GALLOJUNIOR",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "José Antonio Gallo Junior",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "/img/usuarios/ddf093a6-6cb5-4ff7-9a64-83da34aee005.png"
            }
        };
        foreach (var user in usuarios)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}