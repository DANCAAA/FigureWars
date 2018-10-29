using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    [SerializeField]
    private GameObject panel;

    private bool pausa;

	// Use this for initialization
	void Start () {
        pausa = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPause()
    {
        pausa = !pausa;
        if (!pausa)
        {
            Time.timeScale = 1;
            panel.SetActive(false);
        }
        else if (pausa)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Lobby");
    }
}
