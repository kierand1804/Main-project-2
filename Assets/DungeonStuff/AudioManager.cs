using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source ------------ ")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("------------ Audio Clip ------------ ")]
    public AudioClip background;
    public AudioClip shooting;
    public AudioClip damage;
    public AudioClip itemCollection;
    public AudioClip death;
    public AudioClip enemyDeath;
    public AudioClip fall;
    public AudioClip enemyDamage;
    public AudioManager audioManager;

     private void Awake()
      {
        DontDestroyOnLoad(gameObject);
      }
        private void Start()
        {
            musicSource.clip = background;
            musicSource.Play();
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            //Instantiate(audioManager);

        }

        public void PlaySFX(AudioClip clip)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
