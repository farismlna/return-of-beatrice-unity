using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour
{
    public Animation cageAnim;
    public GameObject mainCam;
    public GameObject cameraOpenCage;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                mainCam.SetActive(false);
                cameraOpenCage.SetActive(true);
                FindObjectOfType<AudioManager>().Play("OpenCage");
                Invoke("CageDoorOpen", 1);
                Invoke("SwitchCameraToMain", 2.5f);
            }
        }
    }

    public void CageDoorOpen()
    {
        cageAnim.Play();
    }

    public void SwitchCameraToMain()
    {
        cameraOpenCage.SetActive(false);
        mainCam.SetActive(true);
    }
}