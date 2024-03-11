using System;
using System.Collections.Generic;

namespace HealthApp
{
    /// <summary>
    /// This application is an Intake Form for a Health App.
    /// Author: [mohammed ali]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            string firstName = "";
            string lastName = "";
            int birthYear = 0;
            char gender = ' ';
            List<string> userResponses = new List<string>();

            // Input
            Console.WriteLine("Please fill out the following health information:");

            // First Name
            while (string.IsNullOrWhiteSpace(firstName))
            {
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
            }

            // Last Name
            while (string.IsNullOrWhiteSpace(lastName))
            {
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
            }

            // Birth Year
            while (birthYear <= 1900 || birthYear > DateTime.Now.Year)
            {
                Console.Write("Birth Year: ");
                if (!int.TryParse(Console.ReadLine(), out birthYear))
                {
                    Console.WriteLine("Invalid input. Please enter a valid year.");
                }
            }

            // Gender
            while (gender != 'M' && gender != 'F' && gender != 'O')
            {
                Console.Write("Gender (M/F/O): ");
                gender = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            }

            // Questionnaire
            Console.WriteLine("Please answer the following health questions:");

            // Health-related questions
            string[] healthQuestions = {
                "Do you have any chronic health conditions? If so, please specify.",
                "Are you currently taking any medications? If yes, please list them.",
                "Do you have any allergies? If yes, please list them.",
                "Have you had any surgeries or medical procedures in the past? If yes, please describe.",
                "Do you smoke tobacco products? If yes, how many cigarettes per day?",
                "Do you consume alcohol? If yes, how often and in what quantities?",
                "How would you describe your typical diet? (e.g., vegetarian, omnivore, etc.)",
                "How often do you engage in physical activity or exercise?",
                "Have you experienced any significant weight changes in the past year? If yes, please describe.",
                "Do you have a family history of any hereditary health conditions? If yes, please specify."
            };

            for (int i = 0; i < healthQuestions.Length; i++)
            {
                Console.Write($"{healthQuestions[i]} ");
                string response = Console.ReadLine();
                userResponses.Add(response);
            }

            // Profile Summary
            Console.WriteLine("Health Profile Summary:");
            Console.WriteLine($"Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetGenderDescription(gender)}");

            // Display Questions and Responses
            for (int i = 0; i < userResponses.Count; i++)
            {
                Console.WriteLine($"{healthQuestions[i]}: {userResponses[i]}");
            }
        }

        static string GetGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other";
                default:
                    return "Unknown";
            }
        }
    }
}

