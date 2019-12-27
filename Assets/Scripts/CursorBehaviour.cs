using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorBehaviour : Bolt.EntityBehaviour<ICursorState>
{
    public override void Attached()
    {
        state.SetTransforms(state.CursorTransform, transform);
        if (entity.IsOwner)
        {
            GetComponent<Image>().enabled = false;
        }
    }

    public override void SimulateOwner()
    {
        // CHANGE TO DELAY MOUSE POSITION, USE LERP OR SOMETHING
        transform.position = Input.mousePosition;

    }
}
