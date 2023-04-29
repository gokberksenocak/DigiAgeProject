using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceOrder : MonoBehaviour
{
    public TextMeshProUGUI _playerOrderText;
    public List<float> _distances;
    public Transform _currentCheckPoint;
    public Transform _finishLine;
    public Transform[] _racers;
    public float PlayerDist;
    private void Start()
    {
        InvokeRepeating(nameof(ShowOrder), .2f, .1f);
    }

    void LiveOrder()
    {
        for (int i = 0; i < _distances.Count; i++)
        {
            _distances[i] = Vector3.Distance(_racers[i].position, _currentCheckPoint.position);
        }
        _distances.Sort();
    }

    void ShowToPlayerOrder()
    {
        PlayerDist = Vector3.Distance(transform.position, _currentCheckPoint.position);
        if (PlayerDist == _distances[0])
        {
            _playerOrderText.text = "1st";
        }
        if (PlayerDist == _distances[1])
        {
            _playerOrderText.text = "2nd";
        }
        if (PlayerDist == _distances[2])
        {
            _playerOrderText.text = "3rd";
        }
        if (PlayerDist == _distances[3])
        {
            _playerOrderText.text = "4th";
        }
        if (PlayerDist == _distances[4])
        {
            _playerOrderText.text = "5th";
        }
    }

    void ShowOrder()
    {
        LiveOrder();
        ShowToPlayerOrder();
    }
}