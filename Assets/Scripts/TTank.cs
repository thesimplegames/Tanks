using UnityEngine;
using System.Collections;

public class TTank : MonoBehaviour {
	
	public float speed;
	public int type;
	public bool isMoving;
	public Vector3 spawnPosition;
	public int life;
	public Vector2 direction;
	public float deltaStep;
	
	private GameObject bullet,bullet2;
	private float speedMod;
	private Vector3 targetPosition;
	private float shield;
	private float bulletlvl;
	
	// Use this for initialization
	void Start () {
		speed = 3.5f;
		speedMod = 0;
		shield = 0;
		deltaStep=4;
		bulletlvl=1f;
		if (type != 0) life = Settings.tankHP;
		else life = Settings.enemyHP;
		isMoving = false;
		direction = new Vector2 (0,-1);
		if (type == 0) {
			gameObject.GetComponent<EnemyBehaviour>().enabled = true;
			gameObject.GetComponent<Handler>().enabled = false;
		if (type == 1)
			GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed = false;
		if (type == 2)
			GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed = false;	
		}
		spawnPosition=transform.position;
	}
	
	public void Shooted(){
//		Debug.Log(tag+life.ToString());
		if (shield<=0){
		life--;	
		transform.position=spawnPosition;
			speedMod=0f;
			shield=3f;
			bulletlvl=1f;
			if (gameObject.tag=="Enemy"){
				Achievments.AddAchievmentProgress(Achievments.AchievmentType.KillTank);
				if (Random.value<MapPrefs.powerUpChanse) {
					GameObject pu = Instantiate(Resources.Load("Prefabs/PowerUp")) as GameObject;
					pu.GetComponent<TPowerUp>().CreatePowerUp();
				}
			}
		}
	}	
	
	public void AddPowerUp(TPowerUp.PowerUpType type){
		Achievments.AddAchievmentProgress(Achievments.AchievmentType.FoundPowerUp);
		switch (type) {
		case TPowerUp.PowerUpType.BulletUp:
			bulletlvl++;
			if (bulletlvl>3f) bulletlvl=3f;
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
	}
	public bool CanMove(Vector2 direction_){
		float rayLength=0.55f;
		GameObject hitedPU1=null,hitedPU2=null;
		
		Ray ray = new Ray (transform.position, new Vector3(direction_.x, direction_.y, transform.position.z));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, rayLength)) {
			if (!(hit.transform.gameObject.tag=="PowerUp"))
				return false;
			else if (gameObject.tag!="Enemy") { 
				AddPowerUp(hit.transform.gameObject.GetComponent<TPowerUp>().type);
				hitedPU1=hit.transform.gameObject;
				Destroy(hit.transform.gameObject); }
		}	
		ray = new Ray (new Vector3(transform.position.x+direction_.y*7/16,transform.position.y+direction_.x*7/16,transform.position.z),
						new Vector3(direction_.x, direction_.y, transform.position.z));
		if (Physics.Raycast(ray, out hit, rayLength)) {
			if (!(hit.transform.gameObject.tag=="PowerUp"))
				return false;
			else if (gameObject.tag!="Enemy") if (hit.transform.gameObject!=hitedPU1){ 
					AddPowerUp(hit.transform.gameObject.GetComponent<TPowerUp>().type);
					Destroy(hit.transform.gameObject); 
					hitedPU2=hit.transform.gameObject;
			}
		}	
		
		ray = new Ray (new Vector3(transform.position.x-direction_.y*7/16,transform.position.y-direction_.x*7/16,transform.position.z),
						new Vector3(direction_.x, direction_.y, transform.position.z));
		if (Physics.Raycast(ray, out hit, rayLength)) {
			if (!(hit.transform.gameObject.tag=="PowerUp"))
				return false;
			else if (gameObject.tag!="Enemy") if (hit.transform.gameObject!=hitedPU1) if (hit.transform.gameObject!=hitedPU2){ 
					AddPowerUp(hit.transform.gameObject.GetComponent<TPowerUp>().type);
					Destroy(hit.transform.gameObject); 
			}
		}	
		return true;
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
		isMoving = CanMove(direction);
		targetPosition = new Vector3 (transform.position.x+direction.x/deltaStep,transform.position.y+direction.y/deltaStep,transform.position.z);
				
	}
	public void Shoot(){
		if (gameObject.tag=="Enemy") if (Random.value>0.3f) return;
		if (bullet == null){
			bullet = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
			TBullet myBullet = bullet.GetComponent<TBullet>();
			myBullet.direction = direction;
			myBullet.speed=(bulletlvl/2+1)*10f;
			myBullet.parent=gameObject;
			bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);
			bullet.transform.rotation = transform.rotation;
		}	else if (bullet2==null) if (bulletlvl>2) {
			bullet2 = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
			TBullet myBullet = bullet2.GetComponent<TBullet>();
			myBullet.direction = direction;
			myBullet.speed=(bulletlvl/2+1)*10f;
			myBullet.parent=gameObject;
			bullet2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);
			bullet2.transform.rotation = transform.rotation;
		}
	}
	
	// Update is called once per frame
	void Update () {
		shield-=Time.deltaTime;
		speedMod-=Time.deltaTime;
		if(life==0) {
			if (gameObject.tag=="Enemy"){
					GameOver.Score+=100;
				if (MapPrefs.enemyLeftCount>0) {
					MapPrefs.enemyLeftCount--;
					transform.position=spawnPosition;
					life=Settings.enemyHP;
					type=0;
				} else {
					MapPrefs.enemyCount--;
					Debug.Log (MapPrefs.enemyCount);
					Destroy(gameObject);
					if (MapPrefs.enemyCount<=0){
						GameOver.win=true;
						GameOver.IsGameOver=true;
					}
				}
			} else {
			if (type == 1)
				GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed = true;
			if (type == 2)
				GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed = true;	
			Destroy(gameObject);
			}
		}
		if (isMoving) {
			isMoving=CanMove(direction);
			transform.position=new Vector3 (transform.position.x+direction.x*speed*Time.deltaTime*(speedMod>0?2:1),
											transform.position.y+direction.y*speed*Time.deltaTime*(speedMod>0?2:1),
											transform.position.z);
			if (Vector3.Distance(transform.position,targetPosition)<0.05f) {
				isMoving=false;
				transform.position=targetPosition;
			}
		}
	}
}
