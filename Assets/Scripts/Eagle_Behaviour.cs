using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Eagle_Behaviour : MonoBehaviour
{
    private int Score;

    [SerializeField]private TextMeshProUGUI Text_Score;
    [SerializeField]private TextMeshProUGUI Text_MaxScore;
    [SerializeField]private GameObject Object_Score;
    [SerializeField]private GameObject Transition_Score;
    [SerializeField] private GameObject Alarms;

    private WaitForSeconds RestartDelay = new WaitForSeconds(3);
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Text_MaxScore.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

    private void Update()
    {
        if (transform.position.y>=3.8f || transform.position.y<=-2.55f)
        {
            Alarms.SetActive(true);
        }
        else
        {
            Alarms.SetActive(false);
        }
    }
    IEnumerator RestartScene()
    {
        yield return RestartDelay;
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Lose When Entered To ground or trees
        if (col.gameObject.CompareTag("jungle"))
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Object_Score.GetComponent<RectTransform>().DOMove(Transition_Score.transform.position, 0.6f);
            StartCoroutine(RestartScene());
        }
        // Gain Score From Different Birds
        if (col.gameObject.CompareTag("Bird_1"))
        {
            if (!col.gameObject.GetComponent<Bird_1_Behaviour>().addedscore)
            {
                col.gameObject.GetComponent<Bird_1_Behaviour>().addedscore = true;
                Score += 10;
                UpdateScore();
                col.gameObject.SetActive(false);
            }
           
        }if (col.gameObject.CompareTag("Bird_2"))
        {
            if (!col.gameObject.GetComponent<Bird_2_Behaviour>().addedscore)
            {
                col.gameObject.GetComponent<Bird_2_Behaviour>().addedscore = true;
                Score += 20;UpdateScore();
                col.gameObject.SetActive(false);
            }
           
        }if (col.gameObject.CompareTag("Bird_3"))
        {
            if (!col.gameObject.GetComponent<Bird_3_Behaviour>().addedscore)
            {
                col.gameObject.GetComponent<Bird_3_Behaviour>().addedscore = true;
                Score += 30;UpdateScore();
                col.gameObject.SetActive(false);
            }
           
        }
        if (col.gameObject.CompareTag("Bird_4"))
        {
            if (!col.gameObject.GetComponent<Bird_4_Behaviour>().addedscore)
            {
                col.gameObject.GetComponent<Bird_4_Behaviour>().addedscore = true;
                Score += 40;UpdateScore();
                col.gameObject.SetActive(false);
            }
           
        }
    }

    void UpdateScore()
    {
        Text_Score.text = Score.ToString();
        if (Score>=PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore",Score);
        }
    }
}
