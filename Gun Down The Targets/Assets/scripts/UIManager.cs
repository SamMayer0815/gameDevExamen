using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text enemyKilledText;
    [SerializeField]
    private Text civilianKilledText;

    public void enemyHit(int count)
    {
        //update text if enemy hit
        enemyKilledText.text = "Enemies killed : " + count;
    }

    public void civilianHit(int count)
    {
        //update text if civilian hit
        civilianKilledText.text = "Civilians killed : " + count;
    }
}
