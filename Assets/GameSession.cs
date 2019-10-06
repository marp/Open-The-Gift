using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int lifes = 5;
    // Start is called before the first frame update
    void Awake()
    {
        int GameSessionsCount = FindObjectsOfType<GameSession>().Length;
        if (GameSessionsCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
