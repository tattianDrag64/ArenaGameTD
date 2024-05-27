using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Archer : Hero //weapons with which he knows how to use: Bow. 
    {
        private double distance; //the distance that he can be
        internal int hitCount;
        public Archer(string name, double armor, double strenght, IWeapon weapon) :
            base(name, armor, strenght, weapon)
        {
            hitCount = 0;
            if (weapon is Weapons.Bow) distance = random.Next(10, 151); //the min distance at which it can be is 10m, and the max is 150m
        }

        public override double Attack()
        {
            double damage = base.Attack();
            
            double probability = random.NextDouble();
            if (Weapon is Weapons.Bow bow) 
            {
                hitCount++;
                if (probability > 0.50) damage *= (150.0 - distance) / 150.0; //the attack damage depends on the distance at which the archer is located
                else damage *= (150.0 - distance) / 200.0;
                distance = Math.Max(0, distance - 10); //after each attack, the archer approaches the enemy
                damage += bow.SpecialAbility(this);
            }
            else damage *= .5; //if the weapon is not a bow, then the archer is harder for them to fight
            return damage;
        }

        //if the hero doesn't use his weapon, then his attack decreases

        public override double Defend(double damage, Hero enemy)
        {
            double defend = base.Defend(damage, enemy) * (150.0 - distance) / 150.0;  
            if (Weapon is Weapons.Bow)
            {
                if (enemy is Archer) defend *= 1.5; //if the opponent is Sagittarius, then the damage increases,                                                       
                                                    //because the archer can get a lot of damage from a long attack
                else return defend * .6; //If the opponent of another species uses onions, then there will be less damage
            } 
            return defend;
        }
    }
}
