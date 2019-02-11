using UnityEngine;
using System.Collections;
using Controls;

namespace HybridGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        public bool isJumping = false;
        [Range(1, 8)]
        public float jumpForce = 5.0f;
        [Range(0.0f,3.0f)]
        public float jumpFallGravMultiplier = 2.5f;
        [Range(0, 3)]
        public float lowJumpGravMultiplier = 2f;
        private Rigidbody2D rb;


        private void Awake()
        {
            this.rb = gameObject.GetComponent<Rigidbody2D>();
        }

        void LateUpdate()
        {
            ApplyGravity();
        }

        private void ApplyGravity(){
            if (this.rb.velocity.y < 0){
                // We're falling
                rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpFallGravMultiplier - 1) * Time.deltaTime;
            }else if (rb.velocity.y > 0 && !ControlList.Instance().Player1().JumpButton()){
                // We're jumping
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravMultiplier - 1) * Time.deltaTime;
            }
        }

        public bool Jump(bool isGrounded)
        {
            if (isGrounded && ControlList.Instance().Player1().JumpButtonPressed())
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            return this.isJumping;
        }
    }
}