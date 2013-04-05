using UnityEngine;
using System.Collections;

public class LevelLoadForMenu : MonoBehaviour {
	
	int hor, ver;
	
	public int [,] table;
	
	public static string LoadPath;
	public static bool NeedToLoad = false;
	
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
	
	GameObject InstantiatedObject;
	
	// Use this for initialization
	
	int[,] LoadFromFile(string path, out int mWidth, out int mHeight) {
		string strMap = "";
		System.IO.StreamReader file = new System.IO.StreamReader(path);
	    strMap = file.ReadLine();
		file.Close();	
		int[,] map;
		
		mWidth = 0;
		mHeight = 0;
		bool wh = true;
		string sInt = "";
		int mapPosition = 0;
		
		//	Loading map size
		for (int i = 0; i < strMap.Length; i++) {
			if (strMap[i] == ':') {
				if (wh) {
					wh = false;
					mWidth = System.Convert.ToInt32(sInt);
					sInt = "";
				} else {
					mHeight = System.Convert.ToInt32(sInt);
					mapPosition = i + 1;
					break;
				}
			} else {
				sInt += strMap[i];
			}			
		}
		
		map = new int[mWidth, mHeight];
		for (int i = 0; i < mWidth; i++) {
			for (int j = 0; j < mWidth; j++) {
				map[i, j] = System.Convert.ToInt32(strMap[mapPosition].ToString());
				mapPosition++;
			}
		}	
		return map;
	}
	
	void Update () {
		if (NeedToLoad){
			Debug.Log("Loading level");
		table = LoadFromFile(LoadPath, out hor, out ver);
			
		Camera.main.transform.position = new Vector3 ((hor - 1) / 2f, (ver - 1) / 2f, -4);
		Camera.main.orthographicSize = ver * 0.5f;
		
		bush = Resources.Load("Prefabs/Bush") as GameObject;
		wall = Resources.Load("Prefabs/Wall") as GameObject;
		megaWall = Resources.Load("Prefabs/MegaWall") as GameObject;
		water = Resources.Load("Prefabs/Water") as GameObject;
		eagle = Resources.Load("Prefabs/Eagle") as GameObject;
		nothing = Resources.Load("Prefabs/NothingForMenu") as GameObject;
		tank = Resources.Load("Prefabs/Tank") as GameObject;
		
		
		//Instantiate(nothing, new Vector3(0,0,8), nothing.transform.rotation);
		
		for (int i = 0; i < hor; i++)
			for (int j = 0; j < ver; j++) {
				switch (table[i, j]) {
					case 1: 
						InstantiatedObject = Instantiate(wall, new Vector2(i, j), wall.transform.rotation) as GameObject;
						InstantiatedObject.transform.tag = "ToDestroy";
						break;
					case 2: 
						InstantiatedObject = Instantiate(water, new Vector2(i, j), water.transform.rotation) as GameObject;
						InstantiatedObject.transform.tag = "ToDestroy";
						break;
					case 3: 
						InstantiatedObject = Instantiate(bush, new Vector3(i, j, bush.transform.position.z), bush.transform.rotation) as GameObject;
						InstantiatedObject.transform.tag = "ToDestroy";
						break;
					/*case 4: 
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
						tankObject.GetComponent<Handler>().SetKeyCodes(Settings.Player1);
						tankObject.transform.tag = "Player1";
						GameGUI.Player1 = tankObject;
						break;
					case 7: 
						if (Settings.TwoPlayers){
							tankObject = Instantiate(tank, new Vector3(i, j, tank.transform.position.z), tank.transform.rotation) as GameObject;
							tankObject.GetComponent<TTank>().type = 2;
							tankObject.GetComponent<Handler>().SetKeyCodes(Settings.Player2);
							tankObject.transform.tag = "Player2";
							tankObject.renderer.material.mainTexture = Resources.Load("Prefabs/Materials/Textures/SilverTank") as Texture;
							GameGUI.Player2 = tankObject;
						}
						break;*/
					case 8: 
						InstantiatedObject = Instantiate(megaWall, new Vector2(i, j), megaWall.transform.rotation) as GameObject;
						InstantiatedObject.transform.tag = "ToDestroy";
						break;
				}
			}
		
	}
		NeedToLoad = false;
	}
	
}
