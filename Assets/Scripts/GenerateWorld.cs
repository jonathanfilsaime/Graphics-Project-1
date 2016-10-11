using UnityEngine;
using System.Collections;

public class GenerateWorld : MonoBehaviour {
    public int limit;

    private GameObject root;

	// Use this for initialization
	void Start () {
        // what everything is
        GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // parent
        root = Instantiate(block);
        root.transform.position = new Vector3(0, 0, 0);
        root.transform.rotation = Quaternion.identity;

        for (int i = 1; i < limit; i++)
        {
            if(i % 10 == 0 || i % 10 == 1) {
                continue;
            }
            GameObject go = Instantiate(block);
            go.transform.position = new Vector3(i * 1f, 0, 0);
            go.transform.rotation = Quaternion.identity;
            go.transform.SetParent(root.transform);
            if(i % 2 != 0)
            {
                go.GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
