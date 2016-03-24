using UnityEngine;
using System.Collections;

namespace MRYGame
{
    public class Unit : MonoBehaviour
    {
        /// <summary>
        /// Unitȫ��Ψһ��
        /// </summary>
        protected long uuid;

        /// <summary>
        /// Unit����
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
        /// Ѫ��
        /// </summary>
        public float hp;
        public float maxHp;
        /// <summary>
        /// ħ��
        /// </summary>
        public float mp;
        public float maxMp;
        /// <summary>
        /// ��������
        /// </summary>
        public float atk;
        /// <summary>
        /// ħ��������
        /// </summary>
        public float mtk;
        /// <summary>
        /// ���������
        /// </summary>
        public float def;
        /// <summary>
        /// ħ��������
        /// </summary>
        public float mdef;
        /// <summary>
        /// �����ٶ�
        /// </summary>
        public float atkSpeed;
        /// <summary>
        /// �ƶ��ٶ�
        /// </summary>
        public float walkSpeed;
        /// <summary>
        /// ��ת�ٶ�
        /// </summary>
        public float spinSpeed;
    }
}

