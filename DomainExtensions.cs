using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваРобота_Ксендзова_ПЗ27
{
    public static class DomainExtensions
    {
        public static string ToDisplayName(this TypeOfWork type) => type switch
        {
            TypeOfWork.LaboratoryWork => "Лабораторна",
            TypeOfWork.DiplomaThesis => "Дипломна",
            TypeOfWork.ScientificExperiment => "Експеримент",
            _ => "Самостійна робота"
        };

        public static string ToDisplayName(this UserRole role) => role switch
        {
            UserRole.Professor => "Викладач",
            UserRole.Assistant => "Аспірант",
            _ => "Студент"
        };


        public static UserRole ToUserRole(this string text) => text switch
        {
            "Викладач" => UserRole.Professor,
            "Аспірант" => UserRole.Assistant,
            _ => UserRole.Student
        };
    }
}
