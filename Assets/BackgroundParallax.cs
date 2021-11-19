using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {

    public Transform[] Backgrounds;//an array of backgrounds
    public float ParallaxScale; //proportion of camera's movement to move backgrounds by
    public float ParallaxReductionFactor;//as we move along in the array, we want the farthest backgrounds to move a little
	//slower. This value allows us to make the furthest background move slower than the closer backgrounds. The closest
	//moves fastest, and speed becomes slower and slower as we move backwards through the backgrounds
    public float smoothing;//the smoothness of the parallax effect

    private Vector3 lastPosition;//the position of the camera in the previous frame 

    // Use this for initialization
	void Start () {

        lastPosition = transform.position; //assign the camera's previous position to be the camera's position right now
        
	}
	
	// Update is called once per frame
	void Update () {

        var parallax = (lastPosition.x - transform.position.x) * ParallaxScale;//calculate the difference between the camera's
	//position from this frame and its position from last frame 
	
        for(var i = 0; i< Backgrounds.Length; i++)
        {
            var backgroundTargetPosition = Backgrounds[i].position.x + parallax * (i * ParallaxReductionFactor + 1);
            Backgrounds[i].position = Vector3.Lerp(
                Backgrounds[i].position, 
                new Vector3(backgroundTargetPosition,Backgrounds[i].position.y,Backgrounds[i].position.z), 
                smoothing * Time.deltaTime);
        }

        lastPosition = transform.position;
	
}
}
