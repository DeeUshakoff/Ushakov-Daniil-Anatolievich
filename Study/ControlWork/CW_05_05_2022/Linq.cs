using DeeULib;
namespace Programming.ControlWork;

public class Linq
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Price
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public decimal Sum { get; set; }
            public bool IsActual { get; set; }
        }

        public void Run()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Аквариум 10 литров"},
                new Product {Id = 2, Name = "Аквариум 20 литров"},
                new Product {Id = 3, Name = "Аквариум 50 литров"},
                new Product {Id = 4, Name = "Аквариум 100 литров"},
                new Product {Id = 5, Name = "Аквариум 200 литров"},
                new Product {Id = 6, Name = "Фильтр"},
                new Product {Id = 7, Name = "Термометр"}
            };

            var prices = new List<Price>
            {
                new Price {Id = 1, ProductId = 1, Sum = 100, IsActual = false},
                new Price {Id = 2, ProductId = 1, Sum = 123, IsActual = true},
                new Price {Id = 3, ProductId = 2, Sum = 234, IsActual = true},
                new Price {Id = 4, ProductId = 3, Sum = 532, IsActual = true},
                new Price {Id = 5, ProductId = 4, Sum = 234, IsActual = true},
                new Price {Id = 6, ProductId = 5, Sum = 534, IsActual = true},
                new Price {Id = 7, ProductId = 5, Sum = 124, IsActual = false},
                new Price {Id = 8, ProductId = 6, Sum = 153, IsActual = true},
                new Price {Id = 9, ProductId = 7, Sum = 157, IsActual = true}
            };

            List<List<Product>> Task_1() =>
                new List<List<Product>>()
                {
                    new List<Product>() {products[0], products[0], products[5], products[5], products[6]},
                    new List<Product>() {products[3], products[1], products[5], products[6], products[6]},
                    new List<Product>() {products[2], products[1]}
                };

            void Task_2()
            {
                var products = Task_1().SelectMany(x => x).GroupBy(x => x.Id);
                foreach (var group in products)
                    $"{group.First().Name}, {group.Count()}, {group.Count() * prices.Find(x => x.ProductId == group.First().Id).Sum}"
                        .Print();

                products.SelectMany(x => x).Select(x => prices.Find(price => price.ProductId == x.Id).Sum).Sum()
                    .Print();
            }

            void Task_3() => prices
                .GroupBy(price => price.ProductId)
                .Select(x => x.Average(x => x.Sum))
                .ToList()
                .ForEach(x => x.Print());

            List<Tuple<List<Product>, int>> Task_4() =>
                new List<Tuple<List<Product>, int>>()
                {
                    new Tuple<List<Product>, int>(new List<Product>() {products[3], products[5], products[5]}, 15),
                    new Tuple<List<Product>, int>(new List<Product>() {products[4], products[5], products[5]}, 15),

                    new Tuple<List<Product>, int>(new List<Product>() {products[0], products[5]}, 5),
                    new Tuple<List<Product>, int>(new List<Product>() {products[1], products[5]}, 5),
                    new Tuple<List<Product>, int>(new List<Product>() {products[2], products[5]}, 5),
                    new Tuple<List<Product>, int>(new List<Product>() {products[3], products[5]}, 5),
                    new Tuple<List<Product>, int>(new List<Product>() {products[4], products[5]}, 5)
                };

            void Task_5()
            {
                foreach (var discount in Task_4())
                    $"{string.Join(" + ", discount.Item1.GroupBy(x => x.Id).Select(x => $"{x.Count()} {x.First().Name}"))} {GetCheckSum(discount.Item1) * (100 - discount.Item2) / 100} / {GetCheckSum(discount.Item1)}  "
                        .Print();
            }

            decimal GetCheckSum(List<Product> check) =>
                check.Select(x => prices.Find(price => price.ProductId == x.Id).Sum).Sum();
        }
    }

    
    
    
