using UnityEngine;
using System.Collections;

public class Handler : MonoBehaviour {
	
	private TTank tank;
	private Vector2 direction;
	private bool isMoving;
	private Vector3 targetPosition;
	private GameObject bullet;
	// Use this for initialization
	void Start () {
		tank=this.gameObject.GetComponent<TTank>();
		direction = new Vector2 (1,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!tank.isMoving){
			if (tank.type == 1){ //First player
				if (Input.GetKey(KeyCode.W)) {
					direction = new Vector2 (0,1);
					tank.Move (direction);
				}
				if (Input.GetKey(KeyCode.A)) {
					direction = new Vector2 (-1,0);
					tank.Move (direction);
				}
				if (Input.GetKey(KeyCode.D)) {
					direction = new Vector2 (1,0);
					tank.Move (direction);
				}
				if (Input.GetKey(KeyCode.S)) {
					direction = new Vector2 (0,-1);
					tank.Move (direction);
				}
				if (Input.GetKeyDown(KeyCode.Space)){
					tank.Shoot();
				}
			}	
			if (tank.type == 2){ //First player
				if (Input.GetKey(KeyCode.UpArrow)) {
					direction = new Vector2 (0,1);
					tank.Move (direction);
				}
				if (Input.GetKey(KeyCode.LeftArrow)) {
					direction = new Vector2 (-1,0);
					tank.Move (direction);
				}
				if (Input.GetKey(KeyCode.RightArrow)) {
					direction = new Vector2 (1,0);
					tank.Move (direction);
				}
				if (Input.GetKey(KeyCode.DownArrow)) {
					direction = new Vector2 (0,-1);
					tank.Move (direction);
				}	
				if (Input.GetKeyDown(KeyCode.F)){
					tank.Shoot();
				}	
			}
		}	
	}
}
