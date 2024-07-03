using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotionManager : MonoBehaviour
{
    public static int Potioncount = 3;
    public static PotionManager instance;
    public Text text;
    public Text potionzero;
    public GameObject torqueUI;
    //public Text PotionTalk;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
            
    }
    public void Update()
    {
        text.text = "" + Potioncount;
    }
    public void UsePotion()
    {
        if (Potioncount <= 0)
        {
            StartCoroutine(Potionlack());
        }
        
        else
        {
            Potioncount -= 1;
            PlayerContro.instance.Postion(30);
        }   
    }
    public void PotionRe()
    {
        Potioncount += 1;
    }
    IEnumerator Potionlack ()
    {
        // Display the UI element
        torqueUI.SetActive(true);

        potionzero.text = "포션이 부족해";
        // Add torque effect (assuming you have a TorqueEffect script attached to the UI element)
        //PotionTalk torqueEffect = torqueUI.GetComponent<PotionTalk>();        

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Hide the UI element after 1 second
        torqueUI.SetActive(false);
    }
}
