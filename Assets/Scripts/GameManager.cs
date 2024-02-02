using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject endScreen, bird;
    [SerializeField] PipeSpawn pipeSpawnScript;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixer audioMute;
    [SerializeField] Image soundComponent; // Reference to the Image component
    [SerializeField] Sprite soundOn, soundOff; // Reference to the new sprite/image you want to assign

    public void Mute() {
        float value;
        bool result = audioMute.GetFloat("masterVolume", out value);
        if(result) {
            if(value>-80f) {
                soundComponent.sprite = soundOff;
                audioMute.SetFloat("masterVolume", -80f);
            }
            else {
                soundComponent.sprite = soundOn;
                audioMute.SetFloat("masterVolume", 0f);
            }
        }
    }
    public void GameOver() {
        endScreen.SetActive(true);
        bird.SetActive(false);
        pipeSpawnScript.enabled = false;
        audioSource.Stop();

        PipeMove[] pipeMoveScripts = FindObjectsOfType<PipeMove>();
        foreach(PipeMove eachPipeScript in pipeMoveScripts) {
            eachPipeScript.enabled = false;
        }
    }

    public void Start() {
        if(SceneManager.GetActiveScene().name == "MainMenu") {
            float value;
            bool result = audioMute.GetFloat("masterVolume", out value);
            if(result) {
                if(value>-80f) {
                    soundComponent.sprite = soundOn;
                }
                else {
                    soundComponent.sprite = soundOff;
                }
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Restart() {
        SceneManager.LoadScene("Game");
    }

    public void Quit() {
        Application.Quit();
    }

    public void Menu() {
        SceneManager.LoadScene("MainMenu");
    }
}
