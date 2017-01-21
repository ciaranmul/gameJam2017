using System.Collections;
using System.Collections.Generic;
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
        var player = GameObject.FindWithTag(ObjectNames.HeadOfPlayer).transform;
        var distance = Vector3.Distance(this.transform.position, player.position);
        if (distance < 20)
        {
            Debug.Log("Moving towards the player");
            var step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }


    }
}
