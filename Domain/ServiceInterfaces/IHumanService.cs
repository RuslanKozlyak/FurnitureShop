
using Domain.Data;
using System.Collections.Generic;

namespace Domain.ServiceInterfacesHuman
{
    public interface IHumanService
    {
        public IEnumerable<Human> GetAllHumans();

        public Human GetHuman(int humanId);

        public Human GetHumanByQuery(string email,string password);

        public void SetHuman(Human human);

        public void AddHuman(Human human);
        public string HumanId { get; set; }
        public Human Human { get; set; }
    }
}
