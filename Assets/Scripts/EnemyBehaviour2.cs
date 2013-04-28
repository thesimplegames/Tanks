using UnityEngine;
using System.Collections;

public class EnemyBehaviour2 : MonoBehaviour {
	
	private TTank tank;
	Vector3 direction = Vector3.up;
	
	// Use this for initialization
	void Start () {
	
		tank = gameObject.GetComponent<TTank>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (MapPrefs.isPause) return;
		if (direction == Vector3.up) {
			if (!tank.CanMove(Vector3.up)) {
				if (tank.CanMove(Vector3.right))
					direction = Vector3.right;
				if (tank.CanMove(-Vector3.right))
					direction = -Vector3.right;
				if (tank.CanMove(-Vector3.up))
					direction = -Vector3.up;
			}
		}
		
		if (direction == Vector3.right) {
			if (!tank.CanMove(Vector3.right)) {
				if (tank.CanMove(Vector3.up))
					direction = Vector3.up;
				if (tank.CanMove(-Vector3.right))
					direction = -Vector3.right;
				if (tank.CanMove(-Vector3.up))
					direction = -Vector3.up;
			}
		}
		
		if (direction == -Vector3.right) {
			if (!tank.CanMove(-Vector3.right)) {
				if (tank.CanMove(Vector3.up))
					direction = Vector3.up;
				if (tank.CanMove(Vector3.right))
					direction = Vector3.right;
				if (tank.CanMove(-Vector3.up))
					direction = -Vector3.up;
			}
		}
	
		if (direction == -Vector3.up) {
			if (!tank.CanMove(-Vector3.up)) {
				if (tank.CanMove(Vector3.right))
					direction = Vector3.right;
				if (tank.CanMove(-Vector3.right))
					direction = -Vector3.right;
				if (tank.CanMove(Vector3.up))
					direction = Vector3.up;
			}
		}
		
		if (Random.value*100<2) {
			bool isBlocked=false;
			if (tank.CanMove(Vector3.up) && direction != Vector3.up)
				direction = Vector3.up; else isBlocked=isBlocked||true;
			if (tank.CanMove(-Vector3.up) && direction != -Vector3.up)
				direction = -Vector3.up;	else isBlocked=isBlocked||true;
			if (tank.CanMove(Vector3.right) && direction != Vector3.right)
				direction = Vector3.right;	else isBlocked=isBlocked||true;
			if (tank.CanMove(-Vector3.right) && direction != -Vector3.right)
				direction = -Vector3.right;	else isBlocked=isBlocked||true;
				if (isBlocked) {
					switch (Random.Range(1,4)) {
					case 1:
					direction=Vector3.up;
					break;
					case 2:
					direction=-Vector3.up;
					break;
					case 3:
					direction=Vector3.left;
					break;
					case 4:
					direction=-Vector3.left;
					break;
					}
				}
		}
		
		if (Random.Range(0,100) < 10)
			tank.Shoot();
		
		tank.Move(direction);
	}
}
