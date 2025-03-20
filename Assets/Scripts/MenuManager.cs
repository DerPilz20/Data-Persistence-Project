using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private GameObject canvas;
    private TextMeshProUGUI score;
    
    void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        canvas = GameObject.Find("Canvas");
        score = canvas.transform.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
