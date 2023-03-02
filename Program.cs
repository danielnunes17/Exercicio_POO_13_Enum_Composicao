/* Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). Depois, solicitar
do usuário um mês e mostrar qual foi o salário do funcionário nesse mês*/

using Exercicio_POO_13_Enum_Composicao.Entities;
using Exercicio_POO_13_Enum_Composicao.Entities.Enums;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter department's name: ");
        string dpName = Console.ReadLine();
        Console.WriteLine("Enter worker data: ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
        Console.Write("Base salary: ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Department dept = new Department(dpName);
        Worker worker = new Worker(name, level, baseSalary, dept);

        Console.Write("How many contracts to this worker? ");
        int qtdContract = int.Parse(Console.ReadLine());

        for (int i = 1; i <= qtdContract; i++)
        {
            Console.WriteLine($"Enter # {i} contract data:");
            Console.Write("Date (DD/MM/YYYY):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Value per hour: ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Duration (hours): ");
            int hour = int.Parse(Console.ReadLine());

            HourContract contract = new HourContract(date, valuePerHour, hour);
            worker.AddContract(contract);
        }
        Console.WriteLine();
        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        string mouthAndYear = Console.ReadLine();
        int mounth = int.Parse(mouthAndYear.Substring(0, 2));
        int year = int.Parse(mouthAndYear.Substring(3));

        Console.Write("Name: " + worker.Name);
        Console.Write("Department: " + worker.Department.Name);
        Console.Write("Income for " + mouthAndYear + ": " + worker.Income(year, mounth));

    }
}