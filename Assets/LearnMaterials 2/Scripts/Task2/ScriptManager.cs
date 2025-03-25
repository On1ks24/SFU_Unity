using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public List<SampleScript> scripts = new List<SampleScript>();

    public void ExecuteAll()
    {
        foreach (var script in scripts)
        {
            script.Use();
        }
    }
}
