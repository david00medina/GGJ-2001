using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    void Update()
    {
        UpdateDistance(GameManager.Distance);
    }

    void UpdateDistance(float distance)
    {
        displayText.text = distance.ToString() + " m";
    }
}
