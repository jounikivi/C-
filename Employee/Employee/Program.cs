using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

class Program
{
    static List<Employee> employees = new List<Employee>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Lisää uusi työntekijä");
            Console.WriteLine("2. Näytä kaikki työntekijät");
            Console.WriteLine("3. Poistu");

            Console.Write("Valitse toiminto: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    ShowEmployees();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Virheellinen valinta. Yritä uudelleen.");
                    break;
            }
        }
    }

    static void AddEmployee()
    {
        Employee employee = new Employee();

        Console.Write("Syötä työntekijän nimi: ");
        employee.Name = Console.ReadLine();

        Console.Write("Syötä työntekijän syntymäaika (pp.kk.vvvv): ");
        employee.BirthDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Syötä työntekijän osoite: ");
        employee.Address = Console.ReadLine();

        Console.Write("Syötä työntekijän puhelinnumero: ");
        employee.PhoneNumber = Console.ReadLine();

        employees.Add(employee);
        Console.WriteLine("Työntekijä lisätty onnistuneesti.");
    }

    static void ShowEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("Ei työntekijöitä.");
            return;
        }

        Console.WriteLine("Kaikki työntekijät:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"Nimi: {employee.Name}, Syntymäaika: {employee.BirthDate.ToShortDateString()}, Osoite: {employee.Address}, Puhelinnumero: {employee.PhoneNumber}");
        }
    }
}
