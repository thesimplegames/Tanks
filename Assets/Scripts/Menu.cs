using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GUIStyle TextStyle, ButtonStyle;
	bool Settings=false;
	
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
		if (Str = '1') f = true;
		if (Str = '2') f = true;
		if (Str = '3') f = true;
		if (Str = '4') f = true;
		if (Str = '5') f = true;
		if (Str = '6') f = true;
		if (Str = '7') f = true;
		if (Str = '8') f = true;
		if (Str = '9') f = true;
	}
	
	void OnGUI () {
		if (!Settings) {
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2-Screen.height/4, 100, 40), "Menu", TextStyle);
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-Screen.height/16,100,40),"Start game",ButtonStyle)) Application.LoadLevel("tanks");	
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/8-Screen.height/16,100,40),"Settings", ButtonStyle)) Settings = true;
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4-Screen.height/16,100,40),"Exit", ButtonStyle)) Application.Quit();
		}
		
		if (Settings) {
			
			PlayerLifeValue = GUI.TextField(new Rect(Screen.width/2+30,Screen.height/2-Screen.height/16,20,20),PlayerLifeValue,1);
			if (IsNumber(PlayerLifeValue))
			
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2-Screen.height/4, 100, 40), "Settings", TextStyle);
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4-Screen.height/16,100,40),"Back", ButtonStyle)) Settings = false;;
			
		}
	}	
}
