using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHealthbar : MonoBehaviour
{
    RectTransform rect;
    public Transform targetToFollow;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        if (targetToFollow != null)
        {
            rect.position = Camera.main.WorldToScreenPoint(targetToFollow.position);
        }
        else
        {
            // Disable or hide the health bar when the Enemy1 object is missing
            gameObject.SetActive(false);
        }
    }
}
