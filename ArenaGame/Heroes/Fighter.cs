using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Fighter : Hero //weapons with which he knows how to use: Steel Groves and Wargammer. 
    {
        private double aggressionCoef; //If the aggression of the fighter increases,
                                       //his blows become more accurate, but the protection is less strong
        public Fighter(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
            aggressionCoef = 1;
        }

        public override double Attack()
        {
            double damage = base.Attack();
            double probability = random.NextDouble();
            if (probability > .5)
            {
                damage *= aggressionCoef;
                aggressionCoef += .1; //If the probability of a blow is more than 50%, then aggression increases by 1% and the blow stronger
            }
            else
            {
                damage *= aggressionCoef;
                aggressionCoef += .2; //If the probability of a blow is less than 50%, then aggression increases by 20%
            }
            if (Weapon is Weapons.Warhammer) damage += Weapon.SpecialAbility(this);
            else if (Weapon is Weapons.Dagger || Weapon is Weapons.Sword) return damage * .4;
            else if (Weapon is Weapons.Bow) return damage * .2;
            return damage;
        }

        public override double Defend(double damage, Hero enemy)
        {
            return base.Defend(damage, enemy) * aggressionCoef;
        }
    }
}
