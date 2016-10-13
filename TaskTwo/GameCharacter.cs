using System.Collections.Generic;
using System.Linq;

namespace TaskTwo
{
    /// <summary>
    /// Игровой персонаж, содержащий в себе характеристики и список скилов которые он умеет делать, а также скиллы примененные к нему.
    /// </summary>
    class GameCharacter
    {
        public GameCharacter(IEnumerable<Skill> mySkills, int healthPoints = 100, int healthPointsRegenerationTime = 200, int amountOfMana = 1000, int manaRegenerationTime = 200, int speed = 10)
        {
            HealthPoints = healthPoints;
            HealthPointsRegenerationTime = healthPointsRegenerationTime;
            AmountOfMana = amountOfMana;
            ManaRegenerationTime = manaRegenerationTime;
            Speed = speed;

            _mySkills = new List<Skill>(mySkills);
            _skillsOnMe = new List<Skill>();
        }

        /// <summary>
        /// Умения которыми обладает персонаж
        /// </summary>
        private List<Skill> _mySkills;
        
        /// <summary>
        /// Умения которые применены на персонажа
        /// </summary>
        private List<Skill> _skillsOnMe;

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

        /// <summary>
        /// Получить значение суммы скиллов примененых на персонажа.
        /// </summary>
        /// <param name="actionSkill"></param>
        /// <returns>Сумма примененных скиллов.</returns>
        private int GetSumValueSkills(ActionSkill actionSkill)
        {
            return _skillsOnMe.Where(x => x.ActionSkill == actionSkill).Sum(x => x.ValueSkill);
        }

        /// <summary>
        /// Применить на пользователя определенное умение.
        /// </summary>
        /// <param name="skill"></param>
        public void ApplySkill(Skill skill)
        {
            _skillsOnMe.Add(skill);
        }

        /// <summary>
        /// Проверка может ли пользователь применить какой то скилл.
        /// </summary>
        /// <param name="skill"></param>
        private bool CheckAvailabilitySkill(Skill skill)
        {
            if (AmountOfMana > skill.CostMana)
                return true;

            return false;
        }

        /// <summary>
        /// Получить умение для применение на игрока или пустить ману на ветер. 
        /// </summary>
        /// <param name="nameSkill"></param>
        /// <returns></returns>
        public Skill GetMySkill(string nameSkill)
        {
            var skill = _mySkills.FirstOrDefault(x => x.Name == nameSkill);

            if (!CheckAvailabilitySkill(skill)) return null;

            AmountOfMana -= skill.CostMana;

            return skill;
        }
    }
}
