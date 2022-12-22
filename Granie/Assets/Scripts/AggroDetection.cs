using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AggroDetection : MonoBehaviour
{
    [SerializeField]
    private AudioSource spotted;

    public event Action<Transform> OnAggro = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            spotted.Play();
            OnAggro(player.transform);
            Debug.Log("Aggrod");
        }
    }
}
