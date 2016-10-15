using System;
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
            GameFeatures = new GameFeatures
            {
                // Заполняем все характеристики персонажа
            };
        }

        public GameFeatures GameFeatures;

        /// <summary>
        /// Применить на пользователя определенное умение.
        /// </summary>
        /// <param name="skill"></param>
        public void ApplySkill(Skill skill)
        {
            GameFeatures.AddSkillMe(skill);
        }

        /// <summary>
        /// Проверка может ли пользователь применить какой то скилл.
        /// </summary>
        /// <param name="skill"></param>
        private bool CheckAvailabilitySkill(Skill skill)
        {
            if (GameFeatures.AmountOfMana > skill.CostMana)
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
            throw new NotImplementedException();
        }
    }
}
