using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Transform groundOverlapTopLeft;
    public Transform groundOverlapBottomRight;
    public LayerMask groundLayers;

	private Animator animator;
    public bool isGrounded = true;
    private bool isJumping = false;
    private bool isMoving = true;
    private float movementSpeed = 0.0f;

	// Use this for initialization
	void Start () {
        this.animator = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        checkFlags();
        setExternals();
	}

    private void checkFlags()
    {
        this.isGrounded = checkIsGrounded();
    }

    private bool checkIsGrounded()
    {
        return Physics2D.OverlapArea(this.groundOverlapTopLeft.position, this.groundOverlapBottomRight.position, this.groundLayers);
    }

    private void setExternals()
    {
        this.animator.SetBool("is_grounded", this.isGrounded);
        this.animator.SetBool("is_jumping", this.isJumping);
        this.animator.SetBool("is_moving", this.isMoving);
    }

}
