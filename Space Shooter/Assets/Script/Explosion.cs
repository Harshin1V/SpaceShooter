using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip _explosionSoundClip;
    private AudioSource _explosionSound;
    void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
        Destroy(this.gameObject, 3f);
        if(_explosionSound == null)
        {
            Debug.LogError("Explosion Sound not found");
        }
        else
        {
            _explosionSound.clip = _explosionSoundClip;
        }
        _explosionSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
