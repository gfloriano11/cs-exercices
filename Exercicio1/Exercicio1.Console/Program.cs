const int max_quantity = 50;
int quantity = 0;
string[] books = new string[max_quantity];
int[] books_quantity = new int[max_quantity];
decimal[] books_unit_price = new decimal[max_quantity];
decimal[] books_price = new decimal[max_quantity];
string[] available = new string[max_quantity];


Console.WriteLine("Olá, bem-vindo ao S.C.E.L | [Sistema de Controle de Estoque de Livros]");

insert_book(books, books_unit_price, books_quantity, books_price, available, quantity);
show_stock(books, books_unit_price, books_quantity, books_price, available, quantity);

static void menu()
{
    
}

static void insert_book(string[] books, decimal[] books_unit_price, int[] books_quantity, decimal[] books_price, string[] available, int quantity)
{
    bool option = true;
    bool first_try_name = true;
    bool first_try_price = true;

    while (option && quantity < 50)
    {
        Console.WriteLine($"Dados do Livro número {quantity}");
        while (string.IsNullOrWhiteSpace(books[quantity]))
        {
            if (!first_try_name)
            {
                Console.WriteLine("Nome Inválido. Tente novamente.");
            }
            Console.WriteLine("Digite o nome do livro: ");
            books[quantity] = Console.ReadLine();
        }
        while (books_unit_price[quantity] < 10 || books_unit_price[quantity] > 500)
        {
            if (!first_try_price)
            {
                Console.WriteLine("Preço Inválido. Tente novamente.");
            }
            Console.WriteLine("Digite o preço do Livro:");
            books_unit_price[quantity] = decimal.Parse(Console.ReadLine());
        }
        Console.WriteLine($"Quantos livros [{books[quantity]}] chegarão no estoque?");
        books_quantity[quantity] = int.Parse(Console.ReadLine());

        available[quantity] = "Disponível";

        if (books_quantity[quantity] == 0)
        {
            available[quantity] = "Indisponível";
        }

        books_price[quantity] = books_unit_price[quantity] * books_quantity[quantity];

        quantity++;

        Console.WriteLine("Deseja Continuar?");
        Console.WriteLine("[1] - Sim");
        Console.WriteLine("[2] - Não");
        int num_value = int.Parse(Console.ReadLine());

        if (num_value == 2)
        {
            option = false;
        }

    }
}

static void show_stock(string[] books, decimal[] books_unit_price, int[] books_quantity, decimal[] books_price, string[] available, int quantity)
{
    Console.WriteLine($"Buscando... {quantity}");
    for (int i = 0; i < max_quantity; i++)
    {
        if (!string.IsNullOrEmpty(books[i]))
        {
            Console.WriteLine($"Dados do livro número {i}");
            Console.WriteLine($"{books[i]} | {books_price[i]} | {books_unit_price[i]} | {books_quantity[i]} | {available[i]}");
        }
    }
}