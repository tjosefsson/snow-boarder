using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem crachEffect;
    [SerializeField] AudioClip crashSFX;
    Boolean hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !hasCrashed) {
            GetComponent<PlayerController>().DisableControls();
            crachEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayTime);
            hasCrashed = true;
        }
   }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
