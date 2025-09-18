namespace HostingSystem.Models
{
    public class Suite
    {
        public string SuiteType { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal DiaryValue { get; set; } = 0_0;
        public Suite() { }
        public Suite(string suiteType, int capacity, decimal diaryValue)
        {
            SuiteType = suiteType;
            Capacity = capacity;
            DiaryValue = diaryValue;
        }
    }
}