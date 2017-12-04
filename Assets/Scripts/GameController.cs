using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public Food food;
	public FloorUnit block;
	public Canvas panel;
	public SnakeController snakeController;
	public bool start;
	public bool end;

	private Vector3 speed;
	private GameObject button;


	// Use this for initialization
	void Start () {
		button = GameObject.Find ("Button");
	}

	public void startGame () {
		/*
		 * Hide the Play Button
		*/
		button.SetActive (false);

		GenerateMaze ();

		/*
		 * Spawn the snake
		*/
		Vector3 snakeHeadPosition = snakeController.SpawnSnake ();

		/*
		 * Spawn the food
		*/
		food.gameObject.SetActive (true);
		food.SpawnFood (snakeHeadPosition);

		start = true;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (food.transform.position);
	}

	public void EndGame () {
		end = true;
		start = false;

		food.transform.position = new Vector3 (0, -0.5F, 0);

		/*
		 * Reveal the Play Button
		*/
		button.SetActive (true);
	}

	void GenerateMaze () {
		//init with a 20 X 20 maze
		FloorUnit blockInstance;
		for (int i = -20; i < 20; i++) {
			for (int j = -20; j < 20; j++) {
				blockInstance = Instantiate (block);
				blockInstance.transform.position = new Vector3 (i, 0, j);
			}
		}
	}
}