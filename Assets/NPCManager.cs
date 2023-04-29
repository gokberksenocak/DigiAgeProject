using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class NPCManager : MonoBehaviour
{
    public PlayerManager _playerManager;
    public RaceOrder _raceOrderScript;
    public float _agentSpeed;
    public float _agentAcceleration;
    private NavMeshAgent _agent;
    private Animator _npcAnimator;
    public int index;
    private void Start()
    {
        _npcAnimator = transform.GetComponent<Animator>();
        _npcAnimator.SetBool("isRunning", true);
        _agent = transform.GetComponent<NavMeshAgent>();
        _agentSpeed = Random.Range(4f, 6f);
        _agentAcceleration = Random.Range(11f, 15f);
        _agent.speed = _agentSpeed;
        _agent.acceleration = _agentAcceleration;
    }
    void Update()
    {
        _agent.SetDestination(_raceOrderScript._finishLine.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            index++;
            _raceOrderScript._currentCheckPoint = _playerManager.orderedCube[index];
        }
    }
}