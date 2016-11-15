using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {
	[HideInInspector]
	public Vector3 flipAxis;
	public int limit;

	GameObject block;
	GameObject coins;

	private Vector3[] blockArrayBottom = new Vector3[]
	{
		new Vector3(1,0),
		new Vector3(2,0),
		new Vector3(3,0),
		new Vector3(4,0),
		new Vector3(5,0),
		new Vector3(6,1),
		new Vector3(7,1),
		new Vector3(8,1),
		new Vector3(9,1),
		new Vector3(10,1),
		new Vector3(-11,2, 100),
		new Vector3(-12,2, 100),
		new Vector3(-13,2, 100),
		new Vector3(-14,2, 100),
		new Vector3(-15,2, 100),
		new Vector3(16,3),
		new Vector3(17,3),
		new Vector3(18,3),
		new Vector3(19,3),
		new Vector3(20,3),
		new Vector3(21,4),
		new Vector3(22,4),
		new Vector3(23,4),
		new Vector3(24,4),
		new Vector3(25,4),
		new Vector3(26,0),
		new Vector3(27,0),
		new Vector3(28,0),
		new Vector3(29,0),
		new Vector3(30,0),
		new Vector3(31,1),
		new Vector3(32,1),
		new Vector3(33,1),
		new Vector3(34,1),
		new Vector3(35,1),
		new Vector3(36,2),
		new Vector3(37,2),
		new Vector3(38,2),
		new Vector3(39,2),
		new Vector3(40,2),
		new Vector3(41,3),
		new Vector3(42,3),
		new Vector3(43,3),
		new Vector3(44,3),
		new Vector3(45,3),
		new Vector3(46,2),
		new Vector3(47,2),
		new Vector3(48,2),
		new Vector3(49,2),
		new Vector3(50,2),
		new Vector3(51,1),
		new Vector3(52,1),
		new Vector3(53,1),
		new Vector3(54,1),
		new Vector3(55,1),
		new Vector3(56,-2),
		new Vector3(57,-2),
		new Vector3(58,-2),
		new Vector3(59,-2),
		new Vector3(60,-2),
		new Vector3(61,-1),
		new Vector3(62,-1),
		new Vector3(63,-1),
		new Vector3(64,-1),
		new Vector3(65,-1),
		new Vector3(66,-2),
		new Vector3(67,-2),
		new Vector3(68,-2),
		new Vector3(69,-2),
		new Vector3(70,-2),

	};

	private Vector3[] blockArrayTop = new Vector3[]
	{
		new Vector3(1,0+4),
		new Vector3(2,0+4),
		new Vector3(3,0+4),
		new Vector3(4,0+4),
		new Vector3(5,0+4),
		new Vector3(6,1+4),
		new Vector3(7,1+4),
		new Vector3(8,1+4),
		new Vector3(9,1+4),
		new Vector3(10,1+4),
		new Vector3(11,2+4),
		new Vector3(12,2+4),
		new Vector3(13,2+4),
		new Vector3(14,2+4),
		new Vector3(15,2+4),
		new Vector3(-16,3+4,100),
		new Vector3(-17,3+4,100),
		new Vector3(-18,3+4,100),
		new Vector3(-19,3+4,100),
		new Vector3(-20,3+4,100),
		new Vector3(21,4+4),
		new Vector3(22,4+4),
		new Vector3(23,4+4),
		new Vector3(24,4+4),
		new Vector3(25,4+4),
		new Vector3(-26,10,100),
		new Vector3(-27,10,100),
		new Vector3(-28,10,100),
		new Vector3(-29,10,100),
		new Vector3(-30,10,100),
		new Vector3(31,1+4),
		new Vector3(32,1+4),
		new Vector3(33,1+4),
		new Vector3(34,1+4),
		new Vector3(35,1+4),
		new Vector3(36,2+4),
		new Vector3(37,2+4),
		new Vector3(38,2+4),
		new Vector3(39,2+4),
		new Vector3(40,2+4),
		new Vector3(41,3+4),
		new Vector3(42,3+4),
		new Vector3(43,3+4),
		new Vector3(44,3+4),
		new Vector3(45,3+4),
		new Vector3(46,2+4),
		new Vector3(47,2+4),
		new Vector3(48,2+4),
		new Vector3(49,2+4),
		new Vector3(50,2+4),
		new Vector3(51,1+4),
		new Vector3(52,1+4),
		new Vector3(53,1+4),
		new Vector3(54,1+4),
		new Vector3(55,1+4),
		new Vector3(56,7),
		new Vector3(57,7),
		new Vector3(58,7),
		new Vector3(59,7),
		new Vector3(60,7),
		new Vector3(61,4-1),
		new Vector3(62,4-1),
		new Vector3(63,4-1),
		new Vector3(64,4-1),
		new Vector3(65,4-1),
		new Vector3(66,4-2),
		new Vector3(67,4-2),
		new Vector3(68,4-2),
		new Vector3(69,4-2),
		new Vector3(70,4-2),


	};



	// Use this for initialization
	void Start () 
	{
		block = GameObject.CreatePrimitive (PrimitiveType.Cube);
		coins = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		coins.AddComponent<CoinBehavior>();
		coins.GetComponent<MeshRenderer> ().material.color = Color.yellow;
		coins.GetComponent<CapsuleCollider> ().isTrigger = true; 

		for (int i = 0; i < 10; i++) 
		{
			foreach (Vector3 blocks in blockArrayBottom) 
			{
				place (blocks, i);
				placeCoins (blocks, i);
			}

			foreach (Vector3 blocks in blockArrayTop) 
			{
				place (blocks, i);
			}
		}

		Destroy(block);
		Destroy(coins);
	}

	// Update is called once per frame
	void Update () {

	}

	public void place(Vector3 blocks, int i)
	{
		Debug.Log ("placing block");
		if(blocks.z == -1)
		{
			Debug.Log ("empty block");
			return;
		}

		blocks.x += i * 71;
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

	public void placeCoins(Vector3 blocks, int i)
	{
		if (blocks.x % 5 == 0) 
		{
			GameObject goCoins = Instantiate(coins);
			blocks.x += i * 71;
			goCoins.transform.position = new Vector3(blocks.x,blocks.y+2,0.25f);
			goCoins.transform.position = new Vector3(blocks.x,blocks.y+2,0.25f);
			goCoins.transform.localScale = new Vector3 (1f, .1f, 1f);
			goCoins.transform.eulerAngles = new Vector3 (90, 45, 0);
			goCoins.transform.SetParent(this.transform);
		} 
		else 
		{
			return;
		}
		
	}


}