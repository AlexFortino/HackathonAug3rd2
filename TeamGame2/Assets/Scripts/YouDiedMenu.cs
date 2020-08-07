using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedMenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject YouDied;
    public GameObject YouWon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    public void EndGame(bool win)
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (win)
        {
            YouWon.SetActive(true);
        }
        else
        {
            YouDied.SetActive(true);
        }

            
    }
}
