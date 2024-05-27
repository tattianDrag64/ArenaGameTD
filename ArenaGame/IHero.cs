using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public interface IHero 
    {
        double Attack();
        double Defend(double damage, Hero hero); //If the hero will fight with the same hero as he, then the protection will work differently
    }
}
