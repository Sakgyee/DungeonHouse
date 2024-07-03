using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestText : MonoBehaviour
{
    public QuestManager questmanager;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = (questmanager.CheckQuest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
