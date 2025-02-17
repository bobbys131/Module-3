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
        public float playerSpeed;

        public void Start()
        {
            Debug.Log("PlayerMovement Start!");
        }

        public void FixedUpdate()
        {
            Debug.Log(moveAction.axis.x);
            Debug.Log(moveAction.axis.y);
            Vector3 MoveDirection = Player.instance.hmdTransform.TransformDirection(new Vector3(moveAction.axis.x, 0 , moveAction.axis.y));
            transform.position += Vector3.ProjectOnPlane(Time.deltaTime * MoveDirection * playerSpeed, Vector3.up);
        }
    }
}