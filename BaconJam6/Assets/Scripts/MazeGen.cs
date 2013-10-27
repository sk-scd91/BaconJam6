using UnityEngine;
using System.Collections;

// MazeGen.cs
// Creates a maze using recursive 

public class MazeGen : MonoBehaviour {
	
	public Vector2 gridSize;
	
	//Maze spots
	private bool[,] horizontalWalls;
	private bool[,] verticalWalls;

	// Use this for initialization
	void Start () {
		horizontalWalls = new int[gridSize.y, gridSize.x];
		verticalWalls = new int[gridSize.y, gridSize.x];
		
		//Random.seed = (int)Time.time; //seed the RNG
		
		GenStep(0, 0, gridSize.x, gridSize.y);
	
	}
	
	// Generates a step in the maze.
	private void GenStep(int xStart, int yStart, int width, int height) {
		bool orientation = Random.Range(0, 2) == 1; //true if step is in horizontal direction
		//bias toward shorter side.
		if (width != height)
			orientation = width < height;
		bool[,] walls = orientation ? horizontalWalls : verticalWalls;
		
		//make sure there is enough room to divide the maze.
		if (width > 1 && height > 1) {
			if (orientation) { // if horizontal
				int wallSpot = Random.Range(yStart, height);
				int spaceSpot = Random.Range (xStart, width);
				for (int i = 0; i < width; i++) {
					walls[wallSpot, i] = i != spaceSpot;
				}
				//Recurse above and below.
				GenStep(xStart, yStart, width, wallSpot - yStart);
				GenStep(xStart, wallSpot+1, width, height-wallSpot-1);
			} else {
				int wallSpot = Random.Range(xStart, width);
				int spaceSpot = Random.Range (yStart, height);
				for (int i = 0; i < height; i++) {
					walls[i, wallSpot] = i != spaceSpot;
				}
				//Recurse left and right.
				GenStep(xStart, yStart, wallSpot - xStart, height);
				GenStep(wallSpot+1, yStart, width-wallSpot-1, height);
			}
		}
	}
	
	
}
