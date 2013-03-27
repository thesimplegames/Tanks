using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {
	
	const int hor = 10;
	const int ver = 10;
	
	int [,] table = new int [hor, ver] 
	{{8, 8, 8, 8, 8, 8, 8, 8, 8, 8}, 
	 {8, 1, 2, 1, 1, 0, 0, 0, 4, 8}, 
	 {8, 3, 0, 0, 1, 0, 1, 1, 0, 8}, 
	 {8, 0, 1, 0, 1, 0, 1, 1, 0, 8},
	 {8, 0, 1, 1, 1, 0, 1, 0, 0, 8}, 
	 {8, 0, 0, 0, 0, 0, 1, 0, 1, 8}, 
	 {8, 0, 1, 1, 1, 1, 1, 0, 0, 8},
	 {8, 0, 1, 1, 0, 0, 0, 2, 1, 8},
	 {8, 0, 0, 0, 0, 1, 1, 1, 0, 8},
	 {8, 8, 8, 8, 8, 8, 8, 8, 8, 8}};
	
	GameObject wall;
	GameObject megaWall;
	GameObject water;
	GameObject eagle;
	GameObject bush;
	GameObject nothing;
	
	// Use this for initialization
	void Start () {
			
		bush = Resources.Load("Prefabs/Bush") as GameObject;
		wall = Resources.Load("Prefabs/Wall") as GameObject;
		megaWall = Resources.Load("Prefabs/MegaWall") as GameObject;
		water = Resources.Load("Prefabs/Water") as GameObject;
		eagle = Resources.Load("Prefabs/Eagle") as GameObject;
		nothing = Resources.Load("Prefabs/Nothing") as GameObject;
		
		for (int i = 0; i < hor; i++)
			for (int j = 0; j < ver; j++) {
				switch (table[i, j]) {
					case 0: 
						Instantiate(nothing, new Vector2(i, j), nothing.transform.rotation);
						break;
					case 1: 
						Instantiate(wall, new Vector2(i, j), wall.transform.rotation);
						break;
					case 2: 
						Instantiate(water, new Vector2(i, j), water.transform.rotation);
						break;
					case 3: 
						Instantiate(nothing, new Vector2(i, j), nothing.transform.rotation);
						Instantiate(bush, new Vector3(i, j), bush.transform.rotation);
						break;
					case 4: 
						Instantiate(nothing, new Vector2(i, j), nothing.transform.rotation);
						Instantiate(eagle, new Vector2(i, j), eagle.transform.rotation);
						break;
					case 8: 
						Instantiate(megaWall, new Vector2(i, j), megaWall.transform.rotation);
						break;
				}
			}
		
	}
	
}
