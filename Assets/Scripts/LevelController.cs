using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject Spawn_Point;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject Eagle;
    [SerializeField] private GameObject Play;
    [SerializeField] private GameObject TransitionPos;
    
    [SerializeField] private float TimerSpawn;
    private float TimerSpawnCount;
    private int Spawn_Chance;

    [SerializeField] private List<GameObject> Birds_1;
    [SerializeField] private List<GameObject> Birds_2;
    [SerializeField] private List<GameObject> Birds_3;
    [SerializeField] private List<GameObject> Birds_4;
    private GameObject newbird;

    public bool Started;
    void Start()
    {
        Started = false;
        TimerSpawnCount = TimerSpawn;
        Eagle.GetComponent<Rigidbody2D>().simulated = false;
    }
    void Update()
    {
        if (!Started) return;
        TimerSpawnCount -= Time.deltaTime;
        if (TimerSpawnCount<0)
        {
            TimerSpawnCount = TimerSpawn;
            SpawnRandomBird();
            DetectUselssBirds();
        }
        
    }

    public void StartGame()
    {
        Started = true;
        Play.GetComponent<RectTransform>().DOMove(TransitionPos.transform.position,1.2f);
        Eagle.GetComponent<Rigidbody2D>().simulated = true;
        
    }
    void DetectUselssBirds()
    {
        foreach (var bird in Birds_1)
        {
            if (bird.transform.position.x-Camera.transform.position.x<-20)
            {
                bird.SetActive(false);
            }
        }
        foreach (var bird in Birds_2)
        {
            if (bird.transform.position.x-Camera.transform.position.x<-20)
            {
                bird.SetActive(false);
            }
        }
        foreach (var bird in Birds_3)
        {
            if (bird.transform.position.x-Camera.transform.position.x<-20)
            {
                bird.SetActive(false);
            }
        }
        foreach (var bird in Birds_4)
        {
            if (bird.transform.position.x-Camera.transform.position.x<-20)
            {
                bird.SetActive(false);
            }
        }
    }
    void SpawnRandomBird()
    {
        Spawn_Chance = Random.Range(1, 5);
        switch (Spawn_Chance)
        {
            //Bird_Spawn_Chance_1
            case 1:
            {
                GameObject bird = FindInActiveBird(Birds_1);
                if (bird!=null)
                {
                    SetBirdPosition(bird);
                }
                return;
            }
            case 2:
            { GameObject bird = FindInActiveBird(Birds_2);
                if (bird!=null)
                {
                    SetBirdPosition(bird);
                }
                return;
            } case 3:
            {
                GameObject bird = FindInActiveBird(Birds_3);
                if (bird!=null)
                {
                    SetBirdPosition(bird);
                }
                return;
            }
            case 4:
            {
                GameObject bird = FindInActiveBird(Birds_4);
                if (bird!=null)
                {
                    SetBirdPosition(bird);
                }
                return;
            }
            
        }
    }

    GameObject FindInActiveBird(List<GameObject> Birds)
    {
        foreach (var bird in Birds)
        {
            if (!bird.gameObject.activeSelf)
            {
                return bird;
            }
        }
        return null;
    }

    void SetBirdPosition(GameObject bird)
    {

        float randomYValue = Random.Range(-3f, 4f);
        bird.transform.position =
            new Vector2(Spawn_Point.transform.position.x, Spawn_Point.transform.position.y + randomYValue);
        bird.SetActive(true);
    }
}
