using System;
using System.Collections.Generic;
using System.Linq;
using WebApiBlog.Models;

namespace WebApiBlog.Core.DataAccess
{
    public class AccessTokenRepository : IAccessTokenRepository
    {
        private readonly IList<AccessToken> _tokens; 

        public AccessTokenRepository()
        {
            _tokens = new List<AccessToken>();
        }

        public AccessToken FindById(string id)
        {
            return _tokens.FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<AccessToken> FindAll()
        {
            return _tokens;
        }

        public void Save(AccessToken entity)
        {
            _tokens.Add(entity);
        }

        public void Update(AccessToken entity, string id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(AccessToken entity)
        {
            throw new System.NotImplementedException();
        }
    }
}