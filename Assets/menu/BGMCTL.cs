using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMCTL : MonoBehaviour
{

    private void Awake()
    {
        int numBGM = FindObjectsOfType<BGMCTL>().Length;
        if (numBGM > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "game")
        {
            Destroy(gameObject);
        }
    }
}
