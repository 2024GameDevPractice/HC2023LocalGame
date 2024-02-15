using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    float timer;
    protected int use_Time;
    protected string skillName;

    private void OnEnable()
    {
        Init();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > use_Time )
        {
                Play();

        }
    }

    public abstract void Init();
    public abstract void Play();
}
