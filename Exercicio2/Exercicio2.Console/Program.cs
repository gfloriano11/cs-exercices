const int max_athletes = 20;

string[] athlete_name = new string[max_athletes];
int[,] athlete_points = new int[max_athletes, 4];
int[] avg_athlete_points = new int[max_athletes];
string[] athlete_status = new string[max_athletes];

insert_info(athlete_name, athlete_points, avg_athlete_points, athlete_status);
show_info(athlete_name, athlete_points, avg_athlete_points, athlete_status);

static void insert_info(string[] athlete_name, int[,] athlete_points, int[] avg_athlete_points, string[] athlete_status)
{
    string menu_option = "";
    bool option = false;
    int athlete_quantity = 0;
    int athlete_points_sum = 0;

    Console.WriteLine("Olá! Bem-vindo. ");

    while (!option)
    {
        Console.WriteLine($"Vamos inserir a informação do {athlete_quantity + 1}º atleta:");

        Console.WriteLine($"Digite o nome do {athlete_quantity + 1}º atleta:");
        athlete_name[athlete_quantity] = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(athlete_name[athlete_quantity]))
        {
            Console.WriteLine("Nome do atleta inválido. Tente novamente.");
            athlete_name[athlete_quantity] = Console.ReadLine() ?? "";
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Digite a {i + 1}º pontuação do atleta [{athlete_name[athlete_quantity]}]:");
            athlete_points[athlete_quantity, i] = int.Parse(Console.ReadLine() ?? "0");
            
            while (athlete_points[athlete_quantity, i] < 0 || athlete_points[athlete_quantity, i] > 100)
            {
                Console.WriteLine("Pontuação inválida. Tente novamente.");
                athlete_points[athlete_quantity, i] = int.Parse(Console.ReadLine() ?? "0");
            }
            athlete_points_sum += athlete_points[athlete_quantity, i];
        }

        avg_athlete_points[athlete_quantity] = athlete_points_sum / 3;
        athlete_points_sum = 0;

        athlete_status[athlete_quantity] = "Reprovado";

        if (avg_athlete_points[athlete_quantity] > 70)
        {
            athlete_status[athlete_quantity] = "Aprovado";
        }


        Console.WriteLine("Deseja inserir a informação de mais um atleta?");
        Console.WriteLine("[1] - Sim");
        Console.WriteLine("[2] - Não");
        menu_option = Console.ReadLine() ?? "";

        while (menu_option != "1" && menu_option != "2")
        {
            Console.WriteLine("Opção Inválida! Tente Novamente.");
            Console.WriteLine("[1] - Sim");
            Console.WriteLine("[2] - Não");
            menu_option = Console.ReadLine() ?? "";
            Console.WriteLine(menu_option);
        }

        if (menu_option == "2")
        {
            option = true;
            Console.WriteLine("Saindo...");
        }

        athlete_quantity++;
    }
}

static void show_info(string[] athlete_name, int[,] athlete_points, int[] avg_athlete_points, string[] athlete_status)
{
    Console.WriteLine(
        $"| {"Nome",-15} | {"Pontuação",-15} | {"Média",-5} | {"Status",-10} |"
    );
    Console.WriteLine(new string('-', 60)); // linha separadora

    for (int i = 0; i < 20; i++)
    {
        if (!string.IsNullOrEmpty(athlete_name[i]))
        {
            string pontuacoes = $"{athlete_points[i, 0]}, {athlete_points[i, 1]}, {athlete_points[i, 2]}";
            Console.WriteLine(
                $"| {athlete_name[i],-15} | {pontuacoes,-15} | {avg_athlete_points[i],-5} | {athlete_status[i],-10} |"
            );
        }
    }
}
