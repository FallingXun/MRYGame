using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MRYGame
{
    [TaskCategory("Enemy")]
    public class EnemyAttackAction : Action
    {
        public SharedGameObject enemyGameObject;
        public SharedGameObject playerGameObject;

        public override TaskStatus OnUpdate()
        {
            if (playerGameObject.Value != null)
            {
                Hero hero = playerGameObject.Value.GetComponent<Hero>();
                Enemy enemy = enemyGameObject.Value.GetComponent<Enemy>();
                ThrowSkill skill = enemy.GetComponent<ThrowSkill>();
                enemy.FireSkill(hero, skill);

                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Running;
            }
        }
    }
}
