using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyController {

	//The purpose of keeping this variable commented is to allow the students to experiment with it and understand why GameObject 
    //is a bad choice in this particular scenario
    //private GameObject play;
    public float speedtowardplayer;
    private Controller player;

	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<Controller>();
	}
	
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardplayer * Time.deltaTime);

    
    }

}
