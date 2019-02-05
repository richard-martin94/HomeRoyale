using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalReached : MonoBehaviour {

    public GameObject goalMenuUI;
    public GameObject transport;
    public GameObject goals;

    string playA = "Player A has won!";
    string playB = "Player B has won!";
    public Text winText;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered the trigger");
        if (other.GetComponent<Rigidbody>().gameObject == transport)
        {
            Debug.Log(goals.ToString());
            if(goals.name == "aGoal")
            {
                winText.text = playA;
            }
            else
            {
                winText.text = playB;
            }
            goalMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is within trigger");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        goalMenuUI.SetActive(false);
    }
}
