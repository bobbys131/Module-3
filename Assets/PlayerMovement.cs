//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Planting : MonoBehaviour
    {
        public SteamVR_Action_Vector2 moveAction;

        public void fixedUpdate()
        {
            Vector3 MoveDirection = Player.instance.hmdTransform.TransformDirection(new Vector3(moveAction.axis.x, 0 , moveAction.axis.y));
            transform.position += Vector3.ProjectOnPlane(Time.deltaTime * MoveDirection * 2.0f, Vector3.up);
        }
    }
}