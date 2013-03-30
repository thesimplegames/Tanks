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
		
		while (!found){
			x=(int)Random.Range(1,MapPrefs.heigth-1);
			y=(int)Random.Range(1,MapPrefs.length-1);
			found=true;
			Debug.Log("x: " + x.ToString() + ", y: " + y.ToString());
			Ray ray = new Ray (new Vector3(x,y,-1), Vector3.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 3)) {
				found=false;
			}
			found=true;
		}
		type = (PowerUpType)Random.Range(9,14); 
		transform.position=new Vector3 (x,y,0);
	}
	
	void OnTriggerEnter(Collider col){
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
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	public void AddPowerUp(TPowerUp.PowerUpType type){
		switch (type) {
		case TPowerUp.PowerUpType.BulletUp:
			bulletlvl++;
		break;
		case TPowerUp.PowerUpType.Shield:
			shield=5f;
		break;
		case TPowerUp.PowerUpType.TankLife:
			life++;
		break;
		case TPowerUp.PowerUpType.TankSpeedUp:
			speedMod=5f;
		break;
		case TPowerUp.PowerUpType.Bomb:
		break;	
		}
	}*/
}
