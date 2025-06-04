using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class ranom : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SceneManager.LoadScene();
        SayHello();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SayHello()
    {
        Debug.Log("Hello");
        SayBye();
    }

    void SayBye()
    {
        Debug.Log("Bye");
    }
}
