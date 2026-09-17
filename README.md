## Cybersecurity Chatbot


## Project Overview

This project is a Windows Forms cybersecurity chatbot developed in C#. The chatbot provides users with simple information about cybersecurity topics through a graphical user interface (GUI).

The user can type a question or message into the input box, press the Send button, and receive a response from the chatbot.

The chatbot is designed to demonstrate:

GUI development using Windows Forms

Object-oriented programming

Keyword recognition

Sentiment detection

Randomised responses

Conversation memory

User information capture

Event handling

Basic error handling

Separation of the user interface from chatbot logic

## Main Features


## Project Structure

The project is separated into different files so that the GUI and chatbot logic are not mixed together.

WindowsFormsApp
│
├── Form1.cs
├── Form1.Designer.cs
├── Program.cs
├── ChatEngine.cs
├── Logo.cs
│
└── Voice
    └── aisound.wav


## How the Chatbot Works

The chatbot follows this general process:

User enters a message
        ↓
User presses Send
        ↓
Form1 receives the message
        ↓
Form1 calls GetResponse()
        ↓
ChatEngine analyses the message
        ↓
Check for empty input
        ↓
Check for sentiment
        ↓
Check for follow-up questions
        ↓
Check for cybersecurity keywords
        ↓
Check remembered information
        ↓
Use fallback response if nothing matches
        ↓
Response returned to Form1
        ↓
Response displayed in txtLog

## MIT LICENCE
@ MOLEBOGENG MAUMAU
