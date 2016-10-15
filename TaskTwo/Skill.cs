namespace TaskTwo
{
    public class Skill
    {
        /// <summary>
        /// Название умения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость данной способности, измеряется в мане.
        /// </summary>
        public int CostMana { get; set; }

        /// <summary>
        /// Время действия способности.
        /// </summary>
        public int ActionTime { get; set; }

        /// <summary>
        /// Время перезарядки способности.
        /// </summary>
        public int RechargeTime { get; set; }

        /// <summary>
        /// На что направлено умение
        /// </summary>
        public ActionSkill ActionSkill { get; set; }

        /// <summary>
        /// Значение данного действия, например + 100 ХП или -20 Маны.
        /// </summary>
        public int ValueSkill { get; set; }
    }
}
