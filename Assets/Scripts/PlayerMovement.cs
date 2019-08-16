using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
    public string movementKey;
    public string jumpKey;
    public string attackKey;
    public string attack2Key;

    public AudioSource slashSound;
    public AudioSource laughSound;
    public GameObject cloud;
    public GameObject fusion;
    public GameObject storm;

    private Animator anim;
	float horizontalMove = 0f;
    float verticalMove = 0f;
	bool jump = false;
	bool crouch = false;
    private Player player;
    private Rigidbody2D rb;
    private bool pressed = false;
    private GameObject boss;
    private Transform bossPosition;
    private int count;

    private void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        anim = fusion.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update () {

        Debug.Log("haiz");
        Debug.Log(player.state);
        // Left-Right
		horizontalMove = Input.GetAxisRaw(movementKey) * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Jump
        if (!(player.state == 1 && player.skill == 1))
        {
            if (Input.GetButtonDown(jumpKey))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }


        // Basic Attack
        if (Input.GetButtonDown(attackKey))
        {
            slashSound.Play();
            animator.SetTrigger("attack");

        }

        // Fusion skill
        if (Input.GetButtonDown(attack2Key))
        {
            laughSound.Play();
            Time.timeScale = 0f;
            Destroy(Instantiate(fusion, fusion.transform.position, fusion.transform.rotation),2);
            Time.timeScale = 1f;
            Invoke("FusionSkill", 2);
        }

        // Cloud Pocket
        if (player.state == 1)
        {
            Debug.Log("Player STATE 1");
            // Allow for vertical Move
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (pressed)
                {
                    player.skill = 0;
                    pressed = false;
                    Debug.Log("CONVERTING BACK TO DYNAMIC");
                    //Destroy(cloud);
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
                else
                {
                    player.skill = 1;
                    Debug.Log("CONVERTING TO KINEMATIC");
                    rb.bodyType = RigidbodyType2D.Kinematic;
                    pressed = true;
                    //Instantiate(cloud, player.transform.position, player.transform.rotation);
                }

            }
            if (player.skill == 1)
            {
                verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
                Debug.Log("VERTICAL MOVE: " + verticalMove);
                Debug.Log("Player Skill: " + player.skill);
                Vector3 tempVect = new Vector3(0, 0, verticalMove);
                tempVect = tempVect.normalized * runSpeed * Time.deltaTime;
                rb.MovePosition(transform.position + tempVect);
                //verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
            }
        }

        // Fusion Skill

        if (player.state == 2)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("FUSION SKILL!");
            }
        }

       /* if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Time.timeScale = 1f;
        }*/
	/*	if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
        */
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	/*public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}*/

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    void FusionSkill()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossPosition = boss.transform;
        Destroy(Instantiate(storm, bossPosition.transform.position, bossPosition.transform.rotation), 6);
        while (count < 2)
        {
            boss.GetComponent<Boss>().TakeDamage(100);
            count++;
            Debug.Log("HEALTH:" + boss.GetComponent<Boss>().health);
        }
    }
   
}
