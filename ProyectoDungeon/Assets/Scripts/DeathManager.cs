using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    private bool isDead;
    public GameObject deathPanel;
    public Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            isDead = !isDead;
            if (isDead)
            {
                
                deathPanel.SetActive(true);

            }
            
        }
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void GetScore(int _gold) {
        goldText.text = "Gold: " +_gold;
    }
}
