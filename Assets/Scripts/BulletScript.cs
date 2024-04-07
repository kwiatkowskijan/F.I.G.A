using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BulletScript : MonoBehaviour
{
    private GameBehaviour game;

    private void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            game.health -= 5;
        }
    }
}
