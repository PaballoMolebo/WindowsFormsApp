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

## License

Molebogeng Maumau © 2026. All rights reserved. 

## Author / Contact

Molebogeng Maumau  
For issues or feature requests, please open an issue on the repository.
