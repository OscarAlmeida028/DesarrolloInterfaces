using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSource;
    public AudioSource effectsSource;

    public AudioClip clickSound;
    public AudioClip backgroundMusic;

    public Slider musicSlider;
    public Slider effectsSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);

        // Inicializar los volúmenes de acuerdo a los sliders
        musicSource.volume = musicSlider.value;
        effectsSource.volume = effectsSlider.value;
    }

    public void PlayClickSound()
    {
        effectsSource.PlayOneShot(clickSound);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetEffectsVolume(float volume)
    {
        effectsSource.volume = volume;
    }
}
