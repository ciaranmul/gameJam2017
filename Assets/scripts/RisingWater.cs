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
    private int _waveCount = 0;
    public static float WaterHeight;

	// Use this for initialization
	void Start ()
	{
	    transform.position = new Vector3(transform.position.x, _min);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _velocity = (_waveCount % 2 == 0) ? _speed : -_speed;
		ChangeWaterLevel();
	    WaterHeight = transform.position.y;
	}

    void ChangeWaterLevel()
    {
        transform.position += new Vector3(transform.position.x, _velocity * Time.deltaTime);
        HeightCheck();
    }

    void HeightCheck()
    {
        if (_velocity > 0 && transform.position.y >= _max ||
            _velocity < 0 && transform.position.y <= _min)
        {
            StartCoroutine(Suspend());
            _waveCount++;
        }
    }

    IEnumerator Suspend()
    {
        this.enabled = false;
        yield return new WaitForSeconds(100F);
        this.enabled = true;
    }
}
