using System;
using System.Collections.Generic;

public class ChatEngine
{
    // Information remembered between messages
    private string userName = "";
    private string favouriteTopic = "";
    private string lastTopic = "";

    // Used to make responses less repetitive
    private Random rng = new Random();

    // Cybersecurity keywords and possible responses
    private Dictionary<string, List<string>> keywordResponses =
        new Dictionary<string, List<string>>();

    // Words that indicate the user's mood
    private List<string> worriedWords = new List<string>()
    {
        "worried",
        "scared",
        "nervous",
        "frustrated",
        "confused",
        "afraid",
        "concerned",
        "anxious"
    };

    public ChatEngine()
    {
        // Passwords
        keywordResponses["password"] = new List<string>()
        {
            "Use a long, unique password for every account.",
            "A strong password should be long, difficult to guess, and different from your other passwords.",
            "Consider using a reputable password manager to create and store strong passwords."
        };

        // Phishing
        keywordResponses["phishing"] = new List<string>()
        {
            "Phishing is a scam where attackers try to trick you into revealing information.",
            "Be careful with unexpected emails or messages asking you to click links or provide passwords.",
            "Check the sender and website address carefully before clicking suspicious links."
        };

        // Malware
        keywordResponses["malware"] = new List<string>()
        {
            "Malware is malicious software designed to damage systems or steal information.",
            "Keep your operating system and security software updated to reduce malware risks.",
            "Avoid downloading files from unknown or untrusted sources."
        };

        // Antivirus
        keywordResponses["antivirus"] = new List<string>()
        {
            "Antivirus software can help detect and remove malicious software.",
            "Keep your security software updated so it can recognise newer threats.",
            "Antivirus protection works best when combined with safe browsing habits."
        };

        // Firewall
        keywordResponses["firewall"] = new List<string>()
        {
            "A firewall helps control network traffic entering or leaving your computer.",
            "Firewalls provide an important layer of protection against unwanted network connections.",
            "Make sure the firewall on your computer or network is properly configured."
        };

        // Hacking
        keywordResponses["hacking"] = new List<string>()
        {
            "Hacking can involve exploiting weaknesses in computers, networks, or applications.",
            "Protect your systems by keeping software updated and using strong authentication.",
            "Ethical hacking is used to find security weaknesses so they can be fixed."
        };

        // Two-factor authentication
        keywordResponses["2fa"] = new List<string>()
        {
            "Two-factor authentication adds another security step after your password.",
            "2FA can protect an account even if someone discovers your password.",
            "Where available, enable two-factor authentication on important accounts."
        };

        keywordResponses["two factor"] = new List<string>()
        {
            "Two-factor authentication adds another security step after your password.",
            "2FA can protect an account even if someone discovers your password.",
            "Where available, enable two-factor authentication on important accounts."
        };

        // Encryption
        keywordResponses["encryption"] = new List<string>()
        {
            "Encryption converts information into a form that unauthorised people cannot easily read.",
            "Encryption helps protect sensitive information while it is stored or transmitted.",
            "Many secure websites use encryption to protect information sent between your browser and the website."
        };

        // VPN
        keywordResponses["vpn"] = new List<string>()
        {
            "A VPN can encrypt network traffic between your device and the VPN service.",
            "A VPN can provide additional privacy on some networks, but it does not make you completely anonymous.",
            "Use a trustworthy VPN provider and remember that a VPN is only one part of online security."
        };

        // Social engineering
        keywordResponses["social engineering"] = new List<string>()
        {
            "Social engineering involves manipulating people into revealing information or performing actions.",
            "Be cautious when someone creates urgency or pressure to make you reveal sensitive information.",
            "Verify unusual requests independently instead of relying only on the message you received."
        };

        // Data privacy
        keywordResponses["privacy"] = new List<string>()
        {
            "Review the privacy settings on your online accounts regularly.",
            "Avoid sharing unnecessary personal information online.",
            "Think carefully about what information an app or website is asking you to provide."
        };

        // Cybersecurity
        keywordResponses["cybersecurity"] = new List<string>()
        {
            "Cybersecurity is about protecting computers, networks, accounts, and information from threats.",
            "Good cybersecurity includes strong passwords, updates, secure browsing, and awareness of scams.",
            "Cybersecurity combines technology, good security practices, and user awareness."
        };
    }

