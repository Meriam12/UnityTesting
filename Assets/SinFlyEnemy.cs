using UnityEngine;
using System.Collections;

public class SinFlyEnemy : MonoBehaviour {
	
	public float HorizzontalSpeed;
	public float VerticalSpeed;
	public float amplitude;
	
	private Vector3 temp_position;
	
	public float moveSpeed;
	private Controller player; 

	// Use this for initialization
	void Start () {
		temp_position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		temp_position.x += HorizzontalSpeed;
		temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
		transform.position = temp_position;
	}
	
}
