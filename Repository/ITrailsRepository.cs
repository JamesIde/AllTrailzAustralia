using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITrailsRepository
    {

        //Define the methods which will be implemented by TrailsRepositoryService
        //CRUD 
        public Task<Trail> Create(Trail trail);

        //Get by Id
        public Task<Trail> Get(int id);  
        //List all Trails (Read)
        public Task<IEnumerable<Trail>> GetAll();   

        //Update
       public Task<Trail>Update(Trail trail);
        //Delete
       public Task<int> Delete(int id);


    }
}
