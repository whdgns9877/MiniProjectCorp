using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProcess
{
    Player player { get { return GameManager.Instance.player; } }
    Background ground { get { return GameManager.Instance.ground; } }

    void Do()
    {

    }
}
