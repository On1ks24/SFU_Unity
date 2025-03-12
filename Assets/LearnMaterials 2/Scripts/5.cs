using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : SampleScript
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int count = 5;
    [SerializeField] private float step = 2f;

    public override void Use()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, transform.position + Vector3.right * step * i, Quaternion.identity);
        }
    }
}
