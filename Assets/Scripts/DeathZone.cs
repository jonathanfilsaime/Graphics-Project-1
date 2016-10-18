using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Debug.Log("enter");
    }

    void OnTriggerStay(Collider other) {
        Debug.Log("stay");
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("exit");
    }
}
