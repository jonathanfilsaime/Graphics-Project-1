using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    private bool loading = false;
    public int scene; //make better
    public Text text; //make better

    private AsyncOperation async;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(loading == false)
        {
            loading = true;

            StartCoroutine(LoadNewScene());
        }
	}

    IEnumerator LoadNewScene()
    {
        async = SceneManager.LoadSceneAsync(scene);
        yield return null; //loads when done
    }

    void OnGUI()
    {

    }
}
