using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public Food food;
	public FloorUnit block;
	public Canvas panel;

	private Vector3 speed;



	// Use this for initialization
	void Start () {
		GenerateMaze ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void endGame () {
		
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