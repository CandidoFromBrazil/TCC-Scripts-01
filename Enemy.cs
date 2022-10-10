using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            player.GetComponent<Player>().enemiesDefeat += 1;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Colliders/Hitbox")
        {
            life -= 1;
            print(life);
        }
        else if (collision.gameObject.tag == "Colliders/Hurtbox")
        {
            collision.GetComponentInParent<Player>().hp -= 10;
        }
    }
}
