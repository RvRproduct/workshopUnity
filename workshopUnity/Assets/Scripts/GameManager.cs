using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // IF YOU WANT TO KEEP THESE PRIVATE AND WANT ACCESS TO THEM
    // YOU MUST SETUP A GETTER AND SETTER FOR EACH
    [SerializeField] public List<GameObject> redCollectibles;
    [SerializeField] public List<GameObject> blueCollectibles;
    // IF YOU WANT TO KEEP THESE PRIVATE AND WANT ACCESS TO THEM
    // YOU MUST SETUP A GETTER AND SETTER FOR EACH
    [SerializeField] public Door door;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Old Unity input System
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("MainLevel");
        }
    }
}
