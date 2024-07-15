using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceGold;

namespace JewelSystemBE.Data
{
    public class DataGenerating
    {
        private readonly JewelDbContext _jewelDbContext;
        private readonly IGoldService _goldService;

        public DataGenerating(JewelDbContext jewelDbContext, IGoldService goldService)
        {
            _jewelDbContext = jewelDbContext;
            _goldService = goldService;
        }

        public async Task<List<Product>> GetNewProducts()
        {


            List<Product> newproducts = new List<Product>();

            List<Product> products = _jewelDbContext.Products.ToList();

            List<Gem> gems = _jewelDbContext.Gems.ToList();

            List<Gold> golds = await _goldService.GetGolds();

            List<string> productTypes = new List<string>
            {
                "Ring", "Necklace", "Bracelet", "Earrings"
            };

            List<string> productCodes = products.Select(x => x.ProductCode).ToList();

            int maxId = products
                    .Select(x => int.Parse(x.ProductId.Substring(1)))
                    .DefaultIfEmpty(1)
                    .Max();
            int gemIndex = 0;
            int goldIndex = 0;

            //Declare properties
            string productId = "";
            string productCode = "";
            string productName = "";
            string productImage = "";
            int productQuantity = 0;
            string productType = "";
            double productWeight = 0;
            int productWarranty = 0;
            double markupRate = 0;
            string gemId = "";
            string goldId = "";
            string gemName = "";
            double gemWeight = 0;
            string goldName = "";
            double goldWeight = 0;
            double laborCost = 0;
            DateTime dateTime = DateTime.Now;

            for (int i = 0; i < 39; i++)
            {
                Random random = new Random();

                // Set productId
                if (maxId < 100)
                {
                    productId = $"P0{maxId + 1}";
                }
                else
                {
                    productId = $"P{maxId + 1}";
                }
                maxId++;

                // Set productCode
                while (productCodes.Find(x => x == productCode) != null)
                {
                    string productCode1 = random.Next(100000, 999999).ToString();
                    string productCode2 = random.Next(100000, 999999).ToString();
                    productCode = $"{productCode1}{productCode2}";
                }
                productCodes.Add(productCode);

                // Set productImage
                productImage = $"{productId}.png";

                // Set productQuantity
                productQuantity = random.Next(5, 25);

                // Set productType
                productType = productTypes[random.Next(0, productTypes.Count)];

                // Set gemId
                Gem randomGem = gems[random.Next(0, gems.Count)];
                gemId = randomGem.GemId;
                gemName = randomGem.GemName;
                gemWeight = randomGem.GemWeight;

                // Set goldId
                Gold randomGold = golds[random.Next(0, golds.Count)];
                goldId = randomGold.GoldId;
                goldName = randomGold.GoldName;
                goldWeight = random.Next(1, 10) + random.NextDouble();

                // Set productWeight
                productWeight = gemWeight + goldWeight + random.Next(0, 3) + random.NextDouble();

                // Set productName
                productName = $"{gemName} {productType}";

                // Set datetime
                int addDay = random.Next(0, 30);
                DateTime startDate = new DateTime(2024, 1, 1);
                dateTime = startDate.AddDays(addDay);

                // Set laborCost
                laborCost = random.Next(1000000, 50000000) + random.NextDouble();

                // Set markupRate
                markupRate = random.NextDouble() + random.Next(1, 3);

                // Set productWarranty
                productWarranty = random.Next(12, 48);

                // Set 

                // Set info


                // Create new product
                Product product = new Product
                {
                    ProductId = productId,
                    ProductCode = productCode,
                    ProductName = productName,
                    ProductImages = productImage,
                    ProductQuantity = productQuantity,
                    ProductType = productType,
                    ProductWeight = productWeight,
                    ProductWarranty = productWarranty,
                    MarkupRate = markupRate,
                    GemId = gemId,
                    GemName = gemName,
                    GemWeight = gemWeight,
                    GoldId = goldId,
                    GoldName = goldName,
                    GoldWeight = goldWeight,
                    LaborCost = laborCost,
                    CreatedAt = dateTime
                };

                // Add new product to results
                newproducts.Add(product);

            }

            return newproducts;
        }

        public async Task<string> GetNewProductsToString()
        {
            string productsString = "";

            List<Product> products = await GetNewProducts();

            foreach (Product product in products)
            {
                productsString += "new Product\n";
                productsString += "{\n";
                productsString += $"    ProductId = \"{product.ProductId}\",\n";
                productsString += $"    ProductCode = \"{product.ProductCode}\",\n";
                productsString += $"    ProductName = \"{product.ProductName}\",\n";
                productsString += $"    ProductImages = \"{product.ProductImages}\",\n";
                productsString += $"    ProductQuantity = {product.ProductQuantity},\n";
                productsString += $"    ProductType = \"{product.ProductType}\",\n";
                productsString += $"    ProductWeight = {product.ProductWeight},\n";
                productsString += $"    ProductWarranty = {product.ProductWarranty},\n";
                productsString += $"    MarkupRate = {product.MarkupRate},\n";
                productsString += $"    GoldId = \"{product.GoldId}\",\n";
                productsString += $"    GoldName = \"{product.GoldName}\",\n";
                productsString += $"    GoldWeight = {product.GoldWeight},\n";
                productsString += $"    GemId = \"{product.GemId}\",\n";
                productsString += $"    GemName = \"{product.GemName}\",\n";
                productsString += $"    GemWeight = {product.GemWeight},\n";
                productsString += $"    LaborCost = {product.LaborCost},\n";
                productsString += $"    CreatedAt = new DateTime ({product.CreatedAt.ToString("yyyy, M, d")})\n";
                productsString += "},";
            }

            return productsString;
        }

