using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject CurrentCheckpoint; //so we can update the current checkpoint from within Unity
	// Use this for initialization
	public Transform enemy;

    public void RespawnPlayer()
    {
        FindObjectOfType<Controller>().transform.position = CurrentCheckpoint.transform.position;//Search for the asset/object called
        //Controller (your player's script code name whatever it is). Once you've found it, change its player game object's position
        //to be at thew last checkpoint the player passed through before s/he died
    }

	public void RespawnEnemy()
	{
		Instantiate(enemy, transform.position, transform.rotation);
	}
}
