using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4.0f;
    private Player _player;
    private Animator _anim;
    private AudioSource _explosionSound;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _anim = GetComponent<Animator>();
        _explosionSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -4.2)
        {
            float RandomX = Random.Range(-5.0f, 5.0f);
            transform.position = new Vector3(RandomX, 4.2f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            player.Damage();

            _anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            _explosionSound.Play();
            Destroy(this.gameObject, 2f);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //add 10 points
            _player.AddScore(10);

            _anim.SetTrigger("OnEnemyDeath");
            speed = 0;

            _explosionSound.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject,2f);
        }
    }
    
}
