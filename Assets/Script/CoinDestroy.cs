using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinDestroy : MonoBehaviour
{
    private Transform building;
    private int CoinCount = 0;
    // public TextMeshProUGUI ScoreValue;
    private ScoreManager SM;
    private AudioManager AM;
   
    private void Awake()
    {
       SM = FindObjectOfType<ScoreManager>();
    }
    public void SetBuilding(SpownBuilding spown_Building)
    {
        this.building = building;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            SM.UpdateScore();
            Destroy(gameObject);
            AM.PlayAudio();
        }
    }
}