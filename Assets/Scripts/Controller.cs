using Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HybridGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Controller : MonoBehaviour
    {

        public Transform groundOverlapTopLeft;
        public Transform groundOverlapBottomRight;
        public LayerMask groundLayers;
        public float movementSpeedMultiplier = 1.0f;
        [Range(0.5f, 1)]
        public float jumpingXSpeedMultiplier = 0.8f;
        [Range(0.0f, 3.0f)]
        public float jumpFallGravMultiplier = 2.5f;
        [Range(0, 3)]
        public float lowJumpGravMultiplier = 2f;
        public float jumpForce = 10;

        private Animator animator;
        private bool isGrounded = true;
        private bool isJumping = false;
        private bool isMoving = false;
        private bool isFacingLeft = false;
        private Movement movement;
        private Rigidbody2D rb;
        private Jumper jumper;
        private IControl _control;


        // Use this for initialization
        void Start()
        {
            this.animator = gameObject.GetComponentInChildren<Animator>();
            this.rb = gameObject.GetComponent<Rigidbody2D>();
            CheckFlags();
            _control = new SNES8Bitdo();
            ControlList.Instance().AddControl(0, _control);
        }

        // Update is called once per frame
        void Update()
        {
            CheckFlags();
            SetExternals();
        }

        private void OnGUI()
        {
        }

        private void FixedUpdate()
        {
            ProcessMovement();
        }

        private void CheckFlags()
        {
            this.isGrounded = CheckIsGrounded();
            if (this.isGrounded)
            {
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
            this.animator.SetBool("is_moving", rb.velocity.x != 0);
            // Flip the sprite if moving left.
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }

        void LateUpdate()
        {
            ApplyGravity();
        }

        private void ApplyGravity()
        {
            if (this.rb.velocity.y < 0)
            {
                // We're falling
                rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpFallGravMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !_control.JumpButton())
            {
                // We're jumping
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravMultiplier - 1) * Time.deltaTime;
            }
        }

        private void ProcessMovement()
        {
            var xInput = _control.XAxis();
            float xSpeed = xInput * movementSpeedMultiplier * Time.deltaTime;
            float ySpeed = this.rb.velocity.y;
            rb.AddForce(new Vector2(xSpeed, ySpeed));
            if (isGrounded && ControlList.Instance().Player1().JumpButtonPressed())
            {
                rb.velocity += Vector2.up * jumpForce;
            }

        }
    }
}