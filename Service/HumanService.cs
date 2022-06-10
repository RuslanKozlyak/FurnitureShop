
using Domain.Data;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Domain.ServiceInterfacesHuman;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class HumanService : IHumanService
    {
        private static ISession _session;
        public string HumanId { get; set; }
        public Human Human { get; set; }

        private readonly IRepository<Human> _humanRepository;
        public HumanService(IRepository<Human> humanRepository)
        {
            _humanRepository = humanRepository;
        }

        public IEnumerable<Human> GetAllHumans()
        {
            var humans = _humanRepository.GetAll();
            return humans;
        }

        public Human GetHuman(int humanId)
        {
            return _humanRepository.Get(humanId);
        }

        public static HumanService CheckSignIn(IServiceProvider service)
        {
            _session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var HumanRep = service.GetRequiredService<IRepository<Human>>();

            return new HumanService(HumanRep);
        }

        public Human GetHumanByQuery(string email,string password)
        {
            var findedHumans = _humanRepository.GetAll()
               .Where(human => human.Email == email & human.Password == password).First();

            return findedHumans;
        }

        public IEnumerable<Order> GetHumanOrder(string humanId)
        {
            return _humanRepository.Get(int.Parse(humanId), include => include.Orders).Orders;
        }

        public void SetHuman(Human human)
        {
            _session.SetString("HumanId", human.Id.ToString());
            _session.SetString("FirstName", human.FirstName);
            _session.SetString("LastName", human.LastName);
        }

        public void AddHuman(Human human)
        {
            _humanRepository.Insert(human);
        }
    }
}
