using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startbutton()
    {
        SceneManager.LoadScene("new map");
    }
    public void quitbutton()
    {
        Application.Quit();
    }
}
