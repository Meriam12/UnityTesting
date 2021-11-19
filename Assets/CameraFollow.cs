using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    /*public Controller thePlayer;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    void Start()
    {
        thePlayer = FindObjectOfType<Controller>();
        lastPlayerPosition = thePlayer.transform.position;
        
        // Or do offset = new Vector3(target.x, target.y, -10);
    }

    void Update()
    {
        //lastPlayerPosition = thePlayer.transform.position;
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove,transform.position.y,transform.position.z);
    }*/

    public Transform target;
    public float smoothing;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
        // Or do offset = new Vector3(target.x, target.y, -10);
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }

    

}
