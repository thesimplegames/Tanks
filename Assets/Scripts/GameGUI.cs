using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	
	public GUIStyle TextStyle;
	public GUIStyle LifesStyle;
	
	public GameObject Player1;
	public GameObject Player2;
	
	void OnGUI() {
		
		TextStyle.fontSize = Screen.height/16;
		
		GUI.Box(new Rect(Screen.width/16, Screen.height/16, Screen.width/16, Screen.height/16), "Player 1", TextStyle);
		
		if (Player1.GetComponent<TTank>().life>=1) GUI.Box(new Rect(Screen.width/16, Screen.height/16*3, Screen.width/50, Screen.width/50), "0", LifesStyle);
		
	}
	
}
