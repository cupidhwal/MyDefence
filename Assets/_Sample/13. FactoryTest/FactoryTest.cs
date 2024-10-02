using UnityEngine;

namespace Sample
{
    public class FactoryTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            /*//������ ���� => ������ ����
            *//*Slime slime = new Slime();
            slime.Attack();*//*
            Monster slime = CreateMonster(MonsterType.M_Slime);
            slime.Attack();

            //���� ���� => ���� ����
            *//*Zombie zombie = new Zombie();
            zombie.Attack();*//*
            Monster zombie = CreateMonster(MonsterType.M_Zombie);
            zombie.Attack();*/

            /*MonsterFactory monsterFactory = new MonsterFactory();
            Monster slime = monsterFactory.CreateMonster(MonsterType.M_Slime);
            slime.Attack();
            Monster zombie = monsterFactory.CreateMonster(MonsterType.M_Zombie);
            zombie.Attack();*/

            SlimeFactory slimeFactory = new SlimeFactory();
            Monster slime = slimeFactory.CreateMonster();
            slimeFactory.SlimeCount();
            slime.Attack();

            Debug.Log(slimeFactory.count);

            ZombieFactory zombieFactory = new ZombieFactory();
            Monster zombie = zombieFactory.CreateMonster();
            zombie.Attack();
        }

        //�Ű������� MonsterType�� �޾Ƽ� Ÿ�Կ� �°� ���͸� �����ϰ� Monster�� ��ȯ�ϴ� �Լ�
        Monster CreateMonster(MonsterType mType)
        {
            switch(mType)
            {
                case MonsterType.M_Slime:
                    return new Slime();

                case MonsterType.M_Zombie:
                    return new Zombie();
            }

            return null;
        }
    }
}