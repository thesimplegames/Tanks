using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {
	
	public static bool IsGameOver = false;
	public static bool IsFlagOver = false;
	public static int Score = 0;
	public static bool win=false;
	
	public GUIStyle ButtonStyle;
	public GUIStyle TextStyle;
	public GUIStyle Fon;
	
	public bool GO = false;
	
	int Best;
	
	void OnGUI() {
		
		if (GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed && 
			GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed)
			IsGameOver = true;
		//else IsGameOver = false;
		
		if (IsFlagOver) IsGameOver = true;
		
		if (IsGameOver) {
			MapPrefs.isPause=true;
			if (win){
				TextStyle.fontSize = Screen.height/15;
				ButtonStyle.fontSize = Screen.height/30; 
			
				GUI.Box(new Rect(1, 1, Screen.width, Screen.height), "", Fon);
			
				GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*4, Screen.width/5, Screen.height/10), "You won!", TextStyle);
				GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*6, Screen.width/5, Screen.height/10),
					"Your Score " + Score.ToString(), TextStyle);
				Best = int.Parse(Saver.Load("Best"));
				if (Best < Score) {Best = Score; Saver.Save("Best",Best.ToString());}
				GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*8, Screen.width/5, Screen.height/10),
				"Best " + Saver.Load("Best"), TextStyle);
				
				if(GUI.Button(new Rect(Screen.width/10*2, Screen.height/16*13,Screen.width/5, Screen.height/10), "Exit", ButtonStyle))
					Application.LoadLevel("MenuScene");
				if(GUI.Button(new Rect(Screen.width/10*6, Screen.height/16*13,Screen.width/5, Screen.height/10), "Next", ButtonStyle)){
					MapPrefs.isPause=false;
					IsGameOver = false;
					IsFlagOver = false; 
					win = false;
					Menu.currentMap++;
					Settings.levelName=Menu.mapsDir+"\\"+Menu.currentMap+".map";
					GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed=false;
					GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed=false;
					Application.LoadLevel("tanks");
				}
			} else {
				TextStyle.fontSize = Screen.height/15;
				ButtonStyle.fontSize = Screen.height/30; 
			
				GUI.Box(new Rect(1, 1, Screen.width, Screen.height), "", Fon);
			
				GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*4, Screen.width/5, Screen.height/10), "Game Over!", TextStyle);
				GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*6, Screen.width/5, Screen.height/10),
					"Your Score " + Score.ToString(), TextStyle);
			
				Best = int.Parse(Saver.Load("Best"));
				if (Best < Score) {Best = Score; Saver.Save("Best",Best.ToString());}
				GUI.Box(new Rect(Screen.width/10*4, Screen.height/16*8, Screen.width/5, Screen.height/10),
				"Best " + Saver.Load("Best"), TextStyle);
				
				if(GUI.Button(new Rect(Screen.width/10*2, Screen.height/16*13,Screen.width/5, Screen.height/10), "Exit", ButtonStyle))
					Application.LoadLevel("MenuScene");
				if(GUI.Button(new Rect(Screen.width/10*6, Screen.height/16*13,Screen.width/5, Screen.height/10), "Restart", ButtonStyle)){
					MapPrefs.isPause=false;
					Score=0;
					IsGameOver = false;
					IsFlagOver = false; 
					win = false;
					//Menu.currentMap=1;
					Settings.levelName=Menu.mapsDir+"\\"+Menu.currentMap+".map";
					GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed=false;
					GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed=false;
					Application.LoadLevel("tanks");
				}
			}
		}
	}
	
}
