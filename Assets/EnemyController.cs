using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	[HideInInspector]
	public bool isFacingRight = false;
	public float maxSpeed = 2;
    public int damage = 6;

	public void Flip()
	{
		isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //Vector3 enemyScale = this.transform.localScale;
        //enemyScale.x = enemyScale.x * -1;
        //this.transform.localScale = enemyScale;
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
             FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
}
