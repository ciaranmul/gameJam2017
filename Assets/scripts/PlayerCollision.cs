using Assets.scripts;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip pickup_sound;
    private bool _hasCollided = false;

    // Menu
    //public Transform Menu;
    public RectTransform Menu;

	// Use this for initialization
	void Start ()
    {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.CompareTag (ObjectTags.Treasure))
        {
			if (audioSource != null)
            {
				audioSource.PlayOneShot (pickup_sound);
			}
			col.gameObject.SetActive (false);
			ScoreManager.score++;
		}
        else if (col.gameObject.CompareTag(ObjectTags.Enemy))
		{
		    var gameObject = GameObject.FindGameObjectWithTag("menu");
		    if(!_hasCollided)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 1,
		        gameObject.transform.position.z);
                _hasCollided = true;
            }
            Debug.Log("Yep it worked");
		}
	}

    //IEnumerator GameOver(float seconds)
    //{
    //    Debug.Log("The game is over!");
    //    yield return new WaitForSeconds(seconds);
    //    GameObject menu = (GameObject) Instantiate(Resources.Load("PanelMenu"));
    //    SceneManager.MoveGameObjectToScene(menu, SceneManager.GetActiveScene());
    //}
}
