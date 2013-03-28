using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	int [,] marked = new int [10, 10];
	Vector3 startObject;
	Vector3 endObject;
	
	void Dijkstra (Vector3 start, Vector3 end) {
	
		int [,] graph = GameObject.FindGameObjectWithTag("LevelCreator").GetComponent<LevelCreator>().table;
		for (int i = 0; i < 10; i++)
			for (int j = 0; j < 10; j++)
				marked[i, j] = 0;
		
		while (start != end) {
			if (transform.position.x % 1 == 0 && transform.position.y % 1 == 0) {
			
				if (graph[(int)start.x + 1, (int)start.y] == 0 && marked[(int)start.x + 1, (int)start.y] == 0 && 
					(end - new Vector3(start.x + 1, start.y, start.z)).magnitude <= (end - start).magnitude) {
					marked[(int)start.x + 1, (int)start.y] = 1;
					transform.position = new Vector3 (start.x + 1, start.y, start.z);
				}
				
				if (graph[(int)start.x, (int)start.y + 1] == 0 && marked[(int)start.x, (int)start.y + 1] == 0 && 
					(end - new Vector3(start.x, start.y + 1, start.z)).magnitude <= (end - start).magnitude) {
					marked[(int)start.x + 1, (int)start.y + 1] = 1;
					transform.position = new Vector3 (start.x, start.y + 1, start.z);
				}
				
				if (graph[(int)start.x - 1, (int)start.y] == 0 && marked[(int)start.x - 1, (int)start.y] == 0 && 
					(end - new Vector3(start.x - 1, start.y, start.z)).magnitude <= (end - start).magnitude) {
					marked[(int)start.x - 1, (int)start.y] = 1;
					transform.position = new Vector3 (start.x - 1, start.y, start.z);
				}
				
				if (graph[(int)start.x, (int)start.y - 1] == 0 && marked[(int)start.x, (int)start.y - 1] == 0 && 
					(end - new Vector3(start.x, start.y - 1, start.z)).magnitude <= (end - start).magnitude) {
					marked[(int)start.x, (int)start.y - 1] = 1;
					transform.position = new Vector3 (start.x, start.y - 1, start.z);
				}
				
			}
		}
	}
	
	void Start () {
		
		startObject = transform.position;
		endObject = GameObject.FindGameObjectWithTag("Player1").transform.position;
		Dijkstra(startObject, endObject);
		
	}
	

	// Update is called once per frame
	void Update () {
		
		if (GameObject.FindGameObjectWithTag("Player1").transform.position != endObject) {
			endObject = GameObject.FindGameObjectWithTag("Player1").transform.position;
			Dijkstra(startObject, endObject);
		}
	
	}
}
