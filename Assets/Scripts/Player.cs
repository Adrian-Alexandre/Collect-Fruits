using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 10f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.startGame == false) return;

        float x = Input.GetAxis("Horizontal");
        Vector3 vector = new Vector3(x, 0, 0);
        transform.Translate(vector * speed * Time.deltaTime);
        if (transform.position.x < -8.5f)
            transform.position = new Vector3(-8.5f, -3.5f, 0f);
        if (transform.position.x > 8.5f)
            transform.position = new Vector3(8.5f, -3.5f, 0f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fruit")
        {
            gameManager.score += 10;
        }
        if (other.tag == "Damage")
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
        Destroy(other.gameObject);
    }
}
