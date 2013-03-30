using UnityEngine;
using System.Collections;

public class TBullet : MonoBehaviour {
	
	public Vector2 direction;
	public GameObject parent;
	public float speed;
	//float speedMod;
	
	// Use this for initialization
	void Start () {
		
	//	speedMod=0;
	}
	
	void OnTriggerEnter(Collider col){
		if (!(col.gameObject==parent)) 
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
			case "Player1":
				col.gameObject.GetComponent<TTank>().Shooted();
				Destroy(this.gameObject);
				break;		
			case "Player2":
				col.gameObject.GetComponent<TTank>().Shooted();
				Destroy(this.gameObject);
				break;		
			case "Enemy":
				col.gameObject.GetComponent<TTank>().Shooted();
				Destroy(this.gameObject);
				break;		
			default:			
				Destroy(col.gameObject);
				Destroy(this.gameObject);
				break;
			}
	}
	/*
	void OnCollisionEnter(Collision col){
		Debug.Log (1);
		
	}
	*/
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x+direction.x*speed*Time.deltaTime,
										transform.position.y+direction.y*speed*Time.deltaTime,
										transform.position.z);
	/*	Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 0.1f)){
			switch (hit.transform.gameObject.tag){
			case "MegaWall": 
				Destroy(this.gameObject);
				break;
			case "Water": 
				break;
			case "Bush": 
				break;	
			case "Tank":
				hit.transform.gameObject.GetComponent<TTank>().life--;
				break;		
			default:			
				Destroy(hit.transform.gameObject);
				Destroy(this.gameObject);
				break;
			}
		}
		*/
	}
}
