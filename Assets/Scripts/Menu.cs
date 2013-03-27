using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnGUI () {
		
		GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-100+10,100,40),"Start game");
		
		GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+10,100,40),"Settings");
		
		GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+100+10,100,40),"Exit");
		

	}	
}
