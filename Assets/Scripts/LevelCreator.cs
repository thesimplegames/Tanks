using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {
	
	const int hor = 10;
	const int ver = 10;
	
	public int [,] table = new int [hor, ver] 
	{{8, 8, 8, 8, 8, 8, 8, 8, 8, 8}, 
	 {8, 1, 2, 1, 1, 0, 0, 0, 4, 8}, 
	 {8, 3, 0, 0, 1, 0, 1, 1, 0, 8}, 
	 {8, 0, 1, 7, 1, 0, 1, 1, 0, 8},
	 {8, 0, 1, 1, 1, 0, 1, 5, 0, 8}, 
	 {8, 0, 0, 0, 0, 0, 1, 0, 1, 8}, 
	 {8, 0, 1, 1, 1, 1, 1, 0, 0, 8},
	 {8, 0, 1, 1, 0, 0, 0, 2, 1, 8},
	 {8, 0, 0, 6, 0, 1, 1, 1, 0, 8},
	 {8, 8, 8, 8, 8, 8, 8, 8, 8, 8}};
	
	GameObject wall;
	GameObject megaWall;
	GameObject water;
	GameObject eagle;
	GameObject bush;
	GameObject nothing;
	GameObject player1;
	GameObject player2;
	GameObject tank;
	GameObject tankObject;
	
	// Use this for initialization
	void Start () {
			
		bush = Resources.Load("Prefabs/Bush") as GameObject;
		wall = Resources.Load("Prefabs/Wall") as GameObject;
		megaWall = Resources.Load("Prefabs/MegaWall") as GameObject;
		water = Resources.Load("Prefabs/Water") as GameObject;
		eagle = Resources.Load("Prefabs/Eagle") as GameObject;
		nothing = Resources.Load("Prefabs/Nothing") as GameObject;
		tank = Resources.Load("Prefabs/Tank") as GameObject;
		
		Instantiate(nothing, new Vector3(0,0,8), nothing.transform.rotation);
		
		for (int i = 0; i < hor; i++)
			for (int j = 0; j < ver; j++) {
				switch (table[i, j]) {
					case 1: 
						Instantiate(wall, new Vector2(i, j), wall.transform.rotation);
						break;
					case 2: 
						Instantiate(water, new Vector2(i, j), water.transform.rotation);
						break;
					case 3: 
						Instantiate(bush, new Vector3(i, j, bush.transform.position.z), bush.transform.rotation);
						break;
					case 4: 
						Instantiate(eagle, new Vector2(i, j), eagle.transform.rotation);
						break;
					case 5: 
						tankObject = Instantiate(tank, new Vector3(i, j, tank.transform.position.z), tank.transform.rotation) as GameObject;
						tankObject.GetComponent<TTank>().type = 0;
						tankObject.transform.tag = "Enemy";
						break;
					case 6: 
						tankObject = Instantiate(tank, new Vector3(i, j, tank.transform.position.z), tank.transform.rotation) as GameObject;
						tankObject.GetComponent<TTank>().type = 1;
						//tankObject.GetComponent<TTank>().spawnPosition=tank.transform.position;
						tankObject.GetComponent<Handler>().SetKeyCodes(Settings.Player1);
						tankObject.transform.tag = "Player1";
						
						break;
					case 7: 
						tankObject = Instantiate(tank, new Vector3(i, j, tank.transform.position.z), tank.transform.rotation) as GameObject;
						tankObject.GetComponent<TTank>().type = 1;
						tankObject.GetComponent<Handler>().SetKeyCodes(Settings.Player2);
						tankObject.transform.tag = "Player2";
						tankObject.renderer.material.mainTexture = Resources.Load("Prefabs/Materials/Textures/SilverTank") as Texture;
						break;
					case 8: 
						Instantiate(megaWall, new Vector2(i, j), megaWall.transform.rotation);
						break;
				}
			}
		
	}
	
}
