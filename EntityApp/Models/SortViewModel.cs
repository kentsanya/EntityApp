using EntityApp.Other;

namespace EntityApp.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; }
        public SortState DurationDays { get; set; }
        public SortState Current { get; set; }
        public bool Up { get; set; }

        public SortViewModel(SortState state) 
        {
            NameSort = SortState.NameAsc;
            DurationDays = SortState.DurationDaysAsc;
            Up = true;

            if (state == SortState.NameDesc || state == SortState.DurationDaysDesc)
            {
                Up = false;
            }
            switch (state) 
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.DurationDaysAsc:
                    Current = NameSort = SortState.DurationDaysDesc;
                    break;
                case SortState.DurationDaysDesc:
                    Current = NameSort = SortState.DurationDaysAsc;
                    break;
                default:
                    Current=NameSort = SortState.NameDesc;
                    break;

            }
        } 
    }
}
