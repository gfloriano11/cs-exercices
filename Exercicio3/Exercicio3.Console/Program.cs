const int max_quantity = 40;

string[] product_name = new string[max_quantity];
int[] product_quantity = new int[max_quantity];
decimal[] product_price = new decimal[max_quantity];
decimal[] total_product_price = new decimal[max_quantity];
string[] product_category = new string[max_quantity];

insert_product(product_name, product_quantity, product_price, total_product_price, product_category);
show_info(product_name, product_quantity, product_price, total_product_price, product_category);

static void insert_product(string[] product_name, int[] product_quantity, decimal[] product_price, decimal[] total_product_price, string[] product_category)
{
    string menu_option;
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
        product_price[product] = decimal.Parse(Console.ReadLine());

        while (product_price[product] < 1 || product_price[product] > 1000)
        {
            Console.WriteLine("Preço inválido. Tente novamente:");
            product_price[product] = decimal.Parse(Console.ReadLine());
        }

        total_product_price[product] = product_price[product] * product_quantity[product];

        product_category[product] = "Baixa";
        if (total_product_price[product] >= 500)
        {
            product_category[product] = "Alta";
        }

        Console.WriteLine("Deseja inserir mais um produto?");
        Console.WriteLine("[1] - Sim");
        Console.WriteLine("[2] - Não");
        menu_option = Console.ReadLine();

        while (menu_option != "1" && menu_option != "2")
        {
            Console.WriteLine("Opção inválida. Tente novamente:");
            menu_option = Console.ReadLine();
        }

        if (menu_option == "2")
        {
            option = true;
        }

        product++;
    }
}

static void show_info(string[] product_name, int[] product_quantity, decimal[] product_price, decimal[] total_product_price, string[] product_category)
{
    Console.WriteLine("Gerando relatório...");
    Console.WriteLine($"| {"Nome",-15} | {"Quantidade",-5} | {"Preço",-5} | {"Preço Total",-5} | {"Categoria",-10} |");
    Console.WriteLine(new string('-', 67));

    for (int i = 0; i < max_quantity; i++)
    {
        if (!string.IsNullOrWhiteSpace(product_name[i]))
        {
            Console.WriteLine($"| {product_name[i],-15} | {product_quantity[i],-10} | {product_price[i],-5} | {total_product_price[i],-11} | {product_category[i],-10} |");
        }
    }
}
