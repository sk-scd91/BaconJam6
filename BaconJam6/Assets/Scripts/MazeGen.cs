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
		horizontalWalls = new bool[gridSize.y - 1, gridSize.x];
		verticalWalls = new bool[gridSize.y, gridSize.x - 1];
		
		//Random.seed = (int)Time.time; //seed the RNG
		
		GenStep(0, 0, gridSize.x, gridSize.y);
		
		//Create border walls.
		CreateHorizontalWall(0f, gridSize.y/2f, gridSize.x);
		CreateHorizontalWall(0f, -gridSize.y/2f, gridSize.x);
		CreateVerticalWall(-gridSize.x/2f, 0f, gridSize.y);
		CreateVerticalWall(gridSize.x/2f, 0f, gridSize.y);
		
		//build all horizontal walls.
		for(int i = 0; i < horizontalWalls.GetLength(0); i++) {
			for(int j = 0; j < horizontalWalls.GetLength(1); i++) {
				if (!horizontalWalls[i, j]) { //Until we find a gap.
					if (j > 0) //left wall
						CreateHorizontalWall(-gridSize.x/2f+j*0.5f, 
							(float)i+gridSize.y/2f-1f, (float)j);
					if (j < horizontalWalls.GetLength(1) - 1) { //right wall
						float otherJ = (float)(gridSize.x-j-1);
						CreateHorizontalWall(gridSize.x/2f-otherJ*0.5f, 
							(float)i+gridSize.y/2f-1f, otherJ);
					}
					break;
				}
			}
		}
		//now build vertical walls.
		for(int i = 0; i < verticalWalls.GetLength(1); i++) {
			for(int j = 0; j < horizontalWalls.GetLength(0); i++) {
				if (!verticalWalls[j, i]) {
					if (j > 0) //upper wall
						CreateVerticalWall((float)i+1f-gridSize.x/2f, 
							gridSize.y/2f-i*0.5f, (float)j);
					if (j < verticalWalls.GetLength(0) - 1) { //lower wall
						float otherJ = (float)(gridSize.y-j-1);
						CreateVerticalWall((float)i+1f-gridSize.x/2f, 
							-gridSize.y/2f+1f+otherJ*0.5f, otherJ);
					}
					break;
				}
			}
		}
		
	}
	
	// Generates a step in the maze.
	private void GenStep(int xStart, int yStart, int width, int height) {
		bool orientation = Random.Range(0, 2) == 1; //true if step is in horizontal direction
		//favor the shorter side.
		if (width != height)
			orientation = width < height;
		bool[,] walls = orientation ? horizontalWalls : verticalWalls;
		
		//make sure there is enough room to divide the maze.
		if (width > 1 && height > 1) {
			if (orientation) { // if horizontal
				int wallSpot = Random.Range(yStart, height-1);
				int spaceSpot = Random.Range (xStart, width);
				for (int i = 0; i < width; i++) {
					walls[wallSpot, i] = i != spaceSpot;
				}
				//Recurse above and below.
				GenStep(xStart, yStart, width, wallSpot-yStart+1);
				GenStep(xStart, wallSpot+1, width, height-wallSpot-1);
			} else {
				int wallSpot = Random.Range(xStart, width-1);
				int spaceSpot = Random.Range (yStart, height);
				for (int i = 0; i < height; i++) {
					walls[i, wallSpot] = i != spaceSpot;
				}
				//Recurse left and right.
				GenStep(xStart, yStart, wallSpot-xStart+1, height);
				GenStep(wallSpot+1, yStart, width-wallSpot-1, height);
			}
		}
	}
	
	//Set up horizontal wall
	private void CreateHorizontalWall(float x, float y, float size) {
		
	}
	
	//Set up horizontal wall
	private void CreateVerticalWall(float x, float y, float size) {
		
	}
}
