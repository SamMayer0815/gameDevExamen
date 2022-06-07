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
    private Scene scene;
    private string currentScene;
    private int curTime;
    private float startTime;
    private int startTimeInt;
    private float time;
    public Button button;
    public cameraMovement cam;
    public Rigidbody rigidbody;

    public GameObject menu;
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
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = gameObjects.Length;
        scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("player");
        shootScript playerScript = Player.GetComponent<shootScript>();
        if (enemyCount == playerScript.enemiesKilled && !hasWon)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            var mousePos = Input.mousePosition;
            mousePos.x -= Screen.width / 2;
            mousePos.y -= Screen.height / 2;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            cam.enabled = false;
            time = Time.time;
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
        if(currentScene == "level0")
        {
            SceneManager.LoadScene("level1");
        }
        if (currentScene == "level1")
        {
            SceneManager.LoadScene("Mainmenu");
        }
    }
}
