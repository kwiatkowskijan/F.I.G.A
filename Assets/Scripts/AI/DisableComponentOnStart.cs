using UnityEngine;
using UnityEngine.AI;

public class DisableComponentOnStart : MonoBehaviour
{
    void Start()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false;
        }
        else
        {
            Debug.LogWarning("NavMeshAgent nie zosta� znaleziony na tym obiekcie.");
        }
    }
}
