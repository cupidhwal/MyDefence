using UnityEngine;

namespace Sample
{
    public class MonsterFactory
    {
        //�Ű������� MonsterType�� �޾Ƽ� Ÿ�Կ� �°� ���͸� �����ϰ� Monster�� ��ȯ�ϴ� �Լ�
        public Monster CreateMonster(MonsterType mType)
        {
            switch (mType)
            {
                case MonsterType.M_Slime:
                    return new Slime();

                case MonsterType.M_Zombie:
                    return new Zombie();

                case MonsterType.M_Goblin:
                    return new Goblin();
            }

            return null;
        }
    }
}