using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SG
{
    public class LookAtTarget : MonoBehaviour
    {
        public Transform target;
        public GameObject panelDialogue;
        // Update is called once per frame
        void Update()
        {
            if (panelDialogue.activeSelf == true)
            {
                transform.LookAt(target);
                GameObject.Find("Player").GetComponent<InputHandler>().enabled = false;
            }
            else if (panelDialogue.activeSelf == false)
            {
                GameObject.Find("Player").GetComponent<InputHandler>().enabled = true;
            }
        }
    }
}