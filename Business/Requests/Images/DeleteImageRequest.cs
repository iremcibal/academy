using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Images
{
    public class DeleteImageRequest
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
    }
}
