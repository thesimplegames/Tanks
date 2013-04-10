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
		
		if (Random.Range(0,100) < 1) {
			if (tank.CanMove(Vector3.up) && direction != Vector3.up)
				direction = Vector3.up;
			if (tank.CanMove(-Vector3.up) && direction != -Vector3.up)
				direction = -Vector3.up;
			if (tank.CanMove(Vector3.right) && direction != Vector3.right)
				direction = Vector3.right;
			if (tank.CanMove(-Vector3.right) && direction != -Vector3.right)
				direction = -Vector3.right;
		}
		
		if (Random.Range(0,100) < 10)
			tank.Shoot();
		
		tank.Move(direction);
	}
}
