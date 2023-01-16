using System.ComponentModel.DataAnnotations;

namespace SmartTechnology.Dto
{
    public class SizeDto
    {
        //NOTE: Size value could be string or integer type according to need
        public int Id { get; set; }
        public int SizeValue { get; set; }
    }
}
