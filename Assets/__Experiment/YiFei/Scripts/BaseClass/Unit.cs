using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Unit : MonoBehaviour
    {
        /// <summary>
        /// Unit全局唯一码
        /// </summary>
        protected long uuid;

        /// <summary>
        /// Unit名称
        /// </summary>
        protected string unitName;

        public enum EUnitProperty
        {
            Hp,
            Mp,
            Atk,
            Mtk,
            Def,
            Mdef,
            WalkSpeed,
            SpinSpeed
        }

        /// <summary>
        /// 血量
        /// </summary>
        public float hp;
        public float maxHp;
        /// <summary>
        /// 魔法
        /// </summary>
        public float mp;
        public float maxMp;
        /// <summary>
        /// 物理攻击力
        /// </summary>
        public float atk;
        /// <summary>
        /// 魔法攻击力
        /// </summary>
        public float mtk;
        /// <summary>
        /// 物理防御力
        /// </summary>
        public float def;
        /// <summary>
        /// 魔法防御力
        /// </summary>
        public float mdef;
        /// <summary>
        /// 攻击速度
        /// </summary>
        public float atkSpeed;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float walkSpeed;
        /// <summary>
        /// 旋转速度
        /// </summary>
        public float spinSpeed;
    }
}

