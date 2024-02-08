using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [SerializeField] private GameObject panelQuest;
    [SerializeField] private GameObject settingOption;

    // Start is called before the first frame update
    void Start()
    {
        //settingOption.SetActive(false);
        panelQuest.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            settingOption.SetActive(true);

            if (settingOption.activeSelf == true)
            {
                panelQuest.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            settingOption.SetActive(false);
        }
    }

    public void DestroyTrigger()
    {
        Destroy(this.gameObject);
    }
}
