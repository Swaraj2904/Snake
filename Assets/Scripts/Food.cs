using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	public SnakeController player;

	public void Start () {
		gameObject.SetActive (false);
	}

	public void SpawnFood (Vector3 snakeHeadPosition) {
		Debug.Log ("SpawnFood");
		transform.position = FoodSpawnPosition (snakeHeadPosition);
		Debug.Log (transform.position);
	}

	Vector3 FoodSpawnPosition (Vector3 snakeHeadPosition) {
		int variance = 20;

		float xPosition = (int)Random.Range (snakeHeadPosition.x - variance, snakeHeadPosition.x + variance);
		float yPosition = (float)0.5;
		float zPosition = (int)Random.Range (snakeHeadPosition.z - variance, snakeHeadPosition.z + variance);

		/*
		 * TODO: Exclude the snake body part positions as the possible food spawn positions
		*/

		return new Vector3 (xPosition, yPosition, zPosition);
	}

	/*
	 * 	We need to spawn food at another location as well as increase the size of the snake
	*/
	void OnTriggerEnter (Collider other) {
		/*
		 * Adding a snake body position at the current food position
		*/
		player.AddSnakeBodyPosition (transform.position);
		/*
		 * Spawning food at a new location
		*/
		SpawnFood (other.transform.position);
	}
}
