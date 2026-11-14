# Cybersecurity Chatbot (WindowsFormsApp)

A simple Windows Forms cybersecurity chatbot implemented in C# targeting .NET 8 (C# 12). The application demonstrates a small GUI that answers common cybersecurity questions and offers basic guidance on passwords, phishing, malware, encryption, 2FA, VPNs, and online safety.

## Project Overview

This project contains a Windows Forms GUI and a separate chatbot engine. The chatbot recognises keywords, checks sentiment cues, remembers simple user information, and returns randomized responses to reduce repetition.

Key demonstrations:
- Windows Forms GUI development
- Object-oriented design and separation of concerns
- Keyword recognition and sentiment detection
- Conversation memory and follow-up handling
- Event handling and simple error handling

## Prerequisites

- Windows 10 or Windows 11
- Visual Studio 2022 (17.9+) with .NET Desktop Development workload
- .NET 8 SDK

## Get started

1. Clone the repository
2. Open the solution
- Double-click `WindowsFormsApp.sln` or use __File > Open > Project/Solution__ in Visual Studio.
- Ensure the startup project is correct and the Target Framework is set to `.NET 8`.

3. Build and run
- In Visual Studio: press `F5` to run with the debugger or `Ctrl+F5` to run without the debugger.
- From the command line:Note: Running WinForms from the command line requires Windows.

## Usage

- Type a question or greeting in the chat input and press Enter or click Send.
- The chatbot recognises keywords such as `password`, `phishing`, `malware`, `encryption`, `vpn`, `2fa`, and returns helpful advice.
- The chatbot also detects worried language (e.g., "anxious", "scared") to offer supportive replies.

## Project Structure

## How the chatbot works (high level)

1. User enters a message.
2. Form1 receives the message and calls `ChatEngine.GetResponse`.
3. `ChatEngine`:
   - ignores empty input,
   - captures user information if provided,
   - checks sentiment and worried words,
   - checks for follow-up or remembered context,
   - scans for cybersecurity keywords and returns a relevant randomized response,
   - falls back to a generic help response if no match is found.
4. Response is displayed in the chat log (`txtLog`).

## Contributing

Contributions are welcome.

## Coding standards

- Targets C# 12 and .NET 8. 
 

# Cybersecurity Chatbot (WindowsFormsApp)

A Windows Forms cybersecurity chatbot implemented in C# targeting .NET 8 (C# 12). The application demonstrates a GUI chatbot that answers common cybersecurity questions, plus a **15-question Quiz Mini-Game**, a **Task Assistant**, and an **Activity Log** - all connected through the chatbot.

The project demonstrates Windows Forms GUI development, object-oriented design, keyword recognition, sentiment detection, conversation memory, randomized responses, quiz logic, and task management.

## Features

###  Cybersecurity Chatbot - `Services/ChatbotEngine.cs`
- **Keyword recognition** for: `password`, `phishing`, `malware`, `antivirus`, `firewall`, `hacking`, `2fa`, `two factor`, `encryption`, `vpn`, `social engineering`, `privacy`, `cybersecurity`, `scam`
- **3+ varied responses per keyword** - randomized with `GetRandomResponse()` that avoids repeating the last answer
- **Sentiment detection** - detects `worried`, `scared`, `nervous`, `frustrated`, `confused`, `afraid`, `concerned`, `anxious`, `overwhelmed`, `stressed`, `angry`, `upset`, `lost` and combines mood + topic, e.g. "I'm worried about phishing" gives an empathetic + phishing answer
- **Conversation memory** - remembers `userName`, `favouriteTopic`, `lastTopic`
    - `My name is Alex` -> "Nice to meet you, Alex!"
    - `My favourite topic is phishing` -> remembers it
    - `What is my name?` / `What is my favourite topic?` -> recalls it
    - `Tell me more` / `What else?` -> uses `lastTopic` to go deeper
- **Greetings & Farewell** - personalized if name is known
- **Help command** - type `help` to see all commands
- **Thank you handling** - `thank you` -> personalized reply
- **Cross-tab intents** - Chat understands other tabs:
    - `Add task - Review privacy settings` -> adds a task
    - `Start quiz` / `Play game` -> tells user to go to Quiz tab
    - `Show log` / `Show tasks` -> tells user to go to Activity Log / Task Assistant tab

### 2. Quiz Mini-Game - `Services/QuizService.cs` - 15 Questions
- **10 Multiple Choice + 5 True/False questions** covering passwords, phishing, 2FA, social engineering, HTTPS, public Wi-Fi, ransomware, backups, updates, locking your computer
- **Shuffled every time** - `GetShuffledQuestions()` uses `Random` so order is different on every play
- **Safe copy** - `GetQuestions()` returns a copy so Form1 cannot accidentally change the real list
- **Score + Feedback** - after each answer shows `Correct!` / `Incorrect` + explanation in green/red, locks RadioButtons so answer cannot be changed
- **Final Results** - shows `Final Score: X / 15` + `Percentage: XX%` + message:
    - `>= 80%` -> "Excellent work! You're a cybersecurity pro!"
    - `>= 50%` -> "Good effort! Keep learning..."
    - `< 50%` -> "Keep practising! Continue learning..."
