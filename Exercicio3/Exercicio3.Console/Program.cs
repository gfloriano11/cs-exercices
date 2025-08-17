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

    Console.WriteLine("Olá. Bem-vindo ao S.G.V | Sistema de Gerenciamento de Vendas.");
    Console.WriteLine("Vamos inserir os dados do primeiro produto:");

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
            Console.WriteLine("Quantidade inválida. Tente novamente:");
            product_quantity[product] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Digite o valor unitário do produto:");
        product_price[product] = int.Parse(Console.ReadLine());

        while (product_price[product] < 1 || product_price[product] > 1000)
        {
            Console.WriteLine("Preço inválido. Tente novamente:");
            product_price[product] = int.Parse(Console.ReadLine());
        }

        total_product_price[product] = product_price[product] * product_quantity[product];

        product_category[product] = "Baixa";
        if (total_product_price[product] >= 500)
        {
            product_category[product] = "Alta";
        }
    }
}

// show_products();