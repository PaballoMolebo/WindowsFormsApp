using System;
using System.Threading;

namespace CyberSecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display logo
            ShowLogo();

            // Display welcome message
            ShowWelcome();

            // Start the chatbot
            StartChat();
        }

        // =========================
        // LOGO
        // =========================
        static void ShowLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==============================================");
            Console.WriteLine("        C Y B E R   S E C U R I T Y");
            Console.WriteLine("                 B O T");
            Console.WriteLine("==============================================");

            Console.ResetColor();
            Console.WriteLine();
        }

        // =========================
        // WELCOME MESSAGE
        // =========================
        static void ShowWelcome()
        {
            TypeResponse("Bot: Welcome! I can help you with basic cybersecurity questions.");
            TypeResponse("Bot: You can ask me about passwords, phishing, or safe browsing.");
            Console.WriteLine();
        }

        // =========================
        // CHATBOT
        // =========================
        static void StartChat()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("You: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                // Check if user entered nothing
                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowError("I didn't understand that. Please type a question.");
                    continue;
                }

                // Convert input to lowercase
                input = input.ToLower();

                // Get chatbot response
                string reply = GetBotResponse(input);

                // Display chatbot response
                TypeResponse("Bot: " + reply);

                Console.WriteLine();

                // Ask user if they want to continue
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Would you like to ask another question? (1 = Yes, 0 = No): ");
                Console.ResetColor();

                string answer = Console.ReadLine();

                // Check the answer
                if (answer == "0")
                {
                    TypeResponse("Bot: Stay safe online! Goodbye!");
                    break;
                }
                else if (answer == "1")
                {
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    ShowError("Please enter 1 for Yes or 0 for No.");
                }
            }
        }

        // =========================
        // BOT RESPONSES
        // =========================
        static string GetBotResponse(string question)
        {
            if (question.Contains("hello") || question.Contains("hi"))
            {
                return "Hey there! I'm your Cyber Security Helper. How can I help you today?";
            }

            if (question.Contains("how are you"))
            {
                return "I'm doing great! Ready to help you stay safe online.";
            }

            if (question.Contains("purpose") ||
                question.Contains("what do you do"))
            {
                return "My purpose is to answer basic cybersecurity questions about passwords, phishing, and safe browsing.";
            }

            if (question.Contains("help") ||
                question.Contains("ask"))
            {
                return "You can ask me about password safety, phishing scams, or safe browsing.";
            }

            if (question.Contains("password"))
            {
                return "Password Safety Tip: Use at least 12 characters with uppercase, lowercase, numbers and symbols. Never reuse passwords across different websites.";
            }

            if (question.Contains("phishing"))
            {
                return "Phishing Alert: Scammers pretend to be banks or companies to steal your information. Always check the sender's email address and avoid suspicious links.";
            }

            if (question.Contains("browsing") ||
                question.Contains("website"))
            {
                return "Safe Browsing Tip: Use trusted websites, look for HTTPS, and avoid downloading files from unknown sources.";
            }

            // Default response
            return "I didn't quite understand that. Try asking me about passwords, phishing, or safe browsing.";
        }

        // =========================
        // TYPING EFFECT
        // =========================
        static void TypeResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(15);
            }

            Console.WriteLine();

            Console.ResetColor();
        }

        // =========================
        // ERROR MESSAGE
        // =========================
        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: " + message);
            Console.ResetColor();
        }
    }
}