using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (other.gameObject.tag == "player")
        {
            // Placeholder "Game Over" to reset scene
            SceneManager.LoadScene(scene.name);
            Debug.Log("Dead");
        }
    }
}
