//Зчитує дані з файлу employees.xml.
//Файл містить список співробітників у форматі XML,
//де кожен співробітник має такі властивості: Name, Position, HireDate.
//Сортує співробітників за датою прийому на роботу (від найстаріших до найновіших) за допомогою LINQ.
//Зберігає відсортований список співробітників у новий XML файл sorted_employees.xml.
//Записує інформацію про співробітників в текстовий файл employees.txt у наступному форматі:
//Name: [Name] Position: [Position] HireDate: [HireDate]
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Program
{
    class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
    }
    

    static void Main(string[] args)
    {
        string inputFilePath = "C:\\Users\\Admin\\source\\repos\\модуль3сішарп\\модуль3сішарп\\employees.xml";
        XDocument doc = XDocument.Load(inputFilePath);

        
        var employees = doc.Descendants("Employee")
            .Select(e => new Employee
            {
                Name = e.Element("Name")?.Value,
                Position = e.Element("Position")?.Value,
                HireDate = DateTime.Parse(e.Element("HireDate")?.Value)
            })
            .ToList();

        // Сорт
        var sortedEmployees = employees.OrderBy(e => e.HireDate).ToList();

        
        string outputXmlFilePath = "C:\\Users\\Admin\\source\\repos\\модуль3сішарп\\модуль3сішарп\\sorted_employees.xml";
        var sortedDoc = new XDocument(
            new XElement("Employees",
                sortedEmployees.Select(e =>
                    new XElement("Employee",
                        new XElement("Name", e.Name),
                        new XElement("Position", e.Position),
                        new XElement("HireDate", e.HireDate.ToString("yyyy-MM-dd"))
                    )
                )
            )
        );
        sortedDoc.Save(outputXmlFilePath);
        Console.WriteLine("Information about sorted employees succesfully saved to sorted_employees.xml");

        //тхт
        string outputTxtFilePath = "C:\\Users\\Admin\\source\\repos\\модуль3сішарп\\модуль3сішарп\\employees.txt";
        using (StreamWriter writer = new StreamWriter(outputTxtFilePath))
        {
            foreach (var employee in sortedEmployees)
            {
                writer.WriteLine($"Name: {employee.Name} Position: {employee.Position} HireDate: {employee.HireDate:yyyy-MM-dd}");
            }
        }

        Console.WriteLine("Information about employees succesfully saved to employees.txt");


    }





}