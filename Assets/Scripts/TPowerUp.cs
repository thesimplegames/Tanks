using UnityEngine;
using System.Collections;

public class TPowerUp : MonoBehaviour {
	
	public enum PowerUpType{BulletUp=9,Shield=10,TankSpeedUp=11,Bomb=12,TankLife=13};
	public PowerUpType type;
	// Use this for initialization
	void Start () {
	
	}
	
	public void CreatePowerUp(){
		float x=2,y=2;
		bool found=false;
//		Debug.Log ("start");
		while (!found){
			x=(int)Random.Range(1,MapPrefs.heigth-1);
			y=(int)Random.Range(1,MapPrefs.length-1);
			//Debug.Log (x.ToString()+" "+y.ToString());
			found=true;
			//Ray ray = new Ray (new Vector3(x,y,-1), -Vector3.up);
			//RaycastHit hit;
			//if (Physics.Raycast(ray, out hit, 3)) {
			//	found=false;
			//}
		//if (found) Debug.DrawLine(ray.origin,ray.direction+ray.origin,Color.red,100);
		}
		type = (PowerUpType)Random.Range(9,14); 
		switch (type) {
		case PowerUpType.TankLife:
			gameObject.renderer.material.mainTexture = Resources.Load("Prefabs/Materials/Textures/PowerUp_Health") as Texture;
			break;
		case PowerUpType.Shield:
			gameObject.renderer.material.mainTexture = Resources.Load("Prefabs/Materials/Textures/ShieldPowerUp") as Texture;
			break;
		case PowerUpType.BulletUp:
			gameObject.renderer.material.mainTexture = Resources.Load("Prefabs/Materials/Textures/BulletPowerUp") as Texture;
			break;
		case PowerUpType.Bomb:
			gameObject.renderer.material.mainTexture = Resources.Load("Prefabs/Materials/Textures/BombPowerUp") as Texture;
			break;
		case PowerUpType.TankSpeedUp:
			gameObject.renderer.material.mainTexture = Resources.Load("Prefabs/Materials/Textures/TankSpeedPowerUp") as Texture;
			break;
		}
		transform.position=new Vector3 (x,y,0);
	}
	/*
	void OnTriggerEnter(Collider col){
			Debug.Log ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!@");
		switch (col.gameObject.tag){
		case "Player1":
			col.gameObject.GetComponent<TTank>().AddPowerUp(type);
			Destroy(gameObject);
			break;
		case "Player2":
			col.gameObject.GetComponent<TTank>().AddPowerUp(type);
			Destroy(gameObject);
			break;
		}
	}
	*/
	// Update is called once per frame
	void Update () {
	
	}
}
