using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem crachEffect;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground") {
            crachEffect.Play();
            Invoke("ReloadScene", delayTime);
        }
   }


    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
