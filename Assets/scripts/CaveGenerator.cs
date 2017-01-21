using System.Collections;
using System.Collections.Generic;
using Assets.scripts;
using UnityEngine;
using UnityEngine.UI;

public class CaveGenerator : MonoBehaviour {

	// PUBLIC VARIABLES EXPOSED TO THE EDITOR
	public int Width;
	public int Height;

	[Range(0,8)]
	public int DeathLimit;

	[Range(0,8)]
	public int BirthLimit;

	[Range(0,25)]
	public int Smoothing;

	[Range(0,100)]
	public int WallFillChance;

    [Range(0,100)]
    public int EnemyFillChance;

	public string Seed;

	public int TreasureLimit;

	// Tile map
	public static GridPiece[,] Map;

	// Wall Transform
	public Transform Wall;

	// Treasure Transform
	public Transform Treasure;

    // Enemy Tramform
    public Transform Enemy;

    public enum GridPiece
    {
        None = 0,
        Wall = 1,
        Enemy = 2
    }

	// Use this for initialization
	void Start () {

		Map = new GridPiece[Width, Height];
		Map = initialiseWalls (Map);
		for(int i=0; i<Smoothing; i++){
			Map = doSmoothing (Map);
		}
		populateGameObjects();
		populateTreasure (Map);
	}

	// Update is called once per frame
	void Update () {

	}

	private System.Random checkForSeed()
	{
	    var rand = Seed == "" ? new System.Random () : new System.Random (Seed.GetHashCode ());
	    return rand;
	}

	private GridPiece[,] initialiseWalls(GridPiece[,] map) {
		System.Random rand = checkForSeed ();
		for (int x = 0; x < Width; x++) {
			for (int y = 0; y < Height; y++) {
				if (rand.Next (0, 100) < WallFillChance) {
					map [x, y] = GridPiece.Wall;
				}
			}
		}
		return map;
	}

	private GridPiece[,] doSmoothing(GridPiece[,] oldMap){
		var newMap = new GridPiece[Width,Height];
		for (int x=0; x<oldMap.GetLength(0); x++){
			for (int y=0; y<oldMap.GetLength(1); y++){
				int neighbours = countNeighbours (oldMap, x, y);
				if (oldMap [x, y] == GridPiece.Wall) {
					if (neighbours < DeathLimit) {
						newMap [x, y] = GridPiece.None;
					} else {
						newMap [x, y] = GridPiece.Wall;
					}
				} else {
					if (neighbours > BirthLimit) {
						newMap [x, y] = GridPiece.Wall;
					} else {
						newMap [x, y] = GridPiece.None;
					}
				}
			}
		}
		return newMap;
	}

	private int countNeighbours(GridPiece[,] map, int x, int y)
    {
		int count = 0;
		for (int i=-1; i<2; i++){
			for (int j=-1; j<2; j++){
				int neighbour_x = x + i;
				int neighbour_y = y + j;
				if (i == 0 && j == 0) {
					// looking at middle point, do nothing
				} else if (x == 0 || y == 0 || neighbour_x >= (map.GetLength (0)-1) || neighbour_y >= (map.GetLength (1)-1)) {
					// neighbour is at edge of map
					count++;
				}
				else if (map[neighbour_x,neighbour_y] == GridPiece.Wall){
					// neighbour is alive
					count++;
				}
			}
		}
		return count;
	}

	private void populateTreasure(GridPiece[,] map){
		for (int x = 0; x < Width; x++) {
			for (int y = 0; y < Height; y++) {
				if (map [x, y] == GridPiece.None) {
					int nbrs = countNeighbours (map, x, y);
					if (nbrs >= TreasureLimit) {
						placeTreasure (x, y);
					}
				}
			}
		}
	}

	private void placeTreasure(int x, int y)
    {
		var pos = new Vector3 (-Width / 2 + x + .5f, .5f, -Height / 2 + y + .5f);
		Instantiate (Treasure, pos, Quaternion.identity);
	}

	private void populateGameObjects()
	{
	    if (Map == null) return;

	    for (int x = 0; x < Width; x++)
	    {
	        for (int y = 0; y < Height; y++)
	        {
	            float scaler = Random.Range (0,10);
	            if (x == 0 || y == 0 || x >= (Map.GetLength (0)-1) || y >= (Map.GetLength (1)-1))
	            {
	                var pos = positionCoordinates(x, 5, y);
	                Instantiate (Wall, pos, Quaternion.identity);
	            } 
	            else if (Map[x, y] == GridPiece.Wall)
	            {
	                var pos = positionCoordinates(x, 5, y, scaler);
	                Instantiate(Wall, pos, Quaternion.identity);
	            }
	        }
	    }
	}

    private Vector3 positionCoordinates(int x, int y, int z, float? scaler = null)
    {
        return scaler == null 
            ? new Vector3(-Width / 2 + x + .5f, y, -Height / 2 + z + .5f) 
            : new Vector3(-Width / 2 + x + .5f, y - scaler.Value, -Height / 2 + z + .5f);
    }

    private static Quaternion RandomRotation(System.Random random)
    {
        return Quaternion.Euler(0, RandomFloat(random, 0, 360), 0);
    }

    private static float RandomFloat(System.Random random, int upperBound, int lowerBound)
    {
        return (float)(random.NextDouble() * (upperBound - lowerBound) + lowerBound);
    }

    //void OnDrawGizmos() {
    //	if (map != null) {
    //		for (int x = 0; x < width; x ++) {
    //			for (int y = 0; y < height; y ++) {
    //				Gizmos.color = Color.black;
    //				if (map [x, y] == true) {
    //					Vector3 pos = new Vector3 (-width / 2 + x + .5f, 0.5f, -height / 2 + y + .5f);
    //					Gizmos.DrawCube (pos, Vector3.one);
    //				}
    //			}
    //		}
    //	}
    //}
}
