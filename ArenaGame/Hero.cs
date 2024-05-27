﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public abstract class Hero : IHero
    {
        protected Random random = new Random();
        public string Name { get; private set; }
        public double Health { get; private set; }
        public double Armor { get; private set; }
        public double Strenght { get; private set; }
        public IWeapon Weapon { get; private set; }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public Hero(string name, double armor, double strenght, IWeapon weapon)
        {
            Health = 100;

            Name = name;
            if (weapon is Weapons.Steel_Groves groves) Armor += groves.SpecialAbility(this); //If gloves are worn, then the armor increases
            else Armor = armor;
            Strenght = strenght;
            Weapon = weapon;
        }


        // returns actual damage
        public virtual double Attack() 
        {
            double totalDamage = Strenght + Weapon.AttackDamage; 
            double coef = random.Next(80, 120 + 1); 
            double realDamage = totalDamage * (coef / 100);
            return realDamage;
        }

        public virtual double Defend(double damage, Hero hero)
        {
            double coef = random.Next(80, 120 + 1);
            double defendPower = (Armor + Weapon.BlockingPower) * (coef / 100);
            double realDamage = damage - defendPower;
            //Checking whether the attacking character is of the same type as the defender
            if (this.GetType() == hero.GetType() && !(this is Heroes.Archer)) realDamage *= .8; //The power of attack is reduced because the hero and enemy
                                                                                         //of the same type.
                                                                                         //If they are the same type, then they know each other
                                                                                         //better and can protect themselves better.
            if (realDamage < 0)
                realDamage = 0;
            Health -= realDamage;
            return realDamage;
        }

        public override string ToString()
        {
            return $"{Name} with health {Math.Round(Health,2)}";
        }
    }
}
