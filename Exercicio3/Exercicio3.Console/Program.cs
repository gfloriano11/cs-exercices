const int max_quantity = 40;

string[] product_name = new string[max_quantity];
int[] product_quantity = new int[max_quantity];
int[] product_price = new int[max_quantity];
int[] total_product_price = new int[max_quantity];
string[] product_category = new string[max_quantity];

insert_product(product_name, product_quantity, product_price, total_product_price, product_category);

static void insert_product(string[] product_name, int[] product_quantity, int[] product_price, int[] total_product_price, string[] product_category)
{
    bool option = false;
    int product = 0;


    while (!option)
    {
        Console.WriteLine("Digite o nome do produto vendido:");
        product_name[product] = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(product_name[product]))
        {
            Console.WriteLine("Nome do produto inválido. Tente novamente:");
            product_name[product] = Console.ReadLine() ?? "";
        }

        Console.WriteLine($"Quantas unidades do produto {product_name[product]} foram vendidas?");
        product_quantity[product] = int.Parse(Console.ReadLine());

        while (product_quantity[product] < 1)
        {
            Console.WriteLine("Inválido. Tente novamente:");
            product_quantity[product] = int.Parse(Console.ReadLine());
        }
    }
}

// show_products();