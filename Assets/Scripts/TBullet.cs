using UnityEngine;
using System.Collections;

public class TBullet : MonoBehaviour {
	
	public Vector2 direction;
	float speed;
	//float speedMod;
	
	// Use this for initialization
	void Start () {
		speed=10;
	//	speedMod=0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3 (transform.position.x+direction.x*speed*Time.deltaTime,
										transform.position.y+direction.y*speed*Time.deltaTime,
										transform.position.z);
		Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 0.1f)){
			Destroy(hit.transform.gameObject);
			Destroy(this.gameObject);
		}
		
	}
}
