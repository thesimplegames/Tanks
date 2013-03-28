using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GUIStyle TextStyle, ButtonStyle;
	bool Settings=false;
	
	void OnGUI () {
		if (!Settings) {
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2-Screen.height/4, 100, 40), "Menu", TextStyle);
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-Screen.height/16,100,40),"Start game",ButtonStyle)) Application.LoadLevel("tanks");	
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/8-Screen.height/16,100,40),"Settings", ButtonStyle)) Settings = true;
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4-Screen.height/16,100,40),"Exit", ButtonStyle)) Application.Quit();
		}
		if (Settings) {
			GUI.Box (new Rect (Screen.width/2-50, Screen.height/2-Screen.height/4, 100, 40), "Settings", TextStyle);
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+Screen.height/4-Screen.height/16,100,40),"Back", ButtonStyle)) Settings = false;;
		}
	}	
}
