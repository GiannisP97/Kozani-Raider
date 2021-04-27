using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class characterController2D : MonoBehaviour
{
    // Start is called before the first frame update
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[SerializeField] private float speed = 10f;
	[SerializeField] private float speed_while_air = 10f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	public AudioClip[] audioClip;

	
	const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private Animator animator;

	private bool jump = false;
	private float Horizontal_movement;

	private AudioSource audioSource;
	private bool start_invicible;
	public bool isTeleporting = false;

	public bool can_enter_teleport_room;

	private facts facts;


	public void setTeleport(bool i){

		can_enter_teleport_room = i;
	}


	private IEnumerator coroutine;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private Vector3 position_before_jump = new Vector3();

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioClip[0];


		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}
	void Update(){

		Horizontal_movement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;

		if(Horizontal_movement!=0 && m_Grounded)
			animator.SetInteger("State",2);
		else if(!m_Grounded)
			animator.SetInteger("State",1);
		else
			animator.SetInteger("State",0);

        if(Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log("Space Pressed");
            jump = true;
        }

		if(Input.GetKeyDown(KeyCode.E) && facts!=null){
			if(GetComponent<Books>().books>= facts.getcost()){
				if(!facts.getIsEmpty()){
					GetComponent<Books>().books-=facts.getcost();
					facts.DisplayFact();
				}else{
					GetComponent<setText>().setmessage("Δεν υπάρχει άλλη γνώση");
				}
			}
			else{
				GetComponent<setText>().setmessage("Δεν έχεις τα απαραίτητα βιβλία");
			}
			

		}
		/*
		if(Input.GetKeyDown(KeyCode.E) && TeleportTo!=null)
		{
			transform.position = TeleportTo.position;
			Camera.main.transform.position = new Vector3(TeleportTo.position.x,TeleportTo.position.y,Camera.main.transform.position.z);
		}
		*/
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
	
		

		if(m_Rigidbody2D.velocity.magnitude==0){
			animator.SetInteger("State",0);
		}

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
		//Debug.Log(m_Grounded);
		Move(Horizontal_movement,false,jump);
		jump = false;
	}


	public void Move(float move, bool crouch, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity;
			// Move the character by finding the target velocity
			if(!m_Grounded){
				targetVelocity = new Vector2(move * 10f * speed_while_air, m_Rigidbody2D.velocity.y);
			}
			else{
				targetVelocity = new Vector2(move * 10f * speed, m_Rigidbody2D.velocity.y);

			}
			if(move==0 && m_Grounded){
				audioSource.Stop();
			}
			else if(m_Grounded){
				if(!audioSource.isPlaying){
					audioSource.Play();
				}
			}

				
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
			
			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			position_before_jump = this.transform.position;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			audioSource.clip = audioClip[3];
			//audioSource.loop = false;
			audioSource.Play();
			//animator.SetInteger("State",1);
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        if(other.GetComponent<startgame>()!=null){
            this.GetComponent<AutoScroller>().scrolling = true;
        }
		if(other.gameObject.name=="deathTrigger"){
			this.GetComponent<Health>().health--;
			transform.position = position_before_jump;
		}
		if(other.gameObject.GetComponent<DoorTrigger>()!=null){
			if(can_enter_teleport_room){
				other.gameObject.GetComponent<DoorTrigger>().disableDoor();
			}
		}
		

		if(other.tag=="book"){
			this.GetComponent<Books>().books++;
			Destroy(other.gameObject);
		}



		if(other.GetComponent<DisplayMessage>()!=null){
			other.GetComponent<DisplayMessage>().setText();
		}

		if(other.GetComponent<facts>()!=null){
			facts = other.GetComponent<facts>();
			GetComponent<setText>().setmessage("Πάτα Ε για να αγοράσεις γνώσεις. Η επόμενη γνώση κοστίζει "+other.GetComponent<facts>().getcost());
		}
		if(other.GetComponent<Teleport>()!=null ){
			GetComponent<Health>().health = GetComponent<Health>().numOfHearts;
			if(other.GetComponent<Teleport>().active){
				GetComponent<setText>().setmessage("Πάτα Ε για τηλεμεταφορά");
			}
		}

    }

	private void OnTriggerStay2D(Collider2D other){
		if(other.GetComponent<Crystal>()!=null && !start_invicible){
			this.GetComponent<Health>().health-=other.GetComponent<Crystal>().damage;
			m_Rigidbody2D.velocity = m_Rigidbody2D.velocity*-0.5f;
			
			coroutine = invinsiblility(2f);
        	StartCoroutine(coroutine);

		}
	}
	private void OnCollisionEnter2D(Collision2D other){
		string name = other.gameObject.name;
		switch(name){
			case "Tilemap_snow":
				audioSource.clip = audioClip[1];
				break;
			case "Tilemap_grass":
				audioSource.clip = audioClip[0];
				break;
			case "Tilemap_ice":
				audioSource.clip = audioClip[2];
				break;
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		if(other.GetComponent<Teleport>()!=null){
			GetComponent<setText>().setmessage("");
		}

		if(other.GetComponent<DisplayMessage>()!=null){
			other.GetComponent<DisplayMessage>().hideText();
		}

		if(other.GetComponent<facts>()!=null){
			GetComponent<setText>().setmessage("");
			facts = null;
		}
	}

	public void resetInvisiblility(){
		start_invicible = false;
		Color tmp = GetComponent<SpriteRenderer>().color;
		tmp.a = 1;
		GetComponent<SpriteRenderer>().color = tmp;
	}

	 private IEnumerator invinsiblility(float waitTime)
    {
		start_invicible  = true;
		Color tmp = GetComponent<SpriteRenderer>().color;
		


		for(int i=0;i<10;i++){
			tmp.a = 0.3f;
			GetComponent<SpriteRenderer>().color = tmp;
			yield return new WaitForSeconds(waitTime/20);
			tmp.a = 0.8f;
			GetComponent<SpriteRenderer>().color = tmp;
			yield return new WaitForSeconds(waitTime/20);
		}

		tmp.a = 1f;
		GetComponent<SpriteRenderer>().color = tmp;

		start_invicible  =false;

    }
}
