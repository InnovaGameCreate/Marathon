using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoExplain : MonoBehaviour
{
    [SerializeField] GameObject explain;
    public void Onclick()
    {
        explain.SetActive(true);
    }
}
