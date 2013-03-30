using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public static bool IsGameOver = false;
	public static int Score = 0;
	
	public GUIStyle ButtonStyle;
	public GUIStyle TextStyle;
	public GUIStyle Fon;
	
	public bool GO = false;
	
	int Best;
	
	void OnGUI() {
		
		if (GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed && GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed)
			IsGameOver = true;
		else IsGameOver = false;
		
		if (IsGameOver) {
			TextStyle.fontSize = Screen.height/15;
			ButtonStyle.fontSize = Screen.height/30; 
			
			GUI.Box(new Rect(1, 1, Screen.width, Screen.height), "", Fon);
			
			GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*4, Screen.width/5, Screen.height/10), "Game Over", TextStyle);
			GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*6, Screen.width/5, Screen.height/10), "Your Score " + Score.ToString(), TextStyle);
			
			PlayerPrefs.GetInt( "Best", Best);
			if (Best < Score) {Best = Score; PlayerPrefs.SetInt("Best", Best);}
			
			GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*8, Screen.width/5, Screen.height/10), "Best " + Best.ToString(), TextStyle);
			
			if(GUI.Button(new Rect(Screen.width/10*2, Screen.height/16*13,Screen.width/5, Screen.height/10), "Exit", ButtonStyle)) Application.LoadLevel("MenuScene");
			if(GUI.Button(new Rect(Screen.width/10*6, Screen.height/16*13,Screen.width/5, Screen.height/10), "Restart", ButtonStyle)) {IsGameOver=false; Application.LoadLevel("tanks");}
		}
	}
	
}
