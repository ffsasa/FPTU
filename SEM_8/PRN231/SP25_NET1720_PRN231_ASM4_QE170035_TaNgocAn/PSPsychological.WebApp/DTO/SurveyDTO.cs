namespace PSPsychological.WebApp.DTO
{
    public class SurveyDTO
    {
        public string Id { get; set; }  
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Number { get; set; }
        public double PointAverage { get; set; }
        public int Verygood { get; set; }
        public int Good { get; set; }
        public int Medium { get; set; }
        public int Bad { get; set; }
        public int VeryBad { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public CategoryDTO Category { get; set; }
    }

    public class CategoryDTO
    {
        public int Id { get; set; }
    }

    public class SurveyDataWrapper
    {
        public List<SurveyDTO> Surveys { get; set; }
    }

}
