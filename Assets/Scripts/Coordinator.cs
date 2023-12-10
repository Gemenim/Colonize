using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private Base _base;
    private CreatorResource _creatorResource;

    private void Start()
    {
        _base = GetComponent<Base>();
        _creatorResource = GameObject.FindAnyObjectByType<Terrain>().GetComponentInChildren<CreatorResource>();
        StartCoroutine(Coordinate());
    }

    private IEnumerator Coordinate()
    {
        while (true)
        {
            if (_base.IsFlag && _base.CoutnResources == _base.PriceBase)
            {
                foreach (Collector collector in _base.Collectors)
                {
                    if (collector.IsFree)
                    {
                        collector.TransferResources(_base.PriceBase);
                        collector.TakeTarget(_base.targetFlag.transform.position);
                        break;
                    }
                }
            }
            else
            {
                foreach (Collector collector in _base.Collectors)
                {
                    if (collector.IsFree)
                    {
                        Resources resources = _creatorResource.GetResource();
                        if (resources != null)
                            collector.TakeTarget(resources.transform.position);
                    }
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
