using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleItem : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
