using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MRYGame
{
    public class Actor : Unit
    {
        /// <summary>
        /// Buff列表
        /// </summary>
        private List<Buff> buffList = new List<Buff>();

        /// <summary>
        /// 技能列表
        /// </summary>
        private List<Skill> skillList = new List<Skill>();

        void Update()
        {
            OnUpdate();
        }

        /// <summary>
        /// Actor的帧调用
        /// </summary>
        protected virtual void OnUpdate()
        {
            foreach (var buff in buffList)
            {
                buff.BuffOnTick(this);
            }
        }

        /// <summary>
        /// Actor释放技能
        /// </summary>
        public virtual void FireSkill(Actor target, Skill skill)
        {
            skill.Fire(this, target);
        }

        /// <summary>
        /// Actor添加Buff
        /// </summary>
        public virtual void AddBuff(Buff buff)
        {
            buff.BuffOccur(this);
        }

        /// <summary>
        /// Actor移除Buff
        /// </summary>
        public virtual void RemoveBuff(Buff buff)
        {
            buff.BuffRemoved(this);
        }

        /// <summary>
        /// Actor攻击
        /// </summary>
        public virtual void Attack(Actor actor)
        {
            foreach (var buff in buffList)
            {
                buff.BuffBeHit(this);
            }
        }

        /// <summary>
        /// Actor被攻击
        /// </summary>
        public virtual void BeAttack()
        {
            foreach (var buff in buffList)
            {
                buff.BuffBeHurt(this);
            }
        }

        /// <summary>
        /// Actor死亡
        /// </summary>
        public virtual void Die()
        {
            foreach (var buff in buffList)
            {
                buff.BuffAfterKilled(this);
            }
        }
    }
}

