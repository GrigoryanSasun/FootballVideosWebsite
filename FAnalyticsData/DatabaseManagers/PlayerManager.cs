using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAnalyticsData.DatabaseManagers
{
    public class PlayerManager
    {
        public List<PlayerParticipation> GetAll()
        {
            using(DBDataContext db =new DBDataContext())
            {
                return (from q in db.PlayerParticipations
                        select q).ToList();
            }
            
        } 
    }
}
