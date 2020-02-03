using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrollScript : MonoBehaviour
{
    
    public GameObject player;
    public GameObject spellScript;
    private void OnCollisionEnter(Collision other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (other.gameObject.tag == "player")
        {
            //spellScript = player.transform.Find("spells").GetComponent<Spell>().GenerateSpell();
        }
    }
}