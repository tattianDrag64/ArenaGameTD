using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Warhammer : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }
        public Warhammer(string name)
        {
            Name = name;
            AttackDamage = 20;
            BlockingPower = 10;
        }

        public double SpecialAbility(Hero hero) //A fighter can cause a wave of blows
        {
            if (hero is Heroes.Fighter fighter)
            {
                Random random = new Random();
                double probability = random.NextDouble();
                if (probability > 0.7) return fighter.Attack() * .005;
            }
            return 0;
        }
        
    }
}

