using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public Animator animator;
    public GameObject buttonPanel;
    public TextMeshProUGUI interactText;

    public string openDoor;
    
    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            buttonPanel.SetActive(true);
            interactText.text = openDoor;

            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("isOpen", true);
                Debug.Log("door is open!");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("masuk");
                Debug.Log("door is open!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("keluar");
            buttonPanel.SetActive(false);
        }
    }
}
