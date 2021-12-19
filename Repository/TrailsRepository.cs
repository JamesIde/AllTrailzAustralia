using DataAccess;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TrailsRepository : ITrailsRepository
    {

        private readonly ApplicationDbContext _db;

        //Constructor injection: our dependency injection system will populate this 'db' variable with db data
        public TrailsRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<Trail> Create(Trail trail)
        {
            // Define the date, add new trail, save the trail, return the entity
           
            trail.DateCreated = DateTime.Now;
            trail.DateUpdated = DateTime.Now;   

            //Specify the _db.Trails.add instead of _db.Add. This specifies the DbSet which will translate into queries of the Trails table
            var createTrail = _db.Trails.Add(trail);

            _db.SaveChanges();
            return createTrail.Entity;

        }
        public async Task<int> Delete(int id){

            var trail = await _db.Trails.FindAsync(id);
            
            if(trail != null)
            {
                _db.Trails.Remove(trail);
              return  await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Trail> Get(int id)
        {
            var trail = await _db.Trails.FindAsync(id);
            return trail;
        }

        public async Task<IEnumerable<Trail>> GetAll()
        {
            var TrailList =  _db.Trails.OrderByDescending(trail => trail.DateUpdated).ToList();
            return TrailList;
        }

        public async Task<Trail> Update(Trail trail)
        {
            var newTrail = _db.Trails.Find(trail.Id);
            if(newTrail != null)
            {
                newTrail.DateUpdated = DateTime.Now;
                newTrail = _db.Trails.Update(trail).Entity;
                _db.SaveChanges();
            }
            else
            {
                //invalid

            }
            return newTrail;
        }


    }
}
