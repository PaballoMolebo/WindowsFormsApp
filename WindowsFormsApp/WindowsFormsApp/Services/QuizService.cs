using System;
using System.Collections.Generic;

namespace WindowsFormsApp.Services
{
    internal class QuizService
    {
        private List<QuizQuestion> questions;
        private Random rng = new Random();

        public QuizService()
        {
            questions = new List<QuizQuestion>()
            {
                new QuizQuestion("What should you do if you receive an email asking for your password?",
                    new List<string> { "Reply with your password", "Delete the email", "Report the email as phishing", "Ignore it" }, 2,
                    "Never share your password through email. Reporting phishing emails helps prevent scams."),
                new QuizQuestion("Which of the following is the strongest password?",
                    new List<string> { "password123", "12345678", "John2005", "T!ger#92Moon$47" }, 3,
                    "A strong password combines uppercase and lowercase letters, numbers and special characters."),
                new QuizQuestion("What is two-factor authentication (2FA)?",
                    new List<string> { "Using two passwords", "An extra layer of account security", "Sharing your password with someone", "Logging in twice" }, 1,
                    "Two-factor authentication adds another verification step when accessing an account."),
                new QuizQuestion("What does phishing mean?",
                    new List<string> { "Protecting a computer from viruses", "Sending fake messages to steal information", "Updating computer software", "Creating strong passwords" }, 1,
                    "Phishing involves fake emails, messages or websites designed to steal personal information."),
                new QuizQuestion("Why should you update your antivirus software?",
                    new List<string> { "To make the screen brighter", "To increase internet speed", "To protect against new security threats", "To delete all your files" }, 2,
                    "Antivirus updates help detect and protect against newly discovered threats."),
                new QuizQuestion("What should you do before downloading a file?",
                    new List<string> { "Check whether the source is trustworthy", "Download every file you receive", "Disable your antivirus", "Ignore security warnings" }, 0,
                    "Always download files from trusted websites and check for suspicious content."),
                new QuizQuestion("What is social engineering?",
                    new List<string> { "Building computer networks", "Manipulating people into revealing confidential information", "Installing computer programs", "Creating websites" }, 1,
                    "Social engineering tricks people into sharing sensitive information or performing unsafe actions."),
                new QuizQuestion("What does HTTPS indicate on a website?",
                    new List<string> { "The website is always safe", "The website has no viruses", "The connection is encrypted", "The website is free" }, 2,
                    "HTTPS encrypts information transferred between your browser and the website. It does not guarantee that the website itself is trustworthy."),
                new QuizQuestion("What should you do when using public Wi-Fi?",
                    new List<string> { "Access your banking account without protection", "Share your passwords with others", "Disable all security settings", "Avoid sensitive activities on unsecured networks" }, 3,
                    "Unsecured public Wi-Fi can expose your information. Avoid sensitive activities and use trusted security measures."),
                new QuizQuestion("What is ransomware?",
                    new List<string> { "Software that protects your computer", "Malware that locks or encrypts files and demands payment", "A computer cleaning tool", "A password management application" }, 1,
                    "Ransomware prevents access to files or systems and demands payment to restore access."),
                new QuizQuestion("You should share your password with friends if you trust them.",
                    new List<string> { "True", "False" }, 1,
                    "False! Passwords should remain private, even from friends."),
                new QuizQuestion("Regularly backing up your files can help protect against data loss.",
                    new List<string> { "True", "False" }, 0,
                    "True! Regular backups help you recover important information if files are lost or damaged."),
                new QuizQuestion("You should install software updates to fix security weaknesses.",
                    new List<string> { "True", "False" }, 0,
                    "True! Software updates often fix security vulnerabilities that attackers could exploit."),
                new QuizQuestion("It is safe to open every link received in a text message.",
                    new List<string> { "True", "False" }, 1,
                    "False! Suspicious links may lead to fake websites or download harmful software."),
                new QuizQuestion("You should lock your computer when leaving your workstation.",
                    new List<string> { "True", "False" }, 0,
                    "True! Locking your computer prevents unauthorized people from accessing your information.")
            };
        }

        public List<QuizQuestion> GetQuestions() => new List<QuizQuestion>(questions);

        public List<QuizQuestion> GetShuffledQuestions()
        {
            var copy = new List<QuizQuestion>(questions);
            for (int i = copy.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = copy[i]; copy[i] = copy[j]; copy[j] = temp;
            }
            return copy;
        }

        public QuizQuestion GetQuestion(int index)
        {
            if (index < 0 || index >= questions.Count) return null;
            return questions[index];
        }

        public int GetQuestionCount() => questions.Count;

        public bool CheckAnswer(int questionIndex, int selectedAnswer)
        {
            if (questionIndex < 0 || questionIndex >= questions.Count) return false;
            return questions[questionIndex].CorrectAnswerIndex == selectedAnswer;
        }

        public string GetExplanation(int questionIndex)
        {
            if (questionIndex < 0 || questionIndex >= questions.Count) return "";
            return questions[questionIndex].Explanation;
        }
    }

    internal class QuizQuestion
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string questionText, List<string> options, int correctAnswerIndex, string explanation)
        {
            QuestionText = questionText;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
            Explanation = explanation;
        }
    }
}