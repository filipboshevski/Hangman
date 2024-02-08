# Hangman Game (WinForms .NET C#)

## Overview

Welcome to **Hangman**, a classic word-guessing game developed using WinForms and .NET C# by Filip Boshevski. Challenge your vocabulary and enjoy a visually appealing interface while playing Hangman.

## 1. Features

1. **Intuitive Interface:**
   - A user-friendly graphical interface built with WinForms.
   - Seamless navigation for an immersive gaming experience.

2. **Word Diversity:**
   - Randomly selected words from a diverse word bank for varied gameplay.

3. **User Feedback:**
   - Dynamic updates on guessed letters, providing instant feedback.
   - Track your progress and celebrate victories.

4. **Customization Options:**
   - Adjustable difficulty levels.
   - Set custom word categories for a personalized challenge.

5. **Winning Streaks:**
   - Keep track of your winning streaks.
   - Challenge friends and see who achieves the longest streak.

6. **Codebase Clarity:**
   - Well-documented C# code for educational purposes.
   - Explore and learn about WinForms development.

## 2. Getting Started

1. **New Game:**
   - Click **Start** in the initial window to begin a new game.
   - After a successful guess, a popup appears, allowing you to start a new game.
  
  ![alt text][new_game_screen]

2. **Reset:**
   - Use the **Reset** option to reset the game at any point.
   - A confirmation popup ensures you want to reset the game.

  ![alt text][resetiraj]

3. **Help Option:**
   - Press **Help Option** to reveal a random letter in the word.
   - Limited to 2 help options.

  ![alt text][pomos_izbor]

4. **Rules:**
   - Guess the word before the entire hangman is drawn.
   - 6 incorrect choices allowed (1 for head, 1 for body, 1 for each arm, 1 for each leg).
   - 2 help options available to reveal letters.
   - No repeating letter selections.

## 3. Solving the problem

### 3.1 Data structures

The main logic and methods for the game are stored in ```public class Scene``` which stores the game's state in an instance of ```public class State``` and the hanger's state in an instance of ```public class Hanger```.

```c#
public class Scene
{
	private State State { get; set; }

	private Besilka Window { get; set; }

	private Pen HangerPen { get; set; }

	private Pen RopePen { get; set; }

	private Hanger Hanger { get; set; }

	private static string Words = "Бесилка,Здраво,Филтер,Мајмун,Јаже,Кајмак,Сирење,Стол,Лепило,Плоча,Картон,Ножица,Стакло,Компјутер,Ризик,Полнач";

	public Scene(Besilka window)
	{
	    Window = window;
	    State = new State();
	    
	    InitializeVars();
	    AddButtons();
	}

	// Method implementations can be found in the actual code

	private void InitializeVars() {}
	
	public void StartGame() {}

	private void SelectWord() {}

	private void AddLabels() {}

	private void ResetControls() {}

	private void onBtnClick(object sender, EventArgs e) {}

	private void FillChar(char charClicked) {}

	public void GetHelp() {}

	private void ResetStartButton() {}

	private void AddButtons() {}

	public void Draw(Graphics g) {}
}
```

### 3.1.1 State
```c#
public class State
{
	public State()
	{
		Letters = new List<Label>();
		HangState = HangState.None;
		HelpLeft = 2;
	}

	public List<Label> Letters { get; set; }

	public string Word { get; set; }

	public string EmptyChar => "__";

	public HangState HangState { get; set; }

	public int InitialChoicesLeft => Enum.GetValues(typeof(HangState)).Length - 1;

	public int HelpLeft { get; set; }
}
```
With this class we define the game's state.

### 3.1.2 Hanger
```c#
public class Hanger
{
	public Hanger()
	{
		HangerPoints = new Dictionary<string, Point>();
	}

	public Dictionary<string, Point> HangerPoints { get; set; }

	public Point Rope { get; set; }

	public Point Body { get; set; }

	public Point Head { get; set; }

	public Point LeftArm { get; set; }

	public Point RightArm { get; set; }

	public Point LeftLeg { get; set; }

	public Point RightLeg { get; set; }

	public static int HeadDiameter = 40;

	public static int BodyHeight = 85;

	public static int RopeLength = 40;

	public static Point ArmOffset = new Point(30, 50);

	public static Point LegOffset = new Point(40, 40);
}
```
With this class, we define the hanger's state and configurations.

### 3.2 Algorithms

In order to have different combinations each game, random word generation is used from a list of words or a text file.

### 3.2.1 Start state
`StartGame();`
Calling this method first checks if there is already a game in progress, thus displaying a new game confirmation window.

After resetting the controls, a random word is selected from the list and the dashes are placed in the game.

### 3.2.2 On letter click
`onBtnClick();`
For each letter button, the onBtnClick event handler is added. This method takes the letter of the clicked button and checks if it exists in the word.

If the letter is present, it finds all instances in the blanks and replaces them with the chosen letter.

Otherwise, it increments the hangman state by 1. When it reaches the right leg, the game ends, and a popup with a message is displayed.

`FillChar();`
This method performs the replacement of all blanks in the word containing the selected letter.

If all blanks are filled, the game ends, and a popup with a message is displayed.
		
### 3.2.3 Help option
`GetHelp();`
With the click of **(Помош избор)** or the menu option **(Помош избор)**, the above method is called which replaces one dash in the word with a letter.

With each help, the number of help options is decreased by 1.

### 3.2.3 Hanger drawing
`Draw();`
With the help of this method, the hanger is displayed in cascade.

First, all the variables needed for the drawing are initialized, then for each part of the person it's checked individually according to the hanger's state and drawn.
### 3.3 GUI

A panel control was used to represent the hanger by drawing the components according to its dimensions as an offset.


[new_game_screen]: https://raw.githubusercontent.com/filipboshevski/besilka/master/Sliki/start_screen.png "Слика 1"
[resetiraj]: https://raw.githubusercontent.com/filipboshevski/besilka/master/Sliki/resetiraj.png "Слика 2"
[pomos_izbor]: https://raw.githubusercontent.com/filipboshevski/besilka/master/Sliki/pomos_izbor.png "Слика 3"
