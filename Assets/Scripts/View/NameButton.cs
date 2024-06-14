using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameButton : MonoBehaviour
{
    public void OnClickChangeName()
    { 
        GameLogicManager.Inst.RequestRandomName();
    }
}
