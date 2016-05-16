using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public enum SoldierState
	{
		Idel = 0,
		Walk = 2,
		Run = 3,
		Attack = 4,
		Died = 5
	}

	public struct SoldierStruct :SoldierInterface
	{
		//渲染对象
		public GameObject obj;

		//英雄
		public HeroStruct hero;

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