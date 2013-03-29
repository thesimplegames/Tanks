using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	Vector3 endObject;
	private TTank tank;
	RaycastHit hit;
	Vector2 direction;
	int count;
	Vector2 falseDirection;
	bool up, down, left, right;
	float upd, downd, leftd, rightd;
	
	void Start () {
		
		tank = gameObject.GetComponent<TTank>();
		tank.isMoving = false;
		endObject = GameObject.FindGameObjectWithTag("Player1").transform.position;
		if (Physics.Raycast(new Ray(transform.position, new Vector2(1, 0)), out hit, 1)) 
			right = false;
		else right = true;
		if (Physics.Raycast(new Ray(transform.position, new Vector2(0, 1)), out hit, 1)) 
			up = false;
		else up = true;
		if (Physics.Raycast(new Ray(transform.position, new Vector2(-1, 0)), out hit, 1)) 
			left = false;
		else left = true;
		if (Physics.Raycast(new Ray(transform.position, new Vector2(0, -1)), out hit, 1)) 
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
			
			Debug.Log("enemybeh1");
			endObject = GameObject.FindGameObjectWithTag("Player1").transform.position;
			if (Physics.Raycast(new Ray(transform.position, new Vector2(1, 0)), out hit, 1.2f)) 
				right = false;
			else right = true;
			if (Physics.Raycast(new Ray(transform.position, new Vector2(0, 1)), out hit, 1.2f)) 
				up = false; 
			else up = true;
			if (Physics.Raycast(new Ray(transform.position, new Vector2(-1, 0)), out hit, 1.2f)) 
				left = false; 
			else left = true;
			if (Physics.Raycast(new Ray(transform.position, new Vector2(0, -1)), out hit, 1.2f)) 
				down = false;
			else down = true;
		if (!tank.isMoving) {
			
			
			Debug.Log("1");
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
