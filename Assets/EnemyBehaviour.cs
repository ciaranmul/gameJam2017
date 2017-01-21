using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using ObjectNames = Assets.scripts.ObjectNames;

public class EnemyBehaviour : MonoBehaviour
{
    private const float Speed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        //var player = GameObject.FindWithTag(ObjectNames.HeadOfPlayer).transform;
        //var distance = Vector3.Distance(this.transform.position, player.position);
        //if (distance < 20)
        //{
        //    var step = Speed * Time.deltaTime;

        //    // Is there a wall? 
        //    var x = (int)transform.position.x;
        //    var z = (int) transform.position.z;
        //    var mapCoordinate = CaveGenerator.Map[x, z];
        //    if (mapCoordinate == CaveGenerator.GridPiece.Wall)
        //    {
        //        var bestDirection = getBestDirection(x, z, player.position);
        //        switch (bestDirection)
        //        {
        //            case Movement.Left:
        //                transform.TransformDirection(Vector3.left * Time.deltaTime);
        //                break;
        //            case Movement.Right:
        //                transform.TransformDirection(Vector3.right * Time.deltaTime);
        //                break;
        //            case Movement.Up:
        //                transform.TransformDirection(Vector3.up * Time.deltaTime);
        //                break;
        //            case Movement.Down:
        //                transform.TransformDirection(Vector3.down * Time.deltaTime);
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        //    }
            
        }

        // Can we 

    }

//    /// <summary>
//    /// If the enemy enters a walled position, get positions of non-walled positions nearby and then select the direction which will bring us closer to the player
//    /// </summary>
//    /// <param name="x"></param>
//    /// <param name="z"></param>
//    /// <param name="playerPosition"></param>
//    /// <returns></returns>
//    private Movement getBestDirection(int x, int z, Vector3 playerPosition)
//    {
//        // Nearest grid space which is free

//        var potentialMovements = new List<PotentialMovement>();

//        // Left
//        if (CaveGenerator.Map[x-1, z] == CaveGenerator.GridPiece.None)
//        {
//            var move = new Vector3(x - 1, transform.position.y, transform.position.z);
//            potentialMovements.Add(new PotentialMovement {Movement = Movement.Left, Distance = Vector3.Distance(playerPosition, move) });
//        }
//        // Right
//        if (CaveGenerator.Map[x + 1, z] == CaveGenerator.GridPiece.None)
//        {
//            var move = new Vector3(x + 1, transform.position.y, transform.position.z);
//            potentialMovements.Add(new PotentialMovement { Movement = Movement.Left, Distance = Vector3.Distance(playerPosition, move) });
//        }
//        // Up
//        if (CaveGenerator.Map[x, z + 1] == CaveGenerator.GridPiece.None)
//        {
//            var move = new Vector3(transform.position.x, transform.position.y, z + 1);
//            potentialMovements.Add(new PotentialMovement { Movement = Movement.Left, Distance = Vector3.Distance(playerPosition, move) });
//        }
//        if (CaveGenerator.Map[x, z - 1] == CaveGenerator.GridPiece.None)
//        {
//            var move = new Vector3(transform.position.x, transform.position.y, z - 1);
//            potentialMovements.Add(new PotentialMovement { Movement = Movement.Left, Distance = Vector3.Distance(playerPosition, move) });
//        }

//        // Which move brings us closer to the player? 
//        return potentialMovements.OrderBy(p => p.Distance).First().Movement;
//    }
//}

//public class PotentialMovement
//{
//    public Movement Movement;
//    public float Distance;
//}

//public enum Movement
//{
//    Up = 0,
//    Down = 1,
//    Left = 2,
//    Right = 3,
//}
