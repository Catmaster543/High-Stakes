using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        //Play cutscene like a good script >:)
    }

    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Day 1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
