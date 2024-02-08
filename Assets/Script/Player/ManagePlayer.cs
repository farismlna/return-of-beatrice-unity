using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePlayer : MonoBehaviour
{
    [SerializeField] private GameObject menuEscape;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        menuEscape.SetActive(false);    
        dialogueBox.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuEscape.SetActive(!menuEscape.gameObject.activeSelf);
            menuEscape.LeanScale(Vector3.one, 0.8f);
        }

        if (menuEscape.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (menuEscape.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (dialogueBox.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (endGamePanel.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (gameOverPanel.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Debug.Log("Application has focus");
        }
        else
        {
            Debug.Log("Application not focus");
        }
    }
}
