using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    public float enemySpeed;
    public float stopValue;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        //EnemyFollow
        if(Vector2.Distance(transform.position, player.transform.position) > stopValue)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);

        }
    }
}
