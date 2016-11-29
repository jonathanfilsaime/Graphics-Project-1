using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public Text scoreText;

    public int score = 0;
    private float speed;
	public int scene; //make better
	public Text text; //make better

	private AsyncOperation async;
 	// Use this for initialization

	void Awake() {

	}

	void Start () {
        score = 0;
		scoreText.fontSize = 40;
		scoreText.fontStyle = FontStyle.Bold;
		scoreText.color = Color.red;
        speed = GameObject.Find("Player").GetComponent<PlayerControl>().speed;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}

	public void SetScore(int i)
	{
		score += i;
	}

	IEnumerator LoadNewScene()
	{
		async = SceneManager.LoadSceneAsync(scene);
		yield return null; //loads when done
	}
}
