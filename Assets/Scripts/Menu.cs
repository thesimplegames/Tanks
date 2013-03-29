using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GUIStyle TextStyle; 
	public GUIStyle ButtonStyle;
	public GUIStyle TextNearFieldStyle;
	public GUIStyle FieldStyle;
	public GUIStyle ControlsStyle; 
	public GUIStyle ButtonInputStyle;
	public GUIStyle PressAnyKey;
	
	bool MySettings = false;
	bool GameSettings = false;
	bool HandleSettings = false;
	bool About=false;
	bool StGame = false;
	
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
	
	int PlayerLife = 1;
	int EnemyLife = 1;
	int FlagLife = 1;
	
	public int MaxPlayerLife = 9;
	public int MaxEnemyLife = 9;
	public int MaxFlagLife = 9;
	
	void StartGame() {
		
		Settings.Player1[0] = Player1Up;
		Settings.Player1[1] = Player1Left;
		Settings.Player1[2] = Player1Down;
		Settings.Player1[3] = Player1Right;
		Settings.Player1[4] = Player1Shoot;
		
		Settings.Player2[0] = Player2Up;
		Settings.Player2[1] = Player2Left;
		Settings.Player2[2] = Player2Down;
		Settings.Player2[3] = Player2Right;
		Settings.Player2[4] = Player2Shoot;
		
		Settings.tankHP = PlayerLife;
		Settings.enemyHP = EnemyLife;
		Settings.eagleHP = FlagLife;
		
		Application.LoadLevel("tanks");	
	}
	
	void OnGUI () {
		
		TextStyle.fontSize = Screen.height/15;
		ButtonStyle.fontSize = Screen.height/30; 
		TextNearFieldStyle.fontSize = Screen.height/25;
		FieldStyle.fontSize = Screen.height/25;		
		ControlsStyle.fontSize = Screen.height/30;
		PressAnyKey.fontSize = Screen.height/30;
		
		if ((!MySettings)&&(!About)&&(!StGame)) {
			
			      GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*4, Screen.width/5, Screen.height/10), "Menu", TextStyle);
			if(GUI.Button(new Rect(Screen.width/10*4, Screen.height/16*7, Screen.width/5, Screen.height/10), "Start game",ButtonStyle)) StGame = true;
			if(GUI.Button(new Rect(Screen.width/10*4, Screen.height/16*9, Screen.width/5, Screen.height/10), "Options", ButtonStyle)) MySettings = true;
			if(GUI.Button(new Rect(Screen.width/10*4, Screen.height/16*11,Screen.width/5, Screen.height/10), "About", ButtonStyle)) About = true;
			if(GUI.Button(new Rect(Screen.width/10*4, Screen.height/16*13,Screen.width/5, Screen.height/10), "Exit", ButtonStyle)) Application.Quit();
		
		}
		
		if (StGame) {
			
			GUI.Box (new Rect (Screen.width/16*7, Screen.height/2-Screen.height/4, Screen.width/8, Screen.height/16), "Start Game", TextStyle);
			
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*7,Screen.width/5,Screen.height/10),"1 Player",ButtonStyle)) {Settings.TwoPlayers = false; Application.LoadLevel("tanks");}	
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*9,Screen.width/5,Screen.height/10),"2 Players", ButtonStyle)) {Settings.TwoPlayers = true; Application.LoadLevel("tanks");}
		
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*13,Screen.width/5,Screen.height/10),"Back", ButtonStyle)) StGame = false;
		
		}
		
		if ((MySettings)&&(GameSettings)) {
			GUI.Box (new Rect (Screen.width/16*7, Screen.height/2-Screen.height/4, Screen.width/8, Screen.height/16), "Game Options", TextStyle);
						
			GUI.Box(new Rect(Screen.width/16*5, Screen.height/16*7, Screen.width/8, Screen.height/16), "Player Lifes", TextNearFieldStyle);
			GUI.Box(new Rect(Screen.width/16*10, Screen.height/16*7, Screen.height/32, Screen.height/32),PlayerLife.ToString(),TextNearFieldStyle);
		
		    GUI.Box(new Rect(Screen.width/16*5, Screen.height/16*9, Screen.width/8, Screen.height/16), "Enemy Lifes", TextNearFieldStyle);
			GUI.Box(new Rect(Screen.width/16*10, Screen.height/16*9, Screen.height/32, Screen.height/32), EnemyLife.ToString(), TextNearFieldStyle);
			
			GUI.Box(new Rect(Screen.width/16*5, Screen.height/16*11, Screen.width/8, Screen.height/16), "Flag Lifes", TextNearFieldStyle);
			GUI.Box(new Rect(Screen.width/16*10, Screen.height/16*11, Screen.height/32, Screen.height/32), FlagLife.ToString(), TextNearFieldStyle);
			
			if (GUI.Button(new Rect(Screen.width/32*21, Screen.height/16*7, Screen.height/32, Screen.height/32),"+",ButtonStyle)) PlayerLife++;
			if (GUI.Button(new Rect(Screen.width/32*19, Screen.height/16*7, Screen.height/32, Screen.height/32),"-",ButtonStyle)) PlayerLife--;
			
			if (GUI.Button(new Rect(Screen.width/32*21, Screen.height/16*9, Screen.height/32, Screen.height/32),"+",ButtonStyle)) EnemyLife++;
			if (GUI.Button(new Rect(Screen.width/32*19, Screen.height/16*9, Screen.height/32, Screen.height/32),"-",ButtonStyle)) EnemyLife--;
			
			if (GUI.Button(new Rect(Screen.width/32*21, Screen.height/16*11, Screen.height/32, Screen.height/32),"+",ButtonStyle)) FlagLife++;
			if (GUI.Button(new Rect(Screen.width/32*19, Screen.height/16*11, Screen.height/32, Screen.height/32),"-",ButtonStyle)) FlagLife--;
			
			if (FlagLife > MaxFlagLife) FlagLife--;
			if (FlagLife < 1) FlagLife++;
			
			if (PlayerLife > MaxPlayerLife) PlayerLife--;
			if (PlayerLife < 1) PlayerLife++;
			
			if (EnemyLife > MaxEnemyLife) EnemyLife--;
			if (EnemyLife < 1) EnemyLife++;
			
			
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*13,Screen.width/5,Screen.height/10),"Back", ButtonStyle)) GameSettings = false;
		}
		
		if ((MySettings)&&(HandleSettings)) {
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
			
				if(!Player1UpInput)   GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*7, Screen.width/8, Screen.height/16), Player1UpSt, ControlsStyle);
				if(!Player1DownInput) GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*8, Screen.width/8, Screen.height/16), Player1DownSt, ControlsStyle);
				if(!Player1LeftInput)GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*9, Screen.width/8, Screen.height/16), Player1LeftSt, ControlsStyle);
				if(!Player1RightInput) GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*10, Screen.width/8, Screen.height/16), Player1RightSt, ControlsStyle);
				if(!Player1ShootInput)GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*11, Screen.width/8, Screen.height/16), Player1ShootSt, ControlsStyle);
			
				if(!Player2UpInput)   GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*7, Screen.width/8, Screen.height/16), Player2UpSt, ControlsStyle);
				if(!Player2DownInput) GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*8, Screen.width/8, Screen.height/16), Player2DownSt, ControlsStyle);
				if(!Player2LeftInput)GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*9, Screen.width/8, Screen.height/16), Player2LeftSt, ControlsStyle);
				if(!Player2RightInput) GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*10, Screen.width/8, Screen.height/16), Player2RightSt, ControlsStyle);
				if(!Player2ShootInput)GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*11, Screen.width/8, Screen.height/16), Player2ShootSt, ControlsStyle);
				
				if(Player1UpInput)   GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*7, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player1DownInput) GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*8, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player1LeftInput)GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*9, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player1RightInput) GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*10, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player1ShootInput)GUI.Box (new Rect (Screen.width/16*7, Screen.height/16*11, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
			
				if(Player2UpInput)   GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*7, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player2DownInput) GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*8, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player2LeftInput)GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*9, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player2RightInput) GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*10, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				if(Player2ShootInput)GUI.Box (new Rect (Screen.width/16*13, Screen.height/16*11, Screen.width/8, Screen.height/16), "Press Any Key", PressAnyKey);
				
			
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
			
				if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*13,Screen.width/5,Screen.height/10),"Back", ButtonStyle)) HandleSettings = false;
		}
		
		if ((MySettings)&&(!HandleSettings)&&(!GameSettings)) {
			
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*7,Screen.width/5,Screen.height/10),"Game Options",ButtonStyle)) GameSettings = true;	
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*9,Screen.width/5,Screen.height/10),"Controls", ButtonStyle)) HandleSettings = true;
			
			GUI.Box (new Rect (Screen.width/10*4, Screen.height/2-Screen.height/4, Screen.width/5, Screen.height/16), "Options", TextStyle);
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*13,Screen.width/5,Screen.height/10),"Back", ButtonStyle)) MySettings = false;
		}
		if (About) {	
			GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*4, Screen.width/5, Screen.height/10), "About", TextStyle);
			if(GUI.Button(new Rect(Screen.width/10*4,Screen.height/16*13,Screen.width/5,Screen.height/10),"Back", ButtonStyle)) About = false;
		}
			
	}	
}
