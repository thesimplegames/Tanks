using UnityEngine;
using System.Collections;

public class TTank : MonoBehaviour {
	
	public float speed;
	public float speedMod;
	public float shield;
	public int life;
	public int type;
	public bool isMoving;
	public Vector3 spawnPosition;
	private Vector3 targetPosition;
	public Vector2 direction;
	private GameObject bullet;
	
	// Use this for initialization
	void Start () {
		speed = 3.5f;
		speedMod = 0;
		shield = 0;
		if (type != 0) life = Settings.tankHP;
		else life = Settings.enemyHP;
		isMoving = false;
		direction = new Vector2 (0,-1);
		if (type == 0) {
			gameObject.GetComponent<EnemyBehaviour>().enabled = true;
			gameObject.GetComponent<Handler>().enabled = false;
		}
		spawnPosition=transform.position;
	}
	
	public void Shooted(){
		Debug.Log(tag+life.ToString());
		if (shield>0) shield=0;
			else {
		life--;	
	//	transform.position=spawnPosition;
		}
	}	
	
	public void Move(Vector2 direction_){
		direction = direction_;
		if (direction==Vector2.up){
		transform.eulerAngles = new Vector3 (180,270,90);
		}
		if (direction==(-Vector2.up)){
		transform.eulerAngles = new Vector3 (0,270,90);
		}
		if (direction==(-Vector2.right)){
		transform.eulerAngles = new Vector3 (270,270,90);
		}
		if (direction==Vector2.right){
		transform.eulerAngles = new Vector3 (90,270,90);
		}
		isMoving = true;
		targetPosition = new Vector3 (transform.position.x+direction.x,transform.position.y+direction.y,transform.position.z);
		Ray ray = new Ray (transform.position, new Vector3(direction.x, direction.y, transform.position.z));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1)) {
			isMoving = false;
		}			
	}
	public void Shoot(){
		if (bullet == null){
			bullet = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
			TBullet myBullet = bullet.GetComponent<TBullet>();
			myBullet.direction = direction;
			myBullet.parent=gameObject;
			bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);
			bullet.transform.rotation = transform.rotation;
		}			
	}
	
	// Update is called once per frame
	void Update () {
		if(life==0) Destroy(gameObject);
		if (isMoving){
			
			transform.position=new Vector3 (transform.position.x+direction.x*speed*Time.deltaTime,
											transform.position.y+direction.y*speed*Time.deltaTime,
											transform.position.z);
			if (Vector3.Distance(transform.position,targetPosition)<0.05f) {
				isMoving=false;
				transform.position=targetPosition;
			}
		}
	}
}
