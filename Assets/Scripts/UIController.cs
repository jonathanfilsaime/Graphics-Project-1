using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text scoreText;
    public Text livesText;
    public Text speedText;

    private int score;
    private float speed;
 	// Use this for initialization
	void Start () {
        score = 0;
        speed = GameObject.Find("Player").GetComponent<PlayerControl>().speed;
    }
	
	// Update is called once per frame
	void Update () {
        score += (int)(100*Time.deltaTime);
        scoreText.text = "Score: " + score;

        speed = GameObject.Find("Player").GetComponent<PlayerControl>().speed;
        speedText.text = "Speed: " + speed;
	}
}
