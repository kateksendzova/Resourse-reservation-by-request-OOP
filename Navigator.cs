using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public enum AppPage
    {
        Main,
        AddRequest,
        MySchedule,
        Schedule,
        DeleteRequest
    }

    public static class Navigator
    {
        public static Form Create(AppPage page, UserContext user) => page switch
        {
            AppPage.Main => new MainForm_FirstWindow(user),
            AppPage.AddRequest => new AddRequestForm(user),
            AppPage.MySchedule => new MySchedule_Form(user),
            AppPage.Schedule => new Schedule_Form(user),
            _ => new DeleteRequestForm(user)
        };
    }
}
