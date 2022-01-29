using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Movement controller;
	
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	bool attack = false;
	private Animator anim;

    private void Awake()
    {
		anim = GetComponent<Animator>();
	}
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetKey(KeyCode.Space))
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
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, ref attack);
		jump = false;
	}
}
