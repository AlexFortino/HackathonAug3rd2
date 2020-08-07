using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemyfollow : MonoBehaviour
{
    NavMeshAgent eAgent;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        eAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        eAgent.SetDestination(Player.transform.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            //end game
            //SceneManager.LoadScene("Menu Scene");
            Player.GetComponent<YouDiedMenu>().EndGame(false);
        }

    }
}
