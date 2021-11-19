using UnityEngine;
using System.Collections;

public class CoinsPickup : MonoBehaviour {


		public int coinValue = 1;
        //public AudioClip coin1;
        //public AudioClip coin2;

		void OnTriggerEnter2D(Collider2D collider)
		{
		if(collider.tag == "Player")
		{
            //AudioManager.instance.RandomizeSfx(coin1,coin2);
			FindObjectOfType<PlayerStats>().CollectCoin(this.coinValue);
			Destroy(this.gameObject);
		}
	}
	}

	