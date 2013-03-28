using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GUIStyle TextStyle, ButtonStyle, TextNearFieldStyle, FieldStyle, BulletText;
	
	int FontSize;
	
	bool Settings = false;
	bool GameSettings = false;
	bool HandleSettings = false;
	bool About=false;
	
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
	
	void OnGUI () {
		
		TextStyle.fontSize = Screen.height/20;
		ButtonStyle.fontSize = Screen.height/50; 
		TextNearFieldStyle.fontSize = Screen.height/50;
		FieldStyle.fontSize = Screen.height/50;		
		BulletText.fontSize = Screen.height/50;
		
		
		
		if ((!Settings)&&(!About)) {
			      GUI.Box(new Rect(Screen.width/16*7, Screen.height/16*4, Screen.width/8, Screen.height/16), "Menu", TextStyle);
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*7, Screen.width/8, Screen.height/16), "Start game",ButtonStyle)) Application.LoadLevel("tanks");	
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*9, Screen.width/8, Screen.height/16), "Options", ButtonStyle)) Settings = true;
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*11,Screen.width/8, Screen.height/16), "About", ButtonStyle)) About = true;
			if(GUI.Button(new Rect(Screen.width/16*7, Screen.height/16*13,Screen.width/8, Screen.height/16), "Exit", ButtonStyle)) Application.Quit();
		
		}
		
		if ((Settings)&&(GameSettings)) {
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
