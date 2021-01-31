using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsDoor : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SceneLoader()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke("SceneLoader", 1f);
            Debug.Log("Start Credits");
        }
    }
}
