using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiBird : EnemyController {

	void FixedUpdate ()
	{
		if(this.isFacingRight == true)
		{
			this.GetComponent<Rigidbody2D>().velocity =
				new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			this.GetComponent<Rigidbody2D>().velocity =
				new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
		}
	}

    // This is overrided from the parent calss due to more if stmts needed here
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag == "Wall")
		{
			Flip ();
		}
		else if (collider.tag == "Enemy")
		{
			Flip ();
		}
		if(collider.tag == "Player")
		{
            //AudioManager.instance.RandomizeSfx(hit1, hit2);
			FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
		}
	}
}
