using UnityEngine;
using System.Collections;

public class SpeedZoneBehavior : MonoBehaviour {
    public void OnTriggerExit() {
        PlayerControl pc = GameObject.FindObjectOfType(typeof(PlayerControl)) as PlayerControl;
        pc.speed += 2;
    }
}
