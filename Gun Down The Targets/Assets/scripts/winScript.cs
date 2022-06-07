using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winScript : MonoBehaviour
{
    private bool hasWon = false;
    private GameObject gameObjects;
    private int enemyCount;
    private shootScript playerScript;

    [Header("scene")]
    private Scene scene;
    private string currentScene;

    [Header("Time")]
    private int curTime;
    private float startTime;
    private int startTimeInt;
    private float time;

    [Header("public objects")]
    public Button button;
    public cameraMovement cam;
    public Rigidbody rigidbody;
    public GameObject menu;

    [Header("text fields")]
    [SerializeField]
    private Text rawTime;
    [SerializeField]
    private Text extraTime;
    [SerializeField]
    private Text setTime;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(nextLevel);
        GameObject[] gameObjects;
        //counts how many enemies there are
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = gameObjects.Length;
        //gets current scene
        scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        //gets start time
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("player");
        shootScript playerScript = Player.GetComponent<shootScript>();
        //if killed all enemies and havent won yet
        if (enemyCount == playerScript.enemiesKilled && !hasWon)
        {
            //unlocks cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //centers mouse position
            var mousePos = Input.mousePosition;
            mousePos.x -= Screen.width / 2;
            mousePos.y -= Screen.height / 2;
            //disabled moving
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            //disables camera movement
            cam.enabled = false;
            //gets current time
            time = Time.time;
            //calculets all times
            startTimeInt = (int) startTime;
            curTime = (int) time;
            hasWon = true;
            menu.SetActive(true);
            rawTime.text = "Raw time = " + (curTime - startTimeInt);
            extraTime.text = "Extra time = " + (playerScript.civiliansKilled * 5) + " Seconds";
            setTime.text = "Final time = " + Mathf.Round(((curTime - startTimeInt) + (playerScript.civiliansKilled * 5)) * 1000) / 1000;  
        }

    }

    void nextLevel()
    {
        //manages the levels
        if(currentScene == "level0")
        {
            SceneManager.LoadScene("level1");
        }
        if (currentScene == "level1")
        {
            SceneManager.LoadScene("level2");
        }
        if (currentScene == "level2")
        {
            SceneManager.LoadScene("Mainmenu");
        }
    }
}
