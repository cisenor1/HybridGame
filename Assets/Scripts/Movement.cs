using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HybridGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        public float movementForce = 10.0f;
        private Rigidbody2D rb;

        // Use this for initialization
        void Awake()
        {
            this.rb = GetComponent<Rigidbody2D>();
        }

        public void MoveX(float direction = 1.0f)
        {
            float ySpeed = this.rb.velocity.y;
            float xSpeed = direction * this.movementForce;
            this.rb.velocity = new Vector2(xSpeed, ySpeed);
        }
    }
}