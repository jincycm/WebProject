namespace ProductProject.Models.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class ResponseDto
    {

        public int Retval { get; set; }
        public string RetMsg { get; set; }


    }
}
