# CybieeeBot — Part 2: WPF GUI Cybersecurity Awareness Chatbot

## Overview
CybieeeBot is a WPF-based Cybersecurity Awareness Chatbot for Windows. Part 2 expands the console application into a fully featured GUI matching the **cybieee.com** Figma design with a red-orange gradient theme.

## Part 2 Features Implemented

### 1. GUI Design (WPF)
- Borderless, rounded-corner window with red-orange gradient background (matches Figma mockup)
- **Splash screen** with animated ASCII art, sound-wave icon, name entry, and accessibility toggle
- **Chat window** with bubble-style messages, quick-prompt chips, animated waveform status bar
- Sound-wave icon in header, drag-to-move, minimise/close controls
- High Contrast accessibility mode toggle

### 2. Keyword Recognition
Recognises cybersecurity keywords and responds with relevant guidance:
- `password`, `phishing`, `scam`, `privacy`, `malware`, `2fa`, `wifi`, `browsing`, `social engineering`, and more

### 3. Random Responses
For phishing, password, privacy, malware, and Wi-Fi topics, the bot randomly selects from 5-6 predefined tips (stored in `Dictionary<string, List<string>>`).

### 4. Conversation Flow
- Detects follow-up phrases: "tell me more", "give me another tip", "explain more", "elaborate", etc.
- Continues on the same topic without restarting the conversation

### 5. Memory & Recall
- Stores user name, favourite topic, and topic history in `Dictionary<string, string>` and `List<string>`
- Personalises responses based on expressed interests
- Type "what do you remember about me?" to trigger a full recall

### 6. Sentiment Detection
Detects and responds to: `worried`, `scared`, `frustrated`, `angry`, `confused`, `curious`, `excited`
- Adjusts tone to be empathetic or encouraging
- Automatically continues with a relevant tip (no re-prompting needed)

### 7. Error Handling
- Default fallback for unrecognised input
- Empty input handled gracefully with shake animation
- All exceptions caught to prevent crashes

### 8. Code Optimisation
- OOP: `ChatbotEngine`, `ResponseEngine`, `MemoryStore`, `SentimentDetector`, `AudioPlayer`
- Generics: `Dictionary<string[], ResponseBuilder>`, `List<string>`, `Dictionary<string, List<string>>`
- Delegates: `ResponseBuilder` delegate, `SentimentHandler` delegate

## Project Structure
```
CybieeeBot/
├── App.xaml / App.xaml.cs
├── Audio/
│   └── AudioPlayer.cs
├── Core/
│   ├── ChatbotEngine.cs
│   ├── MemoryStore.cs
│   └── SentimentDetector.cs
├── Responses/
│   └── ResponseEngine.cs
├── UI/
│   ├── SplashWindow.xaml / .cs
│   └── ChatWindow.xaml / .cs
├── greeting.wav
└── CybieeeBot.csproj
```

## How to Run
1. Requires **.NET 8 SDK** (Windows)
2. Open in Visual Studio 2022 or run:
   ```
   dotnet build
   dotnet run
   ```
3. Enter your name on the splash screen and click **Start Chatting**

## Design Inspiration
The GUI is based on the Figma mockup with:
- Red-to-dark-red gradient background
- `Segoe UI Light` branding font
- Dark bubble cards for messages
- Sound-wave icon in header
- Pill/chip quick-prompt buttons
- Animated waveform typing indicator
