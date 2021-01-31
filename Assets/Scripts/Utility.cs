using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility
{
    public static float MinimumDistance(GameObject a, List<GameObject> points)
    {
        float distance = float.PositiveInfinity;
        foreach (GameObject b in points)
        {
            float current_distance = Vector3.Distance(
                a.transform.position, 
                b.transform.position);
            
            if (current_distance < distance)
            {
                distance = current_distance;
            }
        }
        
        return Mathf.Round(distance);
    }
}
