using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public interface IMonsterFactory
    {
        Monster CreateMonster();    //���丮 �޼���
    }

    public abstract class MonstersFactory
    {
        private List<Monster> monsters = new List<Monster>();
        public List<Monster> Monsters { get { return monsters; } }
        public abstract Monster CreateMonster();
    }

    public class SlimeFactory : MonstersFactory
    {
        public int count = 0;

        public override Monster CreateMonster()
        {
            //monsters.Add(new Slime());
            return new Slime();
        }

        public void SlimeCount() => count++;
    }

    public class ZombieFactory : IMonsterFactory
    {
        public Monster CreateMonster()
        {
            return new Zombie();
        }

        public void AddSomething()
        {
            Debug.Log("Add Something");
        }
    }

    public class GoblinFactory : IMonsterFactory
    {
        public Monster CreateMonster()
        {
            return new Goblin();
        }
    }
}