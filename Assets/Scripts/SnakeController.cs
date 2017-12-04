using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour {
	public Snake snakeBody;
	public float speedMax;
	public GameController gameController;
	public Slider vitality;

	private List<Snake> snake = new List<Snake> ();
	private int counter;
	private char prevKey;
	private Vector3 speed;
	private List<Vector3> toBeBodyPosition = new List<Vector3> ();
	private Vector3 snakeHeadPosition;


	void Start () {
		counter = 0;
		vitality.value = 0;
		prevKey = 'W';
		speed = new Vector3 (0, 0, speedMax);
		snakeHeadPosition = new Vector3 (0, 0.5F, 0);
	}

	public Vector3 SpawnSnake () {
		AddSnakeBody (snakeHeadPosition);
		AddSnakeBody (snakeHeadPosition - speed);
		AddSnakeBody (snakeHeadPosition - speed - speed);

		vitality.value = 6;

		return snakeHeadPosition;
	}

	void Update () {
		if (gameController.start == true) {
			counter++;

			switch (prevKey) {
			case 'W':
				if (Input.GetKeyDown (KeyCode.A)) {
					speed = new Vector3 (-speedMax, 0, 0);
					prevKey = 'A';
				} else if (Input.GetKeyDown (KeyCode.D)) {
					speed = new Vector3 (speedMax, 0, 0);
					prevKey = 'D';
				}
				break;
			case 'A':
				if (Input.GetKeyDown (KeyCode.W)) {
					speed = new Vector3 (0, 0, speedMax);
					prevKey = 'W';
				} else if (Input.GetKeyDown (KeyCode.S)) {
					speed = new Vector3 (0, 0, -speedMax);
					prevKey = 'S';
				}
				break;
			case 'S':
				if (Input.GetKeyDown (KeyCode.A)) {
					speed = new Vector3 (-speedMax, 0, 0);
					prevKey = 'A';
				} else if (Input.GetKeyDown (KeyCode.D)) {
					speed = new Vector3 (speedMax, 0, 0);
					prevKey = 'D';
				}
				break;
			case 'D':
				if (Input.GetKeyDown (KeyCode.W)) {
					speed = new Vector3 (0, 0, speedMax);
					prevKey = 'W';
				} else if (Input.GetKeyDown (KeyCode.S)) {
					speed = new Vector3 (0, 0, -speedMax);
					prevKey = 'S';
				}
				break;
			default:
				break;

			}
				

			/*
			 * Movements in quantums
			*/
			if (counter % 10 == 0) {
				/*
				 * Removing the snake body part from queue to be added to the snake.
				 * Also enabling its Rigidbody and Collider.
				*/
				if (toBeBodyPosition.Count > 0 && snake [snake.Count - 1].transform.position == toBeBodyPosition [0]) {
					AddSnakeBody (toBeBodyPosition [0]);
					toBeBodyPosition.RemoveAt (0);
				}

				for (int i = snake.Count - 1; i > 0; i--) {
					snake [i].transform.position = snake [i - 1].transform.position;
				}

				snake [0].transform.position = snake [0].transform.position + speed;
			}
		} else if (gameController.end == true) {
			/*
			 * Emptying the current snake
			*/
			for (int i = 0; i < snake.Count; i++) {
				Debug.Log (i);
				Destroy (snake [i].gameObject);
			}

			snake = new List<Snake> ();

			/*
			 * Initializing for the next play
			*/
			Start ();

			/*
			 * Setting the flag to false so as to display the main menu
			*/
			gameController.end = false;
		}
	}


	public void AddSnakeBodyPosition(Vector3 foodPosition){
		/*
		 * The new snake body will be instantiated at the foodPosition
		 * after the last part of the snake has just crossed it
		*/
		toBeBodyPosition.Add (foodPosition);
	}


	public void AddSnakeBody (Vector3 position) {
		/*
		 * Creating an instance of the prefab.
		*/
		Snake bodypartInstance = Instantiate (snakeBody);

		/*
		 * Setting the body part as a child of Snake
		*/
		bodypartInstance.transform.SetParent (this.transform);

		/*
		 * Setting the snake body position equal to the parameter.
		*/
		bodypartInstance.transform.position = position;

		/*
		 * Adding the body part to the List of snake body parts
		*/
		snake.Add (bodypartInstance);

		/*
		 * Upon addition of snake body increase the vitality of snake
		*/
		vitality.value += 2;
	}

	public void OnSnakeCollision(){
		gameController.EndGame ();
	}
}
 	