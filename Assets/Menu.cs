using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
        GameSession gameStatus = FindObjectOfType<GameSession>();
        gameStatus.ResetGame();
    }
    public void LoadLevelById(int id)
    {
        SceneManager.LoadScene(id);
        Debug.Log("Lvl chgd.");
        //Just to make sure its working
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }

}
