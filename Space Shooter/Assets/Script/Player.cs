using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private GameObject _LaserPrefab;
    [SerializeField] private GameObject _TripleshotLaser;
    [SerializeField] private GameObject _shieldVisualizer;
    [SerializeField] private GameObject _leftEngine,_rightEngine;
    [SerializeField] private float _firerate = 0.1f;
    [SerializeField] private float _canFire = -1;
    [SerializeField] private int _lives = 3;
    [SerializeField] private int _score;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] bool _shieldActive = false;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private bool isTripleEnabled = false;

    [SerializeField] private AudioClip _laserSoundClip;
    private AudioSource _audioSource;

    

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();



        if ( _spawnManager == null)
        {
            Debug.LogError("null object");
        }

        transform.position = new Vector3(0, -3.0f, 0);
        if(_audioSource == null)
        {
            Debug.LogError("audio source error");
        }
        else
        {
            _audioSource.clip = _laserSoundClip;
        }

    }

    void Update()
    {
        
        CaluculatePosition();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Firelaser();
        }
        

    }
    void CaluculatePosition()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);


        // Vector3 direction = new Vector3(horizontalInput, verticalInput, 0
        // transform.Translate(direction) * _speed * Time.deltaTime);

        if (transform.position.x > 9.30)
        {
            transform.position = new Vector3(x: -9.30f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.30)
        {
            transform.position = new Vector3(9.30f, transform.position.y, 0);
        }

        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -9.30f, 9.30f), 0);

        if (transform.position.y >= 2.5f || transform.position.y <= -2.5f)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y < 0 ? -2.5f : +2.5f), 0);
        }


    }

    void Firelaser()
    {
        _canFire = Time.time + _firerate;

        if(isTripleEnabled == true)
        {
            Instantiate(_TripleshotLaser, transform.position + new Vector3(0, 1.2f, 0) , Quaternion.identity);
        }
        else
        {
            Instantiate(_LaserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
        }
        _audioSource.Play();

    }

    public void Damage()
    {
        if(_shieldActive == true)
        {
            _shieldActive = false;
            _shieldVisualizer.SetActive(false);
            return;
        }

        _lives--;
        if(_lives==2)
        {
            _leftEngine.SetActive(true);
        }
        else if(_lives==1)
        {
            _rightEngine.SetActive(true);
        }
        _uiManager.UpdateLives(_lives);
        if (_lives == 0)
        {
            Destroy(this.gameObject);
            _spawnManager.onPlayerDeath();
            
        }
    }

    public void TripleShotActive()
    {
        isTripleEnabled = true;
        StartCoroutine(TripleShotRoutine());

    }
    IEnumerator TripleShotRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        isTripleEnabled = false;
    }

    public void IncreaseSpeed()
    {
        _speed = 10f;
        StartCoroutine(IncreaseSpeedroutine());

    }
    IEnumerator IncreaseSpeedroutine()
    {
        yield return new WaitForSeconds(3.0f);
        _speed = 3.5f;
    }

    public void ShieldActivate()
    {
        _shieldActive = true;
        _shieldVisualizer.SetActive(true);
    }


    public void AddScore(int points)
    {
        _score += points;
        _uiManager.SetScore(_score);
    }
}
