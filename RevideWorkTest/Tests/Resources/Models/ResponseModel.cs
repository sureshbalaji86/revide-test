using System.Collections.Generic;

namespace RevideWorkTest.Tests.Resources.Models
{
    public class ResponseModel
    {
        public int TotalResults { get; set; }
        public List<UserModel> Results { get; set; }
        public ResponseModel()
        {
        }
    }
}
