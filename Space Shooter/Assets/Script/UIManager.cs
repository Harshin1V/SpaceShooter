using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _score;
    [SerializeField] private Sprite[] _liveSprite;
    [SerializeField] private Image _LivesImg;
    [SerializeField] private Text _gameoverText;
    [SerializeField] private Text _restartText;
    private gameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Score:"+0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<gameManager>();
        _gameoverText.gameObject.SetActive(false);
    }
     
    public void SetScore(int score)
    {
        _score.text = "Score:" + score;
    }

    public void UpdateLives( int CurrentLives)
    {
        _LivesImg.sprite = _liveSprite[CurrentLives];
        if(CurrentLives==0)
        {
            _gameManager.GameOver();
            _gameoverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
            StartCoroutine(gameOverFlickerRoutine());
        }
    }
    IEnumerator gameOverFlickerRoutine()
    {
        while(true)
        {
            _gameoverText.text = "GAME OVER!";
            yield return new WaitForSeconds(0.4f);
            _gameoverText.text = " ";
            yield return new WaitForSeconds(0.4f);

        }
    }
}
