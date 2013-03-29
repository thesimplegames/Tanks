using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	Vector3 endObject;
	private TTank tank;
	Vector2 direction;
	int count;
	Vector2 falseDirection;
	bool up, down, left, right;
	float upd, downd, leftd, rightd;
	int [,] array = new int [10, 10];
	
	void CheckDirection () {
		
		if ((array[(int)transform.position.x + 1, (int)transform.position.y] == 0) || (array[(int)transform.position.x + 1, (int)transform.position.y] == 3)) 
		{right = true;}
		else right = false;
		
		if ((array[(int)transform.position.x - 1, (int)transform.position.y] == 0) || (array[(int)transform.position.x - 1, (int)transform.position.y] == 3)) 
		{left = true; Debug.Log(transform.position);}
		else left = false;
		
		if ((array[(int)transform.position.x, (int)transform.position.y + 1] == 0) || (array[(int)transform.position.x, (int)transform.position.y + 1] == 3)) 
		{up = true;}
		else up = false;
		
		if ((array[(int)transform.position.x, (int)transform.position.y - 1] == 0) || (array[(int)transform.position.x, (int)transform.position.y - 1] == 3)) 
		{down = true;}
		else down = false;
		
	}
	
	void Start () {
		
		array = GameObject.FindGameObjectWithTag("LevelCreator").GetComponent<LevelCreator>().table;
		tank = gameObject.GetComponent<TTank>();
		endObject = GameObject.FindGameObjectWithTag("Player1").transform.position;
		
		CheckDirection();
		
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
			
			endObject = GameObject.FindGameObjectWithTag("Player1").transform.position;

		if (!tank.isMoving) {
			
			count = 0;
			
			CheckDirection();
			
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
