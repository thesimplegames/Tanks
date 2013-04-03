using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	
	public GUIStyle TextStyle;
	public GUIStyle LifesStyle;
	
	public static GameObject Player1;
	public static GameObject Player2;
	
	public int P1;
	public int P2;
	
	int X,Y;
	int j,k,i;
	
	void OnGUI() {
		
		TextStyle.fontSize = Screen.height/16;
		
		GUI.Box(new Rect(Screen.width/16, Screen.height/16, Screen.width/16, Screen.height/16), "Player 1", TextStyle);
		
		int X,Y;
		int j,k;
		if (Player1 != null)
		for (i=0; i<Player1.GetComponent<TTank>().life; i++)
		{
			j = i / 3;
			k = i % 3;
			X = Screen.width/16 + Screen.height/10 * k;
			Y = Screen.height/16*3 + Screen.height/10 * j;
			GUI.Box(new Rect(X, Y, Screen.width/20, Screen.width/20), "", LifesStyle);	
		}
		
		if ((Settings.TwoPlayers)&&(Player2!=null)) {
			GUI.Box(new Rect(Screen.width/16*13, Screen.height/16, Screen.width/16, Screen.height/16), "Player 2", TextStyle);

			for (i=0; i<Player2.GetComponent<TTank>().life; i++)
			{
				j = i / 3;
				k = i % 3;
				X = Screen.width/16*13 + Screen.height/10 * k;
				Y = Screen.height/16*3 + Screen.height/10 * j;
				GUI.Box(new Rect(X, Y, Screen.width/20, Screen.width/20), "", LifesStyle);	
			}
		}
		
		
	}
	
}
