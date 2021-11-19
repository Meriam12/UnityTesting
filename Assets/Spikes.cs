using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //function that executes upon trigger (when something collides with the spikes)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Sonic GameObject") 
        //if the collider of the object whose name is Sonic GameObjects touches the spike collider
            
         FindObjectOfType<LevelManager>().RespawnPlayer();
        //go to the Level Manager script, and execute the Respawn Player function
    }
}
