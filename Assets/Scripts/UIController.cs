using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public Text scoreText;
    public Text livesText;
    public Text speedText;
	public GameObject gameOverPanel;
	public Text gameOverText;

    private int score;
    private float speed;
	public int scene; //make better
	public Text text; //make better

	private AsyncOperation async;
 	// Use this for initialization

	void awake()
	{
		gameOverPanel.SetActive (false);
	}

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

		if (GameObject.Find ("Player").GetComponent<PlayerControl> ().moveDirection.y > 30 ||
		    GameObject.Find ("Player").GetComponent<PlayerControl> ().moveDirection.y < -30) {
			StartCoroutine(LoadNewScene());
		}
	}

	IEnumerator LoadNewScene()
	{
		async = SceneManager.LoadSceneAsync(scene);
		yield return null; //loads when done
	}
}
