using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "ScriptableObject/EnemyConfiguration")]
public class EnemyScriptableObject : MonoBehaviour
{
    public int Health = 100;
    public float AIUpdateInterval = 0.1f;

    public float Acceleration = 8;
    public float angularSpeed = 120;

    public int AreaMask = -1;
    public int avoidancePriority = 50;
    public float baseOffset = 0;
    public float Height = 2f;
    public ObstacleAvoidanceType ObstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    public float radius = 0.5f;
    public float Speed = 3f;
    public float stoppingDistance = 0.5f;
}
