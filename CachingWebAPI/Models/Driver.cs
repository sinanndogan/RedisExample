using System.ComponentModel.DataAnnotations.Schema;

namespace CachingWebAPI.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int  DriveNumber { get; set; }
    }
}
