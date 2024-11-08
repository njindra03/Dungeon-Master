using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // When the player touches the hatch tilemap, load the next scene randomly but not the current scene and never the spawnroom
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            while (nextSceneIndex == sceneIndex || nextSceneIndex == 0)
            {
                nextSceneIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    //When the player presses the tab key, load the shop menu scene
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("ShopMenu");
        }
    }
}