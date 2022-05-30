using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
    private GameObject gameObjects;
    private int enemyCount;
    private shootScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCount = gameObjects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("player");
        shootScript playerScript = Player.GetComponent<shootScript>();
        if (enemyCount == playerScript.enemiesKilled)
        {
            Debug.Log("Win");
        }
    }
}
