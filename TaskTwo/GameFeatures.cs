using System.Collections.Generic;
using System.Linq;

namespace TaskTwo
{
    public class GameFeatures
    {
        /// <summary>
        /// Умения которыми обладает персонаж
        /// </summary>
        private List<Skill> _mySkills;

        /// <summary>
        /// Умения которые применены на персонажа
        /// </summary>
        private List<Skill> _skillsOnMe;


        public void AddSkillMe(Skill skill)
        {
            _skillsOnMe.Add(skill);
        }

        /// <summary>
        /// Получить значение суммы скиллов примененых на персонажа.
        /// </summary>
        /// <param name="actionSkill"></param>
        /// <returns>Сумма примененных скиллов.</returns>
        private int GetSumValueSkills(ActionSkill actionSkill)
        {
            return _skillsOnMe.Where(x => x.ActionSkill == actionSkill).Sum(x => x.ValueSkill);
        }

        private int _healthPoints;
        public int HealthPoints
        {
            get { return _healthPoints += GetSumValueSkills(ActionSkill.HealthPoitns); }
            private set { _healthPoints = value; }
        }

        private int _healthPointsRegenerationTime;
        public int HealthPointsRegenerationTime
        {
            get { return _healthPointsRegenerationTime += GetSumValueSkills(ActionSkill.HealthPointsRegenerationTime); }
            private set { _healthPointsRegenerationTime = value; }
        }

        private int _amountOfMana;
        public int AmountOfMana
        {
            get { return _amountOfMana += GetSumValueSkills(ActionSkill.AmountOfMana); }
            private set { _amountOfMana = value; }
        }

        private int _manaRegenerationTime;
        public int ManaRegenerationTime
        {
            get { return _manaRegenerationTime += GetSumValueSkills(ActionSkill.ManaRegenerationTime); }
            private set { _manaRegenerationTime = value; }
        }

        private int _speed;
        public int Speed
        {
            get { return _speed += GetSumValueSkills(ActionSkill.Speed); }
            private set { _speed = value; }
        }

        public int AmountOfGold { get; set; }
    }
}