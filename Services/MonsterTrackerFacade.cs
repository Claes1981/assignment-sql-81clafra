using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_sql_81clafra.Services
{
    public class MonsterTrackerFacade
    {
        private MonsterRepository _monsterRepo;
        private LocationRepository _locationRepo;
        private HunterRepository _hunterRepo;
        private ObservationRepository _observationRepo;

        public MonsterTrackerFacade()
        {
            // TODO: Initiera alla repositories här
        }

        // Enkla operationer som delegerar till repositories
        public void AddMonster(string name, string type, string dangerLevel)
        {
            // TODO: Skapa Monster-objekt och anropa _monsterRepo.Create()
        }

        // Mer komplexa operationer som kombinerar flera repositories
        public List<Observation> GetObservationsByMonsterType(string type)
        {
            // TODO: Hämta monster av typ, sedan deras observationer
            // Detta kräver anrop till både MonsterRepository och ObservationRepository
        }
    }
}c