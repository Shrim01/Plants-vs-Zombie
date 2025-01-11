using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;

namespace Classes
{
    public class ParametersPeas
    {
        public float reload;
        public Sprite bullet;
        public int damageBullet;
        public int speedBullet;
        public int speed;
        public float Health;
        public Sprite evolution;
        public int countBullet;
        public ParametersPeas[] nextEvolution;

        public ParametersPeas(float reload, Sprite bullet, int damageBullet, int speedBullet,
            int speed, float MaxHealth, Sprite evolution, int countBullet, ParametersPeas[] NextEvo)
        {
            this.reload = reload;
            this.bullet = bullet;
            this.damageBullet = damageBullet;
            this.speedBullet = speedBullet;
            this.speed = speed;
            Health = MaxHealth;
            this.evolution = evolution;
            this.countBullet = countBullet;
            nextEvolution = NextEvo;
        }
    }

    public class ParametersChomper
    {
        public float reload;
        public float range;
        public Sprite bullet;
        public int damageBullet;
        public int speedBullet;
        public int speed;
        public float Health;
        public Sprite evolution;
        public int countBullet;
        public ParametersChomper[] nextEvolution;

        public ParametersChomper(float reload, float range, Sprite bullet, int damageBullet, int speedBullet,
            int speed, float MaxHealth, Sprite evolution, int countBullet, ParametersChomper[] NextEvo)
        {
            this.reload = reload;
            this.range = range;
            this.bullet = bullet;
            this.damageBullet = damageBullet;
            this.speedBullet = speedBullet;
            this.speed = speed;
            Health = MaxHealth;
            this.evolution = evolution;
            this.countBullet = countBullet;
            nextEvolution = NextEvo;
        }
    }
}