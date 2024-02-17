using mvcDay2.Models;

namespace mvcDay2.viewmodel
{
    public class employeedeptmodelview
    {
       public List<Departments> Departments { get; set; }
        public List<employee> employees { get; set; }
        public string name { get; set; }   
    }
}
