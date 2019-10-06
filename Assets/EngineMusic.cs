using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _audioSource;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<EngineMusic>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    void Start()
    {
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12)) {
            if (Screen.fullScreen)
            {
                Screen.fullScreen = false;
            }
            else {
                Screen.fullScreen = true;
            }
        }
    }


}
