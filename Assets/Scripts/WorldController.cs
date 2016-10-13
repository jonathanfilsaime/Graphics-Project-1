using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {
    [HideInInspector]
    public Vector3 flipAxis;

    public int limit;
   
    private GameObject root;

	// Use this for initialization
	void Start () {
        flipAxis = Vector3.zero;

        // what everything is
        GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // parent
        root = Instantiate(block);
        root.transform.position = new Vector3(0, -2, 0);
        root.transform.rotation = Quaternion.identity;
        root.transform.SetParent(this.transform);
        
        for (int i = 1; i < limit; i++)
        {
            if (i % 10 == 0 || i % 10 == 1) {
                continue;
            }
            GameObject go = Instantiate(block);
            go.transform.position = new Vector3(i * 1f, -2, 0);
            go.transform.rotation = Quaternion.identity;
            go.transform.SetParent(root.transform);

            GameObject go1 = Instantiate(block);
            go1.transform.position = new Vector3(i * 1f, 2, 0);
            go1.transform.rotation = Quaternion.identity;
            go1.transform.SetParent(root.transform);
            
            if (i % 2 != 0)
            {
                go.GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0);
            }
        }

        Destroy(block);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public void Flip() {
    //    this.transform.RotateAround(Vector3.zero, Vector3.right, 180);
    //}

    //public float GetOffset(GameObject go) {
    //    return root.transform.position.y - go.transform.position.y;
    //}

    //public Vector3 GetLowerPosition() {
    //    return root.transform.position;
    //}
}
