using UnityEngine;
using System.Collections;

public class Handler : MonoBehaviour {
	
	private TTank tank;
	private Vector2 direction;
	private bool isMoving;
	private Vector3 targetPosition;
	private GameObject bullet;
	private KeyCode[] handleParams;// = new KeyCode[4];
	
	
	public void SetKeyCodes(KeyCode[] params_){
		handleParams=params_;
	}
	
	// Use this for initialization
	void Start () {
		tank=this.gameObject.GetComponent<TTank>();
		direction = new Vector2 (1,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!tank.isMoving){
			if (tank.type == 1){ //First player
				if (Input.GetKey(handleParams[0])) {
					direction = new Vector2 (0,1);
					tank.Move (direction);
				}
				if (Input.GetKey(handleParams[1])) {
					direction = new Vector2 (-1,0);
					tank.Move (direction);
				}
				if (Input.GetKey(handleParams[3])) {
					direction = new Vector2 (1,0);
					tank.Move (direction);
				}
				if (Input.GetKey(handleParams[2])) {
					direction = new Vector2 (0,-1);
					tank.Move (direction);
				}
				if (Input.GetKeyDown(handleParams[4])){
					tank.Shoot();
				}
			}	
			
		}	
	}
}
