using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EntityApp.Models
{
    public class FilterViewModel
    {

        public SelectList Courses { get;}
        public string SelectedName { get;  }

        public FilterViewModel(List<Course> courses, string name) 
        {
            courses.Insert(0, new Course { Name = "All", Id = Guid.NewGuid() });
            Courses = new SelectList(courses, "Id", "Name");
            SelectedName = name;
        }
    }
}
