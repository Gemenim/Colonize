using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] Base _base;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Collector>(out Collector collector))
        {
            if (collector.Resource == _base.PriceBase)
            {
                collector.TransferResources(-_base.PriceBase);
                collector.TakePositionBase(Instantiate(_base, transform.position, Quaternion.identity).transform.position);
                collector.TransferResource();
                Remove();
            }
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
