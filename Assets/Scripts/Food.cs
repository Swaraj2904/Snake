using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	public SnakeController player;

	void Start () {
		SpawnFood (new Vector3 (10, 0, 0));
	}

	Vector3 FoodSpawnPosition (Vector3 snakeHeadPosition) {
		int variance = 10;

		float xPosition = (int)Random.Range (snakeHeadPosition.x - variance, snakeHeadPosition.x + variance);
		float yPosition = (float)0.5;
		float zPosition = (int)Random.Range (snakeHeadPosition.z - variance, snakeHeadPosition.z + variance);

		return new Vector3 (xPosition, yPosition, zPosition);
	}

	void SpawnFood (Vector3 snakeHeadPosition) {
		transform.position = FoodSpawnPosition (snakeHeadPosition);
	}

	/*
	 * 	We need to spawn food at another location as well as increase the size of the snake
	*/
	void OnTriggerEnter (Collider other) {
		SpawnFood (other.transform.position);
		player.AddSnakeBody ();
	}
}
