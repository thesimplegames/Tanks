using UnityEngine;
using System.Collections;

public class TFlag : MonoBehaviour {

	private int lives = Settings.eagleHP;
	
	public void Shooted () {
		
		lives--;
		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lives == 0) {
			GameOver.isGameOver = true;
			Destroy (this.gameObject);
		}
	}
}
