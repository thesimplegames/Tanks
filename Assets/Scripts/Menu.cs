using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GUIStyle TextStyle, ButtonStyle, TextNearFieldStyle, FieldStyle, BulletText, ControlsStyle, ButtonInputStyle;
	
	//int FontSize;
	
	bool Settings = false;
	bool GameSettings = false;
	bool HandleSettings = false;
	bool About=false;
	
	Event Ev;
	
	KeyCode Player1Up = KeyCode.W;
	KeyCode Player1Down = KeyCode.S;
	KeyCode Player1Left = KeyCode.A;
	KeyCode Player1Right = KeyCode.D;
	KeyCode Player1Shoot = KeyCode.Space;
	
	string Player1UpSt;
	string Player1DownSt;
	string Player1LeftSt;
	string Player1RightSt;
	string Player1ShootSt;
	
	bool Player1UpInput = false;
	bool Player1DownInput = false;
	bool Player1LeftInput = false;
	bool Player1RightInput = false;
	bool Player1ShootInput = false;
	
	KeyCode Player2Up = KeyCode.UpArrow;
	KeyCode Player2Down = KeyCode.DownArrow;
	KeyCode Player2Left = KeyCode.LeftArrow;
	KeyCode Player2Right = KeyCode.RightArrow;
	KeyCode Player2Shoot = KeyCode.Keypad0;
	
	string Player2UpSt;
	string Player2DownSt;
	string Player2LeftSt;
	string Player2RightSt;
	string Player2ShootSt;
	
	bool Player2UpInput = false;
	bool Player2DownInput = false;
	bool Player2LeftInput = false;
	bool Player2RightInput = false;
	bool Player2ShootInput = false;
	
	public static int PlayerLife = 1;
	public static int EnemyLife = 1;
	public static int FlagLife = 1;
	public static float BulletSpeed = 10.0f;
	
	string PlayerLifeValue = "1";
	string EnemyLifeValue = "1";
	string FlagLifeValue = "1";
	
	string LastPlayerLifeValue = "1";
	string LastEnemyLifeValue = "1";
	string LastFlagLifeValue = "1";
	
	bool IsNumber (string Str) {
		bool f = false;
		if (Str == "1") f = true;
		if (Str == "2") f = true;
		if (Str == "3") f = true;
		if (Str == "4") f = true;
		if (Str == "5") f = true;
		if (Str == "6") f = true;
		if (Str == "7") f = true;
		if (Str == "8") f = true;
		if (Str == "9") f = true;
		if (Str == "") f = true;
		return f;
	}
	
	void StartGame() {
		
	}
	
	void OnGUI () {
		
		TextStyle.fontSize = Screen.height/20;
		ButtonStyle.fontSize = Screen.height/50; 
		TextNearFieldStyle.fontSize = Screen.height/50;
		FieldStyle.fontSize = Screen.height/50;		
		BulletText.fontSize = Screen.height/50;
		ControlsStyle.fontSize = Screen.height/30;
		
		
		if ((!Settings)&&(!About)) {
			      GUI.Box(new Rect(Screen.width/16*7, Screen.height/16*4, Screen.width/8, Screen.height/16), "Menu", TextStyle);
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*7, Screen.width/8, Screen.height/16), "Start game",ButtonStyle)) StartGame();
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*9, Screen.width/8, Screen.height/16), "Options", ButtonStyle)) Settings = true;
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*11,Screen.width/8, Screen.height/16), "About", ButtonStyle)) About = true;
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*13,Screen.width/8, Screen.height/16), "Exit", ButtonStyle)) Application.Quit();
		
		}
		
		if ((Settings)&&(GameSettings)) {
			GUI.Box (new Rect (Screen.width/16*7, Screen.height/2-Screen.height/4, Screen.width/8, Screen.height/16), "Game Options", TextStyle);
			
			                           GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*11, Screen.width/9, Screen.height/16 - Screen.height/64), "Bullet Speed", BulletText);
			BulletSpeed = GUI.HorizontalSlider (new Rect (Screen.width/16*7, Screen.height/16*12, Screen.width/9, Screen.height/16), BulletSpeed, 5, 20);
			
			                       GUI.Box (new Rect(Screen.width/16*7, Screen.height/16*7, Screen.width/8, Screen.height/16), "Player Lifes", TextNearFieldStyle);
			PlayerLifeValue = GUI.TextField(new Rect(Screen.width/16*9 - Screen.width/32, Screen.height/16*7, Screen.height/32, Screen.height/32),PlayerLifeValue,1,FieldStyle);
			
			if (IsNumber(PlayerLifeValue)) LastPlayerLifeValue = PlayerLifeValue; else PlayerLifeValue = LastPlayerLifeValue;
			
			                      GUI.Box (new Rect(Screen.width/16*7, Screen.height/2, Screen.width/8, Screen.height/16), "Enemy Lifes", TextNearFieldStyle);
			EnemyLifeValue = GUI.TextField(new Rect(Screen.width/16*9 - Screen.width/32, Screen.height/2, Screen.height/32, Screen.height/32), EnemyLifeValue, 1, FieldStyle);
			
			if (IsNumber(EnemyLifeValue)) LastEnemyLifeValue = EnemyLifeValue; else EnemyLifeValue = LastEnemyLifeValue;
			
			                     GUI.Box (new Rect(Screen.width/16*7, Screen.height/16*9, Screen.width/8, Screen.height/16), "Flag Lifes", TextNearFieldStyle);
			FlagLifeValue = GUI.TextField(new Rect(Screen.width/16*9 - Screen.width/32, Screen.height/16*9, Screen.height/32, Screen.height/32), FlagLifeValue, 1, FieldStyle);
			
			if (IsNumber(FlagLifeValue)) LastFlagLifeValue = FlagLifeValue; else FlagLifeValue = LastFlagLifeValue;
			
			if(GUI.Button(new Rect(Screen.width/16*7,Screen.height/16*13,Screen.width/8,Screen.height/16),"Back", ButtonStyle)) GameSettings = false;
		}
		
		if ((Settings)&&(HandleSettings)) {
				Ev = Event.current;
				
				Player1UpSt = Player1Up.ToString();
				Player1DownSt = Player1Down.ToString();
				Player1LeftSt = Player1Left.ToString();
				Player1RightSt = Player1Right.ToString();
				Player1ShootSt = Player1Shoot.ToString();
			
				Player2UpSt = Player2Up.ToString();
				Player2DownSt = Player2Down.ToString();
				Player2LeftSt = Player2Left.ToString();
				Player2RightSt = Player2Right.ToString();			
				Player2ShootSt = Player2Shoot.ToString();
			
				GUI.Box (new Rect (Screen.width/16*7, Screen.height/2-Screen.height/4, Screen.width/8, Screen.height/16), "Controls", TextStyle);
				
				GUI.Box (new Rect (Screen.width/16*4, Screen.height/16*5, Screen.width/8, Screen.height/16), "Player 1", TextStyle);
				GUI.Box (new Rect (Screen.width/16*10, Screen.height/16*5, Screen.width/8, Screen.height/16), "Player 2", TextStyle);
				
				GUI.Box (new Rect (Screen.width/16*4, Screen.height/16*7, Screen.width/8, Screen.height/16), "Move Up", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*4, Screen.height/16*8, Screen.width/8, Screen.height/16), "Move Down", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*4, Screen.height/16*9, Screen.width/8, Screen.height/16), "Move Left", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*4, Screen.height/16*10, Screen.width/8, Screen.height/16), "Move Right", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*4, Screen.height/16*11, Screen.width/8, Screen.height/16), "Shoot", ControlsStyle);
			
				GUI.Box (new Rect (Screen.width/16*10, Screen.height/16*7, Screen.width/8, Screen.height/16), "Move Up", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*10, Screen.height/16*8, Screen.width/8, Screen.height/16), "Move Down", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*10, Screen.height/16*9, Screen.width/8, Screen.height/16), "Move Left", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*10, Screen.height/16*10, Screen.width/8, Screen.height/16), "Move Right", ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*10, Screen.height/16*11, Screen.width/8, Screen.height/16), "Shoot", ControlsStyle);	
			
				GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*7, Screen.width/8, Screen.height/16), Player1UpSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*8, Screen.width/8, Screen.height/16), Player1DownSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*9, Screen.width/8, Screen.height/16), Player1LeftSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*10, Screen.width/8, Screen.height/16), Player1RightSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*11, Screen.width/8, Screen.height/16), Player1ShootSt, ControlsStyle);
			
				GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*7, Screen.width/8, Screen.height/16), Player2UpSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*8, Screen.width/8, Screen.height/16), Player2DownSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*9, Screen.width/8, Screen.height/16), Player2LeftSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*10, Screen.width/8, Screen.height/16), Player2RightSt, ControlsStyle);
				GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*11, Screen.width/8, Screen.height/16), Player2ShootSt, ControlsStyle);
		
				if (GUI.Button (new Rect (Screen.width/16*4, Screen.height/16*7, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player1UpInput = true;
				if (GUI.Button (new Rect (Screen.width/16*4, Screen.height/16*8, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player1DownInput = true;
				if (GUI.Button (new Rect (Screen.width/16*4, Screen.height/16*9, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player1LeftInput = true;
				if (GUI.Button (new Rect (Screen.width/16*4, Screen.height/16*10, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player1RightInput = true;
				if (GUI.Button (new Rect (Screen.width/16*4, Screen.height/16*11, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player1ShootInput = true;
			
				if (GUI.Button (new Rect (Screen.width/16*10, Screen.height/16*7, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player2UpInput = true;
				if (GUI.Button (new Rect (Screen.width/16*10, Screen.height/16*8, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player2DownInput = true;
				if (GUI.Button (new Rect (Screen.width/16*10, Screen.height/16*9, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player2LeftInput = true;
				if (GUI.Button (new Rect (Screen.width/16*10, Screen.height/16*10, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player2RightInput = true;
				if (GUI.Button (new Rect (Screen.width/16*10, Screen.height/16*11, Screen.width/16*4, Screen.height/16), "", ButtonInputStyle))	 Player2ShootInput = true;
			
				if ((Ev.isKey)&&(Player1UpInput)) {Player1Up = Ev.keyCode; Player1UpInput = false;}
				if ((Ev.isKey)&&(Player1DownInput)) {Player1Down = Ev.keyCode; Player1DownInput = false;}
				if ((Ev.isKey)&&(Player1LeftInput)) {Player1Left = Ev.keyCode; Player1LeftInput = false;}
				if ((Ev.isKey)&&(Player1RightInput)) {Player1Right = Ev.keyCode; Player1RightInput = false;}
				if ((Ev.isKey)&&(Player1ShootInput)) {Player1Shoot = Ev.keyCode; Player1ShootInput = false;}
			
				if ((Ev.isKey)&&(Player2UpInput)) {Player2Up = Ev.keyCode; Player2UpInput = false;}
				if ((Ev.isKey)&&(Player2DownInput)) {Player2Down = Ev.keyCode; Player2DownInput = false;}
				if ((Ev.isKey)&&(Player2LeftInput)) {Player2Left = Ev.keyCode; Player2LeftInput = false;}
				if ((Ev.isKey)&&(Player2RightInput)) {Player2Right = Ev.keyCode; Player2RightInput = false;}
				if ((Ev.isKey)&&(Player2ShootInput)) {Player2Shoot = Ev.keyCode; Player2ShootInput = false;}
			
				if(GUI.Button(new Rect(Screen.width/16*7,Screen.height/16*13,Screen.width/8,Screen.height/16),"Back", ButtonStyle)) HandleSettings = false;
		}
		
		if ((Settings)&&(!HandleSettings)&&(!GameSettings)) {
			
			if(GUI.Button(new Rect(Screen.width/16*7,Screen.height/16*7,Screen.width/8,Screen.height/16),"Game Options",ButtonStyle)) GameSettings = true;	
			if(GUI.Button(new Rect(Screen.width/16*7,Screen.height/16*9,Screen.width/8,Screen.height/16),"Controls", ButtonStyle)) HandleSettings = true;
			
			GUI.Box (new Rect (Screen.width/16*7, Screen.height/2-Screen.height/4, Screen.width/8, Screen.height/16), "Options", TextStyle);
			if(GUI.Button(new Rect(Screen.width/16*7,Screen.height/16*13,Screen.width/8,Screen.height/16),"Back", ButtonStyle)) { 			
				Settings = false;
			}
		}
		if (About) {	
			GUI.Box(new Rect(Screen.width/16*7, Screen.height/16*4, Screen.width/8, Screen.height/16), "About", TextStyle);
			if(GUI.Button(new Rect(Screen.width/16*7,Screen.height/16*13,Screen.width/8,Screen.height/16),"Back", ButtonStyle)) About = false;
		}
			
	}	
}
