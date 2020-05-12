namespace Twinvision.BolRetailerApi
{
    public enum ConditionName { NEW, AS_NEW, GOOD, REASONABLE, MODERATE }

    public class Condition
    {
        /// <summary>The condition of the offered product.</summary>
        public string Name { get; set; }
        /// <summary>The category of the condition. If not given NEW or SECONDHAND is derived from NAME.</summary>
        public string Category { get; set; }
        /// <summary>The description of the condition of the product. Only allowed if name is not NEW and may not contain e-mail addresses. Max 2000 characters.</summary>
        public string Comment { get; set; }
        public Condition(ConditionName conditionName)
        {
            Name = conditionName.ToString();
        }
    }
}
