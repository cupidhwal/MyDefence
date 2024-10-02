using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class PlayerTest : MonoBehaviour
    {
        private float JumpForce;

        private Rigidbody rbPlayer;

        private void Start()
        {
            JumpForce = 10;

            rbPlayer = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            Debug.Log("¿é!");
            rbPlayer.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }
    }
}