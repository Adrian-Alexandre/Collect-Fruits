using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItens : MonoBehaviour
{

    [SerializeField]
    private GameObject[] items;
    private GameManager gameManager;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("CreateObject", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateObject()
    {
        if(player != null && gameManager.startGame == true) 
        { 
            Instantiate(items[Random.Range(0,3)], new Vector3(Random.Range(-8.5f, 8.5f),10f,0), Quaternion.identity);
        }
        
    }
}
