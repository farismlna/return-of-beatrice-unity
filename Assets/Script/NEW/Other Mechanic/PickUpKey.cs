using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PickUpKey : MonoBehaviour
{
    public Collider cage1TriggerArea;
    public Collider cage2TriggerArea;
    public Collider cage3TriggerArea;
    public Collider cage4TriggerArea;
    public Collider cage5TriggerArea;
    public Collider cage6TriggerArea;
    public Collider cage7TriggerArea;

    public bool redKey;
    public bool purpleKey;
    public bool yellowKey;
    public bool greenKey;
    public bool blueKey;
    public bool whiteKey;
    public bool toskaKey;

    public VisualEffect visualEffectKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (redKey)
            {
                cage1TriggerArea.GetComponent<Collider>().enabled = true;
                FindObjectOfType<AudioManager>().Play("SoundTakeKey");
                visualEffectKey.enabled = false;
                gameObject.SetActive(false);
            }

            if (purpleKey)
            {
                cage2TriggerArea.GetComponent<Collider>().enabled = true;
                FindObjectOfType<AudioManager>().Play("SoundTakeKey");
                visualEffectKey.enabled = false;
                gameObject.SetActive(false);
            }

            if (yellowKey)
            {
                cage3TriggerArea.GetComponent<Collider>().enabled = true;
                FindObjectOfType<AudioManager>().Play("SoundTakeKey");
                visualEffectKey.enabled = false;
                gameObject.SetActive(false);
            }

            if (greenKey)
            {
                cage4TriggerArea.GetComponent<Collider>().enabled = true;
                FindObjectOfType<AudioManager>().Play("SoundTakeKey");
                visualEffectKey.enabled = false;
                gameObject.SetActive(false);
            }

            if (blueKey)
            {
                cage5TriggerArea.GetComponent<Collider>().enabled = true;
                FindObjectOfType<AudioManager>().Play("SoundTakeKey");
                visualEffectKey.enabled = false;
                gameObject.SetActive(false);
            }

            if (whiteKey)
            {
                cage6TriggerArea.GetComponent<Collider>().enabled = true;
                FindObjectOfType<AudioManager>().Play("SoundTakeKey");
                visualEffectKey.enabled = false;
                gameObject.SetActive(false);
            }

            if (toskaKey)
            {
                cage7TriggerArea.GetComponent<Collider>().enabled = true;
                FindObjectOfType<AudioManager>().Play("SoundTakeKey");
                visualEffectKey.enabled = false;
                gameObject.SetActive(false);
            }
        }
    }
}