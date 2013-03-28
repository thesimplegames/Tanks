using UnityEngine;
using System.Collections;

public class TTank : MonoBehaviour {
	
	float speed;
	public float speedMod;
	public float shield;
	public int life;
	bool isMoving;
	Vector2 direction;
	public int type;
	GameObject bullet;
	private Vector3 targetPosition;
	
	// Use this for initialization
	void Start () {
		speed = 5;
		speedMod = 0;
		shield = 0;
		life = 1;
		isMoving = false;
		direction = new Vector2 (1,0);
		type=1;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving){
			
			transform.position=new Vector3 (transform.position.x+direction.x*speed*Time.deltaTime,
											transform.position.y+direction.y*speed*Time.deltaTime,
											transform.position.z);
			if (Vector3.Distance(transform.position,targetPosition)<0.05f) {
				isMoving=false;
				transform.position=targetPosition;
			}
		} else {
			if (type == 1){ //First player
				if (Input.GetKey(KeyCode.W)) {
					direction = new Vector2 (0,1);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}
				if (Input.GetKey(KeyCode.A)) {
					direction = new Vector2 (-1,0);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}
				if (Input.GetKey(KeyCode.D)) {
					direction = new Vector2 (1,0);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}
				if (Input.GetKey(KeyCode.S)) {
					direction = new Vector2 (0,-1);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}
				if (Input.GetKey(KeyCode.Space)) if (bullet==null){
					if (bullet==null)
					bullet = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
					TBullet myBullet=bullet.GetComponent<TBullet>();
					myBullet.direction=direction;
					bullet.transform.position=transform.position;
					bullet.transform.rotation=transform.rotation;
					
					}
			}	
			if (type == 2){ //First player
				if (Input.GetKey(KeyCode.UpArrow)) {
					direction = new Vector2 (0,1);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}
				if (Input.GetKey(KeyCode.LeftArrow)) {
					direction = new Vector2 (-1,0);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}
				if (Input.GetKey(KeyCode.RightArrow)) {
					direction = new Vector2 (1,0);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}
				if (Input.GetKey(KeyCode.DownArrow)) {
					direction = new Vector2 (0,-1);
					isMoving=true;
					targetPosition=new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
					Ray ray = new Ray (transform.position, new Vector3(direction.x,direction.y,transform.position.z));
					RaycastHit hit;
					if (Physics.Raycast(ray, out hit, 1)){
						isMoving=false;
					}
				}	
			}
		}
	}
}
