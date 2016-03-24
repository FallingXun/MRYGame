using UnityEngine;
using System.Collections;

namespace MRYGame
{
    /// <summary>
    /// 投掷技能：目前为投掷飞刀
    /// </summary>
    public class ThrowSkill : Skill
    {
        protected override void SkillBefore()
        {
            base.SkillBefore();
        }

        protected override void SkillRelease()
        {
            GameObject prfab = Resources.Load<GameObject>("Bullets/Bullet_Barrage");
            Transform trans = sourceActor.gameObject.transform;
            GameObject bullet = Instantiate(prfab, trans.localPosition, trans.localRotation)
                as GameObject;
            Rigidbody2D rigid2d = bullet.GetComponent<Rigidbody2D>();
            rigid2d.AddForce((targetActor.transform.localPosition - bullet.transform.localPosition) * 100f,
                ForceMode2D.Force);
        }

        protected override void SkillAfter()
        {
            base.SkillAfter();
        }
    }
}

