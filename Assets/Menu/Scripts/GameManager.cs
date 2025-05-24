using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            FindPlayer();
        }
    }

    

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    void FindPlayer()
    {
        void Update()
            {
                player = GameObject.FindGameObjectWithTag("Player");
                Debug.Log("Player");
                if (player == null)
                {
                    SceneManager.LoadScene(0);
                }  
            }
          
    }
    
}
