using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip pickup_sound;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("Treasure")) {
			if (audioSource != null) {
				audioSource.PlayOneShot (pickup_sound);
			}
			col.gameObject.SetActive (false);
			ScoreManager.score++;
		}

	}
}
