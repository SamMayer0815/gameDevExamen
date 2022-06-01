using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class startGame : MonoBehaviour
{
    
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(start);
    }

    // Update is called once per frame
    void start()
    {
        SceneManager.LoadScene("level0");
    }
}
