using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageIK : MonoBehaviour
{
    public bool ikActive = false;
    public Transform objTarget;
    public Transform pivotTarget;
    public float lookWeight;
    public float desireDist;

    private Animator animator;
    GameObject objPivot;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //object pivot
        objPivot = new GameObject("ObjectPivot");
        objPivot.transform.SetParent(pivotTarget.transform);
        objPivot.transform.localPosition = new Vector3(0, 1.6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        objPivot.transform.LookAt(objTarget);
        float pivotRotY = objPivot.transform.localRotation.y;
        //Debug.Log(pivotRotY);

        //target distance
        float dist = Vector3.Distance(objPivot.transform.position, objTarget.position);

        if (pivotRotY < 0.79f && pivotRotY > -0.79f && dist < desireDist)
        {
            lookWeight = Mathf.Lerp(lookWeight, 1, Time.deltaTime * 2.5f);
        }
        else
        {
            lookWeight = Mathf.Lerp(lookWeight, 0, Time.deltaTime * 2.5f);
        }
    }

    private void OnAnimatorIK()
    {
        if (animator)
        {
            if (ikActive)
            {
                if (objTarget != null)
                {
                    animator.SetLookAtWeight(lookWeight);
                    animator.SetLookAtPosition(objTarget.position);
                }
            }
            else
            {
                animator.SetLookAtWeight(0);
            }
        }
    }
}
