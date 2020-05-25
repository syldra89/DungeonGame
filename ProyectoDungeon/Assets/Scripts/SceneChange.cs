using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string scene;
    public Vector3 playerPosition;
    public SOLocation playerLocationMemory;
    public GameObject fadeEffect;

    private void Awake()
    {
        GameObject effect = Instantiate(fadeEffect, Vector3.zero, Quaternion.identity);
        Destroy(effect, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) {
            playerLocationMemory.initialPosition = playerPosition;
            SceneManager.LoadScene(scene);
        }
    }
}
