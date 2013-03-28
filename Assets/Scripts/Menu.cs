using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GUIStyle TextStyle, ButtonStyle,TextNearFieldStyle;
	bool Settings=false;
	bool GameSettings=false;
	bool HandleSettings=false;
	bool About=false;
	
	public static int PlayerLife;
	public static int EnemyLife;
	public static int FlagLife;
	public static float BulletSpeed;
	
	public static string PlayerLifeValue = "1";
	public static string EnemyLifeValue = "1";
	public static string FlagLifeValue = "1";
	
	public static string LastPlayerLifeValue = "1";
	public static string LastEnemyLifeValue = "1";
	public static string LastFlagLifeValue = "1";
	
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
		if (!Settings) {
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2-Screen.height/4, 100, 40), "Menu", TextStyle);
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-Screen.height/16,100,40),"Start game",ButtonStyle)) Application.LoadLevel("tanks");	
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/8-Screen.height/16,100,40),"Settings", ButtonStyle)) Settings = true;
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4-Screen.height/16,100,40),"About", ButtonStyle)) About = true;
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4+Screen.height/8-Screen.height/16,100,40),"Exit", ButtonStyle)) Application.Quit();
		
		}
		
		if ((Settings)&&(GameSettings)) {
			GUI.Box (new Rect (Screen.width/2-30, Screen.height/2+Screen.height/4-Screen.height/16-10, 100, 20), "Bullet Speed", TextNearFieldStyle);
			BulletSpeed = GUI.HorizontalSlider (new Rect (Screen.width/2-50, Screen.height/2+Screen.height/4-Screen.height/16+Screen.height/16-10, 100, 30), BulletSpeed, 5, 20);
			
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2-Screen.height/16+ 2, 100, 20), "Player Lifes", TextNearFieldStyle);
			PlayerLifeValue = GUI.TextField(new Rect(Screen.width/2+30,Screen.height/2-Screen.height/16,20,20),PlayerLifeValue,1);
			if (IsNumber(PlayerLifeValue)) LastPlayerLifeValue = PlayerLifeValue;
				else PlayerLifeValue = LastPlayerLifeValue;
			
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2+Screen.height/8-Screen.height/16+ 2-Screen.height/16, 100, 20), "Enemy Lifes", TextNearFieldStyle);
			EnemyLifeValue = GUI.TextField(new Rect(Screen.width/2+30,Screen.height/2+Screen.height/8-Screen.height/16-Screen.height/16,20,20),EnemyLifeValue,1);
			if (IsNumber(EnemyLifeValue)) LastEnemyLifeValue = EnemyLifeValue;
				else EnemyLifeValue = LastEnemyLifeValue;
			
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2+Screen.height/8-Screen.height/16 + 2, 100, 20), "Flag Lifes", TextNearFieldStyle);
			FlagLifeValue = GUI.TextField(new Rect(Screen.width/2+30,Screen.height/2+Screen.height/8-Screen.height/16,20,20),FlagLifeValue,1);
			if (IsNumber(FlagLifeValue)) LastFlagLifeValue = FlagLifeValue;
				else FlagLifeValue = LastFlagLifeValue;
			
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4+Screen.height/8-Screen.height/16,100,40),"Back", ButtonStyle)) GameSettings = false;
		}
		
		if ((Settings)&&(HandleSettings)) {
				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4+Screen.height/8-Screen.height/16,100,40),"Back", ButtonStyle)) HandleSettings = false;
		}
		
		if ((Settings)&&(!HandleSettings)&&(!GameSettings)) {
			
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-Screen.height/16,100,40),"Game Options",ButtonStyle)) GameSettings = true;	
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/8-Screen.height/16,100,40),"Handle Settings", ButtonStyle)) HandleSettings = true;
			
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2-Screen.height/4, 100, 40), "Settings", TextStyle);
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4+Screen.height/8-Screen.height/16,100,40),"Back", ButtonStyle)) { 			
				Settings = false;
			}
		if (About) {
				if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4+Screen.height/8-Screen.height/16,100,40),"Back", ButtonStyle)) About = false;
		}
			
		}
	}	
}
