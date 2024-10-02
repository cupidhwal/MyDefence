using UnityEngine;

namespace Sample
{
    //몬스터 타입
    public enum MonsterType
    {
        M_Slime,
        M_Zombie,
        M_Goblin
        //...
    }

    public abstract class Monster
    {
        public abstract void Attack();
    }

    public class Slime : Monster
    {
        public override void Attack()
        {
            Debug.Log("Attack Slime");
        }
    }

    public class Zombie : Monster
    {
        public override void Attack()
        {
            Debug.Log("Attack Zombie");
        }
    }

    public class Goblin : Monster
    {
        public override void Attack()
        {
            Debug.Log("Attack Goblin");
        }
    }
}