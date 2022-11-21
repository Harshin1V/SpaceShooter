using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] private bool _gameOver = false;
    
    void Update()
    {
        if (Input.GetKeyDown("r") && _gameOver== true)
        {
            SceneManager.LoadScene("Gamescene"); //Load scene called Game
        }
    }

    public void GameOver()
    {
        _gameOver = true;
    }
}
