using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Base))]
public class BotSpawner : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private int _countCollectors = 0;
    [SerializeField] private int _limitBots = 5;

    private Base _base;

    private void Awake()
    {
        _base = GetComponent<Base>();

        if (_countCollectors < 0)
            _countCollectors = 0;

        if (_limitBots <= 0)
            _limitBots = 1;

        for (int i = 0; i < _countCollectors; i++)
            _base.TakeCollector(Instantiate(_collector, transform.position, Quaternion.identity));
    }

    public void CreatNewBot()
    {
        if (_base.Collectors.Count < _limitBots)
            _base.TakeCollector(Instantiate(_collector, transform.position, Quaternion.identity));
    }
}