    // Main method called by the GUI
    public string GetResponse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "Please type a question or message so I can help you.";
        }

        string question = input.Trim().ToLower();

        // Remember information supplied by the user
        CaptureUserInfo(input);

        // Greetings
        if (ContainsAny(question, "hello", "hi", "hey", "good morning",
                        "good afternoon", "good evening"))
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                return "Hello " + userName +
                       "! What cybersecurity question can I help you with?";
            }

            return "Hello! What cybersecurity question can I help you with?";
        }

        // Goodbye
        if (ContainsAny(question, "bye", "goodbye", "see you"))
        {
            return "Goodbye! Stay safe online.";
        }

        // User asks who the chatbot is
        if (ContainsAny(question, "who are you", "what are you",
                        "your name"))
        {
            return "I am a cybersecurity chatbot. I can answer questions about topics such as passwords, phishing, malware, firewalls, encryption and online safety.";
        }

        // Sentiment check
        foreach (string worriedWord in worriedWords)
        {
            if (ContainsWord(question, worriedWord))
            {
                return GetWorriedResponse(question);
            }
        }

        // Follow-up questions
        if (ContainsAny(question,
            "tell me more",
            "more information",
            "explain more",
            "what else",
            "can you explain",
            "give me more"))
        {
            if (!string.IsNullOrWhiteSpace(lastTopic) &&
                keywordResponses.ContainsKey(lastTopic))
            {
                return GetRandomResponse(keywordResponses[lastTopic]) +
                       " Would you like to know more about " +
                       lastTopic + "?";
            }

            return "I can explain more. Please tell me which cybersecurity topic you would like to discuss.";
        }

        // Find a cybersecurity keyword
        foreach (string keyword in keywordResponses.Keys)
        {
            if (question.Contains(keyword))
            {
                lastTopic = keyword;

                return GetRandomResponse(keywordResponses[keyword]);
            }
        }

        // Name-related question
        if (question.Contains("what is my name"))
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                return "Your name is " + userName + ".";
            }

            return "You haven't told me your name yet.";
        }

        // Favourite topic
        if (question.Contains("favourite topic") ||
            question.Contains("favorite topic"))
        {
            if (!string.IsNullOrWhiteSpace(favouriteTopic))
            {
                return "Your favourite topic is " + favouriteTopic + ".";
            }

            return "You haven't told me your favourite topic yet.";
        }

        // Fallback response
        return "I'm not sure about that yet. Try asking me about passwords, phishing, malware, firewalls, encryption, VPNs, 2FA, privacy, hacking, or cybersecurity.";
    }

    // Stores information the user provides
    private void CaptureUserInfo(string input)
    {
        string question = input.Trim();

        string lowerQuestion = question.ToLower();

        // Examples:
        // "My name is John"
        // "I am John"
        if (lowerQuestion.StartsWith("my name is "))
        {
            userName = question.Substring(11).Trim();
        }
        else if (lowerQuestion.StartsWith("i am "))
        {
            string possibleName = question.Substring(5).Trim();

            // Avoid treating normal statements such as
            // "I am worried" as a person's name.
            if (!ContainsAny(possibleName.ToLower(),
                "worried", "scared", "nervous", "confused",
                "frustrated", "afraid"))
            {
                userName = possibleName;
            }
        }

        // Examples:
        // "My favourite topic is phishing"
        // "My favorite topic is passwords"
        if (lowerQuestion.StartsWith("my favourite topic is "))
        {
            favouriteTopic = question.Substring(22).Trim();
        }
        else if (lowerQuestion.StartsWith("my favorite topic is "))
        {
            favouriteTopic = question.Substring(21).Trim();
        }
    }

    // Creates a softer response when the user sounds worried
    private string GetWorriedResponse(string question)
    {
        foreach (string keyword in keywordResponses.Keys)
        {
            if (question.Contains(keyword))
            {
                lastTopic = keyword;

                return "It's understandable to be concerned. " +
                       GetRandomResponse(keywordResponses[keyword]);
            }
        }

        return "It's understandable to feel concerned. I can help explain the cybersecurity issue step by step.";
    }

    // Selects a random response from a list
    private string GetRandomResponse(List<string> responses)
    {
        if (responses == null || responses.Count == 0)
        {
            return "I don't have an answer for that topic yet.";
        }

        int index = rng.Next(responses.Count);
        return responses[index];
    }

    // Checks whether a message contains one of several phrases
    private bool ContainsAny(string text, params string[] phrases)
    {
        foreach (string phrase in phrases)
        {
            if (text.Contains(phrase))
            {
                return true;
            }
        }

        return false;
    }

    // Checks for a complete word rather than part of another word
    private bool ContainsWord(string text, string word)
    {
        string[] words = text.Split(
            new char[] { ' ', '.', ',', '!', '?', ';', ':', '-', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries);

        foreach (string currentWord in words)
        {
            if (currentWord == word)
            {
                return true;
            }
        }

        return false;
    }
}
