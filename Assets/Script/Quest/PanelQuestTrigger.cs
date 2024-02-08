using UnityEngine;

public class PanelQuestTrigger : MonoBehaviour
{
    public GameObject panelQuest;

    private void Start()
    {
        panelQuest.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        panelQuest.SetActive(true);
    }
}
