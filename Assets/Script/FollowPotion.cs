using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowPotion : MonoBehaviour
{
    RectTransform re;   

    public Transform targetToFollow;
    void Awake()
    {
        re = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if (targetToFollow != null)
        {
            re.position = Camera.main.WorldToScreenPoint(targetToFollow.position);
        }
        else
        {
            // Disable or hide the health bar when the Enemy1 object is missing
            gameObject.SetActive(false);
        }
    }
}
