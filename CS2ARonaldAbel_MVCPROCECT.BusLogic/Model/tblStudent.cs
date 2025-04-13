using System.ComponentModel.DataAnnotations;

namespace CS2ARonaldAbel_MVCPROJECT.BusLogic.Model
{
    public class tblStudent
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required int Age { get; set; }
        public required string Course { get; set; }
    }
}
