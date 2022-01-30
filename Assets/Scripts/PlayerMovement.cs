using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Movement controller;
	
	public float runSpeed = 40f;
	public float climbSpeed = 10f;
	float horizontalMove = 0f;
	float verticalMove = 0f;
	bool jump = false;
	bool crouch = false;
	bool attack = false;
	bool movementDisabled = false;
	private Animator anim;

	private void Awake()
    {
		anim = GetComponent<Animator>();
	}
    // Update is called once per frame
    void Update()
    {
		if (movementDisabled)
		{
			horizontalMove = 0.0f;
			verticalMove = 0.0f;
			anim.SetBool("walking", false);
			return;
		}

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		verticalMove = Input.GetAxisRaw("Vertical") * climbSpeed;
		if (Input.GetKey(KeyCode.Space))
        {
			jump = true;
		}
		
		if(Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if(Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}		
		anim.SetBool("walking", horizontalMove != 0);
		anim.SetBool("climbing", verticalMove != 0);

		/*
		 * Check whether the mouse button is pressed
		 * plus the cooldown hasn't expired
		 */
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			attack = true;

			Debug.Log("KEY DOWN");
		}

		if(Input.GetKeyUp(KeyCode.Mouse0)){
			attack = false;

			Debug.Log("KEY UP");
		}
	}
    
    void FixedUpdate()
    {
		if (movementDisabled)
		{

		};
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, ref attack, verticalMove * Time.fixedDeltaTime);
		jump = false;
	}

	public void SetMovementDisabled(bool state)
	{
		movementDisabled = state;
	}
}
