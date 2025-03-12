using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleManager : MonoBehaviour
{
    [SerializeField] private List<SampleScript> sampleScripts;

    public void ActivateAll()
    {
        foreach (var script in sampleScripts)
        {
            script.Use();
        }
    }
}
