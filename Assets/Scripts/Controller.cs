using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HybridGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Jumper))]
    public class Controller : MonoBehaviour
    {

        public Transform groundOverlapTopLeft;
        public Transform groundOverlapBottomRight;
        public LayerMask groundLayers;
        public float movementSpeedMultiplier = 1.0f;
        [Range(0.5f, 1)]
        public float jumpingXSpeedMultiplier = 0.8f;

        private Animator animator;
        private bool isGrounded = true;
        private bool isJumping = false;
        private bool isMoving = false;
        private bool isFacingLeft = false;
        private Movement movement;
        private Rigidbody2D rb;
        private Jumper jumper;


        // Use this for initialization
        void Start()
        {
            this.animator = gameObject.GetComponentInChildren<Animator>();
            this.movement = gameObject.GetComponent<Movement>();
            this.rb = gameObject.GetComponent<Rigidbody2D>();
            this.jumper = gameObject.GetComponent<Jumper>();
            CheckFlags();
        }

        // Update is called once per frame
        void Update()
        {
            CheckFlags();
            SetExternals();
        }

        private void FixedUpdate()
        {
            ProcessMovement();
        }

        private void CheckFlags()
        {
            this.isGrounded = CheckIsGrounded();
            if (this.isGrounded){
                this.isJumping = false;
            }
        }

        private bool CheckIsGrounded()
        {
            return Physics2D.OverlapArea(
                this.groundOverlapTopLeft.position, 
                this.groundOverlapBottomRight.position, 
                this.groundLayers
            );
        }

        private void SetExternals()
        {
            this.animator.SetBool("is_grounded", this.isGrounded);
            this.animator.SetBool("is_jumping", this.isJumping);
            this.animator.SetBool("is_moving", this.isMoving);
            // Flip the sprite if moving left.
            transform.localScale = new Vector2(this.isFacingLeft ? -1 : 1,1);
        }

        private void ProcessMovement()
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            this.movement.MoveX(movementSpeedMultiplier * xInput); 
            jumper.Jump(this.isGrounded);
        }
    }
}