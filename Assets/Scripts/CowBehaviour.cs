using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehaviour : Bolt.EntityBehaviour<ICowState>
{
    Animator cowAnimator;
    float cooldown = 0;
    public override void Attached()
    {
        cowAnimator = GetComponent<Animator>();
        state.SetTransforms(state.CowTransform, transform);
        state.SetAnimator(cowAnimator);
        transform.position = new Vector2(Random.Range(0, 3), -5.05f);
        state.Animator.applyRootMotion = entity.IsOwner;
    }
    public override void SimulateOwner()
    {
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !cowAnimator.GetBool("Mooing"))
        {
            // make cow move and set animation statuses
            transform.position = new Vector2(transform.position.x + (2f * Time.deltaTime), transform.position.y);
            cowAnimator.SetBool("Idle", false);
            cowAnimator.SetBool("Walking", true);

            transform.rotation = new Quaternion(0, 0, 0, 0);

            cooldown = 0;
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !cowAnimator.GetBool("Mooing"))
        {
            transform.position = new Vector2(transform.position.x - (2f * Time.deltaTime), transform.position.y);
            cowAnimator.SetBool("Idle", false);
            cowAnimator.SetBool("Walking", true);

            transform.rotation = new Quaternion(0, -180, 0, 0);
            
            cooldown = 0;
        }
        if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && cowAnimator.GetBool("Idle"))
        {
            cowAnimator.SetBool("Idle", false);
            cowAnimator.SetBool("Mooing", true);

            cooldown = -1;
        }
        if (cooldown > 0.1f)
        {
            cowAnimator.SetBool("Idle", true);

            cowAnimator.SetBool("Walking", false);
            cowAnimator.SetBool("Mooing", false);
        }

        cooldown += Time.deltaTime;
    }
}
