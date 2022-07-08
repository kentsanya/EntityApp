
namespace EntityApp.Models
{
    public class FilteringSortingViewModel
    {
        public IEnumerable<Course> Courses { get; set; } 
        public SortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel {get;}
        public FilteringSortingViewModel(IEnumerable<Course> courses, SortViewModel sortViewModel, FilterViewModel filterViewModel)
        {
            Courses = courses;
            SortViewModel = sortViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}
