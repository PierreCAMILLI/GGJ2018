using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerPlane : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;

        if (go == Devil.Instance.ControlledCharacter.gameObject)
        {
            GameManager.Instance.ResetScene();
        }
    }
}
