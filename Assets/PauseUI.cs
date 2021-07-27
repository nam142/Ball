using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public bool pause = false;
    public GameObject PauseUi;
    // Start is called before the first frame update
    void Start()
    {
        PauseUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            PauseUi.SetActive(true);
            Time.timeScale = 0;
        }
        if (pause == false)
        {
            PauseUi.SetActive(false);            
             Time.timeScale = 1;            
        }
    }
    public void resume()
    {
        pause = false;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void quit()
    {
        Application.Quit();
    }
}
