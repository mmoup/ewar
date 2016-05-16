using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public struct HeroStruct :SoldierInterface
	{
		//渲染对象
		public GameObject obj;

		//实际坐标
		public Vector3 position;

		//运动方向
		public Vector3 direction;

		//行走速度
		public float walkSpeed;

		//跑动速度
		public float runSpeed;

		//状态
		public SoldierState state;

		//攻击目标
		public int AttackTarget;

		//进攻
		void SoldierInterface.Attack ()
		{
		}
	}

}