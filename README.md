# Uygulama Özeti

Stok kontrolü gerçekleştirerek, istenilen ürünlerin sepete atılmasını gerçekleştiren API yazılması

## Açıklama

Swagger'da da görüleceği üzere mock bir şekilde ürünlerde listeleme endpointleri bulunmaktadır. Ürünler Relational Db(PostgreSql) üzerinde saklanmaktadır. Client tarafında yazılacak sepet key'i ile sepet oluşturulup (sepet post işleminde, gönderilen key ile sepet bulunmamakta ise yeni oluşturulup döndürülüyor) istenilen ürünleri sepete ekler. Sepet NoSql db (Redis) üzerinde durmaktadır. Basket key'i string olduğundan test amaçlı herhangi bir key verilebilir. (Örn. basket1)

Sepet Key'i Client tarafında ya da üye girişi söz konusu ile db tarafında üye ile ilişkili bir şekilde tutulabilir.

## Projeyi Çalıştırmak İçin

Proje .Net 5 ve Docker'a ihtiyaç duymaktadır. Dockerda container ayağa kalktıktan sonra projeyi çalıştırınca db otomatik olarak oluşturulmaktadır.

1. Projenin klasörüne bir komut işlemci ile gidildikten sonra docker-compose up --detach kodu çalıştırılmalıdır.
2. Projenin içinde src/API klasörüne giderek dotnet run komutu ile ya da Visual Studio üzerinden Startup Project API olacak şekilde ayarlama yapıldıktan sonra proje çalıştırılabilir.


## Kullanılan Teknolojiler ve Patternler

- .Net 5
- PostgreSQL
- Redis
- Docker
- AutoMapper
- EF 5
- Repository Pattern
- Swagger

## Örnek İstekler:

GET
/api/products
/api/basket?id=basket1

POST
/api/basket

{
    "id": "basket1",
    "items": [
        {
            "productId": 1,
            "quantity": 10
        },
        {
            "productId": 3,
            "quantity": 1
        }
    ]
}