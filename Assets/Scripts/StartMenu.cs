using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("KaiScene");
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("HomePage");
    }

    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
