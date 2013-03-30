using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	Vector3 endObject;
	private TTank tank;
	GameObject player1, player2, eagle;
	Vector2 direction;
	int count;
	RaycastHit hit;
	Vector2 falseDirection;
	bool up, down, left, right, isTank;
	float upd, downd, leftd, rightd;
	public bool player1Destroyed, player2Destroyed;
	void Start () {
		
		player1Destroyed = GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed;
		player2Destroyed = GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed;
		
		tank = gameObject.GetComponent<TTank>();
		tank.isMoving = false;
		
		player1 = GameObject.FindGameObjectWithTag("Player1");
		player2 = GameObject.FindGameObjectWithTag("Player2");
		eagle = GameObject.FindGameObjectWithTag("Eagle");
		
		if (player2 == null)
			player2 = player1;
		
		if (GameObject.FindGameObjectWithTag("Player1") != null && GameObject.FindGameObjectWithTag("Player2") != null)
			if ((GameObject.FindGameObjectWithTag("Player1").transform.position - transform.position).magnitude < (GameObject.FindGameObjectWithTag("Player2").transform.position - transform.position).magnitude)
				endObject = GameObject.FindGameObjectWithTag("Player1").transform.position;
		else endObject = GameObject.FindGameObjectWithTag("Player2").transform.position;
		if (GameObject.FindGameObjectWithTag("Player1") == null)
			endObject = player2.transform.position;
		if (GameObject.FindGameObjectWithTag("Player2") == null)
			endObject = player1.transform.position;
		
		
		if (Physics.Raycast(new Ray(transform.position, new Vector2(1, 0)), 1)) 
			right = false;
		else right = true;
		if (Physics.Raycast(new Ray(transform.position, new Vector2(0, 1)), 1)) 
			up = false;
		else up = true;
		if (Physics.Raycast(new Ray(transform.position, new Vector2(-1, 0)), 1)) 
			left = false;
		else left = true;
		if (Physics.Raycast(new Ray(transform.position, new Vector2(0, -1)), 1)) 
			down = false;
		else down = true;
		
		if (right)
			rightd = (endObject - new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z)).magnitude;
		else rightd = 100f;
		if (up)
			upd = (endObject - new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z)).magnitude;
		else upd = 100f;
		if (left)
			leftd = (endObject - new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z)).magnitude;
		else leftd = 100f;
		if (down)
			downd = (endObject - new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z)).magnitude;
		else downd = 100f;
		
		if (leftd <= upd && leftd <= downd && leftd <= rightd)
			falseDirection = new Vector2 (1, 0);
		if (rightd <= upd && rightd <= leftd && rightd <= downd)
			falseDirection = new Vector2 (-1, 0);
		if (upd <= leftd && upd <= downd && upd <= rightd)
			falseDirection = new Vector2 (0, -1);
		if (downd <= upd && downd <= leftd && downd <= rightd)
			falseDirection = new Vector2 (0, 1);
		
	}
	

	// Update is called once per frame
	void Update () {
		if (Time.time > 0.1f) {
			
			player1Destroyed = GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player1Destroyed;
			player2Destroyed = GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed;
			
			if (!Settings.TwoPlayers) {
				player2Destroyed = true;
				GameObject.FindGameObjectWithTag("IfDestroyed").GetComponent<ifDestroyed>().player2Destroyed = true;
				if (!player1Destroyed) 
					if ((player1.transform.position - transform.position).magnitude < (eagle.transform.position - transform.position).magnitude)
						endObject = player1.transform.position;
					else endObject = eagle.transform.position;
				else endObject = eagle.transform.position;
			}
			
			if (Settings.TwoPlayers) {
				if (!player1Destroyed && !player2Destroyed) {
					if ((player1.transform.position - transform.position).magnitude < (eagle.transform.position - transform.position).magnitude)
						endObject = player1.transform.position;
					else endObject = eagle.transform.position;
					if ((player2.transform.position - transform.position).magnitude < (endObject - transform.position).magnitude)
						endObject = player2.transform.position;
				}
				if (!player1Destroyed && player2Destroyed)
					if ((player1.transform.position - transform.position).magnitude < (eagle.transform.position - transform.position).magnitude)
						endObject = player1.transform.position;
					else endObject = eagle.transform.position;
				if (!player2Destroyed && player1Destroyed)
					if ((player2.transform.position - transform.position).magnitude < (eagle.transform.position - transform.position).magnitude)
						endObject = player2.transform.position;
					else endObject = eagle.transform.position;
				if (player1Destroyed && player2Destroyed)
					endObject = eagle.transform.position;
			}
			
			if (Physics.Raycast(new Ray(transform.position, new Vector2(1, 0)), 1)) 
				right = false;
			else right = true;
			if (Physics.Raycast(new Ray(transform.position, new Vector2(0, 1)), 1)) 
				up = false; 
			else up = true;
			if (Physics.Raycast(new Ray(transform.position, new Vector2(-1, 0)), 1)) 
				left = false; 
			else left = true;
			if (Physics.Raycast(new Ray(transform.position, new Vector2(0, -1)), 1)) 
				down = false;
			else down = true;
			
			
			if (!tank.isMoving) {
				
				isTank = false;
				
				if (!player1Destroyed) {
				
					if (player1.transform.position.x > transform.position.x && player1.transform.position.y == transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (90,270,90);
						transform.GetComponent<TTank>().direction = Vector2.right;
					}	
					if (player1.transform.position.x < transform.position.x && player1.transform.position.y == transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (270,270,90);
						transform.GetComponent<TTank>().direction = -Vector2.right;
					}	
					if (player1.transform.position.x == transform.position.x && player1.transform.position.y > transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (180,270,90);
						transform.GetComponent<TTank>().direction = Vector2.up;
					}	
					if (player1.transform.position.x == transform.position.x && player1.transform.position.y < transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (0,270,90);
						transform.GetComponent<TTank>().direction = -Vector2.up;
					}
				
				}
				
				if (!player2Destroyed) {
				
					if (player2.transform.position.x > transform.position.x && player2.transform.position.y == transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (90,270,90);
						transform.GetComponent<TTank>().direction = Vector2.right;
					}	
					if (player2.transform.position.x < transform.position.x && player2.transform.position.y == transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (270,270,90);
						transform.GetComponent<TTank>().direction = -Vector2.right;
					}	
					if (player2.transform.position.x == transform.position.x && player2.transform.position.y > transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (180,270,90);
						transform.GetComponent<TTank>().direction = Vector2.up;
					}	
					if (player2.transform.position.x == transform.position.x && player2.transform.position.y < transform.position.y) {
						isTank = true;
						transform.eulerAngles = new Vector3 (0,270,90);
						transform.GetComponent<TTank>().direction = -Vector2.up;
					}
				
				}
					
				if (eagle.transform.position.x > transform.position.x && eagle.transform.position.y == transform.position.y) {
					isTank = true;
					transform.eulerAngles = new Vector3 (90,270,90);
					transform.GetComponent<TTank>().direction = Vector2.right;
				}	
				if (eagle.transform.position.x < transform.position.x && eagle.transform.position.y == transform.position.y) {
					isTank = true;
					transform.eulerAngles = new Vector3 (270,270,90);
					transform.GetComponent<TTank>().direction = -Vector2.right;
				}	
				if (eagle.transform.position.x == transform.position.x && eagle.transform.position.y > transform.position.y) {
					isTank = true;
					transform.eulerAngles = new Vector3 (180,270,90);
					transform.GetComponent<TTank>().direction = Vector2.up;
				}	
				if (eagle.transform.position.x == transform.position.x && eagle.transform.position.y < transform.position.y) {
					isTank = true;
					transform.eulerAngles = new Vector3 (0,270,90);
					transform.GetComponent<TTank>().direction = -Vector2.up;
				}	
				
			}
			
			if (!tank.isMoving)
				if (isTank) tank.Move(transform.GetComponent<TTank>().direction);
			
			if (isTank && (int)(Time.time / 2f) == Mathf.Round(Time.time / 2f))
				tank.Shoot();
			
			if (!tank.isMoving && !isTank) {
			
				count = 0;
				
				if (right) count++;
				if (left) count++;
				if (down) count++;
				if (up) count++;
				
				switch (count) {
				case 1:
					if (right) direction = new Vector2 (1, 0);
					if (left) direction = new Vector2 (-1, 0);
					if (up) direction = new Vector2 (0, 1);
					if (down) direction = new Vector2 (0, -1);
					falseDirection = -direction;
					break;
				case 2:
					if (right && falseDirection != new Vector2 (1, 0)) direction = new Vector2 (1, 0);
					if (left && falseDirection != new Vector2 (-1, 0)) direction = new Vector2 (-1, 0);
					if (up && falseDirection != new Vector2 (0, 1)) direction = new Vector2 (0, 1);
					if (down && falseDirection != new Vector2 (0, -1)) direction = new Vector2 (0, -1);
					falseDirection = -direction;
					break;
				}
				if (count > 2) {
					if (right && falseDirection != new Vector2 (1, 0))
						rightd = (endObject - new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z)).magnitude;
					else rightd = 100f;
					if (up && falseDirection != new Vector2 (0, 1))
						upd = (endObject - new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z)).magnitude;
					else upd = 100f;
					if (left && falseDirection != new Vector2 (-1, 0))
						leftd = (endObject - new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z)).magnitude;
					else leftd = 100f;
					if (down && falseDirection != new Vector2 (0, -1))
						downd = (endObject - new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z)).magnitude;
					else downd = 100f;
					
					if (leftd <= upd && leftd <= downd && leftd <= rightd)
						falseDirection = new Vector2 (1, 0);
					if (rightd <= upd && rightd <= leftd && rightd <= downd)
						falseDirection = new Vector2 (-1, 0);
					if (upd <= leftd && upd <= downd && upd <= rightd)
						falseDirection = new Vector2 (0, -1);
					if (downd <= upd && downd <= leftd && downd <= rightd)
						falseDirection = new Vector2 (0, 1);
					direction = -falseDirection;
				
			
					}
				
				tank.Move(direction);
			}
		}	
	}
}
