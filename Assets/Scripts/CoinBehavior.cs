using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour 
{
	int i = 0;
	public WorldController wc;
	public void OnTriggerEnter(Collider other)
	{
		UIController wc = GameObject.FindObjectOfType(typeof(UIController)) as UIController;
		i++;
		Debug.Log ("value of i: " + i);
		wc.score += i;
		Destroy (this.gameObject);
	}
}
