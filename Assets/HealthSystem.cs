using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace HybridGame
{
    public class HealthSystem : MonoBehaviour
    {
        public float totalHealth = 100;
        public float currentHealth;
        private Slider hearts;
        // Use this for initialization
        void Start()
        {
            this.currentHealth = this.totalHealth;
            this.hearts = GetComponentInChildren<Slider>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LateUpdate()
        {
            float healthPercent = this.currentHealth / this.totalHealth;
            this.hearts.value = healthPercent;
        }
    }
}