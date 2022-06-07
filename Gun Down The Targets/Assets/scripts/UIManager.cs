using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("text fields")]
    [SerializeField]
    private Text enemyKilledText;
    [SerializeField]
    private Text civilianKilledText;
    [SerializeField]
    private Text curAmmoText;

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

    public void currentAmmo(int count)
    {
        //update text to current ammo
        curAmmoText.text = "" + count;
    }
}
