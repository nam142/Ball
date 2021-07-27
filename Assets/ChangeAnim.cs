using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ChangeAnim : MonoBehaviour
{
    public SkeletonAnimation ska;

    [SpineAnimation]
    public string animIdle, animRun;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            PlayAninmation(animRun);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAninmation(animIdle);
        }
    }
    public void PlayAninmation(string _strAnim)
    {
        ska.AnimationState.SetAnimation(0, _strAnim, true);

    }
}
