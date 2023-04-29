using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoleManager : MonoBehaviour
{
    public NavMeshAgent _hole;
    public Transform _finishLine;
    void Start()
    {
        _hole = transform.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        _hole.SetDestination(_finishLine.position);
    }
}