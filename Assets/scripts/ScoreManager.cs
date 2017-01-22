using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Transform player;
	public static int score;
	Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Artifacts: " + score;
	}

}