- **True/False handling** - Q11-Q15 only have 2 options, Form1 hides C and D and unchecks all options first so no answer is pre-selected

### 3. Task Assistant - `Data/TaskRepository.cs` + `Models/TaskItem.cs`
- Uses your **existing file names** - no new `TaskService.cs` file needed
- **Task model** - `TaskItem` has `Id`, `Title`, `Description`, `DueDate`, `IsCompleted`, `CreatedAt`, `StatusText`
- **Repository** - `TaskRepository` has `AddTask()`, `GetAllTasks()`, `GetPendingTasks()`, `GetCompletedTasks()`, `GetPendingCount()`, `MarkComplete()`, `DeleteTask()`, `GetTaskById()`, `GetDueToday()`, `GetOverdue()`
- **3 starter tasks** on first run: Review privacy settings, Update passwords, Run antivirus scan
- **GUI** - Add Task with Title + Description + Due Date (DateTimePicker), click a task to see details, **Mark Complete** and **Delete Task** with confirmation
- **Due Today / Overdue reminders** - on startup, chatbot shows a message if you have tasks due today or overdue
- **Chat integration** - `Add task - Update antivirus` in Chat is parsed and logged

### 4. Activity Log - Tab `Activity Log`
- Logs every important action with timestamp: App started, Chat message, Quiz started, Quiz completed with score, Task added / completed / deleted
- Shows last 10 activities by default, **Show More** button shows full history
- Accessible from Chat via `Show log` / `Show more`

### 5. Chat UI - `Form1.cs`
- Modern chat bubbles - user = SeaGreen on right, bot = Dark Navy on left
- `FlowLayoutPanel` with auto-scroll, bubbles resize with window via `ResizeChatRows()` using `TextRenderer.MeasureText()`
- Enter key sends message, input clears and focuses again after send
- Logo loaded from `Application.StartupPath/logo.png` with fallback to `C:\Users\Student\Pictures\Screenshots\logo.png`

## Project Overview

This project contains a Windows Forms GUI and separate service / data layers. The chatbot recognises keywords, checks sentiment cues, remembers simple user information, and returns randomized responses to reduce repetition.

Key demonstrations:
- Windows Forms GUI development with TabControl (Chat, Task Assistant, Quiz, Activity Log)
- Object-oriented design and separation of concerns
- Keyword recognition and sentiment detection
- Conversation memory and follow-up handling
- Quiz logic: shuffling, scoring, feedback, True/False handling
- Task management: CRUD, due dates, reminders
- Event handling and simple error handling
- Activity logging

## Prerequisites

- Windows 10 or Windows 11
- Visual Studio 2022 (17.9+) with .NET Desktop Development workload
- .NET 8 SDK

## Get started

1. Clone the repository
2. Open the solution
- Double-click `WindowsFormsApp.sln` or use **File > Open > Project/Solution** in Visual Studio.
- Ensure the startup project is correct and the Target Framework is set to `.NET 8`.

3. Build and run
- In Visual Studio: press `F5` to run with the debugger or `Ctrl+F5` to run without the debugger.
- Or `Ctrl + Shift + B` to build only.
- From the command line: `dotnet build` then `dotnet run`

Note: Running WinForms from the command line requires Windows.

## Usage

### Chat Tab
- Type a question or greeting in the chat input and press Enter or click Send.
- Try: `Hello`, `My name is Alex`, `My favourite topic is phishing`, `Tell me more`, `What is phishing?`, `I'm worried about scams`, `help`
- Try cross-tab: `Add task - Review privacy settings`, `Start quiz`, `Show log`

### Quiz Tab
1. Click **Start Quiz** - questions are shuffled.
2. Select A / B / C / D (or True / False for Q11-Q15) and click **Submit Answer**.
3. Read feedback + explanation.
4. Click **Next Question** until Q15, then **View Results** to see final score + percentage.
5. Click **Play Again** to restart with a new shuffle.

### Task Assistant Tab
1. Type Title, Description, Due Date and click **Add Task**.
2. Click a task in the list to see details on the right.
3. Click **Mark Complete** to mark it completed.
4. Click **Delete Task** > Yes to delete it.
5. Check the Pending / Total counter at the bottom.

### Activity Log Tab
- See your recent activities. Click **Show More** for full history.

## Project Structure



## License

Molebogeng Maumau © 2026. All rights reserved. 

