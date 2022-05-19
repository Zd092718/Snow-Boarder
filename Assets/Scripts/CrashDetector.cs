using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = .5f;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            deathParticles.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delayTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);

    }


}
