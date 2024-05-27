using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Bow : IWeapon {
         public string Name { get; set; }
         public double AttackDamage { get; private set; }
         public double BlockingPower { get; private set; }

         public Bow(string name)
         {
             Name = name;
             AttackDamage = 20;
             BlockingPower = 1;
         }

        public double SpecialAbility(Hero hero) //If the archer uses a bow,
                                                //then every third shot will be two arrows
        {
            if (hero is Heroes.Archer archer && archer.hitCount % 3 == 0) return archer.Attack();
            return 0;
        }

        double IWeapon.SpecialAbility(Hero hero)
        {
            throw new NotImplementedException();
        }
    }
}
