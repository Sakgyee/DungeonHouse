using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Health, EnemyHealth, EnemyHealth1 }
    public InfoType type;

    Slider mySlider;

    public int uniqueID;
    void Awake()
    {
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        if (ScanPlayer.enemyHealth.ContainsKey(uniqueID) && ScanPlayer.enemyMaxHealth.ContainsKey(uniqueID))
        {
            int enemyHealth = ScanPlayer.enemyHealth[uniqueID];
            int maxHealth = ScanPlayer.enemyMaxHealth[uniqueID];
            mySlider.value = (float)enemyHealth / maxHealth;
        }
        switch (type)
        {
            case InfoType.Health:
                float curHealth = PlayerContro.instance.health;
                float maxHealth = PlayerContro.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;

        }
    }
}
