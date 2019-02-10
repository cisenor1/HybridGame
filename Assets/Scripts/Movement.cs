using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HybridGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        public float movementForce = 10.0f;
        public float maxSpeed = 5f;
        private Rigidbody2D rb;

        // Use this for initialization
        void Awake()
        {
            this.rb = GetComponent<Rigidbody2D>();
        }

        public void MoveX(float direction = 1.0f)
        {
            float xSpeed = direction * this.movementForce * Time.deltaTime;
            xSpeed = Mathf.Min(xSpeed, maxSpeed);
            float ySpeed = this.rb.velocity.y;
            if (MathUtils.isZeroish(direction)){
                this.rb.velocity = new Vector2(0f, ySpeed);
            } else {
                this.rb.AddForce(new Vector2(xSpeed, ySpeed));
            }

        }
    }
}