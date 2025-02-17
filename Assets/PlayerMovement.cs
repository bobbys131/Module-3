//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class PlayerMovement : MonoBehaviour
    {
        public SteamVR_Action_Vector2 moveAction;
        public float forceMult;
        public float maxSpeed;
        public Rigidbody rb;

        public void Start()
        {
            Debug.Log("PlayerMovement Start!");
            rb = GetComponent<Rigidbody>();
        }

        public void Update()
        {
            if (rb.velocity.magnitude > maxSpeed)

            {

                // Clamp the velocity to the maximum speed

                Vector3 newVelocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

                rb.velocity = newVelocity;

            }
        }

        public void FixedUpdate()
        {
            Debug.Log(moveAction.axis.x);
            Debug.Log(moveAction.axis.y);
            Vector3 MoveDirection = Player.instance.hmdTransform.TransformDirection(new Vector3(moveAction.axis.x, 0 , moveAction.axis.y));
            MoveDirection.y = 0;
            rb.AddForce(MoveDirection * forceMult);
            //transform.position += Vector3.ProjectOnPlane(Time.deltaTime * MoveDirection * playerSpeed, Vector3.up);
        }
    }
}