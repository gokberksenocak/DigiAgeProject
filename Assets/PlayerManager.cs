using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public Ease ease;
    public FloatingJoystick floatingJoystick;
    public GameObject backGround;
    public float speed;
    public Animator playerAnim;
    public RaceOrder _raceOrderScript;
    //public Transform _jumpEndPoint;
    //public bool _isTurnRight, _isTurnLeft,_isForward;
    public List<Transform> orderedCube;
    public int index;
    public Transform _jumpPoint;

    void Update()
    {
        if (backGround.activeInHierarchy)
        {
            playerAnim.SetBool("isRunning", true);
            playerAnim.SetBool("isStop", false);
            float horizontal = floatingJoystick.Horizontal;
            float vertical = floatingJoystick.Vertical;

            // transform.rotation += Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, horizontal, 0)), 3f * Time.deltaTime);
            float x = transform.rotation.eulerAngles.y;
            // x += horizontal / 2;

            // transform.rotation = Quaternion.Euler(0, Mathf.Lerp(x, x + horizontal / 2f, 60f), 0);

            transform.rotation = Quaternion.Euler(0, x + (horizontal * 120f * Time.deltaTime), 0f);

            transform.position += transform.forward * vertical * speed * Time.deltaTime;

        }
        else
        {
            playerAnim.SetBool("isRunning", false);
            playerAnim.SetBool("isStop", true);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.DOJump(new Vector3(transform.position.x, transform.position.y , transform.position.z), 1.5f, 1, .5f);
            transform.DOMoveY(transform.position.y + 1.5f, 0.3f).SetLoops(2, LoopType.Yoyo);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NavMeshAgent otherAgent = other.GetComponent<NavMeshAgent>();
            otherAgent.speed /= 2;
            otherAgent.acceleration /= 2;
        }


        if (other.CompareTag("CheckPoint") && index < orderedCube.Count-1)
        {
            index++;
            _raceOrderScript._currentCheckPoint = orderedCube[index];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            NavMeshAgent otherAgent = other.GetComponent<NavMeshAgent>();
            otherAgent.speed *= 2;
            otherAgent.acceleration *= 2;
        }
    }
}