        public async Task<List<StallItem>> GetNewStallItems()
        {
            List<StallItem> newStallItems = new List<StallItem>();

            List<Product> products = _jewelDbContext.Products.ToList();

            int maxId = 0;
            string stallItemId = "";
            string stallId = "";
            string productId = "";
            string productName = "";
            int quantity = 0;

            for (int i = 0; i < 100; i++)
            {
                // Set stallItemId

                if (maxId < 10)
                {
                    stallItemId = $"SI00{maxId + 1}";
                }
                else if (maxId < 100)
                {
                    stallItemId = $"SI0{maxId + 1}";
                }
                else
                {
                    stallItemId = $"SI{maxId + 1}";
                }
                maxId++;

                // Set stallId

                if (maxId <= 25)
                {
                    stallId = "ST01";
                }
                else if (maxId <= 50)
                {
                    stallId = "ST02";
                }
                else if (maxId <= 75)
                {
                    stallId = "ST03";
                }
                else
                {
                    stallId = "ST04";
                }

                // Set productId, productName, quantity

                Product product = products[i];

                productId = product.ProductId;
                productName = product.ProductName;
                quantity = product.ProductQuantity;

                // Add stallItem to list

                StallItem stallItem = new StallItem
                {
                    StallItemId = stallItemId,
                    StallId = stallId,
                    ProductId = productId,
                    ProductName = productName,
                    quantity = quantity
                };
                newStallItems.Add(stallItem);
            }

            return newStallItems;
        }

        public async Task<string> GetNewStallItemsToString()
        {
            string stallItemsString = "";

            List<StallItem> stallItems = await GetNewStallItems();

            foreach (StallItem stallItem in stallItems)
            {
                stallItemsString += "new StallItem\n";
                stallItemsString += "{\n";
                stallItemsString += $"    StallItemId = \"{stallItem.StallItemId}\",\n";
                stallItemsString += $"    StallId = \"{stallItem.StallId}\",\n";
                stallItemsString += $"    ProductId = \"{stallItem.ProductId}\",\n";
                stallItemsString += $"    ProductName = \"{stallItem.ProductName}\",\n";
                stallItemsString += $"    quantity = {stallItem.quantity},\n";
                stallItemsString += "},";
            }

            return stallItemsString;
        }

        public async Task<List<StallEmployee>> GetNewStallEmployees()
        {
            List<StallEmployee> newStallEmployees = new List<StallEmployee>();

            List<User> users = _jewelDbContext.Users.OrderBy(x => x.UserId).ToList();

            int maxId = 6;
            string stallEmployeeId = "";
            string stallId = "";
            string stallName = "";
            string employeeId = "";
            string employeeFullname = "";
            string role = "";

            for (int i = 6; i < 22; i++)
            {
                // Set stallEmployeeId
                if(maxId < 10)
                {
                    stallEmployeeId = $"SE00{maxId + 1}";
                }
                else
                {
                    stallEmployeeId = $"SE0{maxId + 1}";
                }
                

                // Set stallId, stallName
                if (maxId < 10)
                {
                    stallId = "ST01";
                    stallName = "Sky Treasure";
                }
                else if(maxId < 14)
                {
                    stallId = "ST02";
                    stallName = "Delights";
                }
                else if (maxId < 18)
                {
                    stallId = "ST03";
                    stallName = "The Vintage";
                }
                else
                {
                    stallId = "ST04";
                    stallName = "The Charm";
                }

                maxId++;

                // Set employeeId, employeeFullname, role

                User user = users[i];
                employeeId = user.UserId;
                employeeFullname = user.Fullname;
                role = user.Role;

                StallEmployee stallEmployee = new StallEmployee
                {
                    StallEmployeeId = stallEmployeeId,
                    StallId = stallId,
                    StallName = stallName,
                    EmployeeId = employeeId,
                    EmployeeFullname = employeeFullname,
                    Role = role 
                };

                newStallEmployees.Add(stallEmployee);
            }

            return newStallEmployees;
        }

        public async Task<string> GetNewStallEmployeesToString()
        {
            string stallEmployeesString = "";

            List<StallEmployee> stallEmployees = await GetNewStallEmployees();

            foreach (StallEmployee stallEmployee in stallEmployees)
            {
                stallEmployeesString += "new StallEmployee\n";
                stallEmployeesString += "{\n";
                stallEmployeesString += $"    StallEmployeeId = \"{stallEmployee.StallEmployeeId}\",\n";
                stallEmployeesString += $"    StallId = \"{stallEmployee.StallId}\",\n";
                stallEmployeesString += $"    StallName = \"{stallEmployee.StallName}\",\n";
                stallEmployeesString += $"    EmployeeId = \"{stallEmployee.EmployeeId}\",\n";
                stallEmployeesString += $"    EmployeeFullname = \"{stallEmployee.EmployeeFullname}\",\n";
                stallEmployeesString += $"    Role = \"{stallEmployee.Role}\",\n";
                stallEmployeesString += "},";
            }

            return stallEmployeesString;
        }
    }
}
