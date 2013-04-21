using UnityEngine;
using System.Collections;

public class TBullet : MonoBehaviour {
	
	public Vector2 direction;
	public GameObject parent;
	public float speed;
	
	void Start () {
	}
	
	void OnTriggerEnter(Collider col){
		if (parent!=null) if (!(col.gameObject==parent)) 
		switch (col.gameObject.tag){
			case "MegaWall": 
				Destroy(this.gameObject);
				break;
			case "Water": 
				break;
			case "Bush": 
				break;	
			case "PowerUp": 
				break;	
			case "Eagle" :
				col.gameObject.GetComponent<TFlag>().Shooted();
				Destroy(gameObject);
				break;
			case "Player1":
				if (!(parent.tag=="Player2"))
				col.gameObject.GetComponent<TTank>().Shooted();
				Destroy(this.gameObject);
				break;		
			case "Player2":
				if (!(parent.tag=="Player1"))
				col.gameObject.GetComponent<TTank>().Shooted();
				Destroy(this.gameObject);
				break;		
			case "Enemy":
				if ((parent.tag!="Enemy")||(MapPrefs.isBackGround))
				//if (!(parent.tag=="Enemy"))
				col.gameObject.GetComponent<TTank>().Shooted();
				Destroy(this.gameObject);
				break;		
			default:			
				Destroy(col.gameObject);
				Destroy(this.gameObject);
				break;
			}
	}
	void Update () {
		transform.position = new Vector3 (transform.position.x+direction.x*speed*Time.deltaTime,
										transform.position.y+direction.y*speed*Time.deltaTime,
										transform.position.z);
	}
}
