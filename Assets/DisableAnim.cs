using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnim : MonoBehaviour
{
    public Animation cageAnim;

    public Collider triggerDialogue;

    public Collider cageCollider;

    private void Start()
    {
        triggerDialogue.enabled = false;
    }

    public void WaitForDisableAnimation()
    {
        cageAnim.enabled = false;
        triggerDialogue.enabled = true;
        Destroy(cageCollider);
    }
}
