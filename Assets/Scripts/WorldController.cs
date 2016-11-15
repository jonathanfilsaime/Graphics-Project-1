using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {
	[HideInInspector]
	public Vector3 flipAxis;
	public int limit;

	GameObject block;

	private Vector3[] blockArrayBottom = new Vector3[]
	{
		new Vector3(1,0),
		new Vector3(2,0),
		new Vector3(3,0),
		new Vector3(4,0),
		new Vector3(5,1),
		new Vector3(6,2),
		new Vector3(7,3),
		new Vector3(8,4),
		new Vector3(9,0,-1),
		new Vector3(10,0,-1),
		new Vector3(11,0,-1),
		new Vector3(12,4),
		new Vector3(13,3),
		new Vector3(14,2),
		new Vector3(15,2),
		new Vector3(15,2),
		new Vector3(16,1),
		new Vector3(17,0),
		new Vector3(18,-1),
		new Vector3(19,-2),
		new Vector3(20,-3),
		new Vector3(21,-3),
		new Vector3(22,-3),
		new Vector3(23,-3),
		new Vector3(24,0),
		new Vector3(25,0),
		new Vector3(26,0),
		new Vector3(27,0),

	};

	private Vector3[] blockArrayTop = new Vector3[]
	{
		new Vector3(1,4),
		new Vector3(2,4),
		new Vector3(3,4),
		new Vector3(4,8),
		new Vector3(5,8),
		new Vector3(6,8),
		new Vector3(7,8),
		new Vector3(8,8),
		new Vector3(9,8),
		new Vector3(10,8),
		new Vector3(11,8),
		new Vector3(12,8),
		new Vector3(13,8),
		new Vector3(14,8),
		new Vector3(15,8),
		new Vector3(15,8),
		new Vector3(16,7),
		new Vector3(17,6),
		new Vector3(18,4),
		new Vector3(19,2,-1),
		new Vector3(20,2,-1),
		new Vector3(21,2,-1),
		new Vector3(22,4),
		new Vector3(23,4),
		new Vector3(24,4),
		new Vector3(25,4),
		new Vector3(26,4),
		new Vector3(27,4),


	};



	// Use this for initialization
	void Start () 
	{
		block = GameObject.CreatePrimitive (PrimitiveType.Cube);
		// what everything is
		GameObject triggerZone = new GameObject("DeathZone");

		for (int i = 0; i < 10; i++) 
		{
			foreach (Vector3 blocks in blockArrayBottom) 
			{
				place (blocks, i);
			}

			foreach (Vector3 blocks in blockArrayTop) 
			{
				place (blocks, i);
			}
		}

		Destroy(block);
		Destroy(triggerZone);
	}

	// Update is called once per frame
	void Update () {

	}

	public void quit()
	{
		Application.Quit ();
	}

	public void place(Vector3 blocks, int i)
	{
		if(blocks.z == -1)
		{
			return;
		}

		blocks.x += i * 27;
		GameObject go = Instantiate(block);
		go.transform.position = blocks;
		go.transform.rotation = Quaternion.identity;
		go.transform.SetParent(this.transform);

		if (blocks.x % 2 != 0)
		{
			go.GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0);
			//	go1.GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0);
		}
	}


}