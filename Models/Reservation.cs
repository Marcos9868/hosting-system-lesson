using System.Security.Cryptography;

namespace HostingSystem.Models
{
    public class Reservation
    {
        public List<Person> People { get; set; } = new List<Person>();
        public Suite? Suite { get; set; }
        public int ReservedDays { get; set; } = 0;
        public Reservation() {}
        public Reservation(int reservedDays)
        { ReservedDays = reservedDays; }
        public void AddPeople(List<Person> people)
        {   
            if (Suite?.Capacity >= people.Count)
            {
                People = people;
            }
            else
            {
                throw new Exception();    
            }
        }
        public void AddSuite(Suite suite)
        {
            Suite = suite;
        }
        public int GetPeopleQuantity()
        {
            var people = People.Count;
            return people;
        }
        public decimal CalculateDiaryValue(bool discount = false)
        {
            decimal diaryValue;
            if (discount)
            {
                diaryValue = (decimal)(ReservedDays * Suite?.DiaryValue);
                diaryValue *= 0_9;
                return diaryValue;
            }
            diaryValue = (decimal)(ReservedDays * Suite?.DiaryValue);
            return diaryValue;
        }
    }
}