using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApiBlog.Models
{
    public class AccessToken 
    {
        private string _id;
        private Guid _userId;
        private DateTime _expires;
        private DateTime _validFrom;

        public AccessToken(Guid userId)
        {
            _validFrom = DateTime.UtcNow;
            _expires = _validFrom.AddMinutes(5);
            _userId = userId;
            _id = CreateAccessToken();
        }

        public string Id
        {
            get { return _id; }
        }

        public Guid UserId
        {
            get { return _userId; }
        }

        public DateTime Expires
        {
            get { return _expires; }
        }

        public DateTime ValidFrom
        {
            get { return _validFrom; }
        }

        private string CreateAccessToken()
        {
            var algorithm = new SHA256Managed();
            var plainText = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            
            var hash = algorithm.ComputeHash(plainText);
            return Convert.ToBase64String(hash);
        }
    }
}