using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Steel_Groves : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }
        public Steel_Groves(string name)
        {
            Name = name;
            AttackDamage = 20;
            BlockingPower = 15;
        }

        public double SpecialAbility(Hero hero)
        { 
            return hero.Armor * 1.25; //increase protection by 25%
        }
        
    }
}
