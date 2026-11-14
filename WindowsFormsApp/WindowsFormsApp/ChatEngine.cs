using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp.Services
{
    public class ChatEngine
    {
        private string userName = "";
        private string favouriteTopic = "";
        private string lastTopic = "";
        private string lastResponse = "";
        private Random rng = new Random();

        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>();

        private List<string> worriedWords = new List<string>()
        {
            "worried", "scared", "nervous", "frustrated", "confused",
            "afraid", "concerned", "anxious", "overwhelmed", "stressed",
            "angry", "upset", "lost"
        };

        public ChatEngine()
        {
            keywordResponses["password"] = new List<string>()
            {
                "Strong passwords are your first defence. Use at least 12 characters with a mix of upper, lower, numbers and symbols.",
                "Avoid reusing passwords. A password manager can create and store unique passwords for every account safely.",
                "Never use personal info like birthdays in passwords. Consider a passphrase like 'BlueSky$Rain2024!'"
            };
            keywordResponses["phishing"] = new List<string>()
            {
                "Phishing is when criminals impersonate trusted companies to trick you into giving away credentials.",
                "Check for red flags: urgent language, spelling errors, and email addresses that don't match the company domain.",
                "Never click links in suspicious emails. Go directly to the website by typing the URL yourself."
            };
            keywordResponses["malware"] = new List<string>()
            {
                "Malware is malicious software - viruses, trojans, ransomware - designed to harm or spy on you.",
                "Keep your OS and antivirus updated. Updates patch vulnerabilities malware exploits.",
                "Only download software from official sources and scan attachments before opening."
            };
            keywordResponses["antivirus"] = new List<string>()
            {
                "Antivirus detects, quarantines and removes malicious software using signature and behaviour analysis.",
                "Set your antivirus to auto-update daily and run weekly full scans.",
                "Antivirus is essential, but works best with a firewall and safe browsing habits."
            };
            keywordResponses["firewall"] = new List<string>()
            {
                "A firewall acts as a barrier, filtering incoming and outgoing traffic based on security rules.",
                "It blocks unauthorized connections while allowing legitimate communication.",
                "Ensure both your Windows firewall and router firewall are enabled for layered protection."
            };
            keywordResponses["hacking"] = new List<string>()
            {
                "Hacking exploits system weaknesses to gain unauthorized access. It can be criminal or ethical.",
                "Protect yourself with updates, strong authentication and least-privilege principles.",
                "Ethical hackers help organizations find vulnerabilities before malicious hackers do."
            };
            keywordResponses["2fa"] = new List<string>()
            {
                "Two-Factor Authentication requires something you know (password) + something you have (phone/code).",
                "Even if your password leaks, 2FA stops 99% of automated attacks.",
                "Enable 2FA on email, banking, and social media - use an authenticator app over SMS where possible."
            };
            keywordResponses["two factor"] = keywordResponses["2fa"];
            keywordResponses["two-factor"] = keywordResponses["2fa"];
            keywordResponses["encryption"] = new List<string>()
            {
                "Encryption converts readable data into ciphertext that can only be read with the correct key.",
                "End-to-end encryption ensures only you and the recipient can read messages.",
                "Look for HTTPS and the padlock icon - it means data in transit is encrypted."
            };
            keywordResponses["vpn"] = new List<string>()
            {
                "A VPN creates an encrypted tunnel for your traffic, protecting you on public Wi-Fi.",
                "Choose a reputable, no-logs VPN. A VPN hides your IP but doesn't make you fully anonymous.",
                "A VPN is one layer - combine it with HTTPS and good password practices."
            };
            keywordResponses["social engineering"] = new List<string>()
            {
                "Social engineering manipulates human psychology, not technology, to gain access or information.",
                "Attackers use urgency, fear, and authority - e.g., 'Your account will be closed! Act now!'",
                "Always verify requests via a separate channel. Call the company directly, don't reply to the suspicious message."
            };
            keywordResponses["privacy"] = new List<string>()
            {
                "Review app permissions and social media privacy settings quarterly.",
                "Minimize your digital footprint - share less personal data than platforms ask for.",
                "Use privacy-focused browsers and check haveibeenpwned.com to see if your data has been leaked."
            };
            keywordResponses["cybersecurity"] = new List<string>()
            {
                "Cybersecurity is protecting confidentiality, integrity and availability of systems and data.",
                "The core pillars are: strong passwords, updates, backups, awareness and least privilege.",
                "Good cybersecurity is a habit, not a product - technology plus informed behaviour."
            };
            keywordResponses["scam"] = new List<string>()
            {
                "Scams exploit trust. Common types: romance scams, tech support scams, and investment scams.",
                "If it sounds too good to be true or creates panic, pause and verify independently.",
                "Never share OTPs, PINs, or remote access to your computer with unsolicited callers."
            };
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please type a message so I can help you with cybersecurity.";

            string originalInput = input.Trim();
            string question = originalInput.ToLower();

            CaptureUserInfo(originalInput);

            // NEW: Confirm name / favourite so user knows it worked
            if (question.StartsWith("my name is ") || (question.StartsWith("i am ") && originalInput.Split(' ').Length <= 4))
            {
                if (!string.IsNullOrWhiteSpace(userName))
                    return $"Nice to meet you, {userName}! What cybersecurity topic do you want to explore first? Try passwords, phishing, or encryption.";
            }
            if (question.StartsWith("my favourite topic is ") || question.StartsWith("my favorite topic is "))
                return $"Great choice! {favouriteTopic} is a really important topic. Want me to tell you more about {favouriteTopic}?";

            // NEW: Help
            if (question == "help" || question.Contains("what can you do"))
                return "I can help with: passwords, phishing, malware, firewall, encryption, VPN, 2FA, privacy, scams, social engineering.\nAlso try: 'Add task', 'Start quiz', or 'Show log'.\nGo to the Quiz tab to play the 15-question mini-game.";

            if (question.Contains("add task") || question.Contains("remind me") || question.Contains("create task"))
            {
                string title = originalInput;
                if (title.ToLower().Contains("add task -")) title = title.Substring(title.ToLower().IndexOf("add task -") + 11).Trim();
                else if (title.ToLower().Contains("add task")) title = title.Substring(title.ToLower().IndexOf("add task") + 8).Trim().TrimStart('-', ' ', ':');
                else if (title.ToLower().Contains("remind me")) title = title.Substring(title.ToLower().IndexOf("remind me") + 9).Trim().TrimStart(':', ' ', '-');

                if (string.IsNullOrWhiteSpace(title))
                    return "What task should I add? Try: 'Add task - Review privacy settings'";
                return $"Got it! I will add: '{title}'. Go to the Task Assistant tab to see it. I also logged this in your Activity Log.";
            }
            if (question.Contains("show tasks") || question.Contains("my tasks") || question.Contains("pending tasks"))
                return "Go to the Task Assistant tab to see all your tasks. You can mark them Complete or Delete them there.";

            // 1. GREETINGS
            if (ContainsWordGroup(question, new[] { "hello", "hi", "hey", "good morning", "good afternoon", "good evening" }))
            {
                return !string.IsNullOrWhiteSpace(userName)
                   ? $"Hello {userName}! What cybersecurity topic can we explore today?"
                    : "Hello! I'm your cybersecurity awareness buddy. What's your name, and how can I help you stay safe online?";
            }

            // 2. FAREWELL
            if (ContainsWordGroup(question, new[] { "bye", "goodbye", "see you", "exit", "quit" }))
            {
                return !string.IsNullOrWhiteSpace(userName)
                   ? $"Goodbye {userName}! Remember to stay vigilant and stay safe online."
                    : "Goodbye! Stay safe and keep your digital life secure.";
            }

            // 3. IDENTITY
            if (question.Contains("who are you") || question.Contains("what are you"))
                return "I am a Cybersecurity Awareness Chatbot designed to educate you on passwords, phishing, malware, encryption, and safe online practices.";

            // 3b. THANK YOU
            if (question.Contains("thank"))
                return !string.IsNullOrWhiteSpace(userName) ? $"You're welcome, {userName}! Stay safe online." : "You're welcome! Stay safe online.";

            // 4. SENTIMENT
            foreach (string mood in worriedWords)
            {
                if (ContainsWord(question, mood))
                    return GetWorriedResponse(question, mood);
            }

            // 5. TELL ME MORE
            if (ContainsAny(question, "tell me more", "more info", "explain more", "what else", "elaborate", "more details"))
            {
                if (!string.IsNullOrWhiteSpace(lastTopic) && keywordResponses.ContainsKey(lastTopic))
                    return $"{GetRandomResponse(keywordResponses[lastTopic])}\n\nWould you like me to go deeper into {lastTopic}, {userName}?";
                return "I'd love to explain more! Which topic would you like me to dive deeper into? e.g., phishing, passwords, or encryption.";
            }

            // 6. KEYWORD MATCHING
            foreach (string keyword in keywordResponses.Keys.OrderByDescending(k => k.Length))
            {
                if (question.Contains(keyword))
                {
                    lastTopic = keyword;
                    return GetRandomResponse(keywordResponses[keyword]);
                }
            }

            // 7. MEMORY
            if (question.Contains("my name") || question.Contains("who am i"))
            {
                return !string.IsNullOrWhiteSpace(userName)
                   ? $"It's a pleasure to meet you {userName}!."
                    : "You haven't told me your name yet. Try saying 'My name is Alex'.";
            }
            if (question.Contains("favourite") || question.Contains("favorite"))
            {
                return !string.IsNullOrWhiteSpace(favouriteTopic)
                   ? $"{userName}, your favourite topic is {favouriteTopic} - you have great taste! Want to learn more about it?"
                    : "You haven't told me your favourite topic yet. Tell me with 'My favourite topic is phishing' for example.";
            }

            // 8. FALLBACK
            return "I'm still learning that topic. I'm best with cybersecurity - try asking me about: passwords, phishing, malware, firewall, encryption, VPN, 2FA, privacy, scams, or social engineering.";
        }

        private void CaptureUserInfo(string input)
        {
            string lower = input.ToLower().Trim();
            if (lower.StartsWith("my name is "))
            {
                string name = input.Substring(11).Trim();
                if (name.Length > 0 && name.Length < 25 && !worriedWords.Any(w => name.ToLower().Contains(w)))
                    userName = ToTitleCase(name);
            }
            else if (lower.StartsWith("i am ") && input.Split(' ').Length <= 4)
            {
                string possible = input.Substring(5).Trim();
                if (!worriedWords.Any(w => possible.ToLower().Contains(w)))
                    userName = ToTitleCase(possible);
            }
            if (lower.StartsWith("my favourite topic is "))
            {
                favouriteTopic = input.Substring(22).Trim().ToLower();
                lastTopic = favouriteTopic;
            }
            else if (lower.StartsWith("my favorite topic is "))
            {
                favouriteTopic = input.Substring(21).Trim().ToLower();
                lastTopic = favouriteTopic;
            }
        }

        private string GetWorriedResponse(string question, string detectedMood)
        {
            foreach (string keyword in keywordResponses.Keys.OrderByDescending(k => k.Length))
            {
                if (question.Contains(keyword))
                {
                    lastTopic = keyword;
                    return $"I hear that you're feeling {detectedMood} - that's completely understandable when it comes to {keyword}.\n" +
                           $"{GetRandomResponse(keywordResponses[keyword])}\n\nLet me know if you want me to break this down into simple steps, {userName}.";
                }
            }
            return $"It's okay to feel {detectedMood}, many people do when learning about online threats. I'm here to make it simple and stress-free. What topic is concerning you most?";
        }

        private string GetRandomResponse(List<string> responses)
        {
            if (responses == null || responses.Count == 0) return "I don't have info on that yet.";
            string result;
            int attempts = 0;
            do
            {
                result = responses[rng.Next(responses.Count)];
                attempts++;
            } while (result == lastResponse && responses.Count > 1 && attempts < 5);
            lastResponse = result;
            return result;
        }

        private bool ContainsAny(string text, params string[] phrases) => phrases.Any(p => text.Contains(p));
        private bool ContainsWordGroup(string text, string[] phrases) => phrases.Any(p => ContainsWord(text, p));
        private bool ContainsWord(string text, string word)
        {
            var tokens = text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens.Contains(word) || text.StartsWith(word + " ") || text.EndsWith(" " + word) || text == word;
        }
        private string ToTitleCase(string s) => string.IsNullOrWhiteSpace(s) ? s : char.ToUpper(s[0]) + s.Substring(1).ToLower();
    }
}