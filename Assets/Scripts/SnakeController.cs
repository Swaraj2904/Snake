using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {
	public Snake snakeHead;
	public Snake snakeBody;
	public float speedMax;
	public GameController gameController;

	private List<Snake> snake = new List<Snake> ();
	private int counter;
	private char prevKey;
	private Vector3 speed;
	// Use this for initialization
	void Start () {
		counter = 0;
		prevKey = 'W';
		snake.Add (snakeHead);
		speed = new Vector3 (0, 0, speedMax);
	}
	
	// Update is called once per frame
	void Update () {
		counter++;

		switch(prevKey){
		case 'W':if (Input.GetKeyDown (KeyCode.A)) {
				speed = new Vector3 (-speedMax, 0, 0);
				prevKey = 'A';
		} else if (Input.GetKeyDown (KeyCode.D)) {
			speed = new Vector3 (speedMax, 0, 0);
			prevKey = 'D';
		}
		break;
		case 'A':if (Input.GetKeyDown (KeyCode.W)) {
				speed = new Vector3 (0, 0, speedMax);
				prevKey = 'W';
		} else if (Input.GetKeyDown (KeyCode.S)) {
			speed = new Vector3 (0, 0, -speedMax);
			prevKey = 'S';
		}
		break;
		case 'S':if (Input.GetKeyDown (KeyCode.A)) {
				speed = new Vector3 (-speedMax, 0, 0);
				prevKey = 'A';
		} else if (Input.GetKeyDown (KeyCode.D)) {
			speed = new Vector3 (speedMax, 0, 0);
			prevKey = 'D';
		}
		break;
		case 'D':if (Input.GetKeyDown (KeyCode.W)) {
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


		if (counter % 10 == 0) {
			for (int i = snake.Count - 1; i > 0; i--) {
				snake [i].transform.position = snake [i - 1].transform.position;
			}
			snake [0].transform.position = snake [0].transform.position + speed;
		}

	}

	public void AddSnakeBody () {
		Snake bodypartInstance = Instantiate (snakeBody);
		Debug.Log (bodypartInstance.transform.position);
		bodypartInstance.transform.SetParent (this.transform);
		/*
		 * Changing this since it is being counted as an internal collision
		*/
		float driftValue = 0.5F;
		Vector3 drift;
		switch (prevKey) {
		case 'W':
			drift = new Vector3 (0, 0, -driftValue);
			break;
		case 'A':
			drift = new Vector3 (driftValue, 0, 0);
			break;
		case 'S':
			drift = new Vector3 (0, 0, driftValue);
			break;
		case 'D':
			drift = new Vector3 (-driftValue, 0, 0);
			break;
		default:
			drift = Vector3.zero;
			break;
		}
		bodypartInstance.transform.position = snake [snake.Count - 1].transform.position + drift;
		snake.Add (bodypartInstance);
	}

	public void OnSnakeCollision(){
		Debug.Log ("Snake Collision occured");
		//gameController.endGame ();
	}
}
 	