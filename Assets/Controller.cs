using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

   /*public float moveSpeed; //how fast the character moves
    public float jumpHeight; //how high the character jumps
    public bool isFacingRight; //check if character is facing right
    public KeyCode Spacebar; //Spacebar is the name we gave a keyboard button we chose to be the jump button. In this case, 
    //we chose the Space button, and called it Spacebar. To allocate the Space button to the name Spacebar, go to the Script 
    //component of your player character, and choose Space from the dropdown list
    public KeyCode L;//L is the name we gave a keyboard button we chose to be the left movement button.
    public KeyCode R;//R is the name we gave a keyboard button we chose to be the right movement button.
    public Transform groundCheck; //an invisible point in space. We use it to see if the player is touching the ground
    public float groundCheckRadius; //a value to determine how big the circle around the player's feet is, and therefore determine how
    //close he is to the ground
    public LayerMask whatIsGround; //this variable stores what is considered a ground to the character
    public bool grounded= true; //check if the character is standing on solid ground;

    private Animator anim; //instance of Animator object to control the character's animation in code
    // Use this for initialization
	

    public AudioClip walk1;
    public AudioClip walk2;
    public AudioClip jump1;
    public AudioClip jump2;
    

	void Start () {

        anim = GetComponent<Animator>();//The player now has an Animator component attached to it, and the animation will play accordingly 
        //when the character moves
    }
	
	// Update is called once per frame
	void Update () {
       
        anim.SetBool("Grounded", grounded);//Animator understands that its parameter Grounded and the boolean value grounded are related
        
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));//this function takes the Animator’s parameter name 
        //(in this case Speed), and gives it the value of the character’s current velocity on the x-axis. However, the fact that x could
        //be a negative value can cause problems, so Mathf.Abs turns any -ve number into positive without affecting the player character's
        //direction

        if (Input.GetKey(L)) //When user presses the left arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //player character 
            //moves horizontally to the left along the x-axis without disrupting jump
            AudioManager.instance.RandomizeSfx(walk1, walk2);
            
            if(isFacingRight=true)
            {
                Flip();
                isFacingRight = false;
            }
        }
      
        if (Input.GetKey(R)) //When user presses the left arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //player character moves 
            //horizontally to the right along the x-axis without disrupting jump
            AudioManager.instance.RandomizeSfx(walk1, walk2);
             if(isFacingRight=false)
            {
                Flip();
                isFacingRight = true;
            }
        }

        if (Input.GetKey(Spacebar) && grounded) //When user presses the left arrow button
        {
            Jump();
        }
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //this statement calculates when 
        //exactly the character is considered by Unity's engine to be standing on the ground. 
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //player character jumps 
        //vertically along the y-axis without disrupting horizontal walk  
         AudioManager.instance.RandomizeSfx(jump1, jump2);
    }


    //The following function flips the character to face the right direction. If velocity along x-axis <0, character
    //faces the left. If velocity > 0, character faces the right.
       
    void Flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }*/

    public float moveSpeed; //how fast the character moves
    public float jumpHeight; //how high the character jumps
    private bool isFacingRight; //check if character is facing right
    public KeyCode Spacebar; //Spacebar is the name we gave a keyboard button we chose to be the jump button. In this case, 
    //we chose the Space button, and called it Spacebar. To allocate the Space button to the name Spacebar, go to the Script 
    //component of your player character, and choose Space from the dropdown list
    public KeyCode L;//L is the name we gave a keyboard button we chose to be the left movement button.
    public KeyCode R;//R is the name we gave a keyboard button we chose to be the right movement button.
    public Transform groundCheck; //an invisible point in space. We use it to see if the player is touching the ground
    public float groundCheckRadius; //a value to determine how big the circle around the player's feet is, and therefore determine how
    //close he is to the ground
    public LayerMask whatIsGround; //this variable stores what is considered a ground to the character
    public bool grounded= true; //check if the character is standing on solid ground;

    private Animator anim; //instance of Animator object to control the character's animation in code
    // Use this for initialization

    public bool directionFlag; //Bool value to be used by Follower Enemy to know which direction the Player sprite is facing

	void Start () {

        isFacingRight = true;
        directionFlag = true;
        anim = GetComponent<Animator>();//The player now has an Animator component attached to it, and the animation will play accordingly 
        //when the character moves
    }
	
	// Update is called once per frame
	void Update () {
       
        if(Input.GetKeyDown(Spacebar) && grounded) //When user presses the space button ONCE
        {
            Jump(); //see function definition below   
        }

        anim.SetBool("Grounded", grounded);//Animator understands that its parameter Grounded and the boolean value grounded are related
       
        if (Input.GetKey(L)) //When user presses the left arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //player character 
            //moves horizontally to the left along the x-axis without disrupting jump  

		    if(isFacingRight)
		    {
			    Flip();
			    isFacingRight=false;
                directionFlag=isFacingRight;
		    }         
        }
      
        if (Input.GetKey(R)) //When user presses the left arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y); //player character moves 
            //horizontally to the right along the x-axis without disrupting jump

		    if(!isFacingRight)
		    {
			    Flip();
			    isFacingRight=true;
                directionFlag=isFacingRight;
		    }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));//this function takes the Animator’s parameter name 
        //(in this case Speed), and gives it the value of the character’s current velocity on the x-axis. However, the fact that x could
        //be a negative value can cause problems, so Mathf.Abs turns any -ve number into positive without affecting the player character's
        //direction

	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position/*GetComponent<Rigidbody2D>().position*/, groundCheckRadius, whatIsGround); //this statement calculates when 
        //exactly the character is considered by Unity's engine to be standing on the ground. 
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight); //player character jumps 
        //vertically along the y-axis without disrupting horizontal walk  
    }

	void Flip()
	{
		transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
	}


}
