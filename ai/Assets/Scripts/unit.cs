using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{

	public class unit : MonoBehaviour
	{
		SoldierStruct[] redUnits;
		SoldierStruct[] redUnits1;
		SoldierStruct[] blueUnits;
		float soldierDistance = 2f;
		float walkSpeed = 3f;
		float chargeSpeed = 6f;
		float chargeDistance = 16f;
		float attackDistance = 2f;

		// Use this for initialization
		void Start ()
		{
			redUnits = new SoldierStruct[21];
			redUnits1 = new SoldierStruct[21];
			blueUnits = new SoldierStruct[21];

			//AnimationClip _ac = Resources.Load<AnimationClip> ("attack");
			//_ac.wrapMode = WrapMode.Loop;

			//AnimationClip _acDie = Resources.Load<AnimationClip> ("die");
			//_acDie.wrapMode = WrapMode.Loop;

			//初始化红色部队
			Vector3 heroPos = new Vector3 (75f, 0.5f, 50f);
			redUnits [0].position = heroPos;
			redUnits [0].obj = Instantiate (Resources.Load ("Hero"), heroPos, Quaternion.identity) as GameObject;
			//redUnits [0].obj.AddComponent<Animation> ().AddClip (_ac, "attack");
			redUnits [0].obj.GetComponent<Renderer> ().material.color = Color.red;
			for (int i = 1; i <= 20; i++) {
				redUnits [i].position = GetSoldierPos (i, heroPos, false);
				redUnits [i].obj = Instantiate (Resources.Load ("Soldier"), redUnits [i].position, Quaternion.identity) as GameObject;
				//redUnits [i].obj.AddComponent<Animation> ().AddClip (_ac, "attack");
				redUnits [i].obj.GetComponent<Renderer> ().material.color = Color.red;
				redUnits [i].state = SoldierState.Idel;
			}

			heroPos = new Vector3 (75f, 0.5f, 100f);
			redUnits1 [0].position = heroPos;
			redUnits1 [0].obj = Instantiate (Resources.Load ("Hero"), heroPos, Quaternion.identity) as GameObject;
			//redUnits1 [0].obj.AddComponent<Animation> ().AddClip (_ac, "attack");
			redUnits1 [0].obj.GetComponent<Renderer> ().material.color = Color.red;
			for (int i = 1; i <= 20; i++) {
				redUnits1 [i].position = GetSoldierPos (i, heroPos, false);
				redUnits1 [i].obj = Instantiate (Resources.Load ("Soldier"), redUnits [i].position, Quaternion.identity) as GameObject;
				//redUnits1 [i].obj.AddComponent<Animation> ().AddClip (_ac, "attack");
				redUnits1 [i].obj.GetComponent<Renderer> ().material.color = Color.red;
				redUnits1 [i].state = SoldierState.Idel;
			}

			//初始化蓝色部队
			heroPos = new Vector3 (125f, 0.5f, 50f);
			blueUnits [0].position = heroPos;
			blueUnits [0].obj = Instantiate (Resources.Load ("Hero"), heroPos, Quaternion.identity) as GameObject;
			//blueUnits [0].obj.AddComponent<Animation> ().AddClip (_ac, "attack");
			blueUnits [0].obj.GetComponent<Renderer> ().material.color = Color.blue;
			for (int i = 1; i <= 20; i++) {
				blueUnits [i].position = GetSoldierPos (i, heroPos, true);
				blueUnits [i].obj = Instantiate (Resources.Load ("Soldier"), blueUnits [i].position, Quaternion.identity) as GameObject;
				//blueUnits [i].obj.AddComponent<Animation> ().AddClip (_ac, "attack");
				blueUnits [i].obj.GetComponent<Renderer> ().material.color = Color.blue;
				blueUnits [i].state = SoldierState.Idel;
			}
		}

		// Update is called once per frame
		void Update ()
		{
			for (int i = 0; i <= 20; i++) {
				switch (redUnits [i].state) {
				case SoldierState.Walk:
					if (null != redUnits [i].obj.transform) {
						redUnits [i].obj.transform.position += Vector3.right * walkSpeed * Time.deltaTime;
					}
					break;
				case SoldierState.Run:
					if (null != redUnits [i].obj.transform) {
						redUnits [i].obj.transform.position += Vector3.right * chargeSpeed * Time.deltaTime;
					}
					break;
				case SoldierState.Attack:
					redUnits [i].obj.GetComponent<Animation> ().Play ("attack");
					break;
				}

				switch (redUnits1 [i].state) {
				case SoldierState.Walk:
					if (null != redUnits1 [i].obj.transform) {
						redUnits1 [i].obj.transform.position += redUnits1 [0].direction * walkSpeed * Time.deltaTime;
					}
					break;
				case SoldierState.Run:
					if (null != redUnits1 [i].obj.transform) {
						redUnits1 [i].obj.transform.position += redUnits1 [0].direction * chargeSpeed * Time.deltaTime;
					}
					break;
				case SoldierState.Attack:
					redUnits1 [i].obj.GetComponent<Animation> ().Play ("attack");
					break;
				}

				switch (blueUnits [i].state) {
				case SoldierState.Walk:
					if (null != blueUnits [i].obj.transform) {
						blueUnits [i].obj.transform.position += Vector3.left * walkSpeed * Time.deltaTime;
					}
					break;
				case SoldierState.Run:
					if (null != blueUnits [i].obj.transform) {
						blueUnits [i].obj.transform.position += Vector3.left * chargeSpeed * Time.deltaTime;
					}
					break;
				case SoldierState.Attack:
					blueUnits [i].obj.GetComponent<Animation> ().Play ("attack");
					break;
				case SoldierState.Died:
					Destroy (blueUnits [i].obj);
					break;
				}
			}
		}

		void FixedUpdate ()
		{
			int[] j = { 0, 16, 18, 17, 20, 19, 11, 13, 12, 15, 14, 6, 8, 7, 10, 9, 1, 3, 2, 5, 4 };

			for (int i = 0; i <= 20; i++) {
				//红军
				if (SoldierState.Walk == redUnits [i].state) {
					redUnits [i].position += Vector3.right * walkSpeed * Time.deltaTime;
					redUnits [i].obj.transform.position = redUnits [i].position;
				} else if (SoldierState.Run == redUnits [i].state) {
					redUnits [i].position += Vector3.right * chargeSpeed * Time.deltaTime;
					redUnits [i].obj.transform.position = redUnits [i].position;
				}

				//红军1
				if (SoldierState.Walk == redUnits1 [i].state) {
					redUnits1 [i].position += redUnits1 [0].direction * walkSpeed * Time.deltaTime;
					redUnits1 [i].obj.transform.position = redUnits1 [i].position;
				} else if (SoldierState.Run == redUnits1 [i].state) {
					redUnits1 [i].position += redUnits1 [0].direction * chargeSpeed * Time.deltaTime;
					redUnits1 [i].obj.transform.position = redUnits1 [i].position;
				}

				//蓝军
				if (SoldierState.Walk == blueUnits [i].state) {
					blueUnits [i].position += Vector3.left * walkSpeed * Time.deltaTime;
					blueUnits [i].obj.transform.position = blueUnits [i].position;
				} else if (SoldierState.Run == blueUnits [i].state) {
					blueUnits [i].position += Vector3.left * chargeSpeed * Time.deltaTime;
					blueUnits [i].obj.transform.position = blueUnits [i].position;
				}
			}

			for (int i = 0; i <= 20; i++) {
				if (SoldierState.Idel == redUnits1 [i].state) {//待机转走动
					redUnits [i].state = SoldierState.Walk;
					redUnits1 [i].state = SoldierState.Walk;
					blueUnits [i].state = SoldierState.Walk;
				} else if (SoldierState.Walk == redUnits [i].state) {
					float heroDistance = Vector3.Distance (redUnits [0].position, blueUnits [0].position);
					if (heroDistance < chargeDistance) {//走动转跑动
						redUnits [i].state = SoldierState.Run;
						blueUnits [i].state = SoldierState.Run;
					}
				} else if (SoldierState.Run == redUnits [i].state) {
					//1:16 2:18 3:17 4:20 5:19 6:11 7:13 8:12 9:15 10:14 11:6 12:7 13:8 14:9 15:10 16:1 17:2 18:3 19:4 20:5

					if (Vector3.Distance (redUnits [i].position, blueUnits [j [i]].position) < attackDistance) {
						redUnits [i].state = SoldierState.Attack;
						redUnits [i].AttackTarget = j [i];
						blueUnits [j [i]].state = SoldierState.Attack;
						blueUnits [j [i]].AttackTarget = i;
					}
				} else if (SoldierState.Attack == redUnits [i].state) {
					if (Random.Range (1, 100) > 80) {
						blueUnits [j [i]].state = SoldierState.Died;
						redUnits [i].AttackTarget = -1;
					}
				} else if (SoldierState.Died == blueUnits [i].state) {
					//死亡补位
					//如果蓝色部队死亡，则红色部队应该围攻另外的单位
					//逻辑是寻找最近的单位
				}
			}

			redUnits [0].direction = (blueUnits [0].position - redUnits [0].position).normalized;
			redUnits1 [0].direction = (blueUnits [0].position - redUnits1 [0].position).normalized;
			blueUnits [0].direction = (redUnits [0].position - blueUnits [0].position).normalized;
		}

		Vector3 GetSoldierPos (int i, Vector3 heroPos, bool isBlue)
		{
			float SoldierDistance = soldierDistance;
			if (isBlue) {
				SoldierDistance = -soldierDistance;
			}

			if (i == 1) {
				return new Vector3 (heroPos.x - SoldierDistance, heroPos.y, heroPos.z);
			} else if (i == 2) {
				return new Vector3 (heroPos.x - SoldierDistance, heroPos.y, heroPos.z + SoldierDistance);
			} else if (i == 3) {
				return new Vector3 (heroPos.x - SoldierDistance, heroPos.y, heroPos.z - SoldierDistance);
			} else if (i == 4) {
				return new Vector3 (heroPos.x - SoldierDistance, heroPos.y, heroPos.z + SoldierDistance * 2);
			} else if (i == 5) {
				return new Vector3 (heroPos.x - SoldierDistance, heroPos.y, heroPos.z - SoldierDistance * 2);
			} else if (i == 6) {
				return new Vector3 (heroPos.x - SoldierDistance * 2, heroPos.y, heroPos.z);
			} else if (i == 7) {
				return new Vector3 (heroPos.x - SoldierDistance * 2, heroPos.y, heroPos.z + SoldierDistance);
			} else if (i == 8) {
				return new Vector3 (heroPos.x - SoldierDistance * 2, heroPos.y, heroPos.z - SoldierDistance);
			} else if (i == 9) {
				return new Vector3 (heroPos.x - SoldierDistance * 2, heroPos.y, heroPos.z + SoldierDistance * 2);
			} else if (i == 10) {
				return new Vector3 (heroPos.x - SoldierDistance * 2, heroPos.y, heroPos.z - SoldierDistance * 2);
			} else if (i == 11) {
				return new Vector3 (heroPos.x - SoldierDistance * 3, heroPos.y, heroPos.z);
			} else if (i == 12) {
				return new Vector3 (heroPos.x - SoldierDistance * 3, heroPos.y, heroPos.z + SoldierDistance);
			} else if (i == 13) {
				return new Vector3 (heroPos.x - SoldierDistance * 3, heroPos.y, heroPos.z - SoldierDistance);
			} else if (i == 14) {
				return new Vector3 (heroPos.x - SoldierDistance * 3, heroPos.y, heroPos.z + SoldierDistance * 2);
			} else if (i == 15) {
				return new Vector3 (heroPos.x - SoldierDistance * 3, heroPos.y, heroPos.z - SoldierDistance * 2);
			} else if (i == 16) {
				return new Vector3 (heroPos.x - SoldierDistance * 4, heroPos.y, heroPos.z);
			} else if (i == 17) {
				return new Vector3 (heroPos.x - SoldierDistance * 4, heroPos.y, heroPos.z + SoldierDistance);
			} else if (i == 18) {
				return new Vector3 (heroPos.x - SoldierDistance * 4, heroPos.y, heroPos.z - SoldierDistance);
			} else if (i == 19) {
				return new Vector3 (heroPos.x - SoldierDistance * 4, heroPos.y, heroPos.z + SoldierDistance * 2);
			} else if (i == 20) {
				return new Vector3 (heroPos.x - SoldierDistance * 4, heroPos.y, heroPos.z - SoldierDistance * 2);
			}
			return heroPos;
		}
	}
}