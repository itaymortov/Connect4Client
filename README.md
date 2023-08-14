# Connect4 Game Client - README

This repository contains a C# Windows Forms application for playing the game Connect4 against an AI opponent. The game communicates with a server to handle game logic and provide a multiplayer experience. Here's a brief overview of the components and functionality in this code

## Requirements

- Visual Studio This project is developed using C# and Windows Forms, so you'll need Visual Studio (or an equivalent development environment) to compile and run the application.

## Getting Started

1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Build and run the application.

## Components

1. `Connect4Database` This represents the database used to store game-related data, such as moves and game information.

2. `Player` Represents a player with details like ID, first name, phone number, and country.

3. `Game` Represents a game with a unique ID.

4. `Move` Represents a move made during the game, including the player's ID, column chosen, move number, and whether it's the player's turn.

5. `Form1` (Main Form) This is the primary form of the application. It handles game setup, player authentication, game management, and interactions with the Connect4 server.

## Features

- Player registration and login (Connecting to the server, Found in another repository).
- Start a new game against the AI opponent.
- Fetch the list of games for the current player.
- View game history and re-create game state.
- Play Connect4 against the AI opponent with interactive features.

## Important Methods

- `start_Game()` Initiates a new game, communicates with the server to start a game.
- `serverTurn()` Handles the AI opponent's turn by communicating with the server to get the opponent's move.
- `makeMove()` Makes a move on the game board based on player or AI input.
- `CheckForWin(int playerID)` Checks if a player has won the game.
- `EndGame()` Handles the end of the game, updating UI and communicating with the server.
- `reCreateGame(int gameId)` Recreates a game state based on the selected game from the ComboBox.

## API Interaction

The application communicates with a server using HTTP requests (GET and POST) to interact with the game logic, including starting games, making moves, and ending games. The base URL for the server is set in the `Form1_Load` method.

## Usage

1. Register or log in as a player.
2. Start a new game or select an existing game from the list.
3. Play the game by clicking on the desired column to drop a token.
4. Enjoy the game and see the outcome!
   
Note Make sure the server is running for the application to function correctly.

## Additional Improvements

- Enhanced error handling and user feedback.
- UI improvements for a more enjoyable user experience.
- Enhanced game logic and AI opponent capabilities.

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute it as needed.

For any questions or issues, please open an issue in this repository.
