using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using Valve.VR;

public class RisingWater : MonoBehaviour
{
    private float _min = 0.4f;
    private float _max = 1.2f;
    private float _speed = 0.01f;
    private float _velocity;

	// Use this for initialization
	void Start ()
	{
	    transform.position = new Vector3(transform.position.x, _min);
	}
	
	// Update is called once per frame
	void Update ()
    {
		transform.position += new Vector3(transform.position.x, _speed * Time.deltaTime);
	}
}
