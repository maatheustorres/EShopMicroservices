using Catalog.API.Models;
using Marten;
using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
        {
            return;
        }

        session.Store<Product>(GetPreConfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    public static IEnumerable<Product> GetPreConfiguredProducts() => [
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Notebook Dell Inspiron 15",
            Categories = ["Eletrônicos", "Informática"],
            Description = "Notebook com processador Intel i7, 16GB RAM e SSD de 512GB.",
            ImageFile = "notebook-dell.jpg",
            Price = 4899.90m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Smartphone Samsung Galaxy S23",
            Categories = ["Eletrônicos", "Celulares"],
            Description = "Smartphone com tela AMOLED de 6.6'', 256GB e câmera tripla.",
            ImageFile = "samsung-galaxy-s23.jpg",
            Price = 3799.00m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Cadeira Gamer ThunderX",
            Categories = ["Móveis", "Games"],
            Description = "Cadeira ergonômica com ajuste de altura e apoio lombar.",
            ImageFile = "cadeira-gamer.jpg",
            Price = 1299.99m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Monitor LG UltraWide 29''",
            Categories = ["Eletrônicos", "Informática"],
            Description = "Monitor ultrawide IPS Full HD com proporção 21:9.",
            ImageFile = "monitor-lg.jpg",
            Price = 1599.90m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Mouse Logitech MX Master 3",
            Categories = ["Acessórios", "Informática"],
            Description = "Mouse sem fio avançado com rolagem ultra rápida.",
            ImageFile = "mouse-logitech.jpg",
            Price = 499.00m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Teclado Mecânico Redragon",
            Categories = ["Games", "Acessórios"],
            Description = "Teclado mecânico RGB com switches vermelhos.",
            ImageFile = "teclado-redragon.jpg",
            Price = 349.90m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Fone Bluetooth JBL Tune 510BT",
            Categories = ["Áudio", "Eletrônicos"],
            Description = "Fone de ouvido sem fio com até 40h de bateria.",
            ImageFile = "fone-jbl.jpg",
            Price = 299.99m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Smart TV LG 55'' 4K",
            Categories = new List<string> { "Eletrônicos", "TV" },
            Description = "Smart TV 4K com inteligência artificial e HDR10.",
            ImageFile = "tv-lg-55.jpg",
            Price = 3199.00m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Caixa de Som Alexa Echo Dot 5ª Geração",
            Categories = ["Áudio", "Assistentes Virtuais"],
            Description = "Caixa de som inteligente com Alexa integrada.",
            ImageFile = "echo-dot.jpg",
            Price = 379.90m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Câmera GoPro Hero 11",
            Categories = new List<string> { "Fotografia", "Eletrônicos" },
            Description = "Câmera de ação com 5.3K de resolução e estabilização.",
            ImageFile = "gopro-hero11.jpg",
            Price = 2899.00m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Console PlayStation 5",
            Categories = ["Games", "Eletrônicos"],
            Description = "Console de nova geração com SSD ultrarrápido.",
            ImageFile = "ps5.jpg",
            Price = 4599.00m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Cafeteira Nespresso Essenza Mini",
            Categories = new List<string> { "Eletrodomésticos", "Cozinha" },
            Description = "Cafeteira compacta para cápsulas Nespresso.",
            ImageFile = "cafeteira-nespresso.jpg",
            Price = 499.00m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Bicicleta Caloi Vulcan Aro 29",
            Categories = ["Esportes", "Lazer"],
            Description = "Bicicleta MTB com 21 marchas e quadro em alumínio.",
            ImageFile = "bike-caloi.jpg",
            Price = 1899.90m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Relógio Smartwatch Amazfit Bip U",
            Categories = ["Esportes", "Eletrônicos"],
            Description = "Relógio inteligente com monitoramento de saúde e GPS.",
            ImageFile = "amazfit-bip.jpg",
            Price = 399.90m
        },
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Mochila Samsonite Tectonic",
            Categories = ["Acessórios", "Viagem"],
            Description = "Mochila reforçada com compartimento para notebook.",
            ImageFile = "mochila-samsonite.jpg",
            Price = 699.00m
        }
    ];
}
